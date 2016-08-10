<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PedidoCompleto.aspx.cs" Inherits="Pedidos_PedidoCompleto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
          <h2>
        Pedido Realizado</h2>
        <table width="99%">
            <tr>
                <td>
                    Pedido Nro:
                    <asp:Label ID="lblPedido" runat="server"></asp:Label>
                </td>
                <td>
                    Fecha:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblEfector" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblEfectorProveedor" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Rubro:
                    <asp:Label ID="lblRubro" runat="server"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <table>
            <tr>
                <td colspan="2">
                    <div class="contentBox">
                        <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" CellPadding="2"
                            ForeColor="#333333" Width="100%" GridLines="Both" PagerStyle-CssClass="pager"
                            PageSize="10" AllowPaging="True" Font-Names="tahoma" Font-Size="10pt" OnRowDataBound="gvInsumos_RowDataBound">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                                <asp:TemplateField HeaderText="IdInsumo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("InsInsumo.Codigo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insumo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsumo" runat="server" Width="250px" Text='<%# Eval("InsInsumo.Nombre") %>'
                                            Title='<%# Eval("InsInsumo.Descripcion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unidad">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Autorizada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCAutorizada" runat="server" Text='<%# Eval("CantidadAutorizada") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Enviada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCEnviada" runat="server" Text='<%# Eval("CantidadEmitida") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Recibida">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCRecibida" runat="server" Text='<%# Eval("CantidadRecibida") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Adeudada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeuda" runat="server" ToolTip="Cantidad Adeudada">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="precioUnitario" HeaderText="$ Unit." />--%>
                                <asp:TemplateField HeaderText="Observacion">
                                    <ItemTemplate>
                                        <asp:Label ID="txtObservacion" runat="server" ToolTip="Observacion del Insumo" Text='<%# Eval("Observacion") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="idPedidoDetalle" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblidPedidoDetalle" Text='<%# Bind("idPedidoDetalle") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Size="Small" Font-Bold="True" />
                            <HeaderStyle BackColor="#00898c" ForeColor="White" VerticalAlign="Middle" Font-Bold="True"
                                HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    Responsables:
                    <asp:Label ID="lblResponsable" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAutorizado" runat="server" Text="" CssClass="lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Observaciones:
                    <asp:Label ID="txtObservaciones" runat="server" Width="80%"></asp:Label>
                </td>
            </tr>
            <tr style="border: solid 2px #00898c;">
                <td colspan="2">
                    Estado Pedido:
                    <asp:Label ID="lblEstados" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
