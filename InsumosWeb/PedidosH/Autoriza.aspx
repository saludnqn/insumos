<%@ Page Title="Autorizar Pedido" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Autoriza.aspx.cs" Inherits="Pedidos_Autoriza" %>

<%@ Register TagPrefix="custom" Namespace="CompareValidatorHelper" Assembly="CompareValidatorHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Pedidos</b>
        <h2>
            Autorizar Pedido (Paso 2)</h2>
        <asp:Label ID="lblEstados" runat="server" Text=""></asp:Label>
        <table width="99%">
            <tr>
                <td>
                    Tipo:
                    <asp:Label ID="lblTPedido" runat="server"></asp:Label>
                </td>
                <td>
                    Fecha:
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Origen Pedido:
                    <asp:Label ID="lblDeposito" runat="server"></asp:Label>
                </td>
            </tr>
<%--            <tr>
                <td colspan="2">
                    Efector Proveedor:
                    <asp:Label ID="lblEfectorProveedor" runat="server"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td colspan="2">
                    Proveedor:
                    <asp:Label ID="lblDepositoProveedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Rubro:
                    <asp:Label ID="lblRubro" runat="server"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div class="divs">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <div class="contentBox">
                        <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" CellPadding="2"
                            ForeColor="#333333" Width="100%" GridLines="Both" PagerStyle-CssClass="pager"
                            PageSize="10" AllowPaging="True" Font-Names="tahoma" Font-Size="10pt" 
                            onrowdatabound="gvInsumos_RowDataBound">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                                <asp:TemplateField HeaderText="IdInsumo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insumo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" runat="server" Text='<%# String.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                            Title='<%# Eval("InsInsumo.Descripcion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unidad">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Solicitado">
                                    <ItemTemplate>
                                        <%--<asp:TextBox ID="txtCantidadSolicitada" runat="server" Width="60px" ReadOnly="true" Text='<%# Eval("cantidadSolicitada") %>' />--%>
                                        <asp:Label ID="lblCantidadSolicitada" runat="server" Text='<%# Eval("cantidadSolicitada") %>' />
                                       <%-- <asp:HiddenField ID="hfCantidadSolicitada1" runat="server" Value='<%# Eval("cantidadSolicitada") %>' />--%>
                                        <custom:VHiddenField ID="hfCantidadSolicitada" runat="server" Value='<%# Eval("cantidadSolicitada") %>' />
                                   </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Autorizado">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCAutorizada" runat="server" ToolTip="Ingrese la Cantidad Autorizada" Width="60px" Text='<%# Eval("CantidadAutorizada") %>' OnTextChanged="VerificaCantidad" AutoPostBack="true" TabIndex="1">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtCAutorizada" ErrorMessage="Debe ingresar un valor" ValidationGroup="P" SetFocusOnError="true"
                                            Display="Dynamic">*</asp:RequiredFieldValidator>
                                        <%--<asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtCAutorizada" Operator="LessThanEqual"
                                            ControlToCompare="txtCantidadSolicitada" ErrorMessage="La cantidad Autorizada no debe ser mayor a la Cantidad Solicitada."
                                            SetFocusOnError="true" Display="Dynamic" ValidationGroup="P">*</asp:CompareValidator>--%>
                                        <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtCAutorizada" ControlToCompare="hfCantidadSolicitada" Operator="LessThanEqual" ErrorMessage="La cantidad Autorizada debe ser Menor o Igual a la Cantidad Solicitada."
                                          Display="Dynamic"  SetFocusOnError="true" ValidationGroup="P">*</asp:CompareValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observacion">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtObservacion" runat="server" ToolTip="Observacion del Insumo" TabIndex="2"
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
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Size="Small" Font-Bold="True" />
                            <HeaderStyle BackColor="#00898c" ForeColor="White" VerticalAlign="Middle" Font-Bold="True"
                                HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    Responsables:
                    <%-- <asp:Label ID="lblResponsable" runat="server"></asp:Label>  --%>
                    <asp:TextBox ID="txtResponsable" runat="server" Width="60%" TabIndex="3"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Observaciones:
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="80%" TextMode="MultiLine"
                        Rows="3"></asp:TextBox>
                </td>
            </tr>
            <tr style="border: solid 2px #00898c;">
                <td colspan="2">
                    <%--Estado Pedido:
                    <asp:DropDownList ID="ddlEstados" runat="server" DataValueField="idEstadoPedido"
                        DataTextField="nombre" ToolTip="Autorizar y Cambiar de estado el actual pedido" />
                    &nbsp;&nbsp;&nbsp;--%>                    
                </td>
            </tr>
            <tr>
                <td>
                    Sacar de línea el Pedido Actual:
                    <asp:CheckBox ID="ckbBaja" runat="server" ToolTip="Click para eliminar el pedido actual" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="P"
            DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar y Guardar Pedido" ValidationGroup="P"
        ToolTip="Guardar" OnClick="btnAutorizar_Click" />
    <input type="button" value="Volver" title="Volver y Editar" onclick="history.go(-1)" />
    <%--<asp:Button ID="btnNuevo" runat="server" Text="Nuevo Pedido" ToolTip="Click para realizar un nuevo Pedido"
        OnClick="btnNuevo_Click" />--%>
</asp:Content>
