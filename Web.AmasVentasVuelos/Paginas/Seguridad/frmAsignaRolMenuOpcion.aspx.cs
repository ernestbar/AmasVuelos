using DevExpress.Web;
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

namespace Web.AmasVentasVuelos.Paginas.Seguridad
{
      public partial class frmAsignaRolMenuOpcion : cBasePagina
    {
        public string _OpcionRol
        {
            get
            {
                if (hfAsingaRolMenuWebOpcion.Contains("_OpcionRol"))
                {
                    return hfAsingaRolMenuWebOpcion.Get("_OpcionRol").ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfAsingaRolMenuWebOpcion.Set("_OpcionRol", value);
            }
        }

        public string _OpcionRolMenu
        {
            get
            {
                if (hfAsingaRolMenuWebOpcion.Contains("_OpcionRolMenu"))
                {
                    return hfAsingaRolMenuWebOpcion.Get("_OpcionRolMenu").ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfAsingaRolMenuWebOpcion.Set("_OpcionRolMenu", value);
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
                ASPxTabControl1.ActiveTabIndex = 0;
                ASPxTabControl1_ActiveTabChanged(null, null);
                _CargarDdlRoles();
                _CargarDdlRolesMenu();
                _OpcionRol = string.Empty;
                _OpcionRolMenu = string.Empty;
            }
            _CargarRolesDisponibles();
            _CargarRolesAsignados();
        }

        public void _CargarDdlRolesMenu()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getRolMenuCombo";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito )
            {
                new cDevComboBox()._CargarComboBox(ddlRolMenu, vRespuesta._Tabla, "id", "nombre_combo");
            }
        }

        public void _CargarDdlRoles()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getRolesTotal";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevComboBox()._CargarComboBox(ddlRoles, vRespuesta._Tabla, "rol", "nombre_rol");
            }
        }
        

        public void _CargarRolesDisponibles()
        {
            if (!String.IsNullOrEmpty( _OpcionRol))
            {
                dgDisponiblesRolMenu.Visible = true;
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "getMenuWebAAsignar_1";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = _OpcionRol });
                vEntidad._Parametros = vLista;


                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgDisponiblesRolMenu, vRespuesta._Tabla, "menu");
                }
            }
            else
            {
                dgDisponiblesRolMenu.Visible = false;
            }

           
        }
        public void _CargarRolesAsignados()
        {
            if (!String.IsNullOrEmpty(_OpcionRol))
            {
                dgAsignadosRolMenu.Visible = true;
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "getMenuWebAsignados_1";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = _OpcionRol });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgAsignadosRolMenu, vRespuesta._Tabla, "menu");
                }
            }
            else
            {
                dgAsignadosRolMenu.Visible = false;
            }
        }



        public void _CargarRolesMenuDisponibles()
        {
            if (!String.IsNullOrEmpty(_OpcionRolMenu))
            {
                dgDisponiblesRolMenuOpcion.Visible = true;
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "getMenuWebOpcionAAsignar";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol_menu_web", Direction = System.Data.ParameterDirection.Input, Value = _OpcionRolMenu.Split('_')[0] });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = _OpcionRolMenu.Split('_')[1] });
                vEntidad._Parametros = vLista;


                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgDisponiblesRolMenuOpcion, vRespuesta._Tabla, "menu_web_opcion");
                }
            }
            else
            {
                dgDisponiblesRolMenuOpcion.Visible = false;
            }


        }
        public void _CargarRolesMenuAsignados()
        {
            if (!String.IsNullOrEmpty(_OpcionRolMenu))
            {
                dgAsignadosRolMenuOpcion.Visible = true;
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "getMenuWebOpcionAsignados";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol_menu_web", Direction = System.Data.ParameterDirection.Input, Value = _OpcionRolMenu.Split('_')[0] });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = _OpcionRolMenu.Split('_')[1] });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgAsignadosRolMenuOpcion, vRespuesta._Tabla, "menu_web_opcion");
                }
            }
            else
            {
                dgAsignadosRolMenuOpcion.Visible = false;
            }
        }



        protected void ASPxTabControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            mv.ActiveViewIndex = ASPxTabControl1.ActiveTabIndex;
        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new cDevComboBox()._ValidaCombos(ddlRoles))
            {
                _OpcionRol = ddlRoles.Value.ToString();
                _CargarRolesDisponibles();
                _CargarRolesAsignados();
            }
        }

        protected void dgDisponiblesRolMenu_SelectionChanged(object sender, EventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }   

            List<object> list = dgDisponiblesRolMenu.GetSelectedFieldValues("menu");
            foreach (object item in list)
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "abm_rol_menu_web";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "I" });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = ddlRoles.Value.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = item.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario")*/ cGestorSession.GetValue("usuario") });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _CargarRolesDisponibles();
                    _CargarRolesAsignados();
                    dgDisponiblesRolMenu.Selection.UnselectAll();
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

        protected void dgAsignadosRolMenu_SelectionChanged(object sender, EventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }   

            List<object> list = dgAsignadosRolMenu.GetSelectedFieldValues("menu");
            foreach (object item in list)
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "abm_rol_menu_web";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "D" });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol", Direction = System.Data.ParameterDirection.Input, Value = ddlRoles.Value.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_menu", Direction = System.Data.ParameterDirection.Input, Value = item.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario")*/ cGestorSession.GetValue("usuario") });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _CargarRolesDisponibles();
                    _CargarRolesAsignados();
                    dgAsignadosRolMenu.Selection.UnselectAll();
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

        protected void ddlRolMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new cDevComboBox()._ValidaCombos(ddlRolMenu))
            {
                _OpcionRolMenu = ddlRolMenu.Value.ToString();
                _CargarRolesMenuDisponibles();
                _CargarRolesMenuAsignados();
            }
        }

        protected void dgDisponiblesRolMenuOpcion_SelectionChanged(object sender, EventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }

            List<object> list = dgDisponiblesRolMenuOpcion.GetSelectedFieldValues("menu_web_opcion", "cod_menu");
            foreach (object item in list)
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "abm_rol_menu_web_opcion";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "I" });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol_menu_web", Direction = System.Data.ParameterDirection.Input, Value = ddlRolMenu.Value.ToString().Split('_')[0] });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_web_opcion", Direction = System.Data.ParameterDirection.Input, Value = ((object[])item)[0] });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_cod_menu", Direction = System.Data.ParameterDirection.Input, Value = ((object[])item)[1] });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario")*/ cGestorSession.GetValue("usuario") });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;

               cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _CargarRolesMenuDisponibles();
                    _CargarRolesMenuAsignados();
                    dgDisponiblesRolMenuOpcion.Selection.UnselectAll();
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

        protected void dgAsignadosRolMenuOpcion_SelectionChanged(object sender, EventArgs e)
        {

            if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            {
                string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
                ShowMessage(mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
                return;
            }


            List<object> list = dgAsignadosRolMenuOpcion.GetSelectedFieldValues("menu_web_opcion");
            foreach (object item in list)
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "abm_rol_menu_web_opcion";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@pv_tipo_operacion", Direction = System.Data.ParameterDirection.Input, Value = "D" });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_rol_menu_web", Direction = System.Data.ParameterDirection.Input, Value = ddlRolMenu.Value.ToString().Split('_')[0] });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_menu_web_opcion", Direction = System.Data.ParameterDirection.Input, Value = item.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario_reg", Direction = System.Data.ParameterDirection.Input, Value = /*cGestorSession.GetValue("usuario")*/ cGestorSession.GetValue("usuario") });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size=300};
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;


                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    _CargarRolesMenuDisponibles();
                    _CargarRolesMenuAsignados();
                    dgAsignadosRolMenuOpcion.Selection.UnselectAll();
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
    }
}