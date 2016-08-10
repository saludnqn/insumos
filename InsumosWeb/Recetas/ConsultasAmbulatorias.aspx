<%@ Page Title="Ambulatorias" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultasAmbulatorias.aspx.cs" Inherits="Recetas_ConsultasAmbulatorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
 <script type="text/javascript" src="../js/Format.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
     <div class="divs"><b>Farmacia</b>
        <table width="80%">
            <tr>
                <td>
                    <h2>
                        Medicación Ambulatoria Dispensada</h2>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha de Prescripción:
                    <asp:TextBox ID="txtFecha" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                        onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar >>" ToolTip="Buscar prescripciones dispensadas en Internación"
                        Height="23px" OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <div id="panel" runat="server">
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" CssClass="lblmsn" Text=""></asp:Label>
                        <b>
                            <asp:Label ID="lblArea" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblServicio" runat="server" Text=""></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbImprimir" runat="server" ToolTip="Exportar e Imprimir" Visible="false" OnClick="lbImprimir_Click">Imprimir Listado</asp:LinkButton>
                        </b>
                        <br />
                        <asp:GridView ID="gvAmbulatorio" runat="server" AutoGenerateColumns="false" EmptyDataText="Sin Pedidos Generados"
                            CssClass="mGrid">
                            <Columns>
                                <asp:TemplateField HeaderText="Medicamento">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("Insumo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                                <asp:BoundField DataField="DosisDiaria" HeaderText="Dosis" />
                                <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                                <asp:BoundField DataField="CantidadSolicitada" HeaderText="Solicitado" />
                                <asp:TemplateField HeaderText="Entregado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="deuda" HeaderText="Deuda" />
                            </Columns>
                        </asp:GridView>
                       <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
 <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />
</asp:Content>

