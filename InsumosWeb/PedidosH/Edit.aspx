<%@ Page Title="Pedidos Internos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="PedidosH_Edit" %>

<%@ Register Src="~/UserControls/Insumo_v2.ascx" TagName="acInsumo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <section class="titulo">
        <label>GESTION PEDIDO</label>
    </section>
    <br />

    <div class="container">

        <div class="form-horizontal">
            <div class="row">
                <div class="col-md-6" style="border-right: 2px solid">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-group" style="margin-bottom: 2px">
                                <asp:DropDownList ID="ddlPedido" runat="server" DataTextField="nombre" DataValueField="idTipoPedido" value="1" Visible="false"
                                    ToolTip="Seleccione el Tioo de Pedido a realizar">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group" style="margin-bottom: 2px" visible="false">
                                <%--<label class="control-label col-md-2">Fecha: </label>--%>
                                <%--<div id="fecha-container" style="padding-top: 0px">
                                    <div class="col-md-8">
                                        <div class="input-group date" style="width: 200px" visible="false">--%>
                                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                            <%--<span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>--%>
                                        <%--</div>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="form-group" style="margin-bottom: 2px">
                                <label class="control-label col-md-2">Solicitante:</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlDeposito" runat="server" class="form-control" DataValueField="idDeposito" DataTextField="nombre">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group" style="margin-bottom: 2px">
                                <%--<label class="control-label col-md-2">Proveedor: </label>--%>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlEfectorProveedor" Visible="false" runat="server" class="form-control" DataValueField="idEfector"
                                        DataTextField="nombre" ToolTip="Seleccione el Efector a quien realizará el Pedido"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEfectorProveedor_SelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="form-group" style="margin-bottom: 2px">
                                <label class="control-label col-md-2">Proveedor:</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlDepositoProveedor" runat="server" class="form-control" DataValueField="idDeposito"
                                        DataTextField="nombre" ToolTip="Seleccione el Depósito a quien realizará el Pedido" />
                                </div>
                            </div>
                            <div class="form-group">
                                <%--<label class="control-label col-md-2">Rubro Medic.:</label>--%>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlRubro" Visible="false" runat="server" class="form-control" DataValueField="codigo" DataTextField="nombre"
                                        ToolTip="Seleccionar el Rubro Base" AutoPostBack="true" OnSelectedIndexChanged="ddlRubro_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div id="panelBuscarInsumo">
                        <label>Buscar Medicamento:</label>
                        <uc1:acInsumo ID="acInsumoxRubro" runat="server" />
                        <br />
                        <asp:LinkButton ID="btnAgregarInsumo" runat="server" CssClass="btn btn-success btn-md"
                            OnClick="btnAgregarInsumo_Click" ToolTip="Asignar Medicamento">Asignar 
                                <span> <i aria-hidden="true" class="glyphicon glyphicon-ok"> </i></span></asp:LinkButton>
                        <asp:LinkButton ID="lbActualizar" runat="server" ToolTip="Ver Stock del Efector e Insumo seleccionado"
                            OnClick="lbActualizar_Click">
                            <img id="imStock" runat="server" src="~/App_Themes/Default/images/stock.png" alt="VerStock"
                                title="Stock Actual del Depósito" />
                        </asp:LinkButton>
                    </div>
                    <br />
                    <br />
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default" id="panelPaciente" style="margin-bottom: 1px">
                        <div class="panel-heading">Listado Medicamentos</div>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
                            <ContentTemplate>
                                <div id="tablaMedicamentos">
                                    <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                        Width="100%" GridLines="Both" CssClass="table table-hover table-bordered">
                                        <RowStyle BackColor="#F7F6F3" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="IdPedidoDetalle" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdPedidoDetalle" runat="server" Text='<%# Eval("IdPedidoDetalle") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Insumo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                                        Title='<%# Eval("InsInsumo.Descripcion") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unidad">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnidad" runat="server" Text='<%# Eval("InsInsumo.Unidad") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cantidad">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCantidad" runat="server" ToolTip="Ingrese la Cantidad Solicitada del Insumo"
                                                        Width="60px" Text='<%# Eval("CantidadSolicitada") %>'> </asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCantidad" Display="Dynamic"
                                                        CssClass="text-danger" ErrorMessage="La cantidad es requerida." ValidationGroup="Edit" />
                                                    <asp:RegularExpressionValidator ControlToValidate="txtCantidad" runat="server" CssClass="text-danger" Display="Dynamic"
                                                        ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                        ValidationGroup="Edit">
                                                    </asp:RegularExpressionValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Observación">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtObservacion" runat="server" Width="80%" Text='<%# Eval("Observacion") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="x">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="ibBorrar" ToolTip="Eliminar el Insumo de la Lista"
                                                        CommandArgument='<%# Eval("IdInsumo") %>' OnCommand="ibBorrar_Command" ImageUrl="~/App_Themes/Default/images/del.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Size="Small" Font-Bold="True" />
                                        <HeaderStyle BackColor="black" ForeColor="White" VerticalAlign="Middle" Font-Bold="True"
                                            HorizontalAlign="Center" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                </div>
                                <br />
                                <div>
                                    <label class="control-label">Responsable:</label>
                                    <asp:TextBox ID="txtResponsable" runat="server" class="form-control" ToolTip="Nombre del Responsable o Usuario que realiza el Pedido"></asp:TextBox>
                                    <label class="control-label">Observaciones:</label>
                                    <asp:TextBox ID="txtObservaciones" runat="server" class="form-control" ToolTip="Observaciones del Pedido realizado"
                                        TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="checkbox" style="margin-left: 20px; margin-top: 10px">
                        <label id="btnConfirmar" class="btn btn-primary">
                            <asp:CheckBox ID="CbPedidoConfirmado" runat="server" Checked="false" Text="CONFIRMAR PEDIDO" AutoPostBack="true" />
                        </label>
                    </div>

                </div>
            </div>
        </div>
        <div>
        </div>
    </div>
    <br />


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
        <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
            <div class="floatRight">
                <asp:LinkButton ID="btnGuardar" runat="server"
                    OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" OnClientClick="modal();"
                    ToolTip="Aceptar">
                     <span> <i aria-hidden="true" class="glyphicon glyphicon-ok"> </i> </span>  Guardar
                </asp:LinkButton>
                <asp:LinkButton ID="btnCerrar" runat="server"
                    OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i aria-hidden="true" class="glyphicon glyphicon-remove"> </i> </span>  Cerrar
                </asp:LinkButton>
            </div>
            <!-- Modal Mensaje Registro Grabado-->
            <div class="modal fade" id="processing-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color: #5bc0de; border-color: #46b8da; color: #fff;">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">CONFIRMACION</h4>
                        </div>
                        <div class="modal-body">
                            <label>El registro fue grabado !!!</label>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-info" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <script>
        function modal() {
            $('#processing-modal').modal('show');
        }

        $('#fecha-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });

    </script>

</asp:Content>
