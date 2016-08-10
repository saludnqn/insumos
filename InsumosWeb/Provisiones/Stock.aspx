<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Stock.aspx.cs" Inherits="Provisiones_Stock" Title="Consultas de Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/Format.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="divs">
                    <h2>
                        Stock Actual</h2>
                    <table>
                        <tr>
                            <td colspan="2">
                                Efector:
                                <asp:DropDownList ID="ddlEfector" runat="server" DataValueField="idEfector" DataTextField="nombre"
                                    ToolTip="Seleccione el Efector" AutoPostBack="true" OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged">
                                </asp:DropDownList>
                                  <asp:CompareValidator ID="cve" runat="server" ErrorMessage="Seleccione el Efector" ControlToValidate="ddlEfector" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                        ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Depósito:
                                <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" DataTextField="nombre"
                                    ToolTip="Seleccione el Depósito">
                                </asp:DropDownList>
                                  <asp:CompareValidator ID="cvd" runat="server" ErrorMessage="Seleccione el Depósito" ControlToValidate="ddlDeposito" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                        ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Desde:
                                <asp:TextBox ID="txtFInicio" runat="server" Width="80px" onblur="javascript:formatearFecha(this)"
                                    ToolTip="Fecha Recepción. Ej.: 01/03/76, 01/03/1976, 010376, 01031976"></asp:TextBox>
                            </td>
                            <td>
                                Fecha Hasta:
                                <asp:TextBox ID="txtFFin" runat="server" Width="80px" onblur="javascript:formatearFecha(this)"
                                    ToolTip="Fecha Recepción. Ej.: 01/03/76, 01/03/1976, 010376, 01031976"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <%-- <td>
                            Rubro:
                            <asp:DropDownList ID="ddlRubro" runat="server" DataValueField="idRubro" DataTextField="nombre"
                                ToolTip="Seleccione el Rubro">
                            </asp:DropDownList>
                        </td>--%>
                            <td>
                                Proveedor:
                                <asp:DropDownList ID="ddlProveedor" runat="server" DataValueField="idProveedor" DataTextField="nombre"
                                    ToolTip="Seleccione el Proveedor">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnBuscar" runat="server" Height="23px" Text="Buscar >>" OnClick="btnBuscar_Click" ValidationGroup="P" />
                            </td>
                        </tr>
                    </table>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" ValidationGroup="P" />
                </div>
                <br />
                <asp:UpdatePanel ID="upStock" runat="server" Visible="false">
                    <ContentTemplate>
                        <div class="divs">
                            <div class="contentBoxW">
                                <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                    PagerStyle-CssClass="pager" EmptyDataText="No se encontraron resultados." OnRowDataBound="gvStock_RowDataBound"
                                    OnDataBound="gvStock_DataBound" ShowFooter="True" PageSize="15" AllowPaging="True"
                                    OnPageIndexChanging="gvStock_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="Efector" HeaderText="Efector" />
                                        <asp:BoundField DataField="Deposito" HeaderText="Deposito" />
                                        <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                                        <asp:BoundField DataField="numeroComprobante" HeaderText="Nº. Cpte" />
                                        <asp:BoundField DataField="ordenCompra" HeaderText="Nro. OC" />
                                        <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                                        <asp:BoundField DataField="Insumo" HeaderText="Insumo" />
                                        <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                                        <asp:TemplateField HeaderText="Recibidos" ItemStyle-ForeColor="#00898c">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecibido" runat="server" Text='<%# Eval("cantidadRecibida") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Enviados" ItemStyle-ForeColor="Red">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEnviado" runat="server" Text='<%# Eval("enviado") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stock" ItemStyle-ForeColor="Blue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStock" runat="server" Text='<%# Eval("stockactual") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="P. Unitario">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPUnitario" runat="server" Text='<%# Eval("precioUnitario") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPTotal" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                                        <asp:BoundField DataField="fechaVto" HeaderText="Fecha Vto." />
                                        <asp:BoundField DataField="proveedor" HeaderText="Proveedor" />
                                        <asp:BoundField DataField="Estado" HeaderText="Suministro" />
                                        <asp:BoundField DataField="ModifiedOn" HeaderText="Actualización" />
                                    </Columns>
                                    <FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" />
                                </asp:GridView>
                            </div>
                            <div style="text-align: center">
                                <asp:Label ID="lblTotal" runat="server" CssClass="lbl"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Cancelar" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
