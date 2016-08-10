<%@ Page Title="Ingreso de Depósitos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="DepositosH_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <section class="titulo">                    
                <label>CONFIGURACION DEPOSITO</label>
            </section>
            </br>
            <div class="container">
                <div class="form-horizontal">
                    <div class="form-group">
                        <%--<label for="pedido" class="control-label col-md-2">Seleccione el Servicio:</label>--%>
                        <%--<div class="col-md-10 text-left">--%>
                            <asp:DropDownList ID="ddlServicio" visible="false" style="width:400px" runat="server" DataValueField="idServicio" DataTextField="nombre"
                                ToolTip="Seleccione el Servicio." CssClass="form-control">
                            </asp:DropDownList>
                        <%--</div>--%>
                        
                        <label for="nombreDeposito" class="control-label col-md-2">Nombre Depósito:</label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtDeposito" style="width:600px" runat="server" TextMode="MultiLine"
                                Rows="1" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                        <label for="descripcion" class="control-label col-md-2">Descripción:</label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtDescripcion" style="width:600px" runat="server" TextMode="MultiLine"
                                Rows="2" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                        <label for="tipoDeposito" class="control-label col-md-2">Tipo Depósito:</label>
                        <div class="col-md-10 text-left">
                            <asp:DropDownList ID="ddlTipoDep" visible="true" runat="server" style="width:400px" DataValueField="idTipoDeposito"
                                DataTextField="nombre" ToolTip="Seleccione el Tipo." CssClass="form-control">
                            </asp:DropDownList>                            
                        </div>
                        
                        <label for="deposito" class="control-label col-md-2">Depósito Superior:</label>
                        <div class="col-md-10 text-left">
                            <asp:DropDownList ID="ddlDeposito" runat="server" style="width:400px" DataValueField="idDeposito" DataTextField="nombre"
                                ToolTip="Seleccione el Deposito." CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        
                        <label for="observaciones" class="control-label col-md-2">Observaciones:</label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtObservaciones" style="width:600px" runat="server" TextMode="MultiLine"
                                Rows="3" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label for="bajaDeposito" class="control-label col-md-2">Baja Depósito:</label>
                        <div class="col-md-10">
                            <asp:CheckBox ID="cbBaja" cssClass="checkbox" runat="server" />
                        </div>

                        <label for="depoDispensacion" class="control-label col-md-2">Dispensación Ambulatoria:</label>
                        <div class="col-md-10">
                            <asp:CheckBox ID="cbDispensacion" cssClass="checkbox" runat="server" />
                        </div>

                    </div>
                    <div id="alerta" runat="server" class="col-lg-4">
                            <div class="alert alert-dismissable alert-success">
                                <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>El Depósito se actualizó correctamente.</strong>
                            </div>
                        </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
        <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnGuardar" runat="server" 
                   OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" ToolTip="Aceptar">
                    <span> <i class="glyphicon glyphicon-ok"> </i></span>  Guardar
                </asp:LinkButton>
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClientClick="cerrarVentana()" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>                                
        </div>
    </div>
    <br />

    <script>
        function cerrarVentana() {
            window.close();
        }
    </script>

    <link href="Content/sweet-alert.css" rel="stylesheet" />
</asp:Content>
