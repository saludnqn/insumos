<%@ Page Title="Dosis por Medicamento" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsultaDosis.aspx.cs" Inherits="Insumos_ConsultaDosis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <b>Configuración</b>
    <div class="divs">
        <h2>
            Dosis por Medicamento</h2>
        <b><asp:Label ID="lblMedicamento" runat="server"></asp:Label></b><br /><br />
        <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                    PagerStyle-CssClass="pgr" EmptyDataText="No hay un medicamento seleccionado">
                    <Columns>
                    <asp:BoundField DataField="cantidad" HeaderText="Nro Dosis" />
                    <asp:BoundField DataField="ModifiedOn" HeaderText="Fecha Actualización" DataFormatString="{0:dd/MM/yyy}" />
                    </Columns>
        </asp:GridView>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Registro" TabIndex="3" OnClick="btnNuevo_Click" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
