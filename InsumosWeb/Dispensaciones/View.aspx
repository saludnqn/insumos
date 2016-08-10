<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Dispensaciones_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>Dispensación Ambulatoria</h2>
        <table width="100%">
            <tr>
                <td>Fecha:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>Tipo Prescripción:
                    <asp:Label ID="lblPrescripcion" runat="server"></asp:Label>
                </td>
                <td>Tratamiento:
                    <asp:Label ID="lblTratamiento" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbTicket" runat="server" ToolTip="Imprimir Ticket de la Dispensación" Visible="false"
                        OnClick="lbTicket_Click">Imprimir Dispensación</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbCronico" runat="server" ToolTip="Imprimir Ticket Cronico" OnClick="lbCronico_Click"
                        Visible="false">Ticket Cronico</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">
                    <b>Datos del Paciente</b>
                </td>
            </tr>
            <tr>
                <td>Documento Unico:
                    <asp:Label ID="lblDocumento" runat="server"></asp:Label>
                </td>
                <td>Nombre:
                    <asp:Label ID="lblPaciente" runat="server"></asp:Label>
                </td>
                <td>Sexo:
                    <asp:Label ID="lblSexo" runat="server"></asp:Label>
                    | Fecha de Nacimiento:
                    <asp:Label ID="lblFechaNac" runat="server"></asp:Label>
                    | Edad:
                    <asp:Label ID="lblEdad" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">Obra Social:
                    <asp:Label ID="lblOSocial" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="upCronico" runat="server" visible="true">
                        Total Tratamiento:
                        <asp:Label ID="lblDuracion" runat="server"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="lblUnidadDuracion" runat="server"></asp:Label>
                       <%-- &nbsp;&nbsp;&nbsp;| Próxima Fecha Dispensación:
                        <asp:Label ID="lblProximaFecha" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;| Nro. Dispensaciones:
                        <asp:Label ID="lblNroDispensacion" runat="server"></asp:Label>--%>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <h2>Medicación</h2>
    </div>

    <asp:GridView ID="gvReceta" runat="server" CellPadding="2" CssClass="table table-bordered table-condensed table-hover" AutoGenerateColumns="false"
        OnRowDataBound="gvReceta_RowDataBound">
        <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="black" />
        <Columns>
            <asp:BoundField DataField="idDispensacionDetalle" HeaderText="Id" Visible="false" />
            <asp:BoundField DataField="renglon" HeaderText="Renglón" />
            <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
            <asp:TemplateField HeaderText="Insumo">
                <ItemTemplate>
                    <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Dosis" HeaderText="Dosis Diaria o N° UP x Día" Visible="false" />
            <asp:BoundField DataField="UnidadDosis" HeaderText="Unidad Dosis" Visible="false" />
            <asp:BoundField DataField="DiasTratamiento" HeaderText="Días Tratamiento" Visible="false" />
            <asp:TemplateField HeaderText="Prescripto">
                <ItemTemplate>
                    <asp:Label ID="lblSolicitado" runat="server" Text='<%# Eval("CantidadSolicitada") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Entregado">
                <ItemTemplate>
                    <asp:Label ID="lblEntregado" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Adeudado">
                <ItemTemplate>
                    <asp:Label ID="lblDeuda" runat="server" ToolTip="Cantidad Adeudada" Text='<%# Eval("Deuda") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="modifiedOn" HeaderText="Actualización" Visible="false" />
        </Columns>
    </asp:GridView>

    <br />
    Diagnóstico:
        <asp:Label ID="lblDiagnostico" runat="server"></asp:Label><br />
    Observaciones:
        <asp:Label ID="lblObservaciones" runat="server"></asp:Label><br />
    Profesional:
        <asp:Label ID="lblProfesional" runat="server"></asp:Label>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
        <div class="container">
            <div class="floatRight">
                <asp:LinkButton ID="btnCerrar" runat="server"
                    OnClientClick="cerrarVentana()" onClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <script>
        function cerrarVentana() {
            window.close();
        }
    </script>

</asp:Content>


