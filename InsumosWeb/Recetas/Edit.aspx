<%@ Page Title="Prescripción Receta Remediar" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Recetas_Edit" %>

<%@ Register Assembly="Subsonic" Namespace="SubSonic" TagPrefix="subsonic" %>
<%@ Register Src="~/UserControls/Insumo.ascx" TagName="acInsumo" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Cie10.ascx" TagName="CodCie10" TagPrefix="uc2" %>
<%@  Register Src="~/UserControls/acProfesional.ascx" TagName="acProfesional" TagPrefix="uc3" %>

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

        function cambiarClass() {

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


        .checkbox .btn,
        .checkbox-inline .btn {
            padding-left: 2em;
            min-width: 8em;
        }

        .checkbox label,
        .checkbox-inline label {
            text-align: left;
            padding-left: 0.5em;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="panel panel-primary" id="panelRecetaRemediar">
            <div class="panel-heading">
                <label class="control-label" for="btnRemediar" style="font-size: larger">RECETA AMBULATORIA</label>
                <div class="form-group">

                    <div class="checkbox" style="margin-left: 20px; margin-top: -5px">
                        <label id="btnRemediar" class="btn btn-primary">
                            <asp:CheckBox ID="IsRemediar" runat="server" Checked="false" Text="REMEDIAR" AutoPostBack="true" OnCheckedChanged="IsRemediar_CheckedChanged" />
                        </label>
                    </div>

                    <div class="checkbox" style="margin-left: 400px; margin-top: -60px">
                        <label id="btnTratamientoProlongado" class="btn btn-primary">
                            <asp:CheckBox ID="IsTratamientoProlongado" runat="server" Text="TRATAMIENTO PROLONGADO" AutoPostBack="true" OnCheckedChanged="IsTratamientoProlongado_CheckedChanged" />
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

            <div class="panel panel-default" id="panelBusqueda" style="margin-bottom: 10px">
                <%--<div class="panel-heading">Datos Paciente</div>--%>
                <div class="form-inline">
                    <div class="row">
                        <div class="col-md-9">
                            <label class="control-label">DNI:</label>
                            <asp:TextBox ID="txtDoc" runat="server" BorderColor="#268fb8" CssClass="form-control"
                                ToolTip="Solo números"
                                MaxLength="9" Width="90px"> </asp:TextBox>

                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success btn-md"
                                OnClick="btnBuscar_Click" ToolTip="Asignar Paciente"> 
                               <span> <i  class="glyphicon glyphicon-ok"> </i> </span></asp:LinkButton>
                            <asp:LinkButton ID="hkOtraBusqueda" runat="server" CssClass="btn btn-primary btn-md"
                                ToolTip="Click para buscar Pacientes por Nombre" OnClick="hkOtraBusqueda_Click">Otras búsquedas 
                               <span> <i class="glyphicon glyphicon-search"> </i> </span></asp:LinkButton>
                        </div>
                    </div>
                    <script>
                        $('#fecha-container .input-group.date').datepicker({
                            format: "dd/mm/yyyy"
                        });
                    </script>
                </div>
            </div>

            <div class="panel panel-default" runat="server" id="panelDatosPaciente">
                <div class="form-horizontal">
                    <div class="row">
                        <div class="col-md-9">
                            <table width="100%">
                                <tr>
                                    <td>&nbsp;Paciente:</td>
                                    <td><strong>
                                        <asp:Label ID="lblPaciente" runat="server"></asp:Label></strong></td>
                                    <td>
                                        <asp:Label ID="lblSexo" runat="server"></asp:Label><asp:HiddenField ID="hfIdPaciente" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Fecha Nac.:</td>
                                    <td>
                                        <asp:Label ID="lblFechaNac" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label><asp:HiddenField ID="hfEdad" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Obra Social:</td>
                                    <td>
                                        <asp:Label ID="lblOSocial" runat="server" ToolTip="Obra Social registrada en Empadronamiento del Paciente"></asp:Label></td>
                                    <td>Historia Clínica:<asp:Label ID="lblHC" runat="server" ToolTip="Número de Historia Clínica en el efector" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-md-3">
                            <div class="form-inline">
                                <asp:LinkButton ID="btnMedicamentosEntregados" runat="server" CssClass="btn btn-primary btn-md" Visible="false" ToolTip="Medicamentos Entregados"
                                    OnClick="btnMedicamentosEntregados_Click">Medicación Entregada
                                        <span> <i visible="false" class="glyphicon glyphicon-search"> </i> </span></asp:LinkButton>

                                <%--<asp:LinkButton ID="hkCronicos" runat="server" CssClass="btn btn-primary btn-md" ToolTip="Click para ver Patologias Anteriores" visible="false"  
                                    OnClick="hkCronicos_Click" >Patologías <span> <i class="glyphicon glyphicon-search"> </i> </span></asp:LinkButton>                   --%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-primary" id="panelMedicamentos" style="margin-bottom: 1px" runat="server">
                <div class="panel-heading" style="margin-bottom: 5px">Medicamentos</div>

                <div id="upCronico" runat="server" visible="false">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label>Duración Tratamiento:</label>

                    <asp:TextBox ID="txtDuracion" Style="width: 50px" runat="server" MaxLength="3" minvalue="1" maxvalue="6"
                        ToolTip="Ingresar la duración del tratamiento."> </asp:TextBox>
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

                <div id="buscarInsumo">
                    <uc1:acInsumo ID="acInsumo" runat="server" />
                </div>

                <div id="botones">
                    <asp:LinkButton ID="btnAsignar" runat="server" CssClass="btn btn-default btn-md active"
                        OnClick="btnAsignar_Click" ToolTip="Cargar medicamento en la receta"> 
                                        <span> <i class="glyphicon glyphicon-plus"> </i> </span>Agregar</asp:LinkButton>

                    <asp:ImageButton ID="imbAsociados" runat="server" ImageUrl="~/App_Themes/Default/images/datosfarmacolog.png"
                        ToolTip="Ver Medicamentos Asociados" OnClick="imbAsociados_Click" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ImageButton ID="imbLotes" runat="server" Visible="false" ImageUrl="~/App_Themes/Default/images/prepara.png"
                                ToolTip="Ver Stock Disponible" OnClientClick="popUpComentarioLotes()" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:DropDownList ID="ddlDeposito" Visible="false" Style="width: 200px" class="form-control" runat="server" DataValueField="idDeposito"
                        DataTextField="nombre">
                    </asp:DropDownList>
                </div>

                <div id="panelGrillaMedicamentos">
                    <asp:UpdatePanel ID="UpdatePanelGrillaMedicamentos" runat="server" UpdateMode="Always">
                        <ContentTemplate>

                            <asp:GridView ID="gvInsumos" runat="server" AutoGenerateColumns="False" 
                                CellPadding="2" CssClass="table table-hover table-condensed table-bordered" EmptyDataText="Sin Medicamentos"
                                OnRowDataBound="gvInsumos_RowDataBound">
                                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="black" />
                                <Columns>
                                    <%--columna 0--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--columna 1--%>
                                    <asp:TemplateField HeaderText="IdPrescripcionDetalle" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdPrescripcionDetalle" runat="server" Text='<%# Eval("IdPrescripcionDetalle") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--columna 2--%>
                                    <asp:TemplateField HeaderText="IdInsumo" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("IdInsumo") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--columna 3--%>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Image ID="imgEstado" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--columna 4--%>
                                    <asp:TemplateField HeaderText="Medicación Prescripta">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>' Title='<%# Eval("InsInsumo.Descripcion") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--columna 5--%>                                    
                                    <asp:TemplateField HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="White"
                                        ItemStyle-Font-Size="XX-Small">
                                        <ItemTemplate>
                                            <asp:Label ID="txtCantidadD" runat="server" Text='<%# Bind("cantidadDisponible") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--columna 6--%>
                                    <asp:TemplateField HeaderText="Dosis Diaria">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDosis" runat="server" Width="60px" Text='<%# Eval("Dosis") %>'
                                                ToolTip="(Dosis)  x  (cantidad de veces por Día)" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDosis" Display="Dynamic"
                                                CssClass="text-danger" ErrorMessage="La dosis diaria es requerida." ValidationGroup="Edit" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtDosis" runat="server" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                ValidationGroup="Edit">
                                            </asp:RegularExpressionValidator>
                                            <%--<asp:CompareValidator ID="cvdd" runat="server" ValidationGroup="G" ErrorMessage="Ingrese la Dosis"
                                                                Display="Dynamic" ControlToValidate="txtDosis" Operator="NotEqual" SetFocusOnError="true"
                                                                ValueToCompare="0">*</asp:CompareValidator>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--columna 7--%>
                                    <asp:TemplateField HeaderText="Unid. Dosis Diaria">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlUnidad" runat="server" Text='<%# Eval("UnidadDosis") %>'
                                                ToolTip="Seleccione la unidad correspondiente a la dosis diaria">
                                                <%--<asp:ListItem Value="0" Selected="True">Seleccione</asp:ListItem>--%>
                                                <asp:ListItem Value="0" Selected="True">Seleccione</asp:ListItem>
                                                <asp:ListItem Value="Unidades">Unidades</asp:ListItem>
                                                <asp:ListItem Value="mg">mg</asp:ListItem>
                                                <asp:ListItem Value="ml">ml</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="cvu" runat="server" ValidationGroup="G" ErrorMessage="Ingrese la Unidad correspondiente a la Dosis"
                                                Display="Dynamic" ControlToValidate="ddlUnidad" Operator="NotEqual" SetFocusOnError="true"
                                                ValueToCompare="0">*</asp:CompareValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--columna 8--%>
                                    <asp:TemplateField HeaderText="Días Trat." Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDiasTrat" runat="server" Width="50px" Text='<%# Eval("diasTratamiento") %>'
                                                 ToolTip="Días para los que le alcanzará la medicación" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDiasTrat" Display="Dynamic"
                                                CssClass="text-danger" ErrorMessage="Los días de tratamiento son requeridos." ValidationGroup="Edit" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtDiasTrat" runat="server" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                ValidationGroup="Edit">
                                            </asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--columna 9--%>
                                    <asp:TemplateField HeaderText="Concent./Volumen" Visible="true">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDosisMedicamento" runat="server" ToolTip="Ingrese la Concentración / Volumen del Medicamento"
                                                Width="50px" Text='<%# Eval("InsDosi.Cantidad") %>'>
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDosisMedicamento" Display="Dynamic"
                                                CssClass="text-danger" ErrorMessage="La dosis del medicamento es requerida." ValidationGroup="Edit" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtDosisMedicamento" runat="server" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                ValidationGroup="Edit">
                                            </asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--columna 10--%>
                                    <asp:TemplateField HeaderText="Calcular" Visible="true">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCalcular" runat="server" CssClass="btn btn-default btn-sm"
                                                OnClick="lbCalcular_Click" ToolTip="Calcular Cantidad prescripta"> 
                                                                    <span> <i class="glyphicon glyphicon-hand-right"> </i> </span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--columna 11--%>
                                    <asp:TemplateField HeaderText="Cantidad" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidadSol" runat="server" ToolTip="Ingrese la Cantidad Solicitada del Medicamento"
                                                Width="60px" Text='<%# Eval("CantidadSolicitada") %>'>
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCantidadSol" Display="Dynamic"
                                                CssClass="text-danger" ErrorMessage="La cantidad a solicitar es requerida." ValidationGroup="Edit" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtCantidadSol" runat="server" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                ValidationGroup="Edit">
                                            </asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--columna 12--%>
                                    <asp:TemplateField HeaderText="Cant. x Mes" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidadSolPorMes" runat="server" ToolTip="Ingrese la Cantidad Solicitada del Medicamento"
                                                Width="50px" Text='<%# Eval("CantidadSolicitada") %>'>
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCantidadSolPorMes" Display="Dynamic"
                                                CssClass="text-danger" ErrorMessage="La cantidad solicitada mensual es requerida." ValidationGroup="Edit" />
                                            <asp:RegularExpressionValidator ControlToValidate="txtCantidadSolPorMes" runat="server" CssClass="text-danger" Display="Dynamic"
                                                ErrorMessage="Solo se permite el ingreso de números." ValidationExpression="^[0-9]{0,6}(\.[0-9]{1,2})?$"
                                                ValidationGroup="Edit">
                                            </asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--columna 13--%>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="ibBorrar" ToolTip="Eliminar medicación de la Lista"
                                                CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' OnCommand="ibBorrar_Command"
                                                ImageUrl="../App_Themes/Default/images/del.png" OnClientClick="siOno()" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--Grilla con detalles de lotes y vencimientos--%>
                                    <%--<asp:TemplateField>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td colspan="99%">
                                                                        <div id="div<%# Eval("idInsumo") %>" style="display: none; position: relative; left: 2px;">
                                                                            <asp:GridView ID="gvInsumosStock" runat="server" DataKeyNames="idInsumo" CssClass="mGridI"
                                                                                AutoGenerateColumns="false">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                                                                                    <asp:BoundField DataField="Presentacion" HeaderText="Presentación" />
                                                                                    <asp:BoundField DataField="numeroLote" HeaderText="Lote Nº" />
                                                                                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyy}" />
                                                                                    <asp:BoundField DataField="stock" HeaderText="Stock" />
                                                                                    <asp:TemplateField HeaderText="Asignar">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="cbPedido" runat="server" Width="30px" ToolTip="Seleccione el lote que se utilizará para dispensar" />                                                                                       
                                                                                        <asp:HiddenField ID="hfIdPedidoDetalle" runat="server" Value='<%# Eval("idPedidoDetalle") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>                                                        
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>

                            <asp:HiddenField ID="hfIdInsumo" runat="server" />
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
                            </script>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>
            <br />
            <div class="panel panel-primary" id="panelOtrosDatos" style="margin-bottom: 1px" runat="server">
                <div class="panel-heading">Otros Datos</div>
                <br />
                <div class="form-horizontal">
                    <div class="row">
                        <div class="col-md-7">
                            <label>PROFESIONAL:</label>
                            <asp:ImageButton ID="lkProfesional" runat="server" ImageUrl="../App_Themes/Default/images/os.png"
                                ToolTip="Donde trabaja?" OnClick="lkProfesional_Click" />

                           
                                <uc3:acProfesional ID="acProfesional" runat="server"/>

                            <%--Propuesta búsqueda Lucho--%>
                          <%--  <div id="divInputProfesional" runat="server" visible="true">
                                <div class="input-group">
                                    <input id="profesional" type="text" class="form-control" tabindex="11">
                                    <span class="input-group-btn">
                                        <button id="btnLimpiaProfesional" class="btn btn-default" type="button" tabindex="12">
                                            <i class="glyphicon glyphicon-remove"></i>
                                        </button>
                                    </span>

                                    <asp:HiddenField ID="hdfIdProfesional" runat="server" />
                                    <asp:HiddenField ID="hdfApellidoyNombre" runat="server" />
                                </div>
                            </div>
                            <input id="txtProfesional" runat="server" type="text" visible="false" class="form-control" tabindex="11">
--%>
                            <br />
                            <br />

                            <label>DIAGNOSTICO:</label>
                            <uc2:CodCie10 ID="CodCie10" runat="server" />

                        </div>
                        <div class="col-md-5">

                            <%--<label>Tratamiento:</label>
                            <asp:DropDownList ID="ddlTratamiento" runat="server" class="form-control" DataValueField="idTipoTratamiento" TabIndex="3"
                                DataTextField="nombre" AutoPostBack="true" OnSelectedIndexChanged="ddlTratamiento_SelectedIndexChanged">
                                </asp:DropDownList>--%>

                            <label>OBSERVACIONES:</label>
                            <asp:TextBox ID="txtObservaciones" class="form-control" runat="server" Width="100%" TextMode="MultiLine"
                                Rows="8"> </asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>





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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
        <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
            <div class="floatRight">
                <asp:LinkButton ID="btnGuardar" runat="server" Enabled="true"
                    OnClick="btnGuardar_Click" CssClass="btn btn-success btn-md"
                    ToolTip="Aceptar">
                     <span> <i class="glyphicon glyphicon-ok"> </i> </span>  Guardar
                </asp:LinkButton>
                <asp:LinkButton ID="btnCerrar" runat="server"
                    OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i> </span>  Cerrar
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <script>
        function modal() {
            $('#processing-modal').modal('show');
        }
    </script>

    <script type="text/javascript">

        function cerrarVentana() {
            window.close();
        }

        function DisableButton(btn) {
            var isPageValid = true;
            if (typeof (Page_ClientValidate) == 'function') {
                isPageValid = Page_ClientValidate('0');
            }

            if (Page_IsValid) {
                //btn.disabled = true;
                //btn.text = 'Espere...';
                //alert('Registro Grabado!!');
                //$(".panelBotones_cargando").hide();
                //$(".panelBotones .floatRight").hide();
                //$(".panelBotones_cargando").show();
            }
        }


        function enter2tab(e) {
            //if (e.keyCode == 13) {
            //    cb = parseInt($(this).attr('tabindex'));

            //    if ($(':input[tabindex=\'' + (cb + 1) + '\']') != null) {
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').focus();
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').select();
            //        e.preventDefault();

            //        return false;
            //    }
            //}
        }
    </script>

   <%-- <script type="text/javascript">
        $(document).ready(function () {

            $("#btnLimpiaProfesional").click(function () {
                $('#profesional').val('');
                $('#typehead').show();
            });
        });
    </script>--%>

    <%--<script type="text/javascript">
        $('#profesional').typeahead({
            source: function (query, process) {
                states = [];
                map = {};
                var data = <%= llenarProfesionales()%>

                $.each(data, function (i, state) {
                    map[state.ApellidoyNombre] = state;
                    states.push(state.ApellidoyNombre);
                });
                process(states);
            },
            updater: function (item) {
                selecIdProfesional = map[item].idProfesional;
                selecApellidoyNombre = map[item].ApellidoyNombre;
                document.getElementById("<%=hdfIdProfesional.ClientID%>").value = selecIdProfesional;
                document.getElementById("<%=hdfApellidoyNombre.ClientID%>").value = selecApellidoyNombre;
                return item;
            },
        });
    </script>--%>

    <script type="text/javascript">

        function cerrarVentana() {
            window.close();
        }

        function DisableButton(btn) {
            var isPageValid = true;
            if (typeof (Page_ClientValidate) == 'function') {
                isPageValid = Page_ClientValidate('0');
            }

            if (Page_IsValid) {
                //btn.disabled = true;
                //btn.text = 'Espere...';
                //alert('Registro Grabado!!');
                //$(".panelBotones_cargando").hide();
                //$(".panelBotones .floatRight").hide();
                //$(".panelBotones_cargando").show();
            }
        }


        function enter2tab(e) {
            //if (e.keyCode == 13) {
            //    cb = parseInt($(this).attr('tabindex'));

            //    if ($(':input[tabindex=\'' + (cb + 1) + '\']') != null) {
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').focus();
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').select();
            //        e.preventDefault();

            //        return false;
            //    }
            //}
        }
    </script>

    <%--<script type="text/javascript">
        $(document).ready(function () {

            $("#btnLimpiaProfesional").click(function () {
                $('#profesional').val('');
                $('#typehead').show();
            });
        });
    </script>--%>

    <%--<script type="text/javascript">
        $('#profesional').typeahead({
            source: function (query, process) {
                states = [];
                map = {};
                var data = <%= llenarProfesionales()%>

                $.each(data, function (i, state) {
                    map[state.ApellidoyNombre] = state;
                    states.push(state.ApellidoyNombre);
                });
                process(states);
            },
            updater: function (item) {
                selecIdProfesional = map[item].idProfesional;
                selecApellidoyNombre = map[item].ApellidoyNombre;
                document.getElementById("<%=hdfIdProfesional.ClientID%>").value = selecIdProfesional;
                document.getElementById("<%=hdfApellidoyNombre.ClientID%>").value = selecApellidoyNombre;
                return item;
            },
        });
    </script>--%>

    <script type="text/javascript">

        function cerrarVentana() {
            window.close();
        }

        function DisableButton(btn) {
            var isPageValid = true;
            if (typeof (Page_ClientValidate) == 'function') {
                isPageValid = Page_ClientValidate('0');
            }

            if (Page_IsValid) {
                //btn.disabled = true;
                //btn.text = 'Espere...';
                //alert('Registro Grabado!!');
                //$(".panelBotones_cargando").hide();
                //$(".panelBotones .floatRight").hide();
                //$(".panelBotones_cargando").show();
            }
        }


        function enter2tab(e) {
            //if (e.keyCode == 13) {
            //    cb = parseInt($(this).attr('tabindex'));

            //    if ($(':input[tabindex=\'' + (cb + 1) + '\']') != null) {
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').focus();
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').select();
            //        e.preventDefault();

            //        return false;
            //    }
            //}
        }
    </script>

    <%--<script type="text/javascript">
        $(document).ready(function () {

            $("#btnLimpiaProfesional").click(function () {
                $('#profesional').val('');
                $('#typehead').show();
            });
        });
    </script>--%>

    <%--<script type="text/javascript">
        $('#profesional').typeahead({
            source: function (query, process) {
                states = [];
                map = {};
                var data = <%= llenarProfesionales()%>

                $.each(data, function (i, state) {
                    map[state.ApellidoyNombre] = state;
                    states.push(state.ApellidoyNombre);
                });
                process(states);
            },
            updater: function (item) {
                selecIdProfesional = map[item].idProfesional;
                selecApellidoyNombre = map[item].ApellidoyNombre;
                document.getElementById("<%=hdfIdProfesional.ClientID%>").value = selecIdProfesional;
                document.getElementById("<%=hdfApellidoyNombre.ClientID%>").value = selecApellidoyNombre;
                return item;
            },
        });
    </script>--%>
    <script type="text/javascript">

        function cerrarVentana() {
            window.close();
        }

        function DisableButton(btn) {
            var isPageValid = true;
            if (typeof (Page_ClientValidate) == 'function') {
                isPageValid = Page_ClientValidate('0');
            }

            if (Page_IsValid) {
                //btn.disabled = true;
                //btn.text = 'Espere...';
                //alert('Registro Grabado!!');
                //$(".panelBotones_cargando").hide();
                //$(".panelBotones .floatRight").hide();
                //$(".panelBotones_cargando").show();
            }
        }


        function enter2tab(e) {
            //if (e.keyCode == 13) {
            //    cb = parseInt($(this).attr('tabindex'));

            //    if ($(':input[tabindex=\'' + (cb + 1) + '\']') != null) {
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').focus();
            //        $(':input[tabindex=\'' + (cb + 1) + '\']').select();
            //        e.preventDefault();

            //        return false;
            //    }
            //}
        }
    </script>

<%--    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnLimpiaProfesional").click(function () {
                $('#profesional').val('');
                $('#typehead').show();
            });
        });
    </script>--%>

<%--    <script type="text/javascript">
        $('#profesional').typeahead({
            source: function (query, process) {
                states = [];
                map = {};
                var data = <%= llenarProfesionales()%>

                $.each(data, function (i, state) {
                    map[state.ApellidoyNombre] = state;
                    states.push(state.ApellidoyNombre);
                });
                process(states);
            },
            updater: function (item) {
                selecIdProfesional = map[item].idProfesional;
                selecApellidoyNombre = map[item].ApellidoyNombre;
                document.getElementById("<%=hdfIdProfesional.ClientID%>").value = selecIdProfesional;
                document.getElementById("<%=hdfApellidoyNombre.ClientID%>").value = selecApellidoyNombre;
                return item;
            },
        });
    </script>--%>

    <script type="text/javascript">
        var selector = document.getElementById('<%= txtDoc.ClientID %>');
        var im = new Inputmask("[9999999999]", { showMaskOnFocus: false, showMaskOnHover: false, clearMaskOnLostFocus: true });
        im.mask(selector);
    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#aspnetForm').formValidation({
                framework: 'bootstrap',
                message: 'El valor no es válido!',
                icon: {
                    valid: 'fa fa-check',
                    invalid: 'fa fa-times',
                    validating: 'fa fa-refresh fa-spin'
                },
                fields: {
                    '<%= txtDoc.UniqueID %>': {
                        row: '.col-sm-2',
                        validators: {
                            notEmpty: {
                                message: 'El DNI es requerido'
                            }
                        }
                    },
                },
                err: {
                    container: 'popover'
                }
            });
        });
    </script>

</asp:Content>

