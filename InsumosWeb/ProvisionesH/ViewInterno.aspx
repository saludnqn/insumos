<%@ Page Title="Vista de la Provision" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewInterno.aspx.cs" Inherits="ProvisionesH_ViewInterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="container">
        <h2>Datos Registro Ingresado</h2>
        <table>
            <tr>
                <td>Efector:
                    <asp:Label ID="lblEfector" runat="server"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbPInterna" runat="server" ToolTip="Exportar a PDF" OnClick="lbPInterna_Click">Imprimir Provision Interna</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>Depósito:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Fecha Recepción:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>Procedencia:
                    <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Tipo Comprobante:
                    <asp:Label ID="lblTComprobante" runat="server"></asp:Label>
                </td>
                <td>Número Comprobante:
                    <asp:Label ID="lblNroComprobante" runat="server"></asp:Label>
                </td>
            </tr>
            <%--<tr>
                <td>Orden de Compra:
                    <asp:Label ID="lblOCompra" runat="server"></asp:Label>
                </td>
                <td>Estado Suministro:
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </td>
            </tr>--%>
        </table>

        <br />

        <h2>Insumos</h2>
        <div class="contentBoxW">
            <asp:GridView ID="gvInsumos" runat="server" CellPadding="2" CssClass="table table-condensed table-hover table-bordered" AutoGenerateColumns="false">
                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="black" />
                <Columns>
                    <asp:BoundField DataField="idPedidoDetalle" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Presentación">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentacion" runat="server" Text='<%# string.Concat(" x ", Eval("Presentacion"), " ", Eval("InsInsumo.Unidad")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recibido">
                        <ItemTemplate>
                            <asp:Label ID="lblRecibido" runat="server" Text='<%# Eval("CantidadRecibida") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="precioUnitario" HeaderText="$ Unitario" Visible="false" />
                    <asp:BoundField DataField="fechaVencimiento" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>Responsable:
                    <asp:Label ID="lblResponsable" runat="server" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" />
                </td>
            </tr>
        </table>
        <br />

        <div id="mensaje" runat="server" visible="false">
            <div class="alert alert-success" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <strong>Confirmación:</strong> El registro se grabó satisfactoriamente!
            </div>
        </div>


        <script>
            window.setTimeout(function () {
                $(".alert").fadeTo(500, 0).slideUp(500, function () {
                    $(this).remove();
                });
            }, 4000);
        </script>


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
        <div class="floatRight">
            <asp:LinkButton ID="btnCerrar" runat="server"
                OnClientClick="cerrarVentana()" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
            </asp:LinkButton>
        </div>
    </div>

    <script>
        function cerrarVentana() {
            window.close();
        }
    </script>
</asp:Content>
