<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ObraSocial.ascx.cs" Inherits="UserControls_ObraSocial" %>

<script type="text/javascript">
    $(function() {
        $('#<%= txtAutoOs.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/ObraSocial.ashx") %>', minlenght: 3,
            focus: function(event, ui) {
            $("#<%= txtAutoOs.ClientID %>").val(ui.item.nombre);
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -1) {
                    $("#<%= txtAutoOs.ClientID %>").val(ui.item.nombre);
                    $('#<%= lblNombre.ClientID %>').text(ui.item.nombre);
                    $('#<%= lblSigla.ClientID %>').text("(" + ui.item.sigla + ")");
                    $('#<%= lblCodigoNacion.ClientID %>').text(ui.item.codigoNacion);
                    $("#<%= idOS.ClientID %>").val(ui.item.id);
                }
                return false;
            }
        }).data("ui-autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("ui-autocomplete-item", item)
				.append("<a><strong>" + item.nombre + "</strong> (" + item.sigla + ") &nbsp; [" + item.codigoNacion + "]</a>")
				.appendTo(ul);
        };

        $('#hlLimpiar').button();
    });

    function LimpiarPrincipal() {
        $("#<%= txtAutoOs.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('Ingrese nombre, código o sigla de la Obra Social.');
        $('#<%= lblSigla.ClientID %>').text('');
        $('#<%= lblCodigoNacion.ClientID %>').text('');
        $("#<%= idOS.ClientID %>").val('');
    }
</script>

<table class="autoCompleter">
     <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutoOs" Columns="85" ToolTip="Ingresar la Obra Social"></asp:TextBox>
        </td>
        <td align="left">
            <a href="javascript:LimpiarPrincipal();" id="hlLimpiar" style="float: left;" title="Eliminar Item actual">
                <asp:Image ToolTip="Eliminar" runat="server" ID="imgLimpiar" ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/Default/images/textfield_delete.png" AlternateText="Borrar valor" /></a>
        </td>
        </tr>
      <tr>  
        <td colspan="2">
            <div id="acResult">
                <asp:HiddenField ID="idOS" runat="server" />
                <asp:Label runat="server" ID="lblNombre" Text="Ingrese nombre, código o sigla de la Obra Social."></asp:Label> &nbsp; <asp:Label runat="server" ID="lblSigla" Text=""></asp:Label> &nbsp;<asp:Label runat="server" ID="lblCodigoNacion" Text=""></asp:Label>
            </div>
        </td>
    </tr>
</table>