<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="DatosFarmaceuticos_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
<div class="divs">
<h2>Vista de Datos</h2>
<table>
<tr>
<td>Medicamento: </td>
<td><asp:Label ID="lblMedicamento" runat="server"></asp:Label> - <asp:Label ID="lblReceta" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Codigo OMS:  <asp:Label ID="lblCodigo" runat="server"></asp:Label></td>
<td>Nivel de Complejidad: <asp:Label ID="lblNComplejidad" runat="server"></asp:Label></td>
</tr>
<tr>
<td colspan="2">Composición: <asp:Label ID="lblComposicíon" runat="server"></asp:Label></td>
</tr>
<tr>
<td colspan="2">Acción Terapéutica: <asp:Label ID="lblAccion" runat="server"></asp:Label></td>
</tr>
<tr>
<td colspan="2">Contraindicaciones: <asp:Label ID="lblContraindicaciones" runat="server"></asp:Label></td>
</tr>
</table>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
<input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>

