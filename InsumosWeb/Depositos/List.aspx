<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="List.aspx.cs" Inherits="Depositos_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
    <style type="text/css">
        .contentBox
        {
            background: white;
            width: 100%;
            height: auto;
            overflow: auto;
            font-family: Verdana;
            font-size: 9px;
        }
        .pager span
        {
            color: #00898c;
            font-weight: bold;
            font-size: 14pt;
            text-align: center;
            margin: 0 3px 0 3px;
        }
        .pac
        {
            width: 2px;
            color: #f7f6f3;
            font-size: 6pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">
   <div class="divs">
    <h2>
        Consulta de Depósitos</h2>
    <table>
        <tr>
            <td>
                Seleccione el Efector:
                <asp:DropDownList ID="ddlEfector" runat="server" DataValueField="idEfector" DataTextField="nombre"
                    ToolTip="Seleccione el Efector para ver los Depósitos.">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <%--                Tipo de Depósito:
                <asp:DropDownList ID="ddlTipoDep" runat="server" DataValueField="idTipoDeposito"
                    DataTextField="nombre" ToolTip="Seleccione el Tipo de Depósito a buscar.">
                </asp:DropDownList>
                <br />
--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <div class="divs">
    <div class="contentBox">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="idDeposito"
            EmptyDataText="Sin datos" OnRowDataBound="GridView1_RowDataBound" CellPadding="2"
            ForeColor="#333333" Width="100%" GridLines="Both" Font-Size="Small" PagerStyle-CssClass="pager"
            PageSize="10" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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
                <asp:BoundField DataField="nombre" HeaderText="Depósito" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fecha" />
                <asp:BoundField DataField="createdby" HeaderText="Usuario" />
                <asp:BoundField DataField="idDeposito" ItemStyle-CssClass="pac" />
                <asp:TemplateField>
                    <ItemTemplate>
                        </td></tr>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("idDeposito") %>" style="display: none; position: relative;
                                    left: 25px;">
                                    <asp:GridView ID="GridView2" runat="server" Width="95%" AutoGenerateColumns="false"
                                        DataKeyNames="idDepositoSuperior" EmptyDataText="No existen Subdepósitos registrados." ForeColor="#333333"
                                        GridLines="Both" Font-Size="X-Small" ToolTip="Subdepósitos">
                                        <Columns>
                                            <asp:BoundField DataField="idDepositoSuperior" HeaderText="IdDepositoSuperior" Visible="false" />
                                            <asp:BoundField DataField="nombre" HeaderText="Subdepósito" />
                                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                                            <asp:BoundField DataField="ModifiedOn" DataFormatString="{0:dd/MM/yyy}" HeaderText="Fecha Act." />
                                            <asp:BoundField DataField="idDeposito" ItemStyle-CssClass="pac" />
                                            <asp:HyperLinkField DataNavigateUrlFields="idDeposito" DataNavigateUrlFormatString="View.aspx?id={0}"
                                                HeaderText="Datos" Text="Ver" />
                                            <asp:HyperLinkField DataNavigateUrlFields="idDeposito" DataNavigateUrlFormatString="Edit.aspx?id={0}"
                                                HeaderText="Edit" Text="Editar" />    
                                        </Columns>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Size="Small" Font-Bold="True" />
                                        <HeaderStyle BackColor="#689fac" ForeColor="White" VerticalAlign="Middle" Font-Bold="True"
                                            HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Size="Small" Font-Bold="True" />
            <HeaderStyle BackColor="#00898c" ForeColor="White" VerticalAlign="Middle" Font-Bold="True"
                HorizontalAlign="Center" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>
