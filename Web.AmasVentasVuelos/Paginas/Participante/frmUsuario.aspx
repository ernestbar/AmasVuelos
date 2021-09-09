<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmUsuario.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Participante.frmUsuario" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h5 class="m-b-10">Registro de Usuario</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Formulario de usuario</a></li>
                            <li class="breadcrumb-item"><a href="#!">Usuario</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>     
        <div class="card">
            <div class="card-header">
                <h5>DATOS DEL USUARIO</h5>
            </div>
            <div class="card-body">
                   <div class="alert alert-danger" role="alert">
                            Los campos con  (*) son valores obligatorios que deben ser completados
                        </div>
                <div id="step-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label"><label class="text-danger">(*)</label>Usuario:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCuentaUsuario" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCuentaUsuario" class="form-text text-muted">Cuenta de usuario</small>
                                </div>
                            </div>                            
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Descripción:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtDEscripsionUsuario" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtDEscripsionUsuario" class="form-text text-muted">Descripción detallada del usuario</small>
                                </div>
                            </div>
                            <h5 class="mt-3">FECHAS PERMITIDA DE ACCESO </h5>
                            <hr />
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label"><label class="text-danger">(*)</label>Fechas desde:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxDateEdit ID="dtFechaDesde" Width="100%" runat="server"></dx:ASPxDateEdit>
                                    <small id="htxtFechaDesde" class="form-text text-muted">Descripción detallada del usuario</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Fechas hasta:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxDateEdit ID="dtHasta" Width="100%" runat="server"></dx:ASPxDateEdit>
                                    <small id="htxtFechaHasta" class="form-text text-muted">Descripción detallada del usuario</small>
                                </div>
                            </div>
                            <h5 class="mt-3">ESTADO EN EL SISTEMA</h5>
                            <hr />
                            <fieldset class="form-group">
                                <div class="row">
                                    <label for="inputPassword3" class="col-sm-3 col-form-label"><label class="text-danger">(*)</label>Estado:</label>
                                    <div class="col-sm-9">
                                        <dx:ASPxRadioButtonList ID="rdlEstado" runat="server" RepeatDirection="Horizontal" SelectedIndex="0" AutoPostBack="True" OnSelectedIndexChanged="rdlEstado_SelectedIndexChanged">
                                            <Items>
                                                <dx:ListEditItem Selected="True" Text="Activo" Value="A" />
                                                <dx:ListEditItem Text="Inactivo" Value="D" />
                                            </Items>
                                            <Border BorderStyle="None" />
                                        </dx:ASPxRadioButtonList>
                                        <small id="hrdlEstado" class="form-text text-muted">El estado del participante</small>
                                    </div>
                                </div>
                            </fieldset>
                            <h5 class="mt-3">ACCESO POR ROLES</h5>
                            <hr />
                            <div class="form-group row">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label"><label class="text-danger">(*)</label>Roles del sistema:</label>
                                <div class="col-sm-7">
                                    <dx:ASPxComboBox ID="ddlRol" runat="server" Width="100%">                                        
                                    </dx:ASPxComboBox>
                                    <small id="hddlRubro" class="form-text text-muted">Roles que contiene el sistema</small>
                                </div>
                                <div class="col-sm-2">
                                    <%--<button type="button" class="btn btn-success"  title="" data-toggle="tooltip" data-original-title="btn btn-success">Adicionar Rol</button>--%>
                                </div>
                            </div>


                        </div>
                    </div>
                       <div class="row">
                        <div class="col-md-12">                            
                            <asp:LinkButton ID="btnLimpiar" class="btn btn-info" runat="server" OnClick="btnLimpiar_Click">Limpiar</asp:LinkButton>
                            <asp:LinkButton ID="btnGuardar" class="btn btn-success" runat="server" OnClick="btnGuardar_Click">Guardar</asp:LinkButton>
                            <asp:LinkButton ID="btnCambiarPassword" class="btn btn-info" runat="server" OnClick="btnCambiarPassword_Click">Cambiar password</asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <div class="card">
                        <div class="card-header">
                            <h5>Datos los roles del usuario</h5>
                        </div>
                        <div class="card-body">
                         
                            <dx:ASPxGridView ID="dgUsuarios" runat="server" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="USUARIO" FieldName="USUARIO" VisibleIndex="0">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="ESTADO"   FieldName="DESC_ESTADO" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="ESTADO" Visible="false" FieldName="ESTADO" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="FECHA DESDE" FieldName="FECHA_DESDE" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="FECHA HASTA" FieldName="FECHA_HASTA" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="ROL" Visible="false" FieldName="rol" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="ROL" FieldName="DESC_ROL" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="7">
                                                    <DataItemTemplate>
                                                        <asp:LinkButton ID="btnModificar" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificar_Command" CommandArgument='<%# Eval("USUARIO") %>'>
                                                            <i class="feather icon-edit-2"></i>                                    
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

    <dx:ASPxHiddenField ID="hfOpciones" runat="server"></dx:ASPxHiddenField>

</asp:Content>
