using prySqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.AmasVentasVuelos.Helper;
namespace Web.AmasVentasVuelos.Paginas.Participante
{
    public partial class frmSucursales :  cBasePagina
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
                Session["lat"] = "-17.3804204";
                Session["lon"] = "-66.1730049";

                _CargarDdlPais();
                _CargarDdlCiudad();

            }

            this._CargarDgSucursales();
        }


        private void _CargarDdlPais()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "PAIS" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlPais, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarDdlCiudad()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CIUDADES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PAIS", Direction = System.Data.ParameterDirection.Input, Value = ddlPais.Value.ToString() });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlCiudad, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarDgSucursales()
        {
            String txtCodParticipante = "";

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_SUCURSALES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = txtCodParticipante });

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                // new cDevGrilla()._CargarDatos(dgSucursales, vRespuesta._Tabla, "codigo");
            }
        }


        private void _ActualizarSucursal()
        {
            String txtCodSucursal = "";
            String txtDescripcion = this.txtDireccion.Text;
            String txtDireccion = this.txtDireccion.Text;
            String txtCodParticipante = "";

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_CONTACTOS";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_SUCURSAL", Direction = System.Data.ParameterDirection.Input, Value = txtCodSucursal });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcion });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DIRECCION", Direction = System.Data.ParameterDirection.Input, Value = txtDireccion });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PAIS", Direction = System.Data.ParameterDirection.Input, Value = this.ddlPais.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD", Direction = System.Data.ParameterDirection.Input, Value = this.ddlCiudad.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_LONGITUD", Direction = System.Data.ParameterDirection.Input, Value = this.txtLongitud });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_LATITUD", Direction = System.Data.ParameterDirection.Input, Value = this.txtLatitud });
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
                _CargarDgSucursales();
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

        private void _LimpiarCampos()
        {
           // this.ddlPais.Value = "1";
           // this.ddlCiudad.Value = "1";
        }

        protected void btnRegistrarSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                _ActualizarSucursal();
                _LimpiarCampos();
                _CargarDgSucursales();
            }
            catch (Exception exception)
            {
                ShowNotifyMessage(exception.ToString(), eTipoRespuesta.Error);
            }
        }
    }
   
}