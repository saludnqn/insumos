<%@ Page Title="Vista Del Egreso" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewInterno.aspx.cs" Inherits="PedidosH_ViewInterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <b>EGRESO</b>
        <h2>
            <asp:Label ID="lblTipoPedido" runat="server"></asp:Label></h2>
        <table>
            <tr>
                <td>Efector:
                    <asp:Label ID="lblEfector" runat="server"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbPInterna" runat="server" ToolTip="Exportar a PDF" OnClick="lbPInterna_Click" Visible="false">Imprimir</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>Depósito:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Fecha:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>Destino:
                    <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Tipo Comprobante:
                    <asp:Label ID="lblTComprobante" runat="server"></asp:Label>
                </td>
                <td>Número Comprobante:
                    <asp:Label ID="lblNroComprobante" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <%--<td>
                    Orden de Compra:
                    <asp:Label ID="lblOCompra" runat="server"></asp:Label>
                </td>--%>
                <td>Estado:
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <h2>Insumos</h2>
        <div class="contentBoxW">
            <asp:GridView ID="gvInsumos" runat="server" CellPadding="2" CssClass="table table-bordered table-condensed table-hover" AutoGenerateColumns="false">
                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="black" />
                <Columns>
                    <asp:BoundField DataField="idPedidoDetalle" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Presentación">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentacion" runat="server" Text='<%# string.Concat(" x ", Eval("Presentacion"), " ", Eval("InsInsumo.Unidad")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cant. Entregada">
                        <ItemTemplate>
                            <asp:Label ID="lblRecibido" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="precioUnitario" HeaderText="$ Unitario" Visible="false" />
                    <asp:BoundField DataField="fechaVencimiento" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" Visible="false" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>Responsable:
                    <asp:Label ID="lblResponsable" runat="server" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnEditar" runat="server" Text="Editar datos" OnClick="btnEditar_Click" Visible="false"
        ToolTip="Click para editar los datos" />
    <%--<asp:Button ID="btnNuevo" runat="server" Text="Nuevo Ingreso" OnClick="btnNuevo_Click"
        ToolTip="Click para realizar un nuevo ingreso de insumos" />--%>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="btnCerrar" runat="server"
        OnClientClick="cerrarVentana()" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
    </asp:LinkButton>

    <script>
        function cerrarVentana() {
            window.close();
        }
    </script>
</asp:Content>
