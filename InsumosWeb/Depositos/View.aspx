<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Depositos_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
<h2>Datos Del Depósito</h2>
<table>
<tr>
<td>Efector: <asp:Label ID="lblEfector" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Servicio: <asp:Label ID="lblServicio" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Depósito Superior: <asp:Label ID="lblDepSuperior" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Tipo Depósito: <asp:Label ID="lblTipoDep" runat="server"></asp:Label></td>
</tr>
<tr>
<td colspan="2">Nombre Depósito: <asp:Label ID="lblDeposito" runat="server"></asp:Label></td>
</tr>
<tr>
<td colspan="2">Descripcion: <asp:Label ID="lblDescripcion" runat="server"></asp:Label></td>
</tr>
<tr>
<td colspan="2">Observaciones: <asp:Label ID="lblObservaciones" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td><asp:Label ID="lblActivo" runat="server"></asp:Label></td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
 <asp:Button ID="btnEditar" runat="server" Text="Modificar" OnClick="btnEditar_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        &nbsp;&nbsp;&nbsp;
<input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>

