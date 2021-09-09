using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos.Controles
{

    public partial class ucPolicy : System.Web.UI.UserControl
    {
        public void RecControles(Control control, string pDato)
        {
            //Recorremos con un ciclo for each cada control que hay en la colección Controls
            foreach (Control contHijo in control.Controls)
            {
                //Preguntamos si el control tiene uno o mas controles dentro del mismo con la propiedad 'HasChildren'
                //Si el control tiene 1 o más controles, entonces llamamos al procedimiento de forma recursiva, para que siga recorriendo los demás controles 
                if (contHijo.HasControls())
                {
                    this.RecControles(contHijo, pDato);
                }
                //Aqui va la lógica de lo queramos hacer, en mi ejemplo, voy a pintar de color azul el fondo de todos los controles
                /*
                   Control v = contHijo.FindControl(pDato);
                   if (v != null)
                   {
                       v.Visible = false;
                   }
                   */
                (cGestorSession.GetValue("lista") as List<string>).Add(contHijo.ClientID + "|||");

            }
        }


        //public static void EscribeEnArchivo(string contenido, string rutaArchivo)
        //{
        //    StreamWriter sw = new StreamWriter(rutaArchivo, false);
        //    sw.WriteLine(contenido);
        //    sw.Close();
        //}

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (cGestorSession.GetValue("usuario") == null)
                {
                    Response.Redirect("~/frmlogin.aspx");
                }

                if (cGestorSession.CurrrentPage == "frmIndex.aspx")
                {
                    return;
                }

                List<string> listaPaginas = cGestorSession.GetValue("listaPaginas") as List<string>;
                if (listaPaginas.Count <= 0)
                {
                    Response.Redirect("~/frmAccesoNoAutorizado.aspx");
                }
                else
                {
                    string pagina = cGestorSession.CurrrentPage;

                    List<string> existe = listaPaginas.Where(x => x.Contains(pagina.ToUpper())).ToList();
                    if (existe.Count <= 0)
                    {
                        Response.Redirect("~/frmAccesoNoAutorizado.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}