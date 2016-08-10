<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Provisiones_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Consulta de Provisiones</h2>
        <table>
            <tr>
                <td>
                    Fecha Inicio:
                    <asp:TextBox ID="txtFInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                </td>
                <td>
                    Fecha Fin:
                    <asp:TextBox ID="txtFFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Rubro:
                    <asp:DropDownList ID="ddlRubro" runat="server" DataValueField="idRubro" DataTextField="nombre"
                        ToolTip="Seleccione el Rubro.">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar >>" Height="23px" ToolTip="Buscar ingresos de Insumos"
                        OnClick="btnBuscar_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <div class="contentBox">
            <asp:GridView ID="gvProvisiones" runat="server" AutoGenerateColumns="false" EmptyDataText="Sin registros."
                CssClass="mGrid" onrowdatabound="gvProvisiones_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="idPedido" HeaderText="Nº Suministro" />
                    <asp:BoundField DataField="fechaRecepcion" HeaderText="Fecha Recepción" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                    <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                    <asp:BoundField DataField="numeroComprobante" HeaderText="Nº Comprobante" />
                    <asp:BoundField DataField="ordenCompra" HeaderText="Orden Compra" />
                    <asp:TemplateField HeaderText="Proveedor">
                        <ItemTemplate>
                            <asp:Label ID="lblProveedor" runat="server" Text='<%# Eval("InsProveedor.nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' ToolTip="Estado actual de la Provisión" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Provisión Completa">
                                <img id="imgView" alt="Ver Provisión" border="0" src="../App_Themes/Default/images/search.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a href="Edit.aspx?id=<%# Eval("IdPedido") %>" title="Editar Provisión">
                                <img id="imgView" alt="Editar Provisión" border="0" src="../App_Themes/Default/images/edit.png" />
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
