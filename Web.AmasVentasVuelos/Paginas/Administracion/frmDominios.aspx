<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmDominios.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Administracion.frmDominios" %>

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
                                    <div class="col-3">
                                        <h4><i class="mdi mdi-drag">FORMULARIO DE REGISTRO</i></h4>
                                    </div>
                                    <div class="col-6">
                                        <div class="btn-group mb-3 mr-3">
                                            <dx:ASPxRadioButtonList ID="rdlTipoDominio" runat="server" AutoPostBack="True" EnableTheming="True" OnSelectedIndexChanged="rdlTipoDominio_SelectedIndexChanged" RepeatDirection="Horizontal" SelectedIndex="0" Theme="MetropolisBlue" Width="250px">
                                                <Items>
                                                    <dx:ListEditItem Selected="True" Text="Dominio" Value="0" />
                                                    <dx:ListEditItem Text="Sub dominio" Value="1" />
                                                </Items>
                                                <Border BorderStyle="None" />
                                            </dx:ASPxRadioButtonList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body">
                                <%--<h5>Form controls</h5>--%>                                <%--  <hr>--%>
                                <div class="col-md-12" id="tabDominio">
                                    <div class="form-group">
                                        <div id="_TextoDominio" runat="server">
                                            <blockquote class="blockquote">
                                                <p class="mb-2">El Dominio hace referencia a un grupo de valores representados por una palabra .</p>
                                                <footer class="blockquote-footer">Ejm:<cite title="Source Title">País, Estado civil, Departamento</cite></footer>
                                            </blockquote>
                                            <label for="exampleInputEmail1"><label class="text-danger">(*)</label>Dominio</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                </div>
                                                <dx:ASPxTextBox ID="txtDominio" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <div id="_ComboTipoDominio" runat="server">
                                            <blockquote class="blockquote">
                                                <p class="mb-2">El sub dominio hace referencia a los detalles de un grupo o un valor agrupador.</p>
                                                <footer class="blockquote-footer">Ejm:<cite title="Source Title">Si el dominio es País, entonces los sub dominios pueden ser Bolivia, Perú, Chile, etc</cite></footer>
                                            </blockquote>
                                            <label for="exampleInputEmail1"><label class="text-danger">(*)</label>Dominio</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-gesture-tap"></i></span>
                                                </div>
                                                <dx:ASPxComboBox ID="ddlTipoDominio" Width="90%" runat="server" CssClass="form-control" EnableTheming="False" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDominio_SelectedIndexChanged">
                                                    <DropDownButton Visible="False">
                                                    </DropDownButton>
                                                </dx:ASPxComboBox>
                                            </div>
                                        </div>
                                        <div id="_COMODIN" runat="server">

                                            <label for="exampleInputEmail1"><label class="text-danger">(*)</label>Codigo</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <dx:ASPxTextBox ID="txtCodigo" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                            </div>
                                            <label for="exampleInputEmail1"><label class="text-danger">(*)</label>Descripción</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                </div>
                                                <dx:ASPxTextBox ID="txtDescripcion" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                            </div>
                                            <label for="exampleInputEmail1">Valor caracter</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <dx:ASPxTextBox ID="txtValorCaracter" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                            </div>
                                            <label for="exampleInputEmail1">Valor caracter Extra</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <dx:ASPxTextBox ID="txtValorCaracterExtra" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                            </div>
                                            <label for="exampleInputEmail1">Valor numerico</label>
                                            <div class="input-group mb-2">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                                </div>
                                                <dx:ASPxSpinEdit ID="spnValorNumerico" runat="server" Number="0" DisplayFormatString="n2">
                                                </dx:ASPxSpinEdit>
                                            </div>
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
                        <div class="card">
                            <div class="card-header">
                                <h4><i class="mdi mdi-drag">DATOS DE LOS DOMINIOS</i></h4>
                            </div>
                            <div class="card-body">
                                <dx:ASPxGridView ID="dgDominios" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="codigo" Theme="MetropolisBlue">
                                    <SettingsSearchPanel Visible="True" />
                                    <Columns>
                                         <dx:GridViewDataTextColumn Caption="DOMINIO" FieldName="dominio" Name="dominio"  VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="CODIGO" FieldName="codigo" Name="CODIGO" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="DESCRIPCION" FieldName="descripcion" Name="DESCRIPCION" VisibleIndex="2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="#" VisibleIndex="3">
                                            <DataItemTemplate>
                                                 <asp:LinkButton ID="btnModificar" class="btn btn-icon btn-rounded btn-outline-warning !important" runat="server" OnCommand="btnModificar_Command" CommandArgument='<%# Eval("dominio") +"|"+ Eval("codigo")+"|"+ Eval("descripcion")  +"|"+ Eval("valor_caracter")%>'>
                                                            <i class="feather icon-edit-2"></i>                                    
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnEliminar" class="btn btn-icon btn-rounded btn-outline-danger !important" runat="server" OnCommand="btnEliminar_Command" CommandArgument='<%# Eval("dominio") +"|"+ Eval("codigo") %>'>
                                                            <i class="feather icon-trash-2"></i>                                    
                                                </asp:LinkButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="VALOR_CARACTER" FieldName="valor_caracter" Visible="False" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="VALOR NUMERICO" FieldName="valor_numerico" Visible="False" VisibleIndex="5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="VALOR EXTRA" FieldName="valor_caracter_extra" Visible="False" VisibleIndex="6">
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
    <dx:ASPxHiddenField ID="hfDominio" runat="server"></dx:ASPxHiddenField>



           </ContentTemplate>
    </asp:UpdatePanel> 



</asp:Content>












