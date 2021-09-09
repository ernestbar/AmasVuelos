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
    public partial class frmParticipante : cBasePagina
    {
        public bool _EsNuevoSucursal
        {
            get
            {
                if (hfOpciones.Contains("_EsNuevoSucursal"))
                {
                    return bool.Parse(hfOpciones.Get("_EsNuevoSucursal").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfOpciones.Set("_EsNuevoSucursal", value);
            }
        }
        public bool _EsNuevoPersonal
        {
            get
            {
                if (hfOpciones.Contains("_EsNuevoPersonal"))
                {
                    return bool.Parse(hfOpciones.Get("_EsNuevoPersonal").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfOpciones.Set("_EsNuevoPersonal", value);
            }
        }

        public bool _EsNuevoParticipante
        {
            get
            {
                if (hfOpciones.Contains("_EsNuevoParticipante"))
                {
                    return bool.Parse(hfOpciones.Get("_EsNuevoParticipante").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfOpciones.Set("_EsNuevoParticipante", value);
            }
        }

        public bool _EsNuevoContacto
        {
            get
            {
                if (hfOpciones.Contains("_EsNuevoContacto"))
                {
                    return bool.Parse(hfOpciones.Get("_EsNuevoContacto").ToString());
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfOpciones.Set("_EsNuevoContacto", value);
            }
        }


        public string _CodSucursal
        {
            get
            {
                if (hfOpciones.Contains("_CodSucursal"))
                {
                    return (hfOpciones.Get("_CodSucursal").ToString());
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfOpciones.Set("_CodSucursal", value);
            }
        }

        public bool _EsPersonaJuridica
        {
            get
            {
                if (hfOpciones.Contains("_EsPersonaJuridica"))
                {
                    return bool.Parse(hfOpciones.Get("_EsPersonaJuridica").ToString());
                }
                else
                {
                    return false;
                }
            }
            set
            {
                hfOpciones.Set("_EsPersonaJuridica", value);
            }
        }

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

        public string _CodPersonal
        {
            get
            {
                if (hfOpciones.Contains("_CodPersonal"))
                {
                    return (hfOpciones.Get("_CodPersonal").ToString());
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfOpciones.Set("_CodPersonal", value);
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
                Session["lat"] = "-17.3804204";
                Session["lon"] = "-66.1730049";
                //txtLongitudSucursales.EnableClientSideAPI = false;
                //txtLatitudSucursales.EnableClientSideAPI = false;
                _CargarParticipante();
                _CargarSociedad();
                _CargarVivienda();
                //_CargarExpedidoPersonal();
                _CargarSituacionLaboral();
                _CargarTipoDocumento();
                _CargarBancos();
                _CargarRubro();
                _CargarNacionalidadPais();
                _CargarSucursales();

                _CargarTipoDocumentos();
                tbMenu.ActiveTabIndex = 0;
                mvVista.ActiveViewIndex = 0;
                ddlTipoParticipanta.SelectedIndex = 0;
                _CargarCiudadContacto();
                txtLongitudSucursales.Text = "";
                txtLatitudSucursales.Text = "";
               // _campoBanco.Visible = true;
                //_textoBanco.Visible = false;
                ddlTipoParticipanta_SelectedIndexChanged1(null, null);

                txtSucursalSucursales.Enabled = false;
                txtCodContacto.Enabled = false;
            }
            _CargarDgContactos();
            _CargarDgSucursales();
            _CargarDgPersonal();
            _CargarDgParticipante();
            //_CargarDgReferenciaPersonal();
            configurarTabs();

            /*
            if (Session["retorno"] != null)
            {
            if (Session["retorno"].ToString() == "0") //retorna desde una empresa juridica
                {
                    _CodParticipante = Session["codParticipante"].ToString();
                    tbMenu.ActiveTabIndex = 3;
                    mvVista.ActiveViewIndex = 3;
                    configurarTabs();
                    _LimpiarContactos();                    
                    _LimpiarPersonal();
                    _LimpiarSucursales();
                    _CargarDgContactos();
                    _CargarDgPersonal();
                    _CargarDgSucursales();
                    if (mvVista.ActiveViewIndex == 3)
                    {
                        _CargarSucursales();
                    }
                    //tbMenu_ActiveTabChanged(null, new DevExpress.Web.TabControlEventArgs( new DevExpress.Web.TabBase().Index=));
                    _CodPersonal = Session["codPersonal"].ToString();
                    btnModificarPersonal_Command(null, new CommandEventArgs("btnModificarPersonal_Command", _CodPersonal));
                    Session["retorno"] = string.Empty;
                }

                if (Session["retorno"].ToString() == "1") //retorna desde una persona natural
                {
                    _CodParticipante = Session["codParticipante"].ToString();
                    tbMenu.ActiveTabIndex = 0;
                    tbMenu_ActiveTabChanged(null, null);
                    Session["retorno"] = string.Empty;
                }
            }
            */


        }

        private void configurarTabs()
        {
            bool tieneCodParticipante = (!string.IsNullOrEmpty(_CodParticipante));
            tbMenu.Tabs[1].Visible = tieneCodParticipante;
            tbMenu.Tabs[2].Visible = tieneCodParticipante;
            tbMenu.Tabs[3].Visible = tieneCodParticipante;

            if (tieneCodParticipante)
            {
                if (_EsPersonaJuridica)
                {
                    tbMenu.Tabs[1].Visible = true;
                }
                else
                {
                    tbMenu.Tabs[1].Visible = false;
                }
            }
        }

        private void _CargarNacionalidadPais()
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
                new cDevComboBox()._CargarComboBox(ddlNacionalidadPersonal, vRespuesta._Tabla, "codigo", "descripcion");
                new cDevComboBox()._CargarComboBox(ddlNacionalidadParticipante, vRespuesta._Tabla, "codigo", "descripcion");
                new cDevComboBox()._CargarComboBox(ddlPaisSucursales, vRespuesta._Tabla, "codigo", "descripcion");

            }
        }

        private void _CargarBancos()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "BANCOS" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                //new cDevComboBox()._CargarComboBox(ddlBancoParticipante, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarTipoDocumento()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "TIPO DOCUMENTO" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                rdltipoDocumentoPersonal.DataSource = vRespuesta._Tabla;
                rdltipoDocumentoPersonal.TextField = "descripcion";
                rdltipoDocumentoPersonal.ValueField = "codigo";
                rdltipoDocumentoPersonal.DataBind();
                //new cDevComboBox()._CargarComboBox(ddlTipoDocumento, vRespuesta._Tabla, "codigo", "descripcion");

            }
        }
        private void _CargarSituacionLaboral()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "SITUACION LABORAL" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                // new cDevComboBox()._CargarComboBox(ddlSituacionLaboral, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarRubro()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "RUBRO" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                // new cDevComboBox()._CargarComboBox(ddlRubro, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }
        ////private void _CargarExpedidoPersonal()
        ////{
        ////    EntidadSp vEntidad = new EntidadSp();
        ////    vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

        ////    List<SqlParameter> vLista = new List<SqlParameter>();
        ////    vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "EXPEDIDO" });
        ////    vEntidad._Parametros = vLista;

        ////    cORM vOrm = new cORM("DbAmaszonas");
        ////    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
        ////    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
        ////    {
        ////        new cDevComboBox()._CargarComboBox(ddlExpedidoUsuario, vRespuesta._Tabla, "codigo", "descripcion");
        ////    }
        ////}

        private void _CargarVivienda()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "TIPO VIVIENDA" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                //  new cDevComboBox()._CargarComboBox(ddlTipoVivienda, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarParticipante()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS_PARTICIPANTE";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlTipoParticipanta, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }



        private void _CargarSociedad()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "CLASE SOCIEDAD" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                //   new cDevComboBox()._CargarComboBox(ddlSociedad, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarCiudadesDePais(string pIdPais)
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CIUDADES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PAIS", Direction = System.Data.ParameterDirection.Input, Value = pIdPais });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlCiudadPersonal, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarCiudadesDePaisSucursal(string pIdPais)
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CIUDADES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PAIS", Direction = System.Data.ParameterDirection.Input, Value = pIdPais });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlCiudadSucursales, vRespuesta._Tabla, "codigo", "descripcion");
                ddlCiudadSucursales.SelectedIndex = 0;
                ddlCiudadSucursales_SelectedIndexChanged(null, null);
            }
        }

        private void _CargarCiudadesDePaisParticipante(string pIdPais)
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CIUDADES";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PAIS", Direction = System.Data.ParameterDirection.Input, Value = pIdPais });
            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlCiudadParticipante, vRespuesta._Tabla, "codigo", "descripcion");

            }
        }

        private void _CargarSucursales()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_SUCURSALES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                //new cDevComboBox()._CargarComboBox(ddlCiudadPersonal, vRespuesta._Tabla, "codigo", "descripcion");
                new cDevComboBox()._CargarComboBox(ddlSucursalPersonal, vRespuesta._Tabla, "COD_SUCURSAL", "DESCRIPCION");
            }
        }
        private void _CargarTipoDocumentos()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "TIPO DOCUMENTO" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlTipoDocumentoParticipante, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }
        private void _CargarCiudadContacto()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "CIUDAD" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlCiudadContacto, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }




        //private void _CargarDgReferenciaPersonal()
        //{
        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_SPERSONAL";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
        //    {
        //        new cDevGrilla()._CargarDatos(dgReferenciaPersonal, vRespuesta._Tabla, "COD_PARTICIPANTE");
        //    }
        //}

        private void _CargarDgContactos()
        {
            if (!String.IsNullOrEmpty(_CodParticipante))
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_CONTACTOS";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito|| vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgContacto, vRespuesta._Tabla, "COD_CONTACTO");
                }
            }
        }

        private void _CargarDgSucursales()
        {
            if (!String.IsNullOrEmpty(_CodParticipante))
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_SUCURSALES";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    new cDevGrilla()._CargarDatos(dgSucursales, vRespuesta._Tabla, "COD_SUCURSAL");
                }
            }
        }

        private void _CargarDgPersonal()
        {
            if (!String.IsNullOrEmpty(_CodParticipante))
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_SPERSONAL";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    new cDevGrilla()._CargarDatos(dgPersonal, vRespuesta._Tabla, "COD_PARTICIPANTE");
                }
            }
        }


        private void _CargarDgParticipante()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevGrilla()._CargarDatos(dgParticipante, vRespuesta._Tabla, "COD_PARTICIPANTE");
            }

        }



        protected void btnCompletarRegistro_Click(object sender, EventArgs e)
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_PERSONAL";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PERSONAL", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_APELLIDOS", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NUMERO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NACIONALIDAD", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CARGO", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD_RESIDENCIA", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DIRECCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TELEFONO", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_EMAIL", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_SUCURSAL", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "" });


            SqlParameter PV_ERROR = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(PV_ERROR);
            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {

            }
        }

        protected void tbMenu_ActiveTabChanged(object source, DevExpress.Web.TabControlEventArgs e)
        {
            mvVista.ActiveViewIndex = e.Tab.Index;

            _LimpiarContactos();
            //_LimpiarParticipante();
            _LimpiarPersonal();
            _LimpiarSucursales();
            _CargarDgContactos();
            _CargarDgPersonal();
            _CargarDgSucursales();


            if (mvVista.ActiveViewIndex == 3)
            {
                _CargarSucursales();
            }





        }

        protected void ddlNacionalidadPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new cDevComboBox()._ValidaCombos(ddlNacionalidadPersonal))
            {
                _CargarCiudadesDePais(ddlNacionalidadPersonal.Value.ToString());
            }

        }

        protected void btnGuardarContactos_Click(object sender, EventArgs e)
        {
            StringBuilder vMensaje = new StringBuilder();
            if (string.IsNullOrEmpty(txtNombreContactos.Text))
            {
                vMensaje.Append("El nombre no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(txtApellidoContactos.Text))
            {
                vMensaje.Append("La apellido no puede ser vacio </br>");
            }
            if (!new cDevComboBox()._ValidaCombos(ddlCiudadContacto))
            {
                vMensaje.Append("La ciudad no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(txtCargoContacto.Text))
            {
                vMensaje.Append("La cargo no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(txtTelefonoContactos.Text))
            {
                vMensaje.Append("El teléfono no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(txtEmailContactos.Text))
            {
                vMensaje.Append("La email no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }





            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_CONTACTOS";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoContacto ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CONTACTO", Direction = System.Data.ParameterDirection.Input, Value = txtCodContacto.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE", Direction = System.Data.ParameterDirection.Input, Value = txtNombreContactos.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_APELLIDOS", Direction = System.Data.ParameterDirection.Input, Value = txtApellidoContactos.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CARGO", Direction = System.Data.ParameterDirection.Input, Value = txtCargoContacto.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_EMAIL", Direction = System.Data.ParameterDirection.Input, Value = txtEmailContactos.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TELEFONO", Direction = System.Data.ParameterDirection.Input, Value = txtTelefonoContactos.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD", Direction = System.Data.ParameterDirection.Input, Value = ddlCiudadContacto.SelectedItem.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                if (_EsNuevoContacto)
                {
                    _LimpiarContactos();
                    _EsNuevoContacto = true;
                }

                _CargarDgContactos();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        private void _LimpiarContactos()
        {
            txtCodContacto.Text = String.Empty;
            txtNombreContactos.Text = String.Empty;
            txtApellidoContactos.Text = String.Empty;
            txtCargoContacto.Text = String.Empty;
            txtEmailContactos.Text = String.Empty;
            txtTelefonoContactos.Text = String.Empty;
            ddlCiudadContacto.SelectedIndex = -1;
        }

        protected void btnEliminarContactos_Command(object sender, CommandEventArgs e)
        {
            string idContacto = e.CommandArgument.ToString();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_CONTACTOS";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "D" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_CONTACTO", Direction = System.Data.ParameterDirection.Input, Value = idContacto });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_APELLIDOS", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CARGO", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_EMAIL", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TELEFONO", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgContactos();
                _LimpiarContactos();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        protected void btnModificarContactos_Command(object sender, CommandEventArgs e)
        {
            string idContacto = e.CommandArgument.ToString();

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_CONTACTOS";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });


            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {

                _EsNuevoContacto = false;
                DataRow vFila = vRespuesta._Tabla.Rows[0];
                txtCodContacto.Enabled = false;
                txtCodContacto.Text = vFila["COD_CONTACTO"].ToString();
                txtNombreContactos.Text = vFila["NOMBRE"].ToString();
                txtApellidoContactos.Text = vFila["APELLIDOS"].ToString();
                txtCargoContacto.Text = vFila["CARGO"].ToString();
                txtEmailContactos.Text = vFila["EMAIL"].ToString();
                txtTelefonoContactos.Text = vFila["TELEFONO"].ToString();
                _CargarNacionalidadPais();
                ddlCiudadContacto.SelectedItem = ddlCiudadContacto.Items.FindByValue(vFila["CIUDAD"].ToString());
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        protected void ddlPaisSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CargarCiudadesDePaisSucursal(ddlPaisSucursales.Value.ToString());
        }

        protected void btnGuardarSucursales_Click(object sender, EventArgs e)
        {
            StringBuilder vMensaje = new StringBuilder();

            if (string.IsNullOrEmpty(txtDescripcionSucursalSucursales.Text))
            {
                vMensaje.Append("La descripción de la sucursal no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(txtDireccionSucursales.Text))
            {
                vMensaje.Append("La dirección no puede ser vacio </br>");
            }
            if (!new cDevComboBox()._ValidaCombos(ddlPaisSucursales))
            {
                vMensaje.Append("El país de la sucursal no puede ser vacio </br>");
            }
            if (!new cDevComboBox()._ValidaCombos(ddlCiudadSucursales))
            {
                vMensaje.Append("El ciudad no puede ser vacio </br>");
            }



            /*
            if (dtFechaDesde.Date == null)
            {
                vMensaje.Append("La fecha de inicio no puede ser vacia</br>");
            }

            if (rdlEstado.SelectedIndex <= -1)
            {
                vMensaje.Append("El estado no puede ser vacio</br>");
            }
            */

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_SUCURSALES";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoSucursal ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_SUCURSAL", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoSucursal ? "" : _CodSucursal });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcionSucursalSucursales.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DIRECCION", Direction = System.Data.ParameterDirection.Input, Value = txtDireccionSucursales.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PAIS", Direction = System.Data.ParameterDirection.Input, Value = ddlPaisSucursales.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD", Direction = System.Data.ParameterDirection.Input, Value = ddlCiudadSucursales.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_LONGITUD", Direction = System.Data.ParameterDirection.Input, Value = txtLongitudSucursales.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_LATITUD", Direction = System.Data.ParameterDirection.Input, Value = txtLatitudSucursales.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgSucursales();
                _CargarSucursales();
                _LimpiarSucursales();
                txtCodContacto.Enabled = true;
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        private void _LimpiarSucursales()
        {
            txtSucursalSucursales.Text = string.Empty;
            txtDescripcionSucursalSucursales.Text = string.Empty;
            txtDireccionSucursales.Text = string.Empty;
            ddlPaisSucursales.SelectedIndex = -1;
            ddlCiudadSucursales.SelectedIndex = -1;
            txtLongitudSucursales.Text = string.Empty;

            txtLatitudSucursales.Text = string.Empty;


        }

        protected void ddlCiudadSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new cDevComboBox()._ValidaCombos(ddlCiudadSucursales))
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_CIUDADES_COORDENADAS";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD", Direction = System.Data.ParameterDirection.Input, Value = ddlCiudadSucursales.Value.ToString() });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    DataRow vFila = vRespuesta._Tabla.Rows[0];
                    Session["lat"] = vFila["valor_caracter_extra"].ToString().Split('|')[0].ToString();
                    Session["lon"] = vFila["valor_caracter_extra"].ToString().Split('|')[1].ToString();
                }
            }

        }

        protected void ddlNacionalidadParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CargarCiudadesDePaisParticipante(ddlNacionalidadParticipante.Value.ToString());
        }

        protected void btnAdicionarBanco_Command(object sender, CommandEventArgs e)
        {
            //_campoBanco.Visible = false;
            //_textoBanco.Visible = true;
        }

        protected void btnGuardarNuevoBanco_Command(object sender, CommandEventArgs e)
        {
           // _campoBanco.Visible = true;
            //_textoBanco.Visible = false;
        }

        protected void btnGuardarParticipante_Click(object sender, EventArgs e)
        {
            StringBuilder vMensaje = new StringBuilder();

            if (!new cDevComboBox()._ValidaCombos(ddlTipoParticipanta))
            {
                vMensaje.Append("El tipo de participante no puede ser vacio </br>");
            }
            if (_EsPersonaJuridica)
            {
                if (string.IsNullOrEmpty(txtRazonSocialParticipante.Text))
                {
                    vMensaje.Append("La razon social no puede ser vacio </br>");
                }
                if (string.IsNullOrEmpty(txtNitParticipante.Text))
                {
                    vMensaje.Append("El nit del participante no puede ser vacio </br>");
                }
                if (string.IsNullOrEmpty(txtPaginaWebParticipante.Text))
                {
                    vMensaje.Append("La pagina web no puede ser vacio </br>");
                }
                if (string.IsNullOrEmpty(txtTelefonoParticipante.Text))
                {
                    vMensaje.Append("El teléfono cuenta no puede ser vacio </br>");
                }
            }
            else
            {

                if (string.IsNullOrEmpty(txtNombreParticipante.Text))
                {
                    vMensaje.Append("el nombre del participante no puede ser vacio </br>");
                }
                if (string.IsNullOrEmpty(txtApellidoParticipante.Text))
                {
                    vMensaje.Append("El apellido  cuenta no puede ser vacio </br>");
                }
                if (!new cDevComboBox()._ValidaCombos(ddlTipoDocumentoParticipante))
                {
                    vMensaje.Append("El tipo de documento no puede ser vacio </br>");
                }
                if (string.IsNullOrEmpty(txtNroDocumentoParticipante.Text))
                {
                    vMensaje.Append("El nro de documento no puede ser vacio </br>");
                }
                //if (string.IsNullOrEmpty(txtCargoParticipante.Text))
                //{
                //    vMensaje.Append("El cargo no puede ser vacio </br>");
                //}
                if (string.IsNullOrEmpty(txtTelefonoCelular.Text))
                {
                    vMensaje.Append("El teléfono no puede ser vacio </br>");
                }
                if (string.IsNullOrEmpty(txtCorreoParticipante.Text))
                {
                    vMensaje.Append("El correo no puede ser vacio </br>");
                }
            }
            if (!new cDevComboBox()._ValidaCombos(ddlNacionalidadParticipante))
            {
                vMensaje.Append("La nacionalidad no puede ser vacio </br>");
            }
            if (!new cDevComboBox()._ValidaCombos(ddlCiudadParticipante))
            {
                vMensaje.Append("La ciudad no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(txtDireccionParticipante.Text))
            {
                vMensaje.Append("La dirección no puede ser vacio </br>");
            }
            //if (!new cDevComboBox()._ValidaCombos(ddlBancoParticipante))
            //{
            //    vMensaje.Append("El banco no puede ser vacio </br>");
            //}
            //if (string.IsNullOrEmpty(txtCuentaParticipante.Text))
            //{
            //    vMensaje.Append("La cuenta no puede ser vacio </br>");
            //}
            if (string.IsNullOrEmpty(txtCodigoComisionParticipante.Text))
            {
                vMensaje.Append("El código de la comisión no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_PARTICIPANTE";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoParticipante ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoParticipante ? "" : _CodParticipante });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoParticipanta.Value.ToString().Split('|')[0].ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_RAZON_SOCIAL", Direction = System.Data.ParameterDirection.Input, Value = txtRazonSocialParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? "" : txtNombreParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_APELLIDOS", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? "" : txtApellidoParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? "NIT" : ddlTipoDocumentoParticipante.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NUMERO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? txtNitParticipante.Text : txtNroDocumentoParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NACIONALIDAD", Direction = System.Data.ParameterDirection.Input, Value = ddlNacionalidadParticipante.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CARGO", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? "" : txtCargoParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD_RESIDENCIA", Direction = System.Data.ParameterDirection.Input, Value = ddlCiudadParticipante.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DIRECCION", Direction = System.Data.ParameterDirection.Input, Value = txtDireccionParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PAGINA_WEB", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? txtPaginaWebParticipante.Text :""   });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TELEFONO", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? txtTelefonoParticipante.Text : txtTelefonoCelular.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_EMAIL", Direction = System.Data.ParameterDirection.Input, Value = _EsPersonaJuridica ? "" : txtCorreoParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_BANCO", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CUENTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_EMISION", Direction = System.Data.ParameterDirection.Input, Value = txtCodigoComisionParticipante.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

            SqlParameter PV_COD_PARTICIPANTE_SALIDA = new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_SALIDA", Direction = System.Data.ParameterDirection.Output, Size = 250 };
            SqlParameter PV_ERROR = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };

            vLista.Add(PV_COD_PARTICIPANTE_SALIDA);
            vLista.Add(PV_ERROR);

            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CodParticipante = PV_COD_PARTICIPANTE_SALIDA.Value.ToString();
                _CargarSucursales();               
                _CargarDgParticipante();
                configurarTabs();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        private void _LimpiarParticipante()
        {
            //ddlTipoParticipanta.SelectedIndex = -1;
            txtRazonSocialParticipante.Text = string.Empty;
            txtNombreParticipante.Text = string.Empty;
            txtApellidoParticipante.Text = string.Empty;
            ddlTipoDocumentoParticipante.SelectedIndex = -1;
            txtNitParticipante.Text = string.Empty;
            txtNroDocumentoParticipante.Text = string.Empty;
            ddlNacionalidadParticipante.SelectedIndex = -1;
            txtCargoParticipante.Text = string.Empty;
            ddlCiudadParticipante.SelectedIndex = -1;
            txtDireccionParticipante.Text = string.Empty;
            txtPaginaWebParticipante.Text = string.Empty;
            txtTelefonoParticipante.Text = string.Empty;
            txtTelefonoCelular.Text = string.Empty;
            txtCorreoParticipante.Text = string.Empty;
            //ddlBancoParticipante.SelectedIndex = -1;
            //txtCuentaParticipante.Text = string.Empty;
            txtCodigoComisionParticipante.Text = string.Empty;

        }

        protected void ddlTipoParticipanta_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (new cDevComboBox()._ValidaCombos(ddlTipoParticipanta))
            {
                _EsPersonaJuridica = (ddlTipoParticipanta.SelectedItem.Value.ToString().Split('|')[1] == "PJ") ? true : false;
                _ConfigurarCampos();
                /*string tipoParticipanta = ddlTipoParticipanta.SelectedItem.Value.ToString().Split('|')[0].ToString();
                dgParticipante.FilterExpression = ("[TIPO_PARTICIPANTE] = '"+ tipoParticipanta + "'");
                dgParticipante.DataBind();
                */

                if (!_EsPersonaJuridica)
                {
                    tbMenu.Tabs[3].Visible = false;
                }

                _LimpiarContactos();
                _LimpiarParticipante();
                _LimpiarPersonal();
                _LimpiarSucursales();

            }
        }

        public void _ConfigurarCampos()
        {
            idJuridica1.Visible = !_EsPersonaJuridica;
            idJuridica2.Visible = !_EsPersonaJuridica;
            idJuridica3.Visible = !_EsPersonaJuridica;
            idJuridica4.Visible = !_EsPersonaJuridica;
            idJuridica5.Visible = !_EsPersonaJuridica;
            idJuridica6.Visible = _EsPersonaJuridica;
            idJuridica7.Visible = _EsPersonaJuridica;

            idJuridica8.Visible = _EsPersonaJuridica;
            idJuridica9.Visible = _EsPersonaJuridica;

            idJuridica11.Visible = !_EsPersonaJuridica;

            /*
            idJuridica12.Visible = !_EsPersonaJuridica;
            idJuridica13.Visible = !_EsPersonaJuridica;
            idJuridica14.Visible = !_EsPersonaJuridica;
            */

        }

        protected void ASPxRadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_PARTICIPANTE";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = ASPxRadioButtonList1.SelectedItem.Value.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_RAZON_SOCIAL", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_APELLIDOS", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_NUMERO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_NACIONALIDAD", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_CARGO", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD_RESIDENCIA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DIRECCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_PAGINA_WEB", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_TELEFONO", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_EMAIL", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_BANCO", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_CUENTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_EMISION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

                SqlParameter PV_COD_PARTICIPANTE_SALIDA = new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_SALIDA", Direction = System.Data.ParameterDirection.Output, Size = 250 };
                SqlParameter PV_ERROR = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };

                vLista.Add(PV_COD_PARTICIPANTE_SALIDA);
                vLista.Add(PV_ERROR);

                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    if (ASPxRadioButtonList1.SelectedItem.Value.ToString() == "D")
                    {
                        _LimpiarParticipante();
                    }
                    _CargarDgParticipante();
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }
            catch (Exception)
            {


            }


        }

        protected void rdlEstadoSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_ABM_SUCURSALES";
                List<SqlParameter> vLista = new List<SqlParameter>();

                vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = rdlEstadoSucursal.SelectedItem.Value.ToString() });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_SUCURSAL", Direction = System.Data.ParameterDirection.Input, Value = _CodSucursal });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DIRECCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_PAIS", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_LONGITUD", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_LATITUD", Direction = System.Data.ParameterDirection.Input, Value = "" });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

                SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                vLista.Add(paramError);
                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    if (rdlEstadoSucursal.SelectedItem.Value.ToString() == "D")
                    {
                        _LimpiarSucursales();
                    }

                    _CargarDgSucursales();

                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }
            catch (Exception)
            {

            }


        }

        protected void btnModificarSucursales_Command(object sender, CommandEventArgs e)
        {
            string idSucursal = e.CommandArgument.ToString();

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_SUCURSALES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                foreach (DataRow item in vRespuesta._Tabla.Rows)
                {
                    if (item["COD_SUCURSAL"].ToString() == idSucursal)
                    {
                        _CodSucursal = item["COD_SUCURSAL"].ToString();
                        _EsNuevoSucursal = false;
                        DataRow vFila = item;
                        txtLatitudSucursales.Text = item["LATITUD"].ToString();
                        txtLongitudSucursales.Text = item["LONGITUD"].ToString();
                        txtSucursalSucursales.Text = item["COD_SUCURSAL"].ToString();
                        txtDescripcionSucursalSucursales.Text = item["DESCRIPCION"].ToString();
                        txtDireccionSucursales.Text = item["DIRECCION"].ToString();
                        _CargarNacionalidadPais();
                        ddlPaisSucursales.SelectedItem = ddlPaisSucursales.Items.FindByValue(item["PAIS"].ToString());
                        ddlPaisSucursales_SelectedIndexChanged(null, null);
                        ddlCiudadSucursales.SelectedItem = ddlCiudadSucursales.Items.FindByValue(item["CIUDAD"].ToString());
                        ddlCiudadSucursales_SelectedIndexChanged(null, null);
                        rdlEstadoSucursal.SelectedIndex = item["ESTADO"].ToString() == "A" ? 0 : 1;
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            StringBuilder vMensaje = new StringBuilder();
            if (string.IsNullOrEmpty(txtNombrePersonal.Text))
            {
                vMensaje.Append("La nombre del personal no puede ser vacio</br>");
            }
            if (string.IsNullOrEmpty(txtApellidoPaternoPersonal.Text))
            {
                vMensaje.Append("El apellido no puede ser vacio </br>");
            }
            if (rdltipoDocumentoPersonal.SelectedIndex <= -1)
            {
                vMensaje.Append("Debe seleccionar un tipo de documento</br>");
            }

            if (string.IsNullOrEmpty(txtNroDocumentoPersonal.Text))
            {
                vMensaje.Append("El número de documento no puede ser vacio </br>");
            }
            if (!new cDevComboBox()._ValidaCombos(ddlNacionalidadPersonal))
            {
                vMensaje.Append("La nacionalidad no debe ser vacia</br>");
            }

            if (!new cDevComboBox()._ValidaCombos(ddlCiudadPersonal))
            {
                vMensaje.Append("La ciudad de referencia no debe ser vacia</br>");
            }
            if (string.IsNullOrEmpty(txtDireccionPersonal.Text))
            {
                vMensaje.Append("La dirección del personal no puede ser vacio </br>");
            }
            if (!new cDevComboBox()._ValidaCombos(ddlSucursalPersonal))
            {
                vMensaje.Append("La sucursal no debe ser vacia</br>");
            }

            if (string.IsNullOrEmpty(txtTelefonoCelularPersonal.Text))
            {
                vMensaje.Append("El telèfono celular no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(txtCorreoElectronicoPersonalPersonal.Text))
            {
                vMensaje.Append("El correo electronico no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_PERSONAL";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoPersonal ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PERSONAL", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevoPersonal ? "" : _CodPersonal });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE", Direction = System.Data.ParameterDirection.Input, Value = txtNombrePersonal.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_APELLIDOS", Direction = System.Data.ParameterDirection.Input, Value = txtApellidoPaternoPersonal.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = rdltipoDocumentoPersonal.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NUMERO_DOCUMENTO", Direction = System.Data.ParameterDirection.Input, Value = txtNroDocumentoPersonal.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NACIONALIDAD", Direction = System.Data.ParameterDirection.Input, Value = ddlNacionalidadPersonal.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CARGO", Direction = System.Data.ParameterDirection.Input, Value = txtCargoPersonal.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CIUDAD_RESIDENCIA", Direction = System.Data.ParameterDirection.Input, Value = ddlCiudadPersonal.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DIRECCION", Direction = System.Data.ParameterDirection.Input, Value = txtDireccionPersonal.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TELEFONO", Direction = System.Data.ParameterDirection.Input, Value = txtTelefonoCelularPersonal.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_EMAIL", Direction = System.Data.ParameterDirection.Input, Value = txtCorreoElectronicoPersonalPersonal.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_SUCURSAL", Direction = System.Data.ParameterDirection.Input, Value = ddlSucursalPersonal.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarDgPersonal();
                _LimpiarPersonal();

                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }

        private void _LimpiarPersonal()
        {

            txtNombrePersonal.Text = string.Empty;
            txtApellidoPaternoPersonal.Text = string.Empty;
            rdltipoDocumentoPersonal.SelectedIndex = 0;
            txtNroDocumentoPersonal.Text = string.Empty;
            ddlNacionalidadPersonal.SelectedIndex = -1;
            txtCargoPersonal.Text = string.Empty;
            ddlCiudadPersonal.SelectedIndex = -1;
            txtDireccionPersonal.Text = string.Empty;
            txtTelefonoCelularPersonal.Text = string.Empty;
            txtCorreoElectronicoPersonalPersonal.Text = string.Empty;
            ddlSucursalPersonal.SelectedIndex = -1;

        }

        protected void btnModificarPersonal_Command(object sender, CommandEventArgs e)
        {
            string codPersonal = e.CommandArgument.ToString();
            if (!String.IsNullOrEmpty(_CodParticipante))
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_SPERSONAL";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = _CodParticipante });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {
                    foreach (DataRow item in vRespuesta._Tabla.Rows)
                    {
                        if (item["COD_PARTICIPANTE"].ToString() == codPersonal)
                        {
                            _CodPersonal = codPersonal;
                            _EsNuevoPersonal = false;
                            txtNombrePersonal.Text = item["NOMBRE"].ToString();
                            txtApellidoPaternoPersonal.Text = item["APELLIDOS"].ToString();
                            txtCargoPersonal.Text = item["CARGO"].ToString();
                            _CargarTipoDocumento();
                            rdltipoDocumentoPersonal.SelectedItem = rdltipoDocumentoPersonal.Items.FindByValue(item["TIPO_DOCUMENTO"].ToString());
                            txtNroDocumentoPersonal.Text = item["NUMERO_DOCUMENTO"].ToString();
                            _CargarNacionalidadPais();
                            ddlNacionalidadPersonal.SelectedItem = ddlNacionalidadPersonal.Items.FindByValue(item["NACIONALIDAD"].ToString());
                            ddlNacionalidadPersonal_SelectedIndexChanged(null, null);
                            ddlCiudadPersonal.SelectedItem = ddlCiudadPersonal.Items.FindByValue(item["CIUDAD_RESIDENCIA"].ToString());
                            txtDireccionPersonal.Text = item["DIRECCION"].ToString();
                            _CargarSucursales();
                            ddlSucursalPersonal.SelectedItem = ddlSucursalPersonal.Items.FindByValue(item["COD_SUCURSAL"].ToString());
                            txtTelefonoCelularPersonal.Text = item["TELEFONO"].ToString();
                            txtCorreoElectronicoPersonalPersonal.Text = item["EMAIL"].ToString();
                            break;
                        }
                    }
                }
            }
        }

        protected void btnModificarParticipante_Command(object sender, CommandEventArgs e)
        {
            string idCodParticipante = e.CommandArgument.ToString();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES";

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                foreach (DataRow item in vRespuesta._Tabla.Rows)
                {
                    if (item["COD_PARTICIPANTE"].ToString() == idCodParticipante)
                    {
                        _CodParticipante = item["COD_PARTICIPANTE"].ToString();
                        _CargarParticipante();
                        string busqueda = "";

                        EntidadSp vEntidad1 = new EntidadSp();
                        vEntidad1._NombreSP = "PR_GET_DATOS_DOMINIOS_PARTICIPANTE";

                        cORM vOrm1 = new cORM("DbAmaszonas");
                        cRespuestaLista vRespuesta1 = vOrm._ConsultaSP(vEntidad1);
                        if (vRespuesta1._TipoRespuesta == eTipoRespuesta.Exito)
                        {
                            foreach (DataRow itemXX in vRespuesta1._Tabla.Rows)
                            {
                                if (itemXX["codigo"].ToString().Split('|')[0].ToString() == item["TIPO_PARTICIPANTE"].ToString())
                                {
                                    busqueda = itemXX["codigo"].ToString();
                                    break;
                                }
                            }
                        }
                        _EsNuevoParticipante = false;

                        ddlTipoParticipanta.SelectedItem = ddlTipoParticipanta.Items.FindByValue(busqueda);
                        ddlTipoParticipanta_SelectedIndexChanged1(null, null);
                        txtNombreParticipante.Text = item["NOMBRE"].ToString();
                        txtApellidoParticipante.Text = item["APELLIDOS"].ToString();
                        _CargarTipoDocumentos();
                        ddlTipoDocumentoParticipante.SelectedItem = ddlTipoDocumentoParticipante.Items.FindByValue(item["TIPO_DOCUMENTO"].ToString());
                        txtNroDocumentoParticipante.Text = item["NUMERO_DOCUMENTO"].ToString();
                        txtCargoParticipante.Text = item["CARGO"].ToString();
                        txtRazonSocialParticipante.Text = item["RAZON_SOCIAL"].ToString();
                        txtNitParticipante.Text = item["NUMERO_DOCUMENTO"].ToString();
                        txtNroDocumentoParticipante.Text = item["NUMERO_DOCUMENTO"].ToString();
                        _CargarNacionalidadPais();
                        ddlNacionalidadParticipante.SelectedItem = ddlNacionalidadParticipante.Items.FindByValue(item["NACIONALIDAD"].ToString());
                        ddlNacionalidadParticipante_SelectedIndexChanged(null, null);
                        ddlCiudadParticipante.SelectedItem = ddlCiudadParticipante.Items.FindByValue(item["CIUDAD_RESIDENCIA"].ToString());
                        txtDireccionParticipante.Text = item["DIRECCION"].ToString();
                        txtPaginaWebParticipante.Text = item["PAGINA_WEB"].ToString();
                        txtTelefonoParticipante.Text = item["TELEFONO"].ToString();
                        txtCorreoParticipante.Text = item["EMAIL"].ToString();
                        txtTelefonoCelular.Text = item["TELEFONO"].ToString();
                        _CargarBancos();
                        //ddlBancoParticipante.SelectedItem = ddlBancoParticipante.Items.FindByValue(item["BANCO"].ToString());
                        //txtCuentaParticipante.Text = item["CUENTA"].ToString();
                        txtCodigoComisionParticipante.Text = item["COD_EMISION"].ToString();
                        ASPxRadioButtonList1.SelectedIndex = item["ESTADO"].ToString() == "A" ? 0 : 1;
                        configurarTabs();
                        break;

                    }
                }
            }
        }

        protected void btnLimpiarParticipante_Click(object sender, EventArgs e)
        {
            _EsNuevoParticipante = true;
            _LimpiarParticipante();
            _CodParticipante = String.Empty;
            _ConfigurarCampos();
            configurarTabs();
        }

        protected void btnLimpiarSucursales_Click(object sender, EventArgs e)
        {
            _EsNuevoSucursal = true;
            txtSucursalSucursales.Text = string.Empty;
            _LimpiarSucursales();
        }

        protected void btnLimpiarContactos_Click(object sender, EventArgs e)
        {
            _EsNuevoContacto = true;
            txtCodContacto.Text = string.Empty;
            _LimpiarContactos();
        }

        protected void btnLimpiarPersonal_Click(object sender, EventArgs e)
        {
            _EsNuevoPersonal = true;
            _LimpiarPersonal();
        }

        protected void btnUsuario_Command(object sender, CommandEventArgs e)
        {
            Session["codParticipante"] = _CodParticipante;
            Session["codPersonal"] = e.CommandArgument.ToString();
            Session["esJuridica"] = "1";
            Session["retorno"] = "0";
            Response.Redirect("~/Paginas/Participante/frmUsuario.aspx");
        }

        protected void btnUsuarioParticipante_Command(object sender, CommandEventArgs e)
        {
            Session["codParticipante"] = e.CommandArgument.ToString();
            Session["codPersonal"] = "";
            Session["esJuridica"] = "0";
            Session["retorno"] = "1";
            Response.Redirect("~/Paginas/Participante/frmUsuario.aspx");
        }
    }
}