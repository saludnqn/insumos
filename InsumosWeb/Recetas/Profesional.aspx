<%@ Page Title="Profesional-Efector" Language="C#" AutoEventWireup="true" CodeFile="Profesional.aspx.cs"
    Inherits="Recetas_Profesional" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Datos Paciente</title>
    <link href="../App_Themes/Default/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <br />
    <div>
        <div class="divs">
            <asp:GridView ID="gvProfesional" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                EmptyDataText="Sin datos encontrados" ToolTip="Profesional asociado a los siguiente efectores">
                <Columns>
                    <asp:BoundField DataField="NombreCompleto" HeaderText="Profesional" />
                    <asp:BoundField DataField="matricula" HeaderText="Matrícula" />
                    <asp:BoundField DataField="legajo" HeaderText="Legajo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Efector" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div style="text-align: center;">
        <a href="javascript:close()">[X]-Cerrar Ventana</a>
    </div>
    </form>
</body>
</html>
