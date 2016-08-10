<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InsumoxRubroxEfector.ascx.cs" Inherits="UserControls_InsumoxRubroxEfector" %>

<script type="text/javascript">
    $(function() {
       var idrub = $('#<%= hfIdRubro.ClientID %>').val();
       var idefec = $('#<%= hfIdEfector.ClientID %>').val();
        $('#<%= txtAutoI.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/InsumoxRubroxEfector.ashx") %>' + '?idru=' + idrub + '?idef=' + idefec,
            minlenght: 3,
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
        }).data("autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a> (" + item.nombre + ") &nbsp;" + item.codigo + " &nbsp; [" + item.descripcion + "]</a>")
				.appendTo(ul);
        };

        $('#hlLimpiar').button({ icons: { primary: "ui-icon-cancel" }, text: false });
    });

  function LimpiarPrincipal() {
    $("#<%= txtAutoI.ClientID %>").val('');
    $('#<%= lblNombre.ClientID %>').text('Ingrese nombre, código o descripción del Insumo.');
    $('#<%= lblCodigo.ClientID %>').val('');
    $('#<%= lblDescripcion.ClientID %>').text('');
    $("#<%= idIns.ClientID %>").val('');
  }
</script>

<table class="autoComplete">
  <tr>
    <td>
      <asp:TextBox runat="server" ID="txtAutoI" Columns="100" ToolTip="Ingrese nombre, código o descripción del Insumo" />
    </td>
    <td>
      <a href="javascript:LimpiarPrincipal();" id="hlLimpiar" style="height: 18px; width: 20px;" title="Eliminar Item actual" >
      <asp:Image ToolTip="Eliminar" runat="server" ID="imgLimpiar" ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/Default/images/textfield_delete.png" AlternateText="Borrar valor" /></a>
    </td>
  </tr>
</table>
<div id="acResult">
  <asp:HiddenField ID="idIns" runat="server" />
  <asp:HiddenField ID="hfIdRubro" runat="server" />
  <asp:HiddenField ID="hfIdEfector" runat="server" />
  <b>Nombre:</b> <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre, código o descripción del Insumo."></asp:Label>
  <b>-</b> <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label>
  <br />
  <b>Descripción:</b> <asp:Label runat="server" ID="lblDescripcion" Text=""></asp:Label>
</div>