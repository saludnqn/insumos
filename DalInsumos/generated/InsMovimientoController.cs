using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace DalInsumos
{
    /// <summary>
    /// Controller class for INS_Movimiento
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsMovimientoController
    {
        // Preload our schema..
        InsMovimiento thisSchemaLoad = new InsMovimiento();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public InsMovimientoCollection FetchAll()
        {
            InsMovimientoCollection coll = new InsMovimientoCollection();
            Query qry = new Query(InsMovimiento.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsMovimientoCollection FetchByID(object IdMovimiento)
        {
            InsMovimientoCollection coll = new InsMovimientoCollection().Where("idMovimiento", IdMovimiento).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsMovimientoCollection FetchByQuery(Query qry)
        {
            InsMovimientoCollection coll = new InsMovimientoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMovimiento)
        {
            return (InsMovimiento.Delete(IdMovimiento) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMovimiento)
        {
            return (InsMovimiento.Destroy(IdMovimiento) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdPedido,int? IdEfector,int? IdEfectorProveedor,int? IdDeposito,int? IdDepositoProveedor,DateTime? Fecha,DateTime? FechaRecepcion,int? IdTipoPedido,int? IdEstadoPedido,int? IdRubro,string Observaciones,string Responsable,bool? Autorizado,int? IdProveedor,int? IdTipoComprobante,string NumeroComprobante,string OrdenCompra,bool? Estado,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsMovimiento item = new InsMovimiento();
		    
            item.IdPedido = IdPedido;
            
            item.IdEfector = IdEfector;
            
            item.IdEfectorProveedor = IdEfectorProveedor;
            
            item.IdDeposito = IdDeposito;
            
            item.IdDepositoProveedor = IdDepositoProveedor;
            
            item.Fecha = Fecha;
            
            item.FechaRecepcion = FechaRecepcion;
            
            item.IdTipoPedido = IdTipoPedido;
            
            item.IdEstadoPedido = IdEstadoPedido;
            
            item.IdRubro = IdRubro;
            
            item.Observaciones = Observaciones;
            
            item.Responsable = Responsable;
            
            item.Autorizado = Autorizado;
            
            item.IdProveedor = IdProveedor;
            
            item.IdTipoComprobante = IdTipoComprobante;
            
            item.NumeroComprobante = NumeroComprobante;
            
            item.OrdenCompra = OrdenCompra;
            
            item.Estado = Estado;
            
            item.Baja = Baja;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdMovimiento,int IdPedido,int? IdEfector,int? IdEfectorProveedor,int? IdDeposito,int? IdDepositoProveedor,DateTime? Fecha,DateTime? FechaRecepcion,int? IdTipoPedido,int? IdEstadoPedido,int? IdRubro,string Observaciones,string Responsable,bool? Autorizado,int? IdProveedor,int? IdTipoComprobante,string NumeroComprobante,string OrdenCompra,bool? Estado,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsMovimiento item = new InsMovimiento();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMovimiento = IdMovimiento;
				
			item.IdPedido = IdPedido;
				
			item.IdEfector = IdEfector;
				
			item.IdEfectorProveedor = IdEfectorProveedor;
				
			item.IdDeposito = IdDeposito;
				
			item.IdDepositoProveedor = IdDepositoProveedor;
				
			item.Fecha = Fecha;
				
			item.FechaRecepcion = FechaRecepcion;
				
			item.IdTipoPedido = IdTipoPedido;
				
			item.IdEstadoPedido = IdEstadoPedido;
				
			item.IdRubro = IdRubro;
				
			item.Observaciones = Observaciones;
				
			item.Responsable = Responsable;
				
			item.Autorizado = Autorizado;
				
			item.IdProveedor = IdProveedor;
				
			item.IdTipoComprobante = IdTipoComprobante;
				
			item.NumeroComprobante = NumeroComprobante;
				
			item.OrdenCompra = OrdenCompra;
				
			item.Estado = Estado;
				
			item.Baja = Baja;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
