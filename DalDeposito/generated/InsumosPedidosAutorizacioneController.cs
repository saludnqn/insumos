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
namespace DalDeposito
{
    /// <summary>
    /// Controller class for Insumos_Pedidos_Autorizaciones
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsumosPedidosAutorizacioneController
    {
        // Preload our schema..
        InsumosPedidosAutorizacione thisSchemaLoad = new InsumosPedidosAutorizacione();
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
        public InsumosPedidosAutorizacioneCollection FetchAll()
        {
            InsumosPedidosAutorizacioneCollection coll = new InsumosPedidosAutorizacioneCollection();
            Query qry = new Query(InsumosPedidosAutorizacione.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosPedidosAutorizacioneCollection FetchByID(object Codigo)
        {
            InsumosPedidosAutorizacioneCollection coll = new InsumosPedidosAutorizacioneCollection().Where("Codigo", Codigo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosPedidosAutorizacioneCollection FetchByQuery(Query qry)
        {
            InsumosPedidosAutorizacioneCollection coll = new InsumosPedidosAutorizacioneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Codigo)
        {
            return (InsumosPedidosAutorizacione.Delete(Codigo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Codigo)
        {
            return (InsumosPedidosAutorizacione.Destroy(Codigo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Pedido,DateTime? Fecha,int Insumo,int Cantidad,int? Estado,DateTime? FechaAutorizacion,int? Autoridad,int? NuevoPedido,string Observaciones,bool Denegada)
	    {
		    InsumosPedidosAutorizacione item = new InsumosPedidosAutorizacione();
		    
            item.Pedido = Pedido;
            
            item.Fecha = Fecha;
            
            item.Insumo = Insumo;
            
            item.Cantidad = Cantidad;
            
            item.Estado = Estado;
            
            item.FechaAutorizacion = FechaAutorizacion;
            
            item.Autoridad = Autoridad;
            
            item.NuevoPedido = NuevoPedido;
            
            item.Observaciones = Observaciones;
            
            item.Denegada = Denegada;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Pedido,int Codigo,DateTime? Fecha,int Insumo,int Cantidad,int? Estado,DateTime? FechaAutorizacion,int? Autoridad,int? NuevoPedido,string Observaciones,bool Denegada)
	    {
		    InsumosPedidosAutorizacione item = new InsumosPedidosAutorizacione();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Pedido = Pedido;
				
			item.Codigo = Codigo;
				
			item.Fecha = Fecha;
				
			item.Insumo = Insumo;
				
			item.Cantidad = Cantidad;
				
			item.Estado = Estado;
				
			item.FechaAutorizacion = FechaAutorizacion;
				
			item.Autoridad = Autoridad;
				
			item.NuevoPedido = NuevoPedido;
				
			item.Observaciones = Observaciones;
				
			item.Denegada = Denegada;
				
	        item.Save(UserName);
	    }
    }
}
