<%@ Page Title="Pedidos de Internación" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PedidoInternacionEdit.aspx.cs" Inherits="Recetas_PedidoInternacionEdit" %>

<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<%@ Register Src="~/UserControls/Insumo.ascx" TagName="Medicamento" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/acProfesional.ascx" TagName="acProfesional" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    
    <script type="text/javascript">
    function seleccionarPaciente() {
        var dom = document.domain;
        var domArray = dom.split('.');
        for (var i = domArray.length - 1; i >= 0; i--) {
            try {
                var dom = '';
                for (var j = domArray.length - 1; j >= i; j--) {
                    dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                }
                document.domain = dom;
                break;
            } catch (E) {
            }
        }

        var $this = $(this);
        $('<iframe src="intranet.hospitalneuquen.org.ar/scripts/historias/historias.dll/alta?inside=1" style="-moz-box-sizing: border-box; -webkit-box-sizing: border-box; box-sizing: border-box" />').dialog({
            title: 'Nuevo Paciente',
            autoOpen: true,
            width: 900,
            height: 500,
            modal: true,
            resizable: false,
            autoResize: true,
            overlay: {
                opacity: 0.5,
                background: "black"
            }
        }).width(900);
    }

    function seleccionarPacienteInternado() {
        var dom = document.domain;
        var domArray = dom.split('.');
        for (var i = domArray.length - 1; i >= 0; i--) {
            try {
                var dom = '';
                for (var j = domArray.length - 1; j >= i; j--) {
                    dom = (j == domArray.length - 1) ? (domArray[j]) : domArray[j] + '.' + dom;
                }
                document.domain = dom;
                break;
            } catch (E) {
            }
        }

        var $this = $(this);
        $('<iframe src="http://intranet.hospitalneuquen.org.ar/scripts/internacion/internacion.dll/mapa?inside=1" style="-moz-box-sizing: border-box; -webkit-box-sizing: border-box; box-sizing: border-box" />').dialog({
            title: 'Mapa de Camas',
            autoOpen: true,
            width: 900,
            height: 500,
            modal: true,
            resizable: false,
            autoResize: true,
            overlay: {
                opacity: 0.5,
                background: "black"
            }
        }).width(900);
    }
    </script>

    <script type="text/javascript" src="../js/Format.js"></script>

    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery-ui-1.8.16.custom.min.js"></script>

    <script type="text/javascript" src="../js/json2.js"></script>

    <link href="../App_Themes/Default/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var _idInsumo;

        function popUpComentario() {
            popUpCerrar();
            var idMedicamento = parseInt('<%=Medicamento.getInsumo() %>');
            var hfIdEfector = document.getElementById('<%=hfIdEfector.ClientID %>');
            var txtComentario = document.getElementById('<%=txtComentario.ClientID %>');
            txtComentario.innerText = ''; //innerText xq es un label el control
            _idInsumo = idMedicamento;
            _idEfector = hfIdEfector.value;

            getValorEncontrado();
            $("#comentario_form").show();
            $("#comentario_form").css({ 'left': ($(window).width() / 2 - $("#comentario_form").width()) + 'px',
                'top': ($(window).height() / 2 - $("#comentario_form").height()) + 'px',
                'position': 'absolute'
            });
        }

        function getValorEncontrado() {
            $.ajax({
                type: "POST", //Tipo de petición
                url: "Edit.aspx/getValorEncontrado", // Url y metodo que se invoca
                data: "{ idInsumo:" + _idInsumo + ",idEfector:" + _idEfector + "}", //Necesario cuando queremos mandar algun parametro
                contentType: "application/json; charset=utf-8",
                dataType: "json", //Tipo de dato con el que se realiza la llamada
                success: function(msg) { //Procesar el valor del método invocado
                    document.getElementById('<%=txtComentario.ClientID %>').innerText = (msg.d == null ? '' : msg.d); //Mostrar en pantalla el valor retornado
                },
                Error: function(msg) { alert("No se pudo obtener el valor cargado"); }
            });
            return false;
        }

        function popUpCerrar() {
            $("#overlay_form").hide();
            $("#comentario_form").hide();
        }

        function siOno() {
            if (!confirm("AVISO: ¿Desea ELiminar definitivamente el item seleccionado?"))
                history.go(-1)
            return " "
        }
    </script>

    <style type="text/css">
        #comentario_form
        {
            position: absolute;
            border: 2px solid gray;
            background-color: rgb(250, 255, 225);
            width: 100px;
            height: 100px;
            display: block;
        }
        #comentario_head
        {
            width: 100%;
            height: 18px;
            background-color: #e6e6e6;
            padding-top: 8px;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            border-bottom: solid 1px gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr>
            <td><b>Farmacia</b>
                <div class="divs">
                    <table>
                        <tr>
                            <td colspan="3">
                                <h2>
                                    Dispensación Internación</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Depósito-Area:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" DataTextField="nombre">
                                </asp:DropDownList>
                                <asp:Label ID="lblServicio" runat="server"></asp:Label> <asp:HiddenField runat="server" ID="hfIdEfector" Value="0" />
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp; Fecha:
                                <asp:TextBox ID="txtFecha" runat="server" Width="80px" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                    onblur="javascript:formatearFecha(this)"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;<%-- <a href="StockInterno.aspx" runat="server" id="arefSI" border="0"
                                    title="Click para ver el Stock" target="_blank" onclick="window.open(this.href, this.target, 'width=900,height=400,scrollbars=yes,top=100, left=100'); return false;">
                                    <asp:Image ID="imStock" runat="server" ImageUrl="~/App_Themes/Default/images/stock.png"
                                        ToolTip="Stock Actual del Depósito" /></a> &nbsp;&nbsp;&nbsp;--%>
                                <asp:ImageButton ID="imHistorial" runat="server" ImageUrl="~/App_Themes/Default/images/historial.png"
                                    ToolTip="Historial de entregas del Depósito seleccionado a Pacientes" OnClick="imHistorial_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                DNI/DU:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDoc" runat="server" ToolTip="Ingresar el Documento del Paciente"
                                    MaxLength="9" Width="100px" TabIndex="1"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar >>" ToolTip="Búsqueda de Pacientes Internados"
                                    Height="23px" OnClick="btnBuscar_Click" />
                            </td>
                            <td>
                                <%-- &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lbActualizar" runat="server" ToolTip="Stock actual del Depósito"
                                    OnClick="lbActualizar_Click">Stock Actual</asp:LinkButton>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" CssClass="Msn" Text=""></asp:Label>
                <br />
                <div id="upPaciente" runat="server" visible="false">
                    <div class="divs">
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <h2>
                                        Indentificación del Paciente</h2>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Paciente:
                                    <asp:Label ID="lblPaciente" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblSexo" runat="server"></asp:Label><asp:HiddenField ID="hfIdPaciente"
                                        runat="server" />
                                </td>
                                <td>
                                    Fecha Nacimiento:
                                    <asp:Label ID="lblFechaNac" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label><asp:HiddenField ID="hfEdad"
                                        runat="server" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbRecetas" runat="server" ToolTip="Ver Recetas Anteriores" OnClick="lbRecetas_Click">Medicación Anterior</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<a href="/Sips/Paciente/PacienteEdit.aspx" runat="server" id="edita"
                                        title="Editar datos del Paciente" target="_blank"><b>Editar Paciente</b></a>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    Obra Social:
                                    <asp:Label ID="lblOSocial" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    Fecha de Internación:
                                    <asp:Label ID="lblFInternacion" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;Nro. HC:
                                    <asp:Label ID="lblHC" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="ibMapaCama" ImageUrl="~/App_Themes/Default/images/mapa.png"
                                        ToolTip="Ver Mapa de Cama" runat="server" OnClick="ibMapaCama_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:HyperLink ID="hlCronicos" runat="server" NavigateUrl="~/Recetas/PacienteCronico.aspx"
                                        Visible="false" ToolTip="Click para ver Recetas anteriores">Recetas Anteriores</asp:HyperLink>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ToolTip="Buscar Pacientes Internados" ID="btnSeleccionarPacienteInternado"
                                        Width="200px" runat="server" Text="Acceder a Pacientes Internados" Visible="false" OnClientClick="seleccionarPacienteInternado(); return false;"
                                        UseSubmitBehavior="False" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="panelInternado" runat="server" visible="false" style="background-color: #edeab3;">
                                        <asp:LinkButton ID="lbOcultarPanel" runat="server" CssClass="derecha" ToolTip="Ocultar Panel"
                                            OnClick="lbOcultarPanel_Click">[x] Cerrar Panel</asp:LinkButton>
                                        <%--va la grilla del WS con los datos de la internacion del paciente--%>
                                        <div class="divs">
                                            <asp:GridView ID="gvInternado" runat="server" CssClass="mGrid" EmptyDataText="No se encontraron registros de internación"
                                                AutoGenerateColumns="false" OnRowDataBound="gvInternado_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="Historia" HeaderText="HC" />
                                                    <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="OS" HeaderText="Obra Social" />
                                                    <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" />
                                                    <asp:BoundField DataField="Servicio" HeaderText="Servicio" />
                                                    <asp:BoundField DataField="NumHabitacion" HeaderText="Habitación" />
                                                    <asp:TemplateField HeaderText="Cama">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCama" runat="server" Text='<%# Bind("NumCama") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Piso">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPiso" runat="server" Text="" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </td>
                                <%--<td>
                                    <div id="panelMapaCamas" runat="server" visible="false" style="background-color: #edeab3;">
                                        <asp:LinkButton ID="lbOcultarPanel1" runat="server" CssClass="derecha" ToolTip="Ocultar Panel"
                                            OnClick="lbOcultarPanel1_Click">[x] Cerrar Panel</asp:LinkButton>
                                        <%--va la grilla del WS con el mapa de cama
                                    </div>
                                </td>--%>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div class="divs">
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <b>Seleccionar el Medicamento</b>
                                    <uc1:Medicamento ID="Medicamento" runat="server" TabIndex="3" />
                                    &nbsp;&nbsp;&nbsp;
                                    <div style="float: right; margin-right: 50px; margin-top: -85px; width: auto;">
                                        <asp:Button ID="btnAsignar" runat="server" Text="Asignar Medicamento" TabIndex="4"
                                            OnClick="btnAsignar_Click1" ToolTip="Asignar Insumo para el registro de la Demanda Rechazada." />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="imbAsociados" runat="server" ImageUrl="~/App_Themes/Default/images/datosfarmacolog.png"
                                            ToolTip="Ver Medicamentos Asociados" OnClick="imbAsociados_Click" />
                                        <div style="padding-left: 280px; margin-top: -28px; z-index: 10">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imbDosis" runat="server" ImageUrl="~/App_Themes/Default/images/dosis.png"
                                                        ToolTip="Ver cantidad de Dosis del Medicamento" OnClientClick="popUpComentario()" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <asp:Label ID="lblMensajeM" runat="server" CssClass="Msn" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="updPanelComentario" runat="server" UpdateMode="Conditional"
                                        ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <div id="comentario_form" style="display: none; font-family: Arial, Verdana, Helvetica, sans-serif;
                                                border-radius: 10px;">
                                                <div id="comentario_head">
                                                    <div style="font-size: 14px; font-weight: bold; color: #000; position: absolute;
                                                        padding-left: 10px;">
                                                        Número
                                                    </div>
                                                    <input type="button" id="Button1" value="X" title="Cerrar" style="float: right; margin-right: 5px;
                                                        margin-top: -5px; height: 20px; cursor: pointer; border-radius: 3px;" onclick="popUpCerrar()" />
                                                </div>
                                                <div style="text-align: left; padding-top: 20px; padding-left: 20px; font-weight: bold;">
                                                    <asp:Label ID="txtComentario" runat="server" Width="100px" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="contentBox">
                                                <asp:GridView ID="gvInsumos" runat="server" TabIndex="4" AutoGenerateColumns="False"
                                                    CellPadding="2" CssClass="mGrid" EmptyDataText="Sin entregas" OnRowDataBound="gvInsumos_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="IdPrescripcionDetalle" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdPrescripcionDetalle" runat="server" Text='<%# Eval("IdPrescripcionDetalle") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Medicamento">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMedicamento" runat="server" Text='<%# Eval("InsInsumo.nombre") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Nº Dosis">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDosis" runat="server" Width="50px" Text='<%# Eval("Dosis") %>'
                                                                    TabIndex="5" ToolTip="Ingrese la dosis diaria" />
                                                                <asp:RequiredFieldValidator ID="rfvd" runat="server" ErrorMessage="Ingrese la dosis"
                                                                    Display="Dynamic" ControlToValidate="txtDosis" ValidationGroup="G">*</asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvdd" runat="server" ValidationGroup="G" ErrorMessage="Ingrese la Dosis"
                                                                    Display="Dynamic" ControlToValidate="txtDosis" Operator="NotEqual" SetFocusOnError="true"
                                                                    ValueToCompare="0">*</asp:CompareValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unidad Dosis">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlUnidad" runat="server" Text='<%# Eval("UnidadDosis") %>'
                                                                    ToolTip="Seleccione la unidad" TabIndex="6">
                                                                    <asp:ListItem Value="0" Selected="True">Seleccione</asp:ListItem>
                                                                    <asp:ListItem Value="mg">mg</asp:ListItem>
                                                                    <asp:ListItem Value="mg/dl">mg/dl</asp:ListItem>
                                                                    <asp:ListItem Value="gr/l">gr/l</asp:ListItem>
                                                                    <asp:ListItem Value="gramos">gramos</asp:ListItem>
                                                                    <asp:ListItem Value="ui/ml">ui/ml</asp:ListItem>
                                                                    <asp:ListItem Value="mcg">mcg</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="cvu" runat="server" ValidationGroup="G" ErrorMessage="Ingrese la Unidad"
                                                                    Display="Dynamic" ControlToValidate="ddlUnidad" Operator="NotEqual" SetFocusOnError="true"
                                                                    ValueToCompare="0">*</asp:CompareValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Días Trat">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDiasTrat" runat="server" Width="50px" Text='<%# Eval("diasTratamiento") %>'
                                                                    TabIndex="7" ToolTip="Días de tratamiento" />
                                                                <asp:RequiredFieldValidator ID="rfvdt" runat="server" ErrorMessage="Ingrese los dias de tratamiento"
                                                                    Display="Dynamic" ControlToValidate="txtDiasTrat" ValidationGroup="G">*</asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fecuencia hs.">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFrecuencia" runat="server" Text='<%# Eval("Frecuencia") %>'
                                                                    ToolTip="Seleccione la frecuencia" AutoPostBack="true" OnSelectedIndexChanged="ddlFrecuencia_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0" Selected="True">Selec</asp:ListItem>
                                                                    <asp:ListItem Value="4">4 hs</asp:ListItem>
                                                                    <asp:ListItem Value="6">6 hs</asp:ListItem>
                                                                    <asp:ListItem Value="8">8 hs</asp:ListItem>
                                                                    <asp:ListItem Value="12">12 hs</asp:ListItem>
                                                                    <asp:ListItem Value="24">24 hs</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="cvf" runat="server" ValidationGroup="G" ErrorMessage="Ingrese la Frecuencia"
                                                                    Display="Dynamic" ControlToValidate="ddlFrecuencia" Operator="NotEqual" SetFocusOnError="true"
                                                                    ValueToCompare="0">*</asp:CompareValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cant. Entregada">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCantidadE" runat="server" ToolTip="Ingrese la Cantidad Entregada al Paciente"
                                                                    Width="50px" Text='<%# Eval("CantidadEmitida") %>'>
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Frecuencia">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFrecuencia" runat="server" ToolTip="Ingrese la frecuencia" Width="60px"
                                                                    Text='<%# Eval("Frecuencia") %>'>
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Tratamiento">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTratamiento" runat="server" ToolTip="Ingrese el tratamiento"
                                                                    Width="100%" Text='<%# Eval("Observacion") %>'>
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Eliminar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton runat="server" ID="ibBorrar" ToolTip="Eliminar medicación de la Lista"
                                                                    CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' OnCommand="ibBorrar_Command"
                                                                    ImageUrl="~/App_Themes/Default/images/del.png" OnClientClick="siOno()" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Profesional:
                                </td>
                                <td>
                                    <uc2:acProfesional ID="acProfesional" runat="server" TabIndex="9" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"
                    ShowMessageBox="true" ShowSummary="false" ValidationGroup="G" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar >>" OnClick="btnGuardar_Click"
        TabIndex="10" ToolTip="Guardar y Dispensar" OnClientClick="DisableButton(this);"
        UseSubmitBehavior="false" ValidationGroup="G" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />

    <script type="text/javascript">
        function DisableButton(btn) {
            var isPageValid = true;
            if (typeof (Page_ClientValidate) == 'function') {
                isPageValid = Page_ClientValidate('0');
            }

            if (Page_IsValid) {
                btn.disabled = true; btn.value = 'Espere...';
            }
        }

        function enter2tab(e) {
            if (e.keyCode == 13) {
                cb = parseInt($(this).attr('tabindex'));

                if ($(':input[tabindex=\'' + (cb + 1) + '\']') != null) {
                    $(':input[tabindex=\'' + (cb + 1) + '\']').focus();
                    $(':input[tabindex=\'' + (cb + 1) + '\']').select();
                    e.preventDefault();

                    return false;
                }
            }
        }
    </script>

</asp:Content>
