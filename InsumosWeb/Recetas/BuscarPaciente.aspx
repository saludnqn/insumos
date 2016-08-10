<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="BuscarPaciente.aspx.cs" Inherits="Recetas_BuscarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="container"><b>Farmacia</b>
        Apellido:
        <asp:TextBox ID="txtApellido" runat="server" ToolTip="Ingresar el Apellido del Paciente"
            Width="40%"></asp:TextBox><br />
        Nombre:
        <asp:TextBox ID="txtNombre" runat="server" ToolTip="Ingresar el Nombre del Paciente"
            Width="40%"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar Paciente" Height="23px" OnClick="btnBuscar_Click" />
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    
    <br />
 
        <asp:GridView ID="gvPacientes" runat="server" ToolTip="Pacientes registrados en el Sips" CssClass="table table-hover" GridLines="None" PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" EmptyDataText="No se encontraron datos."
                                    PageSize="10" AllowPaging="True" OnPageIndexChanging="gvPacientes_PageIndexChanging">
            <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="black" />
            <Columns>
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
                <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nac." DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Sexo">
                    <ItemTemplate>
                        <asp:Label ID="lblSexo" runat="server" Text='<%# Eval("SysSexo.nombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Seleccionar">
                    <ItemTemplate>
                        <a href="Edit.aspx?numeroDocumento=<%# Eval("numeroDocumento") %>" title="Asignar Paciente">
                            <img id="imgVer" alt="Asignar Paciente a la Prescripción" border="0" src="../App_Themes/Default/images/entregados.png" />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>           
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
