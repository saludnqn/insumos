<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Consultas.aspx.cs" Inherits="BotiquinesH_Consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Pedidos</b>
        <h2>
            Envío Medicamentos a Servicios Hospitalarios</h2>
        <table width="100%">
            <tr>
                <td>
                    Fecha
                    <asp:TextBox ID="txtFecha" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Depósito (Área):
                    <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" AutoPostBack="true"
                        ToolTip="Seleccionar el Depósito Proveedor del Envío" DataTextField="nombre"
                        OnSelectedIndexChanged="ddlDeposito_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <asp:ListView ID="rptControles" runat="server" ItemPlaceholderID="phServicios" OnItemDataBound="rptControles_ItemDataBound">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder ID="phServicios" runat="server" />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <asp:Label ID="lblServicios" runat="server" Text='<%# Eval("Servicio") %>' Font-Bold="true" />
                </div>
                <div>
                    <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Código" />
                            <asp:BoundField DataField="nombre" HeaderText="Medicamento" />
                            <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                            <asp:BoundField DataField="CantidadEmitida" HeaderText="Cantidad Enviada" />
                            <asp:BoundField DataField="observacion" HeaderText="Observación" />
                        </Columns>
                    </asp:GridView>
                </div>
                <hr />
            </ItemTemplate>
        </asp:ListView>
        <br />
        <asp:Label ID="lblResponsable" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="printButton" runat="server" Text="Imprimir" OnClientClick="javascript:window.print();" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Envío" OnClick="btnNuevo_Click"
        ToolTip="Click para realizar un nuevo envio a Depositos Servicios" />
</asp:Content>
