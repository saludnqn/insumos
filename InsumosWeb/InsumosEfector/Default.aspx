<%@ Page Title="Asignacion de Insumos" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="InsumosEfector_Default" %>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="divs">
                <h2>
                    Asignación de Insumos</h2>
                <br />
                Seleccione la Zona:
                <asp:DropDownList ID="ddlZona" runat="server" TabIndex="1" DataTextField="nombre"
                    DataValueField="idZona" AutoPostBack="true" ToolTip="Seleccione la Zona" OnSelectedIndexChanged="ddlZona_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                Seleccionar el Efector:
                <asp:DropDownList ID="ddlEfector" runat="server" TabIndex="2" DataTextField="nombre"
                    DataValueField="idEfector" AutoPostBack="true" ToolTip="Seleccionar el Efector" OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblComplejidad" runat="server" Text="" ToolTip="Nivel de Complejidad del Efector" />
                &nbsp;&nbsp;&nbsp;
            </div>
            <br />
            <div class="divs">
                <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="gvInsumos_PageIndexChanging"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" ShowFooter="true"
                    OnRowCommand="gvInsumos_RowCommand" OnRowCreated="gvInsumos_RowCreated" OnRowDataBound="gvInsumos_RowDataBound"
                    EmptyDataText="No hay insumos que comiencen con la letra solicitada." AllowPaging="false">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" title="Seleccionar Todos/Ninguno" name="all" id="all" onclick="checkAll();" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkInsumos" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CODIGO">
                            <ItemTemplate>
                                <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("idInsumo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="INSUMOS">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre") %>' ToolTip='<%# Bind("Unidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripción">
                            <ItemTemplate>
                                <asp:Label ID="lblIdInsumo" runat="server" CssClass="contentBox" Text='<%# Bind("descripcion") %>'></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />
</asp:Content>
