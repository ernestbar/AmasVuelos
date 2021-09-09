using DevExpress.Web;
using prySqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.AmasVentasVuelos.Helper;


namespace Web.AmasVentasVuelos.Paginas.Transacciones
{
    public partial class frmTransaccionesAdmin : cBasePagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _cargarTipoTransaccion();
                _CargarTipoParticipantesCombo();
                _CargarMotivoTransaccionCombo();
                MultiView1.ActiveViewIndex = 0;
            }
        }

        private void _cargarTipoTransaccion()
        {
            ddlTipoTransaccion.Items.Clear();
            ddlTipoTransaccion.Items.Insert(0, "SELECCIONAR");
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "TIPO TRANSACCION" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                foreach (DataRow dr in vRespuesta._Tabla.Rows)
                {
                    ListItem miItem = new ListItem();
                    miItem.Text = dr["DESCRIPCION"].ToString();
                    miItem.Value = dr["CODIGO"].ToString();
                    ddlTipoTransaccion.Items.Add(miItem);
                }
            }
        }
        private void _CargarParticipantesCombo()
        {
            //cblParticipantes.Items.Clear();
            ddlParticipantes.Items.Clear();
            ddlParticipantes.Items.Insert(0, "SELECCIONAR");
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES_UPFRONT_OK";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoParticipante.SelectedValue });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
                {
                    foreach (DataRow dr in vRespuesta._Tabla.Rows)
                    {
                        ListItem miItem = new ListItem();
                        string nombre = "";
                        string codigo = "";
                        if (String.IsNullOrEmpty(dr["NOMBRE_RAZON_SOCIAL"].ToString()))
                            nombre = "";
                        else
                            nombre = dr["NOMBRE_RAZON_SOCIAL"].ToString();
                        if (String.IsNullOrEmpty(dr["COD_PARTICIPANTE"].ToString()))
                            codigo = "";
                        else
                            codigo = dr["COD_PARTICIPANTE"].ToString();
                        miItem.Text = nombre;
                        miItem.Value = codigo;
                        //cblParticipantes.Items.Add(miItem);
                        ddlParticipantes.Items.Add(miItem);
                    }
                }

            }
        }
        private void _cargarGrilla()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_TRANSACCIONES";

            
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlParticipantes.SelectedValue });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevGrilla()._CargarDatos(dgTransaccion, vRespuesta._Tabla, "cod_transaccion");
            }
        }
        private void _CargarTipoParticipantesCombo()
        {
            //cblParticipantes.Items.Clear();
            ddlTipoParticipante.Items.Clear();
            ddlTipoParticipante.Items.Insert(0, "SELECCIONAR");
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_LISTA_PARTICIPANTES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                foreach (DataRow dr in vRespuesta._Tabla.Rows)
                {
                    ListItem miItem = new ListItem();
                    string nombre = "";
                    string codigo = "";
                    if (String.IsNullOrEmpty(dr["descripcion"].ToString()))
                        nombre = "";
                    else
                        nombre = dr["descripcion"].ToString();
                    if (String.IsNullOrEmpty(dr["codigo"].ToString()))
                        codigo = "";
                    else
                        codigo = dr["codigo"].ToString();
                    miItem.Text = nombre;
                    miItem.Value = codigo;
                    //cblParticipantes.Items.Add(miItem);
                    ddlTipoParticipante.Items.Add(miItem);
                }
            }
        }
        private void _CargarMotivoTransaccionCombo()
        {
            //cblParticipantes.Items.Clear();
            ddlMotivoTransaccion.Items.Clear();
            ddlMotivoTransaccion.Items.Insert(0, "SELECCIONAR");
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "MOTIVO TRANSACCION" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                foreach (DataRow dr in vRespuesta._Tabla.Rows)
                {
                    ListItem miItem = new ListItem();
                    miItem.Text = dr["DESCRIPCION"].ToString();
                    miItem.Value = dr["CODIGO"].ToString();
                    ddlMotivoTransaccion.Items.Add(miItem);
                }
            }
        }
        private void _CargarParticipantesNombre(string Nombre, string tipo)
        {
            ddlParticipantes.Items.Clear();
            ddlParticipantes.Items.Insert(0,"SELECCIONAR PARTICIPANTE");
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES_REALES_DINAMICOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = tipo });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
                {
                    foreach (DataRow dr in vRespuesta._Tabla.Rows)
                    {
                        ListItem miItem = new ListItem();
                        string nombre = "";
                        string codigo = "";
                        if (String.IsNullOrEmpty(dr["NOMBRE_RAZON_SOCIAL"].ToString()))
                            nombre = "";
                        else
                            nombre = dr["NOMBRE_RAZON_SOCIAL"].ToString();
                        if (String.IsNullOrEmpty(dr["COD_PARTICIPANTE"].ToString()))
                            codigo = "";
                        else
                            codigo = dr["COD_PARTICIPANTE"].ToString();
                        miItem.Text = nombre;
                        miItem.Value = codigo;
                        ddlParticipantes.Items.Add(miItem);
                    }

                }

            }
        }
        public void _limpiar()
        {
            _cargarTipoTransaccion();
            _CargarTipoParticipantesCombo();
            _CargarMotivoTransaccionCombo();
            txtBuscarParticipante.Text = "";
            txtCodigo.Text = "";
            txtMontoTransaccion.Text = "";
            txtObservaciones1.Text = "";
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            _limpiar();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
          
            if (ddlParticipantes.SelectedIndex == -1)
            { lblAvisoPArticipante.Text = "* Seleccione un participante."; }
            else
            {
                    
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_TRANSACCIONES_CUENTAS";
                List<SqlParameter> vLista = new List<SqlParameter>();

                if (txtCodigo.Text == "")
                { vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "I" }); }
                else
                { vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "U" }); }
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = txtCodigo.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlParticipantes.SelectedValue});
                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoTransaccion.SelectedValue });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_MONTO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = decimal.Parse(txtMontoTransaccion.Text) });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_MOTIVO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = ddlMotivoTransaccion.SelectedValue });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcion.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_OBSERVACION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
                respuesta = vRespuesta._Mensaje;
                    
                ShowNotifyMessage(respuesta, eTipoRespuesta.Exito);
                _cargarGrilla();
                _limpiar();
            }
            
        }

        

        protected void ddlTipoParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CargarParticipantesCombo();
            
        }

        protected void lbtnBuscaarParticipante_Click(object sender, EventArgs e)
        {
            _CargarParticipantesNombre(txtBuscarParticipante.Text, ddlTipoParticipante.SelectedValue);
        }

        protected void ddlParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cargarGrilla();
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            string _CodCuentaCorriente = e.CommandArgument.ToString();
            txtCodigo.Text = e.CommandArgument.ToString();
            MultiView1.ActiveViewIndex = 1;
            lblObs.Text = "";
            lblAvisoPArticipante.Text = "";
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            if (txtObservaciones1.Text == "")
            {
                lblObs.Text = "* Este campo no puede ir vacio.";
            }
            else
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_TRANSACCIONES_CUENTAS";
                List<SqlParameter> vLista = new List<SqlParameter>();


                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "A" });

                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = txtCodigo.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_MONTO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = 0 });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_MOTIVO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_OBSERVACION", Direction = System.Data.ParameterDirection.Input, Value = txtObservaciones1.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
                respuesta = vRespuesta._Mensaje;

                ShowNotifyMessage(respuesta, eTipoRespuesta.Exito);
                _cargarGrilla();
                _limpiar();
            }
            
        }

        protected void lbtnRechazar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            if (txtObservaciones1.Text == "")
            {
                lblObs.Text = "* Este campo no puede ir vacio.";
            }
            else
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_TRANSACCIONES_CUENTAS";
                List<SqlParameter> vLista = new List<SqlParameter>();


                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "R" });

                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = txtCodigo.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PD_MONTO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = 0 });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_MOTIVO_TRANSACCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_OBSERVACION", Direction = System.Data.ParameterDirection.Input, Value = txtObservaciones1.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
                respuesta = vRespuesta._Mensaje;

                ShowNotifyMessage(respuesta, eTipoRespuesta.Exito);
                _cargarGrilla();
                _limpiar();
            }
        }

        protected void lbtnVolver_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}