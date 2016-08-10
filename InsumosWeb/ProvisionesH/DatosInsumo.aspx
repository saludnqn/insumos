<%@ Page Title="Datos del Insumo" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="DatosInsumo.aspx.cs" Inherits="ProvisionesH_DatosInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs">
        <h2>
            Datos del Insumo</h2>
        <br />
        <asp:GridView ID="gvInsumos" runat="server" CssClass="mGrid" 
            AutoGenerateColumns="false" onrowdatabound="gvInsumos_RowDataBound">
            <Columns>
                <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                <asp:TemplateField HeaderText="Código">
                    <ItemTemplate>
                        <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("InsInsumo.Codigo") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Insumo">
                    <ItemTemplate>
                        <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("InsInsumo.Nombre") %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Presentación">
                    <ItemTemplate>
                        <asp:Label ID="lblPresentacion" runat="server" Text='<%# "x " + Eval("presentacion") + " "+ Eval("InsInsumo.Unidad") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Unitario">
                    <ItemTemplate>
                        <asp:Label ID="lblPrecio" runat="server" Text='<%# "$ " + Eval("precioUnitario") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="numeroLote" HeaderText="Nº Lote" />
                <asp:BoundField DataField="fechaVencimiento" HeaderText="Fecha de Vencimiento" DataFormatString="{0:dd/MM/yyy}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cerrar" title="Cerrar ventana" onclick="window.close()" />
</asp:Content>
