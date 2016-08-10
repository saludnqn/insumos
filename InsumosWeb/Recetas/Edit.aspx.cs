using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DalInsumos;
using ExtensionMethods;
using SubSonic;
using System.Data;
using System.Globalization;
using System.Web.Services;
using Salud.Security.SSO;
using Newtonsoft.Json;
using System.Runtime.Serialization;



[Serializable]


public class stockhelper
{
    public int idPedidoDetalle { get; set; }
    public int idInsumo { get; set; }
    public int stock { get; set; }
}


public class MyJsonDictionary<K, V> : ISerializable
{
    Dictionary<K, V> dict = new Dictionary<K, V>();

    public MyJsonDictionary() { }

    protected MyJsonDictionary(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        foreach (K key in dict.Keys)
        {
            info.AddValue(key.ToString(), dict[key]);
        }
    }

    public void Add(K key, V value)
    {
        dict.Add(key, value);
    }

    public V this[K index]
    {
        set { dict[index] = value; }
        get { return dict[index]; }
    }
}

public partial class Recetas_Edit : System.Web.UI.Page
{

    private InsPrescripcionDetalleCollection Detalles
    {
        get
        {
            return ViewState["detalles"] == null ? new InsPrescripcionDetalleCollection() : (InsPrescripcionDetalleCollection)ViewState["detalles"];
        }
        set { ViewState["detalles"] = value; }
    }

    public bool tieneStock { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)                   
            return;        
        
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        txtDoc.Focus();
        panelMedicamentos.Visible = false;
        panelOtrosDatos.Visible = false;

        int doc = SubSonic.Sugar.Web.QueryString<int>("numeroDocumento");
        if (doc > 0)
        {
            txtDoc.Text = doc.ToString();
            llenarDatos();
        }
        CargarCombos();
        lblMensajeM.Text = "";
        txtFecha.Text = DateTime.Now.ToShortDateString();

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            llenarDatos();
            CargarReceta(id);            
        }       
    }

    private void CargarReceta(int id)
    {
        //panelPaciente.Visible = true;
        string dpl = SubSonic.Sugar.Web.QueryString<string>("dpl");
        InsPrescripcion p = new InsPrescripcion(id);
        if (!p.IsNew)
        {
            panelMedicamentos.Visible = true;
            panelOtrosDatos.Visible = true;

            ddlDeposito.SelectedValue = p.IdDeposito.ToString();
            txtFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();

            if (p.IdTipoTratamiento == 2)
            {
                IsTratamientoProlongado.Checked = true;
                upCronico.Visible = true;
            }
            if (p.IdTipoPrescripcion == 2)
                IsRemediar.Checked = true;

            txtDoc.Text = p.SysPaciente.NumeroDocumento.ToString();
            lblPaciente.Text = p.SysPaciente.Apellido + ", " + p.SysPaciente.Nombre;
            lblSexo.Text = "Sexo: " + p.SysPaciente.SysSexo.Nombre;
            hfIdPaciente.Value = p.IdPaciente.ToString();
            lblFechaNac.Text = Convert.ToDateTime(p.SysPaciente.FechaNacimiento).ToShortDateString();
            hfEdad.Value = p.Edad.ToString();
            lblEdad.Text = "Edad: " + p.Edad.ToString();
            if (p.IdObraSocial > 0)
                lblOSocial.Text = p.SysObraSocial.Nombre;
            else lblOSocial.Text = "--";

            acProfesional.setProf(p.IdProfesional.GetValueOrDefault(0));
            CodCie10.setDiagnosticoPrincipal(p.IdCODCie10.GetValueOrDefault(0));
            
            txtObservaciones.Text = p.Observaciones;
            
            
            //divInputProfesional.Visible = true;
            //txtProfesional.Visible = true;
            //hdfIdProfesional.Value = p.SysProfesional.IdProfesional.ToString();
            //txtProfesional.Value = p.SysProfesional.ApellidoyNombre; 
           
            gvInsumos.DataSource = p.InsPrescripcionDetalleRecords;
            gvInsumos.DataBind();
            
            txtDuracion.Text = p.Duracion.ToString();

            //agrego esto
            if (p.IdTipoPrescripcion == 1)  //receta AMBULATORIA
            {
                //gvInsumos.Columns[7].Visible = false;
                gvInsumos.Columns[8].Visible = false;
                gvInsumos.Columns[9].Visible = true;
                //gvInsumos.Columns[10].Visible = true;

                gvInsumos.Columns[12].Visible = true;
                gvInsumos.Columns[13].Visible = true;
                //gvInsumos.Columns[14].Visible = true;

                if (p.IdTipoTratamiento == 1)  //Ambulatorio            
                {
                    //gvInsumos.Columns[7].Visible = true;                
                    gvInsumos.Columns[11].Visible = true;
                }
                
            }
            else if (p.IdTipoPrescripcion == 2)
            {

                if (p.IdTipoTratamiento == 2)
                {                    
                    gvInsumos.Columns[8].Visible = true;
                }
                //else if (p.IdTipoTratamiento == 1)
                //    gvInsumos.Columns[7].Visible = true;
            }

            
        }
        else txtFecha.Text = DateTime.Now.ToShortDateString();
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector del usuario
        d.And(InsDeposito.Columns.IdTipoDeposito).IsEqualTo(1); //deposito por defecto: farmacia
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.Selected).IsEqualTo(1);
        

        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();

        //SubSonic.Select t = new SubSonic.Select();
        //t.From(InsTipoTratamiento.Schema);
        //ddlTratamiento.DataSource = t.ExecuteTypedList<InsTipoTratamiento>();
        //ddlTratamiento.DataBind();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/farmacia/default.aspx");
    }
    
    protected void btnBuscarPaciente_Click(object sender, EventArgs e)
    {        
        Response.Redirect("~/BuscarPaciente.aspx");
    }

    protected void llenarDatos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        if (txtDoc.Text.Length > 0)
        {
            int doc = Convert.ToInt32(txtDoc.Text);
            DataTable dt = DalInsumos.SPs.InsGetPacientes(doc).GetDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                btnMedicamentosEntregados.Visible = true;
                panelMedicamentos.Visible = true;
                panelOtrosDatos.Visible = true;
                panelDatosPaciente.Visible = true;
                //panelLinks.Visible = true;
                lblPaciente.Text = dt.Rows[0][1].ToString();
                lblSexo.Text = "Sexo: " + dt.Rows[0][3].ToString();
                hfIdPaciente.Value = dt.Rows[0][0].ToString();
                lblFechaNac.Text = dt.Rows[0][5].ToString();
                if (Convert.ToInt32(dt.Rows[0][6]) > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0][6]) > 99)
                    {
                        lblEdad.Text = "";
                        hfEdad.Value = dt.Rows[0][6].ToString();
                    }
                    else
                    {
                        lblEdad.Text = "Edad: " + dt.Rows[0][6].ToString() + " Años";
                        hfEdad.Value = dt.Rows[0][6].ToString();
                    }
                }
                else
                {
                    lblEdad.Text = "Menor a 1 Año";
                    hfEdad.Value = "0";
                }
                lblOSocial.Text = dt.Rows[0][7].ToString();
                lblMensaje.Text = "";
                DataTable dthc = DalInsumos.SPs.SysGetPacientesHC(doc, idEfector).GetDataSet().Tables[0];
                if (dthc.Rows.Count > 0)
                {
                    lblHC.Text = dthc.Rows[0][9].ToString();
                }
                else
                {
                    lblHC.Text = "-";
                }
                //traigo los datos de recetas anteriores
                int idP = hfIdPaciente.Value.TryParseInt();
                if (RecetasCronicas(idP))
                {
                    //hlCronicos.Visible = true;
                    string ambulatorio = "si";
                    //hlCronicos.NavigateUrl = "PacienteCronico.aspx?idPaciente=" + hfIdPaciente.Value + "&ambulatorio=" + ambulatorio;
                }
                //llamo WSCronicos
                //hkCronicos.Visible = true;
                //hkCronicos.NavigateUrl = "ConsultarCronicos.aspx?Documento=" + txtDoc.Text;
            }
            else
            {
                lblMensaje.Text = "No se encuentra el paciente buscado";
                btnMedicamentosEntregados.Visible = false;
                panelMedicamentos.Visible = false;
                panelOtrosDatos.Visible = false;
                panelDatosPaciente.Visible = false;
                hlNuevoPaciente.Visible = true;
                //hlCronicos.Visible = false;
            }
        }
        else
        {
            //lblMensaje.Text = "El número ingresado no es válido";
            //hlNuevoPaciente.Visible = true;
            //panelPaciente.Visible = false;
            //hlCronicos.Visible = false;
        }
    }
    
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenarDatos();
    }

    private bool RecetasCronicas(int idPaciente)
    {
        SubSonic.SqlQuery q = new SubSonic.Select()
         .From(InsPrescripcion.Schema)
         .Where(InsPrescripcion.Columns.IdPaciente).IsEqualTo(idPaciente)
         .And(InsPrescripcion.Columns.IdTipoPrescripcion).IsEqualTo(1);

        DataTable dtd = q.ExecuteDataSet().Tables[0];
        if (dtd.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string username = SSOHelper.CurrentIdentity.Username;
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        bool hayStock = true;
        bool errorEnCantidadSE = false;

        //con esto duplico la receta
        string duplica = SubSonic.Sugar.Web.QueryString<string>("dpl");
        
        if (TieneMedicamentosAsignados() && ValidaDesdeServidor())
        {
            int prof = acProfesional.getProfesional();
            if ( prof != -1)
            {
                InsPrescripcion p;
                if (duplica == "si")  //duplica receta
                {
                    p = new InsPrescripcion();
                }
                else
                {
                    p = new InsPrescripcion(id);
                }
                p.IdEfector = idEfector;
                p.IdDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);
                p.IdPaciente = Convert.ToInt32(hfIdPaciente.Value);
                p.Edad = Convert.ToInt32(hfEdad.Value);
                p.Unidad = "Años"; // unidad de la edad
                p.IdObraSocial = p.SysPaciente.IdObraSocial;

                if (IsRemediar.Checked)
                {
                    p.IdTipoPrescripcion = 2;   //RECETA REMEDIAR            
                }
                else
                    p.IdTipoPrescripcion = 1;

                if (IsTratamientoProlongado.Checked)
                {
                    p.IdTipoTratamiento = 2;  //Prolongado        
                    p.UnidadDuracion = "MESES";
                }
                else
                {
                    p.IdTipoTratamiento = 1;  //Ambulatorio
                    p.UnidadDuracion = "DÍAS";
                }
                if (!string.IsNullOrEmpty(txtDuracion.Text))
                    p.Duracion = Convert.ToInt32(txtDuracion.Text);
                else
                    p.Duracion = 0;

                int dias = p.Duracion.Value + 30;

                p.ProximaFecha = DateTime.Now.AddDays(dias);
                p.RecetaVencida = false;
                p.NumeroDispensacion = 0;
                //if (ddlTratamiento.SelectedValue == "2")
                //{                
                //p.UnidadDuracion = ddlUnidadC.SelectedValue;
                //p.NumeroDispensacion = p.Duracion;

                //p.NumeroDispensación = Convert.ToInt32(txtDispensaciones.Text);
                //calcular el vencimiento de la receta, tengo campo RecetaVencida
                //if (p.ProximaFecha > DateTime.Now.AddDays(1))                
                //else p.Habilitada = false;
                //}
                //else
                //{
                //p.Duracion = 0;
                //p.UnidadDuracion = "";
                //p.ProximaFecha = Convert.ToDateTime("01/01/1900");
                //p.NumeroDispensacion = 0;
                //p.Habilitada = true;
                //}
                //p.IdTipoTratamiento = Convert.ToInt32(ddlTratamiento.SelectedValue);

                //if (acProfesional.getProfesional() > 0)
                //    p.IdProfesional = acProfesional.getProfesional();
                //else
                //    p.IdProfesional = -1;

                //if (hdfIdProfesional.Value != "")
                //    p.IdProfesional = int.Parse(hdfIdProfesional.Value);
                //else
                //    p.IdProfesional = -1;


                p.Diagnostico = "";

                p.IdProfesional = acProfesional.getProfesional();
                p.IdCODCie10 = CodCie10.getDiagnostico();
                p.Fecha = Convert.ToDateTime(txtFecha.Text);
                p.Observaciones = txtObservaciones.Text;
                p.Baja = false;
                p.Save(username);

                //aca comienza la cosa
                InsPrescripcionDetalleCollection pds = new InsPrescripcionDetalleCollection();
                foreach (GridViewRow gvr in gvInsumos.Rows)
                {
                    //detalle de la prescripcion o receta
                    Label lblIdPrescripcionDetalle = (Label)gvr.FindControl("lblIdPrescripcionDetalle");
                    int idPD = Convert.ToInt32(lblIdPrescripcionDetalle.Text);

                    InsPrescripcionDetalle pd = new InsPrescripcionDetalle(idPD);
                    pd.IdPrescripcion = p.IdPrescripcion;
                    pd.Fecha = Convert.ToDateTime(txtFecha.Text);
                    Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                    pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                    TextBox txtDosis = (TextBox)gvr.FindControl("txtDosis");
                    CultureInfo ci = null;
                    ci = CultureInfo.InvariantCulture;
                    if (!string.IsNullOrEmpty(txtDosis.Text))
                        pd.Dosis = decimal.Parse(txtDosis.Text.Replace(",", "."), ci);
                    //pd.Dosis = int.Parse(txtDosis.Text);
                    else
                        pd.Dosis = 0;

                    DropDownList ddlUnidad = (DropDownList)gvr.FindControl("ddlUnidad");
                    pd.UnidadDosis = ddlUnidad.SelectedValue;


                    TextBox txtDiasTrat = (TextBox)gvr.FindControl("txtDiasTrat");
                    if (!string.IsNullOrEmpty(txtDiasTrat.Text))
                        pd.DiasTratamiento = Convert.ToInt32(txtDiasTrat.Text);
                    else
                    {
                        if (IsTratamientoProlongado.Checked)
                            pd.DiasTratamiento = 30;
                        else if (IsRemediar.Checked)
                            pd.DiasTratamiento = 1;
                    }


                    Label txtCantidadD = (Label)gvr.FindControl("txtCantidadD");
                    if (!string.IsNullOrEmpty(txtCantidadD.Text))
                        pd.CantidadDisponible = Convert.ToInt32(txtCantidadD.Text);
                    else
                        pd.CantidadDisponible = 0;

                    TextBox txtCantidadSolPorMes = (TextBox)gvr.FindControl("txtCantidadSolPorMes");
                    TextBox txtCantidadSol = (TextBox)gvr.FindControl("txtCantidadSol");

                    //if (IsRemediar.Checked)
                    //{        
                    if (!string.IsNullOrEmpty(txtCantidadSolPorMes.Text))
                    {
                        pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSolPorMes.Text);
                        pd.CantidadSolicitadaTotal = pd.CantidadSolicitada.Value * p.Duracion.Value;//pd.DiasTratamiento.Value;
                        pd.Deuda = pd.CantidadSolicitadaTotal;
                    }
                    else
                    {
                        pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSol.Text); ;
                        pd.CantidadSolicitadaTotal = pd.CantidadSolicitada.Value;
                        pd.Deuda = pd.CantidadSolicitada.Value;
                    }
                    //}
                    //else
                    //{
                    //pd.CantidadSolicitada = 0;
                    //pd.CantidadSolicitadaTotal = 0;
                    //pd.Deuda = 0;
                    //}


                    //TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");
                    pd.CantidadEmitida = 0;
                    pd.Observacion = "";
                    pd.Frecuencia = "";
                    pd.Renglon = gvr.DataItemIndex + 1;
                    pd.IdInternacionPedido = 0;
                    pd.Baja = false;

                    pds.Add(pd); //se definió que se puedan generar recetas con cantidades en cero.

                    if (pd.IdInsumo > 0)
                    {
                        if (pd.CantidadDisponible > 0)
                        {
                            if (pd.CantidadEmitida > 0 && pd.CantidadSolicitada > 0)
                            {
                                //pds.Add(pd);
                            }
                            else
                                errorEnCantidadSE = true;
                        }
                        else
                            hayStock = false;
                    }
                    else
                    {

                        lblMensajeM.Text = "Debe ingresar un medicamento";
                        break;
                    }
                }

                if ((hayStock == false) || (errorEnCantidadSE))
                {
                    string alertjs = @"<script language='javascript'> alert('Atención Ud. está prescribiendo insumos sin stock.'); </script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
                }


                pds.SaveAll(username);
                //ActualizarPrescripcionEntrega(pds);
                //ActualizarStockPedidoDetalle(pds);
                Response.Redirect("VerReceta.aspx?id=" + p.IdPrescripcion.ToString());
            }
            else
            {
                string alertjs = @"<script language='javascript'> alert('Falta ingresar el profesional.'); </script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
            }
        }
        else
        {
            string alertjs = @"<script language='javascript'> alert('Revise los datos del formulario, hay datos faltantes.'); </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
        }
    }

    private void ActualizarPrescripcionEntrega(InsPrescripcionDetalleCollection pds)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;
        int dep = ddlDeposito.SelectedValue.TryParseInt();

        foreach (var item in pds)
        {
            List<stockhelper> e = DalInsumos.SPs.InsGetInsumosDisponiblesGrilla(idEfector, dep, item.IdInsumo).ExecuteTypedList<stockhelper>();
            foreach (var stock in e)
            {
                SubSonic.Select q = new Select(Aggregate.Sum("cantidad"));
                q.From(InsPrescripcionEntrega.Schema);
                q.Where(InsPrescripcionEntrega.IdPrescripcionDetalleColumn).IsEqualTo(item.IdPrescripcionDetalle);

                int entregado = q.ExecuteScalar<int>();
                int paraentregar = item.CantidadEmitida.GetValueOrDefault(0) - entregado;

                InsPrescripcionEntrega pe = new InsPrescripcionEntrega();

                pe.IdPrescripcionDetalle = item.IdPrescripcionDetalle;
                pe.Fecha = DateTime.Now;
                pe.IdPedidoDetalle = stock.idPedidoDetalle;
                pe.IdInsumo = item.IdInsumo.GetValueOrDefault(0);
                pe.IdPaciente = item.InsPrescripcion.IdPaciente.GetValueOrDefault(0);


                if (paraentregar <= stock.stock)
                {
                    // tengo stock suficiente
                    pe.Cantidad = paraentregar;
                    pe.Save(username);
                    break;
                }
                else
                {
                    pe.Cantidad = stock.stock;
                    pe.Save(username);
                }
            }
        }
    }
    
    private bool ValidaDesdeServidor()
    {
        if (Convert.ToInt32(ddlDeposito.SelectedValue) < 1)
            return false;

        if (gvInsumos.Rows.Count < 1)
            return false;

        //if (hdfIdProfesional.Value == "-1")
        //    return false;

        return true;
    }

    private bool TieneMedicamentosAsignados()
    {
        return gvInsumos.Rows.Count > 0;
    }

    protected void ibBorrar_Command(object sender, CommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPrescripcionDetalleCollection pds = new InsPrescripcionDetalleCollection();

        // borro en la BD la prescrip detalle
        GridViewRow row = gvInsumos.Rows[index];
        Label lblIdPrescripcionDetalle = (Label)row.FindControl("lblIdPrescripcionDetalle");
        int idPD = Convert.ToInt32(lblIdPrescripcionDetalle.Text);
        InsPrescripcionDetalle.Delete(idPD);
        // FIN borro en la BD la prescrip detalle

        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            // busco el registro a eliminar o saltear
            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
            int idIns = Convert.ToInt32(lblIdInsumo.Text);
            if (gvr.RowIndex != index)
            {
                //detalle de la prescripcion
                lblIdPrescripcionDetalle = (Label)gvr.FindControl("lblIdPrescripcionDetalle");
                int idPD2 = Convert.ToInt32(lblIdPrescripcionDetalle.Text);
                InsPrescripcionDetalle pd = new InsPrescripcionDetalle(idPD2);
                pd.IdPrescripcion = id;
                pd.Fecha = Convert.ToDateTime(txtFecha.Text);
                pd.IdInsumo = idIns;

                TextBox txtDosis = (TextBox)gvr.FindControl("txtDosis");
                CultureInfo ci = null;
                ci = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(txtDosis.Text))
                    pd.Dosis = decimal.Parse(txtDosis.Text.Replace(",", "."), ci);
                    
                else
                    txtDosis.Text = "0";
                //pd.Dosis = 0;

                DropDownList ddlUnidad = (DropDownList)gvr.FindControl("ddlUnidad");
                pd.UnidadDosis = ddlUnidad.SelectedValue;


                TextBox txtDiasTrat = (TextBox)gvr.FindControl("txtDiasTrat");
                if (!string.IsNullOrEmpty(txtDiasTrat.Text))
                    pd.DiasTratamiento = Convert.ToInt32(txtDiasTrat.Text);
                else
                    pd.DiasTratamiento = 1;

                

                if (IsTratamientoProlongado.Checked)
                {
                    pd.DiasTratamiento = 30;
                    TextBox txtCantidadSolPorMes = (TextBox)gvr.FindControl("txtCantidadSolPorMes");
                    pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSolPorMes.Text);
                }
                else
                {
                    TextBox txtCantidadSol = (TextBox)gvr.FindControl("txtCantidadSol");
                    pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSol.Text);
                }

                //TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");
                //pd.CantidadEmitida = Convert.ToInt32(txtCantidadE.Text);

                Label txtCantidadD = (Label)gvr.FindControl("txtCantidadD");
                pd.CantidadDisponible = Convert.ToInt32(txtCantidadD.Text);
                pd.Observacion = "";

                pd.Renglon = gvr.DataItemIndex + 1;
                pd.Baja = false;
                pds.Add(pd);
            }
        }
        //elimino el check de la Insulina
        //cbInsulina.Checked = false;

        Detalles = pds;
        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }    

    protected void imHistorial_Click(object sender, EventArgs e)
    {
        int idD = Convert.ToInt32(ddlDeposito.SelectedValue);
        if (idD > 0)
        {
            Response.Redirect("List.aspx?idD=" + idD);
        }
    }
    
    //protected void ddlUnidadC_SelectedIndexChanged(object sender, EventArgs e)
    //{
        //debo calcular automaticamente la proxima fecha de vencimiento
        //int cantidad = txtDuracion.Text.TryParseInt(0);

        //if (ddlUnidadC.SelectedValue == "Mensual")
            //txtProximaFecha.Text = (DateTime.Now.AddMonths(1).ToShortDateString()).ToString();
        //else
        //{if (ddlUnidadC.SelectedValue == "Días")
        //    txtProximaFecha.Text = (DateTime.Now.AddDays(txtDuracion.Text.TryParseInt(0)).ToShortDateString().ToString());
        //}

        //    if (cantidad == 30) txtDispensaciones.Text = "1";
        //    if (cantidad == 60) txtDispensaciones.Text = "2";
        //}
        //else
        //{
        //    if (ddlUnidadC.SelectedValue == "Meses")
        //    {
        //        if (cantidad == 1) txtDispensaciones.Text = "1";
        //        if (cantidad == 2) txtDispensaciones.Text = "2";
        //    }
        //}
    //}

    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        //boton que asigna el medicamento para el registro de la demanda rechazada
        int idInsumo = acInsumo.getInsumo();
        if (idInsumo > 0)
        {
            AgregarInsumo(idInsumo, true);
            lblMensajeM.Visible = false;            
        }
        else
        {
            lblMensajeM.Text = "Debe seleccionar un medicamento.";
            lblMensajeM.Visible = true;
        }
        MostrarColumnas();
    }

    private void AgregarInsumo(int idInsumo, bool esdemandarechazada)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int dep = ddlDeposito.SelectedValue.TryParseInt();
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPrescripcionDetalleCollection pds = new InsPrescripcionDetalleCollection();
        List<stockhelper> e = DalInsumos.SPs.InsGetInsumosDisponiblesGrilla(idEfector, dep, idInsumo).ExecuteTypedList<stockhelper>();

        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            //detalle del pedido
            Label lblIdPrescripcionDetalle = (Label)gvr.FindControl("lblIdPrescripcionDetalle");
            int idPD = Convert.ToInt32(lblIdPrescripcionDetalle.Text);

            InsPrescripcionDetalle pd = new InsPrescripcionDetalle(idPD);
            pd.IdPrescripcion = id;
            pd.Fecha = Convert.ToDateTime(txtFecha.Text);

            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
            pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

            TextBox txtDosis = (TextBox)gvr.FindControl("txtDosis");
            CultureInfo ci = null;
            ci = CultureInfo.InvariantCulture;
            if (!string.IsNullOrEmpty(txtDosis.Text))
                pd.Dosis = decimal.Parse(txtDosis.Text.Replace(",", "."), ci);
                //pd.Dosis = int.Parse(txtDosis.Text);
            else
                txtDosis.Text = "0";

            //pd.Dosis = 0;
            DropDownList ddlUnidad = (DropDownList)gvr.FindControl("ddlUnidad");
            pd.UnidadDosis = ddlUnidad.SelectedValue;
            pd.UnidadDosis = "0";

            if (IsTratamientoProlongado.Checked)
            {    pd.DiasTratamiento = 30;
                TextBox txtCantidadSolPorMes = (TextBox)gvr.FindControl("txtCantidadSolPorMes");
                if (!string.IsNullOrEmpty(txtCantidadSolPorMes.Text))                                    
                    pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSolPorMes.Text);
                else
                    pd.CantidadSolicitada = 0;
            }
            else
            { 
                TextBox txtDiasTrat = (TextBox)gvr.FindControl("txtDiasTrat");
                if (!string.IsNullOrEmpty(txtDiasTrat.Text))
                    pd.DiasTratamiento = Convert.ToInt32(txtDiasTrat.Text);
                else
                    pd.DiasTratamiento = 1;
            
                TextBox txtCantidadSol = (TextBox)gvr.FindControl("txtCantidadSol");
                if (!string.IsNullOrEmpty(txtCantidadSol.Text))
                    pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSol.Text);
                else
                    pd.CantidadSolicitada = 0;
                
            }
            

            //Gustavo Saraceni - Agrego la cantidad disponible
            Label txtCantidadD = (Label)gvr.FindControl("txtCantidadD");
            pd.CantidadDisponible = Convert.ToInt32(txtCantidadD.Text);

            pd.Observacion = "";

            pd.Renglon = gvr.DataItemIndex + 1;
            pd.Baja = false;
            pds.Add(pd);
        }

        InsPrescripcionDetalle pdNew = new InsPrescripcionDetalle();
        pdNew.IdPrescripcion = id;
        pdNew.Fecha = Convert.ToDateTime(txtFecha.Text);
        pdNew.IdInsumo = idInsumo;

        pdNew.Dosis = 0;
        pdNew.UnidadDosis = "0";
        pdNew.DiasTratamiento = 0;
        pdNew.CantidadDisponible = 0;
        pdNew.CantidadEmitida = 0;
        pdNew.CantidadSolicitada = 0;
        pdNew.Observacion = "";
        pdNew.Renglon = 0;

        pdNew.Observacion = txtObservaciones.Text;
        pdNew.Baja = false;

        //Gustavo Saraceni - 10/09/2015 - Calculo el stock disponible
        //*************************************************************
        int stock = 0;
        foreach (var cant in e)
            stock += cant.stock;
        pdNew.CantidadDisponible = stock;
        //*************************************************************
        pds.Add(pdNew);

        Detalles = pds;

        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    //protected void txtDiasTrat_TextChanged(object sender, EventArgs e)
    //{
    //    int idEfector = SSOHelper.CurrentIdentity.IdEfector;

    //    TextBox t = (TextBox)sender;
    //    GridViewRow gvr = (GridViewRow)t.Parent.Parent;

    //    int insumo = (Convert.ToInt32(((Label)gvr.FindControl("lblIdInsumo")).Text));

    //    Select m = new Select(new string[] { "cantidad" }).Top("1");
    //    m.From(InsDosi.Schema);
    //    m.Where(InsDosi.IdInsumoColumn).IsEqualTo(insumo);
    //    m.And(InsDosi.IdEfectorColumn).IsEqualTo(idEfector);
    //    m.OrderDesc("ModifiedOn");

    //    int dosis = m.ExecuteScalar<int>();
    //    double dosisdia = (((TextBox)gvr.FindControl("txtDosis")).Text).TryParseInt(0);
    //    int diastratamiento = (((TextBox)gvr.FindControl("txtDiasTrat")).Text).TryParseInt(0);
    //    double cantidadsolicitada = 0;

    //    if (dosis > 0)
    //    {
    //        cantidadsolicitada = (dosisdia * diastratamiento) / dosis;
    //        ((TextBox)gvr.FindControl("txtCantidadS")).Text = Math.Ceiling(cantidadsolicitada).ToString();
    //        ((TextBox)gvr.FindControl("txtCantidadE")).Text = Math.Ceiling(cantidadsolicitada).ToString();
    //    }
    //    else
    //    {
    //        cantidadsolicitada = dosisdia * diastratamiento;
    //        ((TextBox)gvr.FindControl("txtCantidadS")).Text = cantidadsolicitada.ToString();
    //        ((TextBox)gvr.FindControl("txtCantidadE")).Text = cantidadsolicitada.ToString();
    //    }
    //}

    protected void imbAsociados_Click(object sender, EventArgs e)
    {
        int idMedicamento = acInsumo.getInsumo();
        string url = "../Insumos/ConsultaAsociados.aspx?idInsumo=" + idMedicamento.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=650,height=450,scrollbars=yes,top=100, left=100');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }

    protected void lkProfesional_Click(object sender, EventArgs e)
    {
        int idProf = acProfesional.getProfesional();
        string url = "Profesional.aspx?idProf=" + idProf.ToString();
        //string url = "Profesional.aspx?idProf=" + hdfIdProfesional;
        
        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=650,height=200,scrollbars=yes,top=100, left=100');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }

    //[WebMethod]
    //public static int getValorEncontrado(int idInsumo, int idEfector)
    //{
    //    InsDosi oDosis = new Select("cantidad").Top("1")
    //    .From(InsDosi.Schema)
    //    .Where(InsDosi.IdInsumoColumn).IsEqualTo(idInsumo)
    //    .And(InsDosi.IdEfectorColumn).IsEqualTo(idEfector) /*chequear aca*/
    //    .ExecuteSingle<InsDosi>();

    //    return Convert.ToInt32(oDosis.Cantidad);
    //}

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image hlE = new Image();
            hlE = (Image)e.Row.FindControl("imgEstado");
            Label lbl = new Label();
            lbl = e.Row.FindControl("txtCantidadD") as Label;
            if (lbl.Text == "0")                        
            {
               
               hlE.ImageUrl = "../App_Themes/images/estado0.png";
               hlE.ToolTip = "No hay Stock Disponible";
             }
             else
             {
                 hlE.ImageUrl = "../App_Themes/images/estado1.png";
                 hlE.ToolTip = "Hay Stock Disponible";
             }
               
        }
        
    }
    protected void hkOtraBusqueda_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recetas/BuscarPaciente.aspx");
    }
    protected void hkCronicos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recetas/ConsultarCronicos.aspx");
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
    }
   
    protected void IsTratamientoProlongado_CheckedChanged(object sender, EventArgs e)
    {
        MostrarColumnas();
    }    
     
    protected void MostrarColumnas()
    {
        if (IsTratamientoProlongado.Checked)
        {
            upCronico.Visible = true;
            gvInsumos.Columns[9].Visible = true;
            gvInsumos.Columns[11].Visible = false;
            gvInsumos.Columns[12].Visible = true;

            //gvInsumos.Columns[7].HeaderText = "Unidades";
        }
        else
        {
            upCronico.Visible = false;
            gvInsumos.Columns[11].Visible = true;
            gvInsumos.Columns[12].Visible = false;
        }

        if(IsRemediar.Checked)
        {
            gvInsumos.Columns[6].Visible = false;
            gvInsumos.Columns[7].Visible = false;
            gvInsumos.Columns[8].Visible = false;
            gvInsumos.Columns[9].Visible = false;
            gvInsumos.Columns[10].Visible = false;                        
        }
        else
        {
            gvInsumos.Columns[6].Visible = true;  //Dosis Diaria
            gvInsumos.Columns[7].Visible = true;  //Unidad Dosis
            gvInsumos.Columns[9].Visible = true;  //dosis Medicamento
            gvInsumos.Columns[10].Visible = true;  //calcular 
            if (IsTratamientoProlongado.Checked)
            {
                gvInsumos.Columns[8].Visible = false;                                          
            }
            else
            {                
                gvInsumos.Columns[8].Visible = true;  //dias tratamiento                                
            }
        }                
    }
    protected void gvInsumos_RowCreated(object sender, GridViewRowEventArgs e)
    {
                
    }
    protected void IsRemediar_CheckedChanged(object sender, EventArgs e)
    {
        MostrarColumnas();
    }
    protected void lbCalcular_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        LinkButton t = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)t.Parent.Parent;

        int insumo = (Convert.ToInt32(((Label)gvr.FindControl("lblIdInsumo")).Text));
        int cantDisp = (Convert.ToInt32(((Label)gvr.FindControl("txtCantidadD")).Text));

        CultureInfo ci = null;
        ci = CultureInfo.InvariantCulture;
       //if (!string.IsNullOrEmpty(txtDosis.Text))

        decimal dosisDiaria = Decimal.Parse((((TextBox)gvr.FindControl("txtDosis")).Text).Replace(",", "."), ci);
        int dosisMedicamento = ((TextBox)gvr.FindControl("txtDosisMedicamento")).Text.TryParseInt(1);
             
        string unidad = (((DropDownList)gvr.FindControl("ddlUnidad")).SelectedValue);
       
        int meses = txtDuracion.Text.TryParseInt(0);
        
        int diasTrat = 1;

        if (!IsTratamientoProlongado.Checked)
        {
            diasTrat = (((TextBox)gvr.FindControl("txtDiasTrat")).Text).TryParseInt(1);
            meses = 1;
        }
        else
            diasTrat = 30;

        decimal entregar = 0;

        if (unidad == "Unidades")
        {
            
            if (dosisDiaria > 0)
            {
                entregar = Math.Ceiling(dosisDiaria * diasTrat);
                if (!IsTratamientoProlongado.Checked)
                    ((TextBox)gvr.FindControl("txtCantidadSol")).Text = entregar.ToString();
                else
                    ((TextBox)gvr.FindControl("txtCantidadSolPorMes")).Text = entregar.ToString();
                //double deuda = 0;
                //deuda = (entregar * meses) - entregar;
                //((Label)gvr.FindControl("txtDeuda")).Text = Math.Ceiling(deuda).ToString();       
            }
        }
        else
        {            
            if (dosisDiaria > 0 && dosisMedicamento > 0 && diasTrat > 0)
            {
                entregar = Math.Ceiling(dosisDiaria * diasTrat / dosisMedicamento);
                if (!IsTratamientoProlongado.Checked)
                    ((TextBox)gvr.FindControl("txtCantidadSol")).Text = entregar.ToString();
                else
                    ((TextBox)gvr.FindControl("txtCantidadSolPorMes")).Text = entregar.ToString();

                //double deuda = 0;
                //deuda = (entregar * meses) - entregar;
                //((Label)gvr.FindControl("txtDeuda")).Text = Math.Ceiling(deuda).ToString();
            }
        }
    }

    //public string llenarProfesionales()
    //{
    //    SysProfesionalCollection p = new SysProfesionalCollection();
    //    p.Load();

    //    object[] cant = new object[p.Count];
    //    int x = 0;

    //    MyJsonDictionary<String, String> result = null;

    //    foreach (SysProfesional data in p)
    //    {
    //        result = new MyJsonDictionary<String, String>();

    //        result["idProfesional"] = data.IdProfesional.ToString();
    //        result["ApellidoyNombre"] = data.ApellidoyNombre;
    //        cant[x] = result;
    //        x++;
    //    }

    //    return JsonConvert.SerializeObject(cant);
    //}
    protected void btnMedicamentosEntregados_Click(object sender, EventArgs e)
    {
        int idPaciente = Convert.ToInt32(hfIdPaciente.Value);
        string url = "MedicacionAnterior.aspx?idPaciente=" + idPaciente.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=1000,height=800,scrollbars=yes,top=80, left=80');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }
}