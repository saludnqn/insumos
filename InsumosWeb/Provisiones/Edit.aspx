<%@ Page Title="Ingreso de Insumos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Provisiones_Edit" %>

<%@ Register Src="~/UserControls/InsumoxEfector.ascx" TagName="acInsumoxEfector" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    <script src="../js/Format.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/json2.js"></script>
    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div class="divs">
        <h2>
            Ingreso de Insumos</h2>
        <table width="99%">
            <tr>
                <td colspan="2">
                    Efector:
                    <asp:DropDownList ID="ddlEfector" runat="server" DataValueField="idEfector" DataTextField="nombre"
                        ToolTip="Seleccione el Efector" AutoPostBack="true" OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cve" runat="server" ErrorMessage="Seleccione el Efector"
                        ControlToValidate="ddlEfector" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                        ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Depósito:
                    <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" DataTextField="nombre"
                        ToolTip="Seleccione el Depósito">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cvd" runat="server" ErrorMessage="Seleccione el Depóosito"
                        ControlToValidate="ddlDeposito" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                        ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                    <asp:HyperLink ID="hlNuevoDeposito" runat="server">Ingresar Nuevo Depósito</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha:
                    <asp:TextBox ID="txtFecha" runat="server" Width="80px" onblur="javascript:formatearFecha(this)"
                        ToolTip="Ej.: 01/03/76, 01/03/1976, 010376, 01031976"></asp:TextBox>
                </td>
                <td>
                    Proveedor:
                    <asp:DropDownList ID="ddlProveedor" runat="server" DataValueField="Codigo" DataTextField="nombre">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo Comprobante:
                    <asp:DropDownList ID="ddlTipoComprobante" runat="server" DataValueField="idTipoComprobante" ToolTip="Seleccione el Tipo de Comprobante"
                        DataTextField="nombre">
                    </asp:DropDownList>
                     <asp:CompareValidator ID="cvc" runat="server" ErrorMessage="Seleccione el Comprobante" ControlToValidate="ddlTipoComprobante" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                        ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                </td>
                <td>
                    Número:
                    <asp:TextBox ID="txtNroComprobante" runat="server" Width="100px" ToolTip="Solo números"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Orden de Compra:
                    <asp:TextBox ID="txtOCompra" runat="server" ToolTip="Ingrese el Nro de Orden de Compra"></asp:TextBox>
                </td>
                <td>
                    Estado:
                    <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Value="true" Selected="True">Activo</asp:ListItem>
                        <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblActivo" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class="divs">
        <table width="100%">
            <tr>
                <td>
                    <h2>
                        Registro de Insumos</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlRubro" runat="server" DataValueField="idRubro" DataTextField="nombre"
                        ToolTip="Seleccionar el Rubro Base">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cvr" runat="server" ErrorMessage="Seleccione el Rubro"
                        ControlToValidate="ddlRubro" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                        ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:acInsumoxEfector ID="acInsumoxEfector" runat="server" />
                    <%--                            <div class="contentBoxW">
                                Insumo:
                                <asp:DropDownList ID="ddlInsumo" runat="server" DataValueField="idInsumo" DataTextField="Insumo"
                                    ToolTip="Ingrese el codigo o nombre del Insumo">
                                </asp:DropDownList>
                            </div>--%>
                    &nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnAgregarInsumo" Height="23" ToolTip="Click para Agregar otro Insumo"
                        OnClick="btnAgregarInsumo_Click" Text="Agregar Insumo" />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="False" CellPadding="2"
                        CssClass="mGrid" OnRowDataBound="gvInsumos_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="InsPedidoDetalle" HeaderText="InsPedidoDetalle" Visible="false">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Código">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Insumo">
                                <ItemTemplate>
                                    <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("InsInsumo.Nombre") %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCantidad" runat="server" ToolTip="Ingrese la Cantidad" Width="40px"
                                        Text='<%# Eval("Cantidad") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Presentación">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPresentacion" runat="server" OnTextChanged="txtPresentacion_TextChanged"
                                        AutoPostBack="true" ToolTip="Ingrese la Presentación" Width="40px" Text='<%# Eval("Presentacion") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadR" runat="server" ToolTip="Cantidad Total Provista" Width="40px"
                                        Text='<%# Eval("CantidadRecibida") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Renglón OC">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRenglon" runat="server" ToolTip="Ingrese el Nro renglón" Width="40px"
                                        Text='<%# Eval("RenglonOC") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:TemplateField HeaderText="Precio Total">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrecioTotal" runat="server" ToolTip="Ingrese el Precio Total."
                                        Width="60px" OnTextChanged="txtPrecioTotal_TextChanged" AutoPostBack="true">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Precio Unitario">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrecio" runat="server" ToolTip="Ingrese el Precio Unitario." Width="60px" Text='<%# Eval("PrecioUnitario") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nro. Lote">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLote" runat="server" ToolTip="Ingrese el Nro de Lote" Width="80px"
                                        Text='<%# Eval("numeroLote") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha Vto.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtFVto" runat="server" ToolTip="Ingrese la fecha del Vencimiento del Insumo"
                                        Width="80px" Text='<%# Eval("fechaVencimiento","{0:dd/MM/yyyy}") %>' onblur="javascript:formatearFecha(this)">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvfv" runat="server" ControlToValidate="txtFVto" Display="Dynamic" SetFocusOnError="true" ValidationGroup="P" ErrorMessage="Debe ingresar la fecha de vencimiento">*</asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Observación">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtObservacion" runat="server" Text='<%# Eval("Observacion") %>'
                                        Width="150px" ToolTip="Ingrese la Observación del Item" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Del">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="ibBorrar" ToolTip="Eliminar insumo de la Lista"
                                        CommandArgument='<%# Eval("IdInsumo") %>' OnCommand="ibBorrar_Command" ImageUrl="~/App_Themes/Default/images/del.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="lblmsn"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Responsable:
                    <asp:TextBox ID="txtResponsable" runat="server" ToolTip="Nombre del Responsable o Usuario que realiza el Pedido"
                        Width="600px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    Observaciones:
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="80%" ToolTip="Observaciones del Pedido realizado"
                        TextMode="MultiLine" Rows="3"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"
        ShowMessageBox="true" ShowSummary="false" ValidationGroup="P" />
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar >>" OnClick="btnGuardar_Click"
        ValidationGroup="P" />
    <input type="button" value="Cancelar" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
