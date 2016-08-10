<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pedidos_Reportes_Default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="divs">
    <h2>Reportes de Pedidos</h2>
        Fecha Inicial:
        <asp:TextBox ID="txtFechaI" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)"></asp:TextBox>
        Fecha Final:
        <asp:TextBox ID="txtFechaF" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
            onblur="javascript:formatearFecha(this)"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnEjecutar" ToolTip="Click para Ejecutar el reporte"
            Height="23px" OnClick="btnEjecutar_Click" Text="Ejecutar Reporte" />
    </div>
    <br />
    <asp:UpdatePanel ID="upReporte" runat="server" ChildrenAsTriggers="true" Visible="false" UpdateMode="Conditional">
        <ContentTemplate>
    <div class="divs">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="600px" Width="900px">
            <LocalReport ReportPath="Pedidos\Reportes\Pedidos.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                        Name="DataSet1_INS_Pedido" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetData" TypeName="DataSet1TableAdapters.INS_PedidoTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="desde" SessionField="desde" Type="DateTime" />
                <asp:SessionParameter Name="hasta" SessionField="hasta" Type="DateTime" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
