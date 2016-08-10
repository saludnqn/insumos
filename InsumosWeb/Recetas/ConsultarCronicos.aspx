<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsultarCronicos.aspx.cs" Inherits="Recetas_ConsultarCronicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>
            Registro de Patologías</h2>
        <b>
            <asp:Label ID="lblPaciente" runat="server"></asp:Label></b>
        <br />
        <asp:GridView ID="gvCronicos" runat="server" CssClass="mGrid" EmptyDataText="No se encontraron registros anteriores de patologias"
            AutoGenerateColumns="false" PagerStyle-CssClass="pgr" OnPageIndexChanging="gvCronicos_PageIndexChanging">
            <Columns>
                <%--            <asp:BoundField DataField="Id" HeaderText="Id"  />
--%>
                <asp:BoundField DataField="Historia" HeaderText="Nro HC" />
                <%-- <asp:BoundField DataField="Documento" HeaderText="Documento"  />
            <asp:BoundField DataField="IdPatologiaCIE10" HeaderText=""  />--%>
                <asp:BoundField DataField="HospitalOrigen" HeaderText="HospitalOrigen" />
                <asp:BoundField DataField="Servicio" HeaderText="Servicio" />
                <asp:BoundField DataField="Medico" HeaderText="Profesional" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyy}" />
                <asp:BoundField DataField="Patologia" HeaderText="Patología" />
                <asp:BoundField DataField="SubPatologia" HeaderText="SubPatología" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cerrar" title="Cerrar ventana" onclick="history.go(-1)" />
</asp:Content>
