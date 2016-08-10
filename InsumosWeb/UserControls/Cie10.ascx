<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cie10.ascx.cs" Inherits="UserControls_Cie10" %>

<script type="text/javascript">
    $(function() {
        var tipoBusqueda = $("#<%= rdbTipoBusqueda.ClientID %> input:checked").val();

           $('#<%= txtAutocie10.ClientID %>').autocomplete({ source: '<%= ResolveUrl("~/Services/Cie10.ashx?tipoBusqueda=' + tipoBusqueda + '")%>', minLenght: 4,
            focus: function(event, ui) {
                $("#<%= txtAutocie10.ClientID %>").val(ui.item.codigo);
                return false;
            },
            select: function(event, ui) {
                if (ui.item.id != -666) {
                    $("#<%= txtAutocie10.ClientID %>").val(ui.item.codigo);
                    <%--$('#<%= lblNombre.ClientID %>').text( ui.item.nombre);--%>
                    <%--$('#<%= lblCodigo.ClientID %>').text("(" + ui.item.codigo + ")");--%>
                    $('#<%= lblCapitulo.ClientID %>').text(ui.item.capitulo);
                    $("#<%= idCie10.ClientID %>").val(ui.item.id);
                }
                return false;
            }
        }).data("ui-autocomplete")._renderItem = function(ul, item) {
            return $("<li></li>")
				.data("ui-autocomplete-item", item)
				.append("<a style='font-size:10px' class='list-group-item-text'>" + item.nombre + " (" + item.codigo + ")<br>" + item.capitulo + "</a>")
				.appendTo(ul);
        };

        $('#hlLimpiar').button({ icons: { primary: "ui-icon-cancel" }, text: false });
    });

    function LimpiarPrincipal() {
        $("#<%= txtAutocie10.ClientID %>").val('');
        $('#<%= lblNombre.ClientID %>').text('');
        $('#<%= lblCodigo.ClientID %>').text('');
        $('#<%= lblCapitulo.ClientID %>').text('');
        $("#<%= idCie10.ClientID %>").val('');
    }
</script>

<div>
    <div class="row">
        <div class="col-md-2">                          
            <asp:RadioButtonList ID="rdbTipoBusqueda" runat="server" Font-Size="8pt" 
                AutoPostBack="True" RepeatDirection="Horizontal" visible="true">
                        <asp:ListItem Text="Que Cominence" Value="1" GroupName="myGroup" Class="btn btn-default btn-xs" Selected="True"/>
                        <asp:ListItem Text="Que Contenga" Value="2" GroupName="myGroup" Class="btn btn-default btn-xs" />
            </asp:RadioButtonList>
        </div>      
    </div>
    
    <div class="row">  
        <div class="col-md-12">  
            <div class="input-group"> 
                <asp:TextBox runat="server" ID="txtAutocie10"  class="form-control"
                    placeholder="Ingrese aquí el Diagnóstico">
                </asp:TextBox>
                <span class="input-group-btn">
                    <button ID="hlLimpiar" class="btn btn-default" type="button"  OnClick="LimpiarPrincipal()">
                        <span> <i class="glyphicon glyphicon-remove"> </i></span>
                    </button>
                </span>                            
            </div>
            </div>
     </div>
    <div class="row">
            <div class="col-md-12">
                <div id="acResult">    
                    <asp:HiddenField ID="idCie10" runat="server" />
                    <asp:Label runat="server" ID="lblNombre" Text=""></asp:Label>
                    <asp:Label runat="server" ID="lblCodigo" Text=""></asp:Label><br />
                    <asp:Label runat="server" ID="lblCapitulo" Text=""></asp:Label>
                </div>
            </div>
        </div>
</div>
        