<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmCuentaCorriente.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Participante.frmCuentaCorriente" %>

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
                            <h5 class="m-b-10">Cuenta corriente</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Formulario de registro</a></li>
                            <li class="breadcrumb-item"><a href="#!">Cuenta corriente</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->

        &nbsp;<dx:ASPxTabControl ID="ASPxTabControl1" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="ASPxTabControl1_ActiveTabChanged">
            <Tabs>
                <dx:Tab Text="Registro">
                </dx:Tab>
                <dx:Tab Text="Asignación">
                </dx:Tab>
            </Tabs>
        </dx:ASPxTabControl>
        <asp:MultiView ID="mvCuentasCorrientes" runat="server">
            <asp:View ID="vRegistro" runat="server">
                <div class="row">
                    <div class="col-md-5">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>DATOS CUENTAS CORRIENTAS</h5>
                                    </div>

                                    <div class="alert alert-danger" role="alert">
                                        Los campos con  (*) son valores obligatorios que deben ser completados
                                    </div>

                                    <div class="card-body">
                                        <%--<h5>Form controls</h5>--%>
                                        <%--  <hr>--%>
                                        <div class="col-md-12">
                                            <div class="form-group">

                                                <%--  <label for="exampleInputEmail1">Tipo participante</label>
                                        <div class="input-group mb-2">                                            
                                            <dx:ASPxComboBox ID="ddlTipoParticipante" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                        </div>

                                         <label for="exampleInputEmail1">Participante</label>
                                        <div class="input-group mb-2">
                                        
                                            <dx:ASPxComboBox ID="ddlParticipante" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                        </div>--%>


                                                <label class="text-danger">(*)</label>
                                                <label for="exampleInputEmail1">Codigo Cuenta Corriente</label>
                                                <div class="input-group mb-2">

                                                    <dx:ASPxTextBox ID="txtCodigoCuenta" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>

                                                <label for="exampleInputEmail1">Descripción</label>
                                                <div class="input-group mb-2">

                                                    <dx:ASPxTextBox ID="txtDescripcion" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                </div>


                                                <label class="text-danger">(*)</label><label for="exampleInputEmail1">Fecha desde</label>
                                                <div class="input-group mb-2">

                                                    <dx:ASPxDateEdit ID="dtFechaDesde" runat="server" Width="100%"></dx:ASPxDateEdit>
                                                </div>
                                                <label for="exampleInputEmail1">Fecha hasta</label>
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
                                        <h5>DATOS DE LAS CUENTAS CORRIENTES</h5>
                                    </div>

                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgCuentasCorrientes" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="COD_CUENTA_CORRIENTE" Theme="MetropolisBlue">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="COD_CUENTA_CORRIENTE" Visible="false" VisibleIndex="0" FieldName="COD_CUENTA_CORRIENTE">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CODIGO_CUENTA" VisibleIndex="1" Caption="CODIGO CUENTA">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESCRIPCION" VisibleIndex="2" Caption="DESCRIPCION">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ESTADO" VisibleIndex="3" Caption="ESTADO">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="FECHA_DESDE" VisibleIndex="4" Caption="FECHA DESDE">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="FECHA_HASTA" VisibleIndex="5" Caption="FECHA HASTA">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="6">
                                                    <DataItemTemplate>
                                                        <asp:LinkButton ID="btnModificar" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificar_Command" CommandArgument='<%# Eval("COD_CUENTA_CORRIENTE") %>'>
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
            </asp:View>
            <asp:View ID="vAsignacion" runat="server">
                <div class="card">
                    <div class="row">
                        <!-- [ form-element ] start -->
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-header">
                                    <h5>CUENTAS CORRIENTES</h5>
                                </div>
                                <div class="card-body">
                                    <%--<h5>Form controls</h5>--%>
                                    <%--  <hr>--%>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Cuenta corriente</label>
                                            <div class="input-group mb-2">
                                                <dx:ASPxComboBox ID="ddlCuentaCorrriente" runat="server" ValueType="System.String" Width="100%"></dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:LinkButton ID="btnAsignar" class="btn btn-success" runat="server" OnClick="btnAsignar_Click">ASIGNAR</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                  
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-header">
                                    <h5>PARTICIPANTE</h5>
                                </div>
                                <div class="card-body">
                                    <%--<h5>Form controls</h5>--%>
                                    <%--  <hr>--%>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Participante</label>
                                            <div class="input-group mb-2">
                                                <dx:ASPxComboBox ID="ddlParticipante" runat="server" AutoPostBack="true"   ValueType="System.String" Width="100%" OnSelectedIndexChanged="ddlParticipante_SelectedIndexChanged"></dx:ASPxComboBox>
                                            </div>
                                        </div>
                                           <div class="form-group">
                                            <asp:LinkButton ID="btnDesasignar" class="btn btn-success" runat="server" OnClick="btnDesasignar_Click">DESASIGNAR</asp:LinkButton>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1"></label>
                                            <div class="input-group mb-2">
                                                <dx:ASPxGridView ID="dgParticipante" runat="server" AutoGenerateColumns="False" Width="100%">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="COD_CUENTA_CORRIENTE" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="CODIGO_CUENTA" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="DESCRIPCION" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="COD_CUENTA_PARTICIPANTE" VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                            </div>
                                        </div>
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

    <dx:ASPxHiddenField ID="hfOpciones" runat="server"></dx:ASPxHiddenField>
    <dx:ASPxLabel ID="lblCodigo" runat="server" Visible="false" EnableTheming="false" CssClass="form-control"></dx:ASPxLabel>
                            </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
