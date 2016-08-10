using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;

public partial class DatosFarmaceuticos_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = SubSonic.Sugar.Web.QueryString<int>("id");
            InsDatoFarmaceutico idf = new InsDatoFarmaceutico(id);

            if (!idf.IsNew)
            {
                lblMedicamento.Text = idf.InsInsumo.Nombre;
                if (idf.NecesitaReceta == true) lblReceta.Text = "Requiere Receta";
                else lblReceta.Text = "NO Requiere Receta";
                lblCodigo.Text = idf.CodigoOMS;
                lblNComplejidad.Text = idf.NivelComplejidad.ToString();
                lblComposicíon.Text = idf.Composicion;
                lblAccion.Text = idf.AccionTerapeutica;
                lblContraindicaciones.Text = idf.Contraindicaciones;
            }
        }
    }
}
