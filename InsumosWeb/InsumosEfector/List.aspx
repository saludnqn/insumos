<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="InsumosEfector_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="divs">
                <h2>
                    Insumos por Efector</h2>
                <br />
                Seleccione la Zona:
                <asp:DropDownList ID="ddlZona" runat="server" TabIndex="1" DataTextField="nombre" DataValueField="idZona" AutoPostBack="true" 
                    ToolTip="Seleccione la Zona" onselectedindexchanged="ddlZona_SelectedIndexChanged"></asp:DropDownList>
                <br />
                Seleccionar el Efector:
                <asp:DropDownList ID="ddlEfector" runat="server" TabIndex="2" DataTextField="nombre"
                    DataValueField="idEfector" AutoPostBack="true" ToolTip="Seleccionar una opción"
                    OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblComplejidad" runat="server" Text="" ToolTip="Nivel de Complejidad de Efector" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblRegistros" CssClass="lbl" runat="server" Text="" ToolTip="Cantidad de registros encontrados en el Efector" />
            </div>
            <br />
            <div class="divs">
                <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" ShowFooter="true" AllowPaging="true" EmptyDataText="No hay insumos que comiencen con la letra solicitada."
                    PageSize="20" OnPageIndexChanging="gvInsumos_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="idInsumo" HeaderText="Código" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre Suministro" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <asp:Label ID="lblMensaje" CssClass="lbl" runat="server"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />
    <asp:Button ID="btnNuevo" runat="server" Text="Asignar Insumos" ToolTip="Asignar Insumos al Efector seleccionado."
        OnClick="btnNuevo_Click" />
</asp:Content>
