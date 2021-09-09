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

namespace Web.AmasVentasVuelos.Paginas.Seguridad
{
    public partial class frmOpcionesWebMobile : cBasePagina
    {
        public bool _EsNuevoWeb
        {
            get
            {
                if (hfOpcionesWebMobile.Contains("_EsNuevoWeb"))
                {
                    return bool.Parse(hfOpcionesWebMobile.Get("_EsNuevoWeb").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfOpcionesWebMobile.Set("_EsNuevoWeb", value);
            }
        }


        public string _OpcionMenuWeb
        {
            get
            {
                if (hfOpcionesWebMobile.Contains("_OpcionMenuWeb"))
                {
                    return hfOpcionesWebMobile.Get("_OpcionMenuWeb").ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfOpcionesWebMobile.Set("_OpcionMenuWeb", value);
            }
        }

        //public bool _EsNuevoMobile
        //{
        //    get
        //    {
        //        if (hfOpcionesWebMobile.Contains("_EsNuevoMobile"))
        //        {
        //            return bool.Parse(hfOpcionesWebMobile.Get("_EsNuevoMobile").ToString());
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    set
        //    {
        //        hfOpcionesWebMobile.Set("_EsNuevoMobile", value);
        //    }
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (cGestorSession.GetValue("usuario") == null)
            {
                Response.Redirect("~/frmLogin.aspx", true);
            }

            if (!Page.IsPostBack)
            {
                ASPxTabControl1.ActiveTabIndex = 1;
                ASPxTabControl1_ActiveTabChanged(null, null);
                //_CargarDdlMenuMobilePadre();
                //_EsNuevoMobile = true;
                _OpcionMenuWeb = string.Empty;
                _CargarDdlDatosMenuWeb();
            }
            //_CargarDgDatosMenuMobile();
            _CargarDgDatosMenuWeb();


        }

        //public void _LimpiarCamposMobile()
        //{

        //    txtIdMenuMobile.Text = "";
        //    _CargarDdlMenuMobilePadre();
        //    txtNombreMenuMobile.Text = "";
        //    txtDescripcionMenuMobile.Text = "";
        //}

        public void _LimpiarCamposWeb()
        {
            txtIdOpcionWeb.Enabled = true;
            txtIdOpcionWeb.Text = String.Empty;
            txtNombreOpcionWeb.Text = String.Empty;
            txtDescripcionOpcionWeb.Text = String.Empty;
            _EsNuevoWeb = true;
        }



        public void _CargarDgDatosMenuWeb()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getOpcionWebTotal";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = _OpcionMenuWeb });
            vEntidad._Parametros = vLista;


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

        //public void _CargarDgDatosMenuMobile()
        //{

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "getMenuMobileTotal";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        new cDevGrilla()._CargarDatos(dgMenuMobile, vRespuesta._Tabla, "menu");
        //    }
        //    else
        //    {

        //    }
        //}


        public void _CargarDdlDatosMenuWeb()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenuWebTotalCombo";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevComboBox()._CargarComboBox(ddlOpcionWeb, vRespuesta._Tabla, "menu", "nombre_menu");
                if (new cDevComboBox()._ValidaCombos(ddlOpcionWeb))
                {
                    _OpcionMenuWeb = ddlOpcionWeb.Value.ToString();
                    _CargarDgDatosMenuWeb();
                }
            }
            else
            {

            }
        }

        //public void _CargarDdlMenuMobilePadre()
        //{
        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "getMenuMobileTotal";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
        //    {
        //        new cDevComboBox()._CargarComboBox(ddlMenuMobile, vRespuesta._Tabla, "menu", "nombre_menu");
        //    }
        //}


        protected void ASPxTabControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            mv.ActiveViewIndex = ASPxTabControl1.ActiveTabIndex;
        }




        protected void mv_ActiveViewChanged(object sender, EventArgs e)
        {

        }


        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "abm_menu_mobile";
        //    List<SqlParameter> vLista = new List<SqlParameter>();

        //    vLista.Add(new SqlParameter() { ParameterName = "pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoMobile ? "I" : "U" });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_menu", Direction = System.Data.ParameterDirection.Input, Value = txtIdMenuMobile.Text });

        //    vLista.Add(new SqlParameter() { ParameterName = "pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = txtNombreMenuMobile.Text });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcionMenuMobile.Text });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*/*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario")*/ cGestorSession.GetValue("usuario") });


        //    SqlParameter paramEstado = new SqlParameter() { ParameterName = "pv_estado", Direction = System.Data.ParameterDirection.Output, };
        //    SqlParameter paramMenasje = new SqlParameter() { ParameterName = "pv_errordesc", Direction = System.Data.ParameterDirection.Output, };

        //    vLista.Add(paramEstado);
        //    vLista.Add(paramMenasje);

        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

        //    if (paramEstado.Value.ToString() == ((int)eTipoRespuesta.Exito).ToString())
        //    {
        //        _CargarDgDatosMenuMobile();
        //        _LimpiarCamposMobile();
        //        ShowMessage(paramMenasje.Value.ToString(), eTipoRespuesta.Exito);
        //        ShowNotifyMessage(paramMenasje.Value.ToString(), eTipoRespuesta.Exito);
        //    }
        //    else
        //    {
        //        ShowMessage(paramMenasje.Value.ToString(), eTipoRespuesta.Advertencia);
        //        ShowNotifyMessage(paramMenasje.Value.ToString(), eTipoRespuesta.Advertencia);
        //    }
        //}

        //protected void btnModificar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        //{
        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "getMenuMobileIndividual";
        //    List<SqlParameter> vLista = new List<SqlParameter>();


        //    vLista.Add(new SqlParameter() { ParameterName = "pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });

        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._Tabla.Rows.Count > 0)
        //    {
        //        DataRow vFila = vRespuesta._Tabla.Rows[0];
        //        _CargarDdlMenuMobilePadre();
        //        if (vFila["menu_padre"].ToString().Length > 0)
        //        {

        //            ddlMenuMobile.SelectedItem = ddlMenuMobile.Items.FindByValue(vFila["menu_padre"].ToString());
        //        }
        //        else
        //        {

        //        }
        //        txtIdMenuMobile.Text = vFila["menu"].ToString();
        //        txtNombreMenuMobile.Text = vFila["nombre_menu"].ToString();
        //        txtDescripcionMenuMobile.Text = vFila["descripcion"].ToString();
        //        _EsNuevoMobile = false;
        //    }
        //    else
        //    {
        //        ShowMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
        //        ShowNotifyMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
        //    }
        //}

        //protected void btnEliminar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        //{

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "getMenuMobileIndividual";
        //    List<SqlParameter> vLista = new List<SqlParameter>();


        //    vLista.Add(new SqlParameter() { ParameterName = "pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });

        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._Tabla.Rows.Count > 0)
        //    {

        //        EntidadSp vEntidadEliminar = new EntidadSp();
        //        vEntidadEliminar._NombreSP = "abm_menu_mobile";
        //        List<SqlParameter> vListaEliminar = new List<SqlParameter>();

        //        vListaEliminar.Add(new SqlParameter() { ParameterName = "pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "D" });
        //        vListaEliminar.Add(new SqlParameter() { ParameterName = "pv_menu", Direction = System.Data.ParameterDirection.Input, Value = vRespuesta._Tabla.Rows[0]["menu"].ToString() });
        //        vListaEliminar.Add(new SqlParameter() { ParameterName = "pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = "" });
        //        vListaEliminar.Add(new SqlParameter() { ParameterName = "pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = "" });
        //        vListaEliminar.Add(new SqlParameter() { ParameterName = "pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = "" });
        //        vListaEliminar.Add(new SqlParameter() { ParameterName = "pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
        //        vListaEliminar.Add(new SqlParameter() { ParameterName = "pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*/*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario")*/ cGestorSession.GetValue("usuario") });


        //        SqlParameter paramEstadoEliminar = new SqlParameter() { ParameterName = "pv_estado", Direction = System.Data.ParameterDirection.Output, };
        //        SqlParameter paramMenasjeEliminar = new SqlParameter() { ParameterName = "pv_errordesc", Direction = System.Data.ParameterDirection.Output, };

        //        vListaEliminar.Add(paramEstadoEliminar);
        //        vListaEliminar.Add(paramMenasjeEliminar);

        //        vEntidadEliminar._Parametros = vListaEliminar;

        //        cORM vOrmEliminar = new cORM("DbAmaszonas");
        //        cRespuesta vRespuestaEliminar = vOrmEliminar._EjecutarSp(vEntidadEliminar);

        //        if (paramEstadoEliminar.Value.ToString() == ((int)eTipoRespuesta.Exito).ToString())
        //        {
        //            _CargarDgDatosMenuMobile();
        //            _LimpiarCamposMobile();
        //            ShowMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Exito);
        //            ShowNotifyMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Exito);
        //        }
        //        else
        //        {
        //            ShowMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Advertencia);
        //            ShowNotifyMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Advertencia);
        //        }
        //    }
        //    else
        //    {
        //        ShowMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
        //        ShowNotifyMessage("No se encontro el registro ", eTipoRespuesta.Advertencia);
        //    }
        //}

        //protected void btnActivar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        //{
        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "abm_menu_mobile";
        //    List<SqlParameter> vLista = new List<SqlParameter>();

        //    vLista.Add(new SqlParameter() { ParameterName = "pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "A" });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_menu", Direction = System.Data.ParameterDirection.Input, Value = e.CommandArgument.ToString() });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_menu_padre", Direction = System.Data.ParameterDirection.Input, Value = "" });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_nombre_menu", Direction = System.Data.ParameterDirection.Input, Value = "" });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = "" });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_modulo", Direction = System.Data.ParameterDirection.Input, Value = "AMV" });
        //    vLista.Add(new SqlParameter() { ParameterName = "pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*/*cGestorSession.GetValue("usuario").ToString()*/ cGestorSession.GetValue("usuario")*/ cGestorSession.GetValue("usuario") });


        //    SqlParameter paramEstadoEliminar = new SqlParameter() { ParameterName = "pv_estado", Direction = System.Data.ParameterDirection.Output, };
        //    SqlParameter paramMenasjeEliminar = new SqlParameter() { ParameterName = "pv_errordesc", Direction = System.Data.ParameterDirection.Output, };

        //    vLista.Add(paramEstadoEliminar);
        //    vLista.Add(paramMenasjeEliminar);

        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

        //    if (paramEstadoEliminar.Value.ToString() == ((int)eTipoRespuesta.Exito).ToString())
        //    {
        //        _CargarDgDatosMenuMobile();
        //        _LimpiarCamposMobile();
        //        ShowMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Exito);
        //        ShowNotifyMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Exito);
        //    }
        //    else
        //    {
        //        ShowMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Advertencia);
        //        ShowNotifyMessage(paramMenasjeEliminar.Value.ToString(), eTipoRespuesta.Advertencia);
        //    }
        //}

        protected void btnActivarWeb_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            string id = e.CommandArgument.ToString();

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_web_opcion";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "A" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_web_opcion", Direction = System.Data.ParameterDirection.Input, Value = id });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_opcion", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
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

            string id = e.CommandArgument.ToString();
            txtIdOpcionWeb.Enabled = false;

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getOpcionWebTotal";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = _OpcionMenuWeb });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                foreach (DataRow vFila in vRespuesta._Tabla.Rows)
                {
                    if (vFila["menu_web_opcion"].ToString() == id)
                    {
                        txtIdOpcionWeb.Text = vFila["menu_web_opcion"].ToString();
                        txtNombreOpcionWeb.Text = vFila["nombre_opcion"].ToString();
                        txtDescripcionOpcionWeb.Text = vFila["descripcion"].ToString();
                        _EsNuevoWeb = false;

                    }
                }
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

            string id = e.CommandArgument.ToString();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_web_opcion";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "D" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_web_opcion", Direction = System.Data.ParameterDirection.Input, Value = id });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_opcion", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
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

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "abm_menu_web_opcion";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoWeb ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_web_opcion", Direction = System.Data.ParameterDirection.Input, Value = txtIdOpcionWeb.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = ddlOpcionWeb.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_nombre_opcion", Direction = System.Data.ParameterDirection.Input, Value = txtNombreOpcionWeb.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@pv_descripcion", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcionOpcionWeb.Text });
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



        protected void ddlMenuWeb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargamos el dato de la grilla pero con el valor del menu
            if (new cDevComboBox()._ValidaCombos(ddlOpcionWeb))
            {
                _OpcionMenuWeb = ddlOpcionWeb.Value.ToString();
                _CargarDgDatosMenuWeb();
            }
            else
            {
                _OpcionMenuWeb = string.Empty;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            _LimpiarCamposWeb();
        }
    }
}