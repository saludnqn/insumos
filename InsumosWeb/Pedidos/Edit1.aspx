<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Edit1.aspx.cs" Inherits="Pedidos_Edit1" %>

<%@ Register Src="~/UserControls/InsumoxEfector.ascx" TagName="acInsumoxEfector"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>

    <script type="text/javascript" src="../js/json2.js"></script>

    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="divs">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <h2>
                    Nuevo Pedido</h2>
                <table width="100%">
                    <tr>
                        <td>
                            Tipo Pedido:
                            <asp:DropDownList ID="ddlPedido" runat="server" DataTextField="nombre" DataValueField="idTipoPedido"
                                ToolTip="Seleccione el Tioo de Pedido a realizar">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Fecha
                            <asp:TextBox ID="txtFecha" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Efector:
                            <asp:DropDownList ID="ddlEfector" runat="server" DataValueField="idEfector" DataTextField="nombre"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Depósito:
                            <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" DataTextField="nombre"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlDeposito_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Seleccionar el Rubro:
                            <asp:DropDownList ID="ddlRubro" runat="server" DataValueField="idRubro" DataTextField="nombre"
                                ToolTip="Seleccionar el Rubro Base" AutoPostBack="true" OnSelectedIndexChanged="ddlRubro_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <uc1:acInsumoxEfector ID="acInsumoxEfector" runat="server" />
        <%--                         <div class="contentBoxW">
                               Insumo: <asp:DropDownList ID="ddlInsumo" runat="server" DataValueField="idInsumo" DataTextField="Insumo"
                                    ToolTip="Seleccionar el Insumo">
                                </asp:DropDownList>
                         </div>  --%>
        &nbsp;&nbsp;<asp:Button runat="server" ID="btnAgregarInsumo" ToolTip="Click para Agregar Insumo al Pedido"
            OnClick="btnAgregarInsumo_Click" Text="Agregar" />
        &nbsp;&nbsp;
        <asp:LinkButton ID="lbActualizar" runat="server" ToolTip="Ver el Stock del Efector e Insumo seleccionado"
            OnClick="lbActualizar_Click">StockE</asp:LinkButton>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div class="divs">
                <table width="99%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                ForeColor="#333333" Width="100%" GridLines="Both" PagerStyle-CssClass="pager"
                                PageSize="10" AllowPaging="True" Font-Names="tahoma" Font-Size="10pt">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="IdPedidoDetalle" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdPedidoDetalle" runat="server" Text='<%# Eval("IdPedidoDetalle") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidad" runat="server" ToolTip="Ingrese la Cantidad Solicitada del Insumo"
                                                Width="60px" Text='<%# Eval("CantidadSolicitada") %>'>
                                            </asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observación">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtObservacion" runat="server" Width="80%" Text='<%# Eval("Observacion") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="x">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="ibBorrar" ToolTip="Eliminar el Insumo de la Lista"
                                                CommandArgument='<%# Eval("IdInsumo") %>' OnCommand="ibBorrar_Command" ImageUrl="~/App_Themes/Default/images/del.png" />
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="padding: 3px 0 3px 0;">
                                Responsable:
                                <asp:TextBox ID="txtResponsable" runat="server" Width="70%" ToolTip="Nombre del Responsable o Usuario que realiza el Pedido"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Observaciones:
                            <asp:TextBox ID="txtObservaciones" runat="server" Width="80%" ToolTip="Observaciones del Pedido realizado"
                                TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Generar Pedido" OnClick="btnGuardar_Click" />
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
