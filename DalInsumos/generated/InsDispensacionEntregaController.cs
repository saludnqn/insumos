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
    /// Controller class for INS_DispensacionEntrega
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsDispensacionEntregaController
    {
        // Preload our schema..
        InsDispensacionEntrega thisSchemaLoad = new InsDispensacionEntrega();
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
        public InsDispensacionEntregaCollection FetchAll()
        {
            InsDispensacionEntregaCollection coll = new InsDispensacionEntregaCollection();
            Query qry = new Query(InsDispensacionEntrega.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDispensacionEntregaCollection FetchByID(object IdDispensacionEntrega)
        {
            InsDispensacionEntregaCollection coll = new InsDispensacionEntregaCollection().Where("idDispensacionEntrega", IdDispensacionEntrega).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDispensacionEntregaCollection FetchByQuery(Query qry)
        {
            InsDispensacionEntregaCollection coll = new InsDispensacionEntregaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDispensacionEntrega)
        {
            return (InsDispensacionEntrega.Delete(IdDispensacionEntrega) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDispensacionEntrega)
        {
            return (InsDispensacionEntrega.Destroy(IdDispensacionEntrega) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdDispensacionDetalle,int Cantidad,DateTime Fecha,int IdPedidoDetalle,int IdPaciente,int IdInsumo,string NumeroLote,DateTime FechaVencimiento,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDispensacionEntrega item = new InsDispensacionEntrega();
		    
            item.IdDispensacionDetalle = IdDispensacionDetalle;
            
            item.Cantidad = Cantidad;
            
            item.Fecha = Fecha;
            
            item.IdPedidoDetalle = IdPedidoDetalle;
            
            item.IdPaciente = IdPaciente;
            
            item.IdInsumo = IdInsumo;
            
            item.NumeroLote = NumeroLote;
            
            item.FechaVencimiento = FechaVencimiento;
            
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
	    public void Update(int IdDispensacionEntrega,int IdDispensacionDetalle,int Cantidad,DateTime Fecha,int IdPedidoDetalle,int IdPaciente,int IdInsumo,string NumeroLote,DateTime FechaVencimiento,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDispensacionEntrega item = new InsDispensacionEntrega();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDispensacionEntrega = IdDispensacionEntrega;
				
			item.IdDispensacionDetalle = IdDispensacionDetalle;
				
			item.Cantidad = Cantidad;
				
			item.Fecha = Fecha;
				
			item.IdPedidoDetalle = IdPedidoDetalle;
				
			item.IdPaciente = IdPaciente;
				
			item.IdInsumo = IdInsumo;
				
			item.NumeroLote = NumeroLote;
				
			item.FechaVencimiento = FechaVencimiento;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
