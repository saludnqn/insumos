<%@ Page Title="Trazabilidad de Insumos por Rubro" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Trazabilidad_Default" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="acInsumo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/Format.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/json2.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
--%>
    <div class="divs"><b>Consultas</b>
        <h2>
            Trazabilidad de Insumos</h2>
        (Externa al Efector)
        <table width="100%">
            <tr>
                <td colspan="2">
                    Fecha Desde:
                    <asp:TextBox ID="txtFInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp; Fecha Hasta:
                    <asp:TextBox ID="txtFFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                    <%--  &nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnBuscar" runat="server" Text="Ver Trazabilidad" Height="23px" OnClick="btnBuscar_Click" />
                         &nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="imLimpiar" runat="server" CssClass="imgb" ImageUrl="~/App_Themes/Default/images/limpiar.png"
                                ToolTip="Limpiar filtros" OnClick="imLimpiar_Click" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    Seleccione el Insumo:
                    <uc1:acInsumo ID="acInsumo" runat="server" />
                    <%--<br />
                            <div class="contentMed">
                            <asp:DropDownList ID="ddlInsumo" runat="server" DataValueField="idInsumo" DataTextField="Insumo"
                                AutoPostBack="true" ToolTip="Seleccione el Insumo para actualizar la tabla de resultados" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged">
                            </asp:DropDownList>
                            </div>--%>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" TabIndex="1" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <asp:HyperLink ID="hlGrafico" runat="server" ToolTip="Click para ver el gráfico" NavigateUrl="~/Trazabilidad/Grafico.aspx">Ver Gráfico</asp:HyperLink>
    <br />
        <div class="contentBoxW">
            <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                ToolTip="Trazabilidad de Insumos" EmptyDataText="No hay registros para los filtros seleccionados.">
                <Columns>
                    <%--<asp:BoundField DataField="idPedido" HeaderText="Nro Pedido" />--%>
                    <asp:BoundField DataField="fechaPedido" HeaderText="Fecha Pedido" />
                    <asp:BoundField DataField="fecharecepcion" HeaderText="Fecha Recepción" />
                    <asp:BoundField DataField="EfectorProveedor" HeaderText="Efector Proveedor" />
                    <asp:BoundField DataField="Depositoproveedor" HeaderText="Depósito Proveedor" />
                    <asp:BoundField DataField="Efector" HeaderText="Efector Receptor" />
                    <asp:BoundField DataField="deposito" HeaderText="Depósito Receptor" />
                    <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />
                    <asp:BoundField DataField="insumo" HeaderText="Insumo" />
                    <%--<asp:BoundField DataField="cantidadRecibida" HeaderText="Recibido" />--%>
                    <asp:BoundField DataField="stock" HeaderText="Stock" />
                    <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                    <asp:BoundField DataField="fechavencimiento" HeaderText="Vencimiento" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>
--%></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
</asp:Content>
