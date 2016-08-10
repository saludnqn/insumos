<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Consultas.aspx.cs" Inherits="PedidosH_Consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate><b>Pedidos</b>
            <div class="divs">
                <h2>
                    Consulta de Pedidos</h2>
                <table>
                    <tr>
                        <td colspan="2">
                            Fecha Inicio:
                            <asp:TextBox ID="txtFInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp; Fecha Fin:
                            <asp:TextBox ID="txtFFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Depósito:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" DataTextField="nombre"
                                AutoPostBack="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Rubro:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRubro" runat="server" DataValueField="idRubro" DataTextField="nombre">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ToolTip="Buscar Pedidos realizados"
                                OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="divs">
                <div class="contentBox">
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" CssClass="mGrid" EmptyDataText="No se encontraron registros de Pedidos del Efector"
                        ToolTip="Tabla ordenada por Fecha de Pedido en orden Descendente">
                        <Columns>
                        <asp:BoundField DataField="deposito" HeaderText="Deposito" />
                            <asp:TemplateField HeaderText="Pedido Nro">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("idPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyy}" />
                            <asp:BoundField DataField="rubro" HeaderText="Rubro" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                            <asp:BoundField DataField="insumos" HeaderText="Insumos" />
                            <asp:TemplateField HeaderText="Ver">
                                <ItemTemplate>
                                    <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido">
                                        <img id="imgView" alt="Ver Pedido Completo" border="0" src="../App_Themes/Default/images/search.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <a href="Edit1.aspx?id=<%# Eval("IdPedido") %>" title="Modificar datos del Pedido">
                                    <img id="imgEdit" alt="Editar Pedido" border="0" src="../App_Themes/Default/images/edit.png" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la Pantalla anterior" onclick="history.go(-1)" />
</asp:Content>
