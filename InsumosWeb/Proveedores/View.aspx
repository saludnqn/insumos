<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="View.aspx.cs" Inherits="Proveedores_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Datos del Proveedor</h2>
        <table width="80%">
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
                <td>
                    Descripción:
                    <asp:Label runat="server" ID="lblDescripcion"></asp:Label>
                </td>
                <td>
                    CUIT:
                    <asp:Label runat="server" ID="lblCuit"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Teléfono:
                    <asp:Label runat="server" ID="lblTelefono"></asp:Label>
                </td>
                <td>
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Proveedor" ToolTip="Ingresar Nuevo Proveedor"
        OnClick="btnNuevo_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEditar" runat="server" Text="Editar Proveedor" ToolTip="Editar datos del Proveedor"
        OnClick="btnEditar_Click" />
</asp:Content>
