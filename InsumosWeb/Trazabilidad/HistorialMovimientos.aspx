<%@ Page Title="Historial de Movimientos de Insumos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="HistorialMovimientos.aspx.cs" Inherits="Trazabilidad_HistorialMovimientos" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="Insumo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>

    <script type="text/javascript" src="../js/json2.js"></script>

    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Consultas</b>
        <h2>
            Historial de Entregas de Medicamentos</h2>
        Ingrese el nombre o código del Medicamento:
        <uc1:Insumo ID="Insumo" runat="server" />
        <br />
        <div>
            Fecha Desde:
            <asp:TextBox ID="txtFechaInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp; Hasta:
            <asp:TextBox ID="txtFechaFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ToolTip="Buscar Insumos"
                OnClick="btnBuscar_Click" />        
            <asp:Label ID="lblMensaje" runat="server" CssClass="lblmsn" Text=""></asp:Label>
        </div>
    </div>
    <br />
    <div class="divs">
         <asp:ListView ID="rptControles" runat="server" ItemPlaceholderID="phDepositos" OnItemDataBound="rptControles_ItemDataBound">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder ID="phDepositos" runat="server" />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <asp:Label ID="lblDepositos" runat="server" Text='<%# Eval("Deposito") %>' Font-Bold="true" />
                </div>
                <div>
                    <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                        <Columns>
                            <asp:BoundField DataField="medicamento" HeaderText="Medicamento" />
                            <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                            <asp:BoundField DataField="CantidadEmitida" HeaderText="Cantidad Enviada" />
                        </Columns>
                    </asp:GridView>
                </div>
                <hr />
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Vuelve a la página anterior" onclick="history.go(-1)" />
</asp:Content>
