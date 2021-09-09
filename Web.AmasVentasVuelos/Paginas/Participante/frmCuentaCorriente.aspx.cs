using DevExpress.Web;
using prySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos.Paginas.Participante
{
    public partial class frmCuentaCorriente : cBasePagina
    {
        public bool _EsNuevo
        {
            get
            {
                if (hfOpciones.Contains("_EsNuevo"))
                {
                    return bool.Parse(hfOpciones.Get("_EsNuevo").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfOpciones.Set("_EsNuevo", value);
            }
        }

        public string _CodParticipante
        {
            get
            {
                if (hfOpciones.Contains("_CodParticipante"))
                {
                    return hfOpciones.Get("_CodParticipante").ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfOpciones.Set("_CodParticipante", value);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (cGestorSession.GetValue("usuario") == null)
            {
                Response.Redirect("~/frmLogin.aspx", true);
            }

            if (!Page.IsPostBack)
            {
                _EsNuevo = true;
                _Limpiar();
                lblCodigo.Text = "";
                ASPxTabControl1.ActiveTabIndex = 0;
                mvCuentasCorrientes.ActiveViewIndex = 0;
                _CargarDgCuentasCorrientesAAsignar();
                _CargarParticipantes();
            }
            _CargarDgCuentasCorrientes();
            _CargarDgCuentasCorrientesAsignados();
            ShowMessage();

        }

        private void _CargarDgCuentasCorrientes()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CUENTAS_CORRIENTES";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevGrilla()._CargarDatos(dgCuentasCorrientes, vRespuesta._Tabla, "COD_CUENTA_CORRIENTE");
            }
        }

        private void _ActualizarCuentaCorriente()
        {
            String txtCodigoCuenta = this.txtCodigoCuenta.Text.Trim();
            String txtDescripcion = this.txtDescripcion.Text.Trim();



            StringBuilder vMensaje = new StringBuilder();

            if (string.IsNullOrEmpty(txtCodigoCuenta))
            {
                vMensaje.Append("El Código de Cuenta no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

            if (dtFechaHasta.Value == null)
            {
                dtFechaHasta.Value = DateTime.Parse("01/01/3000");
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_CUENTA_CORRIENTE";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CUENTA_CORRIENTE", Direction = System.Data.ParameterDirection.Input, Value = lblCodigo.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CODIGO_CUENTA", Direction = System.Data.ParameterDirection.Input, Value = txtCodigoCuenta });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcion });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = dtFechaDesde.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = dtFechaHasta.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                btnLimpiar_Click(btnLimpiar, null);
                _CargarDgCuentasCorrientes();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                _EsNuevo = true;
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _ActualizarCuentaCorriente();
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                _Limpiar();
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);
            }
        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string _CodCuentaCorriente = e.CommandArgument.ToString();
                lblCodigo.Text = e.CommandArgument.ToString();

                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_CUENTAS_CORRIENTES";

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {

                    foreach (DataRow vfila in vRespuesta._Tabla.Rows)
                    {
                        if (vfila["COD_CUENTA_CORRIENTE"].ToString() == _CodCuentaCorriente)
                        {
                            txtCodigoCuenta.Text = vfila["CODIGO_CUENTA"].ToString();
                            txtDescripcion.Text = vfila["DESCRIPCION"].ToString();
                            this.dtFechaDesde.Date = DateTime.Parse(vfila["FECHA_DESDE"].ToString());
                            this.rbtnEstado.SelectedIndex = vfila["ESTADO"].ToString() == "A" ? 0 : 1;

                            if (String.IsNullOrEmpty(vfila["FECHA_HASTA"].ToString()))
                            {
                                dtFechaHasta.Value = String.Empty;
                            }
                            else
                            {
                                this.dtFechaHasta.Date = DateTime.Parse(vfila["FECHA_HASTA"].ToString());
                            }

                            break;
                        }
                    }

                    _EsNuevo = false;
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);
            }
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string _CodCuentaCorriente = e.CommandArgument.ToString();

                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_CUENTA_CORRIENTE";
                List<SqlParameter> vLista = new List<SqlParameter>();


                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "D" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CUENTA_CORRIENTE", Direction = System.Data.ParameterDirection.Input, Value = _CodCuentaCorriente });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_CODIGO_CUENTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {

                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    btnLimpiar_Click(btnLimpiar, null);
                    _CargarDgCuentasCorrientes();
                    _EsNuevo = true;
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);

            }

        }


        private void _Limpiar()
        {
            txtCodigoCuenta.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            dtFechaDesde.Date = DateTime.Now.Date;

            _EsNuevo = true;
            lblCodigo.Text = "";
        }

        protected void rbtnEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_CUENTA_CORRIENTE";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = rbtnEstado.SelectedItem.Value.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CUENTA_CORRIENTE", Direction = System.Data.ParameterDirection.Input, Value = this.lblCodigo.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_CODIGO_CUENTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    btnLimpiar_Click(btnLimpiar, null);
                    _CargarDgCuentasCorrientes();
                    _EsNuevo = true;
                    this.lblCodigo.Text = "";
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);

            }
        }


        // PARTE DOS DE LA PANTALLA

        private void _CargarDgCuentasCorrientesAAsignar()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CUENTAS_CORRIENTES_A_ASIGNAR";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito )
            {
                new cDevComboBox()._CargarComboBox(ddlCuentaCorrriente, vRespuesta._Tabla, "COD_CUENTA_CORRIENTE", "CODIGO_CUENTA");
            }
        }

        private void _CargarDgCuentasCorrientesAsignados()
        {
            if (!string.IsNullOrEmpty(_CodParticipante))
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_CUENTAS_CORRIENTES_ASIGNADOS";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgParticipante, vRespuesta._Tabla, "COD_CUENTA_CORRIENTE");
                }
            }
        }


        // PARTE 2 (ASIGNACIONES)

        private void _CargarCuentasCorrientesAAsignar()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CUENTAS_CORRIENTES_A_ASIGNAR";
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlCuentaCorrriente, vRespuesta._Tabla, "COD_CUENTA_CORRIENTE", "CODIGO_CUENTA");
            }
        }


        private void _CargarParticipantes()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlParticipante, vRespuesta._Tabla, "COD_PARTICIPANTE", "DESC_RAZON_SOCIAL");
            }
        }

        private void _AsignarDesasignar(string pTipoOperacion)
        {
            if (pTipoOperacion=="I")
            {
                StringBuilder vMensaje = new StringBuilder();
                if (!new cDevComboBox()._ValidaCombos(ddlParticipante))
                {
                    vMensaje.Append("Debe seleccionar un participante</br>");
                }

                if (!new cDevComboBox()._ValidaCombos(ddlCuentaCorrriente))
                {
                    vMensaje.Append("Debe seleccionar una cuenta corriente</br>");
                }


                string vMensajeValidacion = vMensaje.ToString();
                if (!string.IsNullOrEmpty(vMensajeValidacion))
                {
                    ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                    ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                    return;
                }

                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_CUENTA_PARTICIPANTE";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = pTipoOperacion });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CUENTA_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlParticipante.SelectedItem.Value.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CUENTA_CORRIENTE", Direction = System.Data.ParameterDirection.Input, Value = ddlCuentaCorrriente.SelectedItem.Value.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });
                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _CargarDgCuentasCorrientesAAsignar();
                    _CargarParticipantes();
                    _CargarDgCuentasCorrientesAsignados();
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }


            }
            if (pTipoOperacion == "D")
            {
                StringBuilder vMensaje = new StringBuilder();
                if (!new cDevComboBox()._ValidaCombos(ddlParticipante))
                {
                    vMensaje.Append("Debe seleccionar un participante</br>");
                }

                if (dgParticipante.FocusedRowIndex<=-1)
                {
                    vMensaje.Append("Debe seleccionar un registro asignado para desasignar </br>");
                }
                string vMensajeValidacion = vMensaje.ToString();
                if (!string.IsNullOrEmpty(vMensajeValidacion))
                {
                    ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                    ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                    return;
                }

                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_CUENTA_PARTICIPANTE";
                List<SqlParameter> vLista = new List<SqlParameter>();
                string dato = dgParticipante.GetDataRow(dgParticipante.FocusedRowIndex)["COD_CUENTA_CORRIENTE"].ToString();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = pTipoOperacion });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CUENTA_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = dgParticipante.GetDataRow(dgParticipante.FocusedRowIndex)["COD_CUENTA_PARTICIPANTE"].ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CUENTA_CORRIENTE", Direction = System.Data.ParameterDirection.Input, Value = dgParticipante.GetDataRow(dgParticipante.FocusedRowIndex)["COD_CUENTA_CORRIENTE"].ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });
                                             
                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _CargarDgCuentasCorrientesAAsignar();
                    _CargarParticipantes();
                    _CargarDgCuentasCorrientesAsignados();
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }





               
        }

        protected void ASPxTabControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            mvCuentasCorrientes.ActiveViewIndex = e.Tab.Index;
        }

        protected void ddlParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new cDevComboBox()._ValidaCombos(ddlParticipante))
            {
                _CodParticipante = ddlParticipante.Value.ToString();
                _CargarDgCuentasCorrientesAsignados();
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            _AsignarDesasignar("I");

        }

        protected void btnDesasignar_Click(object sender, EventArgs e)
        {
            _AsignarDesasignar("D");
        }
    }
}







