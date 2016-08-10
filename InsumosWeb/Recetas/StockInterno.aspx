<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StockInterno.aspx.cs" Inherits="Recetas_StockInterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>
            Stock Actual del Depósito Seleccionado</h2>
        <br />
        <div class="contentBoxW">
            <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                PagerStyle-CssClass="pager" EmptyDataText="No se encontraron resultados." ShowFooter="True"
                PageSize="15" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="fechapedido" HeaderText="Fecha Pedido" />
                    <asp:BoundField DataField="fecharecepcion" HeaderText="Fecha Recepción" />
                    <asp:TemplateField HeaderText="Medicamentos">
                        <ItemTemplate>
                            <asp:Label ID="lblMedicamento" runat="server" Text='<%# Eval("insumo") %>' Title='<%# Eval("descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cantidademitida" HeaderText="Enviado" />
                    <asp:BoundField DataField="cantidadrecibida" HeaderText="Recibido" />
                    <asp:BoundField DataField="stock" HeaderText="Stock" />
                    <asp:BoundField DataField="Observacion" HeaderText="Observación" />
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
    <input type="button" value="Cerrar" onclick="window.close()" />
</asp:Content>
