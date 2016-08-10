<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ListAsignaStock.aspx.cs" Inherits="PedidosH_ListAsignaStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/jquery-ui-1.11.3.js"></script>
    <script src="../App_Themes/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <link href="../css/datepicker.css" rel="stylesheet" />
    <script src="../js/bootstrap-datepicker.js"></script>      


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>PEDIDOS AUTORIZADOS SIN ASIGNACION DE STOCK</label>
    </section>
    <br />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">                                
                <div class="form-horizontal">
                    <div class="row">
                        <div class="form-group" style="margin-bottom:2px">
                            <label class="control-label col-md-1"> Desde:</label>
                            <div id="fechaDesde-container">
                                <div class="col-md-3">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFInicio" runat="server" cssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                            </div>
                            <label class="control-label col-md-1"> Hasta: </label>
                            <div id="fechaHasta-container" style="padding-top:0px">
                                <div class="col-md-3 text-left">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFFin" runat="server" cssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                            </div>
                        </div>
                        <div class="form-group" style="margin-bottom:2px">                                   
                            <label class="control-label col-md-1">Origen:</label>    
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlDepositoOrigen" runat="server" class="form-control" DataValueField="idDeposito"
                                DataTextField="nombre" AutoPostBack="false" ToolTip="Depósito que originó el pedido">
                            </asp:DropDownList>
                            </div>
                            <label class="control-label col-md-1">Destino:</label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlDepositoProveedor" runat="server" class="form-control" DataValueField="idDeposito"
                                DataTextField="nombre" ToolTip="Depósito a quien realizó el pedido">
                            </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" style="margin-bottom:2px">                                       
                            <label class="control-label col-md-1">Rubro:</label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlRubro" runat="server" class="form-control" DataValueField="codigo" DataTextField="nombre">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <%--<label class="control-label col-md-1">Estado:</label>--%>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlAutorizado" visible="false" runat="server" class="form-control" ToolTip="Seleccionar Pedidos">
                                    <asp:ListItem Value="1">Autorizados</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"    
                                        OnClick="btnBuscar_Click" ToolTip="Buscar Pedido">
                                        <span aria-hidden="true" class="glyphicon glyphicon-search"></span>  Buscar
                                    </asp:LinkButton>            
                            <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
                            </div>
                        </div>  
                    </div>  
                </div>
                                     
                <br />
                <div class="row">
                    <div class="contentBox">
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido" EmptyDataText="No se encontraron registros de Pedidos Internos"
                        OnRowDataBound="gvPedidos_RowDataBound" CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Image ID="imgEstado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="idEstadoPedido" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="White" ItemStyle-Font-Size="XX-Small" />
                            <asp:TemplateField HeaderText="Pedido Nº">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("idPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="fechaPedido" HeaderText="Fecha Pedido" />
                            <asp:BoundField DataField="DOrigen" HeaderText="Deposito Origen" />
                            <asp:BoundField DataField="DProveedor" HeaderText="Deposito Proveedor" />
                            <asp:BoundField DataField="renglones" HeaderText="Renglon" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="ModifiedOn" HeaderText="Actualización" />
                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                            <asp:BoundField DataField="autorizado" HeaderText="Enviado" /><%--10--%>
                            <asp:TemplateField HeaderText="Ver">
                                <ItemTemplate>
                                    <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido Completo">
                                        <img id="imgView" alt="Ver Pedido Completo" border="0" src="../App_Themes/Default/images/search.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar" Visible="false">
                                <ItemTemplate>
                                    <a href="Edit.aspx?id=<%# Eval("IdPedido") %>" title="Modificar datos del Pedido">
                                        <img id="imgEdit" alt="Editar Pedido" border="0" src="../App_Themes/Default/images/edit.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Autorizar" Visible="false">
                                <ItemTemplate>
                                    <a href="Autoriza.aspx?id=<%# Eval("IdPedido") %>" title="Autorizar Pedido">
                                        <img id="imgAutoriz" alt="Autorizar Pedido" border="0" src="../App_Themes/Default/images/autorizar.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asignar" Visible="true">
                                <ItemTemplate>
                                    <a href="AsignaStock.aspx?id=<%# Eval("IdPedido") %>" title="Asignar Stock">
                                        <img id="imgAsigmar" alt="Asignar Stock" border="0" src="../App_Themes/Default/images/asigna.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadEnviada" runat="server" Text='<%# Bind("cantidadEnviada") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("estado") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Entregar" Visible="false">
                                <ItemTemplate>
                                    <a href="InternosEnvio.aspx?id=<%# Eval("IdPedido") %>" title="Entregar Pedido">
                                        <img id="imgEnviar" alt="Entregar Pedido" border="0" src="../App_Themes/Default/images/envio.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfIdPedido" runat="server" />
                </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
            <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
        <div class="floatRight">                
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClientClick="history.go(-1)" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span aria-hidden="true" class="glyphicon glyphicon-remove" ></span>  Cerrar
                </asp:LinkButton>
        </div>
    </div>
    <script>
        $('#fechaDesde-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
        $('#fechaHasta-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
    </script>
</asp:Content>
