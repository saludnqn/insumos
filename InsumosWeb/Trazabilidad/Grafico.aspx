<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Grafico.aspx.cs" Inherits="Trazabilidad_Grafico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
<script type="text/javascript" src="../js/jquery.min.js"></script>
<script type="text/javascript" src="../js/HCharts/js/highcharts.js"></script>
<script type="text/javascript" src="../js/HCharts/js/themes/grid.js"></script>
<script type="text/javascript" src="../js/HCharts/js/modules/exporting.js"></script>
<script type="text/javascript" src="../js/HCharts/js/highslide-full.min.js"></script>
<script type="text/javascript" src="../js/HCharts/js/highslide.config.js" charset="utf-8"></script>
<link rel="stylesheet" type="text/css" href="../js/HCharts/js/highslide.css" />
	<script type="text/javascript">
	    var chart;
	    $(document).ready(function() {
	        chart = new Highcharts.Chart({
	            chart: {
	                renderTo: 'container',
	                defaultSeriesType: 'line'
	            },
	            title: {
	                text: 'Movimientos del Insumo'
	            },
	            subtitle: {
	                text: 'Movimientos desde su ingreso al Sistema, en el año'
	            },
	            xAxis: {
	            categories: ['Dep1', 'Dep2', 'Dep3', 'Dep4', 'Dep5', 'Paciente']
	                // las categorias deberian ser los depositos por donde pasan los insumos
	            },
	            yAxis: {
	                title: {
	                text: 'Días (cantidad de días entre movimientos)'
	                     // aca debe ir el tiempo en el que se produce el movimiento
	                }
	            },
	            tooltip: {
	                enabled: false,
	                formatter: function() {
	                    return '<b>' + this.series.name + '</b><br/>' +
								this.x + ': ' + this.y + '°C';
	                }
	            },
	            plotOptions: {
	                line: {
	                    dataLabels: {
	                        enabled: true
	                    },
	                    enableMouseTracking: true
	                }
	            },
	            series: [{
	                name: 'Insumo',
	                data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5] //deberian ser las fechas de recepcion del insumo en cada centro
	            }]
	            });
	        });			
		</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cuerpo" Runat="Server">
<div class="divs">
<h2>Trazabilidad del Insumo</h2>
<br />
<div style="clear: both"></div>
<div id="container" style="width: 800px; height: 400px; margin: 0 auto"></div>
<br />
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Botones" Runat="Server">
<input type="button" value="Volver" title="Volver a la página anterior" onclick="history.go(-1)" />
</asp:Content>