<%@ Page Title="Recepcion de Insumos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Recepcion.aspx.cs" Inherits="ProvisionesH_Recepcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate><b>Provisiones</b>
            <div class="divs">
                <h2>
                    Recepción de Pedidos</h2>
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
                                AutoPostBack="true" OnSelectedIndexChanged="ddlDeposito_SelectedIndexChanged">
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Estado Pedido:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstado" runat="server" DataValueField="idEstadoPedido" DataTextField="nombre">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Pedidos" ToolTip="Buscar pedidos activos"
                                OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="divs">
                <div class="contentBox">
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido"
                        OnRowDataBound="gvPedidos_RowDataBound" CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Image ID="imgEstado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="idEstadoPedido" HeaderText="" ItemStyle-Font-Size="XX-Small" ItemStyle-ForeColor="White" ItemStyle-Width="1px" />
                            <asp:TemplateField HeaderText="Pedido Nº">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("idPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="fechaPedido" HeaderText="Fecha Pedido" />
                            <asp:BoundField DataField="renglones" HeaderText="Items" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                            <asp:BoundField DataField="autorizado" HeaderText="Enviado" />
                            <asp:BoundField DataField="modifiedOn" HeaderText="Fecha Actualización" />
                            <asp:TemplateField HeaderText="Recibir">
                                <ItemTemplate>
                                    <a href="RecepcionView.aspx?id=<%# Eval("IdPedido") %>" title="Recibir Insumos">
                                        <img id="imgAutoriz" alt="Recibir Insumos" border="0" src="../App_Themes/Default/images/recibir.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ver">
                                <ItemTemplate>
                                    <a href="Finalizado.aspx?id=<%# Eval("IdPedido") %>" title="Ver Recepción">
                                        <img id="imgVer" alt="Ver Insumos recibidos" border="0" src="../App_Themes/Default/images/search.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cancelar" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
