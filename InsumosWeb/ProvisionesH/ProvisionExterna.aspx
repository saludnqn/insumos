<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProvisionExterna.aspx.cs" Inherits="ProvisionesH_ProvisionExterna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
        <section class="titulo">
                <label>PROVISION DEPOSITO ZONA</label>
        </section>
             </br>
        <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Datos Búsqueda Provisión</h3>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">     
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
                        <div class="col-md-1">
                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"    
                            OnClick="btnBuscar_Click" ToolTip="Buscar Provisión">
                            <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                        </asp:LinkButton>
                    </div>
                    </div>
                    <%--<div class="form-group">
                        <label class="control-label col-md-2"> Remito N°:</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtComprobante" runat="server" cssClass="form-control"></asp:TextBox>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Resultado de la búsqueda </h3>
            </div>
            <div class="panel-body">
                <b><asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></b>
                    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" DataKeyNames="Pedido" CssClass="table table-hover table-bordered" EmptyDataText="<b>No se encontraron datos.</b>" 
                        ToolTip="Recepción de Medicamentos enviados desde Abastecimiento">
                            <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                        <Columns>
                            <asp:TemplateField HeaderText="Pedido Nº">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPedido" runat="server" Text='<%# Bind("Pedido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombreRubro" HeaderText="Rubro" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="fechaAutorizacion" HeaderText="Fecha de Autorización" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="fecha_Despacho" HeaderText="Fecha Despacho" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="responsable" HeaderText="Responsable" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:TemplateField HeaderText="Recibir">
                                <ItemTemplate>
                                    <a href="RecibirProvisionExterna.aspx?id=<%# Eval("Pedido") %>" title="Recibir Medicamentos">
                                        <img id="imgAutoriz" alt="Recibir Insumos" border="0" src="../App_Themes/Default/images/recibir.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

            </div>
        </div>
    </div>                           
            <br />                        
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
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">

    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
        <div class="floatRight">                
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
        </div>
    </div>
     
</asp:Content>
