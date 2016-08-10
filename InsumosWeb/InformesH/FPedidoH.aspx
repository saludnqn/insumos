<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FPedidoH.aspx.cs" Inherits="InformesH_FPedidoH" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="600px" Width="900px">
        <LocalReport ReportPath="InformesH\RPTPedidoH.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSPedidoH_INS_RPTPedidoH" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetData" TypeName="DSPedidoHTableAdapters.INS_RPTPedidoHTableAdapter" OldValuesParameterFormatString="original_{0}">
     <SelectParameters>
                <asp:SessionParameter Name="efector" SessionField="efector" Type="Int32" 
                    DefaultValue="1" />
                <asp:SessionParameter Name="deposito" SessionField="deposito" Type="Int32" 
                    DefaultValue="0" />
                <asp:SessionParameter Name="pedido" SessionField="pedido" Type="Int32" 
                    DefaultValue="0" />
      </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
<input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>