<%@ Page Title="Recepción Interna de Insumos" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InternosRecepcion.aspx.cs" Inherits="ProvisionesH_InternosRecepcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <section class="titulo">
                <label>PROVISION INTERNA</label>
            </section>
             </br>
            <div class="container">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Datos Búsqueda</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group" style="margin-bottom:2px">     
                                <label class="control-label col-md-2"> Desde:</label>
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
                                <label class="control-label col-md-2">Solicitante:</label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlDepositoSolicitante" runat="server" class="form-control" DataValueField="idDeposito" DataTextField="nombre"
                                        AutoPostBack="true" ToolTip="Depósito que originó el pedido.">
                                    </asp:DropDownList>
                                </div>
                                
                                <%--<label class="control-label col-md-1"> Proveedor:</label>--%>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlDepositoProveedor" runat="server" visible="false" class="form-control" DataValueField="idDeposito"
                                        DataTextField="nombre" ToolTip="Depósito a quien realizó el pedido">
                                    </asp:DropDownList>            
                                </div>                                
                            </div>
                            <div class="form-group">
                                <%--<label class="control-label col-md-2">Rubro:</label>--%>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlRubro" visible="false" runat="server" class="form-control" DataValueField="codigo" DataTextField="nombre">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">    
                                <div class="col-md-3">
                                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"    
                                        OnClick="btnBuscar_Click" ToolTip="Buscar Pedido Provisión">
                                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                                    </asp:LinkButton>
                                </div>
                            </div>

                            
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Registros encontrados</h3>
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPedido" CssClass="table table-hover table-bordered" EmptyDataText="<b>No se encontraron datos.</b>" 
                        OnRowDataBound="gvPedidos_RowDataBound" >
                            <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                        <Columns>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Image ID="imgEstado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="idEstadoPedido" HeaderText="" ControlStyle-Width="1px" ItemStyle-Font-Size="XX-Small" ItemStyle-ForeColor="White" ItemStyle-Width="1px" />
                            <asp:TemplateField HeaderText="Pedido Nº">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("idPedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="fechaPedido" HeaderText="Fecha Pedido" />
                            <asp:BoundField DataField="DProveedor" HeaderText="Depósito Proveedor" />
                            <asp:BoundField DataField="renglones" HeaderText="Items" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                            <asp:BoundField DataField="autorizado" HeaderText="Enviado" visible="false"/>
                            <asp:BoundField DataField="modifiedOn" HeaderText="Fecha/Hora Envío" />
                            
                            <asp:TemplateField HeaderText="Ver">
                                <ItemTemplate>
                                    <a href="Finalizado.aspx?id=<%# Eval("IdPedido") %>" title="Ver Recepción">
                                        <img id="imgVer" alt="Ver Insumos recibidos" border="0" src="../App_Themes/Default/images/search.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Recibir">
                                <ItemTemplate>
                                    <a href="RecepcionView.aspx?id=<%# Eval("IdPedido") %>" title="Recibir Insumos">
                                        <img id="imgAutoriz" alt="Recibir Insumos" border="0" src="../App_Themes/Default/images/recibir.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>
                </div>
            </div>               
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        $('#fechaDesde-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
        $('#fechaHasta-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">

    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
        <div class="floatRight">                
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
        </div>
    </div>
    <br/>     
</asp:Content>

