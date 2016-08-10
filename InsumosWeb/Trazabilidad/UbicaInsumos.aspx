<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UbicaInsumos.aspx.cs" Inherits="Trazabilidad_UbicaInsumos" %>

<%@ Register Src="~/UserControls/Insumo_v2.ascx" TagName="Insumo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>UBICACION INSUMO</label>
    </section>
    <br/>

    <div class="container">
        <div class="row">
            <%--<label class="control-label col-md-1">Efector: </label>--%>         
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlEfector" runat="server" cssClass="form-control" visible="false"
                        DataValueField="idEfector" DataTextField="nombre" ToolTip="Seleccione el efector">
                </asp:DropDownList>
                </div>
        </div>
        <br />
        <div class ="row">
            <label class="control-label col-md-1" for="Insumo">Insumo:</label>
            <div class="col-md-8">
                <uc1:Insumo ID="Insumo" runat="server" />
            </div>
        </div>
        <br />
        
        <div class="form-horizontal">
            <div class="form-group">              
                <div class="col-md-1">
                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"    
                        OnClick="btnBuscar_Click" ToolTip="Buscar Insumo">
                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                    </asp:LinkButton>
                </div>
            </div>
          </div>
        
    <br />
    <div class="divs">
        <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered"
            EmptyDataText="El insumo buscado no se encuentra en el efector seleccionado">
                                        <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
            <Columns>
                <asp:BoundField DataField="Efector" HeaderText="Efector" />
                <asp:BoundField DataField="Deposito" HeaderText="Depósito" />
                <asp:BoundField DataField="Insumo" HeaderText="Insumo" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="numeroLote" HeaderText="Lote" />
                <asp:BoundField DataField="fechaVencimiento" HeaderText="Vencimiento" />                
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
    <br/>
</asp:Content>
