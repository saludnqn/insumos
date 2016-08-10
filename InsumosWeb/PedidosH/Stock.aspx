<%@ Page Title="Stock disponible" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Stock.aspx.cs" Inherits="Pedidos_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Pedidos</b>
        <h2>
            Stock Actual</h2>
        <br />
        <div class="contentBoxW">
            <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                PagerStyle-CssClass="pager" EmptyDataText="No se encontraron resultados." ShowFooter="True"
                PageSize="15" AllowPaging="True" OnRowDataBound="gvStock_RowDataBound" OnDataBound="gvStock_DataBound">
                <Columns>
                    <asp:BoundField DataField="Deposito" HeaderText="Deposito" />
                    <asp:BoundField DataField="ModifiedOn" HeaderText="FechaPedido" />
                    <asp:BoundField DataField="Insumo" HeaderText="Insumo" />
                    <asp:BoundField DataField="cantidadRecibida" HeaderText="Cantidad" />
                    <asp:BoundField DataField="unidad" HeaderText="Unidad" />
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
 <input type="button" value="Cerrar" title="Cerrar y Volver" onclick="history.go(-1)" />
</asp:Content>
