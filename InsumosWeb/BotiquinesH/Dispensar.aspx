<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Dispensar.aspx.cs" Inherits="BotiquinesH_Dispensar" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="Insumo" TagPrefix="uc1" %>
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
            <ContentTemplate><b>Pedidos</b>
                <h2>
                    Botiquín Servicios Hospitalarios</h2>
                <table width="100%">
                    <tr>
                        <td>
                            Tipo Pedido:
                            <asp:Label ID="lblPedido" runat="server"></asp:Label>
                        </td>
                        <td>
                            Fecha
                            <asp:TextBox ID="txtFecha" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Depósito (Área):
                            <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" AutoPostBack="true"
                                ToolTip="Seleccionar el Depósito Proveedor del Envío" DataTextField="nombre"
                                OnSelectedIndexChanged="ddlDeposito_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Servicio:
                            <asp:DropDownList ID="ddlServicio" runat="server" DataValueField="idDeposito" DataTextField="nombre"
                                ToolTip="Seleccione el Servicio a quien realizará el Envío" /> 
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <br />
            Seleccionar Medicamentos:
            <uc1:Insumo ID="Insumo" runat="server" />
            <div style="float: right; margin-right: 80px; margin-top: -85px; width: auto;">
                &nbsp;&nbsp;<asp:Button runat="server" ID="btnAgregarInsumo" ToolTip="Click para Agregar Medicamentos"
                    OnClick="btnAgregarInsumo_Click" Text="Agregar Medicamento" />
                &nbsp;&nbsp; &nbsp;&nbsp;
                <%--   <asp:LinkButton ID="lbActualizar" runat="server" ToolTip="Ver Stock del Efector e Insumo seleccionado"
                    OnClick="lbActualizar_Click">
                    <img id="imStock" runat="server" src="~/App_Themes/Default/images/stock.png" alt="VerStock"
                        title="Stock Actual del Depósito" /></asp:LinkButton>--%>
            </div>
        </div>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div class="divs">
                <table width="100%">
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
                                    <asp:TemplateField HeaderText="Medicamento">
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
                                    <asp:TemplateField HeaderText="Cantidad Enviada">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidadEnviada" runat="server" ToolTip="Ingrese la Cantidad Enviada"
                                                Width="60px" Text='<%# Eval("CantidadEmitida") %>'> </asp:TextBox>
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
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Pedido" OnClick="btnGuardar_Click" ToolTip="Guardar e Imprimir Pedido" />
</asp:Content>
