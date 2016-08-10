<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Recetas_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>
            Historial Dispensaciones</h2>
        <div class="contentBox">
            <asp:GridView ID="gvRecetas" runat="server" CellPadding="2" CssClass="mGrid" AutoGenerateColumns="false" OnRowDataBound="gvRecetas_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="numerodocumento" HeaderText="DNI" />
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="edad" HeaderText="Edad" />
                    <asp:BoundField DataField="tipoPrescripcion" HeaderText="Receta" />
                    <asp:BoundField DataField="fechaReceta" HeaderText="Fecha" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglon" />
                    <asp:BoundField DataField="medicacion" HeaderText="Medicacion" />
                    <asp:BoundField DataField="dosis" HeaderText="Dosis" />
                    <asp:BoundField DataField="unidadDosis" HeaderText="Unidad" />
                    <asp:TemplateField HeaderText="Solicitado">
                        <ItemTemplate>
                            <asp:Label ID="lblSolicitado" runat="server" Text='<%# Eval("CantidadSolicitada") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Entregado">
                        <ItemTemplate>
                            <asp:Label ID="lblEntregado" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Deuda">
                        <ItemTemplate>
                            <asp:Label ID="lblDeuda" runat="server" ToolTip="Cantidad Adeudada" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="observacionReceta" HeaderText="Observación" />
                    <asp:BoundField DataField="diastratamiento" HeaderText="Tratamiento" />
                    <asp:BoundField DataField="Profesional" HeaderText="Profesional" />
                    <asp:BoundField DataField="Diagnostico" HeaderText="Diagnostico" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
