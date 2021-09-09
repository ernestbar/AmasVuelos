using DevExpress.Web;
using prySqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos.Paginas.Participante
{
    public partial class frmContactos : cBasePagina
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _LimpiarCampos();

            }
            _CargarDgContactos();
            ShowMessage();
        }

        private void _LimpiarCampos()
        {

        }

        private void _CargarDgContactos()
        {
            String txtCodParticipante = "";
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CONTACTOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = txtCodParticipante });

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                // new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
            }
        }


        private void _ActualizarContactos()
        {
            String txtContacto = "";
            String txtNombre = "";
            String txtApellidos = "";
            String txtCargo = "";
            String txtEmail = "";
            String txtTelefono = "";
            String txtCiudad = "";
            String txtCodParticipante = "";
            
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_CONTACTOS";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CONTACTO", Direction = System.Data.ParameterDirection.Input, Value = txtContacto });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE", Direction = System.Data.ParameterDirection.Input, Value = txtNombre });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_APELLIDOS", Direction = System.Data.ParameterDirection.Input, Value = txtApellidos });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CARGO", Direction = System.Data.ParameterDirection.Input, Value = txtCargo });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_EMAIL", Direction = System.Data.ParameterDirection.Input, Value = txtEmail });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TELEFONO", Direction = System.Data.ParameterDirection.Input, Value = txtTelefono });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD", Direction = System.Data.ParameterDirection.Input, Value = txtCiudad });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = txtCodParticipante });


            SqlParameter paramUsuario = new SqlParameter() { ParameterName = "PV_USUARIO", Direction = System.Data.ParameterDirection.Output, };
            SqlParameter paramError = new SqlParameter() { ParameterName = "PV_ERROR", Direction = System.Data.ParameterDirection.Output, };

            vLista.Add(paramUsuario);
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgContactos();
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
}