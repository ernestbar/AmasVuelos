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
    public partial class frmAsignacionReglasBackEnd : cBasePagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _CargarReglas();
                _CargarParticipantes();
                _CargarParticipantesCombo();
                _CargarTipoParticipantesCombo();
            }
        }
        private void _CargarReglas()
        {
            cblReglas.Items.Clear();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_BACKEND_ASIGNAR";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                foreach (DataRow dr in vRespuesta._Tabla.Rows)
                {
                    ListItem miItem = new ListItem();
                    miItem.Text = dr["REGLA"].ToString();
                    miItem.Value = dr["cod_BACKEND"].ToString();
                    cblReglas.Items.Add(miItem);
                }
            }
        }
        private void _CargarParticipantes()
        {
            cblParticipantes.Items.Clear();
            //ddlParticipantes.Items.Clear();

            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES_REALES";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoParticipante.SelectedValue });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
                {
                    foreach (DataRow dr in vRespuesta._Tabla.Rows)
                    {
                        ListItem miItem = new ListItem();
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
                        miItem.Text = nombre;
                        miItem.Value = codigo;
                        cblParticipantes.Items.Add(miItem);
                        //ddlParticipantes.Items.Add(miItem);
                    }
                }
                
            }
        }
        private void _CargarParticipantesCombo()
        {
            //cblParticipantes.Items.Clear();
            
            //ddlParticipanteReglas.Dispose();
            
            ddlParticipanteReglas.Items.Clear();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES_BACKEND_OK";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlTipoParticipante2.SelectedValue });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
                {
                    foreach (DataRow dr in vRespuesta._Tabla.Rows)
                    {
                        ListItem miItem = new ListItem();
                        ListEditItem miItem2 = new ListEditItem();
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
                        miItem.Text = nombre;
                        miItem.Value = codigo;

                        miItem2.Text = nombre;
                        miItem2.Value = codigo;
                        //cblParticipantes.Items.Add(miItem);
                        //ddlParticipantes.Items.Add(miItem);
                        ddlParticipanteReglas.Items.Add(miItem2);

                    }

                }
                else
                {
                    ddlParticipanteReglas.SelectedIndex = -1;
                    ddlParticipanteReglas.Caption="";
                }
                
            }
        }

        private void _CargarTipoParticipantesCombo()
        {
            //cblParticipantes.Items.Clear();
            ddlTipoParticipante.Items.Clear();
            ddlTipoParticipante.Items.Insert(0, "SELECCIONAR");

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
                    ddlTipoParticipante.Items.Add(miItem);

                    ddlTipoParticipante2.Items.Add(miItem);
                }
            }
        }
        private void _CargarParticipantesNombre(string Nombre,string tipo)
        {
            cblParticipantes.Items.Clear();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_PARTICIPANTES_REALES_DINAMICOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_NOMBRE_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
            vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = tipo });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
                {
                    foreach (DataRow dr in vRespuesta._Tabla.Rows)
                    {
                        ListItem miItem = new ListItem();
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
                        miItem.Text = nombre;
                        miItem.Value = codigo;
                        cblParticipantes.Items.Add(miItem);
                    }

                }
                
            }
        }

        private void _CargarReglasNombre(string Nombre)
        {
            cblReglas.Items.Clear();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_BACKEND_ASIGNAR_DINAMICO";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@pv_regla", Direction = System.Data.ParameterDirection.Input, Value = Nombre });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {
                if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
                {
                    foreach (DataRow dr in vRespuesta._Tabla.Rows)
                    {
                        ListItem miItem = new ListItem();
                        miItem.Text = dr["REGLA"].ToString();
                        miItem.Value = dr["cod_backend"].ToString();
                        cblReglas.Items.Add(miItem);
                    }
                }
                  
            }
        }

        private void _CargarReglasParticipante(string Cod_participante)
        {
            cblReglasAsigandas.Items.Clear();
            EntidadSp vEntidad = new EntidadSp();
            vEntidad._NombreSP = "PR_GET_BACKEND_ASIGNADOS";

            List<SqlParameter> vLista = new List<SqlParameter>();
            vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = Cod_participante });
            vEntidad._Parametros = vLista;

            cORM vOrm = new cORM("DbAmaszonas");
            cRespuestaLista vRespuesta = vOrm._ConsultaSP(vEntidad);

            if (vRespuesta._TipoRespuesta == eTipoRespuesta.Exito || vRespuesta._TipoRespuesta == eTipoRespuesta.SinDatos)
            {

                if (vRespuesta._TipoRespuesta.ToString().ToUpper() != "SINDATOS")
                {
                    foreach (DataRow dr in vRespuesta._Tabla.Rows)
                    {
                        ListItem miItem = new ListItem();
                        miItem.Text = dr["REGLA"].ToString();
                        miItem.Value = dr["COD_PARTICIPANTE_BACKEND"].ToString();
                        miItem.Selected = true;
                        cblReglasAsigandas.Items.Add(miItem);
                    }
                }

            }
        }


        protected void lbtnBuscaarParticipante_Click(object sender, EventArgs e)
        {
            _CargarParticipantesNombre(txtBuscarParticipante.Text,ddlTipoParticipante.SelectedValue);
        }

        protected void lbtnAsignar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            if (cblReglas.SelectedIndex == -1)
            { lblAvisoReglas.Text = "* Seleccione al menos una regla."; }
            else
            {
                if (cblParticipantes.SelectedIndex == -1)
                { lblAvisoParticipante.Text = "* Seleccione al menos un participante."; }
                else
                {
                    foreach (ListItem regla in cblReglas.Items)
                    {
                        if (regla.Selected == true)
                        {
                            foreach (ListItem participante in cblParticipantes.Items)
                            {
                                if (participante.Selected == true)
                                {
                                    EntidadSp vEntidad = new EntidadSp();
                                    vEntidad._NombreSP = "PR_ABM_PARTICIPANTE_BACKEND";
                                    List<SqlParameter> vLista = new List<SqlParameter>();


                                    vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "I" });
                                    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = "" });
                                    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = regla.Value });
                                    vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = participante.Value });
                                    vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                                    SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                                    vLista.Add(paramError);
                                    vEntidad._Parametros = vLista;

                                    cORM vOrm = new cORM("DbAmaszonas");
                                    cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
                                    respuesta = vRespuesta._Mensaje;
                                }

                            }
                        }
                    }
                    ShowNotifyMessage(respuesta, eTipoRespuesta.Exito);

                }
            }
        }

        protected void btnBucsarRegla_Click(object sender, EventArgs e)
        {

            _CargarReglasNombre(txtBuscarRegla.Text);
        }



        //protected void ddlParticipantes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _CargarReglasParticipante(ddlParticipantes.SelectedValue);
        //}

        protected void btnQuiarReglaParticipante_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            if (cblReglasAsigandas.Items.Count > 0)
            {
                foreach (ListItem reglas in cblReglasAsigandas.Items)
                {
                    if (reglas.Selected == false)
                    {
                        EntidadSp vEntidad = new EntidadSp();
                        vEntidad._NombreSP = "PR_ABM_PARTICIPANTE_BACKEND";
                        List<SqlParameter> vLista = new List<SqlParameter>();


                        vLista.Add(new SqlParameter() { ParameterName = "@PV_TIPO_OPERACION", Direction = System.Data.ParameterDirection.Input, Value = "D" });
                        vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = reglas.Value });
                        vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_BACKEND", Direction = System.Data.ParameterDirection.Input, Value = "" });
                        vLista.Add(new SqlParameter() { ParameterName = "@PV_COD_PARTICIPANTE", Direction = System.Data.ParameterDirection.Input, Value = ddlParticipanteReglas.SelectedItem.Value.ToString() });
                        vLista.Add(new SqlParameter() { ParameterName = "@PV_USUARIO", Direction = System.Data.ParameterDirection.Input, Value = "calba" });

                        SqlParameter paramError = new SqlParameter() { ParameterName = "@PV_ERROR", Direction = System.Data.ParameterDirection.Output, Size = 300 };
                        vLista.Add(paramError);
                        vEntidad._Parametros = vLista;

                        cORM vOrm = new cORM("DbAmaszonas");
                        cRespuesta vRespuesta = vOrm._EjecutarSp(vEntidad);
                        respuesta = vRespuesta._Mensaje;
                    }

                }
                ShowNotifyMessage(respuesta, eTipoRespuesta.Exito);
            }
            else
            {
                ShowNotifyMessage("El participante no tienes reglas asignadas", eTipoRespuesta.Advertencia);
            }
            _CargarReglasParticipante(ddlParticipanteReglas.SelectedItem.Value.ToString());

        }

        protected void cbReglasTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in cblReglas.Items)
            {
                if (cbReglasTodos.Checked == true)
                    item.Selected = true;
                else
                    item.Selected = false;
            }

        }

        protected void cbParticipanteTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in cblParticipantes.Items)
            {
                if (cbParticipanteTodos.Checked == true)
                    item.Selected = true;
                else
                    item.Selected = false;
            }
        }

        protected void ddlTipoParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CargarParticipantes();
            //_CargarParticipantesCombo();
            //_CargarReglasParticipante(ddlParticipanteReglas.SelectedItem.Value.ToString());
        }
        protected void ddlParticipanteReglas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CargarReglasParticipante(ddlParticipanteReglas.SelectedItem.Value.ToString());

        }
        protected void ddlTipoParticipante2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CargarParticipantesCombo();
            //_CargarReglasParticipante(ddlParticipantes.SelectedValue);   
            if (ddlParticipanteReglas.SelectedIndex > 0)
            { _CargarReglasParticipante(ddlParticipanteReglas.SelectedItem.Value.ToString()); }
            else { cblReglasAsigandas.Items.Clear(); }
        }
    }
}