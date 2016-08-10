<%@ Page Title="Listado de Provisiones" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListEgresos.aspx.cs" Inherits="ProvisionesH_ListEgresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>CONSULTAS EGRESOS</label>
    </section>
    <br />
    <div class="container">
        <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Datos Búsqueda</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">     
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
                            <div class="form-group">
                                <label class="control-label col-md-1">Depósito:</label>
                                <div class="col-md-3">                
                                    <asp:DropDownList ID="ddlDeposito" runat="server" class="form-control" DataValueField="idDeposito" DataTextField="nombre"
                                        ToolTip="Seleccione el Depósito.">
                                    </asp:DropDownList>
                                </div>

                                <label class="control-label col-md-1">Tipo:</label>
                                <div class="col-md-3">                
                                    <asp:DropDownList ID="dllTipoPedido" runat="server" class="form-control" DataValueField="idTipoPedido" DataTextField="nombre"
                                        ToolTip="Seleccione el tipo de Ingreso.">
                                    </asp:DropDownList>
                                </div>                                                                
                                <%--<label class="control-label col-md-1">Destino:</label>
                                <div class="col-md-3">                
                                    <asp:DropDownList ID="ddlProveedor" runat="server" class="form-control" DataValueField="idProveedor" DataTextField="nombre"
                                        ToolTip="Seleccione un Proveedor.">
                                    </asp:DropDownList>
                                </div>--%>
                                <div class="col-md-1">
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
                <asp:GridView ID="gvProvisiones" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" EmptyDataText="<b>No se encontraron datos.</b>" 
                    onrowdatabound="gvProvisiones_RowDataBound">
                    <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                <Columns>
                    <asp:BoundField DataField="depositoProveedor" ItemStyle-ForeColor="White" HeaderText="" ItemStyle-Width="1px" 
                         ItemStyle-VerticalAlign="Top" ItemStyle-Font-Size="XX-Small" ControlStyle-Width="1px"/> 

                    <asp:BoundField DataField="idPedido" HeaderText="ID" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="tipoPedido" HeaderText="Tipo" />
                    
                    <asp:TemplateField HeaderText="Destino">
                                <ItemTemplate>
                                    <asp:Image ID="imgEstado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                    <asp:BoundField DataField="proveedor" HeaderText="" ItemStyle-ForeColor="White"
                                ItemStyle-Font-Size="XX-Small" ControlStyle-Width="1px"/>
                    <asp:BoundField DataField="tipoComprobante" HeaderText="Comprobante" visible="false"/>
                    <asp:BoundField DataField="numeroComprobante" HeaderText="N°" visible="false"/>
                    
                    <%--<asp:BoundField DataField="Rubro" HeaderText="Rubro" />          --%>
                    <asp:BoundField DataField="observaciones" HeaderText="" ItemStyle-ForeColor="White"
                                ItemStyle-Font-Size="XX-Small" ControlStyle-Width="1px"/>

                    <asp:BoundField DataField="depositoProveedor" HeaderText="Deposito" />

                    <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                    <%--<asp:BoundField DataField="estadoPedido" HeaderText="E.Pedido" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />--%>
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <a href="ViewInterno.aspx?id=<%# Eval("IdPedido") %>" title="Ver Provisión"
                                target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                <span> <i class="glyphicon glyphicon-edit"> </i></span>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <a href="Edit.aspx?id=<%# Eval("IdPedido") %>" title="Editar Provisión">
                                <img id="imgView" alt="Editar Provisión" border="0" src="../App_Themes/Default/images/edit.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div>
        </div>
    </div>
    <br />
                    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
        <div class="floatRight">                
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
        </div>
    </div>
    <br>
    <script>
        $('#fechaDesde-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
        $('#fechaHasta-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
    </script>
</asp:Content>