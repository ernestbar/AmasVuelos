using prySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos.Paginas.Participante
{
    public partial class frmUsuario : cBasePagina
    {

        public string _CodParticipante
        {
            get
            {
                if (hfOpciones.Contains("_CodParticipante"))
                {
                    return (hfOpciones.Get("_CodParticipante").ToString());
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
        public string _EsJuridica
        {
            get
            {
                if (hfOpciones.Contains("_EsJuridica"))
                {
                    return (hfOpciones.Get("_EsJuridica").ToString());
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfOpciones.Set("_EsJuridica", value);
            }
        }

        

        public string _CodPerpsonal
        {
            get
            {
                if (hfOpciones.Contains("_CodPerpsonal"))
                {
                    return (hfOpciones.Get("_CodPerpsonal").ToString());
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfOpciones.Set("_CodPerpsonal", value);
            }
        }


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

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (cGestorSession.GetValue("usuario") == null)
            {
                Response.Redirect("~/frmLogin.aspx", true);
            }
            if (!Page.IsPostBack)
            {
                _EsNuevo = true;
                _CodParticipante = Session["codParticipante"].ToString();
                _CodPerpsonal = Session["codPersonal"].ToString();
                _EsJuridica = Session["esJuridica"].ToString();
                _LimpiarCampos();
                dtHasta.Value = String.Empty; 
            }
            _cargarUsuarios(_CodParticipante, _CodPerpsonal);
        }
        public void _CargarDdlRoles()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_ROLES";
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlRol, vRespuesta._Tabla, "ROL", "DESCRIPCION");
            }
        }

        private void _LimpiarCampos()
        {
            txtCuentaUsuario.Text = String.Empty;
            txtDEscripsionUsuario.Text = String.Empty;
            dtFechaDesde.Date = DateTime.Now;
            dtHasta.Value = string.Empty;
            _CargarDdlRoles();
            _EsNuevo = true;
        }



        private void _cargarUsuarios(string codParticipante, string codPersonal)
        {
            try
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_USUARIOS";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PERSONAL", Direction = System.Data.ParameterDirection.Input, Value = _CodPerpsonal });

                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgUsuarios, vRespuesta._Tabla, "USUARIO");
                }

            }
            catch (Exception)
            {
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            StringBuilder vMensaje = new StringBuilder();
            if (string.IsNullOrEmpty(txtCuentaUsuario.Text))
            {
                vMensaje.Append("La cuenta de usuario no puede ser vacio </br>");
            }

            if (dtFechaDesde.Date == null)
            {
                vMensaje.Append("La fecha de inicio no puede ser vacia</br>");
            }

            if (rdlEstado.SelectedIndex <= -1)
            {
                vMensaje.Append("El estado no puede ser vacio</br>");
            }

            if (!new cDevComboBox()._ValidaCombos(ddlRol )  )
            {
                vMensaje.Append("El rol no debe ser vacio</br>");
            }


            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }     

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_USUARIO";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIOI", Direction = System.Data.ParameterDirection.Input, Value = txtCuentaUsuario.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD_ANTERIOR", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = txtDEscripsionUsuario.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = dtFechaDesde.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = (dtHasta.Value == null)? DateTime.Parse("01/01/3000"): dtHasta.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_ROL", Direction = System.Data.ParameterDirection.Input, Value = ddlRol.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _EsJuridica=="1"? _CodPerpsonal: _CodParticipante });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_PADRE", Direction = System.Data.ParameterDirection.Input, Value = _EsJuridica == "1" ? _CodParticipante: _CodPerpsonal });            

            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                if (_EsNuevo)
                {
                    _EsNuevo = true;
                    _LimpiarCampos();
                }
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);                
                _cargarUsuarios(_CodParticipante, _CodPerpsonal);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        protected void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            if (_EsNuevo)
            {
                string vMensaje = "Debe seleccionar un registro para cambiar la contraseña";
                ShowMessage(vMensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vMensaje, eTipoRespuesta.Advertencia);
            }
            else
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_USUARIO";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "R" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIOI", Direction = System.Data.ParameterDirection.Input, Value = txtCuentaUsuario.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD_ANTERIOR", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_ROL", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_PADRE", Direction = System.Data.ParameterDirection.Input, Value ="" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);

                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _LimpiarCampos();
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
        }

        protected void rdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_USUARIO";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = rdlEstado.SelectedIndex == 0 ? "A" : "D" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIOI", Direction = System.Data.ParameterDirection.Input, Value = txtCuentaUsuario.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD_ANTERIOR", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_ROL", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_PADRE", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _LimpiarCampos();
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

        protected void btnModificar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            string usuario = e.CommandArgument.ToString();
            txtCuentaUsuario.Enabled = false;
            _EsNuevo = false;
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_USUARIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PERSONAL", Direction = System.Data.ParameterDirection.Input, Value = _CodPerpsonal });

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                foreach (DataRow vFila in vRespuesta._Tabla.Rows)
                {
                    if (vFila["USUARIO"].ToString() == usuario)
                    {
                        _EsNuevo = false;
                        txtCuentaUsuario.Text = vFila["USUARIO"].ToString();
                        txtDEscripsionUsuario.Text = vFila["DESCRIPCION"].ToString();
                        dtFechaDesde.Date = DateTime.Parse(vFila["FECHA_DESDE"].ToString());

                        if (String.IsNullOrEmpty(vFila["FECHA_HASTA"].ToString()))
                            dtHasta.Value = String.Empty;                        
                        else                        
                            this.dtHasta.Date = DateTime.Parse(vFila["FECHA_HASTA"].ToString());

                      //  dtHasta.Date = DateTime.Parse(vFila["FECHA_HASTA"].ToString());
                        rdlEstado.SelectedIndex = vFila["ESTADO"].ToString() == "A" ? 0 : 1;
                        _CargarDdlRoles();
                        ddlRol.SelectedItem = ddlRol.Items.FindByValue(vFila["rol"].ToString());
                    }
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuentaUsuario.Enabled = true;
            _EsNuevo = true;
            txtDEscripsionUsuario.Text = string.Empty;
            dtFechaDesde.Date = DateTime.Now;
            dtHasta.Value = string.Empty;
            rdlEstado.SelectedIndex = 0;
            _CargarDdlRoles();
        }
    }


}