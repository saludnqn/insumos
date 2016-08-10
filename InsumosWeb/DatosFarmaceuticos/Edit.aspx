<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="DatosFarmaceuticos_Edit" %>

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
        Datos Farmacéuticos</h2>
    <b>Medicamento:
        <asp:Label ID="lblInsumo" runat="server"></asp:Label></b><br />
    <uc1:acMedicamento ID="acMedicamento" runat="server" />
    <br />
    <table>
        <tr>
            <td>
                <asp:CheckBox ID="ckbReceta" Text="Necesita receta?" runat="server" TextAlign="Left"
                    ToolTip="Seleccionar si corresponde" />
            </td>
            <td>
                Código OMS:
                <asp:TextBox ID="txtCodigo" runat="server" ToolTip="Código único de la OMS"></asp:TextBox>
            </td>
            <td>
                Nivel de Complejidad:
                <asp:DropDownList ID="ddlComplejidad" runat="server" ToolTip="Establacer el Nivel de Complejidad que puede tener acceso al medicamento">
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Composición:
            </td>
            <td colspan="2">
                <p>
                    <asp:TextBox ID="txtComposicion" runat="server" Width="99%" ToolTip="Ingrese la composicion química del medicamento"
                        TextMode="MultiLine" Rows="3"></asp:TextBox>
                </p>
            </td>
        </tr>
        <tr>
            <td>
                Acción Terapéutica:
            </td>
            <td colspan="2">
                <p>
                    <asp:TextBox ID="txtATerapeutica" runat="server" Width="99%" TextMode="MultiLine"
                        Rows="3" ToolTip="Indicar la acción terapéutica que puede tener el Medicamento en determinados órganos."></asp:TextBox>
                </p>
            </td>
        </tr>
        <tr>
            <td>
                Contraindicaciones:
            </td>
            <td colspan="2">
                <p>
                    <asp:TextBox ID="txtContraindicaciones" runat="server" Width="99%" TextMode="MultiLine"
                        Rows="3" ToolTip="Indicar las contraindicaciones que el uso del medicamento puede provocar al paciente. "></asp:TextBox>
                </p>
            </td>
        </tr>
    </table>
 </div>   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    <input type="button" value="Cancelar" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
