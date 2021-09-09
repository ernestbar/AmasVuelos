using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Web.AmasVentasVuelos.Helper
{
    public class cDevComboBox
    {
        public bool _ValidaCombos(params object[] pCombos)
        {
            bool vBandera = true;
            foreach (var item in pCombos)
            {
                switch (item.GetType().Name)
                {
                    case "DropDownList":
                        if ((item as DropDownList).SelectedItem != null)
                        {
                            if ((item as DropDownList).SelectedValue != "0")
                            {
                                vBandera = true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "ASPxComboBox":
                        //if ((item as ASPxComboBox).SelectedItem != null  || (item as ASPxComboBox).Value.ToString() != Resources.Messages.SelectIndex_1)                            
                        if ((item as ASPxComboBox).SelectedItem != null)
                        {

                            if ((item as ASPxComboBox).Value!=null)
                            {

                                if ((item as ASPxComboBox).Value.ToString() == "-1")
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }


                        }
                        else if ((item as ASPxComboBox).Value != null)
                        {
                            if ((item as ASPxComboBox).Value.ToString() == "-1")
                            {
                                return false;
                            }

                        }
                        else
                        {
                            return false;
                        }
                        break;

                }
            }

            return vBandera;
        }


        public void _CargarComboBox(ASPxComboBox pASPxComboBox, DataTable pTabla, string pId, string pCampo)
        {
            pASPxComboBox.EnableAnimation = false;
            pASPxComboBox.Items.Clear();
            //pASPxComboBox.CallbackPageSize = 30;
            //pASPxComboBox.EnableCallbackMode = true;            
            pASPxComboBox.Text = string.Empty;
            pASPxComboBox.Items.Insert(0, new ListEditItem("SELECCIONE UN REGISTRO", -1));
            pASPxComboBox.DataSource = pTabla;
            pASPxComboBox.ValueField = pId;
            pASPxComboBox.TextField = pCampo;
            pASPxComboBox.DataBind();
            if (pTabla.Rows.Count == 1)
            {
                pASPxComboBox.Items[0].Selected = true;
                //pASPxComboBox.Enabled = false;
            }
        }
    }
}