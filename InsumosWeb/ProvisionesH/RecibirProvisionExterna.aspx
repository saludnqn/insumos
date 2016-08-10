<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RecibirProvisionExterna.aspx.cs" Inherits="ProvisionesH_RecibirProvisionExterna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    <script src="../js/Format.js" type="text/javascript"></script>
   
        <script type="text/javascript">
             function siOno() {
                if (!confirm("AVISO: ¿Desea ELiminar definitivamente el item seleccionado?"))
                    history.go(-1)
                return " "
             }
    </script>



    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="container">
    
        <h2>Recepción de Insumos</h2>
        <table>
            <tr>
                <td>Depósito Receptor:
                    <asp:DropDownList ID="ddlDepositoReceptor" runat="server" DataValueField="idDeposito" class="form-control"
                        DataTextField="nombre" ToolTip="Seleccione el Receptor">
                    </asp:DropDownList>
                </td>
                
                <td>&nbsp;&nbsp;D. Proveedor:
                    <asp:Label ID="lblDepositoProveedor" class="form-control" runat="server"></asp:Label>
                </td>
                <td>&nbsp;&nbsp; Pedido Nº:
                    <asp:Label ID="lblPedido" class="form-control" runat="server"></asp:Label>
                </td>
                <td>&nbsp;&nbsp;Fecha Pedido:
                    <asp:Label ID="lblFechaPedido" class="form-control" runat="server"></asp:Label>
                </td>
                <td>&nbsp;&nbsp; Fecha Despacho:
                    <asp:Label ID="lblFechaDespacho" class="form-control" runat="server"></asp:Label>
                </td>                  
            </tr>           
            </table>
    </div>
    <br />
    <div class="divs">
        <div class="contentBox">
            <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" PagerStyle-CssClass="pager"
                CssClass="mGrid" OnRowDataBound="gvInsumos_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="PedidoDetalle" HeaderText="P.Detalle" />--%>

                    <asp:TemplateField HeaderText="P.Detalle">
                        <ItemTemplate>
                           <asp:Label ID="lblIdPedidoDetalle" runat="server" Text='<%# Eval("PedidoDetalle") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Codigo">
                        <ItemTemplate>
                            <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("Insumo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="medicamento" HeaderText="Medicamentos" />
                    
                    <asp:TemplateField HeaderText="Unidad">
                        <ItemTemplate>
                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("Unidad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Multiplicador" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblMultiplicador" runat="server" Text='<%# Eval("multiplicador") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad Enviada">
                        <ItemTemplate>
                            <asp:Label ID="lblCantidadEnviada" runat="server" Text='<%# Eval("Cantidad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Cantidad Recibida">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCantidadRecibida" runat="server" ToolTip="Ingrese la Cantidad Recibida"
                                Width="50px" Text='<%# Eval("Cantidad") %>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                            
                    <asp:TemplateField HeaderText="Nro Lote">
                        <ItemTemplate>
                            <asp:TextBox ID="txtLote" runat="server" ToolTip="Ingrese el Lote"
                                Width="100px" Text='<%# Eval("Lote") %>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha Vto">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFechaVencimiento" runat="server" ToolTip="Ingrese la Fecha de Vencimiento"
                                Width="120px" Text='<%# Eval("FechaVencimiento") %>' onblur="javascript:formatearFecha(this)">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion">
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservaciones" runat="server" ToolTip="Observaciones de la cantidad recibida"
                                Width="250px" Text='<%# Eval("Observaciones") %>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                       <asp:ImageButton runat="server" ID="ibBorrar" ToolTip="Eliminar medicación de la Lista"
                          CommandName ="Delete" CommandArgument='<%# Container.DataItemIndex %>' 
                          ImageUrl="../App_Themes/Default/images/del.png"/>
                       </ItemTemplate>
                    </asp:TemplateField>--%>
                    
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table width="98%">
            <tr>
                <td>Responsable:
                    <asp:TextBox ID="txtResponsable" runat="server" Width="80%" ToolTip="Nombre del Responsable o Usuario"></asp:TextBox>
                    <p>
                    </p>
                </td>
            </tr>
            <tr>
                <td>Observaciones:
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="80%" TextMode="MultiLine"
                        Rows="3"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar >>" OnClick="btnGuardar_Click" />
    <input type="button" value="Cancelar" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
