<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Stock.aspx.cs" Inherits="ProvisionesH_Stock" Title="Consultas de Stock" %>

<%@ Register Src="~/UserControls/Insumo_v2.ascx" TagName="acInsumo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    <script type="text/javascript" language="javascript">
        function switchViews(obj, row) {
            var div = document.getElementById(obj);
            var img = document.getElementById('img' + obj);

            if (div.style.display == "none") {
                div.style.display = "inline-block";
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
    <section class="titulo">
        <label>STOCK ACTUAL</label>
    </section>
    <br />
    <%--
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="lkImprimir" />
            </Triggers>
            <ContentTemplate>
                
            </ContentTemplate>
        </asp:UpdatePanel>
            
    --%>

    <div class="container">
        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlRubro" Visible="false" runat="server" class="form-control" DataValueField="codigo" DataTextField="nombre"
                        ToolTip="Seleccione el Rubro.">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-1">Depósito:</label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlDeposito" runat="server" CssClass="form-control" DataValueField="idDeposito" DataTextField="nombre"
                        ToolTip="Seleccione el Depósito." AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <%--<label class="control-label col-md-1" for="Insumo">Insumo:</label>--%>
                <div class="col-md-8">
                    <uc1:acInsumo ID="ucInsumo" runat="server" Visible="false" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-1">
                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"
                        OnClick="btnBuscar_Click" ToolTip="Buscar Insumo">
                        <span><i class="glyphicon glyphicon-search"></i></span>  Buscar
                    </asp:LinkButton>
                </div>
                <div class="col-md-2">
                    <asp:LinkButton ID="btnImprimir" runat="server" OnClick="btnImprimir_Click"
                        CssClass="btn btn-primary btn-md" ToolTip="Imprimir Listado">
                                <span> <i  class="glyphicon glyphicon-print"> </i></span>  Imprimir
                    </asp:LinkButton>
                </div>

            </div>
        </div>
        <br />
        <div class="divs">
            <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvStock_RowDataBound"
                CssClass="table table-hover table-bordered" EmptyDataText="<b>No se encontraron datos.</b>">
                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="black" />
                <Columns>
                    <%--columna 0--%>
                    <%--                    <asp:TemplateField HeaderText="Item" Visible="false">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="javascript:switchViews('div<%# Eval("codigo") %>', 'one');">
                                <img id="imgdiv<%# Eval("codigo") %>" alt="Click para mostrar/ocultar detalles"
                                    border="0" src="../App_Themes/Default/images/round_plus.png" />
                            </a>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <a href="javascript:switchViews('div<%# Eval("codigo") %>', 'alt');">
                                <img id="imgdiv<%# Eval("codigo") %>" alt="Click para mostrar/ocultar detalles"
                                    border="0" src="../App_Themes/default/images/round_plus.png" />
                            </a>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="codigo" HeaderText="Código" />--%>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <asp:Label ID="lblIdInsumo" runat="server" Text='<%# Eval("codigo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Insumo" HeaderText="Nombre Insumo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-ForeColor="Green" />
                    <asp:BoundField DataField="stock" HeaderText="Stock" ItemStyle-ForeColor="Blue" />

                    <%--Grilla con detalles de lotes y vencimientos--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="99%">
                                    <div id="div<%# Eval("codigo") %>" style="display: none; position: relative; left: 50px;">
                                        <asp:GridView ID="gvLotes" runat="server" DataKeyNames="idInsumo" CssClass="table table-bordered bs-table"
                                            AutoGenerateColumns="false">
                                            <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="black" />
                                            <Columns>
                                                <asp:BoundField DataField="idPedidoDetalle" HeaderText="ID" Visible="true" />
                                                <asp:BoundField DataField="idInsumo" HeaderText="Insumo" Visible="false" />
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

                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <a href="EditLote.aspx?id=<%# Eval("idPedidoDetalle") %>" class="btn btn-default btn-md"
                                                            target="_blank" title="Datos del lote" onclick="window.open(this.href, this.target, 'width=1000,height=600,scrollbars=yes,top=20, left=20'); return false;">
                                                            <span><i class="glyphicon glyphicon-edit"></i></span>
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
        </div>

        <div style="text-align: center">
            <asp:Label ID="lblTotal" runat="server" CssClass="lbl"></asp:Label>
        </div>

        <asp:HiddenField runat="server" ID="hfIdEfector" Value="0" />
        <asp:HiddenField ID="hfIdInsumo" runat="server" Value="0" />
        <br />

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
        <div class="floatRight">
            <asp:LinkButton ID="btnCerrar" runat="server"
                OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i aria-hidden="true" class="glyphicon glyphicon-remove"> </i></span>  Cerrar
            </asp:LinkButton>
        </div>
    </div>
</asp:Content>
