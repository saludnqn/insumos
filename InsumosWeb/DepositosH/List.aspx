<%@ Page Title="Listado de Depósitos" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="DepositosH_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>LISTA DEPOSITOS</label>
    </section>
    <br />

    <div class="container">
        <div class="form-horizontal">
            <div class="form-group">
                <label class="control-label col-md-1">Depósito:</label>
                <div class="col-md-5 text-left">
                    <asp:DropDownList ID="ddlDeposito" CssClass="form-control" runat="server" DataValueField="idDeposito" DataTextField="nombre">
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md active"
                        OnClick="btnBuscar_Click">
                        <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                    </asp:LinkButton>
                </div>

                <div class="col-md-1">
                    <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-default btn-md active"
                        OnClick="btnEditar_Click">
                        <span> <i class="glyphicon glyphicon-pencil"> </i></span>  Editar
                    </asp:LinkButton>
                </div>

                <div class="col-md-1">
                    <asp:LinkButton ID="btnNuevo" runat="server" Visible="true"
                        OnClick="btnNuevo_Click" CssClass="btn btn-default btn-md active" ToolTip="Agregar Depósito">
                    <span> <i class="glyphicon glyphicon-plus"> </i></span>  Nuevo
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
        <div style="border: 1px dotted">
            <div class="contentBox">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="idDeposito"
                    CssClass="table table-hover table-bordered" EmptyDataText="<b>No se encontraron datos.</b>" OnRowDataBound="GridView1_RowDataBound" PagerStyle-CssClass="pager"
                    PageSize="10" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="black" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="javascript:switchViews('div<%# Eval("idDeposito") %>', 'one');">
                                    <img id="imgdiv<%# Eval("idDeposito") %>" alt="Click para mostrar/ocultar detalles"
                                        border="0" src="../App_Themes/Default/Images/round_plus.png" />
                                </a>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <a href="javascript:switchViews('div<%# Eval("idDeposito") %>', 'alt');">
                                    <img id="imgdiv<%# Eval("idDeposito") %>" alt="Click para mostrar/ocultar detalles"
                                        border="0" src="../App_Themes/default/images/round_plus.png" />
                                </a>
                            </AlternatingItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="idDeposito" HeaderText="Cód." />
                        <asp:BoundField DataField="nombre" HeaderText="Depósito" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fecha Creación" />

                        <asp:TemplateField HeaderText="Tipo">
                            <ItemTemplate>
                                <asp:Label ID="lblTipoDeposito" runat="server" Text='<%# Eval("InsTipoDeposito.Nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="baja" HeaderText="Estado" />
                        <%--<asp:HyperLinkField DataNavigateUrlFields="idDeposito" DataNavigateUrlFormatString="Edit.aspx?id={0}" HeaderText="" Text="Editar" />--%>

                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <a href="Edit.aspx?id=<%# Eval("idDeposito")%>" title="Editar Datos Depósito"
                                    target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                    <span><i class="glyphicon glyphicon-pencil"></i></span>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                </td></tr>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("idDeposito") %>" style="display: none; position: relative; left: 25px;">
                                    <asp:GridView ID="GridView2" runat="server" Font-Size="Small" Width="95%" AutoGenerateColumns="false" OnRowDataBound="GridView2_RowDataBound"
                                        DataKeyNames="idDepositoSuperior" EmptyDataText="No se registraron subdepósitos." ToolTip="Subdepósitos">
                                        <Columns>
                                            <asp:BoundField DataField="idDepositoSuperior" HeaderText="IdDepositoSuperior" Visible="false" />
                                            <asp:BoundField DataField="idDeposito" HeaderText="Cód." />
                                            <asp:BoundField DataField="nombre" HeaderText="Subdepósito" />
                                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                                            <asp:BoundField DataField="ModifiedOn" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fecha Actualización" />

                                            <asp:TemplateField HeaderText="Tipo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTipoDeposito" runat="server" Text='<%# Eval("InsTipoDeposito.Nombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="baja" HeaderText="Estado" />
                                            <asp:HyperLinkField DataNavigateUrlFields="idDeposito" DataNavigateUrlFormatString="View.aspx?id={0}"
                                                HeaderText="Datos" Text="Ver" />
                                            <%--<asp:HyperLinkField DataNavigateUrlFields="idDeposito" DataNavigateUrlFormatString="Edit.aspx?id={0}"
                                                HeaderText="Edit" Text="Editar" />--%>
                                            <asp:TemplateField HeaderText="Editar">
                                                <ItemTemplate>
                                                    <a href="Edit.aspx?id=<%# Eval("idDeposito")%>" title="Editar Datos Depósito"
                                                        target="_blank" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                                        <span><i class="glyphicon glyphicon-pencil"></i></span>
                                                    </a>
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
                            img.alt = "Cerrar para ver otros detalles";
                        }
                        else {
                            div.style.display = "none";
                            if (row == 'alt') {
                                img.src = "../App_Themes/default/images/round_plus.png";
                                mce_src = "../App_Themes/default/images/round_plus.png";
                            }
                            else {
                                img.src = "../App_Themes/default/images/round_plus.png";
                                mce_src = "../App_Themes/default/images/round_plus.png";
                            }
                            img.alt = "Expandir para ver mas detalles";
                        }
                    }
                </script>
            </div>
        </div>
    </div>
    </br>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="container">
        <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
            <div class="floatRight">
                <asp:LinkButton ID="btnCerrar" runat="server"
                    OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>
        </div>
    </div>
    </br>
</asp:Content>
