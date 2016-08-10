<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="InsumosEfector_Edit" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="acInsumo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript">
        function checkAll() {
            var nodoCheck = document.getElementsByTagName("input");
            var varCheck = document.getElementById("all").checked;
            for (i = 0; i < nodoCheck.length; i++) {
                if (nodoCheck[i].type == "checkbox" && nodoCheck[i].name != "all" && nodoCheck[i].disabled == false) {
                    nodoCheck[i].checked = varCheck;
                }
            }
        }   
    </script>

    <script type="text/javascript" src="../js/Format.js"></script>

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>

    <script type="text/javascript" src="../js/json2.js"></script>

    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Asignación de Insumos al Efector</h2>
        <br />
        Seleccione el Insumo:
        <uc1:acInsumo ID="acInsumo1" runat="server" />
        Seleccione la Zona:
        <asp:DropDownList ID="ddlZona" runat="server" TabIndex="1" DataTextField="nombre"
            DataValueField="idZona" AutoPostBack="true" ToolTip="Seleccione la Zona" OnSelectedIndexChanged="ddlZona_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <br />
    <div class="divs">
        <asp:GridView ID="gvEfectores" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="gvEfectores_PageIndexChanging" AlternatingRowStyle-CssClass="alt"
            ShowFooter="false" OnRowDataBound="gvEfectores_RowDataBound" EmptyDataText="No hay efectores en la zona seleccionada."
            AllowPaging="false">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <input type="checkbox" title="Seleccionar Todos/Ninguno" name="all" id="all" onclick="checkAll();" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkEfector" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EFECTORES DE LA ZONA SELECCIONADA">
                    <ItemTemplate>
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIdEfector" runat="server" Text='<%# Bind("idEfector") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="lblNorecId" runat="server" Text="No se encontraron registros con la letra seleccionada. "></asp:Label>
                <a href="Default.aspx" title="Volver a la pantalla Anterior">Volver</a>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <asp:Label ID="lblMensaje" CssClass="lbl" runat="server"></asp:Label><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />
</asp:Content>
