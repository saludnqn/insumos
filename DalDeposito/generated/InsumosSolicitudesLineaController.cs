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
    /// Controller class for Insumos_Solicitudes_Lineas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsumosSolicitudesLineaController
    {
        // Preload our schema..
        InsumosSolicitudesLinea thisSchemaLoad = new InsumosSolicitudesLinea();
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
        public InsumosSolicitudesLineaCollection FetchAll()
        {
            InsumosSolicitudesLineaCollection coll = new InsumosSolicitudesLineaCollection();
            Query qry = new Query(InsumosSolicitudesLinea.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosSolicitudesLineaCollection FetchByID(object Codigo)
        {
            InsumosSolicitudesLineaCollection coll = new InsumosSolicitudesLineaCollection().Where("Codigo", Codigo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosSolicitudesLineaCollection FetchByQuery(Query qry)
        {
            InsumosSolicitudesLineaCollection coll = new InsumosSolicitudesLineaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Codigo)
        {
            return (InsumosSolicitudesLinea.Delete(Codigo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Codigo)
        {
            return (InsumosSolicitudesLinea.Destroy(Codigo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Solicitud,int Insumo,int Cantidad,decimal? Costo)
	    {
		    InsumosSolicitudesLinea item = new InsumosSolicitudesLinea();
		    
            item.Solicitud = Solicitud;
            
            item.Insumo = Insumo;
            
            item.Cantidad = Cantidad;
            
            item.Costo = Costo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Solicitud,int Codigo,int Insumo,int Cantidad,decimal? Costo)
	    {
		    InsumosSolicitudesLinea item = new InsumosSolicitudesLinea();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Solicitud = Solicitud;
				
			item.Codigo = Codigo;
				
			item.Insumo = Insumo;
				
			item.Cantidad = Cantidad;
				
			item.Costo = Costo;
				
	        item.Save(UserName);
	    }
    }
}
