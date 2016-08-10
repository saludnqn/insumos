<%@ Page Title="Pedidos Externos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PedidosExternos.aspx.cs" Inherits="PedidosH_PedidosExternos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="container">
        <section class="titulo">
            <label>ACCESO AL SISTEMA PEDIDOS VIA WEB</label>
        </section>
        <br />

        <div style="text-align: center;">
            <asp:LinkButton ID="btnSistemaIntegrado" runat="server"
                OnClick="btnSistemaIntegrado_Click" CssClass="btn btn-success btn-md" ToolTip="Acceso al Sistema Integrado de Insumos">
                            <span> <i class="glyphicon glyphicon-ok"> </i></span>  Ingresar
            </asp:LinkButton>
        </div>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
        <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
            <div class="floatRight">
                <asp:LinkButton ID="btnCerrar" runat="server"
                OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
            </asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
