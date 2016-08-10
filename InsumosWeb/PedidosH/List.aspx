<%@ Page Title="Pedidos del Efector" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Pedidos_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
       <label>GESTION PEDIDOS / CONSULTAR - CONFIRMAR</label>
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
                            <label class="control-label col-md-2"> Desde:</label>
                        <div id="fechaDesde-container">
                            <div class="col-md-2">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFInicio" runat="server" cssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                        </div>
                        <label class="control-label col-md-3"> Hasta: </label>
                        <div id="fechaHasta-container" style="padding-top:0px">
                            <div class="col-md-2 text-left">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFFin" runat="server" cssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                        </div>
                        </div>
                        <div class="form-group" style="margin-bottom:2px">
                            <label class="control-label col-md-2">Solicitante:</label>
                            <div class="col-md-3">
                                    <asp:DropDownList ID="ddlDepositoSolicitante" runat="server" class="form-control" DataValueField="idDeposito" DataTextField="nombre"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlDepositoSolicitante_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </div>
                            <label class="control-label col-md-2">Proveedor:</label>
                            <div class="col-md-3">
                                    <asp:DropDownList ID="ddlDepositoProveedor" runat="server" class="form-control" DataValueField="idDeposito" DataTextField="nombre"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlDepositoSolicitante_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </div>

                        </div>
                        <%--<div class="form-group" style="margin-bottom:2px">
                            <label class="control-label col-md-2">Rubro:</label>
                            <div class="col-md-3">--%>                                
                                    <asp:DropDownList ID="ddlRubro" runat="server" class="form-control" visible="false" DataValueField="codigo" DataTextField="nombre">
                                    </asp:DropDownList>
                               <%-- </div>
                        </div>--%>
                        <div class="form-group" style="margin-bottom:2px">
                            <label class="control-label col-md-2">Estado Pedido:</label>
                            <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" DataValueField="idEstadoPedido" DataTextField="nombre">
                                    </asp:DropDownList>
                                </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">Autorización:</label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlAutorizado" runat="server" class="form-control" ToolTip="Seleccionar Pedidos">
                                    <asp:ListItem Value="-1">TODOS</asp:ListItem>
                                    <asp:ListItem Value="1">Confirmados</asp:ListItem>
                                    <asp:ListItem Value="0">No Confirmados</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"    
                                        OnClick="btnBuscar_Click" ToolTip="Buscar Pedido">
                                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                                    </asp:LinkButton>
                            </div>
                            <div class="col-md-4">
                                <asp:LinkButton ID="btnNuevo" runat="server" CssClass="btn btn-primary btn-md" Visible="false"    
                                        ToolTip="Nuevo Pedido">
                                        <span> <i class="glyphicon glyphicon-plus"> </i></span>  Nuevo
                                    </asp:LinkButton>
                            </div>
                                <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        
                        <div class="form-group" style="margin-bottom:2px">
                                                    
                                                
                    </div>
                </div>
            
                                      
                <br />
                
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" DataKeyNames="IdPedido"
                        OnRowDataBound="gvPedidos_RowDataBound" CssClass="table table-hover table-bordered">
                        <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Image ID="imgEstado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="idEstadoPedido" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="White"
                                ItemStyle-Font-Size="XX-Small" />
                            <asp:TemplateField HeaderText="Pedido Nº">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("idPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="fechaPedido" HeaderText="Fecha Pedido" />
                            <asp:BoundField DataField="NombreDepositoSolicitante" HeaderText="Solicitante" Visible="false" />
                            <asp:BoundField DataField="NombreDepositoProveedor" HeaderText="Proveedor"/>
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="ModifiedOn" HeaderText="Actualización" />
                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                            <asp:BoundField DataField="autorizado" HeaderText="Confirmado"/>

                            <asp:TemplateField HeaderText="Enviado" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("estado") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ver">
                                <ItemTemplate>
                                    <%--<a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido Completo">
                                        <img id="imgView" alt="Ver Pedido Completo" border="0" src="../App_Themes/Default/images/search.png" />
                                    </a>--%>

                                     <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido"
                                    target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                    <span><i class="glyphicon glyphicon-search"></i></span>
                                </a>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <%--<a href="Edit.aspx?id=<%# Eval("IdPedido") %>" title="Modificar datos del Pedido">
                                        <img id="imgEdit" alt="Editar Pedido" border="0" src="../App_Themes/Default/images/edit.png" />
                                    </a>--%>

                                     <a href="EditPedido.aspx?id=<%# Eval("IdPedido") %>" title="Modificar datos Pedido"
                                    target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                    <span><i class="glyphicon glyphicon-edit"></i></span>
                                </a>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Autorizar" Visible="false">
                                <ItemTemplate>
                                    <a href="Autoriza.aspx?id=<%# Eval("IdPedido") %>" title="Autorizar el Pedido">
                                        <img id="imgAutoriz" alt="Autorizar Pedido" border="0" src="../App_Themes/Default/images/autorizar.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Entregar" Visible="false">
                                <ItemTemplate>
                                    <a href="Enviar.aspx?id=<%# Eval("IdPedido") %>" title="Entregar el Pedido">
                                        <img id="imgEnviar" alt="Entregar el Pedido Seleccionado" border="0" src="../App_Themes/Default/images/envio.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfIdPedido" runat="server" />
                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
        <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
        <div class="floatRight">                
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClientClick="history.go(-1)" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
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
