<%@ Control Language="C#" AutoEventWireup="true" CodeFile="acMedicamento.ascx.cs" Inherits="UserControls_Medicamento" %>

<script type="text/javascript">
    $(document).ready(function() {
        $('#hlAgregarMedicamento').button();
        $('#<%= txtAutomed.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/Medicamento.ashx") %>', minlenght: 3,
            focus: function(event, ui) {
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -666) {
                    $('#hlAgregarMedicamento').show();
                    $("#<%= txtAutomed.ClientID %>").val(ui.item.nombre);
                    $('#<%= lblNombre.ClientID %>').text(ui.item.nombre);
                    $('#<%= lblDescripcion.ClientID %>').text(ui.item.descripcion);
                    $("#<%= idInsumo.ClientID %>").val(ui.item.id);
                }
                return false;
            }
        }).data("ui-autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("ui-autocomplete-item", item)
				.append("<a><strong>" + item.nombre + "</strong> - " + item.descripcion + "</a>")
				.appendTo(ul);
        };
    });

    function AgregarMedicamento() {
        var id = $('#<%= idInsumo.ClientID %>').val();
        var nombre = $('#<%= lblNombre.ClientID %>').text();
        var descripcion = $('#<%= lblDescripcion.ClientID %>').text();
        var hl = '<a href=javascript:EliminarMedicamento(' + id + ')>Eliminar</a>';
        $('#tbCodigosMedicamento tr:last').after('<tr id=' + id + '><td>' + nombre + '</td><td>' + descripcion +'</td><td>' + hl + '</td></tr>');
        $('#SeleccionMedicamento').fadeIn();
        //Agrego los medicamentos al campo
        if ($('#<%= idInsumos.ClientID %>').val() == '') {
            $('#<%= idInsumos.ClientID %>').val($('#<%= idInsumo.ClientID %>').val());
        } else {
        $('#<%= idInsumos.ClientID %>').val($('#<%= idInsumos.ClientID %>').val() + ',' + $('#<%= idInsumo.ClientID %>').val());
        };
        $('#hlAgregarMedicamento').hide();
    };

    function EliminarMedicamento(id) {
        $('#' + id).remove();
        var ids = $('#<%= idInsumos.ClientID %>').val().split(',');
        var newids = "";
        for (i = 0; i < ids.length; i++) {
            if (ids[i] != id) {
                if (newids == "") {
                    newids += ids[i];
                } else {
                    newids += ',' + ids[i];
                }
            }
        }
        $('#<%= idInsumos.ClientID %>').val(newids);
        if (newids == "") {
            $('#SeleccionMedicamento').fadeOut();
        }
    };
</script>

<div id="acContainer">
    <asp:TextBox runat="server" ID="txtAutomed" class="form-control" Width="64%" Columns="60"></asp:TextBox>


    <div id="acResult">
        <asp:HiddenField ID="idInsumo" runat="server" />
        <asp:Label runat="server" ID="lblNombre" Text="Nombre Medicamento"></asp:Label> - <asp:Label runat="server" ID="lblDescripcion" Text="Descripcion"></asp:Label><br />
    </div>
</div>
<a href="javascript:AgregarMedicamento();" id="hlAgregarMedicamento" style="float: right; display: none;">Agregar</a>
<div id="SeleccionMedicamento" style="display: none">
    <asp:HiddenField ID="idInsumos" runat="server" />
    <table id="tbCodigosMedicamento" class="acResult">
        <tr>
            <td>
                Nombre - Descripcion
            </td>
        </tr>
    </table>
</div>