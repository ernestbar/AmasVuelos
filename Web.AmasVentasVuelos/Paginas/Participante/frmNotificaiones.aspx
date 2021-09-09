<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmNotificaiones.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Participante.frmNotificaiones" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers >
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
        <ContentTemplate>
            <div class="page-wrapper">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h5 class="m-b-10">Notificaciones</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Formulario de registro</a></li>
                            <li class="breadcrumb-item"><a href="#!">Notificaciones</a></li>
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
                                <h5>DATOS NOTIFICACIONES</h5>
                            </div>


                            <div class="alert alert-danger" role="alert">
                            Los campos con  (*) son valores obligatorios que deben ser completados
                        </div>

                            <div class="card-body">
                                <%--<h5>Form controls</h5>--%>
                                <%--  <hr>--%>
                                <div class="col-md-12">
                                    <div class="form-group">
                                                <label for="exampleInputEmail1">Tipo Participante</label>
                                                <div class="input-group mb-2">
                                                    <asp:DropDownList ID="ddlTipoParticipante2"  CssClass="form-control"  runat="server"></asp:DropDownList>
                                                </div>
                                           <%--     <label class="text-danger">(*)</label>
                                                <label for="exampleInputEmail1">Participante</label>
                                                <div class="input-group mb-2">
                                                    <dx:ASPxComboBox ID="ddlParticipantes" CssClass="form-control"  AutoPostBack="true"  Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                </div>--%>


                                    <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Cod. Notificacion</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxTextBox ID="txtCodNotificacion" runat="server" ReadOnly="true" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>
                                        <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Nombre Publicidad</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxTextBox ID="txtDenominacion" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>
                                        <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Descripcion</label>
                                        <div class="input-group mb-2">
                                            <asp:TextBox ID="txtDescripcion"  Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Condiciones</label>
                                        <div class="input-group mb-2">
                                            <asp:TextBox ID="txtCondiciones" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Detalle</label>
                                        <div class="input-group mb-2">
                                            <asp:FileUpload ID="fuImagen" CssClass="form-control"  runat="server" />
                                        </div>

                                        <label class="text-danger">(*)</label><label for="exampleInputEmail1">Fecha Desde</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxDateEdit ID="dtFechaDesde" runat="server" Width="100%"></dx:ASPxDateEdit>
                                        </div>

                                       <label class="text-danger">(*)</label><label for="exampleInputEmail1">Fecha Hasta</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxDateEdit ID="dtFechaHasta" runat="server" Width="100%"></dx:ASPxDateEdit>
                                        </div>
                                    </div>


                                    <h5 class="mt-3">ESTADO EN EL SISTEMA</h5>
                                    <hr />
                                    <div class="form-group row" id="div1" runat="server">
                                        <label for="idNroDocumento" class="col-sm-3 col-form-label">Estado :</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxRadioButtonList ID="rbtnEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtnEstado_SelectedIndexChanged" RepeatDirection="Horizontal" SelectedIndex="0">
                                                <Items>
                                                    <dx:ListEditItem Selected="True" Text="Activar" Value="A" />
                                                    <dx:ListEditItem Text="Desactivar" Value="D" />
                                                </Items>
                                                <Border BorderStyle="None" />
                                            </dx:ASPxRadioButtonList>
                                            <small id="htxtCodigoCuenta" class="form-text text-muted">Estado de la cuenta</small>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:LinkButton ID="btnGuardar" class="btn btn-success" runat="server" OnClick="btnGuardar_Click">Guardar</asp:LinkButton>
                                            <asp:LinkButton ID="btnLimpiar" class="btn btn-info" runat="server" OnClick="btnLimpiar_Click">Limpiar</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             <div class="col-md-7">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h5>DATOS NOTIFICACIONES</h5>
                        </div>
                      
                          <div class="card-body">
                               <dx:ASPxRadioButtonList ID="rbDgEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbDgEstado_SelectedIndexChanged" RepeatDirection="Horizontal" SelectedIndex="0">
                                                <Items>
                                                    <dx:ListEditItem Selected="True" Text="Todos" Value="Todos" />
                                                    <dx:ListEditItem Text="Activo" Value="Activo" />
                                                    <dx:ListEditItem Text="Inactivo" Value="Inactivo" />
                                                </Items>
                                                <Border BorderStyle="None" />
                                            </dx:ASPxRadioButtonList>
                            <dx:ASPxGridView ID="dgNotificaciones" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID_NOTIFICACION" Theme="MetropolisBlue">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID_NOTIFICACION" Visible="true" VisibleIndex="0" FieldName="ID_NOTIFICACION">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataImageColumn FieldName="DETALLE" Caption="IMAGEN" PropertiesImage-ImageWidth="130" VisibleIndex="1">
                                    </dx:GridViewDataImageColumn>
                                    <dx:GridViewDataTextColumn FieldName="DESC_TIPO_PARTICIPANTE" VisibleIndex="2" Caption="TIPO_PARTICIPANTE">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TIPO_PARTICIPANTE" VisibleIndex="3" Visible="false" Caption="TIPO_PARTICIPANTE">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DENOMINACION" VisibleIndex="4" Caption="NOMBRE PUBLICIDAD">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DESCRIPCION" VisibleIndex="5"  Caption="DESCRIPCION">
                                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="CONDICIONES" VisibleIndex="6"  Caption="CONDICIONES">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DETALLE" VisibleIndex="7" Caption="DETALLE">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FECHA_DESDE" VisibleIndex="8" Caption="FECHA DESDE">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FECHA_HASTA" VisibleIndex="9" Caption="FECHA HASTA">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ESTADO" VisibleIndex="10"  Visible="false"  Caption="COD_ESTADO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DESC_ESTADO" VisibleIndex="11" Caption="ESTADO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="12">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="btnModificar"  class="btn btn-icon btn-rounded btn-outline-warning !important"  runat="server" OnCommand="btnModificar_Command" CommandArgument='<%# Eval("ID_NOTIFICACION") %>'>
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

        <!-- [ Main Content ] end -->



    </div>
   
    <dx:ASPxHiddenField ID="hfOpciones" runat="server"></dx:ASPxHiddenField>
    
    <dx:ASPxLabel ID="lblCodigo" runat="server" Visible="false" EnableTheming="false" CssClass="form-control"></dx:ASPxLabel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
