<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmMenuMobileWeb.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Seguridad.frmMenuMobileWeb" %>

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
                            <h5 class="m-b-10">Menu de la Web y Mobile</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Seguridad</a></li>
                            <li class="breadcrumb-item"><a href="#!">Menu</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->

        <dx:ASPxTabControl ID="ASPxTabControl1" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="ASPxTabControl1_ActiveTabChanged" Theme="MetropolisBlue" Width="100%">
            <Tabs>
                <dx:Tab Name="Por usuario" Text="Mobile">
                </dx:Tab>
                <dx:Tab Name="Por pregunta" Text="Web">
                </dx:Tab>
            </Tabs>
            <ActiveTabStyle BackColor="#2CA961" ForeColor="White">
            </ActiveTabStyle>
        </dx:ASPxTabControl>


        <asp:MultiView ID="mv" runat="server" OnActiveViewChanged="mv_ActiveViewChanged">
            <asp:View ID="PorMobile" runat="server">
                <div class="row">
                    <div class="col-md-5">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">FORMULARIO DE REGISTRO MOBILE</i></h4>

                                    </div>
                                    <div class="card-body">
                                        <%--<h5>Form controls</h5>--%>
                                        <%--  <hr>--%>
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Es padre</label>
                                                <div class="input-group mb-2">
                                                    <dx:ASPxRadioButtonList ID="rdlEsPadreMobile" runat="server" RepeatDirection="Horizontal" SelectedIndex="0" AutoPostBack="True" OnSelectedIndexChanged="rdlEsPadreMobile_SelectedIndexChanged">
                                                        <Items>
                                                            <dx:ListEditItem Selected="True" Text="Si" Value="1" />
                                                            <dx:ListEditItem Text="No" Value="0" />
                                                        </Items>
                                                        <Border BorderStyle="None" />
                                                    </dx:ASPxRadioButtonList>
                                                </div>

                                                <div id="opcionMenuMobile" runat="server">

                                                    <label for="exampleInputEmail1">Menu padre</label>
                                                    <div class="input-group mb-2">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                        </div>
                                                        <dx:ASPxComboBox ID="ddlMenuMobile" runat="server" ValueType="System.String" Width="80%"></dx:ASPxComboBox>

                                                    </div>
                                                </div>
                                                <label for="exampleInputEmail1">Id menu</label>
                                                <div class="input-group mb-2">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                    </div>
                                                    <dx:ASPxTextBox ID="txtIdMenuMobile" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>
                                                <label for="exampleInputEmail1">Nombre del menu</label>
                                                <div class="input-group mb-2">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                    </div>
                                                    <dx:ASPxTextBox ID="txtNombreMenuMobile" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>
                                                <label for="exampleInputEmail1">Descripción del menu</label>
                                                <div class="input-group mb-2">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                    </div>
                                                    <dx:ASPxTextBox ID="txtDescripcionMenuMobile" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>

                                            </div>
                                            <div class="form-group">
                                                <asp:LinkButton ID="btnLimpiarMoble" class="btn btn-light" OnClick="btnLimpiarMoble_Click" runat="server">
                                                        LIMPIAR
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnGuardar" class="btn btn-success" OnClick="btnGuardar_Click" runat="server">
                                                        GUARDAR
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">DATOS DE LOS MENUS MOBILE</i></h4>

                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgMenuMobile" runat="server" Width="100%" AutoGenerateColumns="False">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="MENU PADRE" FieldName="menu_padre" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="NOMBRE" FieldName="nombre_menu" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="DESCRIPCION" FieldName="descripcion" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="MENU" FieldName="menu" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="ESTADO" FieldName="estado" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="DESC. ESTADO" FieldName="desc_estado" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="FECHA CREACION" FieldName="fecha_creacion" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="#" VisibleIndex="7">
                                                    <DataItemTemplate>
                                                        <div class="row">
                                                            <div class="col">
                                                                <asp:LinkButton ID="btnActivar" class="btn btn-icon btn-rounded btn-outline-success !important" runat="server" OnCommand="btnActivar_Command" CommandArgument='<%# Eval("menu")%>'>
                                                            <i class="feather icon-check"></i>                                    
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="col">
                                                                <asp:LinkButton ID="btnModificar" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificar_Command" CommandArgument='<%# Eval("menu")%>'>
                                                            <i class="feather icon-edit-2"></i>                                    
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="col">
                                                                <asp:LinkButton ID="btnEliminar" class="btn btn-icon btn-rounded btn-outline-danger !important" runat="server" OnCommand="btnEliminar_Command" CommandArgument='<%# Eval("menu")%>'>
                                                            <i class="feather icon-trash-2"></i>                                    
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </asp:View>
            <asp:View ID="PorWeb" runat="server">
                <div class="row">
                    <div class="col-md-5">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">FORMULARIO DE REGISTRO MENU WEB</i></h4>
                                    </div>
                                    <div class="card-body">
                                        <%--<h5>Form controls</h5>--%>
                                        <%--  <hr>--%>
                                        <div class="col-md-12">
                                            <div class="form-group">

                                                <label for="exampleInputEmail1">Es padre</label>
                                                <div class="input-group mb-2">

                                                    <dx:ASPxRadioButtonList ID="rdlEsPadreWeb" runat="server" RepeatDirection="Horizontal" SelectedIndex="0" AutoPostBack="True" OnSelectedIndexChanged="rdlEsPadreWeb_SelectedIndexChanged">
                                                        <Items>
                                                            <dx:ListEditItem Selected="True" Text="Si" Value="1" />
                                                            <dx:ListEditItem Text="No" Value="0" />
                                                        </Items>
                                                        <Border BorderStyle="None" />
                                                    </dx:ASPxRadioButtonList>
                                                </div>
                                                <div id="opcionMenuWeb" runat="server">
                                                    <label for="exampleInputEmail1">Menu padre</label>
                                                    <div class="input-group mb-2">
                                                        <dx:ASPxComboBox ID="ddlMenuWeb" runat="server" ValueType="System.String" Width="80%"></dx:ASPxComboBox>
                                                    </div>
                                                </div>
                                                <label for="exampleInputEmail1">Id menu</label>
                                                <div class="input-group mb-2">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                    </div>
                                                    <dx:ASPxTextBox ID="txtIdMenuWeb" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>
                                                <label for="exampleInputEmail1">Nombre del menu</label>
                                                <div class="input-group mb-2">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                    </div>
                                                    <dx:ASPxTextBox ID="txtNombreMenuWeb" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>
                                                <label for="exampleInputEmail1">Descripción del menu</label>
                                                <div class="input-group mb-2">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                    </div>
                                                    <dx:ASPxTextBox ID="txtDescripcionMenuWeb" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>

                                            </div>
                                            <div class="form-group">
                                                <asp:LinkButton ID="btnLimpiar" class="btn btn-light" OnClick="btnLimpiar_Click" runat="server">
                                                        LIMPIAR
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnGuardarWeb" class="btn btn-success" OnClick="btnGuardarWeb_Click" runat="server">
                                                        GUARDAR
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4><i class="mdi mdi-drag">DATOS DE LOS MENUS WEB</i></h4>
                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgMenuWeb" runat="server" Width="100%">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="MENU PADRE" FieldName="menu_padre" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="NOMBRE" FieldName="nombre_menu" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="DESCRIPCION" FieldName="descripcion" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="MENU" FieldName="menu" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="ESTADO" FieldName="estado" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="DESC. ESTADO" FieldName="desc_estado" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="FECHA CREACION" FieldName="fecha_creacion" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="#" VisibleIndex="7">
                                                    <DataItemTemplate>
                                                        <div class="row">
                                                            <div class="col">
                                                                <asp:LinkButton ID="btnActivarWeb" class="btn btn-icon btn-rounded btn-outline-success !important" runat="server" OnCommand="btnActivarWeb_Command" CommandArgument='<%# Eval("menu")%>'>
                                                           
                                                            <i class="feather icon-check"></i>                                    
                                                                                                    
                                                                                                   
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="col">
                                                                <asp:LinkButton ID="btnModificarWeb" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificarWeb_Command" CommandArgument='<%# Eval("menu")%>'>
                                                           
                                                            <i class="feather icon-edit-2"></i>                                    
                                                                                                    
                                                                                                   
                                                                </asp:LinkButton>
                                                            </div>
                                                            <div class="col">
                                                                <asp:LinkButton ID="btnEliminarWeb" class="btn btn-icon btn-rounded btn-outline-danger !important" runat="server" OnCommand="btnEliminarWeb_Command" CommandArgument='<%# Eval("menu")%>'>
                                                           
                                                            <i class="feather icon-trash-2"></i>                                    
                                                                                                    
                                                                                                   
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>


                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <!-- [ Main Content ] end -->
    </div>

    <dx:ASPxHiddenField ID="hfMenuMobile" runat="server"></dx:ASPxHiddenField>
                                        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
