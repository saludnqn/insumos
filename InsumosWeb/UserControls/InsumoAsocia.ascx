<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InsumoAsocia.ascx.cs" Inherits="UserControls_InsumoAsocia" %>

<script type="text/javascript">
  $(function() {
    $('#<%= txtAutoI.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/Insumo.ashx") %>', minlenght: 3,
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
				.append("<a> (" + item.nombre + ") &nbsp;" + item.codigo + " &nbsp; [" + item.descripcion + "]</a>")
				.appendTo(ul);
    };

    $('#hlLimpiarA').button({ icons: { primary: "ui-icon-cancel" }, text: false });
  });

  function LimpiarPrincipalA() {
    $("#<%= txtAutoI.ClientID %>").val('');
    $('#<%= lblNombre.ClientID %>').text('Ingrese nombre, código o descripción del Insumo.');
    $('#<%= lblCodigo.ClientID %>').text('');
    $('#<%= lblDescripcion.ClientID %>').text('');
    $("#<%= idIns.ClientID %>").val('');
  }
</script>

<table class="autoCompletar">
  <tr>
    <td>
      <asp:TextBox runat="server" ID="txtAutoI" Columns="80" ToolTip="Ingrese nombre, código o descripción del Insumo." />
    </td>
    <td>
      <a href="javascript:LimpiarPrincipalA();" id="hlLimpiarA" style="height: 18px; width: 20px;" title="Eliminar Item actual" >
      <asp:Image ToolTip="Eliminar" runat="server" ID="imgLimpiarA" ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/Default/images/textfield_delete.png" AlternateText="Borrar valor" /></a>
    </td>
  </tr>
</table>
<div id="acResult">
  <asp:HiddenField ID="idIns" runat="server" />
  <b>Nombre:</b> <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre, código o descripción del Insumo."></asp:Label>
  <b>-</b> <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label>
  <br />
  <b>Descripción:</b> <asp:Label runat="server" ID="lblDescripcion" Text=""></asp:Label>
</div>