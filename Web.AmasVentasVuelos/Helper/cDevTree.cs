using DevExpress.Web.ASPxTreeList;
using System.Collections.Generic;
using System.Data;

namespace Web.AmasVentasVuelos.Helper
{
    public class cDevTree
    {
        public void _Formato(ASPxTreeList pASPxTreeList)
        {
            pASPxTreeList.SettingsPager.PageSize = 15;
            pASPxTreeList.EnableCallbackAnimation = true;
            //pASPxTreeList.SettingsBehavior.AllowFocusedNode = true;
            pASPxTreeList.SettingsPager.Mode = TreeListPagerMode.ShowPager;
            pASPxTreeList.SettingsPager.EnableAdaptivity = true;
            pASPxTreeList.SettingsPager.NumericButtonCount = 15;
            pASPxTreeList.SettingsPager.PageSizeItemSettings.ShowAllItem = true;
            pASPxTreeList.SettingsPager.PageSizeItemSettings.Visible = true;

            pASPxTreeList.SettingsLoadingPanel.Text = "Cargando...";
            pASPxTreeList.KeyboardSupport = true;
            pASPxTreeList.SettingsBehavior.AllowDragDrop = false;            
        }

        public void _CargarDatos(ASPxTreeList pASPxTreeList, DataTable pTabla, string pId, string pRecursivo)
        {            
            pASPxTreeList.DataSource = pTabla;
            pASPxTreeList.KeyFieldName = pId;
            pASPxTreeList.ParentFieldName = pRecursivo;
            pASPxTreeList.DataBind();
        }

        public void _CargarDatosLista(ASPxTreeList pASPxTreeList, List<object> pLista, string pId, string pRecursivo)
        {
            pASPxTreeList.DataSource = pLista;
            pASPxTreeList.KeyFieldName = pId;
            pASPxTreeList.ParentFieldName = pRecursivo;
            pASPxTreeList.DataBind();
        }
    }
}
