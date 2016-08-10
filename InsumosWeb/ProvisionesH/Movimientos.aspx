<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Movimientos.aspx.cs" Inherits="ProvisionesH_Movimientos" Title="Consultas de Stock" %>

    <%@ Register Src="~/UserControls/Insumo_v2.ascx" TagName="acInsumo" TagPrefix="uc1" %> 
    
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/jquery-ui-1.11.3.js"></script>
    <script src="../App_Themes/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <link href="../css/datepicker.css" rel="stylesheet" />
    <script src="../js/bootstrap-datepicker.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>REPORTE DE MOVIMIENTOS</label>
    </section>
    <br/>
    <%--
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="lkImprimir" />
            </Triggers>
            <ContentTemplate>
                
            </ContentTemplate>
        </asp:UpdatePanel>
            
    --%>

    <div class="container">
        <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Datos Búsqueda</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="control-label col-md-1">Depósito:</label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlDeposito" runat="server" cssClass="form-control" DataValueField="idDeposito" DataTextField="nombre"
                                        ToolTip="Seleccione el Depósito. Por defecto todos del efector actual." AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-1">Mov.:</label>
                                <div class="col-md-3">                
                                    <asp:DropDownList ID="ddlTipoMovimiento" runat="server" class="form-control" DataValueField="idTipoMovimiento" DataTextField="nombre"
                                        ToolTip="Seleccione el tipo de Movimiento.">
                                    </asp:DropDownList>
                                </div>

                            </div>
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
                                <%--<label class="control-label col-md-1">Tipo:</label>
                                <div class="col-md-3">                
                                    <asp:DropDownList ID="dllTipoPedido" runat="server" class="form-control" DataValueField="idTipoPedido" DataTextField="nombre"
                                        ToolTip="Seleccione el tipo de Ingreso.">
                                    </asp:DropDownList>
                                </div>--%>                                                                
                                <%--<label class="control-label col-md-1">Destino:</label>
                                <div class="col-md-3">                
                                    <asp:DropDownList ID="ddlProveedor" runat="server" class="form-control" DataValueField="idProveedor" DataTextField="nombre"
                                        ToolTip="Seleccione un Proveedor.">
                                    </asp:DropDownList>
                                </div>--%>
                                
                            </div>
                            <%--<div class="form-group">
                                <label class="control-label col-md-1">Rubro:</label>
                                <div class="col-md-3">                
                                    <asp:DropDownList ID="ddlRubro" runat="server" class="form-control" DataValueField="codigo" DataTextField="nombre"
                                        ToolTip="Seleccione el Rubro.">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            
                            <div class="form-group">
                <label class="control-label col-md-1" for="Insumo">Insumo:</label>
                <div class="col-md-8">
                    <uc1:acInsumo ID="ucInsumo" runat="server" />
                </div>
            </div>
                            <div class="form-group">              
                <div class="col-md-1">
                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"    
                        OnClick="btnBuscar_Click" ToolTip="Buscar Insumo">
                        <span aria-hidden="true" class="glyphicon glyphicon-search"></span>  Buscar
                    </asp:LinkButton>
                </div>
                    <div class="col-md-2">
                            <asp:linkbutton ID="btnImprimir" runat="server" onClick="btnImprimir_Click"
                                CssClass="btn btn-primary btn-md" ToolTip="Imprimir Listado">
                                <span aria-hidden="true" class="glyphicon glyphicon-print" ></span>  Imprimir
                            </asp:LinkButton>
                       </div>
                
            </div>
                        </div>
                    </div>
        </div>
        
        <br />
        <div class="divs">
                            <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="true" CssClass="mGrid"
                                PagerStyle-CssClass="pager" EmptyDataText="No se encontraron resultados." ShowFooter="True"
                                PageSize="150" AllowPaging="True" OnPageIndexChanging="gvStock_PageIndexChanging">
                                <Columns>
                                    <%--<asp:BoundField DataField="codigo" HeaderText="Código" />                                    
                                    <asp:BoundField DataField="Insumo" HeaderText="Insumo" />                                    
                                    <asp:BoundField DataField="presentacion" HeaderText="Presentación" ItemStyle-ForeColor="Green" />                                    
                                    <asp:BoundField DataField="stock" HeaderText="Stock" ItemStyle-ForeColor="Blue" />--%>                                    
                                </Columns>
                                <FooterStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" />
                            </asp:GridView>
                        </div>
        <div style="text-align: center">
                            <asp:Label ID="lblTotal" runat="server" CssClass="lbl"></asp:Label>
                        </div>
        
    <br />

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

<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span aria-hidden="true" class="glyphicon glyphicon-remove" ></span>  Cerrar
                </asp:LinkButton>
            </div>
    </div>        
</asp:Content>
