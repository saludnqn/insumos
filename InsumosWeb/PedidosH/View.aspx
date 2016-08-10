<%@ Page Title="Datos del Pedido" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Pedidos_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Pedidos</b>
    <h2>
        ESTADO PEDIDO</h2>
        <table width="99%">
            <tr>
                <td>
                    Tipo Pedido:
                    <asp:Label ID="lblTPedido" runat="server"></asp:Label>
                </td>
                <td>
                    Fecha:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lkImprimir" runat="server" ToolTip="Imprimir en Pdf" onclick="lkImprimir_Click">Imprimir Pedido</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Solicitante:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Proveedor:
                    <asp:Label ID="lblEfectorProveedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Depósito Proveedor:
                    <asp:Label ID="lblDepositoProveedor" runat="server"></asp:Label>
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
        <table width="99%">
            <tr>
                <td colspan="2">
                    <div class="contentBox">
                        <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" CellPadding="2"
                            CssClass="table table-bordered table-condensed table-hover" PagerStyle-CssClass="pager" PageSize="10" AllowPaging="True"
                            OnRowDataBound="gvInsumos_RowDataBound">
                            <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                            <Columns>
                                <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                                <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insumo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsumo" runat="server" Width="250px" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                            Title='<%# Eval("InsInsumo.Descripcion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unidad">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Solicitada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCSolicitada" runat="server" Text='<%# Eval("CantidadSolicitada") %>'>
                                        </asp:Label>
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
<%--                                <asp:TemplateField HeaderText="Cantidad Adeudada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeuda" runat="server" ToolTip="Cantidad Adeudada">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
--%>                                <asp:TemplateField HeaderText="Observacion">
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
                        </asp:GridView>
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    Responsable:
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
<div class="container">
<div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>
    </div>
    </div>
</asp:Content>
