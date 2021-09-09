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

namespace Web.AmasVentasVuelos.Paginas.Seguridad
{
    public partial class frmMenuMobileWeb : cBasePagina
    {
        public bool _EsNuevoWeb
        {
            get
            {
                if (hfMenuMobile.Contains("_EsNuevoWeb"))
                {
                    return bool.Parse(hfMenuMobile.Get("_EsNuevoWeb").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfMenuMobile.Set("_EsNuevoWeb", value);
            }
        }
        public bool _EsNuevoMobile
        {
            get
            {
                if (hfMenuMobile.Contains("_EsNuevoMobile"))
                {
                    return bool.Parse(hfMenuMobile.Get("_EsNuevoMobile").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfMenuMobile.Set("_EsNuevoMobile", value);
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
                ASPxTabControl1_ActiveTabChanged(null, null);
                _CargarDdlMenuMobilePadre();
                _EsNuevoMobile = true;

                rdlEsPadreMobile.SelectedIndex = 0;
                rdlEsPadreMobile_SelectedIndexChanged(null, null);

                rdlEsPadreWeb.SelectedIndex = 0;
                rdlEsPadreWeb_SelectedIndexChanged(null, null);

                _CargarDdlDatosMenuWeb();
            }
            _CargarDgDatosMenuMobile();
            _CargarDgDatosMenuWeb();


        }

        public void _LimpiarCamposMobile()
        {
            rdlEsPadreMobile.SelectedIndex = 0;
            rdlEsPadreMobile_SelectedIndexChanged(null, null);
            txtIdMenuMobile.Text = "";
            _CargarDdlMenuMobilePadre();
            txtNombreMenuMobile.Text = "";
            txtDescripcionMenuMobile.Text = "";
            _EsNuevoMobile = true;
        }

        public void _LimpiarCamposWeb()
        {
            rdlEsPadreWeb.SelectedIndex = 0;
            rdlEsPadreWeb_SelectedIndexChanged(null, null);
            txtIdMenuWeb.Text = "";
            _CargarDdlDatosMenuWeb();
            txtNombreMenuWeb.Text = "";
            txtDescripcionMenuWeb.Text = "";
            _EsNuevoWeb = true;
        }



        public void _CargarDgDatosMenuWeb()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuWebTotalPadresGrilla";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevGrilla()._CargarDatos(dgMenuWeb, vRespuesta._Tabla, "menu");
            }
            else
            {

            }
        }

        public void _CargarDgDatosMenuMobile()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuMobileTotal";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevGrilla()._CargarDatos(dgMenuMobile, vRespuesta._Tabla, "menu");
            }
            else
            {

            }
        }


        public void _CargarDdlDatosMenuWeb()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuWebTotalPadres";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevComboBox()._CargarComboBox(ddlMenuWeb, vRespuesta._Tabla, "menu", "nombre_menu");
            }
            else
            {

            }
        }

        public void _CargarDdlMenuMobilePadre()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuMobileTotal";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlMenuMobile, vRespuesta._Tabla, "menu", "nombre_menu");
            }
        }


        protected void ASPxTabControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            mv.ActiveViewIndex = ASPxTabControl1.ActiveTabIndex;
        }




        protected void mv_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        protected void rdlEsPadreMobile_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcionMenuMobile.Visible = (rdlEsPadreMobile.Value.ToString() == "1") ? false : true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            StringBuilder vMensaje = new StringBuilder();
            if (rdlEsPadreMobile.Value.ToString() == "0")
            {
                if (!new cDevComboBox()._ValidaCombos(ddlMenuMobile))
                {
                    vMensaje.Append("El menu padre no puede ser vacio</br>");
                }
            }

            if (string.IsNullOrEmpty(txtIdMenuMobile.Text))
            {
                vMensaje.Append("El identificador del menu no puede ser vacio </br>");
            }

            if (string.IsNullOrEmpty(txtNombreMenuMobile.Text))
            {
                vMensaje.Append("El nombre del menu no puede ser vacio </br>");
            }

            if (string.IsNullOrEmpty(txtDescripcionMenuMobile.Text))
            {
                vMensaje.Append("La descripción del menu no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_mobile";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoMobile ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = txtIdMenuMobile.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = rdlEsPadreMobile.Value.ToString() == "0" ? ddlMenuMobile.Value.ToString() : "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = txtNombreMenuMobile.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcionMenuMobile.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });


            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgDatosMenuMobile();
                _LimpiarCamposMobile();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
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

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuMobileIndividual";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._Tabla.Rows.Count > 0)
            {
                DataRow vFila = vRespuesta._Tabla.Rows[0];
                _CargarDdlMenuMobilePadre();
                if (vFila["menu_padre"].ToString().Length > 0)
                {
                    rdlEsPadreMobile.SelectedItem = rdlEsPadreMobile.Items.FindByValue("0");
                    rdlEsPadreMobile.SelectedIndex = 1;
                    rdlEsPadreMobile_SelectedIndexChanged(null, null);
                    ddlMenuMobile.SelectedItem = ddlMenuMobile.Items.FindByValue(vFila["menu_padre"].ToString());
                }
                else
                {
                    rdlEsPadreMobile.SelectedIndex = 1;
                    rdlEsPadreMobile.SelectedItem = rdlEsPadreMobile.Items.FindByValue("1");

                    rdlEsPadreMobile_SelectedIndexChanged(null, null);
                }
                txtIdMenuMobile.Text = vFila["menu"].ToString();
                txtNombreMenuMobile.Text = vFila["nombre_menu"].ToString();
                txtDescripcionMenuMobile.Text = vFila["descripcion"].ToString();
                _EsNuevoMobile = false;
            }
            else
            {
                ShowMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
                ShowNotifyMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
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

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuMobileIndividual";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._Tabla.Rows.Count > 0)
            {

                EntidadSp vEntidadEliminar = new EntidadSp();
                vEntidadEliminar._NombreSP = "abm_menu_mobile";
                List<SqlParameter> vListaEliminar = new List<SqlParameter>();

                vListaEliminar.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "D" });
                vListaEliminar.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = vRespuesta._Tabla.Rows[0]["menu"].ToString() });
                vListaEliminar.Add(new SqlParameter() { ParameterName = "@pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vListaEliminar.Add(new SqlParameter() { ParameterName = "@pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vListaEliminar.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vListaEliminar.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
                vListaEliminar.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vListaEliminar.Add(paramError);
                vEntidadEliminar._Parametros = vListaEliminar;

                cORM vOrmEliminar = new cORM("DbAmaszonas");
                cRespuesta vRespuestaEliminar = vOrmEliminar._EjecutarSp(vEntidadEliminar);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _CargarDgDatosMenuMobile();
                    _LimpiarCamposMobile();
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }
            else
            {
                ShowMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
                ShowNotifyMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
            }
        }

        protected void btnActivar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_mobile";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "A" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });


            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgDatosMenuMobile();
                _LimpiarCamposMobile();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        protected void btnActivarWeb_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_web";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "A" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });


            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgDatosMenuWeb();
                _LimpiarCamposWeb();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        protected void btnModificarWeb_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuWebIndividual";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._Tabla.Rows.Count > 0)
            {
                DataRow vFila = vRespuesta._Tabla.Rows[0];
                _CargarDdlDatosMenuWeb();
                if (vFila["menu_padre"].ToString().Length > 0)
                {
                    rdlEsPadreWeb.SelectedItem = rdlEsPadreWeb.Items.FindByValue("0");
                    rdlEsPadreWeb.SelectedIndex = 1;
                    rdlEsPadreWeb_SelectedIndexChanged(null, null);
                    ddlMenuWeb.SelectedItem = ddlMenuWeb.Items.FindByValue(vFila["menu_padre"].ToString());
                }
                else
                {
                    rdlEsPadreWeb.SelectedIndex = 1;
                    rdlEsPadreWeb.SelectedItem = rdlEsPadreWeb.Items.FindByValue("1");

                    rdlEsPadreWeb_SelectedIndexChanged(null, null);
                }
                txtIdMenuWeb.Text = vFila["menu"].ToString();
                txtNombreMenuWeb.Text = vFila["nombre_menu"].ToString();
                txtDescripcionMenuWeb.Text = vFila["descripcion"].ToString();
                _EsNuevoWeb = false;
            }
            else
            {
                ShowMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
                ShowNotifyMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
            }
        }

        protected void btnEliminarWeb_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_web";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "D" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });


            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgDatosMenuWeb();
                _LimpiarCamposWeb();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        protected void btnGuardarWeb_Click(object sender, EventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }


            StringBuilder vMensaje = new StringBuilder();
            if (rdlEsPadreWeb.Value.ToString() == "0")
            {
                if (!new cDevComboBox()._ValidaCombos(ddlMenuWeb))
                {
                    vMensaje.Append("El menu padre no puede ser vacio</br>");
                }
            }

            if (string.IsNullOrEmpty(txtIdMenuWeb.Text))
            {
                vMensaje.Append("El identificador del menu no puede ser vacio </br>");
            }

            if (string.IsNullOrEmpty(txtNombreMenuWeb.Text))
            {
                vMensaje.Append("El nombre del menu no puede ser vacio </br>");
            }

            if (string.IsNullOrEmpty(txtDescripcionMenuWeb.Text))
            {
                vMensaje.Append("La descripción del menu no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_web";
            List<SqlParameter> vLista = new List<SqlParameter>();

            DataTable registro = _DevuelveDdlMenuWeb();
            string modulo = "";
            foreach (DataRow item in registro.Rows)
            {

                if (rdlEsPadreWeb.Value.ToString() == "0")
                {
                    if (item["menu"].ToString() == ddlMenuWeb.Value.ToString())
                    {
                        modulo = item["modulo"].ToString();
                    }
                }
            }

            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoWeb ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = txtIdMenuWeb.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = rdlEsPadreWeb.Value.ToString() == "0" ? ddlMenuWeb.Value.ToString() : "" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = txtNombreMenuWeb.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcionMenuWeb.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = modulo });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario") });


            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;
             
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgDatosMenuWeb();
                _LimpiarCamposWeb();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                _EsNuevoWeb = true;
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);

            }
        }


        public DataTable _DevuelveDdlMenuWeb()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuWebTotalPadres";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                return vRespuesta._Tabla;
            }
            else
            {
                return null;
            }

        }

        protected void rdlEsPadreWeb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdlEsPadreWeb.Value != null)
            {
                opcionMenuWeb.Visible = (rdlEsPadreWeb.Value.ToString() == "1") ? false : true;
            }


        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            _LimpiarCamposWeb();
        }

        protected void btnLimpiarMoble_Click(object sender, EventArgs e)
        {
            _LimpiarCamposMobile();
        }
    }
}