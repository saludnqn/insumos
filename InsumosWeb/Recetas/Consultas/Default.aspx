<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Recetas_Consultas_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../../js/Format.js"></script>

    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="../../js/HCharts/js/highcharts.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <b>Top 10 de medicamentos consumidos</b>
        <br />
        Fecha Inicio:
        <asp:TextBox ID="txtFInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp; Fecha Fin:
        <asp:TextBox ID="txtFFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
        <br />
        Seleccionar Depósito:
        <asp:DropDownList ID="ddlDeposito" runat="server" DataTextField="nombre" DataValueField="idDeposito"
            ToolTip="Seleccionar el Depósito" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar >>" ToolTip="Buscar Prescripciones"
            Height="23px" OnClick="btnBuscar_Click" />
    </div>
    <br />
    <div class="divs">
        <div style="text-align: center;">
            <highchart:ColumnChart ID="hcMedicamentos" Width="800" Height="500" runat="server">
            </highchart:ColumnChart>
            <br />
            <asp:GridView ID="gvEntregas" runat="server" AutoGenerateColumns="false" CssClass="mGridC">
                <Columns>
                    <asp:BoundField DataField="Insumo" HeaderText="Insumos Entregados" />
                    <asp:BoundField DataField="solicitado" HeaderText="Solicitados" />
                    <asp:BoundField DataField="entregado" HeaderText="Entregados" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
