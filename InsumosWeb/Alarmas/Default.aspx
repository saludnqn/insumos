<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Alarmas_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Consulta de Vencimientos</h2>
        Ingrese la fecha de Vencimiento a consultar<br />
        Fecha de Inicio:
        <asp:TextBox ID="txtFinicio" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)"></asp:TextBox>
        Fecha de Inicio:
        <asp:TextBox ID="txtFfin" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar Insumos" OnClick="btnBuscar_Click" />
    </div>
    <br />
    <div class="divs">
        <asp:GridView ID="gvInsumos" runat="server" CssClass="mGrid" AutoGenerateColumns="false" EmptyDataText="No se encontraron medicamentos con fecha de vencimiento similar a la ingresada.">
        <Columns>
        <asp:BoundField DataField="Insumo" HeaderText="Medicamento" />
        <asp:BoundField DataField="Stock" HeaderText="Stock" />
        <%--<asp:BoundField DataField="Observacion" HeaderText="Observación" />--%>
        <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
        <asp:BoundField DataField="fechaVencimiento" HeaderText="Vencimiento" />
        <asp:BoundField DataField="deposito" HeaderText="Depósito" />
        </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblMensaje" runat="server" CssClass="lblmsn"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Vuelve a la página anterior" onclick="history.go(-1)" />
</asp:Content>
