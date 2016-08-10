<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Insumos_List" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagPrefix="uc" TagName="usInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/json2.js"></script>
    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
    <h2>
        Localización de Insumos</h2>
    <table>
        <tr>
            <td>
                <uc:usInsumo runat="server" ID="usInsumo" TabIndex="1" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="hlDatosfarmacia" runat="server" OnClick="hlDatosfarmacia_Click" ToolTip="Ingresar Datos Farmacéuticos al Medicamento seleccionado." ImageUrl="~/App_Themes/Default/images/datosfar.png" />
                &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="hlAlarma" runat="server" OnClick="hlDatosalarma_Click" ToolTip="Ingresar Datos de Alarma al Medicamento seleccionado." ImageUrl="~/App_Themes/Default/images/alarmita.png" />              
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnEditar" runat="server" Text="Modificar" OnClick="btnEditar_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
