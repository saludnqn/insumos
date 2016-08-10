<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsultaMedicacion.aspx.cs" Inherits="Recetas_ConsultaMedicacion" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="acInsumos" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>
    <script type="text/javascript" src="../js/json2.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate><b>Farmacia</b>
            <div class="divs">
                <h2>
                    Consultas de Medicación Dispensada</h2>
                <table>
                    <tr>
                        <td>
                            Fecha Inicio:
                            <asp:TextBox ID="txtFInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp; Fecha Fin:
                            <asp:TextBox ID="txtFFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            Selección de Medicamentos:
                            <uc1:acInsumos ID="acInsumos" runat="server" />
                        </td>
                        <td>
                            <div style="margin-left: 50px; margin-top: -35px;">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ToolTip="Buscar Dispensaciones"
                                    OnClick="btnBuscar_Click" />
                            </div>                       
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="divs">
                <div class="contentBoxW">
                    <asp:GridView ID="gvRecetas" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                        EmptyDataText="No existen registros de dispensaciones del medicamento seleccionado">
                        <Columns>
                            <asp:BoundField DataField="codigo" HeaderText="Código" />
                            <asp:BoundField DataField="nombre" HeaderText="Medicamento" />
                            <asp:BoundField DataField="fechaDispensacion" HeaderText="Fecha Entrega" />
                            <asp:BoundField DataField="cantidadEmitida" HeaderText="Cant. Entregada" />
                            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                            <asp:BoundField DataField="numeroDocumento" HeaderText="Dni" />
                            <asp:BoundField DataField="obrasocial" HeaderText="ObraSocial" />
                            <asp:BoundField DataField="prescripcion" HeaderText="Prescripción" />
                            <asp:BoundField DataField="profesional" HeaderText="Medico" />
                            <asp:BoundField DataField="diagnostico" HeaderText="Diagnostico" />
                            <asp:BoundField DataField="tratamiento" HeaderText="Tratamiento" />
                            <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
</asp:Content>
