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
    /// Controller class for Insumos_Consumo_Anual
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsumosConsumoAnualController
    {
        // Preload our schema..
        InsumosConsumoAnual thisSchemaLoad = new InsumosConsumoAnual();
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
        public InsumosConsumoAnualCollection FetchAll()
        {
            InsumosConsumoAnualCollection coll = new InsumosConsumoAnualCollection();
            Query qry = new Query(InsumosConsumoAnual.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosConsumoAnualCollection FetchByID(object Codigo)
        {
            InsumosConsumoAnualCollection coll = new InsumosConsumoAnualCollection().Where("Codigo", Codigo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosConsumoAnualCollection FetchByQuery(Query qry)
        {
            InsumosConsumoAnualCollection coll = new InsumosConsumoAnualCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Codigo)
        {
            return (InsumosConsumoAnual.Delete(Codigo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Codigo)
        {
            return (InsumosConsumoAnual.Destroy(Codigo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Anio,int Servicio,int Insumo,int Cantidad,int? CantidadOriginal,int PeriodoControl,bool Auditado,int? AuditadoPor,DateTime FechaActualizacion)
	    {
		    InsumosConsumoAnual item = new InsumosConsumoAnual();
		    
            item.Anio = Anio;
            
            item.Servicio = Servicio;
            
            item.Insumo = Insumo;
            
            item.Cantidad = Cantidad;
            
            item.CantidadOriginal = CantidadOriginal;
            
            item.PeriodoControl = PeriodoControl;
            
            item.Auditado = Auditado;
            
            item.AuditadoPor = AuditadoPor;
            
            item.FechaActualizacion = FechaActualizacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Codigo,int Anio,int Servicio,int Insumo,int Cantidad,int? CantidadOriginal,int PeriodoControl,bool Auditado,int? AuditadoPor,DateTime FechaActualizacion)
	    {
		    InsumosConsumoAnual item = new InsumosConsumoAnual();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Codigo = Codigo;
				
			item.Anio = Anio;
				
			item.Servicio = Servicio;
				
			item.Insumo = Insumo;
				
			item.Cantidad = Cantidad;
				
			item.CantidadOriginal = CantidadOriginal;
				
			item.PeriodoControl = PeriodoControl;
				
			item.Auditado = Auditado;
				
			item.AuditadoPor = AuditadoPor;
				
			item.FechaActualizacion = FechaActualizacion;
				
	        item.Save(UserName);
	    }
    }
}