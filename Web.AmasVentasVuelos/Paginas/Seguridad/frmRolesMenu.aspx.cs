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

namespace Web.AmasVentasVuelos.Paginas.Seguridad
{
    public partial class frmRolesMenu : cBasePagina
    {
        public string _IdRol
        {
            get
            {
                if (hfRolesMenu.Contains("_IdRol"))
                {
                    return (string)hfRolesMenu.Get("_IdRol");
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfRolesMenu.Set("_IdRol", value);
            }
        }
        public bool _EsNuevo
        {
            get
            {
                if (hfRolesMenu.Contains("_EsNuevo"))
                {
                    return (bool)hfRolesMenu.Get("_EsNuevo");
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfRolesMenu.Set("_EsNuevo", value);
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

            }
            _CargarDatos();
        }

        public void _CargarDatos()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getRolesTotal";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevGrilla()._CargarDatos(dgRoles, vRespuesta._Tabla, "rol");
            }


        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            StringBuilder vMensaje = new StringBuilder();

            if (string.IsNullOrEmpty(txtIdRol.Text))
            {
                vMensaje.Append("El código no puede ser vacio </br>");
            }

            if (string.IsNullOrEmpty(txtNombreRol.Text))
            {
                vMensaje.Append("El nombre rol no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_rol";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = (_EsNuevo) ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = txtIdRol.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_rol", Direction = System.Data.ParameterDirection.Input, Value = txtNombreRol.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value =  /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario")});


            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                btnLimpiar_Click(btnLimpiar, null);
                _CargarDatos();
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


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }
            _EsNuevo = true;
            txtIdRol.Text = string.Empty;
            txtNombreRol.Text = string.Empty;
        }

        protected void btnModificar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            string idRol = e.CommandArgument.ToString();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getRolIndividual";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = idRol });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {

                DataRow vFila = vRespuesta._Tabla.Rows[0];
                txtIdRol.Text = vFila["rol"].ToString();
                txtNombreRol.Text = vFila["nombre_rol"].ToString();
                _EsNuevo = false;
                _IdRol = vFila["rol"].ToString();
            }
            else
            {
                ShowMessage("No se encontro el rol", eTipoRespuesta.Advertencia);
                ShowNotifyMessage("No se encontro el rol", eTipoRespuesta.Advertencia);
            }

        }

        protected void btnActivacion_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            string idRol = e.CommandArgument.ToString();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_rol";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "A" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = idRol });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_rol", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                btnLimpiar_Click(btnLimpiar, null);
                _CargarDatos();
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

        protected void btnEliminar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            string idDominio = e.CommandArgument.ToString();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_rol";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "D" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = idDominio });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_rol", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                btnLimpiar_Click(btnLimpiar, null);
                _CargarDatos();
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