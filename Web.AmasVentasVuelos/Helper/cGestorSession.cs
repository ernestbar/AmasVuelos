using System;
using System.Linq;
using System.Web;

namespace Web.AmasVentasVuelos.Helper
{
    [Serializable]
    public class DatosUsuario
    {
        public string _IdUsuario { get; set; }
        public string _Usuario { get; set; }
        public DateTime _FechaIngreso { get; set; }
        public string _Nombres { get; set; }
        public string _Apellidos { get; set; }
        public string _NombreCompleto { get; set; }
        public string _Correo { get; set; }
        public string _Cargo { get; set; }
        public string _Carnet { get; set; }
        public string _Sexo { get; set; }
        public string _Foto { get; set; }
        public string _Telefono { get; set; }        
    }

    public class cGestorSession
    {
        public static DatosUsuario _DatosUsuario
        {
            get { return (DatosUsuario)GetValue("_DatosUsuario"); }
            set { PutValue("_DatosUsuario", value); }
        }
        public static String CurrrentPage
        {
            get
            {
                return HttpContext.Current.Request.Path.Split('/').LastOrDefault();
            }
        }
        public static string Terminal
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
            }
        }
        public static string Explorador
        {
            get
            {
                return HttpContext.Current.Request.Browser.Browser;
            }
        }
        public static string IP
        {
            get
            {
                string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipList))
                {
                    return ipList.Split(',')[0];
                }

                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
        }
        /// <summary>
        /// Ingresa un valor a la session
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Valor</param>
        public static void PutValue(string key, Object value)
        {
            //HttpContext context = HttpContext.Current;
            //SessionStateUtility.GetHttpSessionStateFromContext(context)[key] = value;

            HttpContext context = HttpContext.Current;
            context.Session[key] = value;


        }

        /// <summary>
        /// Obtiene un valor de la session
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public static Object GetValue(string key)
        {
            //HttpContext context = HttpContext.Current;
            //return SessionStateUtility.GetHttpSessionStateFromContext(context)[key];

            HttpContext context = HttpContext.Current;
            return context.Session[key];
        }

        /// <summary>
        /// Destruye la session
        /// </summary>
        public static void DestroySession()
        {
            //HttpContext context = HttpContext.Current;
            //SessionStateUtility.GetHttpSessionStateFromContext(context).Abandon();
            HttpContext context = HttpContext.Current;
            context.Session.Abandon();
        }
        public static void DestroyValue(string key)
        {
            //HttpContext context = HttpContext.Current;
            //return SessionStateUtility.GetHttpSessionStateFromContext(context)[key];

            HttpContext context = HttpContext.Current;
            context.Session.Remove(key);
        }
    }
}