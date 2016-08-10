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
    /// Controller class for Insumos_Tipos_Comprobantes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsumosTiposComprobanteController
    {
        // Preload our schema..
        InsumosTiposComprobante thisSchemaLoad = new InsumosTiposComprobante();
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
        public InsumosTiposComprobanteCollection FetchAll()
        {
            InsumosTiposComprobanteCollection coll = new InsumosTiposComprobanteCollection();
            Query qry = new Query(InsumosTiposComprobante.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosTiposComprobanteCollection FetchByID(object Nombre)
        {
            InsumosTiposComprobanteCollection coll = new InsumosTiposComprobanteCollection().Where("Nombre", Nombre).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosTiposComprobanteCollection FetchByQuery(Query qry)
        {
            InsumosTiposComprobanteCollection coll = new InsumosTiposComprobanteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Nombre)
        {
            return (InsumosTiposComprobante.Delete(Nombre) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Nombre)
        {
            return (InsumosTiposComprobante.Destroy(Nombre) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre)
	    {
		    InsumosTiposComprobante item = new InsumosTiposComprobante();
		    
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Nombre)
	    {
		    InsumosTiposComprobante item = new InsumosTiposComprobante();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}