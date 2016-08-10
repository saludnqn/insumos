<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="VerDispensaRapida.aspx.cs" Inherits="Recetas_VerDispensaRapida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>
            Prescripción Rápida Ambulatoria</h2>
        <table width="100%">
            <tr>
                <td>
                    Fecha:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>
                    Tipo Prescripción:
                    <asp:Label ID="lblPrescripcion" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <b>Datos del Paciente</b>
                </td>
            </tr>
            <tr>
                <td>
                    Documento Unico:
                    <asp:Label ID="lblDocumento" runat="server"></asp:Label>
                </td>
                <td>
                    Nombre:
                    <asp:Label ID="lblPaciente" runat="server"></asp:Label>
                </td>
                <td>
                    Sexo:
                    <asp:Label ID="lblSexo" runat="server"></asp:Label>
                    | Fecha de Nacimiento:
                    <asp:Label ID="lblFechaNac" runat="server"></asp:Label>
                    | Edad:
                    <asp:Label ID="lblEdad" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <h2>
            Medicación</h2>
        <div class="contentBoxW">
            <asp:GridView ID="gvReceta" runat="server" CellPadding="2" CssClass="mGrid" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="idPrescripcionDetalle" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("InsInsumo.Nombre") %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Entregado">
                        <ItemTemplate>
                            <asp:Label ID="lblEntregado" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UnidadDosis" HeaderText="Unidad" />
                    <asp:BoundField DataField="modifiedOn" HeaderText="Actualización" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        Observaciones:
        <asp:Label ID="lblObservaciones" runat="server"></asp:Label><br />
        Profesional:
        <asp:Label ID="lblProfesional" runat="server"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="printButton" runat="server" Text="Imprimir" OnClientClick="javascript:window.print();" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEditar" runat="server" Text="Editar datos" OnClick="btnEditar_Click"
        ToolTip="Click para editar los datos" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNuevo" runat="server" Text="Nueva Receta" OnClick="btnNuevo_Click"
        ToolTip="Click para realizar una nueva receta" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
