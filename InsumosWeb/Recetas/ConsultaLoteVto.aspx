<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ConsultaLoteVto.aspx.cs" Inherits="Recetas_ConsultaLoteVto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StylesPlaceHolder" Runat="Server">
     <style type="text/css">
        #panelItem
        {
            min-width:300px;
        }
        
        #advertencia
        {
            background-color:AntiqueWhite;
            border:2px solid wheat;            
            height:40px;            
            margin-top:15px;            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderPlaceHolder" Runat="Server">
    <script type="text/javascript">
    $(document).ready(function () {
        $("#panelEdit").hide();
    });
</script>

<div id="panelItem">
    Stock Medicamento:
        
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBodyPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" Runat="Server">
</asp:Content>

