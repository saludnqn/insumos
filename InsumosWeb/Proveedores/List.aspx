<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Proveedores_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Listado de Poveedores</h2>
        Seleccione el Efector:
        <asp:DropDownList ID="ddlEfector" runat="server" AutoPostBack="true" DataTextField="nombre"
            DataValueField="idEfector" OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <br />
    <div class="divs">
        <div class="contentBoxW">
            <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                EmptyDataText="El efector no posee proveedores internos">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Código" />
                    <asp:BoundField DataField="nombre" HeaderText="Proveedor" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="cuit" HeaderText="CUIT" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                    <asp:BoundField DataField="email" HeaderText="Correo Electrónico" />
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <a href="View.aspx?id=<%# Eval("IdProveedor") %>" title="Ver Proveedor">
                                <img id="imgView" alt="Ver Proveedor" border="0" src="../App_Themes/Default/images/search.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <a href="Edit.aspx?id=<%# Eval("IdProveedor") %>" title="Modificar Proveedor">
                                <img id="imgEdit" alt="Editar Proveedor" border="0" src="../App_Themes/Default/images/edit.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
