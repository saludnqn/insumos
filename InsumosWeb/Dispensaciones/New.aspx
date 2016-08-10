<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="New.aspx.cs" Inherits="Dispensaciones_New" %>

<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<%@ Register Src="~/UserControls/Insumo.ascx" TagName="acInsumo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript">
        var _idInsumo;
        var _idEfector;
        var _idDeposito;

        function targetBlankPage() {
            document.forms[0].target = "_blank";
        }

        <%--function popUpLotes() {
            popUpCerrar();
            var idMedicamento = parseInt('<%=Medicamento.getInsumo() %>');            
            _idInsumo = idMedicamento;
            
            var hfIdEfector = document.getElementById('<%=SSOHelper.CurrentIdentity.IdEfector %>');    
            _idEfector = hfIdEfector.value;

            var hfIdDeposito = document.getElementById('<%=ddlDeposito.SelectedValue %>');    
            _idDeposito = hfIdDeposito.value;

            getValorEncontrado();
            });
            
        }

        function getValorEncontrado() {
            $.ajax({
                type: "POST", //Tipo de petición
                url: "Edit.aspx/getValorEncontrado", // Url y metodo que se invoca
                data: "{ idInsumo:" + _idInsumo + ",idEfector:" + _idEfector + ",idDeposito:" + _idDeposito + "}", //Necesario cuando queremos mandar algun parametro
                contentType: "application/json; charset=utf-8",
                dataType: "json", //Tipo de dato con el que se realiza la llamada
                success: function (msg) { //Procesar el valor del método invocado
                    document.getElementById('<%=txtComentario.ClientID %>').innerText = (msg.d == null ? '' : msg.d); //Mostrar en pantalla el valor retornado
                },
                Error: function (msg) { alert("No se pudo obtener el valor cargado"); }
            });
                return false;
            }

            function popUpCerrar() {
                $("#overlay_form").hide();
                $("#comentario_form").hide();
            }--%>

        function siOno() {
            if (!confirm("AVISO: ¿Desea ELiminar definitivamente el item seleccionado?"))
                history.go(-1)
            return " "
        }
    </script>

    <style type="text/css">
        #comentario_form {
            position: absolute;
            border: 2px solid gray;
            background-color: rgb(250, 255, 225);
            width: 100px;
            height: 100px;
            display: block;
        }

        #comentario_head {
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
    <asp:ScriptManager ID="scriptMgr" runat="server">
    </asp:ScriptManager>
    <div class="container">

        <%--<div class="alert alert-warning" role="alert" id="alertaDatosUltimaModificacion" runat="server">
                <p class="text-left">
                    <strong>Ultima Modificación: </strong>
                    <asp:Label ID="lblDatosUltimaModificacion" runat="server"></asp:Label>
                </p>
            </div>--%>

        <div class="panel panel-primary" id="panelRecetaRemediar">

            <div class="panel-heading">
                <label class="control-label" for="btnRemediar" style="font-size: larger">DISPENSACION RECETA</label>
                <div class="form-group">

                    <div class="checkbox" style="margin-left: 20px; margin-top: -5px">
                        <label id="btnRemediar" class="btn btn-primary">
                            <asp:CheckBox ID="IsRemediar" runat="server" Text="REMEDIAR" Enabled="false" />
                        </label>
                    </div>

                    <div class="checkbox" style="margin-left: 400px; margin-top: -60px">
                        <label id="btnTratamientoProlongado" class="btn btn-primary">
                            <asp:CheckBox ID="IsTratamientoProlongado" runat="server" Text="TRATAMIENTO PROLONGADO" Enabled="false" />
                        </label>
                    </div>
                </div>
                <div class="col-md-10"></div>
                <div class="col-md-2" style="margin-top: -45px">
                    <div id="fecha-container" style="padding-top: 0px">

                        <div class="input-group date">
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default" id="panelPaciente" style="margin-bottom: 10px">
                <%--<div class="panel-heading">Datos Paciente</div>--%>
                <div class="form-inline">
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtDoc" runat="server" class="form-control"
                                ToolTip="Ingresar el Documento del Paciente" Visible="false"
                                MaxLength="9" Width="80px" TabIndex="1"> </asp:TextBox>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success btn-md" Visible="false"
                                OnClick="btnBuscar_Click" ToolTip="Asignar Paciente"> 
                                <span> <i class="glyphicon glyphicon-ok"> </i></span></asp:LinkButton>
                        </div>
                    </div>
                    <script>
                        $('#fecha-container .input-group.date').datepicker({
                            format: "dd/mm/yyyy"
                        });
                    </script>
                </div>
                <div class="form-horizontal">
                    <div class="row">
                        <div class="col-md-9">
                            <table width="100%">
                                <tr>
                                    <td>&nbsp;<label>Paciente:</label></td>
                                    <td><strong>
                                        <asp:Label ID="lblPaciente" runat="server"></asp:Label></strong></td>
                                    <td>
                                        <label>Sexo:</label><asp:Label ID="lblSexo" runat="server"></asp:Label><asp:HiddenField ID="hfIdPaciente" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<label>Fecha Nac.:</label></td>
                                    <td>
                                        <asp:Label ID="lblFechaNac" runat="server"></asp:Label></td>

                                    <td>
                                        <label>Edad:</label><asp:Label ID="lblEdad" runat="server" Text=""></asp:Label><asp:HiddenField ID="hfEdad" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;<label>Obra Social:</label></td>
                                    <td>
                                        <asp:Label ID="lblOSocial" runat="server" ToolTip="Obra Social registrada en Empadronamiento del Paciente"></asp:Label></td>
                                    <td>
                                        <label>Historia Clínica:</label><asp:Label ID="lblHC" runat="server" ToolTip="Número de Historia Clínica en el efector" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-md-3">
                            <div class="form-inline">
                                <asp:LinkButton ID="btnMedicamentosEntregados" runat="server" CssClass="btn btn-primary btn-md" Visible="false" ToolTip="Medicamentos Entregados"
                                    OnClick="btnMedicamentosEntregados_Click">Medicación Entregada
                                        <span> <i visible="false" class="glyphicon glyphicon-search"> </i> </span></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <%--</div>--%>


                <div class="panel panel-primary" id="panelMedicamentos" style="margin-bottom: 1px">
                    <div class="panel-heading" style="margin-bottom: 5px">Medicamentos</div>
                    <div class="form-horizontal">
                        <div class="row">
                            <div id="panelBuscarMedicamento" class="col-md-12">
                                <div id="upCronico" runat="server" visible="false">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label>Duración Tratamiento:</label>

                                    <asp:TextBox ID="txtDuracion" Style="width: 50px" runat="server" MaxLength="3" minvalue="1" maxvalue="6"
                                        ToolTip="Ingresar la duración del tratamiento." TabIndex="4"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese la cantidad"
                                        Display="Dynamic" ControlToValidate="txtDuracion" ValidationGroup="C">* </asp:RequiredFieldValidator>

                                    <asp:DropDownList ID="ddlUnidadC" runat="server" ToolTip="Seleccione la unidad"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="Meses" Selected="True">Meses</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvucr" runat="server" ValidationGroup="C" ErrorMessage="Seleccione la Unidad"
                                        Display="Dynamic" ControlToValidate="ddlUnidadC" Operator="NotEqual" SetFocusOnError="true"
                                        ValueToCompare="0">*</asp:CompareValidator>
                                </div>

                                <uc1:acInsumo ID="acInsumo" runat="server" />
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div id="panelAsignar" class="col-md-12" style="margin-left: 10px">
                                <asp:LinkButton ID="btnAsignar" runat="server" CssClass="btn btn-success btn-md"
                                    OnClick="btnAsignar_Click" ToolTip="Asignar Medicamento">Asignar 
                                <span> <i class="glyphicon glyphicon-ok"> </i></span></asp:LinkButton>

                                <asp:ImageButton ID="imbAsociados" runat="server" ImageUrl="~/App_Themes/Default/images/datosfarmacolog.png"
                                    ToolTip="Ver Medicamentos Asociados" OnClick="imbAsociados_Click" />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="imbLotes" runat="server" Visible="false" ImageUrl="~/App_Themes/Default/images/prepara.png"
                                            ToolTip="Ver Stock Disponible" OnClientClick="popUpComentarioLotes()" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:DropDownList ID="ddlDeposito" Visible="false" Style="width: 200px" class="form-control" runat="server" DataValueField="idDeposito"
                                    DataTextField="nombre" TabIndex="7">
                                </asp:DropDownList>

                            </div>
                            <div class="form-horizontal">
                                <div id="panelGrillaMedicamentos" class="col-md-12">

                                    <asp:UpdatePanel ID="UpdatePanelGrillaMedicamentos" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="contentGvInsumos">
                                                <asp:GridView ID="gvInsumos" runat="server" TabIndex="5" AutoGenerateColumns="False"
                                                    CellPadding="2" CssClass="table table-hover table-condensed table-bordered" EmptyDataText="<b>No se encontraron datos.</b>" OnRowDataBound="gvInsumos_RowDataBound">
                                                    <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                                                    <Columns>
                                                        <%--columna 0--%>
                                                        <asp:TemplateField HeaderText="Item">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 1--%>
                                                        <asp:TemplateField HeaderText="IdPrescripcionDetalle" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdPrescripcionDetalle" runat="server" Text='<%# Eval("IdPrescripcionDetalle") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 2--%>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a href="javascript:switchViews('div<%# Eval("idInsumo") %>', 'one');">
                                                                    <img id="imgdiv<%# Eval("idInsumo") %>" alt="Click para mostrar/ocultar detalles"
                                                                        border="0" src="../App_Themes/Default/images/round_plus.png" />
                                                                </a>
                                                            </ItemTemplate>
                                                            <AlternatingItemTemplate>
                                                                <a href="javascript:switchViews('div<%# Eval("idInsumo") %>', 'alt');">
                                                                    <img id="imgdiv<%# Eval("idInsumo") %>" alt="Click para mostrar/ocultar detalles"
                                                                        border="0" src="../App_Themes/default/images/round_plus.png" />
                                                                </a>
                                                            </AlternatingItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 3--%>
                                                        <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 4--%>
                                                        <asp:TemplateField HeaderText="Descripción Medicamento">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 5--%>
                                                        <asp:TemplateField HeaderText="Disponibles">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtCantidadD" runat="server" Text='<%# Eval("cantidadDisponible") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 6--%>
                                                        <asp:TemplateField HeaderText="Solicitados">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCantidadSol" runat="server" ToolTip="Solicitada para todos los días de tratamiento"
                                                                    Width="50px" Text='<%# Eval("CantidadSolicitada") %>'>
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 7--%>
                                                        <asp:TemplateField HeaderText="Cant. x Mes" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCantidadSolxMes" runat="server" ToolTip="Solicitada para todos los días de tratamiento"
                                                                    Width="50px" Text='<%# Eval("CantidadSolicitada") %>'>
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 8--%>
                                                        <asp:TemplateField HeaderText="Dosis Diaria" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDosis" runat="server" Width="70px" Text='<%# Eval("Dosis") %>'
                                                                    TabIndex="6" ToolTip="Dosis Diaria tomada por el Paciente" />
                                                                <%--<asp:RequiredFieldValidator ID="rfvd" runat="server" ErrorMessage="Ingrese la dosis"
                                                                    Display="Dynamic" ControlToValidate="txtDosis" ValidationGroup="G">*</asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="cvdd" runat="server" ValidationGroup="G" ErrorMessage="Ingrese la Dosis"
                                                                    Display="Dynamic" ControlToValidate="txtDosis" Operator="NotEqual" SetFocusOnError="true"
                                                                    ValueToCompare="0">*</asp:CompareValidator>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 9--%>
                                                        <asp:TemplateField HeaderText="Unid. Dosis" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlUnidad" runat="server" Text='<%# Eval("UnidadDosis") %>'
                                                                    ToolTip="Seleccione la unidad correspondiente a la dosis diaria" TabIndex="7">
                                                                    <asp:ListItem Value="0" Selected="True">Seleccione</asp:ListItem>
                                                                    <asp:ListItem Value="mg">mg</asp:ListItem>
                                                                    <asp:ListItem Value="ml">ml</asp:ListItem>
                                                                    <asp:ListItem Value="Unidades">Unidades</asp:ListItem>
                                                                    <%--<asp:ListItem Value="gramos">gramos</asp:ListItem>
                                                                    <asp:ListItem Value="ui/ml">ui/ml</asp:ListItem>
                                                                    <asp:ListItem Value="mcg">mcg</asp:ListItem>
                                                                    <asp:ListItem Value="Comprimido">Comprimido</asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                                <%--<asp:CompareValidator ID="cvu" runat="server" ValidationGroup="G" ErrorMessage="Ingrese la Unidad correspondiente a la Dosis"
                                                                    Display="Dynamic" ControlToValidate="ddlUnidad" Operator="NotEqual" SetFocusOnError="true"
                                                                    ValueToCompare="0">*</asp:CompareValidator>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 10--%>
                                                        <asp:TemplateField HeaderText="Días" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDias" runat="server" Width="50px" Text='<%# Eval("diasTratamiento") %>'
                                                                    TabIndex="8" ToolTip="Ingrese los días que le durarán los insumos" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <%--columna 11--%>
                                                        <asp:TemplateField HeaderText="Concent./Vol." Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDosisMedicamento" runat="server" ToolTip="Ingrese la Concentración / Volumen del Medicamento"
                                                                    Width="50px" Text='<%# Eval("InsDosi.Cantidad") %>' TabIndex="9">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 12--%>
                                                        <asp:TemplateField HeaderText="Calcular" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbCalcular" runat="server" CssClass="btn btn-default btn-sm" TabIndex="10"
                                                                    OnClick="lbCalcular_Click" ToolTip="Calcular Unidades prescriptas"> 
                                                                    <span> <i class="glyphicon glyphicon-hand-right"> </i></span></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 13--%>
                                                        <asp:TemplateField HeaderText="Cant. A Entregar" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCantidadE" runat="server" ToolTip="Ingrese la Cantidad que está entregando."
                                                                    Width="40px" Text='<%# Eval("CantidadEmitida") %>' TabIndex="11">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 14--%>

                                                        <asp:TemplateField HeaderText="Adeudados">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtDeuda" runat="server" ToolTip="Cantidad Pendiente de Entrega."
                                                                    Width="50px" Text='<%# Eval("deuda") %>' TabIndex="11">
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--columna 15--%>
                                                        <asp:TemplateField HeaderText="Quitar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton runat="server" ID="ibBorrar" ToolTip="Eliminar medicación de la Lista"
                                                                    CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' OnCommand="ibBorrar_Command"
                                                                    ImageUrl="../App_Themes/Default/images/del.png" OnClientClick="siOno()" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--Grilla con detalles de lotes y vencimientos--%>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td colspan="99%">
                                                                        <div id="div<%# Eval("idInsumo") %>" style="display: inline-table; position: relative; left: 50px;">
                                                                            <asp:GridView ID="gvLotes" runat="server" DataKeyNames="idInsumo" CssClass="table table-bordered bs-table"
                                                                                AutoGenerateColumns="false">
                                                                                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                                                <EditRowStyle BackColor="black" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                                                                                    <asp:TemplateField HeaderText="Presentación Num" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPresentacionNum" runat="server" Text='<%# Eval("PresentacionNum") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Presentación">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPresentacion" runat="server" Text='<%# Eval("Presentacion") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Lote">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLote" runat="server" Text='<%# Eval("numeroLote") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Vencimiento">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblVencimiento" runat="server" Text='<%# Eval("FechaVencimiento") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Stock">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblStock" runat="server" Text='<%# Eval("stock") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <%--<asp:BoundField DataField="Presentacion" HeaderText="Presentación" />
                                                                                    <asp:BoundField DataField="numeroLote" HeaderText="Lote Nº" />
                                                                                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyy}" />
                                                                                    <asp:BoundField DataField="stock" HeaderText="Stock" />--%>
                                                                                    <asp:TemplateField HeaderText="Cant. Entregada">
                                                                                        <ItemTemplate>
                                                                                            <%--<asp:CheckBox ID="cbPedidoDetalle" runat="server" Width="30px" ToolTip="Ingrese la cantidad a dipensar por lote." />--%>
                                                                                            <asp:TextBox ID="txtCantAsignada" runat="server" ToolTip="Ingrese la Cantidad a Entregar."
                                                                                                Width="50px" OnTextChanged="txtCantAsignada_TextChanged" Text="0" AutoPostBack="false">
                                                                                            </asp:TextBox>
                                                                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCantAsignada" Display="Dynamic"
                                                                                                CssClass="text-danger" ErrorMessage="La cantidad asignada es requerida." ValidationGroup="Edit" />
                                                                                            <asp:RegularExpressionValidator ControlToValidate="txtCantAsignada" runat="server" CssClass="text-danger" Display="Dynamic"
                                                                                                ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                                                                ValidationGroup="Edit">
                                                                                            </asp:RegularExpressionValidator>
                                                                                            <asp:HiddenField ID="hfIdPedidoDetalle" runat="server" Value='<%# Eval("idPedidoDetalle") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                            <asp:HiddenField runat="server" ID="hfIdEfector" Value="0" />
                                            <asp:HiddenField ID="hfIdInsumo" runat="server" Value="0" />

                                            <script type="text/javascript" language="javascript">

                                                function switchViews(obj, row) {
                                                    var div = document.getElementById(obj);
                                                    var img = document.getElementById('img' + obj);

                                                    if (div.style.display == "none") {
                                                        div.style.display = "inline";
                                                        if (row == 'alt') {
                                                            img.src = "../App_Themes/default/images/round_minus.png";
                                                            mce_src = "../App_Themes/default/images/round_minus.png";
                                                        }
                                                        else {
                                                            img.src = "../App_Themes/default/images/round_minus.png";
                                                            mce_src = "../App_Themes/default/images/round_minus.png";
                                                        }
                                                        img.alt = "Cerrar";
                                                    }
                                                    else {
                                                        div.style.display = "none";
                                                        if (row == 'alt') {
                                                            img.src = "../App_Themes/default/images/round_plus.png";
                                                            mce_src = "../App_Themes/default/images/round_plus.png";
                                                        }
                                                        else {
                                                            img.src = "../App_Themes/default/images/round_plus.png";
                                                            mce_src = "..*App_Themes/default/images/round_plus.png";
                                                        }
                                                        img.alt = "Expandir para ver mas detalles";
                                                    }
                                                }

                                                $('#aspnetForm').formValidation({
                                                    framework: 'bootstrap',
                                                    message: 'El valor no es válido!',
                                                    icon: {
                                                        valid: 'fa fa-check',
                                                        invalid: 'fa fa-times',
                                                        validating: 'fa fa-refresh fa-spin'
                                                    },

                                                }).on('change', '[name="ctl00$Cuerpo$gvInsumos$ctl02$gvLotes$ctl02$txtCantAsignada"]', function (e) {
                                                    var asignada = $('#aspnetForm').find('[name="ctl00$Cuerpo$gvInsumos$ctl02$gvLotes$ctl02$txtCantAsignada"]').val();
                                                    var stock = parseInt($('#aspnetForm').find('span[id*="lblStock"]').text());

                                                    if (asignada > stock) {
                                                        //alert("hola" + asignada + " " + stock);
                                                        $('#alertaError').removeClass('hidden').hide().fadeIn();
                                                        $("#<%= lblMensajeG.ClientID %>").text("La cantidad asignada no puede ser superior a la del lote.");
                                 }
                                 else {
                                     $('#alertaError').hide();
                                 }

                             });
                                            </script>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div id="alertaError" class="alert alert-dismissable alert-warning hidden">
                                        <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                                        <strong>Importante!</strong><asp:Label ID="lblMensajeG" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <br />




                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:Label ID="lblMensajeM" runat="server" CssClass="Msn" Text=""></asp:Label>

                            <asp:UpdatePanel ID="updPanelComentario" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <div id="comentario_form" style="display: none; font-family: Arial, Verdana, Helvetica, sans-serif; border-radius: 10px;">
                                        <div id="comentario_head">
                                            <div style="font-size: 14px; font-weight: bold; color: #000; position: absolute; padding-left: 10px;">
                                                Número                                                   
                                            </div>
                                            <input type="button" id="Button1" value="X" title="Cerrar" style="float: right; margin-right: 5px; margin-top: -5px; height: 20px; cursor: pointer; border-radius: 3px;"
                                                onclick="popUpCerrar()" />
                                        </div>
                                        <div style="text-align: left; padding-top: 20px; padding-left: 20px; font-weight: bold;">
                                            <asp:Label ID="txtComentario" runat="server" Width="100px" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="panel panel-primary" id="panelOtrosDatos" style="margin-bottom: 1px">
                        <div class="panel-heading">Otros Datos</div>

                        <div class="form-horizontal">
                            <div class="row">
                                <div class="col-md-7">

                                    <label>profesional:</label>
                                    <asp:ImageButton ID="lkProfesional" runat="server" ImageUrl="../App_Themes/Default/images/os.png"
                                        ToolTip="Donde trabaja?" OnClick="lkProfesional_Click" />

                                    <%--<uc3:acProfesional ID="acProfesional" runat="server" TabIndex="11" />--%>
                                    <asp:Label ID="lblProfesional" runat="server" type="text" class="form-control"> </asp:Label>
                                    <asp:HiddenField ID="hdfProfesional" runat="server" />
                                    <br />
                                    <label>Diagnóstico:</label>
                                    <%--<uc2:CodCie10 ID="CodCie10" runat="server" TabIndex="12" />--%>
                                    <asp:Label ID="lblDiagnostico" runat="server" type="text" class="form-control"> </asp:Label>
                                    <asp:HiddenField ID="hdfCie10" runat="server" />
                                </div>
                                <div class="col-md-5">

                                    <%--<label>Tratamiento:</label>
                            <asp:DropDownList ID="ddlTratamiento" runat="server" class="form-control" DataValueField="idTipoTratamiento" TabIndex="3"
                                DataTextField="nombre" AutoPostBack="true" OnSelectedIndexChanged="ddlTratamiento_SelectedIndexChanged">
                                </asp:DropDownList>--%>

                                    <label>Observaciones:</label>
                                    <asp:TextBox ID="txtObservaciones" class="form-control" runat="server" Width="100%" TextMode="MultiLine"
                                        Rows="5" TabIndex="13"> </asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>

                    <%--<script>
    $(document).ready(function () {
        $(".btn-success").click(function () {
            $(".collapse").collapse('show');
            alert('Paso por aca.');
        });
        $(".btn-warning").click(function () {
            $(".collapse").collapse('hide');
        });
    });
</script>--%>
                    <%--<script>
    $(document).ready(function(){
        $(".nav-tabs a").click(function(){
            $(this).tab('show');
        });
        $('.nav-tabs a').on('shown.bs.tab', function(event){
            var x = $(event.target).text();         // active tab
            var y = $(event.relatedTarget).text();  // previous tab
            $(".act span").text(x);
            $(".prev span").text(y);
        });
    });
</script>--%>

                    <br />

                    <asp:Label ID="lblMensaje" runat="server" CssClass="Msn" Text=""></asp:Label>
                    <asp:HyperLink ID="hlNuevoPaciente" runat="server" Visible="false" Target="_blank"
                        NavigateUrl="/SIPS/Paciente/PacienteEdit.aspx"
                        ToolTip="Click para buscar Ingresar un nuevo Paciente">Nuevo Paciente</asp:HyperLink>

                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"
                        ShowMessageBox="true" ShowSummary="false" ValidationGroup="G" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="BulletList"
                        ShowMessageBox="true" ShowSummary="false" ValidationGroup="C" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
        <div class="floatRight">
            <asp:LinkButton ID="btnGuardar" runat="server"
                OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md"
                ToolTip="Aceptar" UseSubmitBehavior="false" ValidationGroup="G">
                     <span> <i class="glyphicon glyphicon-ok"> </i></span>  Guardar
            </asp:LinkButton>
            <asp:LinkButton ID="btnCerrar" runat="server"
                OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
            </asp:LinkButton>
        </div>
        <!-- Modal Mensaje Registro Grabado-->
        <div class="modal fade" id="processing-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #5bc0de; border-color: #46b8da; color: #fff;">
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

    </div>

    <script type="text/javascript">
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

