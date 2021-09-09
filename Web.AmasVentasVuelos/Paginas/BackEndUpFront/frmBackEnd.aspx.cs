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

namespace Web.AmasVentasVuelos.Paginas.BackEndUpFront
{
    public partial class frmBackEnd : cBasePagina
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
                _Limpiar();
                _CargarTipo();
                _CargarModo();
                _CargarRuta();
              
                lblCodigo.Text = "";

            }
            _CargarDgBackEnd();
            ShowMessage();
        }

        private void _Limpiar()
        {
            this.txtRegla.Text = String.Empty;
            this.txtRangoFin.Text = String.Empty;
            this.txtRangoIni.Text = String.Empty;
            this.txtComisiones.Text = String.Empty;
            this.dtFechaDesde.Date = DateTime.Now.Date;
            this.dtFechaHasta.Text = String.Empty;
            this.lbRuta.Items.Clear();
            this.ddlRuta.Value = String.Empty;
            this.ddlModo.Value = String.Empty;
            this.lblCodigo.Text = String.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _ActualizarBackEnd();
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                _Limpiar();
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);
            }
        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string _CodCuentaCorriente = e.CommandArgument.ToString();
                lblCodigo.Text = e.CommandArgument.ToString();

                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_BACKEND";

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {

                    foreach (DataRow vfila in vRespuesta._Tabla.Rows)
                    {
                        if (vfila["COD_BACKEND"].ToString() == _CodCuentaCorriente)
                        {
                            this.txtRegla.Text = vfila["NRO_REGLA"].ToString();
                            this.txtComisiones.Text = vfila["COMISION"].ToString();
                            if (String.IsNullOrEmpty(vfila["FECHA_INICIO"].ToString()))
                                dtFechaDesde.Value = String.Empty;
                            else
                                this.dtFechaDesde.Date = DateTime.Parse(vfila["FECHA_INICIO"].ToString());
                            
                            if (String.IsNullOrEmpty(vfila["FECHA_FIN"].ToString()))
                                dtFechaHasta.Value = String.Empty;
                            else
                                this.dtFechaHasta.Date = DateTime.Parse(vfila["FECHA_FIN"].ToString());
                            this.txtRangoIni.Text = vfila["RANGO_INICIO"].ToString();
                            this.txtRangoFin.Text = vfila["RANGO_FIN"].ToString();
                            this.ddlModo.Value = vfila["MODO"].ToString();
                            this.rbtnEstado.SelectedIndex = vfila["ESTADO"].ToString() == "A" ? 0 : 1;
                            string[] rutas = vfila["ruta"].ToString().Split(',');
                            int x = rutas.Length;
                            _CargarRuta();
                            for (int i = 0; i < x; i++)
                            {
                                ListEditItem itemDv = new ListEditItem();
                                ListItem item = new ListItem();
                                itemDv.Text = rutas[i];
                                itemDv.Value = rutas[i];
                                item.Value = rutas[i];
                                lbRuta.Items.Add(item);
                                int index = ddlRuta.Items.IndexOfValue(itemDv.Value.ToString());
                                ddlRuta.Items.RemoveAt(index);
                            }

                            break;
                        }
                    }
                    _EsNuevo = false;
                }
                else
                {
                    ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                }
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);
            }
        }

        private void _CargarDgBackEnd()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_BACKEND";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevGrilla()._CargarDatos(dgBackEnd, vRespuesta._Tabla, "COD_BACKEND");
            }
        }

        //private void _CargarDgBackEndAAsignarRutas()
        //{

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_BACKEND_A_ASIGNAR_RUTAS";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        // new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
        //    }
        //}

        //private void _CargarDgBackEndAsignadoRutas()
        //{
        //    String txtCodBackEnd = "";

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_BACKEND_ASIGNADO_RUTAS";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = txtCodBackEnd });
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        // new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
        //    }
        //}

        //private void _CargarDgBackEnd()
        //{

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_UPFRONT";
        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        new cDevGrilla()._CargarDatos(dgBackEnd, vRespuesta._Tabla, "cod_upfront");
        //    }
        //}

        //private void _CargarDgUpFrontAAsignarRutas()
        //{

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_UPFRONT_A_ASIGNAR_RUTAS";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        // new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
        //    }
        //}

        //private void _CargarDgUpFrontAAsignarVuelos()
        //{

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_UPFRONT_A_ASIGNAR_VUELOS";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        // new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
        //    }
        //}


        //private void _CargarDgUpFrontAsignadoRutas()
        //{
        //    String txtCodUpFront = "";

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_UPFRONT_ASIGNADO_RUTAS";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_UPFRONT", Direction = System.Data.ParameterDirection.Input, Value = txtCodUpFront });
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        // new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
        //    }
        //}

        //private void _CargarDgUpFrontAsignadoVuelos()
        //{
        //    String txtCodUpFront = "";

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_UPFRONT_ASIGNADO_VUELOS";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_UPFRONT", Direction = System.Data.ParameterDirection.Input, Value = txtCodUpFront });
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
        //    {
        //        // new cDevGrilla()._CargarDatos(dgDominios, vRespuesta._Tabla, "codigo");
        //    }
        //}

        private void _ActualizarBackEnd()
        {
            StringBuilder vMensaje = new StringBuilder();

            if (string.IsNullOrEmpty(txtRegla.Text))
            {
                vMensaje.Append("La Regla no puede ser vacio </br>");
            }

            if (string.IsNullOrEmpty(this.txtComisiones.Text))
            {
                vMensaje.Append("La comisión no puede ser vacio </br>");
            }

            if (string.IsNullOrEmpty(this.ddlModo.Text))
            {
                vMensaje.Append("El valor modo no puede ser vacio </br>");
            }

            
            if (lbRuta.Items.Count == 0)
            {
                vMensaje.Append("Debe seleccionar una ruta </br>");
            }

            if (string.IsNullOrEmpty(this.txtComisiones.Text))
            {
                vMensaje.Append("La comisión no puede ser vacio </br>");
            }

            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

            if (dtFechaDesde.Date == DateTime.Parse("01/01/0001"))
                dtFechaDesde.Date = DateTime.Parse("01/01/3000");
            if (dtFechaHasta.Date == DateTime.Parse("01/01/0001"))
                dtFechaHasta.Date = DateTime.Parse("01/01/3000");
            

            //if (chkRutas.Checked)
            //    this.ddlRuta.Value = "S";
           

            string rutas = "";
            int rCont = 0;
            //int rMax = lbRuta.Items.Count;
            foreach (ListItem itemR in lbRuta.Items)
            {
                if (rCont == 0)
                {
                    rutas = itemR.Value;
                }
                else
                {
                    rutas = rutas + ',' + itemR.Value;
                }
                rCont++;
            }
            
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_BACKEND";
            List<SqlParameter> vLista = new List<SqlParameter>();


            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = lblCodigo.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NRO_REGLA", Direction = System.Data.ParameterDirection.Input, Value = txtRegla.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_INICIO", Direction = System.Data.ParameterDirection.Input, Value = dtFechaDesde.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_FIN", Direction = System.Data.ParameterDirection.Input, Value = dtFechaHasta.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_MODO", Direction = System.Data.ParameterDirection.Input, Value = ddlModo.Value.ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_RUTA", Direction = System.Data.ParameterDirection.Input, Value = rutas });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VUELOS", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PB_RANGO_INICIO ", Direction = System.Data.ParameterDirection.Input, Value = long.Parse(txtRangoIni.Text) });
            vLista.Add(new SqlParameter() { ParameterName = "@PB_RANGO_FIN", Direction = System.Data.ParameterDirection.Input, Value = long.Parse(txtRangoFin.Text) });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_COMISION", Direction = System.Data.ParameterDirection.Input, Value = decimal.Parse(txtComisiones.Text) });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {

                _Limpiar();
                _CargarDgBackEnd();
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

        //private void _ActualizarBackEndDetalle()
        //{
        //    String txtCodBackEndDetalle = "";
        //    String txtCodBackEnd = "";
        //    String txtRutaVuelo = "";
        //    String txtValor = "";

        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_ABM_BACKEND_DETALLE";
        //    List<SqlParameter> vLista = new List<SqlParameter>();

        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_BACKEND_DETALLE", Direction = System.Data.ParameterDirection.Input, Value = txtCodBackEndDetalle });
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = txtCodBackEnd });
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_RUTA_VUELO", Direction = System.Data.ParameterDirection.Input, Value = txtRutaVuelo });
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR", Direction = System.Data.ParameterDirection.Input, Value = txtValor });

        //    SqlParameter paramUsuario = new SqlParameter() { ParameterName = "PV_USUARIO", Direction = System.Data.ParameterDirection.Output, Size = 100 };
        //    SqlParameter paramError = new SqlParameter() { ParameterName = "PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };

        //    vLista.Add(paramUsuario);
        //    vLista.Add(paramError);
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
        //    {

        //        _Limpiar();
        //        ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
        //        ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
        //        _EsNuevo = true;
        //    }
        //    else
        //    {
        //        ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
        //        ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
        //    }
        //}


       


        private void _ActualizarUpFrontDetalle()
        {
            String txtCodFrontUpDetalle = "";
            String txtCodFrontUp = "";
            String txtRutaVuelo = "";
            String txtValor = "";

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_UPFRONT_DETALLE";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_UPFRONT_DETALLE", Direction = System.Data.ParameterDirection.Input, Value = txtCodFrontUpDetalle });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_UPFRONT", Direction = System.Data.ParameterDirection.Input, Value = txtCodFrontUp });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_RUTA_VUELO", Direction = System.Data.ParameterDirection.Input, Value = txtRutaVuelo });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_VALOR", Direction = System.Data.ParameterDirection.Input, Value = txtValor });

            SqlParameter paramUsuario = new SqlParameter() { ParameterName = "PV_USUARIO", Direction = System.Data.ParameterDirection.Output, Size = 100 };
            SqlParameter paramError = new SqlParameter() { ParameterName = "PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };

            vLista.Add(paramUsuario);
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {

                _Limpiar();
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

        protected void rbtnEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigo.Text == "")
                { ShowNotifyMessage("Debe seleccionar un registro2!", eTipoRespuesta.Advertencia); }
                else
                {
                    EntidadSp vEntidad = new EntidadSp();
                    vEntidad._NombreSP = "PR_ABM_BACKEND";
                    List<SqlParameter> vLista = new List<SqlParameter>();

                    vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = rbtnEstado.SelectedItem.Value.ToString() });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = lblCodigo.Text });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_NRO_REGLA", Direction = System.Data.ParameterDirection.Input, Value = txtRegla.Text });
                    vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_INICIO", Direction = System.Data.ParameterDirection.Input, Value = dtFechaDesde.Date });
                    vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_FIN", Direction = System.Data.ParameterDirection.Input, Value = dtFechaHasta.Date });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_MODO", Direction = System.Data.ParameterDirection.Input, Value = ddlModo.Value.ToString() });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_RUTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_VUELOS", Direction = System.Data.ParameterDirection.Input, Value = "" });
                    vLista.Add(new SqlParameter() { ParameterName = "@PB_RANGO_INICIO ", Direction = System.Data.ParameterDirection.Input, Value = long.Parse(txtRangoIni.Text) });
                    vLista.Add(new SqlParameter() { ParameterName = "@PB_RANGO_FIN", Direction = System.Data.ParameterDirection.Input, Value = long.Parse(txtRangoFin.Text) });
                    vLista.Add(new SqlParameter() { ParameterName = "@PD_COMISION", Direction = System.Data.ParameterDirection.Input, Value = decimal.Parse(txtComisiones.Text) });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                    SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                    vLista.Add(paramError);
                    vEntidad._Parametros = vLista;

                    cORM vOrm = new cORM("DbAmaszonas");
                    cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                    {
                        _Limpiar();
                        ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                        ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);

                        _CargarDgBackEnd();
                        _EsNuevo = true;
                        this.lblCodigo.Text = "";
                    }
                    else
                    {
                        ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                        ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                    }
                }
                
            }
            catch (Exception exception)
            {
                ShowMessage(exception.ToString(), eTipoRespuesta.Error);

            }
        }

        private void _CargarTipo()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "TIPO BACKEND" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
               // new cDevComboBox()._CargarComboBox(ddlTipo, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarModo()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "MODO BACKEND" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(this.ddlModo, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        private void _CargarRuta()
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "RUTAS" });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                new cDevComboBox()._CargarComboBox(ddlRuta, vRespuesta._Tabla, "codigo", "descripcion");
            }
        }

        //private void _CargarVuelo()
        //{
        //    EntidadSp vEntidad = new EntidadSp();
        //    vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

        //    List<SqlParameter> vLista = new List<SqlParameter>();
        //    vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "VUELOS" });
        //    vEntidad._Parametros = vLista;

        //    cORM vOrm = new cORM("DbAmaszonas");
        //    cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
        //    if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
        //    {
        //        new cDevComboBox()._CargarComboBox(this.ddlVuelo, vRespuesta._Tabla, "codigo", "descripcion");
        //    }
        //}

        protected void chkRutas_CheckedChanged(object sender, EventArgs e)
        {

            if (chkRutas.Checked)
            {
                lbRuta.Items.Clear();
                this.ddlRuta.Enabled = false;
                ////CARGAMOS LOS DATOS AL LISTBOX////
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_DATOS_DOMINIOS";

                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@PV_DOMINIO", Direction = System.Data.ParameterDirection.Input, Value = "RUTAS" });
                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);
                foreach (DataRow dr in vRespuesta._Tabla.Rows)
                {
                    ListItem item = new ListItem();
                    item.Text = dr["descripcion"].ToString();
                    item.Value = dr["codigo"].ToString();
                    lbRuta.Items.Add(item);
                }
                lbRuta.Enabled = false;
            }

            else
            {
                this.ddlRuta.Enabled = true;
                lbRuta.Items.Clear();
                lbRuta.Enabled = true;
            }

        }
        protected void ddlRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = new ListItem();
            item.Text = ddlRuta.Text;
            item.Value = ddlRuta.Value.ToString();
            lbRuta.Items.Add(item);
            ddlRuta.Items.RemoveAt(ddlRuta.SelectedIndex);
            ddlRuta.SelectedIndex = -1;
        }
        protected void lbRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListEditItem itemDev = new ListEditItem();
            itemDev.Text = lbRuta.Text;
            itemDev.Value = lbRuta.SelectedValue;
            ddlRuta.Items.Add(itemDev);
            lbRuta.Items.RemoveAt(lbRuta.SelectedIndex);
        }
        //protected void chkVuelos_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkVuelos.Checked)
        //        this.ddlVuelo.Enabled = false;
        //    else
        //        this.ddlVuelo.Enabled = true;
        //}
    }
}