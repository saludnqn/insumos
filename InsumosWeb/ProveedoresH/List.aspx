<%@ Page Title="Consulta de Proveedores" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="ProveedoresH_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>PROVEEDORES</label>
    </section>
    </br>

    <div class="container">
        <div class="form-horizontal">
            <div class="form-group">
               <%-- <div class="row">
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
                </div>--%>
                <div class="row">
                    <%--<label class="control-label col-md-1">Código: </label>
                    <div class="col-md-3 text-left">--%>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                    <%--</div>
                     <label class="control-label col-md-1">Nombre:</label> 
                    <div class="col-md-3 text-left"> --%>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                    <%--</div>  
                    
                    <div class="col-md-1">
                        <asp:LinkButton ID="btnNuevo" runat="server" visible="false"
                            CssClass="btn btn-default btn-md"    
                        OnClick="btnNuevo_Click" ToolTip="Ingresa un nuevo registro">
                        <span> <i class="glyphicon glyphicon-plus"> </i></span>   Nuevo
                        </asp:LinkButton>
                   </div>--%>
                  
                </div>
            </div>                        
            </br>                                        
        </div>
    
        <script>
            $('#fechaDesde-container .input-group.date').datepicker({
                format: "dd/mm/yyyy"
            });
            $('#fechaHasta-container .input-group.date').datepicker({
                format: "dd/mm/yyyy"
            });

            </script>

        <br />
        
            <div>
                <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="false" 
                    CssClass="table table-hover table-condensed" EmptyDataText="<b>No se encontraron datos.</b>"  onrowdatabound="gvProveedores_RowDataBound">
                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                    <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Código" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="cuit" HeaderText="Cuit" />
                    <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                    <asp:BoundField DataField="Baja" HeaderText="Baja" />
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <a href="View.aspx?id=<%# Eval("Codigo") %>" title="Ver Proveedor">
                                <img id="imgView" alt="Ver Proveedor" border="0" src="../App_Themes/Default/images/search.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar" Visible="false">
                        <ItemTemplate>
                            <a href="Edit.aspx?id=<%# Eval("Codigo") %>" title="Modificar Proveedor">
                                <img id="imgEdit" alt="Editar Proveedor" border="0" src="../App_Themes/Default/images/edit.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">        
    <div class="container">
        <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>
        </div>                                
    </div>
    </br>

</asp:Content>
