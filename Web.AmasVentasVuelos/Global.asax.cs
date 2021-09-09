using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                cGestorSession.DestroySession();
                HttpContext context = HttpContext.Current;
                context.Response.Redirect("frmLogin.aspx");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            cGestorSession.DestroySession();
            HttpContext context = HttpContext.Current;
            context.Response.Redirect("frmLogin.aspx");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            cGestorSession.DestroySession();
        }
    }
}