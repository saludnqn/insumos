<%@ Page Title="Consulta Medic. Asociados" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ConsultaAsociados.aspx.cs" Inherits="Insumos_ConsultaAsociados" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="Insumo1" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
   <section class="titulo">
        <label>MEDICAMENTOS ASOCIADOS</label>
    </section>
    <br/>
    
    <div class="container">
            <label class="control-label">Medicamento:</label>
            <div class="form-group">           
                <div class="col-md-12">
                    <uc1:Insumo1 ID="Insumo1" runat="server" />
                </div>
                        
                <div class="col-md-1">
                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md active"    
                        OnClick="btnBuscar_Click" ToolTip="Buscar Medicamentos Asociados">
                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                    </asp:LinkButton>
                </div>
                <div class="col-md-1">
                    <asp:linkbutton ID="btnNuevo" runat="server" Visible="true" 
                   OnClick="btnNuevo_Click" CssClass="btn btn-default btn-md active" ToolTip="Click para crear una nueva asociación de medicamentos">
                    <span> <i class="glyphicon glyphicon-plus"> </i></span>  Nuevo
                </asp:LinkButton>
                </div>
            </div>
        
        <br />
        <div id="idAsociados" runat="server" visible="false">
            <asp:GridView ID="gvMedicamentosAsociados" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                EmptyDataText="El insumo buscado no se tiene medicamentos asociados"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:Label ID="lblEquivalente" runat="server" Text='<%# Eval("InsInsumo.codigo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medicamento Equivalente">
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("InsInsumo.nombre") %>' Title='<%# Eval("InsInsumo.descripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="fechaAsociacion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyy}" />
                </Columns>
                <HeaderStyle BackColor="#4a4841" Font-Bold="true" ForeColor="white" />
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
