<%@ Page Title="Vista de la Provision" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="ProvisionesH_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Provisiones</b>
        <h2>
            Datos Ingresados</h2>
        <table>
            <tr>
                <td>
                    Efector:
                    <asp:Label ID="lblEfector" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbImprimir" runat="server" ToolTip="Exportar a PDF" OnClick="lbImprimir_Click">Imprimir PDF</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <%--<asp:LinkButton ID="lbPInterna" runat="server" ToolTip="Exportar a PDF" OnClick="lbPInterna_Click">Provision Interna</asp:LinkButton>--%>
                </td>
            </tr>
            <tr>
                <td>
                    Depósito:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha Recepción:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>
                    Proveedor:
                    <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo Comprobante:
                    <asp:Label ID="lblTComprobante" runat="server"></asp:Label>
                </td>
                <td>
                    Número Comprobante:
                    <asp:Label ID="lblNroComprobante" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Orden de Compra:
                    <asp:Label ID="lblOCompra" runat="server"></asp:Label>
                </td>
                <td>
                    Estado Suministro:
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <h2>
            Insumos</h2>
        <div class="contentBoxW">
            <asp:GridView ID="gvInsumos" runat="server" CellPadding="2" CssClass="table table-bordered table-condensed table-hover" AutoGenerateColumns="false">
                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                <Columns>
                    <asp:BoundField DataField="idPedidoDetalle" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unidad" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CantidadSolicitada" HeaderText="Solicitado" />
                    <asp:BoundField DataField="CantidadAutorizada" HeaderText="Autorizado" visible="false"/>
                    <asp:BoundField DataField="CantidadEmitida" HeaderText="Enviado" />
                    <asp:BoundField DataField="CantidadRecibida" HeaderText="Recibido" />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" />
                    <asp:TemplateField HeaderText="Info" Visible="false">
                        <ItemTemplate>
                            <a href="DatosInsumo.aspx?id=<%# Eval("IdPedido") %>&idInsumo=<%# Eval("IdInsumo") %>"
                                target="_blank" title="Datos del Insumo" onclick="window.open(this.href, this.target, 'width=900,height=400,scrollbars=yes,top=100, left=100'); return false;">
                                <img id="imgVer" alt="Mas datos del Insumo" border="0" src="../App_Themes/Default/images/mas.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    Responsable:
                    <asp:Label ID="lblResponsable" runat="server" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" />
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>                                
        </div>
        </div>

</asp:Content>
