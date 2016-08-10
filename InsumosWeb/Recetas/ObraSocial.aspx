<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ObraSocial.aspx.cs" Inherits="Recetas_ObraSocial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Obra Social en Padrones</h2>
        <asp:GridView ID="gvOSocial" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
            EmptyDataText="Sin datos encontrados" ToolTip="Obra Social encontrada en el Padrón de Obras Sociales">
            <Columns>
                <asp:BoundField DataField="Documento" HeaderText="DU" />
                <asp:BoundField DataField="Nombre" HeaderText="Paciente" />
                <asp:BoundField DataField="ObraSocial" HeaderText="ObraSocial" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
 <input type="button" value="Cerrar" onclick="window.close()" />
</asp:Content>
