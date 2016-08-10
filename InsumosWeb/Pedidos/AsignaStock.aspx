<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AsignaStock.aspx.cs" Inherits="Pedidos_AsignaStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="divs">
                <h2>
                    Pedido (Paso 3) - Asignación del Stock</h2>
                <table width="99%">
                    <tr>
                        <td>
                            Pedido Nº:
                            <asp:Label ID="lblPedidoNro" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp; Tipo Pedido:
                            <asp:Label ID="lblTPedido" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp; Fecha Pedido:
                            <asp:Label ID="lblFechaPedido" runat="server"></asp:Label>
                        </td>
                        <td>
                            Modificación:
                            <asp:Label ID="lblFecha" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Efector Destino:
                            <asp:Label ID="lblEfector" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Depósito Destino:
                            <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Rubro:
                            <asp:Label ID="lblRubro" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="border: solid 1px lightgrey;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Responsables:
                            <asp:Label ID="lblResponsable" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Observaciones:
                            <asp:Label ID="lblObservaciones" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="divs">
                <div class="contentBox">
                    <asp:GridView ID="gvPedidos" runat="server" CssClass="mGrid" DataKeyNames="idPedido"
                        AutoGenerateColumns="false" EmptyDataText="Sin datos" CellPadding="2" OnRowDataBound="gvPedidos_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("idInsumo") %>', 'one');">
                                        <img id="imgdiv<%# Eval("idInsumo") %>" alt="Click para mostrar/ocultar detalles"
                                            border="0" src="../App_Themes/Default/images/round_plus.png" />
                                    </a>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("idInsumo") %>', 'alt');">
                                        <img id="imgdiv<%# Eval("idInsumo") %>" alt="Click para mostrar/ocultar detalles"
                                            border="0" src="../App_Themes/default/images/round_plus.png" />
                                    </a>
                                </AlternatingItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:BoundField DataField="CantidadAutorizada" HeaderText="Cantidad Autorizada" />
                            <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                            <asp:TemplateField HeaderText="idPD">
                                <ItemTemplate>
                                    <asp:Label ID="lblidPedidoDetalle" runat="server" Text='<%# Eval("idPedidoDetalle") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="99%">
                                            <div id="div<%# Eval("idInsumo") %>" style="display: none; position: relative; left: 2px;">
                                                <asp:GridView ID="gvInsumosStock" runat="server" DataKeyNames="idPedidoDetalle" CssClass="mGridI"
                                                    AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                                                        <asp:TemplateField HeaderText="Insumo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("Insumo") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="presentacion" HeaderText="Presentación" />
                                                        <asp:BoundField DataField="precioUnitario" HeaderText="Precio Unitario" />
                                                        <asp:BoundField DataField="numeroLote" HeaderText="Lote Nº" />
                                                        <asp:BoundField DataField="fechaVto" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyy}" />
                                                        <asp:BoundField DataField="stock" HeaderText="Stock" />
                                                        <asp:TemplateField HeaderText="Asignar">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCantidad" runat="server" Width="60px" ToolTip="Ingrese la cantidad a Asignar" />
                                                                <asp:HiddenField ID="hfIdPedidoDetalle" runat="server" Value='<%# Eval("idPedidoDetalle") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:HiddenField ID="hfIdInsumo" runat="server" />
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

                <script type="text/javascript" language="javascript">
                    function switchViews(obj, row) {
                        var div = document.getElementById(obj);
                        var img = document.getElementById('img' + obj);

                        if (div.style.display == "none") {
                            div.style.display = "inline";
                            if (row == 'alt') {
                                img.src = "../App_Themes/default/images/round_minus.png";
                                mce_src = "../App_Themes/default/images/round_minus.png";
                            }
                            else {
                                img.src = "../App_Themes/default/images/round_minus.png";
                                mce_src = "../App_Themes/default/images/round_minus.png";
                            }
                            img.alt = "Cerrar";
                        }
                        else {
                            div.style.display = "none";
                            if (row == 'alt') {
                                img.src = "../App_Themes/default/images/round_plus.png";
                                mce_src = "../App_Themes/default/images/round_plus.png";
                            }
                            else {
                                img.src = "../App_Themes/default/images/round_plus.png";
                                mce_src = "..*App_Themes/default/images/round_plus.png";
                            }
                            img.alt = "Expandir para ver mas detalles";
                        }
                    }
                </script>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver y Editar" onclick="history.go(-1)" />
    <asp:Button ID="btnAsignar" runat="server" Text="Asignar Stock" Visible="false" ToolTip="Click para Asignar Stock al Pedido"
        OnClick="btnAsignar_Click" />
</asp:Content>
