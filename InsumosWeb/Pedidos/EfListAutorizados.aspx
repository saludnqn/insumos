<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EfListAutorizados.aspx.cs" Inherits="Pedidos_EfListAutorizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <h2>
        Pedidos Autorizados</h2>
    <div class="divs">
        <table>
            <tr>
                <td>
                    Efector:
                    <asp:Label ID="lblEfector" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                    Depósito:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Rubro Insumo:
                    <asp:Label ID="lblRubro" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido"
            OnRowDataBound="gvPedidos_RowDataBound" CssClass="mGrid">
            <Columns>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Image ID="imgEstado" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="idEstadoPedido" HeaderText="idEstado" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyy}" />
                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                <asp:BoundField DataField="autorizado" HeaderText="Enviado" />
                <asp:BoundField DataField="ModifiedBy" HeaderText="Usuario" />
                <asp:BoundField DataField="ModifiedOn" HeaderText="Fecha Modific" DataFormatString="{0:dd/MM/yyy}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
  <input type="button" value="Volver" title="Volver a la Página anterior" onclick="history.go(-1)" />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Pedido" ToolTip="Click para realizar un nuevo Pedido"
        OnClick="btnNuevo_Click" />
</asp:Content>
