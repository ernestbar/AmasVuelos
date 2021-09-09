<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmTransaccionesAdmin.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Transacciones.frmTransaccionesAdmin" %>
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
                            <h5 class="m-b-10">Formulario de dominios</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Administración</a></li>
                            <li class="breadcrumb-item"><a href="#!">Domninios</a></li>
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
                                <div class="row justify-content-between">
                                    <div class="col-12">
                                        <h4><i class="mdi mdi-drag">FORMULARIO DE REGISTRO</i></h4>
                                    </div>
                                    <%--<div class="col-6">
                                        <div class="btn-group mb-3 mr-3">
                                            <dx:ASPxRadioButtonList ID="rdlTipoDominio" runat="server" AutoPostBack="True" EnableTheming="True" OnSelectedIndexChanged="rdlTipoDominio_SelectedIndexChanged" RepeatDirection="Horizontal" SelectedIndex="0" Theme="MetropolisBlue" Width="250px">
                                                <Items>
                                                    <dx:ListEditItem Selected="True" Text="Dominio" Value="0" />
                                                    <dx:ListEditItem Text="Sub dominio" Value="1" />
                                                </Items>
                                                <Border BorderStyle="None" />
                                            </dx:ASPxRadioButtonList>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="card-body">
                                <%--<h5>Form controls</h5>--%>                                <%--  <hr>--%>
                                <div class="col-md-12" id="tabDominio">
                                    <div class="form-group">
                                        
                                        <div id="_COMODIN" runat="server">
                                             <label for="exampleInputEmail1">Tipo Participante:</label>
                                        <div class="input-group mb-2">
                                            <asp:DropDownList ID="ddlTipoParticipante" OnSelectedIndexChanged="ddlTipoParticipante_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"  runat="server"></asp:DropDownList>
                                        </div>
                                 

                                        <label for="exampleInputEmail1">Buscar Participante</label>
                                        <div class="input-group mb-2">
                                            <asp:TextBox ID="txtBuscarParticipante"  CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                            <div class="row">
                                            <div class="col-sm-12">
                                                <asp:LinkButton ID="lbtnBuscaarParticipante" class="btn btn-success" OnClick="lbtnBuscaarParticipante_Click" runat="server" >Buscar</asp:LinkButton>
                                            </div>
                                        </div>
                                        <div class="input-group mb-2">
                                            <asp:DropDownList ID="ddlParticipantes" OnSelectedIndexChanged="ddlParticipante_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"  runat="server"></asp:DropDownList>
                                            <asp:Label ID="lblAvisoPArticipante" runat="server" Font-Size="Small" ForeColor="Red" Text=""></asp:Label>
                                        </div>
                                            <label for="exampleInputEmail1"><label class="text-danger">(*)</label>Cod. Transaccion</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <dx:ASPxTextBox ID="txtCodigo" runat="server" EnableTheming="false" ReadOnly="true" CssClass="form-control"></dx:ASPxTextBox>
                                            </div>
                                            <label for="exampleInputEmail1"><label class="text-danger">(*)</label>Tipo Transaccion</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                </div>
                                                <asp:DropDownList ID="ddlTipoTransaccion" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                             <label for="exampleInputEmail1"><label class="text-danger">(*)</label>Motivo Transaccion</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                </div>
                                                <asp:DropDownList ID="ddlMotivoTransaccion" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <label for="exampleInputEmail1">Monto Transaccion</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <dx:ASPxTextBox ID="txtMontoTransaccion" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                            </div>
                                            <label for="exampleInputEmail1">Descripcion</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <asp:TextBox ID="txtDescripcion" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                            
                                             
                                           <%-- <label for="exampleInputEmail1">Valor numerico</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <dx:ASPxSpinEdit ID="spnValorNumerico" runat="server" Number="0" DisplayFormatString="n2">
                                                </dx:ASPxSpinEdit>
                                            </div>--%>
                                        </div>



                                    </div>
                                    <div class="form-group">
                                        <asp:LinkButton ID="btnLimpiar" class="btn btn-light" OnClick="btnLimpiar_Click" runat="server"> Limpiar</asp:LinkButton>
                                        <asp:LinkButton ID="btnIngresar" class="btn btn-success" OnClick="btnIngresar_Click" runat="server"> Guardar </asp:LinkButton>
                                        
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
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <div class="card">
                            <div class="card-header">
                                <h4><i class="mdi mdi-drag">DATOS TRANSACCIONES</i></h4>
                            </div>
                            
                            <div class="card-body">
                                <dx:ASPxGridView ID="dgTransaccion" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="cod_transaccion" Theme="MetropolisBlue">
                                    <SettingsSearchPanel Visible="True" />
                                    <Columns>
                                         <dx:GridViewDataTextColumn Caption="CUENTA CTE" FieldName="codigo_cuenta" Name="CUENTA CTE"  VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="TIPO" FieldName="desc_tipo_transaccion" Name="TIPO" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="MONTO" FieldName="monto_transaccion" Name="MONTO" VisibleIndex="2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="ESTADO" FieldName="desc_estado_transaccion" Name="ESTADO" VisibleIndex="3">
                                        </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="MOTIVO" FieldName="desc_motivo_transaccion" Name="MOTIVO" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="OBERVACION" FieldName="observacion" Name="OBERVACION" VisibleIndex="5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="DESCRIPCION" FieldName="descripcion" Name="DESCRIPCION" VisibleIndex="6">
                                        </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="FECHA TRANSACCION" FieldName="fecha_transaccion" Name="FECHA TRANSACCION" VisibleIndex="7">
                                        </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="FECHA APROBACION" FieldName="fecha_aprobacion" Name="FECHA APROBACION" VisibleIndex="8">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="#" VisibleIndex="8">
                                            <DataItemTemplate>
                                                 <asp:LinkButton ID="btnSeleccionar" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnSeleccionar_Command" CommandArgument='<%# Eval("cod_transaccion")%>'>
                                                            <i class="feather icon-edit-2"></i>                           
                                                </asp:LinkButton>
                                                <%--<asp:LinkButton ID="btnEliminar" class="btn btn-icon btn-rounded btn-outline-danger !important" runat="server" OnCommand="btnEliminar_Command" CommandArgument='<%# Eval("cod_transaccion")%>'>
                                                            RECHAZAR                                    
                                                </asp:LinkButton>--%>
                                            </DataItemTemplate>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="VALOR_CARACTER" FieldName="valor_caracter" Visible="False" VisibleIndex="9">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="VALOR NUMERICO" FieldName="valor_numerico" Visible="False" VisibleIndex="10">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="VALOR EXTRA" FieldName="valor_caracter_extra" Visible="False" VisibleIndex="11">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <label for="exampleInputEmail1">Observaciones</label>
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                            </div>
                            <asp:TextBox ID="txtObservaciones1" Width="100%"  runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="lblObs" runat="server" Text="" Font-Size="Small" ForeColor="Red"></asp:Label>
                        </div>
                         <div class="form-group">
                            <asp:LinkButton ID="lbtnAceptar" class="btn btn-success" OnClick="lbtnAceptar_Click" runat="server"> ACEPTAR</asp:LinkButton>
                            <asp:LinkButton ID="lbtnRechazar" class="btn btn-danger" OnClick="lbtnRechazar_Click" runat="server"> RECHAZAR </asp:LinkButton>
                             <asp:LinkButton ID="lbtnVolver" class="btn btn-light" OnClick="lbtnVolver_Click" runat="server"> Cancelar</asp:LinkButton>
                        </div>
                    </asp:View>
                </asp:MultiView>
               
                        
                    </div>
                </div>
            </div>
        </div>
        <!-- [ Main Content ] end -->
    </div>
    <dx:ASPxHiddenField ID="hfDominio" runat="server"></dx:ASPxHiddenField>


        </ContentTemplate>
    </asp:UpdatePanel>
    



</asp:Content>