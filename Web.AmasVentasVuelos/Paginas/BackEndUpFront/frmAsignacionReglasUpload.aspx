<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAmaszonas.Master" AutoEventWireup="true" CodeBehind="frmAsignacionReglasUpload.aspx.cs" Inherits="Web.AmasVentasVuelos.Paginas.BackEndUpFront.frmAsignacionReglasUpload" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="row">
                    <div class="col-md-3">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>LISTADO DE REGLAS UPFRONT</h5>
                                    </div>

                                   <%-- <div class="alert alert-danger" role="alert">
                                        Los campos con  (*) son valores obligatorios que deben ser completados
                                    </div>--%>

                                    <div class="card-body">
                                      
                                        <div class="col-md-12">
                                            <div class="form-group">

                                 

                                                <label for="exampleInputEmail1">Buscar Reglas</label>
                                                <div class="input-group mb-2">
                                                    <asp:TextBox ID="txtBuscarRegla1"  CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:LinkButton ID="btnBucsarRegla" class="btn btn-success" OnClick="btnBucsarRegla_Click" runat="server" >Buscar</asp:LinkButton>
                                                    </div>
                                                </div>
                                                <asp:CheckBox ID="cbReglasTodos" Text="Todas las reglas" OnCheckedChanged="cbReglasTodos_CheckedChanged" AutoPostBack="true" runat="server" />
                                                <asp:Label ID="lblAvisoReglas" runat="server" Font-Size="Small" ForeColor="Red" Text=""></asp:Label>
                                                
                                                <div class="input-group mb-2">
                                                   
                                                    <div style="overflow-y: auto; height:300px;width:100%">
                                                        
                                                    <asp:CheckBoxList ID="cblReglas" CssClass="form-control" runat="server"></asp:CheckBoxList>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
         
                     <div class="col-md-3">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>LISTADO DE PARTICIPANTES</h5>
                                    </div>

                                   
                                    <div class="card-body">
                                      
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Tipo Participante:</label>
                                                <div class="input-group mb-2">
                                                    <asp:DropDownList ID="ddlTipoParticipante" OnSelectedIndexChanged="ddlTipoParticipante_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"  runat="server"></asp:DropDownList>
                                                </div>
                                 

                                                <label for="exampleInputEmail1">Buscar Participante</label>
                                                <div class="input-group mb-2">
                                                    <asp:TextBox ID="txtBuscarParticipante"  CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:LinkButton ID="lbtnBuscaarParticipante" class="btn btn-success" OnClick="lbtnBuscaarParticipante_Click" runat="server" >Buscar</asp:LinkButton>
                                                    </div>
                                                </div>
                                                <asp:CheckBox ID="cbParticipanteTodos" Text="Todas los participantes" OnCheckedChanged="cbParticipanteTodos_CheckedChanged" AutoPostBack="true" runat="server" />
                                                <asp:Label ID="lblAvisoParticipante" runat="server" Font-Size="Small" ForeColor="Red" Text=""></asp:Label>
                                                <div class="input-group mb-2">
                                                    <div style="overflow-y: auto; height:210px;width:100%"> 
                                                    <asp:CheckBoxList ID="cblParticipantes" CssClass="form-control" runat="server"></asp:CheckBoxList>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
         <div class="col-md-2">
            <br /><br /><br /><br /><br /><br /><br />
               <div class="row">
                   
                    <div class="col-md-2">
                        <asp:LinkButton ID="lbtnAsignar" class="btn btn-success" OnClick="lbtnAsignar_Click" runat="server" >Asignar</asp:LinkButton>
                    </div>
                </div>
               <%-- <div class="row">
                    <div class="col-md-1">
                        <asp:LinkButton ID="lbtnQuitar" class="btn btn-success w-100%" runat="server" >Quitar</asp:LinkButton>
                    </div>
                </div>--%>
          </div>
        <div class="col-md-3">
                        <div class="row">
                            <!-- [ form-element ] start -->
                            <div class="col-sm-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h5>REGLAS UPFRONT ASIGNADAS</h5>
                                    </div>

                                 

                                    <div class="card-body">
                                      
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                 <label for="exampleInputEmail1">Tipo Participante:</label>
                                                <div class="input-group mb-2">
                                                    <asp:DropDownList ID="ddlTipoParticipante2" OnSelectedIndexChanged="ddlTipoParticipante2_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"  runat="server"></asp:DropDownList>
                                                </div>
                                                <label class="text-danger">(*)</label>
                                                <label for="exampleInputEmail1">Buscar Participante</label>
                                                <div class="input-group mb-2">
                                                    <%--<asp:DropDownList ID="ddlParticipantes" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlParticipantes_SelectedIndexChanged" runat="server"></asp:DropDownList>--%>
                                                    <dx:ASPxComboBox ID="ddlParticipanteReglas" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlParticipanteReglas_SelectedIndexChanged" Width="100%" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                                </div>
                                                 <div class="row">
                                                     <label for="exampleInputEmail1">Si desea quitar una regla, deseleccione la regla y presione Quitar</label>
                                                  
                                                </div>
                                                <label for="exampleInputEmail1">Reglas asignadas</label>
                                                <div class="input-group mb-2">
                                                    <asp:CheckBoxList ID="cblReglasAsigandas" CssClass="form-control" runat="server"></asp:CheckBoxList>
                                                </div>
                                                  <div class="col-md-12">
                                                        <asp:LinkButton ID="btnQuiarReglaParticipante" OnClick="btnQuiarReglaParticipante_Click" class="btn btn-success" runat="server" >Quitar</asp:LinkButton>
                                                    </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

             </ContentTemplate>
    </asp:UpdatePanel>
   <%-- <asp:HiddenField ID="hfCustomerId" runat="server" />
<script type="text/javascript">
        $(function () {
            $("[id$=txtParticipanteB]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx?op=GetCustomers") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('|')[0],
                                    val: item.split('|')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
		});

</script>--%>
</asp:Content>
