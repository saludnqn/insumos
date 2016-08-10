<%@ Page Title="Medicación Entragada al Paciente" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="MedicacionAnterior.aspx.cs" Inherits="Recetas_MedicacionAnterior" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript">
        function printPartOfPage(elementId) {
            var printContent = document.getElementById(elementId);
            var windowUrl = 'about:blank';
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(windowUrl, windowName, 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }

        function popUpCerrar() {
            $("#overlay_form").hide();
            $("#comentario_form").hide();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div id="MyFirstDiv" class="container">
        <div class="divs">
            <b>Farmacia</b>
            <h2>Medicación Entregada al Paciente</h2>
            <div style="float: left; position: absolute; margin-left: 450px; margin-top: -28px">
                <asp:Image ID="img" runat="server" ImageUrl="~/App_Themes/Default/images/pprint.png"
                    ToolTip="Imprimir Listado" onclick="javascript:printPartOfPage('MyFirstDiv')" />
            </div>
            <br />

            <div class="form-inline">
                <div class="row">
                    <div class="col-md-9">
                        <label class="control-label">DNI:</label>
                        <asp:TextBox ID="txtDoc" runat="server" class="form-control"
                            ToolTip="Ingresar el Documento del Paciente"
                            MaxLength="9" Width="90px" TabIndex="1"> </asp:TextBox>
                        <asp:LinkButton ID="btnAsignaPaciente" runat="server" CssClass="btn btn-success btn-md"
                            ToolTip="Asignar Paciente" OnClick="btnAsignaPaciente_Click"> 
                               <span> <i  class="glyphicon glyphicon-ok"> </i> </span></asp:LinkButton>
                        <asp:LinkButton ID="hkOtraBusqueda" runat="server" CssClass="btn btn-primary btn-md"
                            ToolTip="Click para buscar Pacientes por Nombre" OnClick="hkOtraBusqueda_Click">Otras búsquedas 
                               <span> <i class="glyphicon glyphicon-search"> </i> </span></asp:LinkButton>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="Msn" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <br />

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
                                <td>&nbsp;Obra Social:</td>
                                <td>
                                    <asp:Label ID="lblOSocial" runat="server" ToolTip="Obra Social registrada en Empadronamiento del Paciente"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdfIdPaciente" runat="server" />

            <br />

            <div class="form-horizontal">
                <div class="form-group">
                        <label class="control-label col-md-1">Desde:</label>
                        <div id="fechaDesde-container">
                            <div class="col-md-3">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFInicio" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                        </div>
                        <label class="control-label col-md-1">Hasta: </label>
                        <div id="fechaHasta-container" style="padding-top: 0px">
                            <div class="col-md-3 text-left">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFFin" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"
                                OnClick="btnBuscar_Click" ToolTip="Buscar Entregas">
                                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                            </asp:LinkButton>
                    </div>

            </div>

            <br />

            <asp:GridView ID="gvMedicacion" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed table-hover"
                EmptyDataText="Sin registros de medicación anterior">
                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="black" />
                <Columns>
                    <%--<asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
                            <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" />--%>
                    <asp:BoundField DataField="Fecha" HeaderText="Entrega" />
                    <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                    <asp:BoundField DataField="Insumo" HeaderText="Medicacion" />
                    <%--<asp:BoundField DataField="presentacion" HeaderText="Presentación" />
                            <asp:BoundField DataField="CantidadSolicitada" HeaderText="Solicitado" />--%>
                    <asp:BoundField DataField="CantidadEmitida" HeaderText="Entregado" />
                    <asp:BoundField DataField="Deuda" HeaderText="Adeudado" />
                    <asp:BoundField DataField="Efector" HeaderText="Efector" />
                    <%--<asp:BoundField DataField="Deposito" HeaderText="Depósito" />
                            <asp:BoundField DataField="usuario" HeaderText="Usuario" />--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server" ViewStateMode="Inherit">
    <div class="container">
        <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
            <div class="floatRight">
                <input type="button" value="Cerrar" class="btn btn-success btn-md" title="Cerrar página" onclick="window.close()" />
            </div>
        </div>
    </div>
    <script>
        $('#fechaDesde-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
        $('#fechaHasta-container .input-group.date').datepicker({
            format: "dd/mm/yyyy"
        });
    </script>
</asp:Content>
