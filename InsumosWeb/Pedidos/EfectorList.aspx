<%@ Page Title="Pedidos del Efector" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="EfectorList.aspx.cs" Inherits="Pedidos_EfectorList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Consulta de Pedidos del Efector</h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                    <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" DataTextField="nombre">
                    </asp:DropDownList>
                </td>
            </tr>
             <%--    <tr>
                <td>
                    Rubro:
                </td>
                <td>
                    <asp:DropDownList ID="ddlRubro" runat="server" DataValueField="idRubro" DataTextField="nombre">
                    </asp:DropDownList>
                </td>
            </tr>
        <tr>
                        <td>
                            Estado Pedido:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstado" runat="server" DataValueField="idEstadoPedido" DataTextField="nombre">
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
            <tr>
                <td>
                    Autorizados:
                </td>
                <td>
                    <asp:DropDownList ID="ddlAutorizado" runat="server" ToolTip="Seleccionar Pedidos">
                        <asp:ListItem Value="0">No Autorizados</asp:ListItem>
                        <asp:ListItem Value="1">Autorizados</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Pedidos" ToolTip="Buscar pedidos activos"
                        OnClick="btnBuscar_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <div class="divs">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="contentBox">
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido"
                        OnRowDataBound="gvPedidos_RowDataBound" CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Image ID="imgEstado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="idEstadoPedido" ItemStyle-Width="1px" ItemStyle-Font-Size="XX-Small" HeaderText="IdEstado" />
                            <asp:TemplateField HeaderText="idPedido">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("idPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyy}" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                            <asp:TemplateField HeaderText="Autorizar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckAutorizar" runat="server" ToolTip="Autorizar y enviar pedido" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="autorizado" HeaderText="Enviado" />
                            <asp:TemplateField HeaderText="Ver">
                                <ItemTemplate>
                                    <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido">
                                        <img id="imgView" alt="Ver Pedido Completo" border="0" src="../App_Themes/Default/images/search.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <a href="Edit1.aspx?id=<%# Eval("IdPedido") %>" title="Modificar datos del Pedido">
                                    <img id="imgEdit" alt="Editar Pedido" border="0" src="../App_Themes/Default/images/edit.png" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Autorizar" ToolTip="Autorizar y guardar los cambios"
        OnClick="btnGuardar_Click" />
    <input type="button" value="Volver" title="Volver a la Pantalla anterior" onclick="history.go(-1)" />
</asp:Content>
