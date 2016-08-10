<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Proveedores_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
<div class="divs">
<h2>Ingreso de Provedores</h2>
<table width="99%">
<tr>
<td>Código: </td>
<td style="width:85%">
    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox> </td>
</tr>
<tr>
<td>Denominación: </td>
<td><asp:TextBox ID="txtNombre" runat="server" Width="80%"></asp:TextBox></td>
</tr>
<tr>
<td>Descripción: </td>
<td><asp:TextBox ID="txtDescripcion" runat="server" Width="80%"></asp:TextBox> </td>
</tr>
<tr>
<td>CUIT: </td>
<td><asp:TextBox ID="txtCuit" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Teléfono/Fax: </td>
<td><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Domicilio: </td>
<td><asp:TextBox ID="txtDomicilio" runat="server" Width="80%"></asp:TextBox></td>
</tr>
<tr>
<td>Tipo Proveedor: </td>
<td><asp:DropDownList ID="ddlTProveedor" runat="server" DataTextField="nombre" DataValueField="idTipoProveedor" ToolTip="Seleccionar el Tipo">
    </asp:DropDownList> </td>
</tr>
<tr>
<td>Correo Electrónico: </td>
<td><asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Observaciones: </td>
<td><asp:TextBox ID="txtObservaciones" runat="server" Width="80%" TextMode="MultiLine"
                    Rows="3"></asp:TextBox></td>
</tr>
</table>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
 <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" />
    <input type="button" value="Cancelar" title="Cancela la Edición y vuelve a la página anterior" onclick="history.go(-1)" />
</asp:Content>

