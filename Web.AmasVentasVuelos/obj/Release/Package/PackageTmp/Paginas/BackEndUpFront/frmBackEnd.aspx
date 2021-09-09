<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmBackEnd.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.BackEndUpFront.frmBackEnd" %>
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
                            <h5 class="m-b-10">Comisiones</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Formulario de registro</a></li>
                            <li class="breadcrumb-item"><a href="#!">BackEnd</a></li>
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
                                <h5>DATOS BACKEND</h5>
                            </div>


                            <div class="alert alert-danger" role="alert">
                            Los campos con  (*) son valores obligatorios que deben ser completados
                        </div>

                            <div class="card-body">
                                <%--<h5>Form controls</h5>--%>
                                <%--  <hr>--%>
                                <div class="col-md-12">
                                    <div class="form-group">



                                    <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Regla</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxTextBox ID="txtRegla" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>

                                        <label class="text-danger">(*)</label><label for="exampleInputEmail1">Fecha Inicio</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxDateEdit ID="dtFechaDesde" runat="server" Width="100%"></dx:ASPxDateEdit>
                                        </div>

                                       <label class="text-danger">(*)</label><label for="exampleInputEmail1">Fecha fin</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxDateEdit ID="dtFechaHasta" runat="server" Width="100%"></dx:ASPxDateEdit>
                                        </div>

                                           <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Rango inicio</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxTextBox ID="txtRangoIni" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>

                                           <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Rango Fin</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxTextBox ID="txtRangoFin" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>

                                      <label class="text-danger">(*)</label>    <label for="exampleInputEmail1">Modo</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxComboBox ID="ddlModo" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                        </div>

                                      <label class="text-danger"></label> <label for="exampleInputEmail1">Seleccione una ruta</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxComboBox ID="ddlRuta" OnSelectedIndexChanged="ddlRuta_SelectedIndexChanged" AutoPostBack="true" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                            <asp:CheckBox ID="chkRutas" runat="server" OnCheckedChanged="chkRutas_CheckedChanged" Text="Todos"  AutoPostBack="true" />
                                        </div>
                                        <label class="text-danger">(*)</label> <label for="exampleInputEmail1">Rutas seleccionadas</label>
                                        <div class="input-group mb-2">
                                            <asp:ListBox ID="lbRuta" Width="100%"  OnSelectedIndexChanged="lbRuta_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:ListBox>
                                         </div>

                                      <label class="text-danger">(*)</label>   <label for="exampleInputEmail1">Comisiones %</label>
                                        <div class="input-group mb-2">
                                            <dx:ASPxTextBox ID="txtComisiones" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
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
                            <h5>DATOS DE LAS COMISIONES  - BACKEND</h5>
                        </div>
                      
                          <div class="card-body">
                            <dx:ASPxGridView ID="dgBackEnd" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="COD_BACKEND" Theme="MetropolisBlue">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="COD_BACKEND" Visible="true" VisibleIndex="0" FieldName="COD_BACKEND">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="NRO_REGLA" VisibleIndex="1" Caption="NRO. REGLA">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FECHA_INICIO" VisibleIndex="2" Visible="false" Caption="FECHA INICIO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FECHA_FIN" VisibleIndex="3" Caption="FECHA FIN">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="MODO" VisibleIndex="4"  Visible="false" Caption="MODO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="desc_modo" VisibleIndex="5" Caption="DESC. MODO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RUTA" VisibleIndex="6" Caption="RUTA">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RANGO_INICIO" VisibleIndex="7" Caption="RANGO INICIO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RANGO_FIN" VisibleIndex="8" Caption="RANGO FIN">
                                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="COMISION" VisibleIndex="9" Caption="COMISION">
                                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="ESTADO" VisibleIndex="10" Visible="false" Caption="ESTADO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="desc_estado" VisibleIndex="11"    Caption="ESTADO">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="OPERACION" VisibleIndex="13">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="btnModificar" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificar_Command" CommandArgument='<%# Eval("COD_BACKEND") %>'>
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

