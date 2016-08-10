<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Pedidos_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="divs">
                <div>
                    <h2>
                        Consulta de Pedidos (Usr Depósito)</h2>
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
                                Efector que realizó el Pedido:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEfector" runat="server" DataValueField="idEfector" DataTextField="nombre"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged">
                                </asp:DropDownList>
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
                                Nro Pedido:
                            </td>
                            <td>
                                <%--<asp:DropDownList ID="ddlEstado" runat="server" DataValueField="idEstadoPedido" DataTextField="nombre">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp; Nº Pedido:--%>
                                <asp:TextBox ID="txtNroPedido" runat="server" Width="80px" Text="0" ToolTip="Ingrese el Número de Pedido a Buscar"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Pedidos" ToolTip="Buscar pedidos activos"
                                    OnClick="btnBuscar_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
<%--                <div style="float: right; margin-top: -15%; margin-right: 10%; background-color: #e4e4e4;">
                    <br />
                    <p>
                        Referencia de Estados</p>
                    <asp:Image ID="img" runat="server" ImageUrl="~/App_Themes/Default/images/estadosExternos1.png" />
                    <br />
                    <br />
                </div>
            </div>--%>
            <%-- <div class="contentBox">
        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" DataKeyNames="IdPedido"
            GridLines="Both" OnRowDataBound="gvPedidos_RowDataBound" CssClass="mGrid">
            <Columns>
                 <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Image ID="imgEstado" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="idEstadoPedido" HeaderText="IdEstado" />
                <asp:BoundField DataField="idPedido" HeaderText="Nº Pedido" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyy}" />
                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                <asp:CheckBoxField DataField="autorizado" HeaderText="Autorizado Por Efector" />
                <asp:TemplateField HeaderText="Ver">
                    <ItemTemplate>
                        <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido">
                            <img id="imgView" alt="Ver Pedido Completo" border="0" src="../App_Themes/Default/images/ver.jpg" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <a href="Edit1.aspx?id=<%# Eval("IdPedido") %>" title="Modificar datos del Pedido">
                            <img id="imgEdit" alt="Editar Pedido" border="0" src="../App_Themes/Default/images/editar.jpg" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>--%>
            <br />
            <div class="divs">
                <div class="contentBox">
                    <asp:GridView ID="gvPedidos" runat="server" CssClass="mGrid" DataKeyNames="idPedido"
                        AutoGenerateColumns="false" EmptyDataText="Sin datos" OnRowDataBound="gvPedidos_RowDataBound"
                        CellPadding="2">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("idPedido") %>', 'one');">
                                        <img id="imgdiv<%# Eval("idPedido") %>" alt="Click para mostrar/ocultar detalles"
                                            border="0" src="../App_Themes/Default/images/round_plus.png" />
                                    </a>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <a href="javascript:switchViews('div<%# Eval("idPedido") %>', 'alt');">
                                        <img id="imgdiv<%# Eval("idPedido") %>" alt="Click para mostrar/ocultar detalles"
                                            border="0" src="../App_Themes/default/images/round_plus.png" />
                                    </a>
                                </AlternatingItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="idPedido" HeaderText="Pedido Nº" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyy}" />
                            <asp:TemplateField HeaderText="Estado" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estadoPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="autorizado" HeaderText="Autorizado por Efector" />
                            <asp:BoundField DataField="ModifiedBy" HeaderText="Usuario" />
                            <asp:BoundField DataField="ModifiedOn" HeaderText="Fecha Actualización" />
                            <asp:TemplateField HeaderText="Ver Pedido">
                                <ItemTemplate>
                                    <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido">
                                        <img id="imgView" alt="Ver Pedido Completo" border="0" src="../App_Themes/Default/images/search.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Autorizar">
                                <%--<asp:CheckBox ID="chkPedidos" runat="server" ToolTip="Seleccione para Autorizar el Pedido" />--%>
                                <ItemTemplate>
                                    <a href="Autorizar.aspx?id=<%# Eval("IdPedido") %>" title="Autorizar Insumos">
                                        <img id="imgAutoriz" alt="Autorizar Insumos" border="0" src="../App_Themes/Default/images/autorizar.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asignar Stock y Preparar">
                                <ItemTemplate>
                                    <a href="AsignaStock.aspx?id=<%# Eval("IdPedido") %>" title="Asignar Stock y Preparar Pedido">
                                        <img id="imgPreparar" alt="Preparar Pedido" border="0" src="../App_Themes/Default/images/prepara.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Entregar">
                                <ItemTemplate>
                                    <a href="Envia.aspx?id=<%# Eval("IdPedido") %>" title="Entregar Pedido">
                                        <img id="imgEnviar" alt="Entregar Pedido" border="0" src="../App_Themes/Default/images/envio.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadEnviada" runat="server" Text='<%# Eval("cantidadenviada") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadRecibida" runat="server" Text='<%# Eval("cantidadrecibida") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    </td></tr>
                                    <tr>
                                        <td colspan="100%">
                                            <div id="div<%# Eval("idPedido") %>" style="display: none; position: relative; left: 2px;">
                                                <asp:GridView ID="gvPedidoDetalle" runat="server" DataKeyNames="idPedidoDetalle"
                                                    CssClass="mGrid" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="idPedido" HeaderText="IdPedido" Visible="false" />
                                                        <asp:BoundField DataField="renglon" HeaderText="Renglón" />
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
                                                        <asp:BoundField DataField="CantidadAutorizada" HeaderText="Cantidad Solicitada" />
                                                        <asp:BoundField DataField="CantidadEmitida" HeaderText="Cantidad Enviada" />
                                                        <asp:BoundField DataField="CantidadRecibida" HeaderText="Cantidad Recibida" />
                                                        <%-- <asp:BoundField DataField="numeroLote" HeaderText="Lote Nº" />
                                                    <asp:BoundField DataField="fechaVencimiento" HeaderText="Fecha Vto." DataFormatString="{0:dd/MM/yyy}" />
                                                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio Unitario" />--%>
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
                <asp:HiddenField ID="hfIdPedido" runat="server" />

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
    <input type="button" value="Volver" title="Volver a la Pantalla anterior" onclick="history.go(-1)" />
    <%--    <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar >>" Visible="true" ToolTip="Click para Autorizar el Pedido"
        OnClick="btnAutorizar_Click" />
--%></asp:Content>
