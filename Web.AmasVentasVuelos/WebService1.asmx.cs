using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using System.Data;
using prySqlServer;

namespace Web.AmasVentasVuelos
{
    /// <summary>
    /// Descripción breve de Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES_REALES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                foreach (DataRow dr in vRespuesta._Tabla.Rows)
                {
                    string nombre = "";
                    string codigo = "";
                    if (String.IsNullOrEmpty(dr["NOMBRE_RAZON_SOCIAL"].ToString()))
                        nombre = "";
                    else
                        nombre = dr["NOMBRE_RAZON_SOCIAL"].ToString();
                    if (String.IsNullOrEmpty(dr["COD_PARTICIPANTE"].ToString()))
                        codigo = "";
                    else
                        codigo = dr["COD_PARTICIPANTE"].ToString();
                    customers.Add(string.Format("{0}|{1}", nombre, codigo));
                }
            }
            return customers.ToArray();
        }
    }
}
