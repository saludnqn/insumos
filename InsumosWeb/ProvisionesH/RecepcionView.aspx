<%@ Page Title="Datos Recibidos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="RecepcionView.aspx.cs" Inherits="ProvisionesH_RecepcionView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>INGRESOS</b>
        <h2>
            Recepción de Insumos</h2>
        <table>
            <tr>
                <td>
                    Pedido Nº:
                    <asp:Label ID="lblPedido" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>                    
                    Depósito Proveedor:
                    <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    Depósito Destino:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                     
                </td>
            </tr>
            <tr>
                <td>
                    Fecha Pedido:
                    <asp:Label ID="lblFechaPedido" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp; Fecha Envío:
                    <asp:Label ID="lblFechaEnvio" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo de Pedido:
                    <asp:Label ID="lblTipoPedido" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp; Estado del Pedido:
                    <asp:Label ID="lblEstadoPedido" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <div class="contentBox">
            <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" PagerStyle-CssClass="pager"
                PageSize="10" AllowPaging="True" CssClass="table table-bordered table-condensed table-hover" 
                onrowdatabound="gvInsumos_RowDataBound" >
                 <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />

                <Columns>
                    <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                    <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Insumo">
                        <ItemTemplate>
                            <asp:Label ID="lblInsumo" runat="server" Width="250px" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                Title='<%# Eval("InsInsumo.Descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unidad" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lote">
                        <ItemTemplate>
                            <asp:Label ID="lblLote" runat="server" Text='<%# Eval("NumeroLote") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vencimiento">
                        <ItemTemplate>
                            <asp:Label ID="lblVencimiento" runat="server" Text='<%# Eval("FechaVencimiento") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad Enviada">
                        <ItemTemplate>
                            <asp:Label ID="lblCantidadEmitida" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad Recibida">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCRecibida" runat="server" ToolTip="Ingrese la Cantidad Recibida"
                                Width="60px" Text='<%# Eval("CantidadRecibida") %>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion">
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservacion" runat="server" ToolTip="Observacion del Insumo"
                                Width="250px" Text='<%# Eval("Observacion") %>'>
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="idPedidoDetalle" Visible="false">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblidPedidoDetalle" Text='<%# Bind("idPedidoDetalle") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table width="98%">
            <tr>
                <td>
                    Responsable:
                    <asp:Label ID="lblResponsable" runat="server"></asp:Label>
                    <p></p>
                </td>
            </tr>
            <tr>
                <td>
                    Observaciones: <asp:TextBox ID="txtObservaciones" runat="server" Width="80%" TextMode="MultiLine"
                        Rows="3"></asp:TextBox>
                </td>
            </tr>
            <%--<tr style="border: solid 2px #00898c;">
                <td>
                    Estado Pedido:
                    <asp:DropDownList ID="ddlEstados" runat="server" DataValueField="idEstadoPedido"
                        DataTextField="nombre" ToolTip="Autorizar y Cambiar de estado el actual pedido" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblEstados" runat="server" Text=""></asp:Label>
                </td>
            </tr>--%>
        </table>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnGuardar" runat="server" 
                   OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" ToolTip="Aceptar">
                    <span> <i class="glyphicon glyphicon-ok"> </i></span>  Guardar
                </asp:LinkButton>
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>                                
        </div>
        </div>
</asp:Content>
