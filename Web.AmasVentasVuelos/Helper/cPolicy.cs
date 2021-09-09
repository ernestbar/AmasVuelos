using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.AmasVentasVuelos.Helper
{
    public class cPolicy
    {
        public bool Acceso(string pagina,string componente)
        {
            return false;
            /*
            string vPagina = pagina;      
            List<string> listaControles = cGestorSession.GetValue("listaOpcionesDenegadas") as List<string>;
            List<string> filtroPagina = listaControles.Where(x => x.Contains(vPagina)).ToList();
            List<string> filtroComponente = filtroPagina.Where(x => x.Contains(componente)).ToList();

            return filtroComponente.Count>0? true:false;
            */
        }
    }
}