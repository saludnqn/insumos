<%@ Page Title="Asocia Medicamentos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="AsociaMedicamentos.aspx.cs" Inherits="Insumos_AsociaMedicamentos" %>

<%@ Register Src="~/UserControls/Insumo.ascx" TagName="Insumo1" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/InsumoAsocia.ascx" TagName="InsumoAsocia" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>ASOCIA MEDICAMENTOS</label>
    </section>
    </br>

    <div class="container">
    
        <div style="background-color: #f1eee7; width: 100%"; border:"1px doted" id="autocompleter1">
            <b>Medicamento Origen</b>
            <uc1:Insumo1 ID="Insumo1" runat="server" />
        </div>
        <br />
        <div style="background-color: #f1eee7; width: 100%" id="autocompleter2">
            <b>Medicamento Asociado</b>
            <uc2:InsumoAsocia ID="InsumoAsocia" runat="server" />            
        </div>
        <br />
        <div id="idAsociados" runat="server" visible="false" style="float: right; margin-top: -260px; border: dotted 1px black; width: 35%;
            background-color: #f1eee7; display: block;">
            <b>Medicamento Asociado a:<br />
               <asp:Label ID="lblEtiqueta" runat="server" Text=""></asp:Label>
            </b>
            <div style="text-align:justify">
                <asp:GridView ID="gvMedicamentosAsociados" runat="server" AutoGenerateColumns="false"
                    Width="100%" Font-Size="Smaller">
                    <Columns>
                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <asp:Label ID="lblEquivalente" runat="server" Text='<%# Eval("InsInsumo.codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Medicamento Equivalente">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("InsInsumo.nombre") %>'
                                    Title='<%# Eval("InsInsumo.descripcion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="fechaAsociacion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyy}" />
                    </Columns>
                    <HeaderStyle BackColor="#4a4841" Font-Bold="true" ForeColor="white" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">  
     <div class="container">
         <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
            <div class="floatRight">
                <asp:linkbutton ID="btnGuardar" runat="server" Enabled="false" 
                       OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md" OnClientClick="modal();"
                    ToolTip="Aceptar">
                     <span> <i class="glyphicon glyphicon-ok"> </i></span>  Guardar
                </asp:LinkButton>
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
             </div>
         </div>                              
     </div>
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
