<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="ProveedoresH_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
    <section class="titulo">
        <label>ALTA PROVEEDOR</label>
    </section>
    </br>

 <div class="container">
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-md-2">Código: </label>
            <div class="col-md-10">
                <asp:TextBox ID="txtCodigo" runat="server" cssClass="form-control"></asp:TextBox>
            </div>
            <label class="control-label col-md-2">Denominación: </label>
            <div class="col-md-10 text-left">
                <asp:TextBox ID="txtNombre" runat="server" cssClass="form-control"></asp:TextBox>
            </div>
            <label class="control-label col-md-2">Descripción: </label>
            <div class="col-md-10 text-left">
                <asp:TextBox ID="txtDescripcion" runat="server" cssClass="form-control"></asp:TextBox>
            </div>
            <label class="control-label col-md-2">CUIT: </label>
            <div class="col-md-10 text-left">
                <asp:TextBox ID="txtCuit" runat="server" cssClass="form-control"></asp:TextBox>
            </div>
            <label class="control-label col-md-2">Teléfono/Fax: </label>
            <div class="col-md-10 text-left">
                <asp:TextBox ID="txtTelefono" runat="server" cssClass="form-control"></asp:TextBox>            
            </div>
            <label class="control-label col-md-2">Domicilio: </label>
            <div class="col-md-10 text-left">
                <asp:TextBox ID="txtDomicilio" runat="server" cssClass="form-control"></asp:TextBox>
            </div>
            <label class="control-label col-md-2">Tipo Proveedor: </label>
            <div class="col-md-10 text-left">
                <asp:DropDownList ID="ddlTProveedor" runat="server" DataTextField="nombre" cssClass="form-control" 
                    DataValueField="idTipoProveedor" ToolTip="Seleccionar el Tipo"> </asp:DropDownList>            
            </div>    
            <label class="control-label col-md-2">Correo Electrónico: </label>
            <div class="col-md-10 text-left">
                <asp:TextBox ID="txtCorreo" runat="server" cssClass="form-control"></asp:TextBox>
            </div>
            <label class="control-label col-md-2">Observaciones: </label>
            <div class="col-md-5 text-left">
                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" cssClass="form-control"
                    Rows="3"></asp:TextBox>
            </div>
        </div>      
    <br />
    <asp:Label ID="lblMensaje" runat="server" CssClass="lblmsn"></asp:Label>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
    <div class="container">
        <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnGuardar" runat="server" 
                       OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" OnClientClick="modal();" ToolTip="Aceptar">
                     <span> <i class="glyphicon glyphicon-ok"> </i></span>  Guardar
                </asp:LinkButton>
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClientClick="history.go(-1)" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Volver
                </asp:LinkButton>
            </div>
        </div>                                
    </div>
    </br>

    <!-- Modal Mensaje Registro Grabado-->
    <div class="modal fade" id="processing-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header" style="background-color: #5bc0de;border-color: #46b8da;color: #fff;">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">CONFIRMACION</h4>
                      </div>
                      <div class="modal-body">
                        <label>El registro fue grabado !!!</label>
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-info" data-dismiss="modal">Cerrar</button>        
                      </div>
                    </div>
                  </div>
                </div> 

    <script>
                    function modal() {
                        $('#processing-modal').modal('show');
                    }
                </script>

</asp:Content>

