using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Text;

public partial class InformesInternos_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        OleDbConnection oCnn = new OleDbConnection();
        // Objeto de conexion a la base de datos
        OleDbDataAdapter daDatos = new OleDbDataAdapter();
        // Objeto Adaptador para leer datos de la Base de datos
        OleDbCommand cmdExec = new OleDbCommand();
        // objeto comando para ejecutar sentencias sql
        DataTable dtDatos = new DataTable();
        // datatable para recibir los datos de la base de datos
        StringBuilder sbQuery = new StringBuilder();
        // StringBuilder para armar cadenas

        try
        {
            oCnn.ConnectionString = "Provider=insProvider;Server=.;Database=SIntegralHDev;Uid=sa; Pwd=ssecure;";
            oCnn.Open();
            cmdExec = oCnn.CreateCommand();
            cmdExec.Connection = oCnn;

            sbQuery.Append("SELECT Consecutivo  ");
            sbQuery.Append("      ,IdentificacionPersona  ");
            sbQuery.Append("      ,TipoPersona  ");
            sbQuery.Append("      ,Grupo  ");
            sbQuery.Append("      ,PrimerNombre  ");
            sbQuery.Append("      ,PrimerApellido  ");
            sbQuery.Append("      ,SegundoApellido  ");
            sbQuery.Append("      ,Sexo  ");
            sbQuery.Append("      ,Profesion  ");
            sbQuery.Append("      ,Direccion1  ");
            sbQuery.Append("      ,Direccion2  ");
            sbQuery.Append("      ,TelFijo1  ");
            sbQuery.Append("      ,TelFijo2  ");
            sbQuery.Append("      ,TelMovil  ");
            sbQuery.Append("      ,PaginaWeb  ");
            sbQuery.Append("      ,ZonaPostal  ");
            sbQuery.Append("      ,Fax  ");
            sbQuery.Append("      ,Email1  ");
            sbQuery.Append("      ,Email2  ");
            sbQuery.Append("      ,FechaNacimiento  ");
            sbQuery.Append("            FROM Persona   ");
            cmdExec.CommandText = sbQuery.ToString();

            daDatos = new OleDbDataAdapter(cmdExec);
            daDatos.Fill(dtDatos);

            CrystalDecisions.CrystalReports.Engine.ReportDocument CrReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            // Asigno el reporte 
            CrReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            CrReport.Load(Application.ToString() + "\\CRPedido.rpt");
            CrReport.SetDataSource(dtDatos);

            CrystalReportViewer1.ReportSource = CrReport;

        }
        catch (Exception ex)
        {
            //MessageBox.Show("excepcion: " + ex.Message, "Mostrando Reporte");
        }
    }
}
