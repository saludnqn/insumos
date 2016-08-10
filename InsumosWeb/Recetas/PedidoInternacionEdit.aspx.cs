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
using WSInternados;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Salud.Security.SSO;
using System.Configuration;


[Serializable]
public class stockhelperpedidointernacion
{
    public int idPedidoDetalle { get; set; }
    public int idInsumo { get; set; }
    public int stock { get; set; }
}

public partial class Recetas_PedidoInternacionEdit : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
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
        else
        {
            string alertjs = @"<script language='javascript'> alert('No posee Areas de Internación!'); </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
            //return;
        }
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
            acProfesional.setProf(p.IdProfesional.GetValueOrDefault(0));
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
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector del usuario
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();

        /* Debo traer el Servicio vinculado al deposito */
        int idDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);

        /*   SysServicio oServicio = new SubSonic.Select("Nombre")
              .From(SysServicio.Schema)
              .InnerJoin(InsDeposito.Schema)
              .Where(SysServicio.IdServicioColumn).IsEqualTo(idDeposito)
              .ExecuteSingle<SysServicio>(); */

        InsDeposito oDep = new InsDeposito(idDeposito);
        if (oDep.IdServicio > 0)
            lblServicio.Text = "Servicio: " + oDep.SysServicio.Nombre;
        else lblServicio.Text = "Sin Servicio Vinculado";
        //sino traer el servicio que devuelve el wservice del Castro
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        if (txtDoc.Text.Length > 0)
        {
            lblMensaje.Text = "";
            int doc = Convert.ToInt32(txtDoc.Text);

            if (idEfector.ToString() == ConfigurationManager.AppSettings["idHCastro"].ToString())// (idEfector == 745) 
            {
                btnSeleccionarPacienteInternado.Visible = true;
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
                string dni = txtDoc.Text;
                CargarMapaCama(dni);
            }
            else
            {
                //Pacientes internados con Sips
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
                    lblMensaje.Text = "El paciente no se encuentra internado";
                    upPaciente.Visible = false;
                }
            }
            //traigo los datos de recetas anteriores
            int idP = hfIdPaciente.Value.TryParseInt();
            if (RecetasCronicas(idP))
            {
                //hlCronicos.NavigateUrl = "PacienteCronico.aspx?idPaciente=" + hfIdPaciente.Value;
                hlCronicos.Visible = true;
                string internado = "si";
                hlCronicos.NavigateUrl = "PacienteCronico.aspx?idPaciente=" + hfIdPaciente.Value + "&internado=" + internado;
            }
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

            //TextBox txtFrecuencia = (TextBox)gvr.FindControl("txtFrecuencia");
            //pd.Frecuencia = txtFrecuencia.Text;
            DropDownList ddlFrecuencia = (DropDownList)gvr.FindControl("ddlFrecuencia");
            pd.Frecuencia = ddlFrecuencia.SelectedValue;

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
        pd1.Frecuencia = "0";
        pd1.Observacion = "";
        pd1.Renglon = 0;

        pd1.Baja = false;

        pds.Add(pd1);

        Detalles = pds;

        gvInsumos.DataSource = Detalles;
        gvInsumos.DataBind();
    }

    private bool RecetasCronicas(int idPaciente)
    {
        SubSonic.SqlQuery q = new SubSonic.Select()
         .From(InsPrescripcion.Schema)
         .Where(InsPrescripcion.Columns.IdPaciente).IsEqualTo(idPaciente)
         .And(InsPrescripcion.Columns.IdTipoPrescripcion).IsEqualTo(2)
         .And(InsPrescripcion.Columns.IdTipoTratamiento).IsEqualTo(3);

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
        //if (Page.IsValid)
        string dpl = SubSonic.Sugar.Web.QueryString<string>("dpl");
        if (Page.IsValid && TieneMedicamentosAsignados() && ValidaDesdeServidor())
        {
            //InsPrescripcion insp = new InsPrescripcion(id);
            InsPrescripcion insp;
            if (dpl == "si")
            {
                insp = new InsPrescripcion();
            }
            else
            {
                insp = new InsPrescripcion(id);
            }
            insp.IdEfector = idEfector; //efector del usuario
            insp.IdDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);
            insp.IdPaciente = Convert.ToInt32(hfIdPaciente.Value);
            insp.Edad = Convert.ToInt32(hfEdad.Value);
            insp.Unidad = "Años"; // unidad de la edad
            insp.IdObraSocial = insp.SysPaciente.IdObraSocial;
            insp.IdTipoPrescripcion = 2;
            //debo tener en cuenta el tipo de tratamiento para contemplar las internaciones??
            insp.IdTipoTratamiento = 3; // Convert.ToInt32(ddlTratamiento.SelectedValue);
            //generar la tabla pedidos 
            insp.Duracion = 0;
            insp.UnidadDuracion = "";
            insp.NumeroDispensacion = 0;
            if (acProfesional.getProfesional() > 0)
                insp.IdProfesional = acProfesional.getProfesional();
            else
                insp.IdProfesional = -1;
            insp.Diagnostico = "";
            insp.IdCODCie10 = 0;
            insp.Fecha = Convert.ToDateTime(txtFecha.Text);
            insp.Observaciones = "";
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

                DropDownList ddlFrecuencia = (DropDownList)gvr.FindControl("ddlFrecuencia");
                pd.Frecuencia = ddlFrecuencia.SelectedValue;

                TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");
                pd.CantidadEmitida = Convert.ToInt32(txtCantidadE.Text);

                TextBox txtTratamiento = (TextBox)gvr.FindControl("txtTratamiento");
                pd.Observacion = txtTratamiento.Text.ToString();

                pd.CantidadSolicitada = pd.CantidadEmitida;
                pd.Renglon = gvr.DataItemIndex + 1;
                pd.Baja = false;

                //genero el registro para la tabla internacionpedido
                /*InsInternacionPedido ipedido = new InsInternacionPedido();
                ipedido.IdEfector = us.IdEfector;
                ipedido.Fecha = Convert.ToDateTime(txtFecha.Text);
                ipedido.IsDeleted = false;
                ipedido.Save(us.Username);
                */
                pd.IdInternacionPedido = 0;// ipedido.IdInternacionPedido;

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
            //GeneraPedidoInternacion(pds);
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
        string username = SSOHelper.CurrentIdentity.Username;
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        //llamar a este store para descontar del medicamento mas proximo a vencer
        foreach (var item in pds)
        {
            int dep = ddlDeposito.SelectedValue.TryParseInt();
            int idInsumo = Medicamento.getInsumo();
            List<stockhelperpedidointernacion> e = SPs.InsGetInsumosDisponiblesGrilla(idEfector, dep, idInsumo).ExecuteTypedList<stockhelperpedidointernacion>();

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

    /*   private void GeneraPedidoInternacion(InsPrescripcionDetalleCollection pds)
       {
           SysUsuario us = new SysUsuario(Session["idUsuario"]);
           //llamar a este store para descontar del medicamento mas proximo a vencer
           InsInternacionPedido ipedido = new InsInternacionPedido();
           ipedido.IdEfector = us.IdEfector;
           ipedido.Fecha = Convert.ToDateTime(txtFecha.Text);
           ipedido.IsDeleted = false;

           int dep = ddlDeposito.SelectedValue.TryParseInt();
           int idInsumo = Medicamento.getInsumo();
       } */

    private bool ValidaDesdeServidor()
    {
        if (gvInsumos.Rows.Count < 1)
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

    protected void ddlFrecuencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList t = (DropDownList)sender;
        GridViewRow gvr = (GridViewRow)t.Parent.Parent;

        double dosisdia = (((TextBox)gvr.FindControl("txtDosis")).Text).TryParseInt(0);
        int horasdiastrat = (((TextBox)gvr.FindControl("txtDiasTrat")).Text).TryParseInt(0);
        int frecuencia = (((DropDownList)gvr.FindControl("ddlFrecuencia")).SelectedValue).TryParseInt(0);
        double cantidadentregada = 0;

        if ((dosisdia > 0) && (horasdiastrat == 1) && (frecuencia > 0))
        {
            cantidadentregada = (dosisdia * 24) / frecuencia;
            ((TextBox)gvr.FindControl("txtCantidadE")).Text = cantidadentregada.ToString();
        }
        else
        {
            cantidadentregada = dosisdia * horasdiastrat;
            ((TextBox)gvr.FindControl("txtCantidadE")).Text = cantidadentregada.ToString();
        }
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

    //50126205
    //12637144
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

    /*Inicio: Datos Internacion*/
    protected void lbOcultarPanel_Click(object sender, EventArgs e)
    {
        panelInternado.Visible = false;
    }

    /* protected void lbOcultarPanel1_Click(object sender, EventArgs e)
     {
         panelMapaCamas.Visible = false;
     } */

    public bool CheckValidationResult(ServicePoint sp, X509Certificate cert, WebRequest req, int problem)
    {
        return true;
    }

    private void CargarMapaCama(string dni)
    {
        if (dni != null)
        {
            int idEfector = SSOHelper.CurrentIdentity.IdEfector;
            if (idEfector == 205)
            {
                //consumiendo el WS Hcastro
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                CredentialCache cache = new CredentialCache();

                WebServices we = new WebServices();
                WSInternacion[] bc = we.BuscarInternados(dni);

                //di.DefaultView.Sort = "Pac DESC";
                gvInternado.DataSource = bc;
                gvInternado.DataBind(); //dni: 41010677  //id 986242
                // gvInternado.Sort("FechaIngreso", SortDirection.Descending);
                //PISO no lo tengo, pero las habitaciones que tiene número, el primer dígito es el piso.
                //SECTOR que tengo es el campo habitación.
            }
        }
    }

    public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }

    protected void gvInternado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //adquirir el numero de piso, sacar el primer digito del nro de cada
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCama = (Label)e.Row.FindControl("lblCama");
            Label lblPiso = (Label)e.Row.FindControl("lblPiso");
            if (lblCama.Text != "")
            {
                if (lblCama.Text.StartsWith("C"))
                {
                    string[] piso = lblCama.Text.Split(' ');
                    string letra = piso[0];
                    string nro = piso[1];
                    lblPiso.Text = "1";//nro;  
                }
                else
                {
                    string cama = lblCama.Text.Substring(0, 1); //tomo 1 letra, despues del 3er lugar               
                    lblPiso.Text = cama;
                }
            }
            else
            {
                lblPiso.Text = "";
            }
        }
    }

    protected void ibMapaCama_Click(object sender, ImageClickEventArgs e)
    {
        panelInternado.Visible = true;
    }
    /*Fin: datos internacion*/
}

/*
 <WSInternacion>
    <Id>26609</Id>
    <Historia>218133</Historia>
    <DocumentoTipo>DNI</DocumentoTipo>
    <Documento>26139171</Documento>
    <Apellido>Fonollat</Apellido>
    <Nombre>Mariela Alejandra</Nombre>
    <FechaIngreso>2010-02-23T19:00:00</FechaIngreso>
    <Servicio>Servicio de Clínica Quirúrgica</Servicio>
    <NumHabitacion>Habitación 416</NumHabitacion>
    <NumCama>Cama 1</NumCama>
  </WSInternacion>
 */