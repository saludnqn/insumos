<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsultaDispensa.aspx.cs" Inherits="Recetas_ConsultaDispensa" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
        <section class="titulo">
            <label>RECETA A DISPENSAR</label>            
        </section>
            <br />
        <div class="container">        
                <div class="form-horizontal">
                    <div class="row">
                    <div class="form-group">
                        <label class="control-label col-md-1"> Desde:</label>
                        <div id="fechaDesde-container">
                            <div class="col-md-2">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFInicio" runat="server" cssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                        </div>
                        <label class="control-label col-md-1"> Hasta: </label>
                        <div id="fechaHasta-container" style="padding-top:0px">
                            <div class="col-md-2 text-left">
                                <div class="input-group date">
                                    <asp:TextBox ID="txtFFin" runat="server" cssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <script>
                        $('#fecha-container .input-group.date').datepicker({
                            format: "dd/mm/yyyy"
                        });
                    </script>
                </div>
                    <div class="row">
                        <div class="form-group">
                            <label class="control-label col-md-1"> Receta:</label>
                            <div class="col-md-2">
                                <asp:DropDownList ID="dllTipoPrescripcion" runat="server" class="form-control" DataValueField="idTipoPrescripcion"
                                    DataTextField="nombre" ToolTip="Seleccione el Tipo de Receta" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <label class="control-label col-md-1"> Tratamiento:</label>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlTratamiento" runat="server" class="form-control" DataValueField="idTipoTratamiento"
                                    DataTextField="nombre" ToolTip="Seleccione el Tipo de Tratamiento" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                    <div class="form-group">
                        <label class="control-label col-md-1">Paciente:</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtDoc" runat="server" class="form-control" ToolTip="Ingrese el dni del paciente."></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-md"    
                                OnClick="btnBuscar_Click" ToolTip="Buscar Provisión">
                                <span> <i class="glyphicon glyphicon-search"> </i></span>  Buscar
                            </asp:LinkButton>
                    </div>
                </div>
            </div>            
                    <asp:UpdatePanel ID="upRecetas" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional"
                Visible="false">
                <ContentTemplate>
                    <%--<div class="divs">--%>
                    <div class="contentBoxW">
                        <asp:GridView ID="gvRecetas" runat="server" AutoGenerateColumns="false" PagerStyle-CssClass="pager" AllowPaging="True" OnPageIndexChanging="gvRecetas_PageIndexChanging" PageSize="20"
                            ToolTip="Recetas Ambulatorias encontradas. Ordenadas por Fecha Desc." OnRowDataBound="gvRecetas_RowDataBound" CssClass="table table-hover table-bordered" EmptyDataText="<b>No se encontraron datos.</b>" >
                                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                            <Columns>

                                <asp:TemplateField HeaderText="IdPrescripcion" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPrescripcion" runat="server" Text='<%# Eval("IdPrescripcion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="javascript:switchViews('div<%# Eval("idPrescripcion") %>', 'one');">
                                            <img id="imgdiv<%# Eval("idPrescripcion") %>" alt="Click para mostrar/ocultar detalles"
                                                border="0" src="../App_Themes/Default/images/round_plus.png" />
                                        </a>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <a href="javascript:switchViews('div<%# Eval("idPrescripcion") %>', 'alt');">
                                            <img id="imgdiv<%# Eval("idPrescripcion") %>" alt="Click para mostrar/ocultar detalles"
                                                border="0" src="../App_Themes/default/images/round_plus.png" />
                                        </a>
                                    </AlternatingItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Efector" HeaderText="Efector" />
                                <asp:TemplateField HeaderText="Tipo Receta" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipoPrescripcion" runat="server" Text='<%# Eval("TipoPrescripcion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha Receta" DataFormatString="{0:dd/MM/yyy}" />
                                <asp:TemplateField HeaderText="DNI">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDniPaciente" runat="server" Text='<%# Bind("NumeroDocumento") %>'
                                            title="Documento del Paciente" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paciente">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaciente" runat="server" Text='<%# Bind("Paciente") %>'
                                            title="Nombre del Paciente" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tratamiento">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTratamiento" runat="server" Text='<%# Bind("tratamiento") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Profesional">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProfesional" runat="server" Text='<%# Bind("Profesional") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vto. Receta">
                                    <ItemTemplate>
                                        <asp:Label ID="vencimientoReceta" runat="server" Text='<%# Bind("vencimiento") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Vencida" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="recetaVencida" runat="server" Text='<%# Bind("recetaVencida") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Receta">
                                    <ItemTemplate>
                                        <a href="VerReceta.aspx?id=<%# Eval("IdPrescripcion") %>"
                                            target="_blank" title="Datos de la Receta" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                            <%--<img id="imgVer" alt="Mas datos de la Receta" border="0" src="../App_Themes/Default/images/receta.png" />--%>
                                            <span> <i class="glyphicon glyphicon-edit"> </i></span>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Duplicar" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink Visible="true" runat="server" ID="HyperLinkDuplicar" ImageUrl="../App_Themes/Default/images/duplicar2.png"
                                            NavigateUrl='<%# Eval("IdPrescripcion", "Edit.aspx?dpl=si&id={0}") %>' Text="Duplicar datos de la Receta"
                                            ToolTip="Duplicar datos de la Receta.">
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Dispensar" Visible="true">
                                    <ItemTemplate>
                                        <asp:HyperLink Visible="true" runat="server" ID="HyperLinkDispensar" ImageUrl="../App_Themes/Default/images/prepara.png"
                                            NavigateUrl='<%# Eval("IdPrescripcion", "../Dispensaciones/New.aspx?dpl=si&id={0}") %>' Text="Dispensar a partir de los medicamentos prescriptos por el médico."
                                            ToolTip="">
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--Grilla con detalles de las entregas--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <tr>
                                            <td colspan="99%">
                                                <div id="div<%# Eval("idPrescripcion") %>" style="display: none; position: relative; left: 2px;">
                                                    <asp:GridView ID="gvDispensacionReceta" runat="server" DataKeyNames="idPrescripcion" CssClass="table table-hover table-bordered"
                                                        EmptyDataText="Sin dispensaciones. Presione el icono Dispensar para realizar una." AutoGenerateColumns="false">
                                                        <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="idPrescripcion" HeaderText="N° Prescripción" Visible="false" />
                                                            <asp:BoundField DataField="idDispensacion" HeaderText="N° Dispensación" Visible="false" />
                                                            <asp:BoundField DataField="numeroDispensacion" HeaderText="Dispensación N°" />
                                                            <asp:BoundField DataField="fecha" HeaderText="Fecha Entrega" DataFormatString="{0:dd/MM/yyy}" />
                                                            <asp:BoundField DataField="Efector" HeaderText="Efector" />
                                                            <%--<asp:TemplateField HeaderText="Ver Dispensación">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink Visible="true" runat="server" ID="HyperLink1" ImageUrl="../App_Themes/Default/images/duplicar2.png"
                                                                        NavigateUrl='<%# Eval("IdDispensacion", "../Dispensaciones/View.aspx?dpl=si&id={0}") %>' Text="Ver Dispensación."
                                                                        ToolTip="Duplicar datos de la Receta.">
                                                                    </asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>

                                                            <asp:TemplateField HeaderText="Info Dispensación">
                                                                <ItemTemplate>
                                                                    <a href="../Dispensaciones/View.aspx?id=<%# Eval("IdDispensacion") %>"
                                                                        visible="true" ID="hrefDispensar" target="_blank" title="Datos de la Dispensación" onclick="window.open(this.href, this.target, 'width=1100,height=800,scrollbars=yes,top=20, left=20'); return false;">
                                                                        <img id="imgVer" alt="Mas datos de la Dispensación" border="0" src="../App_Themes/Default/images/mas.png" />
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
                    <asp:HiddenField ID="hfIdPrescripcion" runat="server" />
      
                </ContentTemplate>
            </asp:UpdatePanel>
                </div>
        </div>
                        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color:#d9d9d9 ;padding-right:10px">
        <div class="floatRight">                
                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClick="btnCerrar_Click" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
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
