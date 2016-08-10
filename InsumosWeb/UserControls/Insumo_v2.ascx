<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Insumo_v2.ascx.cs" Inherits="UserControls_Insumo_v2" %>

<script type="text/javascript">
  $(function() {
      var tipoBusqueda = $("#<%= rdbTipoBusqueda.ClientID %> input:checked").val();
      $('#<%= txtAutoI.ClientID %>').autocomplete({
          source: '<%= ResolveUrl("~/Services/Insumo.ashx?tipoBusqueda=' + tipoBusqueda + '")%>', minLenght: 5,      

      focus: function(event, ui) {
        $("#<%= txtAutoI.ClientID %>").val(ui.item.nombre);
        return false;
      },
      select: function(event, ui) {
        if (ui.item.id != -1) {
          $("#<%= txtAutoI.ClientID %>").val(ui.item.nombre);
          $('#<%= lblCodigo.ClientID %>').val("(" + ui.item.codigo + ")");
          $('#<%= lblNombre.ClientID %>').text(ui.item.nombre);
          $('#<%= lblDescripcion.ClientID %>').text(ui.item.descripcion);
          $("#<%= idIns.ClientID %>").val(ui.item.id);
        }
        return false;
      }
    }).data("ui-autocomplete")._renderItem = function(ul, item) {
      return $("<li></li>")
				.data("ui-autocomplete-item", item)
				.append("<a href='#' style='font-size:12px' class='list-group-item-text' > (" + item.nombre + ") &nbsp;" + item.codigo + " &nbsp; [" + item.descripcion + "]</a>")
				.appendTo(ul);
    };

    //$('#hlLimpiar').button({ icons: { primary: "ui-icon-cancel" }, text: false });
  });

  function LimpiarPrincipal() {
    $("#<%= txtAutoI.ClientID %>").val('');
    $('#<%= lblNombre.ClientID %>').text('');
    $('#<%= lblCodigo.ClientID %>').text('');
    $('#<%= lblDescripcion.ClientID %>').text('');
    $("#<%= idIns.ClientID %>").val('');
  }
</script>

<div>
    <div class="row">
        <div class="col-md-3">                          
            <asp:RadioButtonList ID="rdbTipoBusqueda" runat="server" 
                AutoPostBack="True" RepeatDirection="Horizontal" visible="true">
                        <asp:ListItem Text="Remediar" Value="1" GroupName="myGroup" Class="btn btn-info btn-xs" />
                        <asp:ListItem Text="Todos" Value="2" GroupName="myGroup" Class="btn btn-default btn-xs" Selected="True"/>
            </asp:RadioButtonList>
        </div>      
    </div>
    <div class="row">  
        <div class="col-md-6">  
            <div class="input-group">               
                <asp:TextBox runat="server" ID="txtAutoI" Width="300px" Columns="100" class="form-control" ToolTip="Ingrese nombre, código o descripción del Insumo." 
                    placeholder="Ingrese aquí el Medicamento"></asp:TextBox>   
                <span class="input-group-btn">
                    <button ID="hlLimpiar" class="btn btn-default" type="button"  OnClick="LimpiarPrincipal()">
                        <span> <i class="glyphicon glyphicon-remove"> </i></span>
                    </button>
                </span>                            
            </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <div id="acResult">
                    <asp:HiddenField ID="idIns" runat="server" />
                    <b>Nombre:</b> <asp:Label runat="server" ID="lblNombre" Text=""></asp:Label>
                    <b> </b> <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label>                    
                    <b>Descripción:</b> <asp:Label runat="server" ID="lblDescripcion" Text=""></asp:Label>
                </div>
            </div>        
    </div>    
</div>

