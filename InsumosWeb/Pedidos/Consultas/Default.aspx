<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Pedidos_Consultas_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Consulta de Pedidos Finalizados</h2>
        Fecha Inicial:
        <asp:TextBox ID="txtFechaI" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)"></asp:TextBox>
        Fecha Final:
        <asp:TextBox ID="txtFechaF" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnBuscar" ToolTip="Click para Buscar Pedidos"
            Height="23px" OnClick="btnBuscar_Click" Text="Buscar Pedidos" />
    </div>
    <br />
    <div class="divs">
        <div class="contentBoxW">
            <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                EmptyDataText="Sin Datos." OnRowDataBound="gvPedidos_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="IdPedido" HeaderText="Nº Pedido" />
                    <asp:TemplateField HeaderText="Depósito Solicitante">
                        <ItemTemplate>
                            <asp:Label ID="lblDeposito" runat="server" Text='<%# Eval("InsDeposito.nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Efector Solicitante">
                        <ItemTemplate>
                            <asp:Label ID="lblEfector" runat="server" Text='<%# Eval("SysEfector.nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Depósito Proveedor">
                        <ItemTemplate>
                            <asp:Label ID="lblDepositoProveedor" runat="server" Text='<%# Eval("InsDepositoToIdDepositoProveedor.nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Efector Proveedor">
                        <ItemTemplate>
                            <asp:Label ID="lblEfectorProveedor" runat="server" Text='<%# Eval("SysEfectorToIdEfectorProveedor.nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                    <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                    <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                    <asp:TemplateField HeaderText="Mas">
                        <ItemTemplate>
                            <a href="PedidoCompleto.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido">
                                <img id="imgView" alt="Ver Pedido Completo" border="0" src="../../App_Themes/Default/images/entregados.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
</asp:Content>
