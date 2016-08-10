<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Recuento.aspx.cs" Inherits="Insumos_Recuento" Title="Recuento Inicial de Stock" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="acInsumo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/jquery-ui-1.11.3.js"></script>
    <script src="../App_Themes/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/json2.js"></script>        
    <link href="../css/datepicker.css" rel="stylesheet" />
    <script src="../js/bootstrap-datepicker.js"></script>      
    
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>RECUENTO DE STOCK</label>
    </section>
    <br />
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Comprobante Recuento</h3>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                <div class="form-group">                
                    <label class="control-label col-md-1">Depósito:</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlDeposito" cssClass="form-control" runat="server" DataValueField="idDeposito" DataTextField="nombre"
                            ToolTip="Seleccione el Depósito" AutoPostBack="true" OnSelectedIndexChanged="ddlDeposito_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="cvd" runat="server" ErrorMessage="Seleccione el Depóosito"
                            ControlToValidate="ddlDeposito" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                            ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                    </div>
                                
                    <label class="control-label col-md-1">Fecha: </label>
                    <div id="fecha-container" style="padding-top:0px">
                    <div class="col-md-6">
                     <div class="input-group date" style="width:200px">
                        <asp:TextBox ID="txtFecha" runat="server" cssClass="form-control"></asp:TextBox>
                        <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                    </div>
                </div>
            </div>                         
        
        
                    <script>
                        $('#fecha-container .input-group.date').datepicker({
                            format: "dd/mm/yyyy"
                        });
        </script>
        
                </div>      
                <div class="form-group">
                    <label class="control-label col-md-1">Proveedor: </label>
                    <div class="col-md-4">    
                        <asp:DropDownList ID="ddlProveedor" runat="server" cssClass="form-control" DataValueField="idProveedor" DataTextField="nombre"
                            ToolTip="Seleccione el Proveedor.">
                        </asp:DropDownList>
                    </div>    
                    
                    <%--<label class="control-label col-md-1">Comprobante: </label>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlTipoComprobante" runat="server" cssClass="form-control" style="width:200px" DataValueField="idTipoComprobante"
                            DataTextField="nombre" ToolTip="Seleccione el Tipo de Comprobante del suministro">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="cvc" runat="server" ErrorMessage="Seleccione el Comprobante" ControlToValidate="ddlTipoComprobante" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                            ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                    </div>                
                    <label class="control-label col-md-1">Nro.: </label>
                    <div class="col-md-2 text-left">
                        <asp:TextBox ID="txtNroComprobante" runat="server" cssClass="form-control" Width="100px" ToolTip="Solo números"></asp:TextBox>
                    </div>--%>
                </div>    
                    <%--Orden de Compra:
                    <asp:TextBox ID="txtOCompra" runat="server" ToolTip="Ingrese el Nro de Orden de Compra"></asp:TextBox>                
                    Estado:
                    <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Value="true" Selected="True">Activo</asp:ListItem>
                        <asp:ListItem Value="false">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblActivo" runat="server" Text="" ForeColor="Red"></asp:Label>--%>                          
                </div>
            </div>
        
            <%--<div class="panel-heading">
                <h3 class="panel-title">Listado de Insumos</h3>
            </div>    
            <div class="panel-body">--%>
                <div class="form-horizontal">
                    <div class="form-group">                
                        <%--<label class="control-label col-md-1">Rubro:</label>
                        <div class="col-md-11">
                            <asp:DropDownList ID="ddlRubro" runat="server" cssClass="form-control" style="width:300px" DataValueField="codigo" DataTextField="nombre" ToolTip="Seleccionar el Rubro">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvr" runat="server" ErrorMessage="Seleccione el Rubro"
                                ControlToValidate="ddlRubro" Display="Dynamic" Operator="NotEqual" SetFocusOnError="true"
                                ValidationGroup="P" ValueToCompare="0">*</asp:CompareValidator>
                        </div>--%>
                        <label class="control-label col-md-1">Insumo:</label>
                        <div class="col-md-6">
                            <uc1:acInsumo ID="acInsumo" runat="server" />
                        </div>
                        <div class="col-md-2">
                                <asp:LinkButton ID="btnAgregarInsumo" runat="server" CssClass="btn btn-primary btn-md"    
                                OnClick="btnAgregarInsumo_Click" ToolTip="Click para Agregar otro Insumo">
                                <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>  Agregar
                                </asp:LinkButton>                                                         
                        </div>
                    </div>
                </div>                                       
                <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="False" CellPadding="2"
                        CssClass="mGrid">
                        <Columns>
                            <asp:BoundField DataField="IdPrescripcionDetalle" HeaderText="IdPrescripcionDetalle"
                                Visible="false"></asp:BoundField>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:TemplateField HeaderText="Renglón OC" Visible="false">
                                <%--<ItemTemplate>
                                    <asp:TextBox ID="txtRenglon" runat="server" ToolTip="Ingrese el Nro renglón" Width="40px"
                                        Text='<%# Eval("RenglonOC") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>--%>
                            </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Precio Total">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrecioTotal" runat="server" ToolTip="Ingrese el Precio Total."
                                        Width="60px" OnTextChanged="txtPrecioTotal_TextChanged" AutoPostBack="true">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Precio Unitario" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrecio" runat="server" ToolTip="Ingrese el Precio Unitario" Width="60px"
                                        Text='<%# Eval("PrecioUnitario") %>'>
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
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Observación">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtObservacion" runat="server" Text='<%# Eval("Observacion") %>'
                                        Width="200px" ToolTip="Ingrese la Observación del Item" />
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
            
            <%--</div>--%>
        </div>
        <div class="panel panel-default">
            <div class="form-horizontal">
                <div class="form-group">                                                           
                    <div class="panel-body">
                            <label class="control-label col-md-2">Observaciones:</label>
                            <div class="col-md-5">                        
                                <asp:TextBox ID="txtObservaciones" runat="server" class="form-control" Width="80%" ToolTip="Observaciones del Pedido realizado"
                                    TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>                                        
                            <label class="control-label col-md-2">Responsable:</label>
                            <div class="col-md-3">                        
                                <asp:TextBox ID="txtResponsable" runat="server" class="form-control" ToolTip="Nombre del Responsable o Usuario que realiza el Pedido"></asp:TextBox>
                            </div>
                    </div>
                </div>                    
            </div>
        </div>
    </div>
                                                                                                                  
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"
        ShowMessageBox="true" ShowSummary="false" ValidationGroup="P" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
<div class="container">
    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
        <div class="floatRight">
                <asp:linkbutton ID="btnGuardar" runat="server" Enabled="false" 
                       OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" OnClientClick="modal();"
                    ToolTip="Aceptar">
                     <span aria-hidden="true" class="glyphicon glyphicon-ok" ></span>  Guardar
                </asp:LinkButton>
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span aria-hidden="true" class="glyphicon glyphicon-remove" ></span>  Cerrar
                </asp:LinkButton>
                                            
                <!-- Modal Mensaje Registro Grabado-->
                <div class="modal fade" id="processing-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header" style="background-color: #5bc0de;border-color: #46b8da;color: #fff;">
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

                <script>
                    function modal() {
                        $('#processing-modal').modal('show');
                    }
                </script>
            </div>
        </div>
</div>
</br>
</asp:Content>
