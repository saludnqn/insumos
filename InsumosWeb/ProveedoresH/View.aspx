<%@ Page Title="Datos del Proveedor" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="ProveedoresH_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>DATOS DEL PROVEEDOR</label>
    </section>
    </br>
    <table class="mGrid">
        
        <tr>
            <td>
                Código:
                <asp:Label runat="server" ID="lblCodigo"></asp:Label>
            </td>
            <td>
                Denominación:
                <asp:Label runat="server" ID="lblNombre"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Descripción:
                <asp:Label runat="server" ID="lblDescripcion"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                CUIT:
                <asp:Label runat="server" ID="lblCuit"></asp:Label>
            </td>
            <td>
                Teléfono:
                <asp:Label runat="server" ID="lblTelefono"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Domicilio:
                <asp:Label runat="server" ID="lblDomicilio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Tipo Proveedor:
                <asp:Label runat="server" ID="lblTProveedor"></asp:Label>
            </td>
            <td>
                Correo Electrónico:
                <asp:Label runat="server" ID="lblCorreoE"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Observaciones:
                <asp:Label runat="server" ID="lblObservaciones"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
<div class="container">
        <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
               <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClientClick="history.go(-1)" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Volver
                </asp:LinkButton>
            </div>
        </div>                                
    </div>
    </br>
</asp:Content>
