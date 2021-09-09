<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmRolesMenu.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Seguridad.frmRolesMenu" %>

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
                            <h5 class="m-b-10">Registro de roles del sistema</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Seguridad</a></li>
                            <li class="breadcrumb-item"><a href="#!">Roles</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <!-- [ form-element ] start -->
                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                                <h4><i class="mdi mdi-drag">FORMULARIO DE REGISTRO</i></h4>
                            </div>
                            <div class="card-body">
                                <%--<h5>Form controls</h5>--%>
                                <%--  <hr>--%>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Rol</label>
                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                            </div>
                                            <dx:ASPxTextBox ID="txtIdRol" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>
                                        <label for="exampleInputEmail1">Nombre rol</label>
                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                            </div>
                                            <dx:ASPxTextBox ID="txtNombreRol" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:LinkButton ID="btnLimpiar" class="btn btn-light" OnClick="btnLimpiar_Click" runat="server"> Limpiar</asp:LinkButton>
                                        <asp:LinkButton ID="btnIngresar" class="btn btn-success" OnClick="btnIngresar_Click" runat="server">
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
                                <h4><i class="mdi mdi-drag">DATOS DE LOS ROLES</i></h4>
                            </div>
                            <div class="card-body">
                                <dx:ASPxGridView ID="dgRoles" runat="server" Width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="ROL" FieldName="rol" VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="NOMBRE ROL" FieldName="nombre_rol" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="ESTADO" FieldName="estado" VisibleIndex="2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="DESCRIPCION" FieldName="desc_estado" VisibleIndex="3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="#" VisibleIndex="4">
                                            <DataItemTemplate>
                                                <asp:LinkButton ID="btnActivacion" class="btn btn-icon btn-rounded btn-outline-success !important" runat="server" OnCommand="btnActivacion_Command" CommandArgument='<%# Eval("rol")%>'>
                                                            <i class="feather icon-check"></i>                                    
                                                </asp:LinkButton>

                                                <asp:LinkButton ID="btnModificar" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificar_Command" CommandArgument='<%# Eval("rol")%>'>
                                                            <i class="feather icon-edit-2"></i>                                    
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnEliminar" class="btn btn-icon btn-rounded btn-outline-danger !important" runat="server" OnCommand="btnEliminar_Command" CommandArgument='<%# Eval("rol")%>'>
                                                            <i class="feather icon-trash-2"></i>                                    
                                                </asp:LinkButton>
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
        <!-- [ Main Content ] end -->
    </div>
    <dx:ASPxHiddenField ID="hfRolesMenu" runat="server"></dx:ASPxHiddenField>
                                        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
