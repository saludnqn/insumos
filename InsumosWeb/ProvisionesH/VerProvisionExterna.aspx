<%@ Page Title="Provisión Externa" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="VerProvisionExterna.aspx.cs" Inherits="ProvisionesH_VerProvisionExterna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Provisiones</b>
        <h2>Provision de Medicamentos</h2>
        <table>
            <tr>
                <td>Depósito:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
                <td>Pedido Interno Nº:
                    <asp:Label ID="lblPedido" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Fecha Recepción:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>Proveedor:
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
        </table>
    </div>
    <br />
    <div class="divs">
        Medicamentos
        <div class="contentBoxW">
            <asp:GridView ID="gvInsumos" runat="server" CellPadding="2" CssClass="mGrid" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="idPedidoDetalle" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unidad">
                        <ItemTemplate>
                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CantidadEmitida" HeaderText="Enviado" />
                    <asp:BoundField DataField="CantidadRecibida" HeaderText="Recibido" />
                    <asp:BoundField DataField="numeroLote" HeaderText="Nro Lote" />
                    <asp:BoundField DataField="fechaVencimiento" HeaderText="Fecha Vencimiento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>Responsable:
                    <asp:Label ID="lblResponsable" runat="server" />
                    <br />
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="printButton" runat="server" Text="Imprimir" OnClientClick="javascript:window.print();" />
</asp:Content>
