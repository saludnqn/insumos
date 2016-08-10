<%@ Page Title="Envio de Pedidos Internos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="InternosEnvio.aspx.cs" Inherits="Pedidos_InternosEnvio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Pedidos</b>
        <h2>
            Registro Entrega</h2>
        <table width="99%">
            <tr>
                <td>
                    Tipo Pedido:
                    <asp:Label ID="lblTPedido" runat="server"></asp:Label>
                </td>
                <td>
                    Fecha:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Depósito Originante:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Efector Proveedor:
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
    <div class="divs">
        <table>
            <tr>
                <td colspan="2">
                    <div class="contentBox">
                        <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" CellPadding="2"
                            CssClass="table table-bordered table-condensed table-hover" PagerStyle-CssClass="pager" PageSize="10" AllowPaging="True">
                            <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />                            
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
                                <asp:BoundField DataField="cantidadSolicitada" HeaderText="Cantidad Solicitada" />
                                <asp:TemplateField HeaderText="Cantidad Autorizada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCAutorizada" runat="server" ToolTip="Ingrese la Cantidad Autorizada"
                                            Width="60px" Text='<%# Eval("CantidadAutorizada") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Enviada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCEnviada" runat="server" ToolTip="Ingrese la Cantidad a Enviar"
                                            Width="60px" Text='<%# Eval("CantidadEmitida") %>'>
                                        </asp:Label>
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
                        </asp:GridView>
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Responsable:
                    <asp:Label ID="lblResponsable" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Observaciones:
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="80%" TextMode="MultiLine"
                        Rows="3"></asp:TextBox>
                </td>
            </tr>
            <tr style="border: solid 2px #00898c;">
                <td colspan="2">                     
                    <asp:DropDownList ID="ddlEstados" runat="server" class="form-control" visible="false" ToolTip="Seleccionar el estado del pedido">
                                    <asp:ListItem Value="9">Enviado</asp:ListItem>                                    
                                </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td>
                    Eliminar el Pedido Actual:
                    <asp:CheckBox ID="ckbBaja" runat="server" ToolTip="Click para eliminar el pedido actual" />
                </td>
                <td>
                </td>
            </tr>--%>
        </table>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnGuardar" runat="server" 
                       OnClick="btnGuardar_Click" OnClientClick="javascript:window.close();" CssClass="btn btn-success btn-md" 
                    ToolTip="Aceptar" UseSubmitBehavior="false" ValidationGroup="G">
                     <span> <i class="glyphicon glyphicon-ok"> </i></span>  Guardar
                </asp:LinkButton>
                <asp:linkbutton ID="btnCancelar" runat="server" 
                       OnClientClick="javascript:window.close();" CssClass="btn btn-info btn-md" ToolTip="Cancelar y Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cancelar
                </asp:LinkButton>
            </div>    
    </div>
        </div>
</asp:Content>
