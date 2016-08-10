<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MedicacionPorPaciente.aspx.cs" Inherits="Recetas_MedicacionPorPaciente" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>Medicación Entregada al Paciente</h2>
        <div style="float: left; position: absolute; margin-left: 450px; margin-top: -28px">
            <asp:Image ID="img" runat="server" ImageUrl="~/App_Themes/Default/images/pprint.png"
                ToolTip="Imprimir Listado" onclick="javascript:printPartOfPage('MyFirstDiv')" />
        </div>
        <div>
            Ingrese DNI/DU:
            <asp:TextBox ID="txtDoc" runat="server" ToolTip="Ingresar el Documento del Paciente"
                MaxLength="9" Width="100px" TabIndex="1"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnBuscar" runat="server" TabIndex="2" Text="Buscar Paciente" Height="23px"
                                    OnClick="btnBuscar_Click" /><asp:HiddenField ID="hfIdPaciente" runat="server" />
        </div>
        <div id="pnDatos" runat="server" visible="true">
            <b>Paciente: <asp:Label ID="lblPaciente" runat="server" Text=""></asp:Label> &nbsp;&nbsp;&nbsp;
            Edad: <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label></b><br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br />
            <div id="MyFirstDiv">
                <div class="contentBoxW">
                    <asp:GridView ID="gvMedicacion" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                        EmptyDataText="Sin registros de medicación anterior">
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Entrega" />
                            <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                            <asp:BoundField DataField="Insumo" HeaderText="Medicación" />
                            <asp:BoundField DataField="Presentacion" HeaderText="Presentación" />
                            <asp:BoundField DataField="CantidadEmitida" HeaderText="Entregado" />
                            <asp:BoundField DataField="Deuda" HeaderText="Adeudado" />
                            <asp:BoundField DataField="Efector" HeaderText="Efector" />
                            <asp:BoundField DataField="Deposito" HeaderText="Depósito" />
                            <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>

