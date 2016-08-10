<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="DatosFarmaceuticos_List" %>

<%@ Register Src="~/UserControls/acMedicamento.ascx" TagName="acMedicamento" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>

    <script type="text/javascript" src="../js/json2.js"></script>

    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
 <div class="divs">
        <h2>
            Datos Farmacéuticos de Medicamentos</h2>
        Seleccione el Medicamento:
        <asp:DropDownList ID="ddlInsumos" runat="server" AutoPostBack="true" DataTextField="nombre"
            DataValueField="idInsumo" OnSelectedIndexChanged="ddlInsumos_SelectedIndexChanged">
        </asp:DropDownList><%--<br />
        <div style="font-family: Verdana">
        <uc1:acMedicamento ID="acMedicamento" runat="server" />
        </div>--%>
    </div>
    <br />
    <div class="divs">
        <div class="contentBoxW">
            <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                EmptyDataText="El Medicamento no posee Datos Farmacéuticos.">
                <Columns>
                    <asp:BoundField DataField="idInsumo" HeaderText="Código" />
                    <asp:BoundField DataField="codigoOMS" HeaderText="CodigoOMS" />
                    <asp:BoundField DataField="nivelComplejidad" HeaderText="Complejidad" />
                    <asp:BoundField DataField="composicion" HeaderText="Composición" />
                    <asp:BoundField DataField="contraindicaciones" HeaderText="Contraindicaciones" />
                    <asp:BoundField DataField="accionTerapeutica" HeaderText="Acción Terapéutica" />
                    <asp:BoundField DataField="modifiedOn" HeaderText="Fecha Actulización" DataFormatString="{0:dd/MM/yyy}" />
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <a href="View.aspx?id=<%# Eval("IdDatoFarmaceutico") %>" title="Ver Datos">
                                <img id="imgView" alt="Ver Datos" border="0" src="../App_Themes/Default/images/search.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a href="Edit.aspx?id=<%# Eval("IdDatoFarmaceutico") %>" title="Modificar Datos">
                                <img id="imgEdit" alt="Editar Datos" border="0" src="../App_Themes/Default/images/edit.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
 <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>

