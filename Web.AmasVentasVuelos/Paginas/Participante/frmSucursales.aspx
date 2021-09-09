<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmSucursales.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.Participante.frmSucursales" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <h5 class="m-b-10">Registro de sucursales</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmIndex1.aspx"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#!">Formulario de registro</a></li>
                            <li class="breadcrumb-item"><a href="#!">Sucursales</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->

        <div class="row">
            <!-- [ tabs ] start -->
            <div class="col-sm-12">
                <h5>Formulario de registro y asignación</h5>
                <hr>
                <ul class="nav nav-tabs" id="myTab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active text-uppercase" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Sucursales</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link text-uppercase" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Asignar sucursal al participante</a>
                    </li>

                </ul>
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <div class="row">
                            <div class="col-md-5">
                                <div class="row">
                                    <!-- [ form-element ] start -->
                                    <div class="col-sm-12">
                                        <div class="card">
                                            <div class="card-header">
                                                <h5>Registro de sucursal</h5>
                                            </div>
                                            <div class="card-body">
                                                <%--<h5>Form controls</h5>--%>
                                                <%--  <hr>--%>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">País</label>
                                                        <div class="input-group mb-2">

                                                            <dx:ASPxComboBox ID="ddlPais" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                        </div>

                                                        <label for="exampleInputEmail1">Ciudad</label>
                                                        <div class="input-group mb-2">

                                                            <dx:ASPxComboBox ID="ddlCiudad" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                        </div>

                                                        <label for="exampleInputEmail1">Dirección</label>
                                                        <div class="input-group mb-2">
                                                            <dx:ASPxTextBox ID="txtDireccion" runat="server" Width="100%"></dx:ASPxTextBox>
                                                        </div>
                                                        <div class="row">

                                                            <div id="map"></div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <label for="exampleInputEmail1">Latitud</label>
                                                                <div class="input-group mb-2">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="mdi mdi-compass"></i></span>
                                                                    </div>
                                                                    <dx:ASPxTextBox ID="txtLatitud" runat="server" EnableTheming="false" CssClass="form-control" ClientInstanceName="ctxtLatitud" EnableClientSideAPI="true"></dx:ASPxTextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <label for="exampleInputEmail1">Longitud</label>
                                                                <div class="input-group mb-2">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="mdi mdi-compass"></i></span>
                                                                    </div>
                                                                    <dx:ASPxTextBox ID="txtLongitud" runat="server" EnableTheming="false" CssClass="form-control" ClientInstanceName="ctxtLongitud" EnableClientSideAPI="true"></dx:ASPxTextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="form-group">
                                                        <asp:LinkButton ID="btnRegistrarSucursal" class="btn btn-success" runat="server" OnClick="btnRegistrarSucursal_Click">Registrar</asp:LinkButton>
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
                                                <h5>Datos de sucursales</h5>
                                            </div>
                                            <div class="card-body">
                                                <div class="dt-responsive table-responsive">
                                                    <table id="simpletable" class="table table-striped table-bordered nowrap">
                                                        <thead>
                                                            <tr>
                                                                <th>Name</th>
                                                                <th>Position</th>
                                                                <th>Office</th>
                                                                <th>Age</th>
                                                                <th>Start date</th>
                                                                <th>Salary</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>Quinn Flynn</td>
                                                                <td>System Architect</td>
                                                                <td>Edinburgh</td>
                                                                <td>61</td>
                                                                <td>2011/04/25</td>
                                                                <td>$320,800</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Garrett Winters</td>
                                                                <td>Accountant</td>
                                                                <td>Tokyo</td>
                                                                <td>63</td>
                                                                <td>2011/07/25</td>
                                                                <td>$170,750</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Ashton Cox</td>
                                                                <td>Junior Technical Author</td>
                                                                <td>San Francisco</td>
                                                                <td>66</td>
                                                                <td>2009/01/12</td>
                                                                <td>$86,000</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Cedric Kelly</td>
                                                                <td>Senior Javascript Developer</td>
                                                                <td>Edinburgh</td>
                                                                <td>22</td>
                                                                <td>2012/03/29</td>
                                                                <td>$433,060</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Airi Satou</td>
                                                                <td>Accountant</td>
                                                                <td>Tokyo</td>
                                                                <td>33</td>
                                                                <td>2008/11/28</td>
                                                                <td>$162,700</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Brielle Williamson</td>
                                                                <td>Integration Specialist</td>
                                                                <td>New York</td>
                                                                <td>61</td>
                                                                <td>2012/12/02</td>
                                                                <td>$372,000</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Herrod Chandler</td>
                                                                <td>Sales Assistant</td>
                                                                <td>San Francisco</td>
                                                                <td>59</td>
                                                                <td>2012/08/06</td>
                                                                <td>$137,500</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Rhona Davidson</td>
                                                                <td>Integration Specialist</td>
                                                                <td>Tokyo</td>
                                                                <td>55</td>
                                                                <td>2010/10/14</td>
                                                                <td>$327,900</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Colleen Hurst</td>
                                                                <td>Javascript Developer</td>
                                                                <td>San Francisco</td>
                                                                <td>39</td>
                                                                <td>2009/09/15</td>
                                                                <td>$205,500</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Sonya Frost</td>
                                                                <td>Software Engineer</td>
                                                                <td>Edinburgh</td>
                                                                <td>23</td>
                                                                <td>2008/12/13</td>
                                                                <td>$103,600</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Jena Gaines</td>
                                                                <td>Office Manager</td>
                                                                <td>London</td>
                                                                <td>30</td>
                                                                <td>2008/12/19</td>
                                                                <td>$90,560</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Quinn Flynn</td>
                                                                <td>Support Lead</td>
                                                                <td>Edinburgh</td>
                                                                <td>22</td>
                                                                <td>2013/03/03</td>
                                                                <td>$342,000</td>
                                                            </tr>

                                                        </tbody>
                                                        <tfoot>
                                                            <tr>
                                                                <th>Name</th>
                                                                <th>Position</th>
                                                                <th>Office</th>
                                                                <th>Age</th>
                                                                <th>Start date</th>
                                                                <th>Salary</th>
                                                            </tr>
                                                        </tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                        <div class="row">
                            <div class="col-md-5">
                                <div class="row">
                                    <!-- [ form-element ] start -->
                                    <div class="col-sm-12">
                                        <div class="card">
                                            <div class="card-header">
                                                <h5>Asignar participante a la sucursal</h5>
                                            </div>
                                            <div class="card-body">
                                                <%--<h5>Form controls</h5>--%>
                                                <%--  <hr>--%>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">Tipo participante</label>
                                                        <div class="input-group mb-2">
                                                            <dx:ASPxComboBox ID="ddlTipoParticipante" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                        </div>
                                                        <label for="exampleInputEmail1">Participante</label>
                                                        <div class="input-group mb-2">

                                                            <dx:ASPxComboBox ID="ddlParticipante" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                        </div>

                                                        <label for="exampleInputEmail1">Sucursal</label>
                                                        <div class="input-group mb-2">

                                                            <dx:ASPxComboBox ID="ddlSucursal" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:LinkButton ID="btnRegistrarSucursals" class="btn btn-success" runat="server">Registrar</asp:LinkButton>
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
                                                <h5>Datos</h5>
                                            </div>
                                            <div class="card-body">
                                                <div class="dt-responsive table-responsive">
                                                    <table id="simpletable" class="table table-striped table-bordered nowrap">
                                                        <thead>
                                                            <tr>
                                                                <th>Name</th>
                                                                <th>Position</th>
                                                                <th>Office</th>
                                                                <th>Age</th>
                                                                <th>Start date</th>
                                                                <th>Salary</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>Quinn Flynn</td>
                                                                <td>System Architect</td>
                                                                <td>Edinburgh</td>
                                                                <td>61</td>
                                                                <td>2011/04/25</td>
                                                                <td>$320,800</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Garrett Winters</td>
                                                                <td>Accountant</td>
                                                                <td>Tokyo</td>
                                                                <td>63</td>
                                                                <td>2011/07/25</td>
                                                                <td>$170,750</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Ashton Cox</td>
                                                                <td>Junior Technical Author</td>
                                                                <td>San Francisco</td>
                                                                <td>66</td>
                                                                <td>2009/01/12</td>
                                                                <td>$86,000</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Cedric Kelly</td>
                                                                <td>Senior Javascript Developer</td>
                                                                <td>Edinburgh</td>
                                                                <td>22</td>
                                                                <td>2012/03/29</td>
                                                                <td>$433,060</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Airi Satou</td>
                                                                <td>Accountant</td>
                                                                <td>Tokyo</td>
                                                                <td>33</td>
                                                                <td>2008/11/28</td>
                                                                <td>$162,700</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Brielle Williamson</td>
                                                                <td>Integration Specialist</td>
                                                                <td>New York</td>
                                                                <td>61</td>
                                                                <td>2012/12/02</td>
                                                                <td>$372,000</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Herrod Chandler</td>
                                                                <td>Sales Assistant</td>
                                                                <td>San Francisco</td>
                                                                <td>59</td>
                                                                <td>2012/08/06</td>
                                                                <td>$137,500</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Rhona Davidson</td>
                                                                <td>Integration Specialist</td>
                                                                <td>Tokyo</td>
                                                                <td>55</td>
                                                                <td>2010/10/14</td>
                                                                <td>$327,900</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Colleen Hurst</td>
                                                                <td>Javascript Developer</td>
                                                                <td>San Francisco</td>
                                                                <td>39</td>
                                                                <td>2009/09/15</td>
                                                                <td>$205,500</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Sonya Frost</td>
                                                                <td>Software Engineer</td>
                                                                <td>Edinburgh</td>
                                                                <td>23</td>
                                                                <td>2008/12/13</td>
                                                                <td>$103,600</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Jena Gaines</td>
                                                                <td>Office Manager</td>
                                                                <td>London</td>
                                                                <td>30</td>
                                                                <td>2008/12/19</td>
                                                                <td>$90,560</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Quinn Flynn</td>
                                                                <td>Support Lead</td>
                                                                <td>Edinburgh</td>
                                                                <td>22</td>
                                                                <td>2013/03/03</td>
                                                                <td>$342,000</td>
                                                            </tr>

                                                        </tbody>
                                                        <tfoot>
                                                            <tr>
                                                                <th>Name</th>
                                                                <th>Position</th>
                                                                <th>Office</th>
                                                                <th>Age</th>
                                                                <th>Start date</th>
                                                                <th>Salary</th>
                                                            </tr>
                                                        </tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>


        </div>




        <!-- [ Main Content ] end -->
    </div>


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

                var infowindow = new google.maps.InfoWindow({
                    content: 'Latitud: ' + location.lat() + '<br>Longitud: ' + location.lng()
                });
                //infowindow.open(map, marker);
            }

            google.maps.event.addListener(map, 'click', function (event) {
                placeMarker(event.latLng);
            });

            const input = document.getElementById("ctxtDirecciones");

            google.maps.event.addDomListener(window, 'load', function () {
                var places = new google.maps.places.Autocomplete(document.getElementById('ctxtDirecciones'));
                google.maps.event.addListener(places, 'place_changed', function () {
                    var place = places.getPlace();
                    var address = place.formatted_address;
                    var latitude = place.geometry.location.lat();
                    var longitude = place.geometry.location.lng();
                    var mesg = "Address: " + address;
                    mesg += "\nLatitude: " + latitude;
                    mesg += "\nLongitude: " + longitude;
                    alert(mesg);
                });
            });
        }




        window.onload = initMap;
    </script>

    <dx:ASPxHiddenField ID="hfOpciones" runat="server"></dx:ASPxHiddenField>

</asp:Content>
