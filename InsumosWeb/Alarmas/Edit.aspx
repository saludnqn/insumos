<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Alarmas_Edit" %>

<%@ Register Src="~/UserControls/acMedicamento.ascx" TagName="acMedicamento" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
<script type="text/javascript" src="../js/Format.js"></script>

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>

    <script type="text/javascript" src="../js/json2.js"></script>

    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
  <div class="divs">
    <h2>
        Condiguración de Alarmas</h2>
    <div>
        <b><asp:Label ID="lblInsumo" runat="server"></asp:Label></b><br />
            <uc1:acMedicamento ID="acMedicamento" runat="server" />  <asp:CheckBox ID="ckbAlarma" runat="server" TextAlign="Left" Text="Activar Alarma"
            ToolTip="Seleccionar para activar la alarma" />
    </div>
    <br />
    <table width="65%" border="1px">
        <tr style="background-color: #edf3f8">
            <td align="center">
               <b>Stock Crítico</b>
            </td>
            <td align="right">
                Cantidad Mínima del Insumo: 
            </td>
            <td>
                <asp:TextBox ID="txtCantidadMinima" runat="server" Width="50px" ToolTip="Solo números"></asp:TextBox>
                Unidades
            </td>
        </tr>
        <tr>
        <td colspan="3">&nbsp;</td>
        </tr>
        <tr style="background-color: #edf3f8">
            <td align="center">
                <b>Fecha de Vencimiento</b>
            </td>
            <td align="right">
                Días antes del Vencimiento: 
            </td>
            <td>
                <asp:TextBox ID="txtDiasVto" runat="server" Width="50px" ToolTip="Solo números"></asp:TextBox>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    <input type="button" value="Cancelar" title="Cancela la Edición y vuelve a la página anterior"
        onclick="history.go(-1)" />
</asp:Content>
