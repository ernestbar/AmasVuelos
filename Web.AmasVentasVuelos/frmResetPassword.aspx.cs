using prySqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos
{
    public partial class frmResetPassword : cBasePagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _exito.Visible = false;
            _error.Visible = false;
            this.btnVolver.OnClientClick = "javascript:window.history.go(-1);return false;";
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void btnCambiarContrasenia_Click(object sender, EventArgs e)
        {
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_ABM_USUARIO";
            List<SqlParameter> vLista = new List<SqlParameter>();

            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "R" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIOI", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario").ToString() });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_PASSWORD_ANTERIOR", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_DESCRIPCION", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_DESDE", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PD_FECHA_HASTA", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_ROL", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = "" });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_PADRE", Direction = System.Data.ParameterDirection.Input, Value = ""});
            vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = cGestorSession.GetValue("usuario").ToString() });
            SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
            vLista.Add(paramError);

            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                _exito.Visible = true;
                _error.Visible = false;
                string vMensajeValidacion = "Se cambio la contraseña satisfactoriamente, en 5 segundos volvera a la página de inicio.";
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "5;url=frmLogin.aspx";
                this.Page.Controls.Add(meta);
                lblExito.Text = vRespuesta._Mensaje + "</br> " + vMensajeValidacion;
            }
            else
            {
                _exito.Visible = false;
                _error.Visible = true;
                string vMensajeValidacion = vRespuesta._Mensaje;
                lblError.Text = vMensajeValidacion;
                ShowNotifyMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
                ShowMessage(vMensajeValidacion, eTipoRespuesta.Advertencia);
            }
        }
    }
}