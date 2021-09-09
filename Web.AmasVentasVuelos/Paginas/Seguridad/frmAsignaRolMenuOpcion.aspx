<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmAsignaRolMenuOpcion.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Seguridad.frmAsignaRolMenuOpcion" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div class="page-wrapper">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h5 class="m-b-10">Asignación de roles, menu y opciones</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Seguridad</a></li>
                            <li class="breadcrumb-item"><a href="#!">Asignaciones</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->
        <div class="row">
            <div class="col-md-12">

                <dx:ASPxTabControl ID="ASPxTabControl1" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="ASPxTabControl1_ActiveTabChanged" Theme="MetropolisBlue" Width="100%">
                    <Tabs>
                        <dx:Tab Name="Asigna Rol => Menu" Text="Asigna Rol   =>   Menu">
                        </dx:Tab>
                        <dx:Tab Name="Asigna Rol, Menu => Opcion" Text="Asigna Rol, Menu   =>   Opción">
                        </dx:Tab>
                    </Tabs>
                    <ActiveTabStyle BackColor="#2CA961" ForeColor="White">
                    </ActiveTabStyle>
                </dx:ASPxTabControl>

                <asp:MultiView ID="mv" runat="server">
                    <asp:View ID="PorRolMenu" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">BUSQUEDA DE ROLES</i></h4>
                                    </div>
                                    <div class="card-body">
                                        <label for="exampleInputEmail1">Rol </label>
                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                            </div>
                                            <dx:ASPxComboBox ID="ddlRoles" runat="server" CssClass="form-control" EnableTheming="False" LoadDropDownOnDemand="True" AutoPostBack="True" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged">
                                                <DropDownButton Visible="False">
                                                </DropDownButton>
                                            </dx:ASPxComboBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">DISPONIBLES</i></h4>
                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgDisponiblesRolMenu" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="menu" EnableCallbackCompression="False" EnableCallBacks="False" OnSelectionChanged="dgDisponiblesRolMenu_SelectionChanged">
                                            <SettingsBehavior AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="MENU" FieldName="nombre_menu" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>

                            </div>
                            <div class="col-sm-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">ASIGNADOS</i></h4>
                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgAsignadosRolMenu" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="menu" EnableCallbackCompression="False" EnableCallBacks="False" OnSelectionChanged="dgAsignadosRolMenu_SelectionChanged">
                                            <SettingsBehavior AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="MENU" FieldName="nombre_menu" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </asp:View>
                    <asp:View ID="PorRolMenuOpcion" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">BÚSQUEDA DE ROLES Y MENU</i></h4>

                                    </div>
                                    <div class="card-body">

                                        <label for="exampleInputEmail1">Rol y menu </label>

                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                            </div>
                                            <dx:ASPxComboBox ID="ddlRolMenu" runat="server" CssClass="form-control" EnableTheming="False" LoadDropDownOnDemand="True" AutoPostBack="True" OnSelectedIndexChanged="ddlRolMenu_SelectedIndexChanged">
                                                <DropDownButton Visible="False">
                                                </DropDownButton>
                                            </dx:ASPxComboBox>
                                        </div>
                                    </div>
                                </div>


                            </div>

                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">OPCIONES DISPONIBLES</i></h4>

                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgDisponiblesRolMenuOpcion" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="menu_web_opcion" EnableCallbackCompression="False" EnableCallBacks="False" OnSelectionChanged="dgDisponiblesRolMenuOpcion_SelectionChanged">
                                            <SettingsBehavior AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="MENU" FieldName="nombre_opcion" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="cod_menu" FieldName="cod_menu" Visible="false"  VisibleIndex ="2">
                                                </dx:GridViewDataTextColumn>

                                                
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>

                            </div>
                            <div class="col-sm-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">OPCIONES QUE SE DENEGARAN ACCESO</i></h4>
                                       
                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgAsignadosRolMenuOpcion" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="menu_web_opcion" EnableCallbackCompression="False" EnableCallBacks="False" OnSelectionChanged="dgAsignadosRolMenuOpcion_SelectionChanged">
                                            <SettingsBehavior AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="MENU" FieldName="nombre_opcion" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                        <br />
                                         <blockquote class="blockquote">
											<p  class="text-danger mb-2">Las opciones que se encuentren marcadas dentro del menu serán las que no se tendra el acceso el usuario.</p>
											
										</blockquote>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
        <!-- [ Main Content ] end -->
    </div>
    <dx:ASPxHiddenField ID="hfAsingaRolMenuWebOpcion" runat="server"></dx:ASPxHiddenField>
                                </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
