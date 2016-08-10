<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Rubro.ascx.cs" Inherits="UserControls_Rubro" %>

<script type="text/javascript">
    $(function() {
        $('#<%= txtAutoR.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/Rubro.ashx") %>', minlenght: 3,
            focus: function(event, ui) {
            $("#<%= txtAutoR.ClientID %>").val(ui.item.nombre);
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -1) {
                    $("#<%= txtAutoR.ClientID %>").val(ui.item.nombre);
                    $('#<%= lblNombre.ClientID %>').text(ui.item.nombre);
                    $("#<%= idR.ClientID %>").val(ui.item.id);
                }
                return false;
            }
        }).data("autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("item.autocomplete", item)
				.append("<a><strong>" + item.nombre + "</strong></a>")
				.appendTo(ul);
        };

        $('#hlLimpiarR').button({ icons: { primary: "ui-icon-cancel" }, text: false });
    });

    function LimpiarPrincipalR() {
        $("#<%= txtAutoR.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('Ingrese rubro o subrubro.');
        $("#<%= idR.ClientID %>").val('');
    }
</script>

<table class="autoCompleter">
     <tr>
        <td>
            <asp:TextBox runat="server" ID="txtAutoR" Columns="50" ToolTip="Ingresar el Rubro/Subrubro"></asp:TextBox>
        </td>
        <td align="left">
            <a href="javascript:LimpiarPrincipalR();" id="hlLimpiarR" style="float: left;" title="Eliminar Item actual">
                <asp:Image ToolTip="Eliminar" runat="server" ID="imgLimpiarR" ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/Default/images/textfield_delete.png" AlternateText="Borrar valor" /></a>
        </td>
        </tr>
      <tr>  
        <td colspan="2">
            <div id="acResult">
                <asp:HiddenField ID="idR" runat="server" />
                <asp:Label runat="server" ID="lblNombre" Text=""></asp:Label>
            </div>
        </td>
    </tr>
</table>
