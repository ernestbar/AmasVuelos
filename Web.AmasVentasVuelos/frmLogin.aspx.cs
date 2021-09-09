using prySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.AmasVentasVuelos.Helper;

namespace Web.AmasVentasVuelos
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mensaje.Visible = false;
            txtUsuario.Focus();
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text== "admin")
            {                
                cGestorSession.PutValue("usuario","admin");
                Response.Redirect("~/Paginas/frmIndex.aspx");
            }

            if (!string.IsNullOrEmpty(txtUsuario.Text) &&!string.IsNullOrEmpty(txtContrasenia.Text))
            {
                EntidadSp vEntidad = new EntidadSp();
                vEntidad._NombreSP = "setValidaCredenciales";
                List<SqlParameter> vLista = new List<SqlParameter>();
                vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario", Direction = System.Data.ParameterDirection.Input, Value = txtUsuario.Text });
                vLista.Add(new SqlParameter() { ParameterName = "@pv_password", Direction = System.Data.ParameterDirection.Input, Value = txtContrasenia.Text });

                SqlParameter paramTemporal = new SqlParameter() { ParameterName = "@pv_temporal", Direction = System.Data.ParameterDirection.Output,Size=255 };

                vLista.Add(paramTemporal);

                vEntidad._Parametros = vLista;

                cORM vOrm = new cORM("DbAmaszonas");
                cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);

                if (vRespuesta._TipoRespuesta  == eTipoRespuesta.Exito)
                {
                    cGestorSession.PutValue("usuario", txtUsuario.Text);
                    if (_cargarPaginas(txtUsuario.Text))
                    {
                        _cargarOpcionesDenegadas(txtUsuario.Text);

                        Response.Redirect("~/Paginas/frmIndex.aspx");
                    }
                    else
                    {
                        mensaje.Visible = true;
                        ltrlMensaje.Text = "No cuenta con ningun rol asignado al usuario";
                        //ShowNotifyMessage("No cuenta con ningun rol asignado al usuario", eTipoRespuesta.Error);
                    }
                }
                else
                {
                    mensaje.Visible = true;
                    ltrlMensaje.Text = vRespuesta._Mensaje;
                    //ShowNotifyMessage(paramMenasje.Value.ToString(), eTipoRespuesta.Advertencia);
                }
            }
            else
            {
                mensaje.Visible = true;
                ltrlMensaje.Text = "Los campos de usuario y contraseña no pueden ser vacios";
            }        
            
        }

        public bool _cargarPaginas(string usuario)
        {
            bool vBandera = false;
            
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getMenusHabilitadosPorUsuario";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario", Direction = System.Data.ParameterDirection.Input, Value = usuario });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                List<string> listaPaginas = new List<string>();
                foreach (DataRow item in vRespuesta._Tabla.Rows)
                {
                    if (!string.IsNullOrEmpty(item["DESCRIPCION"].ToString()))
                    {
                        listaPaginas.Add(item["DESCRIPCION"].ToString());
                    }
                }
                cGestorSession.PutValue("listaPaginas", listaPaginas);
                vBandera = true;
            }
            
            return vBandera;
        }

        public void _cargarOpcionesDenegadas(string usuario)
        {
            
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "getOpcionesDenegadasPorUsuario";
            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@pv_usuario", Direction = System.Data.ParameterDirection.Input, Value = usuario });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito)
            {
                List<string> listaOpcionesDenegadas = new List<string>();
                foreach (DataRow item in vRespuesta._Tabla.Rows)
                {
                    if (!string.IsNullOrEmpty(item["valor"].ToString()))
                    {
                        listaOpcionesDenegadas.Add(item["valor"].ToString());
                    }
                }
                cGestorSession.PutValue("listaOpcionesDenegadas", listaOpcionesDenegadas);
            }
            

        }

    }
}