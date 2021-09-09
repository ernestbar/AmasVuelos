<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmContactos.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Participante.frmContactos" %>
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
                            <h5 class="m-b-10">Navbar image Layout</h5>
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
                                <h5>Basic Componant</h5>
                            </div>
                            <div class="card-body">
                                <%--<h5>Form controls</h5>--%>
                                <%--  <hr>--%>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Dominio</label>
                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                            </div>
                                            <dx:ASPxTextBox ID="txtDominio" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>
                                        <label for="exampleInputEmail1">Codigo</label>
                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="mdi mdi-barcode"></i></span>
                                            </div>
                                            <dx:ASPxTextBox ID="txtCodigo" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>
                                        <label for="exampleInputEmail1">Descripción</label>
                                        <div class="input-group mb-2">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                            </div>
                                            <dx:ASPxTextBox ID="txtDescripcio" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                        </div>

                                    </div>
                                    <div class="form-group">
                                        <asp:LinkButton ID="btnIngresar" class="btn btn-light" runat="server">
                                                        INGRESAR                                                 
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
                                <h5>Basic Componant</h5>
                            </div>
                            <div class="card-body">
                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%"></dx:ASPxGridView>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <!-- [ Main Content ] end -->
    </div>








    <dx:ASPxHiddenField ID="hfOpciones" runat="server"></dx:ASPxHiddenField>

</asp:Content>
