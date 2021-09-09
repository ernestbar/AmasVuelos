using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Web.AmasVentasVuelos.Helper
{
    public class cDevGrilla
    {

        public void _CargarDatos(ASPxGridView pASPxGridView,
           DataTable pLista,
           string pLllave,
           bool pExporter = true,
           bool pExportarCvs = false,           
           bool vCache = false
           )
        {
            string vCaption = pASPxGridView.Caption;
            if (!string.IsNullOrEmpty(vCaption))
            {
                String after = vCaption.Substring(0, 1).ToUpper() + vCaption.Substring(1).ToLower();
                pASPxGridView.Caption = after;
            }

            pASPxGridView.Settings.ShowFooter = true;
            pASPxGridView.Settings.ShowGroupPanel = true;
            pASPxGridView.Settings.ShowHeaderFilterButton = true;
            pASPxGridView.DataSource = pLista;
            pASPxGridView.KeyFieldName = pLllave;
            if (pLista != null)
            {
                pASPxGridView.DataBind();
                if (pExporter && pLista.Rows.Count > 0)
                {   
                }
            }
            else
            {
                pASPxGridView.DataBind();
            }
            string vFiltro = string.Empty;

            pASPxGridView.SettingsPager.Position = PagerPosition.Bottom;
            pASPxGridView.SettingsPager.PageSizeItemSettings.Visible = true;
            pASPxGridView.SettingsPager.PageSizeItemSettings.Items = new[] { "10", "20", "30", "50", "100" };


            pASPxGridView.Styles.BatchEditCell.ForeColor = Color.Black;
            pASPxGridView.Styles.BatchEditCell.BackColor = Color.LightYellow;

            pASPxGridView.Styles.BatchEditModifiedCell.ForeColor = Color.Black;
            pASPxGridView.Styles.BatchEditModifiedCell.BackColor = Color.LightYellow;

            pASPxGridView.SettingsCommandButton.UpdateButton.Styles.Native = true;
            pASPxGridView.SettingsCommandButton.UpdateButton.Styles.Style.CssClass = "btn btn-sm btn-success";
            pASPxGridView.SettingsCommandButton.UpdateButton.Text = "Actualizar";

            pASPxGridView.SettingsCommandButton.CancelButton.Styles.Native = true;
            pASPxGridView.SettingsCommandButton.CancelButton.Styles.Style.CssClass = "btn btn-sm btn-danger";
            pASPxGridView.SettingsCommandButton.CancelButton.Text = "Cancelar";



            pASPxGridView.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.HideDataCells;
            pASPxGridView.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = true;

            pASPxGridView.SettingsBehavior.EnableCustomizationWindow = true;
                                 
            _FormatoDeTexto(pASPxGridView);
        }

        public void _FormatoDeTexto(ASPxGridView pAspXGridView)
        {

            //Se adiciono el metodo para que puede enfocar la grilla cada fila
            pAspXGridView.SettingsBehavior.AllowFocusedRow = true;
            pAspXGridView.Settings.ShowFilterRow = true;
            pAspXGridView.Settings.ShowFilterRowMenu = true;

            pAspXGridView.Settings.ShowGroupPanel = true;
            pAspXGridView.Settings.ShowFooter = true;
            pAspXGridView.Settings.ShowStatusBar = GridViewStatusBarMode.Visible;
            //pAspXGridView.Settings.ShowFilterBar = GridViewStatusBarMode.Visible;
            pAspXGridView.Settings.GridLines = System.Web.UI.WebControls.GridLines.Both;
            pAspXGridView.SettingsBehavior.AllowDragDrop = true;
            //pAspXGridView.Settings.ShowFilterBar = GridViewStatusBarMode.Auto;
            pAspXGridView.Settings.ShowGroupButtons = true;
            pAspXGridView.Settings.ShowHeaderFilterButton = true;

            pAspXGridView.SettingsBehavior.AllowSort = true;
            if (!pAspXGridView.Page.IsPostBack)
            {
                pAspXGridView.FocusedRowIndex = -1;
            }
            //pAspXGridView.SettingsBehavior.AutoExpandAllGroups = true;            

            //Formato para Busqueda Contains.
            foreach (var columna in pAspXGridView.Columns)
            {
                if (columna is GridViewDataColumn)
                {
                    (columna as GridViewDataColumn).Settings.AutoFilterCondition = AutoFilterCondition.Contains;

                }
            }
        }

    }
}