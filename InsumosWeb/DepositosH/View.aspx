<%@ Page Title="Datos del Depósito" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="DepositosH_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server"> <b>Configuración</b>
<div class="container">
    <div class="divs"><h2>Datos Del Depósito</h2>
    </div>
    <br />
    <div class="form-horizontal">
                    <div class="row">                        
                            <label for="lblEfector" class="control-label col-md-2"> Efector:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblEfector" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="row">
                            <label class="control-label col-md-2"> Servicio:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblServicio" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="row">
                            <label class="control-label col-md-2"> Depósito Superior:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblDepSuperior" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="row">
                            <label class="control-label col-md-2"> Tipo Depósito:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblTipoDep" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="row">
                            <label class="control-label col-md-2"> Nombre Depósito:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="row">
                            <label class="control-label col-md-2"> Descripción:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="row">
                            <label class="control-label col-md-2"> Observaciones:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblObservaciones" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="row">
                            <label class="control-label col-md-2"> Estado:</label>
                            <div class="col-md-5">
                                <asp:Label ID="lblActivo" runat="server"></asp:Label>
                            </div>                        
                    </div>
        </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
    <div class="container">
        <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>                                
        </div>
    </div>
    <br />

</asp:Content>

