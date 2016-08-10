<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Autorizar.aspx.cs" Inherits="Pedidos_Autorizar" %>

<%@ Register TagPrefix="custom" Namespace="CompareValidatorHelper" Assembly="CompareValidatorHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Autorizar Pedido (Paso 2)</h2>
        <table width="99%">
            <tr>
                <td>
                    Tipo Pedido:
                    <asp:Label ID="lblTPedido" runat="server"></asp:Label>
                </td>
                <td>
                    Fecha Pedido:
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
                <td>
                    <div class="contentBox">
                        <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" CellPadding="2"
                            ForeColor="#333333" Width="100%" GridLines="Both" PagerStyle-CssClass="pager"
                            PageSize="10" AllowPaging="True" Font-Names="tahoma" Font-Size="10pt">
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
                                <asp:BoundField DataField="CantidadSolicitada" HeaderText="Cantidad Solicitada" />
                                <asp:TemplateField HeaderText="Cantidad Autorizada">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCAutorizada" runat="server" ToolTip="Ingrese la Cantidad que se Autoriza"
                                            Width="60px" Text='<%# Eval("CantidadAutorizada") %>'>
                                        </asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observacion">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtObservacion" runat="server" ToolTip="Observacion del Insumo"
                                            Width="250px" Text='<%# Eval("Observacion") %>'>
                                        </asp:TextBox>
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
                    Responsable:
                    <asp:TextBox ID="txtResponsable" runat="server" Width="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Observaciones:
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="80%" TextMode="MultiLine"
                        Rows="3"></asp:TextBox>
                </td>
            </tr>
            <tr style="border: solid 2px #00898c;">
                <td>
                    Estado Pedido:
                    <asp:DropDownList ID="ddlEstados" runat="server" DataValueField="idEstadoPedido"
                        DataTextField="nombre" ToolTip="Autorizar y Cambiar de estado el actual pedido" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblEstados" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Autorizar el Pedido Actual:
                    <asp:CheckBox ID="ckbAutoriza" runat="server" ToolTip="Click para autorizar el pedido actual" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Eliminar el Pedido Actual:
                    <asp:CheckBox ID="ckbBaja" runat="server" ToolTip="Click para eliminar el pedido actual" />                   
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Autorizar Pedido" ToolTip="Click para Autorizar el Pedido"
        OnClick="btnGuardar_Click" />
    <input type="button" value="Volver" title="Volver y Editar" onclick="history.go(-1)" />
</asp:Content>
