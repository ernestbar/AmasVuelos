using prySqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos.Paginas.Administracion
{
    public partial class frmDominios : cBasePagina
    {
        public string _IdDominio
        {
            get
            {
                if (hfDominio.Contains("hfDominio"))
                {
                    return hfDominio.Get("hfDominio").ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                hfDominio.Set("hfDominio", value);
            }
        }
        public bool _EsDominio
        {
            get
            {
                if (hfDominio.Contains("_EsDominio"))
                {
                    return (bool)hfDominio.Get("_EsDominio");
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfDominio.Set("_EsDominio", value);
            }
        }


        public bool _EsNuevo
        {
            get
            {
                if (hfDominio.Contains("_EsNuevo"))
                {
                    return (bool)hfDominio.Get("_EsNuevo");
                }
                else
                {
                    return true;
                }
            }
            set
            {
                hfDominio.Set("_EsNuevo", value);
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
                _CargarTipos();
                _ComboTipoDominio.Visible = false;
                _TextoDominio.Visible = true;
                _EsDominio = true;
                ddlTipoDominio_SelectedIndexChanged(null, null);
                rdlTipoDominio_SelectedIndexChanged(null, null);
            }
            _CargarGrilla();
            // ShowMessage();


        }

        private void _CargarTipos()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_LISTA_DOMINIOS";
            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlTipoDominio, vRespuesta._Tabla, "dominio", "dominio");
            }
        }


        public void _CargarGrilla()
        {
            //if (new cDevComboBox()._ValidaCombos(ddlTipoDominio))
            //{
            if (_EsDominio)
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";
                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = _EsDominio ? "" : !new cDevComboBox()._ValidaCombos(ddlTipoDominio) ? "" : ddlTipoDominio.Value.ToString() });
                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
                }
            }
            else
            {


                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";
                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoDominio.Value.ToString() });
                vEntidad._Parametros = vLista;
                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
                {
                    new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
                }
            }



            //}
        }

        protected void ddlTipoDominio_SelectedIndexChanged(object sender, EventArgs e)
        {

            _CargarGrilla();



        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            //if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            //{
            //    string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
            //    ShowMessage(mensaje, eTipoRespuesta.Advertencia);
            //    ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
            //    return;
            //}

            StringBuilder vMensaje = new StringBuilder();
            if (_EsDominio)
            {
                if (string.IsNullOrEmpty(txtDominio.Text))
                {
                    vMensaje.Append("El dominio no puede ser vacio </br>");
                }
            }
            else
            {
                if (!new cDevComboBox()._ValidaCombos(ddlTipoDominio))
                {
                    vMensaje.Append("El dominio no puede ser vacio </br>");
                }
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    vMensaje.Append("El código no puede ser vacio </br>");
                }

                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    vMensaje.Append("La descripción no puede ser vacio </br>");
                }
            }




            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_DOMINIOS";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = (_EsNuevo) ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = (_EsDominio) ? txtDominio.Text : ddlTipoDominio.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CODIGO", Direction = System.Data.ParameterDirection.Input, Value =/* (_EsDominio) ?"": */txtCodigo.Text.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = /*(_EsDominio) ? "":*/txtDescripcion.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR_CARACTER", Direction = System.Data.ParameterDirection.Input, Value =/* (_EsDominio) ? "":*/txtValorCaracter.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR_NUMERICO", Direction = System.Data.ParameterDirection.Input, Value = /*(_EsDominio) ? "":*/spnValorNumerico.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR_CARACTER_EXTRA", Direction = System.Data.ParameterDirection.Input, Value = /*(_EsDominio) ? "":*/ txtValorCaracterExtra.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;



            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarGrilla();
                btnLimpiar_Click(null, null);
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

            //if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            //{
            //    string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
            //    ShowMessage(mensaje, eTipoRespuesta.Advertencia);
            //    ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
            //    return;

            //_EsNuevo codigo par asubir
            //}

            string idDominio = e.CommandArgument.ToString();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_DOMINIOS";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "D" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = idDominio.Split('|')[0].ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_CODIGO", Direction = System.Data.ParameterDirection.Input, Value = idDominio.Split('|')[1].ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR_CARACTER", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR_NUMERICO", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR_CARACTER_EXTRA", Direction = System.Data.ParameterDirection.Input, Value = string.Empty });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario") });
            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };

            vLista.Add(paramError);
            vEntidad._Parametros = vLista;
            cORM vOrm = new cORM("DbAmaszonas");

            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _CargarGrilla();
                btnLimpiar_Click(null, null);
                if (_EsDominio)
                {
                    _CargarTipos();
                }




                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }


        }

        protected void rdlTipoDominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdlTipoDominio.Value.ToString() == "0")
            {
                _ComboTipoDominio.Visible = false;
                _TextoDominio.Visible = true;
                _EsDominio = true;
                //_COMODIN.Visible = false;
                txtDominio.Text = string.Empty;
                txtValorCaracter.Text = string.Empty;
                txtValorCaracterExtra.Text = string.Empty;
                spnValorNumerico.Value = 0;
                txtCodigo.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
            else
            {
                ddlTipoDominio.SelectedIndex = 1;
                _ComboTipoDominio.Visible = true;

                _TextoDominio.Visible = false;
                _EsDominio = false;
                //_COMODIN.Visible = true;
                txtDominio.Text = string.Empty;
                txtValorCaracter.Text = string.Empty;
                txtValorCaracterExtra.Text = string.Empty;
                spnValorNumerico.Value = 0;
                txtCodigo.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
            _CargarGrilla();
            txtCodigo.Enabled = true;
            ddlTipoDominio.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            _EsNuevo = true;
            // rdlTipoDominio.Value = "0";
            //     rdlTipoDominio_SelectedIndexChanged(null, null);
            txtDominio.Text = string.Empty;
            txtValorCaracter.Text = string.Empty;
            txtValorCaracterExtra.Text = string.Empty;
            spnValorNumerico.Value = 0;
            if (_EsDominio)
            {
                _CargarTipos();
            }

            //ddlTipoDominio_SelectedIndexChanged(null, null);
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCodigo.Enabled = true;
            ddlTipoDominio.Enabled = true;
        }

        protected void btnModificar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            //if (new cPolicy().Acceso(cGestorSession.CurrrentPage, (sender as Control).ID))
            //{
            //    string mensaje = "No tiene acceso a esta opcion, favor consulte al administrador del sistema";
            //    ShowMessage(mensaje, eTipoRespuesta.Advertencia);
            //    ShowNotifyMessage(mensaje, eTipoRespuesta.Advertencia);
            //    return;
            //}

            string idDominio = e.CommandArgument.ToString();
            string dominio = idDominio.Split('|')[0].ToString();
            string codigo = idDominio.Split('|')[1].ToString();
            string descripcion = idDominio.Split('|')[2].ToString();
            string caracter = idDominio.Split('|')[3].ToString();
            string numerico = idDominio.Split('|')[4].ToString();
            string caracter_extra = idDominio.Split('|')[5].ToString();
            _ComboTipoDominio.Visible = false;
            _TextoDominio.Visible = true;
            _EsDominio = rdlTipoDominio.SelectedIndex == 0 ? true : false;
            _EsNuevo = false;
            _CargarTipos();
            ddlTipoDominio.SelectedItem = ddlTipoDominio.Items.FindByValue(dominio);
            txtDominio.Text = dominio;
            txtCodigo.Text = codigo;
            txtDescripcion.Text = descripcion;
            txtValorCaracter.Text = caracter;
            txtValorCaracterExtra.Text = caracter_extra;
            spnValorNumerico.Text = numerico;
            txtCodigo.Enabled = _EsDominio ? true : false;
            ddlTipoDominio.Enabled = _EsDominio ? true : false;
        }
    }
}