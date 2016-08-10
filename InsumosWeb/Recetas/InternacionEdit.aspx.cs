using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using DalInsumos;
using ExtensionMethods;
using SubSonic;
using System.Collections.Generic;
using System.Web.Services;
using Salud.Security.SSO;


[Serializable]
public class stockhelperinternacion
{
    public int idPedidoDetalle { get; set; }
    public int idInsumo { get; set; }
    public int stock { get; set; }
}

public partial class Recetas_InternacionEdit : System.Web.UI.Page
{
    private InsPrescripcionDetalleCollection Detalles
    {
        get
        {
            return ViewState["detalles"] == null ? new InsPrescripcionDetalleCollection() : (InsPrescripcionDetalleCollection)ViewState["detalles"];
        }
        set { ViewState["detalles"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        CargarCombos();
        hfIdEfector.Value = idEfector.ToString();
        upPaciente.Visible = false;
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarReceta(id);
        }
        txtFecha.Text = DateTime.Now.ToShortDateString();
    }

    private void CargarReceta(int id)
    {
        upPaciente.Visible = true;
        InsPrescripcion p = new InsPrescripcion(id);
        if (!p.IsNew)
        {
            ddlDeposito.SelectedValue = p.IdDeposito.ToString();
            txtFecha.Text = Convert.ToDateTime(p.Fecha).ToShortDateString();
            //ddlPrescripcion.SelectedValue = p.IdPrescripcion.ToString();
            //ddlTratamiento.SelectedValue = p.IdTipoTratamiento.ToString();
            txtDoc.Text = p.SysPaciente.NumeroDocumento.ToString();
            lblPaciente.Text = p.SysPaciente.Apellido + ", " + p.SysPaciente.Nombre;
            lblSexo.Text = "Sexo: " + p.SysPaciente.SysSexo.Nombre;
            hfIdPaciente.Value = p.IdPaciente.ToString();
            lblFechaNac.Text = Convert.ToDateTime(p.SysPaciente.FechaNacimiento).ToShortDateString();
            hfEdad.Value = p.Edad.ToString();
            lblEdad.Text = "Edad: " + p.Edad.ToString() + "Años";
            if (p.IdObraSocial > 0)
                lblOSocial.Text = p.SysObraSocial.Nombre;
            else lblOSocial.Text = "--";
            CodCie10.setDiagnosticoPrincipal(p.IdCODCie10.GetValueOrDefault(0));
            acProfesional.setProf(p.IdProfesional.GetValueOrDefault(0));
            txtObservaciones.Text = p.Observaciones;
            //detalle del pedido        
            SubSonic.Select pd = new Select();
            pd.From(Schemas.InsPrescripcionDetalle);
            pd.Where(InsPrescripcionDetalle.Columns.IdPrescripcion).IsEqualTo(id);

            gvInsumos.DataSource = pd.ExecuteTypedList<InsPrescripcionDetalle>();
            gvInsumos.DataBind();
        }
    }

    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);
        d.Where(InsDeposito.Columns.IdTipoDeposito).IsEqualTo(1);
        d.And(InsDeposito.NombreColumn).Like("%INTERNACION%");
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector del usuario
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();

        /* 
              SubSonic.Select t = new SubSonic.Select();
              t.From(InsTipoTratamiento.Schema);
              ddlTratamiento.DataSource = t.ExecuteTypedList<InsTipoTratamiento>();
              ddlTratamiento.DataBind();
        
        SubSonic.Select tp = new SubSonic.Select();
        tp.From(InsTipoPrescripcion.Schema);
        tp.Where(InsTipoPrescripcion.Columns.IdTipoPrescripcion).IsEqualTo(2);
        ddlPrescripcion.DataSource = tp.ExecuteTypedList<InsTipoPrescripcion>();
        ddlPrescripcion.DataBind();
         * */
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        if (txtDoc.Text.Length > 0)
        {
            //lblMensaje.Text = "El paciente no se encuentra registrado en Internación";
            lblMensaje.Text = "";
            int doc = Convert.ToInt32(txtDoc.Text);
            //chequeo pacientes internados registrados en el sips
            DataTable dt = SPs.InsPacientesInternados(idEfector, doc).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                upPaciente.Visible = true;
                lblPaciente.Text = dt.Rows[0][2].ToString();
                lblSexo.Text = "Sexo: " + dt.Rows[0][9].ToString();
                hfIdPaciente.Value = dt.Rows[0][0].ToString();
                lblFechaNac.Text = dt.Rows[0][3].ToString();
                lblOSocial.Text = dt.Rows[0][8].ToString();
                if (Convert.ToInt32(dt.Rows[0][4]) > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0][4]) > 99)
                    {
                        lblEdad.Text = "";
                        hfEdad.Value = dt.Rows[0][4].ToString();
                    }
                    else
                    {
                        lblEdad.Text = "Edad: " + dt.Rows[0][4].ToString() + " Años";
                        hfEdad.Value = dt.Rows[0][4].ToString();
                    }
                }
                else
                {
                    lblEdad.Text = "Menor a 1 Año";
                    hfEdad.Value = "0";
                }
                lblFInternacion.Text = dt.Rows[0][10].ToString() + "   Tipo de Ingreso: " + dt.Rows[0][6].ToString();
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
            }
            else
            {
                //funcion para Internacion del Castro
                //lblMensaje.Text = "No se encuentra al paciente buscado";
                if (idEfector == 205)
                {
                    lblMensaje.Text = "El paciente Empadronado en Sips";
                    upPaciente.Visible = true;
                    DataTable dp = SPs.InsGetPacientes(doc).GetDataSet().Tables[0];
                    lblPaciente.Text = dp.Rows[0][3].ToString();
                    lblSexo.Text = "Sexo: " + dp.Rows[0][9].ToString();
                    hfIdPaciente.Value = dp.Rows[0][0].ToString();
                    lblFechaNac.Text = dp.Rows[0][5].ToString();
                    lblOSocial.Text = dp.Rows[0][7].ToString();
                    if (Convert.ToInt32(dp.Rows[0][6]) > 0)
                    {
                        lblEdad.Text = "Edad: " + dp.Rows[0][6].ToString() + " Años";
                        hfEdad.Value = dp.Rows[0][6].ToString();
                    }
                } else lblMensaje.Text = "No se encuentra al paciente buscado";
            }
        }
        else
        {
            lblMensaje.Text = "El número ingresado no es válido";
            upPaciente.Visible = false;
        }
    }

    protected void btnAsignar_Click1(object sender, EventArgs e)
    {
        //boton que asigna el medicamento para el registro de la demanda rechazada
        int idInsumo = Medicamento.getInsumo();
        if (idInsumo > 0)
            AgregarInsumo(idInsumo, true);
    }

    private void AgregarInsumo(int idInsumo, bool esdemandarechazada)
    // protected void AgregarInsumo_Click(object sender, EventArgs e)
    {
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        InsPrescripcionDetalleCollection pds = new InsPrescripcionDetalleCollection();
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
            //CultureInfo ci = null;
            //ci = CultureInfo.InvariantCulture;
            if (!string.IsNullOrEmpty(txtDosis.Text))
                //pd.Dosis = decimal.Parse(txtDosis.Text.Replace(",", "."), ci);
                pd.Dosis = int.Parse(txtDosis.Text);
            else txtDosis.Text = "0";

            DropDownList ddlUnidad = (DropDownList)gvr.FindControl("ddlUnidad");
            pd.UnidadDosis = ddlUnidad.SelectedValue;

            TextBox txtDiasTrat = (TextBox)gvr.FindControl("txtDiasTrat");
            pd.DiasTratamiento = Convert.ToInt32(txtDiasTrat.Text);

            TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");
            pd.CantidadEmitida = Convert.ToInt32(txtCantidadE.Text);

            TextBox txtFrecuencia = (TextBox)gvr.FindControl("txtFrecuencia");
            pd.Frecuencia = txtFrecuencia.Text;

            TextBox txtTratamiento = (TextBox)gvr.FindControl("txtTratamiento");
            pd.Observacion = txtTratamiento.Text;

            pd.Renglon = gvr.DataItemIndex + 1;
            pd.Baja = false;
            pds.Add(pd);
        }

        InsPrescripcionDetalle pd1 = new InsPrescripcionDetalle();
        pd1.IdPrescripcion = id;
        pd1.Fecha = Convert.ToDateTime(txtFecha.Text);
        pd1.IdInsumo = idInsumo;

        pd1.Dosis = 0;
        pd1.UnidadDosis = "0";
        pd1.CantidadEmitida = 0;
        pd1.CantidadSolicitada = 0;
        pd1.Frecuencia = "";
        pd1.Observacion = "";
        pd1.Renglon = 0;

        pd1.Observacion = txtObservaciones.Text;
        pd1.Baja = false;

        pds.Add(pd1);

        Detalles = pds;

        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        //if (Page.IsValid)
        if (Page.IsValid && TieneMedicamentosAsignados() && ValidaDesdeServidor())
        {
            InsPrescripcion insp = new InsPrescripcion(id);

            insp.IdEfector = idEfector; //efector del usuario
            insp.IdDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);
            insp.IdPaciente = Convert.ToInt32(hfIdPaciente.Value);
            insp.Edad = Convert.ToInt32(hfEdad.Value);
            insp.Unidad = "Años"; // unidad de la edad
            insp.IdObraSocial = insp.SysPaciente.IdObraSocial;
            insp.IdTipoPrescripcion = 2;
            //debo tener en cuenta el tipo de tratamiento para contemplar las internaciones??
            insp.IdTipoTratamiento = 3; // Convert.ToInt32(ddlTratamiento.SelectedValue);
            insp.Duracion = 0;
            insp.UnidadDuracion = "";
            insp.NumeroDispensacion = 0;
            if (acProfesional.getProfesional() > 0)
                insp.IdProfesional = acProfesional.getProfesional();
            else
                insp.IdProfesional = -1;
            insp.Diagnostico = "";
            insp.IdCODCie10 = CodCie10.getDiagnostico();
            insp.Fecha = Convert.ToDateTime(txtFecha.Text);
            insp.Observaciones = txtObservaciones.Text;
            insp.Baja = false;
            insp.Save(username);

            InsPrescripcionDetalleCollection pds = new InsPrescripcionDetalleCollection();
            foreach (GridViewRow gvr in gvInsumos.Rows)
            {
                //detalle de la prescripcion o receta
                Label lblIdPrescripcionDetalle = (Label)gvr.FindControl("lblIdPrescripcionDetalle");
                int idPD = Convert.ToInt32(lblIdPrescripcionDetalle.Text);

                InsPrescripcionDetalle pd = new InsPrescripcionDetalle(idPD);
                pd.IdPrescripcion = insp.IdPrescripcion;

                pd.Fecha = Convert.ToDateTime(txtFecha.Text);

                Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                TextBox txtDosis = (TextBox)gvr.FindControl("txtDosis");
                //CultureInfo ci = null;
                //ci = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(txtDosis.Text))
                    //pd.Dosis = decimal.Parse(txtDosis.Text.Replace(",", "."), ci);
                    pd.Dosis = int.Parse(txtDosis.Text);
                else txtDosis.Text = "0";

                DropDownList ddlUnidad = (DropDownList)gvr.FindControl("ddlUnidad");
                pd.UnidadDosis = ddlUnidad.SelectedValue;

                TextBox txtDiasTrat = (TextBox)gvr.FindControl("txtDiasTrat");
                pd.DiasTratamiento = Convert.ToInt32(txtDiasTrat.Text);

                TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");
                pd.CantidadEmitida = Convert.ToInt32(txtCantidadE.Text);

                TextBox txtFrecuencia = (TextBox)gvr.FindControl("txtFrecuencia");
                pd.Frecuencia = txtFrecuencia.Text;

                TextBox txtTratamiento = (TextBox)gvr.FindControl("txtTratamiento");
                pd.Observacion = txtTratamiento.Text.ToString();

                pd.CantidadSolicitada = 0;

                pd.Renglon = gvr.DataItemIndex + 1;
                pd.Baja = false;

                if (pd.IdInsumo > 0)
                    pds.Add(pd);
                else
                {
                    lblMensajeM.Text = "Debe ingresar un medicamento";
                    break;
                }
            }
            pds.SaveAll(username);
            //luego de guardar descontar del stock lo emitido o dispensado
            ActualizarStock(pds);
            Response.Redirect("InternacionView.aspx?id=" + insp.IdPrescripcion.ToString());
        }
        else
        {
            lblMensajeM.Text = "Debe seleccionar algún medicamento para guardar la Prescripción!";
            string alertjs = @"<script language='javascript'> alert('Revise los datos del formulario, hay datos faltantes!'); </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
        }
    }

    private void ActualizarStock(InsPrescripcionDetalleCollection pds)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;
        //llamar a este store para descontar del medicamento mas proximo a vencer
        foreach (var item in pds)
        {
            int dep = ddlDeposito.SelectedValue.TryParseInt();
            int idInsumo = Medicamento.getInsumo();
            List<stockhelperinternacion> e = SPs.InsGetInsumosDisponiblesGrilla(idEfector, dep, idInsumo).ExecuteTypedList<stockhelperinternacion>();

            foreach (var stock in e)
            {
                SubSonic.Select q = new Select(Aggregate.Sum("cantidad"));
                q.From(InsPrescripcionEntrega.Schema);
                q.Where(InsPrescripcionEntrega.IdPrescripcionDetalleColumn).IsEqualTo(item.IdPrescripcionDetalle);

                int entregado = q.ExecuteScalar<int>();
                int paraentregar = item.CantidadEmitida.GetValueOrDefault(0) - entregado;

                if (paraentregar <= stock.stock)
                {
                    // tengo mas stock del que hay que entregar
                    InsPrescripcionEntrega pe = new InsPrescripcionEntrega();

                    pe.IdPrescripcionDetalle = item.IdPrescripcionDetalle;
                    pe.Cantidad = paraentregar;
                    pe.Fecha = DateTime.Now;
                    pe.IdPedidoDetalle = stock.idPedidoDetalle;
                    pe.IdInsumo = idInsumo;
                    pe.IdPaciente = item.InsPrescripcion.IdPaciente.GetValueOrDefault(0);

                    InsPedidoDetalle pd = new InsPedidoDetalle(stock.idPedidoDetalle);

                    pd.Stock = pd.Stock - paraentregar;
                    pd.Save(username);

                    pe.Save(username);
                    break;
                }

                if (paraentregar > stock.stock)
                {
                    InsPrescripcionEntrega pe = new InsPrescripcionEntrega();

                    pe.IdPrescripcionDetalle = item.IdPrescripcionDetalle;
                    pe.Cantidad = stock.stock;

                    pe.Fecha = DateTime.Now;
                    pe.IdPedidoDetalle = stock.idPedidoDetalle;
                    pe.IdInsumo = idInsumo;
                    pe.IdPaciente = item.InsPrescripcion.IdPaciente.GetValueOrDefault(0);

                    InsPedidoDetalle pd = new InsPedidoDetalle(stock.idPedidoDetalle);

                    pd.Stock = pd.Stock - stock.stock;
                    pd.Save(username);

                    pe.Save(username);
                }
            }
        }
    }

    private bool ValidaDesdeServidor()
    {
        if (gvInsumos.Rows.Count < 1)
            return false;

        if (CodCie10.getDiagnostico() < 1)
            return false;

        if (acProfesional.getProfesional() < 1)
            return false;

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
                //CultureInfo ci = null;
                //ci = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(txtDosis.Text)) 
                    //pd.Dosis = decimal.Parse(txtDosis.Text.Replace(",", "."), ci);
                    pd.Dosis = int.Parse(txtDosis.Text);
                else txtDosis.Text = "0";

                DropDownList ddlUnidad = (DropDownList)gvr.FindControl("ddlUnidad");
                pd.UnidadDosis = ddlUnidad.SelectedValue;

                TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");
                pd.CantidadEmitida = Convert.ToInt32(txtCantidadE.Text);

                TextBox txtFrecuencia = (TextBox)gvr.FindControl("txtFrecuencia");
                pd.Frecuencia = txtFrecuencia.Text;

                TextBox txtTratamiento = (TextBox)gvr.FindControl("txtTratamiento");
                pd.Observacion = txtTratamiento.Text.ToString();

                pd.Renglon = gvr.DataItemIndex + 1;
                pd.Baja = false;
                pds.Add(pd);
            }
        }
        //elimino el check de la Insulina
        // cbInsulina.Checked = false;

        Detalles = pds;
        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    protected void lbActualizar_Click(object sender, EventArgs e)
    {
        int idD = Convert.ToInt32(ddlDeposito.SelectedValue);
        int idI = 0; // Convert.ToInt32(ddlInsumo.SelectedValue);
        if ((idD > 0) && (idI > 0))
        {
            Response.Redirect("Stock.aspx?idD=" + idD + "&idI=" + idI);
        }
        else
        {
            Response.Redirect("Stock.aspx?idD=" + idD);
        }
    }

    protected void lbRecetas_Click(object sender, EventArgs e)
    {
        int idPaciente = Convert.ToInt32(hfIdPaciente.Value);
        string url = "MedicacionAnterior.aspx?idPaciente=" + idPaciente.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=700,height=400,scrollbars=yes,top=80, left=80');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }

    protected void imHistorial_Click(object sender, EventArgs e)
    {
        int idD = Convert.ToInt32(ddlDeposito.SelectedValue);
        if (idD > 0)
        {
            Response.Redirect("List.aspx?idD=" + idD);
        }
    }

    protected void imStock_Click(object sender, EventArgs e)
    {
        int idD = Convert.ToInt32(ddlDeposito.SelectedValue);
        if (idD > 0)
        {
            Response.Redirect("StockInterno.aspx?idD=" + idD);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx", false);
    }

    protected void txtDiasTrat_TextChanged(object sender, EventArgs e)
    {
        TextBox t = (TextBox)sender;
        GridViewRow gvr = (GridViewRow)t.Parent.Parent;

        int insumo = (Convert.ToInt32(((Label)gvr.FindControl("lblIdInsumo")).Text));

        //InsInsumo medic = new InsInsumo(insumo);
        InsDosi medic = new InsDosi(insumo);
        int dosis = Convert.ToInt32(medic.Cantidad);
        double dosisdia = (((TextBox)gvr.FindControl("txtDosis")).Text).TryParseInt(0);
        int diastratamiento = (((TextBox)gvr.FindControl("txtDiasTrat")).Text).TryParseInt(0);
        double cantidadsolicitada = 0;

        if (dosis > 0)
        {
            //if (cbInsulina.Checked)
            //    cantidadsolicitada = (dosisdia * diastratamiento) * dosis;
            //else
            cantidadsolicitada = (dosisdia * diastratamiento) / dosis;
            ((TextBox)gvr.FindControl("txtCantidadE")).Text = Math.Ceiling(cantidadsolicitada).ToString(); //Math.Round(cantidadsolicitada, 1, MidpointRounding.AwayFromZero).ToString();
        }
        else
        {
            cantidadsolicitada = dosisdia * diastratamiento;
            ((TextBox)gvr.FindControl("txtCantidadE")).Text = cantidadsolicitada.ToString();
        }
    }

    protected void lkProfesional_Click(object sender, EventArgs e)
    {
        int idProf = acProfesional.getProfesional();
        string url = "Profesional.aspx?idProf=" + idProf.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=650,height=200,scrollbars=yes,top=100, left=100');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }

    protected void imbAsociados_Click(object sender, EventArgs e)
    {
        int idMedicamento = Medicamento.getInsumo();
        string url = "../Insumos/ConsultaAsociados.aspx?idInsumo=" + idMedicamento.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=650,height=450,scrollbars=yes,top=100, left=100');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }

    [WebMethod]
    public static int getValorEncontrado(int idInsumo, int idEfector)
    {
        InsDosi oDosis = new Select("cantidad").Top("1")
        .From(InsDosi.Schema)
        .Where(InsDosi.IdInsumoColumn).IsEqualTo(idInsumo)
        .And(InsDosi.IdEfectorColumn).IsEqualTo(idEfector) /*chequear aca*/
        .ExecuteSingle<InsDosi>();

        return Convert.ToInt32(oDosis.Cantidad);
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            InsPrescripcionDetalle pd = (InsPrescripcionDetalle)e.Row.DataItem;
            if (pd.InsPrescripcionEntregaRecords.Count > 0)
            {
                ImageButton ib = (ImageButton)e.Row.FindControl("ibBorrar");
                ib.Visible = false;
            }
        }
    }
}
