<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Depositos_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="divs">
                <h2>
                    Ingreso de Depósitos</h2>
                <table>
                    <tr>
                        <td>
                            Seleccione el Efector
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEfector" runat="server" DataValueField="idEfector" DataTextField="nombre"
                                AutoPostBack="true" ToolTip="Seleccione el Efector." OnSelectedIndexChanged="ddlEfector_SelectedIndexChanged">
                            </asp:DropDownList>
                            <%--                        <div style="font-family: Verdana;">
                            <uc1:Efector ID="Efector" runat="server" />
                        </div>
--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Seleccione el Servicio
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlServicio" runat="server" DataValueField="idServicio" DataTextField="nombre"
                                ToolTip="Seleccione el Servicio.">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Depósito Superior
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDeposito" runat="server" DataValueField="idDeposito" DataTextField="nombre"
                                ToolTip="Seleccione el Deposito.">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo Depósito
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoDep" runat="server" DataValueField="idTipoDeposito"
                                DataTextField="nombre" ToolTip="Seleccione el Tipo.">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre Depósito
                        </td>
                        <td>
                            <asp:TextBox ID="txtDeposito" runat="server" Width="90%" ToolTip="Ingrese el Nombre del Depósito"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descripción
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="90%" TextMode="MultiLine"
                                Rows="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Observaciones
                        </td>
                        <td>
                            <asp:TextBox ID="txtObservaciones" runat="server" Width="90%" TextMode="MultiLine"
                                Rows="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Baja Depósito
                        </td>
                        <td>
                            <asp:CheckBox ID="cbBaja" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"
        ToolTip="Guardar los cambios" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Cancelar" title="Cancelar" onclick="history.go(-1)" />
</asp:Content>
