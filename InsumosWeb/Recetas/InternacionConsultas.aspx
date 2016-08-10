<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InternacionConsultas.aspx.cs" Inherits="Recetas_InternacionConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">

    <script type="text/javascript" src="../js/Format.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate><b>Farmacia</b>
            <div class="divs">
                <h2>
                    Consultas de Recetas de Internación</h2>
                <table>
                    <tr>
                        <td>
                            Fecha Inicio:
                            <asp:TextBox ID="txtFInicio" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp; Fecha Fin:
                            <asp:TextBox ID="txtFFin" runat="server" ToolTip="Formatos permitidos: 01/03/1975, 010375, 01031975"
                                onblur="javascript:formatearFecha(this)" Width="80px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar >>" ToolTip="Buscar prescripciones dispensadas en Internación"
                                Height="23px" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <%--   <tr>
                        <td>
                 <%--           Tratamientos:
                            <asp:DropDownList ID="ddlTratamiento" runat="server" DataValueField="idTipoTratamiento" DataTextField="nombre" ToolTip="Seleccione el Tipo de Tratamiento" 
                                onselectedindexchanged="ddlTratamiento_SelectedIndexChanged" AutoPostBack="true" >
                            </asp:DropDownList>
                           
                       </td>
                    </tr>--%>
                </table>
            </div>
            <br />
            <asp:UpdatePanel ID="upRecetas" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="divs">
                        <div class="contentBoxW">
                            <asp:GridView ID="gvRecetas" runat="server" CssClass="mGrid" AutoGenerateColumns="false" PagerStyle-CssClass="pager" AllowPaging="True" OnPageIndexChanging="gvRecetas_PageIndexChanging"
                                EmptyDataText="No se encontraron registros de medicación" PageSize="20">
                                <Columns>
                                    <asp:BoundField DataField="IdEfector" HeaderText="Efector" />
                                    <asp:TemplateField HeaderText="Depósito">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepósito" runat="server" Text='<%# Bind("InsDeposito.nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DNI">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaciente" runat="server" Text='<%# Bind("SysPaciente.numerodocumento") %>'
                                                title="Documento del Paciente" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Edad" HeaderText="Edad" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha Receta" DataFormatString="{0:dd/MM/yyy}" />
                                    <asp:TemplateField HeaderText="Tipo Prescripción">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTPrescripcion" runat="server" Text='<%# Bind("InsTipoPrescripcion.nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Profesional">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProfesional" runat="server" Text='<%# Bind("SysProfesional.nombrecompleto") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
                                    <asp:TemplateField HeaderText="Tratamiento">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTratamiento" runat="server" Text='<%# Bind("InsTipoTratamiento.nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ModifiedOn" HeaderText="FechaModificación" />
                                    <asp:TemplateField HeaderText="Receta">
                                        <ItemTemplate>
                                            <a href="InternacionView.aspx?id=<%# Eval("IdPrescripcion") %>" title="Ver Receta Completa">
                                                <img id="imgVer" alt="Datos de la Receta Completa" border="0" src="../App_Themes/Default/images/receta.png" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="printButton" runat="server" Text="Imprimir" OnClientClick="javascript:window.print();" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
