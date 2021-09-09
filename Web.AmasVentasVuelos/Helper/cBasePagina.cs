

using prySqlServer;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.AmasVentasVuelos.Helper
{
    public class cBasePagina : Page

    {
        protected override void OnPreInit(EventArgs e)
        {

            base.OnPreInit(e);
        }

        /// <summary>
        /// Metodo para mostrar el mensaje en blanco
        /// </summary>
        public void ShowMessage()
        {
            cGestorSession.PutValue("GrlMessage", "");
            cGestorSession.PutValue("GrlMessageType", "");

        }

        /// <summary>
        /// Despliega el mensaje en base a los parametros.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pMessageType"></param>
        public void ShowMessage(string pMessage, eTipoRespuesta pMessageType)
        {
            cGestorSession.PutValue("GrlMessage", pMessage);
            cGestorSession.PutValue("GrlMessageType", pMessageType);
        }



        /// <summary>
        /// Despliega el mensaje en base a los parametros.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pMessageType"></param>
        public void ShowMessage(string pMessage, eTipoRespuesta pMessageType, Literal pLiteral)
        {
            cGestorSession.PutValue("GrlMessage", pMessage);
            cGestorSession.PutValue("GrlMessageType", pMessageType);
            if (pMessageType != eTipoRespuesta.SinDatos)
            {
                System.Text.StringBuilder vBuilder = new System.Text.StringBuilder();
                vBuilder.Append(@"<div class=""row"">");
                vBuilder.Append(@"<div class=""col-md-12"">");
                switch (pMessageType)
                {
                    case eTipoRespuesta.Exito:
                        vBuilder.Append(@"<div class=""alert alert-success alert-dismissable"">");
                        break;
                    case eTipoRespuesta.Error:
                        vBuilder.Append(@"<div class=""alert alert-error alert-dismissable""> ");
                        break;
                    case eTipoRespuesta.Advertencia:
                        vBuilder.Append(@"<div class=""alert alert-warning alert-dismissable"">");
                        break;

                }

                vBuilder.Append(@"<button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">&times;</button>");
                vBuilder.Append(" ");
                vBuilder.Append(pMessage);
                vBuilder.Append("</div>");
                vBuilder.Append("</div>");
                vBuilder.Append("</div>");
                pLiteral.Text = vBuilder.ToString();
            }
        }

        public void ShowNotifyMessage(string pMessage, eTipoRespuesta pMessageType)
        {
            StringBuilder vJSQ = new StringBuilder();
            vJSQ.Append("$(document).ready(function () {    Swal.fire( ");
            switch (pMessageType)
            {
                case eTipoRespuesta.Exito:
                    vJSQ.Append("'Exito!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'success'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                case eTipoRespuesta.SinDatos:
                    vJSQ.Append("'Sin datos!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'question'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                case eTipoRespuesta.Advertencia:
                    vJSQ.Append("'Advertencia!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'warning'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                case eTipoRespuesta.Error:
                    vJSQ.Append("'Error!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'error'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                default:
                    break;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), vJSQ.ToString(), true);
        }
    }


    public class cBaseUserControl : System.Web.UI.UserControl

    {
        

        /// <summary>
        /// Metodo para mostrar el mensaje en blanco
        /// </summary>
        public void ShowMessage()
        {
            cGestorSession.PutValue("GrlMessage", "");
            cGestorSession.PutValue("GrlMessageType", "");

        }

        /// <summary>
        /// Despliega el mensaje en base a los parametros.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pMessageType"></param>
        public void ShowMessage(string pMessage, eTipoRespuesta pMessageType)
        {
            cGestorSession.PutValue("GrlMessage", pMessage);
            cGestorSession.PutValue("GrlMessageType", pMessageType);
        }



        /// <summary>
        /// Despliega el mensaje en base a los parametros.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pMessageType"></param>
        public void ShowMessage(string pMessage, eTipoRespuesta pMessageType, Literal pLiteral)
        {
            cGestorSession.PutValue("GrlMessage", pMessage);
            cGestorSession.PutValue("GrlMessageType", pMessageType);
            if (pMessageType != eTipoRespuesta.SinDatos)
            {
                System.Text.StringBuilder vBuilder = new System.Text.StringBuilder();
                vBuilder.Append(@"<div class=""row"">");
                vBuilder.Append(@"<div class=""col-md-12"">");
                switch (pMessageType)
                {
                    case eTipoRespuesta.Exito:
                        vBuilder.Append(@"<div class=""alert alert-success alert-dismissable"">");
                        break;
                    case eTipoRespuesta.Error:
                        vBuilder.Append(@"<div class=""alert alert-error alert-dismissable""> ");
                        break;
                    case eTipoRespuesta.Advertencia:
                        vBuilder.Append(@"<div class=""alert alert-warning alert-dismissable"">");
                        break;

                }

                vBuilder.Append(@"<button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">&times;</button>");
                vBuilder.Append(" ");
                vBuilder.Append(pMessage);
                vBuilder.Append("</div>");
                vBuilder.Append("</div>");
                vBuilder.Append("</div>");
                pLiteral.Text = vBuilder.ToString();
            }
        }

        public void ShowNotifyMessage(string pMessage, eTipoRespuesta pMessageType)
        {
            StringBuilder vJSQ = new StringBuilder();
            vJSQ.Append("$(document).ready(function () {    Swal.fire( ");
            switch (pMessageType)
            {
                case eTipoRespuesta.Exito:
                    vJSQ.Append("'Exito!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'success'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                case eTipoRespuesta.SinDatos:
                    vJSQ.Append("'Sin datos!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'question'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                case eTipoRespuesta.Advertencia:
                    vJSQ.Append("'Advertencia!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'warning'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                case eTipoRespuesta.Error:
                    vJSQ.Append("'Error!' , ");
                    vJSQ.Append("'" + pMessage + "',");
                    vJSQ.Append("'error'");
                    vJSQ.Append(");");
                    vJSQ.Append("});");
                    vJSQ.Append("");
                    break;
                default:
                    break;
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), vJSQ.ToString(), true);


        }





    }
}