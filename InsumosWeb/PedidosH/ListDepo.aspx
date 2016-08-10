<%@ Page Title="Pedidos del Efector" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ListDepo.aspx.cs" Inherits="Pedidos_ListDepo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>GESTION PEDIDOS - Preparar, Enviar/Entregar</label>
    </section>
    <br />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container">
                <div class="form-horizontal">
                    <div class="row">
                        <div class="form-group" style="margin-bottom: 2px">
                            <label class="control-label col-md-2">Desde:</label>
                            <div id="fechaDesde-container">
                                <div class="col-md-2">
                                    <div class="input-group date">
                                        <asp:TextBox ID="txtFInicio" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                    </div>
                                </div>
                            </div>
                            <label class="control-label col-md-3">Hasta: </label>
                            <div id="fechaHasta-container" style="padding-top: 0px">
                                <div class="col-md-2 text-left">
                                    <div class="input-group date">
                                        <asp:TextBox ID="txtFFin" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group" style="margin-bottom: 2px">
                            <label class="control-label col-md-2">Depósito:</label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlDepositoProveedor" runat="server" class="form-control"
                                    DataValueField="idDeposito" DataTextField="nombre" OnSelectedIndexChanged="ddlDepositoDestino_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <label class="control-label col-md-2">Destino:</label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlDepositoDestino" runat="server" class="form-control" DataValueField="idDeposito" DataTextField="nombre"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDepositoDestino_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <%--<div class="form-group" style="margin-bottom:2px">
                            <label class="control-label col-md-2">Proveedor:</label>
                            <div class="col-md-3">
                                    <asp:DropDownList ID="ddlDeposito" runat="server" class="form-control" DataValueField="idDeposito" DataTextField="nombre"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            
                        </div>--%>
                        <%--<div class="form-group" style="margin-bottom:2px">
                            <label class="control-label col-md-2">Rubro:</label>
                            <div class="col-md-3">--%>
                        <asp:DropDownList ID="ddlRubro" runat="server" Visible="false" class="form-control" DataValueField="codigo" DataTextField="nombre">
                        </asp:DropDownList>
                        <%--</div>
                        </div>--%>
                        <div class="form-group" style="margin-bottom: 2px">
                            <label class="control-label col-md-2">Estado Pedido:</label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" DataValueField="idEstadoPedido" DataTextField="nombre">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"
                                    OnClick="btnBuscar_Click" ToolTip="Buscar Pedido">
                                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-4">
                                <%--<asp:LinkButton ID="btnNuevo" runat="server" CssClass="btn btn-primary btn-md"    
                                        OnClick="btnNuevo_Click" ToolTip="Nuevo Pedido">
                                        <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>  Nuevo
                                    </asp:LinkButton>--%>
                            </div>
                            <asp:Label ID="lblCantidad" runat="server" Text=""></asp:Label>
                        </div>
                        <%--<div class="form-group">
                            <label class="control-label col-md-2">Autorización:</label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlAutorizado" runat="server" class="form-control" ToolTip="Seleccionar Pedidos">
                                    <asp:ListItem Value="-1">TODOS</asp:ListItem>
                                    <asp:ListItem Value="1">Confirmados</asp:ListItem>
                                    <asp:ListItem Value="0">No Confirmados</asp:ListItem>
                                </asp:DropDownList>
                            </div>                                                        
                        </div> --%>
                    </div>
                </div>

                <br />
                <%--<div class="divs">
                <div class="contentBox">--%>
                <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido"
                    OnRowDataBound="gvPedidos_RowDataBound" CssClass="table table-hover table-condensed">
                    <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="black" />
                    <Columns>
                        <asp:TemplateField HeaderText="Estado"><%--col 0--%>
                            <ItemTemplate>
                                <asp:Image ID="imgEstado" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="idEstadoPedido" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="White"
                            ItemStyle-Font-Size="XX-Small" />
                        <%--col 1--%>
                        <asp:TemplateField HeaderText="Pedido Nº"><%--col 2--%>
                            <ItemTemplate>
                                <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("idPedido") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="fechaPedido" HeaderText="Fecha Pedido" />
                        <%--col 3--%>
                        <asp:BoundField DataField="NombreDepositoProveedor" HeaderText="Proveedor" Visible="false" />
                        <%--col 4--%>
                        <asp:BoundField DataField="NombreDepositoSolicitante" HeaderText="Destino" />
                        <%--col 5--%>
                        <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                        <%--col 6--%>
                        <asp:BoundField DataField="ModifiedOn" HeaderText="Actualización" />
                        <%--col 7--%>
                        <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                        <%--col 8--%>
                        <asp:BoundField DataField="estado" HeaderText="Situación" Visible="false" />
                        <%--col 9--%>

                        <%--<asp:TemplateField HeaderText="Estado" Visible="true"> 
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("idEstadoPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Ver"><%--col 10--%>
                            <ItemTemplate>

                                <a href="View.aspx?id=<%# Eval("IdPedido") %>" title="Ver Pedido"
                                    target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                    <span><i class="glyphicon glyphicon-search"></i></span>
                                </a>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar" Visible="false"><%--col 11--%>
                            <ItemTemplate>

                                <a href="Edit.aspx?id=<%# Eval("IdPedido") %>" title="Modificar datos del Pedido"
                                    target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                    <span><i class="glyphicon glyphicon-edit"></i></span>
                                </a>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preparar" Visible="true"><%--col 12--%>
                            <ItemTemplate>

                                <a href="AsignaStock.aspx?id=<%# Eval("IdPedido") %>" title="Autorizar el Pedido"
                                    target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                    <span><i class="glyphicon glyphicon-ok"></i></span>
                                </a>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Para Retirar" Visible="true"> 
                                <ItemTemplate>
                                    <a href="#InternosParaRetirar.aspx?id=<%# Eval("IdPedido") %>" title="Cambiar estado del Pedido">
                                        <img id="imgEnviar" alt="Cambiar el estado del Pedido Seleccionado" border="0" 
                                            src="../App_Themes/Default/images/envio.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Entregar/Enviar" Visible="true"><%--col 13--%>
                            <ItemTemplate>
                                <%--<a href="InternosEnvio.aspx?id=<%# Eval("IdPedido") %>" title="Cambiar estado del Pedido">
                                    <img id="imgEnviar" alt="Cambiar el estado del Pedido Seleccionado" border="0"
                                        src="../App_Themes/Default/images/envio.png" />
                                </a>--%>
                                 <a href="InternosEnvio.aspx?id=<%# Eval("IdPedido") %>" title="Camibar estado del Pedido"
                                    target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                    <span><i class="glyphicon glyphicon-share-alt"></i></span>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfIdPedido" runat="server" />
                <%--</div>
            </div>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
        <div class="floatRight">
            <asp:LinkButton ID="btnCerrar" runat="server"
                OnClientClick="javascript:window.close()" CssClass="btn btn-info btn-md" ToolTip="Salir">
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
