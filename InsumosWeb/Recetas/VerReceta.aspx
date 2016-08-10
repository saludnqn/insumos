<%@ Page Title="Dispensacion Ambulatoria" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="VerReceta.aspx.cs" Inherits="Recetas_VerReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" runat="Server">

    <div class="container">
        <div class="panel panel-primary" id="panelRecetaRemediar">
            <div class="panel-heading">
                <label class="control-label" style="font-size: larger">PRESCRIPCION AMBULATORIA</label>
                <br />
                Tipo:
                <asp:Label ID="lblPrescripcion" class="control-label" Style="font-size: larger" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;          
                Tratamiento:                                    
                <asp:Label ID="lblTratamiento" runat="server" Style="font-size: larger"></asp:Label>

                <div class="row">
                    <div class="form-group">
                        <div class="col-md-10"></div>
                        <div class="col-md-2" style="margin-top: -40px">
                            <asp:Label ID="lblFecha" runat="server" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>


            <div class="form-horizontal">
                <div class="row">
                    <div class="col-md-12">
                        <table width="100%">
                            <tr>
                                <td>&nbsp;Paciente:</td>
                                <td><strong>
                                    <asp:Label ID="lblDocumento" runat="server"></asp:Label></strong>&nbsp;|&nbsp;
                                    <asp:Label ID="lblPaciente" runat="server"></asp:Label>

                                </td>
                                <td>Historia Clínica:</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;Fecha Nac.:</td>
                                <td>
                                    <asp:Label ID="lblFechaNac" runat="server"></asp:Label></td>
                                <td>Sexo:</td>
                                <td>
                                    <asp:Label ID="lblSexo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>&nbsp;Edad:</td>
                                <td>
                                    <asp:Label ID="lblEdad" runat="server"></asp:Label></td>
                                <td>Obra Social:</td>
                                <td>
                                    <asp:Label ID="lblOSocial" runat="server"></asp:Label></td>

                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <br />

            <div class="form-horizontal">

                <div id="upCronico" runat="server" visible="true">
                    Tratamiento:
                        <asp:Label ID="lblDuracion" runat="server"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblUnidadDuracion" runat="server"></asp:Label>
                      <%--  &nbsp;&nbsp;&nbsp;| Próxima Fecha Dispensación:
                        <asp:Label ID="lblProximaFecha" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;| Nro. Dispensaciones:
                        <asp:Label ID="lblNroDispensacion" runat="server"></asp:Label>--%>
                </div>




                <br />


                <asp:GridView ID="gvReceta" runat="server" CellPadding="2" CssClass="table table-bordered table-hover table-condensed" AutoGenerateColumns="false"
                    OnRowDataBound="gvReceta_RowDataBound">
                    <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="black" />
                    <Columns>
                        <asp:BoundField DataField="idPrescripcion" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="idPrescripcionDetalle" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="renglon" HeaderText="Renglón" />
                        <asp:BoundField DataField="idInsumo" HeaderText="idInsumo" Visible="false" />
                        <asp:TemplateField HeaderText="Insumo">
                            <ItemTemplate>
                                <asp:Label ID="lblInsumo" runat="server" Text='<%# string.Concat(Eval("InsInsumo.Codigo"), " - ", Eval("InsInsumo.Nombre")) %>'
                                    Title='<%# Eval("InsInsumo.Descripcion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Dosis" HeaderText="Dosis Diaria o N° UP x Día" Visible="false" />
                        <asp:BoundField DataField="UnidadDosis" HeaderText="Unidad Dosis" Visible="false" />
                        <asp:BoundField DataField="diasTratamiento" HeaderText="Dias Trat" Visible="false" />
                        <asp:TemplateField HeaderText="Cant. Prescripta/Mes">
                            <ItemTemplate>
                                <asp:Label ID="lblSolicitado" runat="server" Text='<%# Eval("CantidadSolicitada") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prescripto Total" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSolicitadoTotal" runat="server" Text='<%# Eval("CantidadSolicitadaTotal") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--EN LA RECETA ESTOS NO FIGURAN -- POR ESO LOS SACO AL CARAJO
                        
                        <asp:TemplateField HeaderText="Entregado" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblEntregado" runat="server" Text='<%# Eval("CantidadEmitida") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Adeudado">
                            <ItemTemplate>
                                <asp:Label ID="lblDeuda" runat="server" Text='<%# Eval("Deuda") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="" HeaderText="Fecha Vto." visible="false"/>--%>
                        <%--<asp:BoundField DataField="modifiedOn" HeaderText="Actualización" visible="false"/>                    --%>
                    </Columns>
                </asp:GridView>

                <br />
                Diagnóstico:
        <asp:Label ID="lblDiagnostico" runat="server"></asp:Label><br />
                Observaciones:
        <asp:Label ID="lblObservaciones" runat="server"></asp:Label><br />
                Profesional:
        <asp:Label ID="lblProfesional" runat="server"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" runat="Server">
    <div class="row" style="background-color: #d9d9d9; padding-right: 10px">
        <div class="container">
            <div class="floatRight">

                <asp:LinkButton ID="btnDispensar" runat="server"
                    OnClick="btnDispensar_Click" CssClass="btn btn-info btn-md">
                     <span> <i class="glyphicon glyphicon-new"> </i></span>  Dispensar
                </asp:LinkButton>


                <%--<asp:LinkButton ID="btnNuevo" runat="server"
                    OnClick="lbTicket_Click" CssClass="btn btn-info btn-md" ToolTip="Nueva Prescripción">
                     <span> <i class="glyphicon glyphicon-new"> </i></span>  Nueva
                </asp:LinkButton>--%>

                <asp:LinkButton ID="btnEditar" runat="server"
                    OnClick="btnEditar_Click" CssClass="btn btn-info btn-md" ToolTip="Modificar Prescripción">
                     <span> <i class="glyphicon glyphicon-new"> </i></span>  Modificar
                </asp:LinkButton>

                <asp:LinkButton ID="printButton" runat="server"
                    OnClick="lbTicket_Click" CssClass="btn btn-info btn-md" ToolTip="Imprimir Prescripción">
                     <span> <i class="glyphicon glyphicon-print"> </i></span>  Imprimir
                </asp:LinkButton>

                <asp:linkbutton ID="btnCerrar" runat="server" 
                       OnClientClick="cerrarVentana()" CssClass="btn btn-info btn-md" ToolTip="Salir">
                     <span> <i class="glyphicon glyphicon-remove"> </i></span>  Cerrar
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <script>
        function cerrarVentana() {
            window.close();
        }
    </script>


</asp:Content>
