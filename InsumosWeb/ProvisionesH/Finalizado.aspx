﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Finalizado.aspx.cs" Inherits="ProvisionesH_Finalizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
  <div class="divs"><b>Provisiones</b>
        <h2>
            Datos Ingresados</h2>
        <table>
            <tr>
                <td>
                    Efector:
                    <asp:Label ID="lblEfector" runat="server"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;
               <%-- <asp:LinkButton ID="lbImprimir" runat="server" ToolTip="Exportar a PDF" onclick="lbImprimir_Click">Imprimir PDF</asp:LinkButton>--%>
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
            <asp:GridView ID="gvInsumos" runat="server" CellPadding="2" CssClass="mGrid" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="idPedidoDetalle" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unidad">
                        <ItemTemplate>
                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CantidadSolicitada" HeaderText="Solicitado" />
                    <asp:BoundField DataField="CantidadAutorizada" HeaderText="Autorizado" />
                    <asp:BoundField DataField="CantidadEmitida" HeaderText="Enviado" />
                    <asp:BoundField DataField="CantidadRecibida" HeaderText="Recibido" />
                    <asp:BoundField DataField="precioUnitario" HeaderText="Costo Unitario" />
                    <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                    <asp:BoundField DataField="fechaVencimiento" HeaderText="F.Vencimiento" DataFormatString="{0:dd/MM/yyy}" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
<input type="button" value="Volver" name="Back2" onclick="history.back()" title="Click para volver a la pantalla anterior" />
<%--    <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click"
        ToolTip="Click para volver a la pantalla anterior" />
--%>
</asp:Content>

