using DevExpress.Web;
using prySqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos.Paginas.Participante
{
    public partial class frmComunicados : cBasePagina
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
                _CargarTipoParticipantesCombo();
                lblCodigo.Text = "";

            }
            _CargarDgNotificaciones();
            ShowMessage();
        }

        private void _CargarTipoParticipantesCombo()
        {

            ddlTipoParticipante2.Items.Clear();
            ddlTipoParticipante2.Items.Insert(0, "SELECCIONAR");
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
                    ddlTipoParticipante2.Items.Add(miItem);
                }
            }
        }

        private void _CargarDgNotificaciones()
        {

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_COMUNICADOS";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                new cDevGrilla()._CargarDatos(dgComunicados, vRespuesta._Tabla, "ID_COMUNICADO");
            }
        }
        private void _CargarParticipantesCombo()
        {
            //ddlParticipantes.Items.Clear();
            ////ddlParticipanteReglas.Items.Insert(0, "SELECCIONAR");
            //EntidadSp vEntidad = new EntidadSp();
            //vEntidad._NombreSP = "PR_GET_PARTICIPANTES_REALES";

            //List<SqlParameter> vLista = new List<SqlParameter>();
            //vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoParticipante2.SelectedValue });
            //vEntidad._Parametros = vLista;

            //cORM vOrm = new cORM("DbAmaszonas");
            //cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            //if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            //{
            //    if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
            //    {
            //        foreach (DataRow dr in vRespuesta._Tabla.Rows)
            //        {
            //            ListItem miItem = new ListItem();
            //            ListEditItem miItem2 = new ListEditItem();
            //            string nombre = "";
            //            string codigo = "";
            //            if (String.IsNullOrEmpty(dr["NOMBRE_RAZON_SOCIAL"].ToString()))
            //                nombre = "";
            //            else
            //                nombre = dr["NOMBRE_RAZON_SOCIAL"].ToString();
            //            if (String.IsNullOrEmpty(dr["COD_PARTICIPANTE"].ToString()))
            //                codigo = "";
            //            else
            //                codigo = dr["COD_PARTICIPANTE"].ToString();
            //            miItem.Text = nombre;
            //            miItem.Value = codigo;

            //            miItem2.Text = nombre;
            //            miItem2.Value = codigo;
            //            //cblParticipantes.Items.Add(miItem);
            //            //ddlParticipantes.Items.Add(miItem);
            //            ddlParticipantes.Items.Add(miItem2);
            //        }
            //    }
            //    else
            //    {
            //        ddlParticipantes.SelectedIndex = -1;
            //        ddlParticipantes.Caption = "";
            //    }

            //}
        }
        private void _Limpiar()
        {
            _EsNuevo = true;
            this.txtCodComunicado.Text = String.Empty;
            this.txtDenominacion.Text = String.Empty;
            this.txtDescripcion.Text = String.Empty;
            this.lblCodigo.Text = String.Empty;
            dtFechaDesde.Dispose();
            dtFechaHasta.Dispose();

        }
        protected void ddlTipoParticipante2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CargarParticipantesCombo();

        }
        private void _ActualizarNotificacion()
        {
            if (txtCodComunicado.Text == "")
                _EsNuevo = true;
            else
                _EsNuevo = false;
            //string detalle = "";
            StringBuilder vMensaje = new StringBuilder();
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                vMensaje.Append("La Desdeciption no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(this.txtDenominacion.Text))
            {
                vMensaje.Append("La denominacion no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(this.dtFechaDesde.Date.ToString()))
            {
                vMensaje.Append("La fecha desde no puede ser vacio </br>");
            }
            if (string.IsNullOrEmpty(this.dtFechaHasta.Date.ToString()))
            {
                vMensaje.Append("La fecha hasta no puede ser vacio </br>");
            }
            


            string vMensajeValidacion = vMensaje.ToString();
            if (!string.IsNullOrEmpty(vMensajeValidacion))
            {
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                return;
            }

           // detalle = WebConfigurationManager.AppSettings["repositorio"].ToString() + fuImagen.FileName;

            if (dtFechaHasta.Date == DateTime.Parse("01/01/0001"))
                dtFechaHasta.Date = DateTime.Parse("01/01/3000");
            if (dtFechaDesde.Date == DateTime.Parse("01/01/0001"))
                dtFechaDesde.Date = DateTime.Parse("01/01/3000");

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "ABM_COMUNICADO";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = _EsNuevo ? "I" : "U" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_ID_COMUNICADO", Direction = System.Data.ParameterDirection.Input, Value = txtCodComunicado.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoParticipante2.SelectedValue });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DENOMINACION", Direction = System.Data.ParameterDirection.Input, Value = txtDenominacion.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcion.Text });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = dtFechaDesde.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = dtFechaHasta.Date });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO_REG", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {

                _Limpiar();
                _CargarDgNotificaciones();
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Exito);

                
            }
            else
            {
                ShowMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
                ShowNotifyMessage(vRespuesta._Mensaje, eTipoRespuesta.Advertencia);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                _ActualizarNotificacion();
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
                _CargarTipoParticipantesCombo();
                _CargarParticipantesCombo();
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

                string _CodComunicado = e.CommandArgument.ToString();
                lblCodigo.Text = e.CommandArgument.ToString();

                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "PR_GET_COMUNICADOS";

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

                if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
                {

                    foreach (DataRow vfila in vRespuesta._Tabla.Rows)
                    {
                        if (vfila["ID_COMUNICADO"].ToString() == _CodComunicado)
                        {

                            this.txtCodComunicado.Text = _CodComunicado;
                            this.txtDenominacion.Text = vfila["denominacion"].ToString();
                            this.txtDescripcion.Text = vfila["descripcion"].ToString();

                            if (String.IsNullOrEmpty(vfila["fecha_hasta"].ToString()))
                                dtFechaHasta.Value = String.Empty;
                            else
                                this.dtFechaHasta.Date = DateTime.Parse(vfila["fecha_hasta"].ToString());

                            if (String.IsNullOrEmpty(vfila["fecha_desde"].ToString()))
                                dtFechaDesde.Value = String.Empty;
                            else
                                this.dtFechaDesde.Date = DateTime.Parse(vfila["fecha_desde"].ToString());

                            this.rbtnEstado.SelectedIndex = vfila["estado"].ToString() == "A" ? 0 : 1;

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

        protected void rbtnEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigo.Text == "")
                { ShowNotifyMessage("Debe seleccionar un registro!", eTipoRespuesta.Advertencia); }
                else
                {
                    EntidadSp vEntidad = new EntidadSp();
                    vEntidad._NombreSP = "ABM_COMUNICADO";
                    List<SqlParameter> vLista = new List<SqlParameter>();

                    vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = rbtnEstado.SelectedItem.Value.ToString() });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_ID_COMUNICADO", Direction = System.Data.ParameterDirection.Input, Value = txtCodComunicado.Text });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoParticipante2.SelectedValue });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_DENOMINACION", Direction = System.Data.ParameterDirection.Input, Value = txtDenominacion.Text });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = txtDescripcion.Text });
                    vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = dtFechaDesde.Date });
                    vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = dtFechaHasta.Date });
                    vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO_REG", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

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

                        _CargarDgNotificaciones();
                        _EsNuevo = true;
                        this.lblCodigo.Text = "";
                        ////////CODIGO UPLOAD
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

       

        protected void rbDgEstado_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (rbDgEstado.SelectedItem.Value.ToString().ToUpper() == "TODOS")
                dgComunicados.FilterExpression = "ESTADO='A' OR ESTADO='I'";
            if (rbDgEstado.SelectedItem.Value.ToString().ToUpper() == "ACTIVO")
                dgComunicados.FilterExpression = "ESTADO='A'";
            if (rbDgEstado.SelectedItem.Value.ToString().ToUpper() == "INACTIVO")
                dgComunicados.FilterExpression = "ESTADO='I'";
        }
    }
}