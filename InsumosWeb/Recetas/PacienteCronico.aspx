<%@ Page Title="Recetas Crónicas" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PacienteCronico.aspx.cs" Inherits="Recetas_PacienteCronico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <div class="divs"><b>Farmacia</b>
        <h2>
            Medicación Dispensada al Paciente</h2>
        <br />
        <div class="contentBoxW">
            <asp:GridView ID="gvRecetasCronicas" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                EmptyDataText="Sin registro de recetas de tratamiento crónico" DataKeyNames="idPrescripcion"
                OnRowDataBound="gvRecetasCronicas_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyy}" />
                    <asp:TemplateField HeaderText="TipoReceta">
                        <ItemTemplate>
                            <asp:Label ID="lblTipoReceta" runat="server" Text='<%# Bind("InsTipoPrescripcion.Nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tratamiento">
                        <ItemTemplate>
                            <asp:Label ID="lblTipoTratamiento" runat="server" Text='<%# Bind("InsTipoTratamiento.Nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Profesional">
                        <ItemTemplate>
                            <asp:Label ID="lblProfesional" runat="server" Text='<%# Bind("SysProfesional.NombreCompleto") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Diagnostico">
                        <ItemTemplate>
                            <asp:Label ID="lblDiagnostico" runat="server" Text='<%# Bind("SysCIE10.Codigo") %>'
                                ToolTip='<%# Bind("SysCIE10.Nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblTipoPrescripcion" runat="server" Text='<%# Bind("idTipoPrescripcion") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <asp:HyperLink Visible="false" runat="server" ID="verra" ImageUrl="../App_Themes/Default/images/verr.png"
                                NavigateUrl='<%# Eval("IdPrescripcion", "VerReceta.aspx?id={0}") %>' Text="Ver Receta Ambulatoria Crónica"
                                ToolTip="Ver Receta Cronica Completa">
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duplicar">
                        <ItemTemplate>
                            <%--                            <a href="Edit.aspx?id=<%# Eval("IdPrescripcion") %>&dpl=si" title="Copiar Datos de la Receta en una nueva">
                                <img id="imgDuplicar" alt="Duplicar datos de la Receta" border="0" src="../App_Themes/Default/images/duplicar2.png" />
                            </a>--%>
                            <asp:HyperLink Visible="false" runat="server" ID="edra" ImageUrl="../App_Themes/Default/images/duplicar2.png"
                                NavigateUrl='<%# Eval("IdPrescripcion", "Edit.aspx?dpl=si&id={0}") %>' Text="Duplicar datos de la Receta"
                                ToolTip="Duplicar datos de la Receta">
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <asp:HyperLink Visible="false" runat="server" ID="verri" ImageUrl="../App_Themes/Default/images/verr.png"
                                NavigateUrl='<%# Eval("IdPrescripcion", "InternacionView.aspx?id={0}") %>' Text="Ver Receta Internación"
                                ToolTip="Ver datos de la Receta">
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duplicar">
                        <ItemTemplate>
                            <asp:HyperLink Visible="false" runat="server" ID="edri" ImageUrl="../App_Themes/Default/images/duplicar2.png"
                                NavigateUrl='<%# Eval("IdPrescripcion", "PedidoInternacionEdit.aspx?dpl=si&id={0}") %>'
                                Text="Duplicar datos de la Receta" ToolTip="Duplicar datos de la Receta">
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
