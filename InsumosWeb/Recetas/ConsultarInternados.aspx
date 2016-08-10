<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsultarInternados.aspx.cs" Inherits="Recetas_ConsultarInternados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>
            Mapa de Cama</h2>
        <b>
            <asp:Label ID="lblPaciente" runat="server"></asp:Label></b>
        <br />
        <asp:GridView ID="gvInternados" runat="server" CssClass="mGrid" EmptyDataText="No se encontraron registros de internación"
            AutoGenerateColumns="false" PagerStyle-CssClass="pgr" OnPageIndexChanging="gvInternados_PageIndexChanging"
            OnRowDataBound="gvInternados_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Historia" HeaderText="HC" />
                <asp:BoundField DataField="Documento" HeaderText="Documento" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="OS" HeaderText="Obra Social" />
                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" />
                <asp:BoundField DataField="Servicio" HeaderText="Servicio" />
                <asp:BoundField DataField="NumHabitacion" HeaderText="Habitación" />
                <asp:TemplateField HeaderText="Cama">
                    <ItemTemplate>
                        <asp:Label ID="lblCama" runat="server" Text='<%# Bind("NumCama") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Piso">
                    <ItemTemplate>
                        <asp:Label ID="lblPiso" runat="server" Text="" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cerrar" title="Cerrar ventana" onclick="history.go(-1)" />
</asp:Content>
