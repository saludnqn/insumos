<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="View.aspx.cs" Inherits="Provisiones_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Datos Ingresados</h2>
        <table>
            <tr>
                <td>
                    Efector:
                    <asp:Label ID="lblEfector" runat="server"></asp:Label>
                </td>
                <td>
                 <asp:LinkButton ID="lbImprimir" runat="server" ToolTip="Exportar a PDF" onclick="lbImprimir_Click">Imprimir PDF</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    Depósito:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha Recepción:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>
                    Proveedor:
                    <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo Comprobante:
                    <asp:Label ID="lblTComprobante" runat="server"></asp:Label>
                </td>
                <td>
                    Número Comprobante:
                    <asp:Label ID="lblNroComprobante" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Orden de Compra:
                    <asp:Label ID="lblOCompra" runat="server"></asp:Label>
                </td>
                <td>
                    Estado Suministro:
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <h2>
            Insumos</h2>
        <div class="contentBoxW">
            <asp:GridView ID="gvInsumos" runat="server" CellPadding="2" CssClass="mGrid" AutoGenerateColumns="false"
                OnRowDataBound="gvInsumos_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="idPedidoDetalle" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Label ID="lblCantidad" runat="server" Text='<%# string.Concat(Eval("Cantidad"), " x ", Eval("Presentacion"), " ", Eval("InsInsumo.Unidad")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Recibido">
                        <ItemTemplate>
                            <asp:Label ID="lblCRecibida" runat="server" Text='<%# Eval("CantidadRecibida") %>' />
                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Costo Unitario">
                        <ItemTemplate>
                            <asp:Label ID="lblCUnitario" runat="server" Text='<%# Eval("precioUnitario") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Costo Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalInsumo" runat="server" ToolTip="Total del Insumo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="fechaVencimiento" HeaderText="F.Vencimiento" DataFormatString="{0:dd/MM/yyy}" />
                    <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    Responsable:
                    <asp:Label ID="lblResponsable" runat="server" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click"
        ToolTip="Click para editar los datos" />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Ingreso" OnClick="btnNuevo_Click"
        ToolTip="Click para realizar un nuevo ingreso de insumos" />
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
