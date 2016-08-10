<%@ Control Language="C#" AutoEventWireup="true" CodeFile="acProfesional.ascx.cs" Inherits="UserControls_acProfesional" %>

<script language="javascript" type="text/javascript">
    $(function() {
        $('#<%= txtAutoProf.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/Profesional.ashx") %>', minlenght: 3,
            focus: function (event, ui) {
            $("#<%= txtAutoProf.ClientID %>").val(ui.item.nombreCompleto);
                return false;
            },
            select: function (event, ui) {
                if (ui.item.id != -1) {
                    $("#<%= txtAutoProf.ClientID %>").val(ui.item.nombreCompleto);
                    $('#<%= lblNombreCompleto.ClientID %>').text(ui.item.nombreCompleto);
                    $("#<%= idProf.ClientID %>").val(ui.item.id);
                    ActivarRequerido(false);
                }
                else {
                    ActivarRequerido(true);
                    return false;
                }
            }
        }).data("ui-autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
				.data("ui-autocomplete-item", item)
				.append("<a style='font-size:10px' class='list-group-item-text'>" + item.nombreCompleto + "</a>")
				.appendTo(ul);
        };

        $('#hlLimpiar').button({ icons: { primary: "ui-icon-cancel" }, text: false });
    });

    function LimpiarPrincipal() {
        $("#<%= txtAutoProf.ClientID %>").val('');
        $('#<%= lblNombreCompleto.ClientID %>').text('');
        $("#<%= idProf.ClientID %>").val('');

        ActivarRequerido(true);
    }
</script>
<script type="text/javascript">

    function ActivarRequerido(Activa) {
        var boolRequerido = document.getElementById('<%=boolRequerido.ClientID%>');
        if (boolRequerido.value == "true") {

            mensaje = document.getElementById('<%=lblMensajeError.ClientID%>');
            mensaje.style.visibility = (Activa == true ? "visible" : "collapse");
        }

    }

    function validar(sender, args) {
        args.IsValid = false;
        var boolRequerido = document.getElementById('<%=boolRequerido.ClientID%>');
        var id = (isNaN(document.getElementById('<%=idProf.ClientID%>').value) ? -1 : document.getElementById('<%=idProf.ClientID%>').value);
        if (id == "") id = -1;

        if ((boolRequerido.value == "true") & (id >= 0)) {
            args.IsValid = true;
        }
    }

</script>
<table class="autoCompleter">
    <tr>
        <td>
             <div class="input-group">
                <asp:TextBox runat="server" ID="txtAutoProf" Columns="85" class="form-control" 
                    placeholder="Ingrese aquí el Profesional" Width="300px"></asp:TextBox>

                 <span class="input-group-btn">
                        <button ID="hlLimpiar" class="btn btn-default" type="button"  OnClick="LimpiarPrincipal()">
                            <span> <i class="glyphicon glyphicon-remove"> </i></span>
                        </button>
                 </span>
                </div>        
        </td>
        <td>
            <asp:CustomValidator ID="cvValidar" runat="server" ErrorMessage="*" Text="*" Display="Dynamic"
                ClientValidationFunction="validar">*</asp:CustomValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="acResultP">
                <asp:HiddenField ID="idProf" runat="server" />
                <asp:HiddenField ID="boolRequerido" runat="server" />
                <asp:Label runat="server" ID="lblNombreCompleto" Text=""></asp:Label>
            </div>
            <div align="center">
                <asp:Label ID="lblMensajeError" runat="server" Text="Debe seleccionar el Profesional"
                    Style="color: #FF0000; font-size: 0.94em; visibility: collapse;"></asp:Label>
            </div>
        </td>
    </tr>
</table>