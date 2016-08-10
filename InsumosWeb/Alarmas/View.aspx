<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Alarmas_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
<h2>Datos de Alarma</h2>
<table>
<tr>
<td>Medicamento: <asp:Label ID="lblMedicamento" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Alarma Activada? <asp:Label ID="lblAlarma" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Cantidad Mínima del Insumo: <asp:Label ID="lblMinimo" runat="server"></asp:Label></td>
</tr>
<tr>
<td>Días antes del Vencimiento: <asp:Label ID="lblDias" runat="server"></asp:Label></td>
<td></td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
<input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>