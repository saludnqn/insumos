<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Entregados.aspx.cs" Inherits="ProvisionesH_Entregados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
<div class="divs"><b>Provisiones</b>
<h2>Entregas del Insumo</h2>
<br />
    <asp:GridView ID="gvEntregados" runat="server" CssClass="mGrid" AutoGenerateColumns="false" ToolTip="Stock actual del Insumo" EmptyDataText="No existen registros.">
    <Columns>
    <asp:BoundField DataField="IdInsumo" HeaderText="Código" />
    <asp:BoundField DataField="cantidadRecibida" HeaderText="Cantidad Recibida" />
    <asp:BoundField DataField="fechaR" HeaderText="Fecha Recepción" />
    <asp:BoundField DataField="entregado" HeaderText="Cantidad Entregada" />
    <asp:BoundField DataField="stockActual" HeaderText="Stock Actual" ItemStyle-ForeColor="Blue" />
    </Columns>
    </asp:GridView>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
<input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>

