<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmParticipante.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Participante.frmParticipante" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <style>
        #map {
            width: 100%;
            height: 300px;
            background-color: grey;
        }
    </style>

    <div class="page-wrapper">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h5 class="m-b-10">Registro de particiantes</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="index.html"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Formulario de registro</a></li>
                            <li class="breadcrumb-item"><a href="#!">Participantes</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ breadcrumb ] end -->
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->

        <!-- [ SmartWizard html ] start -->
        <dx:ASPxTabControl ID="tbMenu" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="tbMenu_ActiveTabChanged">
            <Tabs>
                <dx:Tab Text="DATOS PARTICIPANTE">
                </dx:Tab>
                <dx:Tab Text="SUCURSALES">
                </dx:Tab>
                <dx:Tab Text="CONTACTOS">
                </dx:Tab>
                <dx:Tab Text="PERSONAL">
                </dx:Tab>
                <%--<dx:Tab Text="Usuario">
                </dx:Tab>--%>
            </Tabs>
        </dx:ASPxTabControl>
        <div class="card">
            <div class="card-body">
                <asp:MultiView ID="mvVista" runat="server">
                    <asp:View ID="vDatosParticipantes" runat="server">
                        <div class="alert alert-danger" role="alert">
                            Los campos con  (*) son valores obligatorios que deben ser completados
                        </div>
                        <h5>DATOS GENERALES DEL PARTICIPANTE</h5>
                        <hr>
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Tipo de partipante:</label>
                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlTipoParticipanta" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoParticipanta_SelectedIndexChanged1">
                                </dx:ASPxComboBox>
                                <small id="hddlTipoParticipanta" class="form-text text-muted">El tipo de partipante que puede ser juridico o persona natural</small>
                            </div>
                        </div>
                        <div class="form-group row" id="idJuridica1" runat="server">
                            <label for="idRazonSocial" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Nombre:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtNombreParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtNombreParticipante" class="form-text text-muted">Nombre del participante</small>
                            </div>
                        </div>
                        <div class="form-group row" id="idJuridica2" runat="server" visible="">
                            <label for="idRazonSocial" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Apellido:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtApellidoParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtApellidoParticipante" class="form-text text-muted">Apellido del participante</small>
                            </div>
                        </div>
                        <fieldset class="form-group" id="idJuridica3" runat="server">
                            <h5 class="mt-3">DOCUMENTOS DE IDENTIFICACIÓN</h5>
                            <hr />
                            <div class="row">
                                <label for="inputPassword3" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Tipo de documento:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxComboBox ID="ddlTipoDocumentoParticipante" runat="server" Width="100%">
                                    </dx:ASPxComboBox>
                                    <small id="hrdlTipodocumentoParticipante" class="form-text text-muted">Tipos de documentos que identifican al participante</small>
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-group row" id="idJuridica4" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Nro de documento:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtNroDocumentoParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtNroDocumentoParticipante" class="form-text text-muted">Identificador del documento</small>
                            </div>
                        </div>
                        <div class="form-group row" id="idJuridica5" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Cargo:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtCargoParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtCargoParticipante" class="form-text text-muted">Cargo del contacto</small>
                            </div>
                        </div>
                        <div class="form-group row" id="idJuridica6" runat="server">
                            <label for="idRazonSocial" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Razon social:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtRazonSocialParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtRazonSocialParticipante" class="form-text text-muted">La razon social registrada</small>
                            </div>
                        </div>
                        <div class="form-group row" id="idJuridica7" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Nit:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtNitParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtNitParticipante" class="form-text text-muted">Nit del participante</small>
                            </div>
                        </div>
                        <h5 class="mt-3">INFORMACIÓN EMPRESARIAL</h5>
                        <hr />
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Nacionalidad:</label>
                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlNacionalidadParticipante" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlNacionalidadParticipante_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                                <small id="hddlNacionalidadParticipante" class="form-text text-muted">Nacionalidad </small>
                            </div>
                        </div>
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Ciudad:</label>
                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlCiudadParticipante" runat="server" Width="100%" AutoPostBack="True">
                                </dx:ASPxComboBox>
                                <small id="hddlCiudadParticipante" class="form-text text-muted">Ciudad </small>
                            </div>
                        </div>
                        <div class="form-group row" id="div24" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Dirección:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtDireccionParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtDireccionParticipante" class="form-text text-muted">Dirección del participante</small>
                            </div>
                        </div>
                        <div class="form-group row" id="idJuridica8" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Pagina web:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtPaginaWebParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtPaginaWebParticipante" class="form-text text-muted">Pagina web</small>
                            </div>
                        </div>
                        <div class="form-group row" id="idJuridica9" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Teléfono:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtTelefonoParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtTelefonoParticipante" class="form-text text-muted">Teléfono</small>
                            </div>
                        </div>
                        <fieldset id="idJuridica11" runat="server">
                            <h5 class="mt-3">INFORMACIÓN DE CONTACTOS Y CORREO</h5>
                            <hr />
                            <div class="form-group row" id="div14" runat="server">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">Correo electronico:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCorreoParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCorreoParticipante" class="form-text text-muted">Correo electronico del participante</small>
                                </div>
                            </div>
                            <div class="form-group row" id="div25" runat="server">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">Teléfono celular:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtTelefonoCelular" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtTelefonoCelular" class="form-text text-muted">Teléfono celular del participante</small>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset id="Fieldset2" runat="server">
                            <h5 class="mt-3">INFORMACIÓN BANCARIA</h5>
                            <hr />
                           <%-- <div class="form-group row" id="_campoBanco" runat="server">
                                <label for="inputPassword3" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Banco:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxComboBox ID="ddlBancoParticipante" runat="server" Width="100%">
                                    </dx:ASPxComboBox>
                                    <small id="hddlBancoParticipante" class="form-text text-muted">Banco </small>
                                </div>
                               
                            </div>
                             <%--<div class="col-sm-1">
                                    <asp:LinkButton ID="btnAdicionarBanco" class="btn drp-icon btn-rounded btn-info dropdown-toggle" runat="server" OnCommand="btnAdicionarBanco_Command"> <i class="feather icon-plus"></i> </asp:LinkButton>
                                </div>--%>
                            <%--  <div class="form-group row" id="_textoBanco" runat="server">

                                <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Nuevo banco:</label>
                                <div class="col-sm-8">
                                    <dx:ASPxTextBox ID="txtNuevoBanco" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtNuevoBanco" class="form-text text-muted">Ingrese el nuevo nombre del banco </small>
                                </div>
                                <div class="col-sm-1">
                                    <asp:LinkButton ID="btnGuardarNuevoBanco" class="btn drp-icon btn-rounded btn-info dropdown-toggle" runat="server" OnCommand="btnGuardarNuevoBanco_Command"> <i class="feather icon-repeat"></i> </asp:LinkButton>
                                </div>
                            </div>--%>
                        </fieldset>
                       <%-- <div class="form-group row" id="div17" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Cuenta:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtCuentaParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtCuentaParticipante" class="form-text text-muted">Nro de Cuenta</small>
                            </div>
                        </div>--%>
                        <div class="form-group row" id="div18" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Tour code:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtCodigoComisionParticipante" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtCodigoComisionParticipante" class="form-text text-muted">Código de la emisión</small>
                            </div>
                        </div>
                        <h5 class="mt-3">ESTADO EN EL SISTEMA</h5>
                        <hr />
                        <div class="form-group row" id="div19" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">Estado :</label>
                            <div class="col-sm-9">
                                <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ASPxRadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" SelectedIndex="0">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="Activar" Value="A" />
                                        <dx:ListEditItem Text="Desactivar" Value="D" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>
                                <small id="htxtCodigoComision" class="form-text text-muted">Estado del participante</small>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:LinkButton ID="btnGuardarParticipante" class="btn btn-success" runat="server" OnClick="btnGuardarParticipante_Click">Guardar</asp:LinkButton>
                                <asp:LinkButton ID="btnLimpiarParticipante" class="btn btn-info" runat="server" OnClick="btnLimpiarParticipante_Click">Limpiar</asp:LinkButton>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>DATOS DEL PARTICIPANTE</h5>
                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgParticipante" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="COD_PARTICIPANTE">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="COD_PARTICIPANTE"  VisibleIndex ="0" FieldName="COD_PARTICIPANTE">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="TIPO PARTICIPANTE"  VisibleIndex ="0" FieldName="DESC_TIPO_PARTICIPANTE">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="TIPO_PARTICIPANTE" Visible="false" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="RAZON_SOCIAL" Visible="false" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="NOMBRE" Visible="false" VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="APELLIDOS" Visible="false" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_RAZON_SOCIAL" CAPTION="RAZON SOCIAL / PERSONA" VisibleIndex="5">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="TIPO_DOCUMENTO" Visible="false"  VisibleIndex="6">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_TIPO_DOCUMENTO" Caption="TIPO DOCUMENTO" VisibleIndex="7">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="NUMERO_DOCUMENTO"  Caption="NUMERO DE DOCUMENTO" VisibleIndex="8">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="NACIONALIDAD" Visible="false" VisibleIndex="9">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_NACIONALIDAD" Caption="NACIONALIDAD" VisibleIndex="10">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CARGO" VisibleIndex="14">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CIUDAD_RESIDENCIA" Visible="false" VisibleIndex="11">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_RESIDENCIA" Caption="CIUDAD" VisibleIndex="12">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DIRECCION" VisibleIndex="13">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="TELEFONO" Visible="false" VisibleIndex="15">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="EMAIL" Visible="false" Caption="CORREO" VisibleIndex="16">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PAGINA_WEB" Visible="false" Caption="PAGINA WEB" VisibleIndex="17">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="BANCO" Visible="false" VisibleIndex="18">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_BANCO" Caption="BANCO" VisibleIndex="19">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CUENTA" Caption="# CUENTA" VisibleIndex="20">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="COD_EMISION" Caption="# EMISION" VisibleIndex="21">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ESTADO" Visible="false"    VisibleIndex="22">
                                                </dx:GridViewDataTextColumn>

                                                   <dx:GridViewDataTextColumn FieldName="DESC_ESTADO" Caption="ESTADO" VisibleIndex="22">
                                                </dx:GridViewDataTextColumn>

                                                <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="23">
                                                    <DataItemTemplate>
                                                        <asp:LinkButton ID="btnModificarParticipante" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificarParticipante_Command" CommandArgument='<%# Eval("COD_PARTICIPANTE") %>'>
                                                            <i class="feather icon-edit-2"></i>                                    
                                                        </asp:LinkButton>

                                                           <asp:LinkButton ID="btnUsuarioParticipante" class="btn btn-icon btn-rounded btn-outline-info !important" runat="server" Visible='<%# ((Eval("TIPO_PARTICIPANTE").ToString()== "FLA"  )? true: false) %>'   OnCommand="btnUsuarioParticipante_Command" CommandArgument='<%# Eval("COD_PARTICIPANTE") %>'>
                                                            <i class="feather icon-user"></i>                                    
                                                        </asp:LinkButton>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </asp:View>
                    <asp:View ID="vSucursales" runat="server">
                        <div class="alert alert-danger" role="alert">
                            Los campos con  (*) son valores obligatorios que deben ser completados
                        </div>
                        <h5 class="mt-3">DATOS DE LA SUCURSAL</h5>
                        <hr />
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                Sucursal:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtSucursalSucursales" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtSucursalSucursales" class="form-text text-muted">Cod. de la sucursal</small>
                            </div>
                        </div>
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Descripción de la sucursal:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtDescripcionSucursalSucursales" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtDescripcionSucursalSucursales" class="form-text text-muted">Descripción de la sucursal</small>
                            </div>
                        </div>
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Dirección de la sucursal:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtDireccionSucursales" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtDireccionSucursales" class="form-text text-muted">Dirección de la sucursal</small>
                            </div>
                        </div>
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>País:</label>
                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlPaisSucursales" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlPaisSucursales_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                                <small id="hddlPaisSucursales" class="form-text text-muted">País </small>
                            </div>
                        </div>
                        <div class="row">
                            <label for="inputPassword3" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Ciudad:</label>
                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlCiudadSucursales" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlCiudadSucursales_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                                <small id="hddlCiudadSucursales" class="form-text text-muted">Ciudad </small>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="map" class="col-sm-3 col-form-label">Mapa:</label>
                            <div class="col-sm-9">
                                <div id="map"></div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">Coordenadas:</label>
                            <div class="col-sm-4">
                                <dx:ASPxTextBox ID="txtLatitudSucursales"   runat="server" EnableTheming="false" ReadOnly="true" CssClass="form-control" ClientInstanceName="ctxtLatitud" EnableClientSideAPI="true"></dx:ASPxTextBox>
                                <%--<dx:ASPxLabel ID="lblLatitudSucursales" ClientInstanceName="cblblLatitudSucursales" EnableClientSideAPI="true" runat="server" Text="ASPxLabel"></dx:ASPxLabel>--%>
                                <small id="htxtLatitudSucursales" class="form-text text-muted">Latitud</small>
                            </div>
                            <div class="col-sm-4">
                                <dx:ASPxTextBox ID="txtLongitudSucursales" runat="server" EnableTheming="false" ReadOnly="true" CssClass="form-control" ClientInstanceName="ctxtLongitud" EnableClientSideAPI="true"></dx:ASPxTextBox>
                                <%--<dx:ASPxLabel ID="lblLongitudSucursales" ClientInstanceName="cblblLongitudSucursales" EnableClientSideAPI="true" runat="server" Text="ASPxLabel"></dx:ASPxLabel>--%>
                                <small id="htxtLongitudSucursales" class="form-text text-muted">Longitud</small>
                            </div>
                        </div>

                        <h5 class="mt-3">ESTADO EN EL SISTEMA</h5>
                        <hr />
                        <div class="form-group row" id="div13" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">Estado:</label>
                            <div class="col-sm-9">
                                <dx:ASPxRadioButtonList ID="rdlEstadoSucursal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdlEstadoSucursal_SelectedIndexChanged" RepeatDirection="Horizontal" SelectedIndex="0">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="Activar" Value="A" />
                                        <dx:ListEditItem Text="Desactivar" Value="D" />
                                    </Items>
                                    <Border BorderStyle="None" />
                                </dx:ASPxRadioButtonList>
                                <small id="txtEmail" class="form-text text-muted">Coloque el estado del sistema Activo / Inactivo</small>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:LinkButton ID="btnGuardarSucursales" class="btn btn-success" runat="server" OnClick="btnGuardarSucursales_Click">Guardar</asp:LinkButton>
                                <asp:LinkButton ID="btnLimpiarSucursales" class="btn btn-info" runat="server" OnClick="btnLimpiarSucursales_Click">Limpiar</asp:LinkButton>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>DATOS DE LAS SUCURSALES</h5>
                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgSucursales" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="COD_SUCURSAL">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="COD_SUCURSAL"  VisibleIndex="0" FieldName="COD_SUCURSAL">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESCRIPCION" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DIRECCION" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PAIS" Visible="false" VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_PAIS" Caption="PAIS" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="CIUDAD" Visible="false" VisibleIndex="5">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_CIUDAD" Caption="CIUDAD" VisibleIndex="6">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="LONGITUD" Visible="false" VisibleIndex="7">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="LATITUD" Visible="false" VisibleIndex="8">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ESTADO" Visible="false" VisibleIndex="9">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DESC_ESTADO" Caption="ESTADO" VisibleIndex="10">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="11">

                                                    <DataItemTemplate>
                                                        <asp:LinkButton ID="btnModificarSucursales" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificarSucursales_Command" CommandArgument='<%# Eval("COD_SUCURSAL") %>'>
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
                    </asp:View>
                    <asp:View ID="vContactos" runat="server">
                        <div class="alert alert-danger" role="alert">
                            Los campos con  (*) son valores obligatorios que deben ser completados
                        </div>
                        <fieldset class="form-group" id="Fieldset3" runat="server">
                            <h5 class="mt-3">DATOS DEL CONTACTO</h5>
                            <hr />
                            <div class="row">
                                <label for="inputPassword3" class="col-sm-3 col-form-label">Cod. contacto:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCodContacto" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCodContacto" class="form-text text-muted">Codigo del contacto</small>
                                </div>
                            </div>
                            <div class="form-group row" id="div8" runat="server">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Nombre:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtNombreContactos" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtNombreContactos" class="form-text text-muted">Nombre del contacto</small>
                                </div>
                            </div>
                            <div class="form-group row" id="div9" runat="server">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Apellido:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtApellidoContactos" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtApellidoContactos" class="form-text text-muted">Apellido del contacto</small>
                                </div>
                            </div>

                            <div class="row">
                                <label for="inputPassword3" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Ciudad de partipante:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxComboBox ID="ddlCiudadContacto" runat="server" Width="100%" AutoPostBack="True">
                                    </dx:ASPxComboBox>
                                    <small id="hddlCiudadContacto" class="form-text text-muted">Ciudad del contacto de referencia</small>
                                </div>

                            </div>
                            <div class="form-group row" id="div10" runat="server">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Cargo:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCargoContacto" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCargoContacto" class="form-text text-muted">Cargo del contacto</small>
                                </div>
                            </div>

                            <div class="form-group row" id="div11" runat="server">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Teléfono:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtTelefonoContactos" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtTelefonoContactos" class="form-text text-muted">Teléfono del contacto</small>
                                </div>
                            </div>
                            <div class="form-group row" id="div12" runat="server">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Email:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtEmailContactos" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtEmailContactos" class="form-text text-muted">Teléfono del contacto</small>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:LinkButton ID="btnGuardarContactos" class="btn btn-success" runat="server" OnClick="btnGuardarContactos_Click">Guardar</asp:LinkButton>
                                    <asp:LinkButton ID="btnLimpiarContactos" class="btn btn-info" runat="server" OnClick="btnLimpiarContactos_Click">Limpiar</asp:LinkButton>
                                </div>
                            </div>



                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5>DATOS DEL CONTACTO</h5>
                                        </div>
                                        <div class="card-body">
                                            <dx:ASPxGridView ID="dgContacto" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="COD_CONTACTO">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="COD_CONTACTO" FieldName="COD_CONTACTO" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="NOMBRE" FieldName="NOMBRE" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="APELLIDOS" FieldName="APELLIDOS" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="CARGO" FieldName="CARGO" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="EMAIL" FieldName="EMAIL" VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="TELEFONO" FieldName="TELEFONO" VisibleIndex="5">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="CIUDAD" Visible="false" FieldName="CIUDAD" VisibleIndex="6">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="CIUDAD"  FieldName="DESC_CIUDAD" VisibleIndex="7">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="7">
                                                        <DataItemTemplate>
                                                            <asp:LinkButton ID="btnModificarContactos" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificarContactos_Command" CommandArgument='<%# Eval("COD_CONTACTO") %>'>
                                                            <i class="feather icon-edit-2"></i>                                    
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btnEliminarContactos" class="btn btn-icon btn-rounded btn-outline-danger !important" runat="server" OnCommand="btnEliminarContactos_Command" CommandArgument='<%# Eval("COD_CONTACTO") %>'>
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
                        </fieldset>
                    </asp:View>
                    <asp:View ID="vPersonal" runat="server">
                        <div class="alert alert-danger" role="alert">
                            Los campos con  (*) son valores obligatorios que deben ser completados
                        </div>
                        <h5>DATOS PERSONALES</h5>
                        <hr>
                        <div class="form-group row" id="div2" runat="server">
                            <label for="idNombre" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Nombre completo:</label>
                            <div class="col-sm-4">
                                <dx:ASPxTextBox ID="txtNombrePersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtNombrePersonal" class="form-text text-muted">Nombre</small>
                            </div>
                            <div class="col-sm-4">
                                <dx:ASPxTextBox ID="txtApellidoPaternoPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtApellidoPaternoPersonal" class="form-text text-muted">Apellidos</small>
                            </div>

                        </div>
                        <div class="form-group row">
                            <label for="idActividad" class="col-sm-3 col-form-label">Cargo:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtCargoPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtCargoPersonal" class="form-text text-muted">Cargo del personal</small>
                            </div>
                        </div>

                        <fieldset class="form-group" id="Fieldset1" runat="server">
                            <h5 class="mt-3">DOCUMENTOS DE IDENTIFICACIÓN</h5>
                            <hr />
                            <div class="row">
                                <label for="inputPassword3" class="col-sm-3 col-form-label">
                                    <label class="text-danger">(*)</label>Tipo de documento:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxRadioButtonList ID="rdltipoDocumentoPersonal" runat="server" RepeatDirection="Horizontal" SelectedIndex="0">
                                        <Border BorderStyle="None" />
                                    </dx:ASPxRadioButtonList>
                                    <small id="hrdltipoDocumentoPersonal" class="form-text text-muted">Tipos de documentos que identifican al participante</small>
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-group row" id="div3" runat="server">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Nro de documento:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtNroDocumentoPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtNroDocumentoPersonal" class="form-text text-muted">Identificador del documento</small>
                            </div>
                        </div>
                        <h5 class="mt-3">INFORMACIÓN ADICIONAL GEOGRÁFICA</h5>
                        <hr />
                        <div class="form-group row">
                            <label for="idNroDocumento" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Nacionalidad:</label>
                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlNacionalidadPersonal" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlNacionalidadPersonal_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                                <small id="hddlNacionalidadPersonal" class="form-text text-muted">Nacionalidad del participante</small>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="idActividad" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Ciudad de referencia:</label>

                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlCiudadPersonal" runat="server" Width="100%">
                                </dx:ASPxComboBox>
                                <small id="hddlCiudadPersonal" class="form-text text-muted">Lugar de nacimiento o ciudad de referencia actual</small>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="idActividad" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Dirección:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtDireccionPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtDireccionPersonal" class="form-text text-muted">Dirección de referencia donde vive</small>
                            </div>
                        </div>

                        <div class="form-group row" id="div1" runat="server">
                            <label for="ddlNroDocumentoPersonal" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Sucursal:</label>
                            <div class="col-sm-9">
                                <dx:ASPxComboBox ID="ddlSucursalPersonal" runat="server" Width="100%">
                                </dx:ASPxComboBox>
                                <small id="hddlSucursalPersonal" class="form-text text-muted">Sucursal asociada al personal</small>
                            </div>
                        </div>
                        <div class="form-group row" id="div5" runat="server">
                            <label for="idActividad" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Telefono celular:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtTelefonoCelularPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtTelefonoCelularPersonal" class="form-text text-muted">Número telefónico del celular</small>
                            </div>
                        </div>
                        <div class="form-group row" id="div6" runat="server">
                            <label for="idtxtCorreoElectronicoPersonal" class="col-sm-3 col-form-label">
                                <label class="text-danger">(*)</label>Correo electronico:</label>
                            <div class="col-sm-9">
                                <dx:ASPxTextBox ID="txtCorreoElectronicoPersonalPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                <small id="htxtCorreoElectronicoPersonalPersonal" class="form-text text-muted">Correo electronico</small>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:LinkButton ID="btnGuardar" class="btn btn-success" runat="server" OnClick="btnGuardar_Click">Guardar</asp:LinkButton>
                                <asp:LinkButton ID="btnLimpiarPersonal" class="btn btn-info" runat="server" OnClick="btnLimpiarPersonal_Click">Limpiar</asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>DATOS DE LA REFERENCIA PERSONAL</h5>
                                    </div>
                                    <div class="card-body">
                                        <dx:ASPxGridView ID="dgPersonal" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="COD_PARTICIPANTE">
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="COD_PARTICIPANTE" FieldName="COD_PARTICIPANTE" VisibleIndex="0">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="NOMBRE" FieldName="NOMBRE" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="APELLIDOS" FieldName="APELLIDOS" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="TIPO_DOCUMENTO" Visible="false" FieldName="TIPO_DOCUMENTO" VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="TIPO DOCUMENTO" FieldName="DESC_TIPO_DOCUMENTO" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="NUMERO_DOCUMENTO" FieldName="NUMERO_DOCUMENTO" VisibleIndex="5">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="NACIONALIDAD" Visible="false" FieldName="NACIONALIDAD" VisibleIndex="6">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="NACIONALIDAD" FieldName="DESC_NACIONALIDAD" VisibleIndex="7">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="CARGO" FieldName="CARGO" VisibleIndex="8">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="CIUDAD_RESIDENCIA" Visible="false" FieldName="CIUDAD_RESIDENCIA" VisibleIndex="9">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="CIUDAD" FieldName="DESC_RESIDENCIA" VisibleIndex="10">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="DIRECCION" FieldName="DIRECCION" VisibleIndex="11">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="TELEFONO" Visible="false" FieldName="TELEFONO" VisibleIndex="12">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="CORREO" Visible="false" FieldName="EMAIL" VisibleIndex="13">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="COD_SUCURSAL" Visible="false" FieldName="COD_SUCURSAL" VisibleIndex="14">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="SUCURSAL" FieldName="DESC_SUCURSAL" VisibleIndex="15">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="16">
                                                    <DataItemTemplate>
                                                        <asp:LinkButton ID="btnModificarPersonal" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificarPersonal_Command" CommandArgument='<%# Eval("COD_PARTICIPANTE") %>'>
                                                            <i class="feather icon-edit-2"></i>                                    
                                                        </asp:LinkButton>
                                                        <asp:LinkButton ID="btnUsuario" class="btn btn-icon btn-rounded btn-outline-info!important" runat="server" OnCommand="btnUsuario_Command" CommandArgument='<%# Eval("COD_PARTICIPANTE") %>'>
                                                            <i class="feather icon-user"></i>                                    
                                                        </asp:LinkButton>

                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>

                                            </Columns>
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </asp:View>
                    <%-- <asp:View ID="vUsuario" runat="server">
                        <div class="row" id="idInformacionAdicionalPersonal" runat="server">
                            <h5 class="mt-3">Usuario</h5>
                            <hr />
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row" id="div4" runat="server">
                                            <label for="ddlNroDocumentoPersonal" class="col-sm-3 col-form-label">Expedido en:</label>
                                            <div class="col-sm-9">
                                                <dx:ASPxComboBox ID="ddlExpedidoUsuario" runat="server" Width="100%">
                                                </dx:ASPxComboBox>
                                                <small id="hddlExpedidoUsuario" class="form-text text-muted">Ubicacion donde fue expedido el documento </small>
                                            </div>
                                        </div>
                                        <div id="div7" runat="server">
                                            <h5 class="mt-3">Genero</h5>
                                            <hr />
                                            <fieldset class="form-group">
                                                <div class="row">
                                                    <label for="inputPassword3" class="col-sm-3 col-form-label">Sexo:</label>
                                                    <div class="col-sm-9">
                                                        <dx:ASPxRadioButtonList ID="rdlSexoUsuario" runat="server" RepeatDirection="Horizontal" SelectedIndex="0">
                                                            <Items>
                                                                <dx:ListEditItem Selected="True" Text="Masculino" Value="0" />
                                                                <dx:ListEditItem Text="Femenino" Value="00" />
                                                            </Items>
                                                            <Border BorderStyle="None" />
                                                        </dx:ASPxRadioButtonList>
                                                        <small id="hrdlSexoUsuario" class="form-text text-muted">Identifique el genero</small>
                                                    </div>
                                                </div>
                                            </fieldset>
                                            <h5 class="mt-3">Información de estado civil</h5>
                                            <hr />
                                            <div class="form-group row">
                                                <label for="idNroDocumento" class="col-sm-3 col-form-label">Estado civil:</label>
                                                <div class="col-sm-9">
                                                    <dx:ASPxRadioButtonList ID="rdlEstadoCivilUsuario" runat="server" RepeatDirection="Horizontal" SelectedIndex="0">
                                                        <Items>
                                                            <dx:ListEditItem Selected="True" Text="Solterno" Value="0" />
                                                            <dx:ListEditItem Text="Casado" Value="00" />
                                                            <dx:ListEditItem Text="Divorciado" Value="000" />
                                                        </Items>
                                                        <Border BorderStyle="None" />
                                                    </dx:ASPxRadioButtonList>
                                                    <small id="hrdlEstadoCivilUsuario" class="form-text text-muted">El estado civil del participante</small>
                                                </div>
                                            </div>
                                            <h5 class="mt-3">Información academica</h5>
                                            <hr />
                                            <div class="form-group row">
                                                <label for="idActividad" class="col-sm-3 col-form-label">Profesión:</label>
                                                <div class="col-sm-9">
                                                    <dx:ASPxTextBox ID="txtProfesionUsuario" runat="server" Width="100%"></dx:ASPxTextBox>
                                                    <small id="htxtProfesionUsuario" class="form-text text-muted">Profesion que logro alcanzar</small>
                                                </div>
                                            </div>
                                            <h5 class="mt-3">Información Laboral</h5>
                                            <hr />
                                            <div class="form-group row">
                                                <label for="idActividad" class="col-sm-3 col-form-label">Empresa laboral:</label>
                                                <div class="col-sm-9">
                                                    <dx:ASPxTextBox ID="txtEmpresaLaboralUsuario" runat="server" Width="100%"></dx:ASPxTextBox>
                                                    <small id="htxtEmpresaLaboralUsuario" class="form-text text-muted">Nombre de la empresa que pertenece</small>

                                                </div>
                                            </div>
                                        </div>
                                        <asp:LinkButton ID="LinkButton2" class="btn btn-success" runat="server" OnClick="btnGuardar_Click">Guardar personal</asp:LinkButton>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                    </asp:View>--%>
                </asp:MultiView>
            </div>
        </div>

        <%--
        <div id="smartwizard">
            <ul>
                <li><a href="#step-1">
                    <h6>Datos del participante</h6>
                    <p class="m-0">Datos generales </p>
                </a></li>
                <li><a href="#step-2">
                    <h6>Dirección</h6>
                    <p class="m-0">Dirección de domicilio / laboral</p>
                </a></li>
                <li><a href="#step-3">
                    <h6>Referencia Laboral</h6>
                    <p class="m-0">Datos laborales</p>
                </a></li>
                <li><a href="#step-4">
                    <h6>Referencia personal</h6>
                    <p class="m-0">Datos personales</p>
                </a></li>
                <li><a href="#step-5">
                    <h6>Representante legal</h6>
                    <p class="m-0">Información legal del representante</p>
                </a></li>
                <li><a href="#step-6">
                    <h6>Personas naturales</h6>
                    <p class="m-0">Información personal</p>
                </a></li>
            </ul>
            <div>
                <div id="step-1">

                    <div class="row">
                        <div class="col-md-12">
                            <fieldset class="form-group">




                                <div class="form-group row" id="divNombreCompleto" runat="server">
                                    <label for="idNombre" class="col-sm-3 col-form-label">Nombre completo:</label>
                                    <div class="col-sm-3">
                                        <dx:ASPxTextBox ID="txtNombre" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <small id="htxtNombre" class="form-text text-muted">Nombre</small>
                                    </div>
                                    <div class="col-sm-3">
                                        <dx:ASPxTextBox ID="txtApellidoPaterno" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <small id="htxtApellidoPaterno" class="form-text text-muted">Apellido paterno</small>
                                    </div>
                                    <div class="col-sm-3">
                                        <dx:ASPxTextBox ID="txtApellidoMaterno" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <small id="htxtApellidoMaterno" class="form-text text-muted">Apellido materno</small>
                                    </div>
                                </div>

                                <fieldset class="form-group" id="divTipoDocumento" runat="server">
                                    <h5 class="mt-3">Documentos de identificación</h5>
                                    <hr />
                                    <div class="row">
                                        <label for="inputPassword3" class="col-sm-3 col-form-label">Tipo de documento:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxComboBox ID="ddlTipoDocumento" runat="server" Width="100%">
                                            </dx:ASPxComboBox>
                                            <small id="hrdltipoDocumento" class="form-text text-muted">Tipos de documentos que identifican al participante</small>
                                        </div>
                                    </div>
                                </fieldset>
                                <div class="form-group row" id="divtxtNroDocumento" runat="server">
                                    <label for="idNroDocumento" class="col-sm-3 col-form-label">Nro de documento:</label>
                                    <div class="col-sm-9">
                                        <dx:ASPxTextBox ID="txtNroDocumento" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <small id="htxtNroDocumento" class="form-text text-muted">Identificador del documento</small>
                                    </div>
                                </div>
                                <div class="form-group row" id="divddlExpedido" runat="server">
                                    <label for="idNroDocumento" class="col-sm-3 col-form-label">Expedido en:</label>
                                    <div class="col-sm-9">

                                        <dx:ASPxComboBox ID="ddlExpedido" runat="server" Width="100%">
                                        </dx:ASPxComboBox>
                                        <small id="hddlExpedido" class="form-text text-muted">Ubicacion donde fue expedido el documento </small>
                                    </div>
                                </div>


                                <div class="form-group row" id="divtxtTelefonoCelular" runat="server">
                                    <label for="idActividad" class="col-sm-3 col-form-label">Telefono celular:</label>
                                    <div class="col-sm-9">
                                        <dx:ASPxTextBox ID="txtTelefonoCelular" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <small id="htxtTelefonoCelular" class="form-text text-muted">Número telefónico del celular</small>
                                    </div>
                                </div>

                                <div class="form-group row" id="divtxtCorreoElectronicoPersonal" runat="server">
                                    <label for="idtxtCorreoElectronicoPersonal" class="col-sm-3 col-form-label">Correo electronico:</label>
                                    <div class="col-sm-9">
                                        <dx:ASPxTextBox ID="txtCorreoElectronicoPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <small id="htxtCorreoElectronicoPersonal" class="form-text text-muted">Correo electronico</small>

                                    </div>
                                </div>
                                <div id="divPersonal" runat="server">
                                    <h5 class="mt-3">Genero</h5>
                                    <hr />
                                    <fieldset class="form-group">
                                        <div class="row">
                                            <label for="inputPassword3" class="col-sm-3 col-form-label">Sexo:</label>
                                            <div class="col-sm-9">
                                                <dx:ASPxRadioButtonList ID="rdlSexo" runat="server" RepeatDirection="Horizontal" SelectedIndex="0">
                                                    <Items>
                                                        <dx:ListEditItem Selected="True" Text="Masculino" Value="0" />
                                                        <dx:ListEditItem Text="Femenino" Value="00" />
                                                    </Items>
                                                    <Border BorderStyle="None" />
                                                </dx:ASPxRadioButtonList>
                                                <small id="hrdlSexo" class="form-text text-muted">Identifique el genero</small>
                                            </div>
                                        </div>
                                    </fieldset>
                                    <h5 class="mt-3">Información adicional geográfica</h5>
                                    <hr />
                                    <div class="form-group row">
                                        <label for="idActividad" class="col-sm-3 col-form-label">Lugar de nacimiento:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxTextBox ID="txtLugarNacimiento" runat="server" Width="100%"></dx:ASPxTextBox>
                                            <small id="htxtLugarNacimiento" class="form-text text-muted">Lugar de nacimiento</small>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="idNroDocumento" class="col-sm-3 col-form-label">Nacionalidad:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxComboBox ID="ddlNacionalidad" runat="server" Width="100%">
                                                <Items>
                                                    <dx:ListEditItem Text="xxxxxxBoliviano" Value="0" />
                                                    <dx:ListEditItem Text="Exterior" Value="1" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                            <small id="hddlNacionalidad" class="form-text text-muted">Nacionalidad del participante</small>
                                        </div>
                                    </div>

                                    <h5 class="mt-3">Información de estado civil</h5>
                                    <hr />
                                    <div class="form-group row">
                                        <label for="idNroDocumento" class="col-sm-3 col-form-label">Estado civil:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxRadioButtonList ID="rdlEstadoCivil" runat="server" RepeatDirection="Horizontal" SelectedIndex="0">
                                                <Items>
                                                    <dx:ListEditItem Selected="True" Text="Solterno" Value="0" />
                                                    <dx:ListEditItem Text="Casado" Value="00" />
                                                    <dx:ListEditItem Text="Divorciado" Value="000" />
                                                    <dx:ListEditItem Text="Viudo" Value="0000 " />
                                                </Items>
                                                <Border BorderStyle="None" />
                                            </dx:ASPxRadioButtonList>
                                            <small id="hrdlEstadoCivil" class="form-text text-muted">El estado civil del participante</small>
                                        </div>
                                    </div>
                                    <h5 class="mt-3">Información academica</h5>
                                    <hr />
                                    <div class="form-group row">
                                        <label for="idActividad" class="col-sm-3 col-form-label">Profesión:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxTextBox ID="txtProfesion" runat="server" Width="100%"></dx:ASPxTextBox>
                                            <small id="htxtProfesion" class="form-text text-muted">Profesion que logro alcanzar</small>
                                        </div>
                                    </div>
                                    <h5 class="mt-3">Información Laboral</h5>
                                    <hr />
                                    <div class="form-group row">
                                        <label for="idActividad" class="col-sm-3 col-form-label">Empresa laboral:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxTextBox ID="txtEmpresaLaboral" runat="server" Width="100%"></dx:ASPxTextBox>
                                            <small id="htxtEmpresaLaboral" class="form-text text-muted">Nombre de la empresa que pertenece</small>
                                            <asp:LinkButton ID="btnGuardar" class="btn btn-success" runat="server" OnClick="btnGuardar_Click">Guardar personal</asp:LinkButton>
                                        </div>

                                        <div class="form-group row">
                                            <div class="col-sm-9">
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div id="divInformacionEmpresarial" runat="server">


                                    <h5 class="mt-3">Información Empresarial</h5>
                                    <hr />
                                    <div class="form-group row">
                                        <label for="ddlSociedad" class="col-sm-3 col-form-label">Sociedad:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxComboBox ID="ddlSociedad" runat="server" Width="95%">
                                            </dx:ASPxComboBox>
                                            <small id="hddlSociedad" class="form-text text-muted">Nombre de la sociedad</small>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="idActividad" class="col-sm-3 col-form-label">Actividad:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxTextBox ID="txtActividad" runat="server" Width="100%"></dx:ASPxTextBox>
                                            <small id="htxtActividad" class="form-text text-muted">Nombre de la actividad</small>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="txtNit" class="col-sm-3 col-form-label">Nit:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxTextBox ID="txtNit" runat="server" Width="100%"></dx:ASPxTextBox>
                                            <small id="htxtNit" class="form-text text-muted">Nit registrado en Impuestos internos</small>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="idActividad" class="col-sm-3 col-form-label">Telefono Fijo:</label>
                                        <div class="col-sm-9">
                                            <dx:ASPxTextBox ID="txtTelefonoFijo" runat="server" Width="100%"></dx:ASPxTextBox>
                                            <small id="htxtTelefonoFijo" class="form-text text-muted">Número telefónico fijo</small>
                                        </div>
                                    </div>
                                    <div class="form-group row" id="comboRubro" runat="server">
                                        <label for="idNroDocumento" class="col-sm-3 col-form-label">Rubro:</label>

                                        <div class="col-sm-8">
                                            <dx:ASPxComboBox ID="ddlRubro" runat="server" Width="95%">
                                            </dx:ASPxComboBox>
                                            <small id="hddlRubro" class="form-text text-muted">Rubros disponibles</small>
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:LinkButton ID="btnAdicionarRubro" class="btn drp-icon btn-rounded btn-info dropdown-toggle" runat="server" OnCommand="btnAdicionarRubro_Command"> <i class="feather icon-plus"></i> </asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="form-group row" id="textoRubro" runat="server">
                                        <label for="idNroDocumento" class="col-sm-3 col-form-label">Rubro:</label>
                                        <div class="col-sm-8">
                                            <dx:ASPxTextBox ID="txtRubro" runat="server" Width="100%"></dx:ASPxTextBox>
                                            <small id="htxtRubro" class="form-text text-muted">Ingrese el rubro </small>
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:LinkButton ID="btnGuardarRubroNuevo" class="btn drp-icon btn-rounded btn-info dropdown-toggle" runat="server" OnCommand="btnGuardarRubroNuevo_Command"> <i class="feather icon-repeat"></i> </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <h5 class="mt-3">Información de contacto web</h5>
                                <hr />

                                <div class="form-group row">
                                    <label for="idActividad" class="col-sm-3 col-form-label">Pagina web:</label>
                                    <div class="col-sm-9">
                                        <dx:ASPxTextBox ID="txtPaginaWeb" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <small id="htxtPaginaWeb" class="form-text text-muted">Dirección de a pagina web del participante</small>
                                    </div>
                                </div>

                                <h5 class="mt-3">Información bancaria</h5>
                                <hr />

                                <div class="form-group row">
                                    <label for="idActividad" class="col-sm-3 col-form-label">Cuenta corriente:</label>
                                    <div class="col-sm-9">
                                        <dx:ASPxSpinEdit ID="spnCuentaCorriente" runat="server" Number="0" HorizontalAlign="Right" AllowMouseWheel="false" Width="100%">
                                        </dx:ASPxSpinEdit>
                                        <small id="htxtCuentaCorriente" class="form-text text-muted">Número de cuenta corriente</small>
                                    </div>
                                </div>

                                <h5 class="mt-3">Estado en el sistema</h5>
                                <hr />
                                <fieldset class="form-group">
                                    <div class="row">
                                        <label for="inputPassword3" class="col-sm-3 col-form-label">Estado:</label>
                                        <div class="col-sm-9">
                                            <label class="badge badge-pill badge-success">Estado inicial del registro del participante</label>
                                        </div>
                                    </div>
                                </fieldset>
                        </div>
                    </div>
                </div>
                <div id="step-2">
                    <h5>Dirección del domicilio</h5>
                    <hr>
                    <div class="row">
                        <div class="col-md-12">
                            <fieldset class="form-group">
                                <div class="row">
                                    <label for="inputPassword3" class="col-sm-3 col-form-label">Tipo de vivienda:</label>
                                    <div class="col-sm-9">
                                        <dx:ASPxComboBox ID="ddlTipoVivienda" runat="server" Width="100%"></dx:ASPxComboBox>
                                        <small id="hddlTipoVivienda" class="form-text text-muted">Tipo del departamento que vive</small>
                                    </div>
                                </div>
                            </fieldset>
                            <h5 class="mt-3">Información adicional</h5>
                            <hr />
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Detalle:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtDetalle" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtDetalle" class="form-text text-muted">Detalle / referencia del domicilio</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Detalle opcional:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtDetalleOpcional" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtDetalleOpcional" class="form-text text-muted">Detalle / referencia del domicilio adicional</small>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label for="idNombre" class="col-sm-3 col-form-label">Dirección:</label>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtBarrio" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtBarrio" class="form-text text-muted">Barrio</small>
                                </div>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtCondominio" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCondominio" class="form-text text-muted">Condominio</small>
                                </div>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtUrbanizacion" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtUrbanizacion" class="form-text text-muted">Urbanización</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idNombre" class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtCiudad" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCiudad" class="form-text text-muted">Ciudad</small>
                                </div>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtAvenida" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtAvenida" class="form-text text-muted">Avenida</small>
                                </div>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtCalle" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCalle" class="form-text text-muted">Calle</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idNombre" class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtPasillo" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtPasillo" class="form-text text-muted">Pasillo</small>
                                </div>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtNroDomicilio" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtNroDomicilio" class="form-text text-muted">Nro de domicilio</small>
                                </div>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtEdificio" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtEdificio" class="form-text text-muted">Edificio</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idNombre" class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtPiso" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtPiso" class="form-text text-muted">Piso</small>
                                </div>
                                <div class="col-sm-3">
                                    <dx:ASPxTextBox ID="txtNroDepartamento" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtNroDepartamento" class="form-text text-muted">Nro de departamento</small>
                                </div>
                                <div class="col-sm-3">
                                </div>
                            </div>
                            <h5 class="mt-3">Información de referncia domicilaria</h5>
                            <hr />
                            <div class="form-group row">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">Telefono de referencia:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtTelefonoReferencia" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtTelefonoReferencia" class="form-text text-muted">Telefono de referencia del participante</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">Referencia:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtReferencia" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtReferencia" class="form-text text-muted">Referencia adicional del domicilio</small>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
                <div id="step-3">
                    <h5>Referencia laboral</h5>
                    <hr>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group row">
                                <label for="ddlSituacionLaboral" class="col-sm-3 col-form-label">Situación laboral:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxComboBox ID="ddlSituacionLaboral" runat="server" Width="95%">
                                    </dx:ASPxComboBox>
                                    <small id="hddlSituacionLaboral" class="form-text text-muted">Situación laboral actual</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Relación laboral:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxComboBox ID="ddlRelacionLaboral" runat="server" Width="95%">
                                    </dx:ASPxComboBox>
                                    <small id="htxtRelacionLaboral" class="form-text text-muted">Relación laboral actual</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Relación laboral opcional:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtRelacionLaboralOp" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtRelacionLaboralOp" class="form-text text-muted">Relación laboral opcional</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Antiguedad:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxSpinEdit ID="spnAntiguedad" runat="server" Number="0" HorizontalAlign="Right" AllowMouseWheel="false" Width="100%">
                                    </dx:ASPxSpinEdit>
                                    <small id="htxtAntiguedadLaboral" class="form-text text-muted">Antiguedad laboral</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Cargo:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCargo" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCargo" class="form-text text-muted">Cargo actual</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Empresa:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtEmpresa" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtEmpresa" class="form-text text-muted">Empresa actual</small>
                                </div>
                            </div>
                            <h5 class="mt-3">Información de contacto</h5>
                            <hr />
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Telefono:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtTelefono" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtTelefono" class="form-text text-muted">Telefono actual</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Correo electronico:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCorreoElectronico" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCorreoElectronico" class="form-text text-muted">Correo electronico</small>
                                </div>
                            </div>
                            <h5 class="mt-3">Información salarial</h5>
                            <hr />
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Ingreso [Bs]:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtIngresoBs" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtIngresoBs" class="form-text text-muted">Ingreso en bolivianos</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="step-4">
                    <h5>Referencia Personal</h5>
                    <hr>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group row">
                                <label for="idNroDocumento" class="col-sm-3 col-form-label">Tipo de referencia:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxComboBox ID="ddlTipoReferencia" runat="server" Width="100%">
                                    </dx:ASPxComboBox>
                                    <small id="hddlTipoReferencia" class="form-text text-muted">Tipo del referencia personal</small>


                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Nombre completo:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtReferenciaPersonal" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtReferenciaPersonal" class="form-text text-muted">Nombre completo de la referencia personal</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Ocupacion:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtOcupacion" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtOcupacion" class="form-text text-muted">Ocupación de la referencia personal</small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Telefono:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtTelefonoReferenciaLaboral" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtTelefonoReferenciaLaboral" class="form-text text-muted">Telefono de la referencia personal</small>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <button type="button" class="btn btn-success" title="" data-toggle="tooltip" data-original-title="btn btn-success">Registrar referencia personal</button>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h5>Datos de la referencia personal</h5>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-sm">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Username</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td>Mark</td>
                                            <td>Otto</td>
                                            <td>@mdo</td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td>Jacob</td>
                                            <td>Thornton</td>
                                            <td>@fat</td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td>Larry</td>
                                            <td>the Bird</td>
                                            <td>@twitter</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="step-5">
                    <h5>Representante legal</h5>
                    <hr>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Nombre completo:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtNombreRepresentanteLegal" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtNombreRepresentanteLegal" class="form-text text-muted">Nombre completo del representante legal </small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Nro de poder:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtNroPoder" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtNroPoder" class="form-text text-muted">Número del poder del representante legal </small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Nro de documento:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtNroDocumentoRepresentanteLegal" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtNroDocumentoRepresentanteLegal" class="form-text text-muted">Número del documento del representante legal </small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Cargo:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCargoRepresentanteLegal" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCargoRepresentanteLegal" class="form-text text-muted">Cargo del representante legal </small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Correo electronico:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtCorreoRepresentanteLegal" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtCorreoRepresentanteLegal" class="form-text text-muted">Correo del representante legal </small>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="idRazonSocial" class="col-sm-3 col-form-label">Telefono:</label>
                                <div class="col-sm-9">
                                    <dx:ASPxTextBox ID="txtTelefonoRepresentanteLegal" runat="server" Width="100%"></dx:ASPxTextBox>
                                    <small id="htxtTelefonoRepresentanteLegal" class="form-text text-muted">Telefono del representante legal </small>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <button type="button" class="btn btn-success" title="" data-toggle="tooltip" data-original-title="btn btn-success">Registrar representante legal</button>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h5>Datos de los representantes legales</h5>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-sm">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Username</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td>Mark</td>
                                            <td>Otto</td>
                                            <td>@mdo</td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td>Jacob</td>
                                            <td>Thornton</td>
                                            <td>@fat</td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td>Larry</td>
                                            <td>the Bird</td>
                                            <td>@twitter</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="step-6">
                    <div class="row" id="idInformacionAdicionalJuridica" runat="server">
                        <h2 class="mt-3">Completo la información, proceda a registrar la información</h2>

                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5>Datos de la referencia personal</h5>
                                        </div>
                                        <div class="card-body">
                                            <div class="table-responsive">
                                                <table class="table table-sm">
                                                    <thead>
                                                        <tr>
                                                            <th>ID</th>
                                                            <th>Nombre</th>
                                                            <th>Apellido paterno</th>
                                                            <th>Apellido materno</th>
                                                            <th>Acciones</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>Mark</td>
                                                            <td>Otto</td>
                                                            <td>@mdo</td>
                                                            <td><a href="frmUsuario.aspx">
                                                                <button type="button" class="btn btn-info" title="" data-toggle="tooltip" data-original-title="btn btn-info">Usuario</button></a></td>

                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                 


                    <div class="row">
                        <div class="col-md-12">

                            <asp:LinkButton ID="btnCompletarRegistro" class="btn btn-success" runat="server" OnClick="btnCompletarRegistro_Click">Completar registro</asp:LinkButton>

                            <button type="button" class="btn btn-success" title="" data-toggle="tooltip" data-original-title="btn btn-success">Completar registro</button>
                        </div>
                    </div>

                </div>

            </div>
        </div>
        --%>
        <dx:ASPxHiddenField ID="hfOpciones" runat="server"></dx:ASPxHiddenField>
    </div>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAIO6udUgHwuiAnL-I_Tk5Jp_A6wHh1U84&callback=initMap"></script>
    <script>
        // Initialize and add the map
        function initMap() {
            //var marker;
            //var position;
            //var myLatlng = { lat: -17.3804204, lng: -66.1730049 };
            //var map = new google.maps.Map(
            //    document.getElementById('map'), { zoom: 4, center: myLatlng });
            //google.maps.event.addListener(map, "click", function (e) {
            //    //lat and lng is available in e object
            //    var latLng = e.latLng;
            //    ctxtLatitud.SetText(latLng.lat());
            //    ctxtLongitud.SetText(latLng.lng());
            //     marker = new google.maps.Marker({
            //        position: position,
            //        map: map
            //    });
            //});

            var myOptions = {
                zoom: 11,
                center: new google.maps.LatLng(<%=Session["lat"] %> , <%=Session["lon"] %>),
                disableDefaultUI: true,
                zoomControl: true,
                zoomControlOptions: {
                    style: google.maps.ZoomControlStyle.SMALL
                },
                mapTypeId: 'terrain',
                draggableCursor: 'crosshair',
            }
            var map = new google.maps.Map(document.getElementById("map"), myOptions);

            var marker;
            function placeMarker(location) {
                if (marker) {
                    marker.setPosition(location);
                } else {
                    marker = new google.maps.Marker({
                        position: location,
                        map: map
                    });
                }

                ctxtLatitud.SetText(location.lat());
                ctxtLongitud.SetText(location.lng());

                //cblblLatitudSucursales.SetText(location.lat());                
                //cblblLongitudSucursales.SetText(location.lat());

                var infowindow = new google.maps.InfoWindow({
                    content: 'Latitud: ' + location.lat() + '<br>Longitud: ' + location.lng()
                });
                //infowindow.open(map, marker);
            }

            google.maps.event.addListener(map, 'click', function (event) {
                placeMarker(event.latLng);
            });
        }
        window.onload = initMap;
    </script>
                   </ContentTemplate>
    </asp:UpdatePanel> 

</asp:Content>

