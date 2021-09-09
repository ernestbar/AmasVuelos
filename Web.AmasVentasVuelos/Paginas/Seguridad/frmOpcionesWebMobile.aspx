<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmOpcionesWebMobile.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Seguridad.frmOpcionesWebMobile" %>

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
                            <h5 class="m-b-10">Opciones de acceso en la Web y Mobile</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Seguridad</a></li>
                            <li class="breadcrumb-item"><a href="#!">Opciones Web Mobile</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->

        <dx:ASPxTabControl ID="ASPxTabControl1" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="ASPxTabControl1_ActiveTabChanged" Theme="MetropolisBlue" Width="100%">
            <Tabs>
                <dx:Tab Name="Por usuario" Text="Mobile" Visible="false" >
                </dx:Tab>
                <dx:Tab Name="Por pregunta" Text="Web">
                </dx:Tab>
            </Tabs>
            <ActiveTabStyle BackColor="#2CA961" ForeColor="White">
            </ActiveTabStyle>
        </dx:ASPxTabControl>


        <asp:MultiView ID="mv" runat="server" OnActiveViewChanged="mv_ActiveViewChanged">
            <asp:View ID="PorMobile" runat="server">
                En construccion
              <%--  <div class="row">
                    <div class="col-md-5">
                        <div class="row">
                            
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>Datos</h5>
                                    </div>
                                    <div class="card-body">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                    <label for="exampleInputEmail1">Menu padre</label>
                                                    <div class="input-group mb-2">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                        </div>
                                                        <dx:ASPxComboBox ID="ddlMenuMobile" runat="server" ValueType="System.String" Width="80%"></dx:ASPxComboBox>

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
                            
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>Basic Componant</h5>
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
                </div>--%>
            </asp:View>

            <asp:View ID="PorWeb" runat="server">
                <div class="row">
                    <div class="col-md-5">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                             <h4><i class="mdi mdi-drag">FORMULARIO DE REGISTRO DE OPCIONES WEB</i></h4> 
                                        
                                    </div>
                                    <div class="card-body">
                                        <%--<h5>Form controls</h5>--%>
                                        <%--  <hr>--%>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label for="exampleInputEmail1">Menu</label>
                                                    <div class="input-group mb-2">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                        </div>
                                                        <dx:ASPxComboBox ID="ddlOpcionWeb" runat="server" ValueType="System.String" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuWeb_SelectedIndexChanged"></dx:ASPxComboBox>
                                                    </div>
                                                    <label for="exampleInputEmail1">Id menu web opcion</label>
                                                    <div class="input-group mb-2">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                        </div>
                                                        <dx:ASPxTextBox ID="txtIdOpcionWeb" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                    </div>
                                                    <label for="exampleInputEmail1">Nombre de la opcion web</label>
                                                    <div class="input-group mb-2">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                        </div>
                                                        <dx:ASPxTextBox ID="txtNombreOpcionWeb" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                    </div>
                                                    <label for="exampleInputEmail1">Descripción </label>
                                                    <div class="input-group mb-2">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="mdi mdi-text-subject"></i></span>
                                                        </div>
                                                        <dx:ASPxTextBox ID="txtDescripcionOpcionWeb" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                                    </div>

                                                </div>
                                                <div class="form-group">
                                                     <asp:LinkButton ID="btnLimpiar" class="btn btn-light" OnClick="btnLimpiar_Click" runat="server"> LIMPIAR</asp:LinkButton>
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
                    </div>
               
                <div class="col-md-7">
                    <div class="row">
                        <!-- [ form-element ] start -->
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-header">
                                         <h4><i class="mdi mdi-drag">DATOS DE LAS OPCIONES </i></h4>                                     
                                </div>
                                <div class="card-body">
                                    <dx:ASPxGridView ID="dgMenuWeb" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="menu_web_opcion">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="#" VisibleIndex="6">
                                                <DataItemTemplate>
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:LinkButton ID="btnActivarWeb" runat="server" class="btn btn-icon btn-rounded btn-outline-success !important" CommandArgument='<%# Eval("menu_web_opcion")%>' OnCommand="btnActivarWeb_Command">
                                                           
                                                            <i class="feather icon-check"></i>                                    
                                                                                                    
                                                                                                   
                                                            </asp:LinkButton>
                                                        </div>
                                                        <div class="col">
                                                            <asp:LinkButton ID="btnModificarWeb" runat="server" class="btn btn-icon btn-rounded btn-outline-warning !important" CommandArgument='<%# Eval("menu_web_opcion")%>' OnCommand="btnModificarWeb_Command">
                                                           
                                                            <i class="feather icon-edit-2"></i>                                    
                                                                                                    
                                                                                                   
                                                            </asp:LinkButton>
                                                        </div>
                                                        <div class="col">
                                                            <asp:LinkButton ID="btnEliminarWeb" runat="server" class="btn btn-icon btn-rounded btn-outline-danger !important" CommandArgument='<%# Eval("menu_web_opcion")%>' OnCommand="btnEliminarWeb_Command">
                                                           
                                                            <i class="feather icon-trash-2"></i>                                    
                                                                                                    
                                                                                                   
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="menu_web_opcion" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="MENU" FieldName="menu" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="NOMBRE" FieldName="nombre_opcion" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="ESTADO" FieldName="estado" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="DESCRIPCION" FieldName="descripcion" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="FECHA CREACION" FieldName="fecha_creacion" VisibleIndex="5"></dx:GridViewDataTextColumn>
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

    <dx:ASPxHiddenField ID="hfOpcionesWebMobile" runat="server"></dx:ASPxHiddenField>
                                        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
