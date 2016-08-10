<%@ Page Title="Edición de Dosis por Medicamento" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="EditaDosis.aspx.cs" Inherits="Insumos_EditaDosis" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagPrefix="uc" TagName="usInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>DOSIS MEDICAMENTOS</label>
    </section>
    </br>

    <div class="container">
        <div class="form-horizontal">
            <label class="control-label">Medicamento:</label>
            <div class="form-group">           
                <div class="col-md-6">
                    <uc:usInsumo runat="server" ID="Medicamento" TabIndex="1" />
                </div>
                <asp:HiddenField ID="hfidInsumo" runat="server" />
                <div class="col-md-1">
                    <asp:LinkButton ID="lkDosis" runat="server" CssClass="btn btn-primary btn-md"    
                        OnClick="lkDosis_Click" ToolTip="Tiene Dosis?">
                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                    </asp:LinkButton>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="btnNuevo" runat="server" CssClass="btn btn-default btn-md"    
                        OnClick="btnNuevo_Click" ToolTip="Ingresa un nuevo registro">
                        <span> <i class="glyphicon glyphicon-plus"> </i></span>  Nuevo
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        </br>

         <div class="form-group">
            <label class="control-label col-md-2">Cantidad de Dosis por Envase:</label>
            <div class="col-md-1">
                <asp:TextBox ID="txtNroDosis" runat="server" CssClass="form-control" ToolTip="Ingrese la cantidad de dosis"></asp:TextBox>
            </div>
        </div>
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
        <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnGuardar" runat="server" Visible="true" 
                   OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" ToolTip="Grabar los datos">
                    <span> <i class="glyphicon glyphicon-floppy-disk"> </i></span>  Guardar
                </asp:LinkButton>
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>  
        </div>
    </div>
    </br>

</asp:Content>