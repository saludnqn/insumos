<%@ Page Title="Stock disponible" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="StockSuperior.aspx.cs" Inherits="Pedidos_StockSuperior" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Stock Actual</h2>
        <br />
        <div class="contentBoxW">
            <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                PagerStyle-CssClass="pager" EmptyDataText="No se encontraron resultados." ShowFooter="True"
                PageSize="15" AllowPaging="True" OnRowDataBound="gvStock_RowDataBound" OnDataBound="gvStock_DataBound">
                <Columns>
                    <asp:BoundField DataField="Deposito" HeaderText="Deposito" />
                    <asp:BoundField DataField="FechaPedido" HeaderText="FechaPedido" />
                    <asp:BoundField DataField="Insumo" HeaderText="Insumo" />
                    <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                    <asp:BoundField DataField="cantidadRecibida" HeaderText="Cantidad" />
                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio" />
                    <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                    <asp:BoundField DataField="fechaVto" HeaderText="Fecha Vto." />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" />
                </Columns>
                <FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" />
            </asp:GridView>
        </div>
        <div style="text-align: center">
            <asp:Label ID="lblTotal" runat="server" CssClass="lbl"></asp:Label>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
 
</asp:Content>
