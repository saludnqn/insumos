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
using System.Linq;

[Serializable]
public class stockhelper
{
    public int idPedidoDetalle { get; set; }
    public int idInsumo { get; set; }
    public int stock { get; set; }
}


public partial class Dispensaciones_New : System.Web.UI.Page
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


    private DataTable dtDetalleLotes; //tabla para los lotes
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        //txtDoc.Focus();
        hfIdEfector.Value = idEfector.ToString();
        
        int doc = SubSonic.Sugar.Web.QueryString<int>("numeroDocumento");
        if (doc > 0)
        {
            txtDoc.Text = doc.ToString();
        }
        CargarCombos();
        InicializarTablaDetalleLotes();
        lblMensajeM.Text = "";
        
        //el id de la receta es para tomar los datos de origen de la dispensación
        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        if (id > 0)
        {
            CargarDispensacion(id);
        }
        txtFecha.Text = DateTime.Now.ToShortDateString();
    }

    private void CargarDispensacion(int id)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int dep = ddlDeposito.SelectedValue.TryParseInt();

        //tomo los datos a partir de la prescripción
        InsPrescripcion p = new InsPrescripcion(id);        
        
        txtFecha.Text = DateTime.Now.ToShortDateString();

        if (p.IdTipoPrescripcion == 2)
            IsRemediar.Checked = true;
        if (p.IdTipoTratamiento == 2)
            IsTratamientoProlongado.Checked = true;

        txtDoc.Text = p.SysPaciente.NumeroDocumento.ToString();
        lblPaciente.Text = p.SysPaciente.Apellido + ", " + p.SysPaciente.Nombre;
        lblSexo.Text = p.SysPaciente.SysSexo.Nombre;
        hfIdPaciente.Value = p.IdPaciente.ToString();
        lblFechaNac.Text = Convert.ToDateTime(p.SysPaciente.FechaNacimiento).ToShortDateString();
        hfEdad.Value = p.Edad.ToString();
        lblEdad.Text = p.Edad.ToString();
        if (p.IdObraSocial > 0)
            lblOSocial.Text = p.SysObraSocial.Nombre;
        else lblOSocial.Text = "--";
        //CodCie10.setDiagnosticoPrincipal(p.IdCODCie10.GetValueOrDefault(0));

        hdfCie10.Value = p.IdCODCie10.ToString();
        if (p.IdCODCie10 != -1)            
            lblDiagnostico.Text = p.SysCIE10.Codigo.ToString() + " - " + p.SysCIE10.Nombre;        

        //acProfesional.setProf(p.IdProfesional.GetValueOrDefault(0));
        hdfProfesional.Value = p.IdProfesional.ToString();
        if (p.IdProfesional != -1)                   
            lblProfesional.Text = p.SysProfesional.ApellidoyNombre;        

        txtDuracion.Text = p.Duracion.ToString();
        txtObservaciones.Text = p.Observaciones;

        //cargo la grilla de insumos a partir de los datos de la receta
        gvInsumos.DataSource = p.InsPrescripcionDetalleRecords;
        gvInsumos.DataBind();

        if (p.IdTipoPrescripcion == 1)  //receta AMBULATORIA
        {
            //gvInsumos.Columns[6].Visible = false;
            gvInsumos.Columns[7].Visible = false;
            gvInsumos.Columns[8].Visible = true;
            gvInsumos.Columns[9].Visible = true;
            
            gvInsumos.Columns[11].Visible = false;
            gvInsumos.Columns[12].Visible = false;
            gvInsumos.Columns[13].Visible = false;

            if (p.IdTipoTratamiento == 1)  //Ambulatorio            
            {
                //gvInsumos.Columns[6].Visible = true;                
                gvInsumos.Columns[10].Visible = true;
            }
            else if (p.IdTipoTratamiento == 2)
            {
                upCronico.Visible = true;
                //gvInsumos.Columns[7].Visible = true;
            }
        }
        else if (p.IdTipoPrescripcion==2)
        {
            if (p.IdTipoTratamiento == 2)
            {
                upCronico.Visible = true;
                gvInsumos.Columns[7].Visible = true;
            }
            //else if (p.IdTipoTratamiento == 1)
            //    gvInsumos.Columns[6].Visible = true;
        }
            
          
        //recorro toda la grilla y actulizo las catidades disponibles
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");            
            int idInsumo = Convert.ToInt32(lblIdInsumo.Text);
            List<stockhelper> e = DalInsumos.SPs.InsGetInsumosDisponiblesGrilla(idEfector, dep, idInsumo).ExecuteTypedList<stockhelper>();
            int stock = 0;
            foreach (var cant in e)
                stock += cant.stock;

            ((Label)gvr.FindControl("txtCantidadD")).Text = stock.ToString();
           
            // ((TextBox)gvr.FindControl("txtDeuda")).Text = "0";            
            //if (IsTratamientoProlongado.Checked == false)
            //{
            //   ((TextBox)gvr.FindControl("txtCantidadE")).Text = ((Label)gvr.FindControl("txtCantidadSol")).Text;                
            //}
            //else
            //{
            //    ((TextBox)gvr.FindControl("txtCantidadE")).Text = ((Label)gvr.FindControl("txtCantidadSolxMes")).Text;                
            //}
        }
    }

    
    private void CargarCombos()
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        SubSonic.Select d = new SubSonic.Select();
        d.From(InsDeposito.Schema);        
        d.Where(InsDeposito.Columns.Selected).IsEqualTo(1); //deposito por defecto: farmacia
        d.And(InsDeposito.Columns.Baja).IsEqualTo(0);
        d.And(InsDeposito.Columns.IdEfector).IsEqualTo(idEfector); //efector del usuario

        d.OrderAsc("Nombre");
        ddlDeposito.DataSource = d.ExecuteTypedList<InsDeposito>();
        ddlDeposito.DataBind();

        //SubSonic.Select t = new SubSonic.Select();
        //t.From(InsTipoTratamiento.Schema);
        //ddlTratamiento.DataSource = t.ExecuteTypedList<InsTipoTratamiento>();
        //ddlTratamiento.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        
    }

    private bool RecetasCronicas(int idPaciente)
    {
        SubSonic.SqlQuery q = new SubSonic.Select()
         .From(InsPrescripcion.Schema)
         .Where(InsPrescripcion.Columns.IdPaciente).IsEqualTo(idPaciente)
         .And(InsPrescripcion.Columns.IdTipoTratamiento).IsEqualTo(2);

        DataTable dtd = q.ExecuteDataSet().Tables[0];
        if (dtd.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        if (TieneLotesAsignados())
        {                                                                        
            //if (HayStockDisponible())
            //{
                if (NoSuperaLoAdeudado())
                {
                    string username = SSOHelper.CurrentIdentity.Username;
                    int idEfector = SSOHelper.CurrentIdentity.IdEfector;

                    int id = SubSonic.Sugar.Web.QueryString<int>("id");

                    if (TieneMedicamentosAsignados() && ValidaDesdeServidor())
                    {
                        bool cerrarReceta = true;
                        //Nueva Dispensación
                        InsDispensacion d = new InsDispensacion();

                        d.IdEfector = idEfector;
                        d.IdPrescripcion = id;
                        d.IdDeposito = Convert.ToInt32(ddlDeposito.SelectedValue);
                        d.IdPaciente = Convert.ToInt32(hfIdPaciente.Value);
                        d.Edad = Convert.ToInt32(hfEdad.Value);
                        d.Unidad = "Años"; // unidad de la edad
                        d.IdObraSocial = d.SysPaciente.IdObraSocial;

                        if (IsRemediar.Checked)
                            d.IdTipoPrescripcion = 2;   //RECETA REMEDIAR
                        else
                            d.IdTipoPrescripcion = 1;

                        if (IsTratamientoProlongado.Checked)
                        {
                            d.IdTipoTratamiento = 2;  //Prolongado
                            d.UnidadDuracion = "Meses";
                        }
                        else
                        {
                            d.IdTipoTratamiento = 1;  //Ambulatorio
                            d.UnidadDuracion = "Dias";
                        }


                        d.Duracion = Convert.ToInt32(txtDuracion.Text);


                        d.IdProfesional = int.Parse(hdfProfesional.Value);
                        
                        d.Diagnostico = "";


                        d.IdCODCie10 = int.Parse(hdfCie10.Value);
                        
                        d.Fecha = Convert.ToDateTime(txtFecha.Text);
                        d.Observaciones = txtObservaciones.Text;
                        d.Baja = false;
                        d.Save(username);

                        // Nuevo Pedido (Out)
                        InsPedido p = new InsPedido();
                        p.IdEfector = d.IdEfector;
                        p.IdEfectorProveedor = d.IdEfector;
                        p.IdDeposito = d.IdDeposito;
                        p.IdDepositoProveedor = d.IdDeposito;
                        p.Fecha = d.Fecha;
                        p.FechaRecepcion = d.Fecha;
                        p.IdTipoPedido = getTipoPedido(d.IdTipoPrescripcion.Value);
                        p.IdEstadoPedido = 5; //Finalizado
                        p.IdRubro = 1;  //
                        p.Observaciones = txtDoc.Text + " - " + lblPaciente.Text;
                        p.Responsable = username;
                        p.Autorizado = true;
                        
                        //busco el id del proveedor
                        SubSonic.Select q = new Select("idProveedor");
                        q.From(InsProveedor.Schema);
                        q.Where(InsProveedor.Columns.Codigo).IsEqualTo(idEfector);
                        int idPro = q.ExecuteScalar<int>();
                        p.IdProveedor = idPro;
                        p.IdTipoComprobante = 0; //Ninguno                       
                        p.Estado = true;
                        p.Baja = false;
                        p.Save(username);


                        //********** Nuevo Movimiento *****************
                        InsMovimiento m = new InsMovimiento();
                        m.IdEfector = d.IdEfector;
                        m.IdEfectorProveedor = d.IdEfector;
                        m.IdDeposito = d.IdDeposito;
                        m.IdDepositoProveedor = d.IdDeposito;
                        m.Fecha = d.Fecha;
                        m.FechaRecepcion = d.Fecha;
                        m.IdTipoPedido = p.IdTipoPedido;
                        m.IdTipoComprobante = 0; //Ninguno
                        m.IdRubro = 1;  //
                        m.IdEstadoPedido = 5; //Finalizado
                        m.IdProveedor = 0;
                        m.Observaciones = txtDoc.Text + " - " + lblPaciente.Text;
                        m.Responsable = username;
                        m.Autorizado = true;
                        m.Estado = true;
                        m.Baja = false;
                        m.Save(username);

                        
                        InsDispensacionDetalleCollection dds = new InsDispensacionDetalleCollection();
                        InsPedidoDetalleCollection pds = new InsPedidoDetalleCollection();
                        InsMovimientoDetalleCollection mds = new InsMovimientoDetalleCollection();

                        InsPrescripcion pres = new InsPrescripcion(id);

                        foreach (GridViewRow gvr in gvInsumos.Rows)
                        {
                            InsDispensacionDetalle dd = new InsDispensacionDetalle();                            

                            Label lblIdPrescripcionDetalle = (Label)gvr.FindControl("lblIdPrescripcionDetalle");
                            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
                            TextBox txtDosis = (TextBox)gvr.FindControl("txtDosis"); //Paso 1
                            DropDownList ddlUnidad = (DropDownList)gvr.FindControl("ddlUnidad"); //paso 2
                            Label txtCantidadD = (Label)gvr.FindControl("txtCantidadD");
                            TextBox txtCantidadSol = (TextBox)gvr.FindControl("txtCantidadSol");
                            //((TextBox)gvr.FindControl("txtCantidadE")).Text = cantAsignada.ToString();
                            //TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");


                            GridView gvLotes = (GridView)gvr.FindControl("gvLotes");
                            int cantAsignada = 0;
                            foreach (GridViewRow gvrStock in gvLotes.Rows)
                            {
                                //Modificación 
                                InsPedidoDetalle pd = new InsPedidoDetalle();
                                InsMovimientoDetalle md = new InsMovimientoDetalle();
                                
                                Label presentacion = (Label)gvrStock.FindControl("lblPresentacionNum");
                                Label lote = (Label)gvrStock.FindControl("lblLote");
                                Label vto = (Label)gvrStock.FindControl("lblVencimiento");
                                TextBox cantA = (TextBox)gvrStock.FindControl("txtCantAsignada");

                                if (int.Parse(cantA.Text) > 0)
                                {
                                    pd.IdPedido = p.IdPedido;
                                    pd.FechaPedido = Convert.ToDateTime(txtFecha.Text);
                                    pd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);
                                    pd.Presentacion = Convert.ToInt32(presentacion.Text);
                                    pd.NumeroLote = lote.Text;
                                    pd.FechaVencimiento = Convert.ToDateTime(vto.Text);
                                    pd.Cantidad = 0;
                                    pd.CantidadSolicitada = int.Parse(cantA.Text);
                                    pd.CantidadEmitida = int.Parse(cantA.Text);
                                    pd.CantidadAutorizada = int.Parse(cantA.Text);
                                    pd.CantidadRecibida = int.Parse(cantA.Text);
                                    pd.Observacion = "";
                                    pd.Renglon = gvr.DataItemIndex + 1;
                                    pd.Stock = 0;
                                    pd.Baja = false;

                                    md.IdMovimiento = m.IdMovimiento;
                                    md.FechaPedido = Convert.ToDateTime(txtFecha.Text);
                                    md.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);
                                    md.Presentacion = Convert.ToInt32(presentacion.Text);
                                    md.NumeroLote = lote.Text;
                                    md.FechaVencimiento = Convert.ToDateTime(vto.Text);
                                    md.Cantidad = 0;
                                    md.CantidadSolicitada = int.Parse(cantA.Text);
                                    md.CantidadEmitida = int.Parse(cantA.Text);
                                    md.CantidadAutorizada = int.Parse(cantA.Text);
                                    md.CantidadRecibida = int.Parse(cantA.Text);
                                    md.Observacion = "";
                                    md.Renglon = gvr.DataItemIndex + 1;
                                    md.Stock = 0;
                                    md.Baja = false;

                                    pds.Add(pd);
                                    mds.Add(md);

                                    cantAsignada += (cantA.Text).TryParseInt();
                                }
                            }

                            dd.IdDispensacion = d.IdDispensacion;
                            dd.Fecha = Convert.ToDateTime(txtFecha.Text);
                            dd.IdInsumo = Convert.ToInt32(lblIdInsumo.Text);

                            CultureInfo ci = null;
                            ci = CultureInfo.InvariantCulture;
                            if (!string.IsNullOrEmpty(txtDosis.Text))
                                dd.Dosis = decimal.Parse(txtDosis.Text.Replace(",", "."), ci);
                                //dd.Dosis = int.Parse(txtDosis.Text);
                            else
                                dd.Dosis = 0;
                            dd.UnidadDosis = ddlUnidad.SelectedValue;
                            dd.DiasTratamiento = 0;
                            dd.CantidadDisponible = Convert.ToInt32(txtCantidadD.Text);
                            dd.CantidadSolicitada = Convert.ToInt32(txtCantidadSol.Text);
                            dd.CantidadEmitida = Convert.ToInt32(cantAsignada);
                            dd.Observacion = "";
                            dd.Frecuencia = "";
                            dd.Renglon = gvr.DataItemIndex + 1;
                            dd.IdInternacionPedido = 0;
                            dd.Baja = false;

                            //Aca actualizo la deuda sobre la receta misma
                            Label lblIdInsumoDispensa = (Label)gvr.FindControl("lblIdInsumo");
                            int insumo = Convert.ToInt32(lblIdInsumoDispensa.Text);
                            int PrescDetalle = Buscar_PrescripcionDetalle(id, insumo);
                            
                            InsPrescripcionDetalle presD = new InsPrescripcionDetalle(PrescDetalle);
                            presD.Deuda -= dd.CantidadEmitida.Value;
                            if (presD.Deuda < 0)
                                presD.Deuda = 0;
                            presD.Save(username);

                            if (presD.Deuda != 0)
                                cerrarReceta = false;

                            //if (cantAsignada < dd.CantidadSolicitada)
                                dd.Deuda = presD.Deuda;//dd.CantidadSolicitada.Value - dd.CantidadEmitida.Value;
                            //else
                            //    dd.Deuda = 0;

                            if (dd.IdInsumo > 0)
                               dds.Add(dd);
                            else
                            {

                                lblMensajeM.Text = "Debe ingresar un medicamento";
                                break;
                            }
                        }

                        dds.SaveAll(username);
                        pds.SaveAll(username);
                        mds.SaveAll(username);
                        ActualizarStockPedidoDetalle(dds);  //de real stock se actualiza acá                                                           
                        
                        //Controlo si se entrego todo. (Si no adeudo nada cierro las dispensaciones)
                        if(cerrarReceta == true)
                        {
                            InsPrescripcion pr = new InsPrescripcion(id);
                            pr.RecetaVencida = true;
                            pr.Save(username);
                        }

                        Response.Redirect("../Dispensaciones/View.aspx?id=" + d.IdDispensacion.ToString());                        
                    }
                    else
                    {
                        string alertjs = @"<script language='javascript'> alert('Revise los datos del formulario, hay datos faltantes.'); </script>";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
                    }
                }
                //else
                //{
                //    string alertjs = @"<script language='javascript'> alert('Una de las cantidades asignadas es superior a la cantidad adeudada.'); </script>";
                //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
                //}
            //}
            //else
            //{
            //    string alertjs = @"<script language='javascript'> alert('No hay stock suficiente para uno de los insumos seleccionados.'); </script>";
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
            //}
        }

        else
        {
            string alertjs = @"<script language='javascript'> alert('Faltan asignar cantidades en algún/os insumos.'); </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
        }     
    }

    private int Buscar_PrescripcionDetalle(int p, int insumo)
    {        
        SubSonic.Select q = new Select("idPrescripcionDetalle");
        q.From(InsPrescripcionDetalle.Schema);
        q.Where(InsPrescripcionDetalle.IdPrescripcionColumn).IsEqualTo(p);
        q.And(InsPrescripcionDetalle.IdInsumoColumn).IsEqualTo(insumo);
        int pd = q.ExecuteScalar<int>();
        return pd;

    }
    private void ActualizarStockPedidoDetalle(InsDispensacionDetalleCollection dds)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        string username = SSOHelper.CurrentIdentity.Username;
        int dep = ddlDeposito.SelectedValue.TryParseInt();

        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            GridView gvLotes = (GridView)gvr.FindControl("gvLotes");
            bool StockActualizado = false;

            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
            hfIdInsumo.Value = lblIdInsumo.Text;

            foreach (var item in dds)
            {
                if (item.IdInsumo == hfIdInsumo.Value.TryParseInt())
                {
                    foreach (GridViewRow gvrStock in gvLotes.Rows)
                    {
                        TextBox cantA = (TextBox)gvrStock.FindControl("txtCantAsignada");
                        if (cantA.Text != "0")                            
                        {
                            int cantAsignada = (cantA.Text).TryParseInt();
                            HiddenField hfIdPedidoDetalle = (HiddenField)gvrStock.FindControl("hfIdPedidoDetalle");  //Acá tomo el idPedidoDetalle del lote seleccionado a descontar stock                                

                            InsPedidoDetalle pedidoD = new InsPedidoDetalle(hfIdPedidoDetalle.Value);
                            InsDispensacionEntrega de = new InsDispensacionEntrega();

                            de.IdDispensacionDetalle = item.IdDispensacionDetalle;
                            de.Fecha = DateTime.Now;
                            de.IdPedidoDetalle = pedidoD.IdPedidoDetalle;
                            de.IdInsumo = pedidoD.IdInsumo;
                            de.IdPaciente = hfIdPaciente.Value.TryParseInt();                            
                            de.NumeroLote = pedidoD.NumeroLote;
                            de.FechaVencimiento = pedidoD.FechaVencimiento;

                            if (cantAsignada <= pedidoD.Stock)    //si la cantidad a entregar es menor o igual que el stock disponible
                            {
                                de.Cantidad = cantAsignada;
                                pedidoD.Stock -= cantAsignada;  //actualizo el stock del lote                                
                            }
                            else
                            {
                                string alertjs = @"<script language='javascript'> alert('Las cantidades asignadas no pueden ser superior al lote seleccionado.'); </script>";
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);                                                                
                            }
                            pedidoD.Save(username);
                            de.Save(username);

                            StockActualizado = true;                           
                        }
                    } //foreach (GridViewRow gvrStock in gvLotes.Rows)                   

                    if (StockActualizado == false) //si entra acá es que no hay ningún lote seleccionado
                    {
                        string alertjs = @"<script language='javascript'> alert('Falta asignar cantidades a los lotes de uno de los insumos.'); </script>";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
                                              
                    } 
                } //else

            }  //foreach (var item in dds)                                                                         
        } // foreach (GridViewRow gvr in gvInsumos.Rows)              
    }
    private bool ValidaDesdeServidor()
    {
        if (Convert.ToInt32(ddlDeposito.SelectedValue) < 1)
            return false;

        if (gvInsumos.Rows.Count < 1)
            return false;

        return true;
    }

    private bool TieneLotesAsignados()
    {
        bool asignado = false;
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            asignado = false;

            Label cantDisponible = (Label)gvr.FindControl("txtCantidadD");
            if (cantDisponible != null)
            {
                GridView gvLotes = (GridView)gvr.FindControl("gvLotes");
                foreach (GridViewRow gvrStock in gvLotes.Rows)
                {
                    TextBox cantA = (TextBox)gvrStock.FindControl("txtCantAsignada");
                    if (cantA.Text != "0")
                        if (cantA.Text != "")
                            asignado = true;
                }
                if (!asignado)
                    return false;
            }
        }
        return true;
    }

    private bool NoSuperaLoAdeudado()
    {        
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            int Total = 0;
            Label cant = (Label)gvr.FindControl("txtDeuda");        
            int cantAdeudada = Convert.ToInt32(cant.Text);
            
            if (cantAdeudada != 0)
            {
                GridView gvLotes = (GridView)gvr.FindControl("gvLotes");
                foreach (GridViewRow gvrStock in gvLotes.Rows)
                {
                    TextBox cantA = (TextBox)gvrStock.FindControl("txtCantAsignada");
                    Total += int.Parse(cantA.Text);
                }
                if (Total > cantAdeudada)
                {
                    string alertjs = @"<script language='javascript'> alert('ATENCION: Ud. está entregando más insumos que los adeudados.'); </script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
                }                    
            }
            //else return false;
        }
        return true;
    }
    private bool HayStockDisponible()
    {
        int Total = 0;
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            Label cantDisponible = (Label)gvr.FindControl("txtCantidadD");
            if (cantDisponible != null)
            {
                GridView gvLotes = (GridView)gvr.FindControl("gvLotes");
                
                foreach (GridViewRow gvrStock in gvLotes.Rows)
                {
                    TextBox cantA = (TextBox)gvrStock.FindControl("txtCantAsignada");
                    Total += int.Parse(cantA.Text);
                }
                
                if (((cantDisponible.Text).TryParseInt()) < Total)
                    return false;
            }
            else return false;
        }
        return true;        
    }
    private bool TieneMedicamentosAsignados()
    {
        return gvInsumos.Rows.Count > 0;
    }

    private void InicializarTablaDetalleLotes()
        {
            ///Inicializa las sesiones para las tablas de diagnosticos y de determinaciones
            if (Session["Tabla1"] != null) Session["Tabla1"] = null;

            dtDetalleLotes = new DataTable();

            DataColumn col = new DataColumn("id", typeof(int));
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 1;
            dtDetalleLotes.Columns.Add(col);
            dtDetalleLotes.Columns.Add("idPedidoDetalle", typeof(int));
            dtDetalleLotes.Columns.Add("idInsumo", typeof(int));            
            dtDetalleLotes.Columns.Add("Presentacion");
            dtDetalleLotes.Columns.Add("PresentacionNum", typeof(int));
            dtDetalleLotes.Columns.Add("numeroLote");
            dtDetalleLotes.Columns.Add("fechaVencimiento");
            dtDetalleLotes.Columns.Add("stock", typeof(int));
            dtDetalleLotes.Columns.Add("cantidad", typeof(int));
            
            Session.Add("Tabla1", dtDetalleLotes);

            //gvLotes.DataSource = dtDetalleLotes;
            //gvLotes.DataBind();
            //gvLotes.UpdateAfterCallBack = true;
        }
    
    private void LeerDatos()
    {
        int efector = SSOHelper.CurrentIdentity.IdEfector;
        int dep = ddlDeposito.SelectedValue.TryParseInt();

        dtDetalleLotes = (System.Data.DataTable)(Session["Tabla1"]);
        DataTable dt = DalInsumos.SPs.InsGetInsumosDisponiblesGrilla(efector, dep, Convert.ToInt32(hfIdInsumo.Value)).GetDataSet().Tables[0]; 
        DataColumn col = new DataColumn("id", typeof(int));
        col.AutoIncrement = true;
        col.AutoIncrementSeed = 1;
        col.AutoIncrementStep = 1;
        dt.Columns.Add(col);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["id"] = i + 1;
        }

        dtDetalleLotes = dt;
        Session.Add("Tabla1", dtDetalleLotes);
    }

    protected void ibBorrar_Command(object sender, CommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        int id = SubSonic.Sugar.Web.QueryString<int>("id");
        
        InsPrescripcionDetalleCollection pds = new InsPrescripcionDetalleCollection();
        
        GridViewRow row = gvInsumos.Rows[index];
        Label lblIdPrescripcionDetalle = (Label)row.FindControl("lblIdPrescripcionDetalle");
        int idDD = Convert.ToInt32(lblIdPrescripcionDetalle.Text);
        //InsDispensacionDetalle.Delete(idDD);        

        //busco el insumo a sacar de la grilla
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            // busco el registro a eliminar o saltear
            Label lblIdInsumo = (Label)gvr.FindControl("lblIdInsumo");
            int idIns = Convert.ToInt32(lblIdInsumo.Text);
            if (gvr.RowIndex != index)
            {
                //detalle de la Dispensacion
                lblIdPrescripcionDetalle = (Label)gvr.FindControl("lblIdPrescripcionDetalle");
                int idDD1 = Convert.ToInt32(lblIdPrescripcionDetalle.Text);
                InsPrescripcionDetalle pd = new InsPrescripcionDetalle(idDD1);
                pd.IdPrescripcion = id;
                pd.Fecha = Convert.ToDateTime(txtFecha.Text);
                pd.IdInsumo = idIns;

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

                //TextBox txtDias = (TextBox)gvr.FindControl("txtDias");
                pd.DiasTratamiento = 0; //Convert.ToInt32(txtDias.Text);

                TextBox txtCantidadSol = (TextBox)gvr.FindControl("txtCantidadSol");
                pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSol.Text);

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

    protected void ddlTratamiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlTratamiento.SelectedValue == "2")
        //{
        //    upCronico.Visible = true;
        //}
        //else
        //{
        //    upCronico.Visible = false;
        //}
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

    protected void btnAsignar_Click1(object sender, EventArgs e)
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
    }

    private void AgregarInsumo(int idInsumo, bool esdemandarechazada)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;
        int dep = ddlDeposito.SelectedValue.TryParseInt();
        int id = SubSonic.Sugar.Web.QueryString<int>("id");

        InsPrescripcionDetalleCollection pds = new InsPrescripcionDetalleCollection();
        List<stockhelper> e = DalInsumos.SPs.InsGetInsumosDisponiblesGrilla(idEfector, dep, idInsumo).ExecuteTypedList<stockhelper>();

        if (e.Count==0)
        {
            string alertjs = @"<script language='javascript'> alert('Insumo Sin Stock Disponible'); </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);
        }
        else
        {
            
            foreach (GridViewRow gvr in gvInsumos.Rows)
            {
                
                //detalle del pedido
                //Label lblIdDispensacionDetalle = (Label)gvr.FindControl("lblIdDispensacionDetalle");
                //int idPD = Convert.ToInt32(lblIdDispensacionDetalle.Text);
                
                
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

                //TextBox txtDias = (TextBox)gvr.FindControl("txtDias");
                //pd.DiasTratamiento = Convert.ToInt32(txtDias.Text);
                pd.DiasTratamiento = 0;

                TextBox txtCantidadSol = (TextBox)gvr.FindControl("txtCantidadSol");
                pd.CantidadSolicitada = Convert.ToInt32(txtCantidadSol.Text);

                //TextBox txtCantidadE = (TextBox)gvr.FindControl("txtCantidadE");
                //pd.CantidadEmitida = Convert.ToInt32(txtCantidadE.Text);

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
    }
    
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
        
        //MostrarColumnas();
    }
    protected void imbAsociados_Click(object sender, EventArgs e)
    {
        int idMedicamento = acInsumo.getInsumo();
        string url = "../Insumos/ConsultaAsociados.aspx?idInsumo=" + idMedicamento.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=650,height=450,scrollbars=yes,top=100, left=100');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }

    protected void lkProfesional_Click(object sender, EventArgs e)
    {
        int idProf = int.Parse(hdfProfesional.Value);
        string url = "Profesional.aspx?idProf=" + idProf.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=650,height=200,scrollbars=yes,top=100, left=100');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }

    [WebMethod]
    public static int getTipoPedido(int idTipoPresc)
    {
        Select tp = new Select("idTipoPedido").Top("1");
        tp.From(InsTipoPrescripcion.Schema);
        tp.Where(InsTipoPrescripcion.IdTipoPrescripcionColumn).IsEqualTo(idTipoPresc);
        int tipoPedido = tp.ExecuteScalar<int>();
        return (tipoPedido);
    }

    protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            gvInsumos.Columns[11].ItemStyle.BackColor = System.Drawing.Color.Gray;
            gvInsumos.Columns[12].ItemStyle.BackColor = System.Drawing.Color.Gray;
            gvInsumos.Columns[13].ItemStyle.BackColor = System.Drawing.Color.Gray;
            gvInsumos.Columns[13].ItemStyle.ForeColor = System.Drawing.Color.White;
            InsPrescripcionDetalle pd = (InsPrescripcionDetalle)e.Row.DataItem;
            //   if (pd.InsDispensacionEntregaRecords.Count > 0)
            //   {
            //ImageButton ib = (ImageButton)e.Row.FindControl("ibBorrar");
            //ib.Visible = false;  

            int efector = SSOHelper.CurrentIdentity.IdEfector;
            int dep = ddlDeposito.SelectedValue.TryParseInt();
                        
            //bindeo la segunda grilla
            Label lblIdInsumo = (Label)e.Row.FindControl("lblIdInsumo");
            hfIdInsumo.Value = lblIdInsumo.Text;

            GridView gvLotes = (GridView)e.Row.FindControl("gvLotes");
            //solo los insumo con stock
            gvLotes.AutoGenerateColumns = false;
            //LeerDatos();
            DataTable di = DalInsumos.SPs.InsGetInsumosDisponiblesGrilla(efector, dep, Convert.ToInt32(hfIdInsumo.Value)).GetDataSet().Tables[0];
            gvLotes.DataSource = di;
            gvLotes.DataBind();
        }
        
    }
    protected void lbCalcular_Click(object sender, EventArgs e)
    {
        int idEfector = SSOHelper.CurrentIdentity.IdEfector;

        LinkButton t = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)t.Parent.Parent;

        int insumo = (Convert.ToInt32(((Label)gvr.FindControl("lblIdInsumo")).Text));
        int cantDisp = (Convert.ToInt32(((Label)gvr.FindControl("txtCantidadD")).Text));
        double dosisDiaria = (((TextBox)gvr.FindControl("txtDosis")).Text).TryParseDouble();        
        double dosisMedicamento = (((TextBox)gvr.FindControl("txtDosisMedicamento")).Text).TryParseDouble();
        string unidad = (((DropDownList)gvr.FindControl("ddlUnidad")).SelectedValue);
       
        int meses = txtDuracion.Text.TryParseInt(0);
        
        int diasTrat = 1;

        if (!IsTratamientoProlongado.Checked)
        {
            diasTrat = (((TextBox)gvr.FindControl("txtDias")).Text).TryParseInt(0);
            meses = 1;
        }
        else
            diasTrat = 30;                 

        if(unidad=="Unidades")
        {
            double entregar = 0;
            if (dosisDiaria > 0)
            {
                entregar = Math.Ceiling(dosisDiaria * diasTrat);
                ((TextBox)gvr.FindControl("txtCantidadE")).Text = entregar.ToString();
                //double deuda = 0;
                //deuda = (entregar * meses) - entregar;
                //((Label)gvr.FindControl("txtDeuda")).Text = Math.Ceiling(deuda).ToString();       
            }        
        }
        else
        {
            double entregar = 0;
            if (dosisDiaria > 0 && dosisMedicamento > 0 && diasTrat > 0)
            {
                entregar = Math.Ceiling(dosisDiaria * diasTrat / dosisMedicamento);
                ((TextBox)gvr.FindControl("txtCantidadE")).Text = entregar.ToString();
                
                //double deuda = 0;
                //deuda = (entregar * meses) - entregar;
                //((Label)gvr.FindControl("txtDeuda")).Text = Math.Ceiling(deuda).ToString();
            }            
        }


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
    //   {
    //        cantidadsolicitada = dosisdia * diastratamiento;
    //        ((TextBox)gvr.FindControl("txtCantidadS")).Text = cantidadsolicitada.ToString();
    //        ((TextBox)gvr.FindControl("txtCantidadE")).Text = cantidadsolicitada.ToString();
    //    }

       
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/farmacia/default.aspx");
    }
    protected void txtCantidadE_TextChanged(object sender, EventArgs e)
    {
       
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
    //   {
    //        cantidadsolicitada = dosisdia * diastratamiento;
    //        ((TextBox)gvr.FindControl("txtCantidadS")).Text = cantidadsolicitada.ToString();
    //        ((TextBox)gvr.FindControl("txtCantidadE")).Text = cantidadsolicitada.ToString();
    //    }
    //}
    protected void txtCantAsignada_TextChanged(object sender, EventArgs e)
    {                                
        foreach (GridViewRow gvr in gvInsumos.Rows)
        {
            GridView gvLotes = (GridView)gvr.FindControl("gvLotes");
            int cantAsignada = 0;
            foreach (GridViewRow gvrStock in gvLotes.Rows)
            { 
                TextBox cantA = (TextBox)gvrStock.FindControl("txtCantAsignada");
                Label stock = (Label)gvrStock.FindControl("lblStock");
                if (int.Parse(cantA.Text) > int.Parse(stock.Text))
                {
                    string alertjs = @"<script language='javascript'> alert('La cantidad ingresada no puede ser superior a la del lote.'); </script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", alertjs);                    
                }
                else
                cantAsignada += (cantA.Text).TryParseInt();
            }

            ((TextBox)gvr.FindControl("txtCantidadE")).Text = cantAsignada.ToString();
        }       
    }

    protected void btnMedicamentosEntregados_Click(object sender, EventArgs e)
    {
        int idPaciente = Convert.ToInt32(hfIdPaciente.Value);
        string url = "MedicacionAnterior.aspx?idPaciente=" + idPaciente.ToString();

        string js = "<script language=JavaScript>window.open('" + url + "','_blank','width=1000,height=800,scrollbars=yes,top=80, left=80');</script>";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", js);
    }
}