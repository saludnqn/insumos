<%@ Page Title="Consumo Por Pacientes" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsumosPorPaciente.aspx.cs" Inherits="Recetas_InsumosPorPaciente" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="Medicamento" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
   <script type="text/javascript" src="../js/Format.js"></script>

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>

    <script type="text/javascript" src="../js/json2.js"></script>

    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <b>Farmacia</b>
    <div class="divs">
        <table width="90%">
            <tr>
                <td>
                    <h2>
                        Consumo de Medicamentos por Pacientes</h2>
                </td>
            </tr>
            <tr>
                <td>
                    Seleccione el Medicamento:
                    <uc1:Medicamento ID="Medicamento" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Ingrese la Fecha de la Prescripción
                    <br />
                    Desde:
                    <asp:TextBox ID="txtFechaInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp; Hasta:
                    <asp:TextBox ID="txtFechaFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar >>" ToolTip="Buscar prescripciones dispensadas en Internación"
                        Height="23px" OnClick="btnBuscar_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbImprimir" runat="server" ToolTip="Exportar e Imprimir" Visible="false"
                        OnClick="lbImprimir_Click">Imprimir Listado</asp:LinkButton>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="lblmsn" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" EmptyDataText="No se encontraron dispensas del Medicamento seleccionado"
                        CssClass="mGrid">
                        <Columns>
                            <asp:BoundField DataField="dni" HeaderText="DNI" />
                            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                            <asp:BoundField DataField="Entregado" HeaderText="Cantidad" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />
</asp:Content>
