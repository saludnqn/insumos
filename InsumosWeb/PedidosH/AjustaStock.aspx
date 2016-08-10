<%@ Page Title="Ajustes de Stock" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="AjustaStock.aspx.cs" Inherits="PedidosH_AjustaStock" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="acInsumo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <section class="titulo">
        <label>EGRESO INSUMOS</label>
    </section>
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                </br>
              <div class="form-horizontal">
                  <div class="form-group" style="margin-bottom: 2px">
                      <label class="control-label col-md-2">Motivo:</label>
                      <div class="col-md-3 text-left">
                          <asp:DropDownList ID="ddlPedido" runat="server" CssClass="form-control" DataTextField="nombre" DataValueField="idTipoPedido" />
                      </div>
                      <label class="control-label col-md-1">Fecha:</label>
                      <div id="fecha-container" style="padding-top: 0px">
                          <div class="col-md-3">
                              <div class="input-group date">
                                  <asp:TextBox ID="dtpFechaAjuste" runat="server" CssClass="form-control"></asp:TextBox>
                                  <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                              </div>
                          </div>
                      </div>
                  </div>
                  <div class="form-group" style="margin-bottom: 2px">
                      <label for="deposito" class="control-label col-md-2">Depósito:</label>
                      <div class="col-md-3 text-left">
                          <asp:DropDownList ID="ddlDeposito" runat="server" CssClass="form-control" DataValueField="idDeposito" DataTextField="nombre">
                          </asp:DropDownList>
                      </div>
                      
                      <label for="ddlDestino" class="control-label col-md-1">Destino:</label>                    
                    <div class="col-md-3 text-left">    
                        <asp:DropDownList ID="ddlDestino" runat="server" cssClass="form-control" DataValueField="idProveedor" DataTextField="nombre"
                                ToolTip="Seleccionar el Destino" />
                    </div>
                  </div>

                  <div class="form-group" style="margin-bottom: 2px">
                      <label for="" class="control-label col-md-2">Comprobante:</label>
                      <div class="col-md-3">
                          <asp:DropDownList ID="ddlTipoComprobante" runat="server" CssClass="form-control" DataValueField="idTipoComprobante"
                                DataTextField="nombre" ToolTip="Seleccione el Tipo de Comprobante del suministro">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvc" runat="server" ErrorMessage="Seleccione el Comprobante" ControlToValidate="ddlTipoComprobante" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                                ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                        </div>
                        <%--<label class="control-label col-md-1">Nro.: </label>
                        <div class="col-md-2 text-left">
                            <asp:TextBox ID="txtNroComprobante" runat="server" CssClass="form-control" ToolTip="Solo números"></asp:TextBox>
                        </div>--%>
                   </div>
                  
                  
                  <div class="form-group" style="margin-bottom: 2px">
                      <label for="observaciones" class="control-label col-md-2">Observaciones:</label>
                      <div class="col-md-3">
                          <asp:TextBox ID="txtObservaciones" CssClass="form-control" runat="server" Style="width: 260px" ToolTip="Observaciones del Pedido realizado"
                              TextMode="MultiLine" Rows="3"></asp:TextBox>
                      </div>
                      <label for="responsable" class="control-label col-md-1">Respos.:</label>
                      <div class="col-md-3">
                          <asp:TextBox ID="txtResponsable" CssClass="form-control"
                              runat="server" ToolTip="Nombre del Responsable o Usuario que realiza el Pedido"></asp:TextBox>
                      </div>

                  </div>


                  <script>
                      $('#fecha-container .input-group.date').datepicker({
                          format: "dd/mm/yyyy"
                      });
                  </script>
              </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <br />
        <div class="form-horizontal">
            <div class="form-group">
                <div class="row">
                    <uc1:acInsumo ID="acInsumo" runat="server" />
                </div>
                <div class="row">
                    <asp:LinkButton ID="btnAgregarInsumo" runat="server" CssClass="btn btn-success btn-md"
                        OnClick="btnAgregarInsumo_Click">
                    <span> <i class="glyphicon glyphicon-plus"> </i></span>  Agregar
                    </asp:LinkButton>
                </div>

                <div class="row">
                    <asp:UpdatePanel ID="upInsumosEnDeposito" runat="server" Visible="false">
                        <ContentTemplate>
                            <div style="float: left; width: 78%">
                                <asp:GridView ID="gvInsumosDeposito" runat="server" AutoGenerateColumns="false" CellPadding="2"
                                    CssClass="table table-bordered table-condensed table-hover" GridLines="Both" Font-Size="10pt"
                                    EmptyDataText="Sin registros del insumo seleccionado.">
                                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Size="Small" Font-Bold="True" />
                                    <HeaderStyle BackColor="black" ForeColor="White" VerticalAlign="Middle" Font-Bold="True"
                                        HorizontalAlign="Center" />
                                    <EditRowStyle BackColor="black" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdPedido" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdPedido" runat="server" Text='<%# Eval("idPedido") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdPedidoDetalleo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdPedidoDetalle" runat="server" Text='<%# Eval("idPedidoDetalle") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("Codigo") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="idRubro" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdRubro" runat="server" Text='<%# Eval("idRubro") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Insumo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("insumo") %>' Title='<%# Eval("Unidad") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Presentación">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPresentacion" runat="server" Text='<%# Eval("presentacion") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Lote">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLote" runat="server" Text='<%# Eval("lote") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vencimiento">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVencimiento" runat="server" Text='<%# Eval("Vencimiento") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="$ Unitario" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Eval("precioUnitario") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Stock Actual">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStockActual" runat="server" Text='<%# Eval("Stock") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cant. Egresada">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>' ToolTip="Ingrese la cantidad a descontar" Width="60px" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCantidad" Display="Dynamic"
                                                    CssClass="text-danger" ErrorMessage="La cantidad es requerida." ValidationGroup="Edit" />
                                                <asp:RegularExpressionValidator ControlToValidate="txtCantidad" runat="server" CssClass="text-danger" Display="Dynamic"
                                                    ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                    ValidationGroup="Edit">
                                                </asp:RegularExpressionValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Stock Real" Visible="false">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtStockReal" runat="server" ToolTip="Ingrese el Stock Real" Width="60px" Text='<%# Eval("Stock") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cantidad Recibida" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCantidadRecibida" runat="server" Text='<%# Eval("CantidadRecibida") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cantidad Autorizada" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCantidadAutorizada" runat="server" Text='<%# Eval("CantidadAutorizada") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cantidad Emitida" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCantidadEmitida" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Observaciones" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObservacion" runat="server" Text='<%# Eval("observacion") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:HiddenField ID="hfIdRubro" runat="server" />
            </div>
        </div>


    </div>

    <br />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
        <div class="floatRight">
            <asp:LinkButton ID="btnGuardar" runat="server" Enabled="false"
                OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" OnClientClick="modal();"
                ToolTip="Aceptar">
                     <span> <i class="glyphicon glyphicon-ok"> </i></span>  Guardar
            </asp:LinkButton>
            <asp:LinkButton ID="btnCerrar" runat="server"
                OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
            </asp:LinkButton>

            <!-- Modal Mensaje Registro Grabado-->
            <div class="modal fade" id="processing-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color: #5bc0de; border-color: #46b8da; color: #fff;">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
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

            <script>
                function modal() {
                    $('#processing-modal').modal('show');
                }
            </script>
        </div>
    </div>
</asp:Content>

