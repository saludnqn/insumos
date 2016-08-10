<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Stock.aspx.cs" Inherits="Recetas_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>
            Stock Actual del Depósito Seleccionado</h2>
        <br />
        <div class="contentBoxW">
            <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                PagerStyle-CssClass="pager" EmptyDataText="No se encontraron resultados." ShowFooter="True"
                PageSize="15" AllowPaging="True" OnRowDataBound="gvStock_RowDataBound" OnDataBound="gvStock_DataBound">
                <Columns>
                    <asp:BoundField DataField="Insumo" HeaderText="Medicamento" />
                    <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="edad" HeaderText="Edad" />
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
                    <%--                    <asp:BoundField DataField="stockActual" HeaderText="Stock Actual" />
--%>
                    <asp:BoundField DataField="fechaEntregaPaciente" HeaderText="Fecha Entrega" />
                </Columns>
                <FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" />
            </asp:GridView>
        </div>
        <div style="text-align: center">
            <asp:Label ID="lblTotal" runat="server" CssClass="lbl"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblStock" runat="server" CssClass="lbl" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
