<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmResetPassword.aspx.cs" Inherits="Web.AmasVentasVuelos.frmResetPassword" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cambiar contraseña</title>
</head>
<link rel="icon" href="favicon.ico" type="image/x-icon">
<!-- fontawesome icon -->
<link rel="stylesheet" href="assets/fonts/fontawesome/css/fontawesome-all.min.css">
<!-- animation css -->
<link rel="stylesheet" href="assets/plugins/animation/css/animate.min.css">

<!-- vendor css -->
<link rel="stylesheet" href="assets/css/style.css">

<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="description" content="" />
<meta name="keywords" content="">
<body>
    <script src="assets/js/vendor-all.min.js"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <form id="form1" runat="server">
        <div class="auth-wrapper">
            <!-- [ change-password ] start -->
            <div class="auth-content container">
                <div class="card">
                    <div class="row align-items-center">
                        <div class="col-md-6">
                            <div class="card-body">
                                <img src="assets/images/amaszonas/logo.png" alt="" class="img-fluid mb-4">
                                <br />
                                <div class="form-group">

                                    <div class="alert alert-success" role="alert" id="_exito" runat="server">
                                        <asp:Literal ID="lblExito" runat="server"></asp:Literal>

                                    </div>
                                    <div class="alert alert-danger" role="alert" id="_error" runat="server">
                                        <asp:Literal ID="lblError" runat="server"></asp:Literal>
                                    </div>

                                    <asp:LinkButton ID="btnCambiarContrasenia" class="btn btn-success !important" OnClick="btnCambiarContrasenia_Click" runat="server">Cambiar</asp:LinkButton>
                                    <asp:LinkButton ID="btnVolver" class="btn btn-primary !important" OnClick="btnVolver_Click" runat="server">volver atras</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 d-none d-md-block">
                            <img src="assets/images/amaszonas/NUEVO_slider_web_2-actualizado-min.jpg" alt="" class="img-fluid">
                        </div>
                    </div>
                </div>
            </div>
            <!-- [ change-password ] end -->
        </div>
    </form>
</body>
</html>
