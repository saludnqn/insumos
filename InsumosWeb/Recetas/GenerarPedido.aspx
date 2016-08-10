<%@ Page Title="Generar Pedido" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="GenerarPedido.aspx.cs" Inherits="Recetas_GenerarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <table width="80%">
            <tr>
                <td>
                    <h2>
                        Pedidos de Medicación a Internación</h2>
                </td>
            </tr>
            <tr>
                <td>
                    Ingrese la fecha de Prescripción:
                    <asp:TextBox ID="txtFecha" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar >>" ToolTip="Buscar prescripciones dispensadas en Internación"
                        Height="23px" OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="panel" runat="server">
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" CssClass="lblmsn" Text=""></asp:Label>
                        <b>
                            <asp:Label ID="lblArea" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblServicio" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbImprimir" runat="server" ToolTip="Exportar e Imprimir" Visible="false" OnClick="lbImprimir_Click">Imprimir Listado</asp:LinkButton>
                        </b>
                        <br />
                        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" EmptyDataText="Sin Pedidos Generados"
                            CssClass="mGrid">
                            <Columns>
                                <asp:TemplateField HeaderText="Medicamento">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("Insumo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Entregada">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                       <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />
      &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nueva Prescripción" OnClick="btnNuevo_Click"
        ToolTip="Click para dispensar nueva prescripcion de Internación" />
</asp:Content>
