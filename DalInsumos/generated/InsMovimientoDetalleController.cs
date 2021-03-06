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
    /// Controller class for INS_MovimientoDetalle
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsMovimientoDetalleController
    {
        // Preload our schema..
        InsMovimientoDetalle thisSchemaLoad = new InsMovimientoDetalle();
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
        public InsMovimientoDetalleCollection FetchAll()
        {
            InsMovimientoDetalleCollection coll = new InsMovimientoDetalleCollection();
            Query qry = new Query(InsMovimientoDetalle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsMovimientoDetalleCollection FetchByID(object IdMovimientoDetalle)
        {
            InsMovimientoDetalleCollection coll = new InsMovimientoDetalleCollection().Where("idMovimientoDetalle", IdMovimientoDetalle).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsMovimientoDetalleCollection FetchByQuery(Query qry)
        {
            InsMovimientoDetalleCollection coll = new InsMovimientoDetalleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdMovimientoDetalle)
        {
            return (InsMovimientoDetalle.Delete(IdMovimientoDetalle) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdMovimientoDetalle)
        {
            return (InsMovimientoDetalle.Destroy(IdMovimientoDetalle) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdMovimiento,int IdPedidoDetalle,int IdPedido,int? IdInsumo,DateTime? FechaPedido,int? Cantidad,int? Presentacion,int? CantidadSolicitada,int? CantidadAutorizada,int? CantidadEmitida,int? CantidadRecibida,int? Stock,decimal? PrecioUnitario,string Observacion,int? RenglonOC,int? Renglon,string NumeroLote,DateTime? FechaVencimiento,bool? Baja,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    InsMovimientoDetalle item = new InsMovimientoDetalle();
		    
            item.IdMovimiento = IdMovimiento;
            
            item.IdPedidoDetalle = IdPedidoDetalle;
            
            item.IdPedido = IdPedido;
            
            item.IdInsumo = IdInsumo;
            
            item.FechaPedido = FechaPedido;
            
            item.Cantidad = Cantidad;
            
            item.Presentacion = Presentacion;
            
            item.CantidadSolicitada = CantidadSolicitada;
            
            item.CantidadAutorizada = CantidadAutorizada;
            
            item.CantidadEmitida = CantidadEmitida;
            
            item.CantidadRecibida = CantidadRecibida;
            
            item.Stock = Stock;
            
            item.PrecioUnitario = PrecioUnitario;
            
            item.Observacion = Observacion;
            
            item.RenglonOC = RenglonOC;
            
            item.Renglon = Renglon;
            
            item.NumeroLote = NumeroLote;
            
            item.FechaVencimiento = FechaVencimiento;
            
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
	    public void Update(int IdMovimientoDetalle,int IdMovimiento,int IdPedidoDetalle,int IdPedido,int? IdInsumo,DateTime? FechaPedido,int? Cantidad,int? Presentacion,int? CantidadSolicitada,int? CantidadAutorizada,int? CantidadEmitida,int? CantidadRecibida,int? Stock,decimal? PrecioUnitario,string Observacion,int? RenglonOC,int? Renglon,string NumeroLote,DateTime? FechaVencimiento,bool? Baja,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiedOn)
	    {
		    InsMovimientoDetalle item = new InsMovimientoDetalle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdMovimientoDetalle = IdMovimientoDetalle;
				
			item.IdMovimiento = IdMovimiento;
				
			item.IdPedidoDetalle = IdPedidoDetalle;
				
			item.IdPedido = IdPedido;
				
			item.IdInsumo = IdInsumo;
				
			item.FechaPedido = FechaPedido;
				
			item.Cantidad = Cantidad;
				
			item.Presentacion = Presentacion;
				
			item.CantidadSolicitada = CantidadSolicitada;
				
			item.CantidadAutorizada = CantidadAutorizada;
				
			item.CantidadEmitida = CantidadEmitida;
				
			item.CantidadRecibida = CantidadRecibida;
				
			item.Stock = Stock;
				
			item.PrecioUnitario = PrecioUnitario;
				
			item.Observacion = Observacion;
				
			item.RenglonOC = RenglonOC;
				
			item.Renglon = Renglon;
				
			item.NumeroLote = NumeroLote;
				
			item.FechaVencimiento = FechaVencimiento;
				
			item.Baja = Baja;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
