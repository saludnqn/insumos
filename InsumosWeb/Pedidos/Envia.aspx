<%@ Page Title="Pedido Enviado" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Envia.aspx.cs" Inherits="Pedidos_Envia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Enviar Pedido (por Sistema)</h2>
        <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
            <Columns>
                <asp:BoundField DataField="idPedido" HeaderText="Pedido Nº" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyy}" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("InsEstadoPedido.Nombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                <asp:BoundField DataField="ModifiedOn" HeaderText="Fecha Modificación" />
                <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="divs">
    Nuevo Estado del Pedido: <asp:DropDownList ID="ddlEstado" runat="server" DataValueField="idEstadoPedido" DataTextField="nombre" 
            ToolTip="Seleccione el Nuevo Estado del Pedidos">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ToolTip="Guardar el cambio de estado del Pedido actual" 
            onclick="btnGuardar_Click" />
            <br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="lbl" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
</asp:Content>
