<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="Web.AmasVentasVuelos.frmLogin" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="" />
    <meta name="keywords" content="">
    <meta name="author" content="" />


    <title>Amaszonas</title>
    <!-- Favicon icon -->
    <!--<link rel="icon" href="../assets/images/favicon.ico" type="image/x-icon">-->
    <!-- fontawesome icon -->
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" href="assets/fonts/fontawesome/css/fontawesome-all.min.css" />
    <!-- animation css -->
    <link rel="stylesheet" href="assets/plugins/animation/css/animate.min.css" />
    <!-- vendor css -->
    <link rel="stylesheet" href="assets/css/style.css" />
    <link rel="stylesheet" href="@sweetalert2/theme-material-ui/material-ui.css" />
</head>
>
<body>
       <!-- Required Js -->
        <script src="assets/js/vendor-all.min.js"></script>
        <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/plugins/sweetalert/js/sweetalert.min.js"></script>
    

    <form id="form1" runat="server" defaultbutton="btnIngresar">
         <!-- [ signin-img-slider ] start -->
        <div class="blur"></div>
        <div class="auth-wrapper">
            <div class="auth-content container">
                <div class="card">
                    <div class="row align-items-center">
                        <div class="col-md-6">
                            <div class="card-body">
                                <img src="<%=Page.ResolveUrl("~/assets/images/amaszonas/LOGO.png") %>" alt="" class="img-fluid mb-4"/>
                                <h4 class="mb-3 f-w-400">Bienvenidos al sistema de Amaszonas </h4>
                                <div class="alert alert-danger" role="alert" id="mensaje" runat="server">
                                    <asp:Literal ID="ltrlMensaje" runat="server"></asp:Literal>
										</div>
                                <div class="input-group mb-2">
                                    <div class="input-group-prepend">
                                       <label class="text-danger">(*)</label>Usuario :
                                    </div>
                                    <br />
                                    <dx:ASPxTextBox ID="txtUsuario" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                </div>

                                <div class="input-group mb-2">
                                    <div class="input-group-prepend">
                                        <label class="text-danger">(*)</label>Contraseña:
                                    </div>
                                    <br />
                                    <dx:ASPxTextBox ID="txtContrasenia" Password="true" runat="server" EnableTheming="false" CssClass="form-control"></dx:ASPxTextBox>
                                </div>
                                <asp:LinkButton ID="btnIngresar" class="btn btn-success" runat="server" TabIndex="0" OnClick="btnIngresar_Click">
                                                        INGRESAR                                                 
                                                </asp:LinkButton>
                            

                            </div>
                        </div>
                        <div class="col-md-6 d-none d-md-block">
                            <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
                                <ol class="carousel-indicators">
                                    <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                                    <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
                                    <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
                                    <li data-target="#carouselExampleCaptions" data-slide-to="3"></li>
                                    <li data-target="#carouselExampleCaptions" data-slide-to="4"></li>
                                    <li data-target="#carouselExampleCaptions" data-slide-to="5"></li>
                                    
                                </ol>
                                <div class="carousel-inner">
                                    <div class="carousel-item active">
                                        <img src="<%=Page.ResolveUrl("~/assets/images/amaszonas/1.jpg") %>"  style="height: 20vw;" alt="" class="img-fluid bd-placeholder-img bd-placeholder-img-lg d-block w-100"/>                                     
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%=Page.ResolveUrl("~/assets/images/amaszonas/2.jpg") %>"  style="height: 20vw;" alt="" class="img-fluid bd-placeholder-img bd-placeholder-img-lg d-block w-100"/>                                     
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%=Page.ResolveUrl("~/assets/images/amaszonas/3.jpg") %>"  style="height: 25vw;" alt="" class="img-fluid bd-placeholder-img bd-placeholder-img-lg d-block w-100"/>                                     
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%=Page.ResolveUrl("~/assets/images/amaszonas/4.jpg") %>"  style="height: 25vw;" alt="" class="img-fluid bd-placeholder-img bd-placeholder-img-lg d-block w-100"/>                                     
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%=Page.ResolveUrl("~/assets/images/amaszonas/5.jpg") %>"  style="height: 25vw;" alt="" class="img-fluid bd-placeholder-img bd-placeholder-img-lg d-block w-100"/>                                     
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%=Page.ResolveUrl("~/assets/images/amaszonas/6.jpg") %>"  style="height: 25vw;" alt="" class="img-fluid bd-placeholder-img bd-placeholder-img-lg d-block w-100"/>                                     
                                    </div>

                                    
                                </div>
                                <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev"><span class="carousel-control-prev-icon" aria-hidden="true"></span></a>
                                <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next"><span class="carousel-control-next-icon" aria-hidden="true"></span></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ signin-img-slider ] end -->
    </form>
</body>
</html>
