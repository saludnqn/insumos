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
    /// Controller class for INS_RelInsumoEfector
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsRelInsumoEfectorController
    {
        // Preload our schema..
        InsRelInsumoEfector thisSchemaLoad = new InsRelInsumoEfector();
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
        public InsRelInsumoEfectorCollection FetchAll()
        {
            InsRelInsumoEfectorCollection coll = new InsRelInsumoEfectorCollection();
            Query qry = new Query(InsRelInsumoEfector.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsRelInsumoEfectorCollection FetchByID(object IdRelInsumoEfector)
        {
            InsRelInsumoEfectorCollection coll = new InsRelInsumoEfectorCollection().Where("idRelInsumoEfector", IdRelInsumoEfector).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsRelInsumoEfectorCollection FetchByQuery(Query qry)
        {
            InsRelInsumoEfectorCollection coll = new InsRelInsumoEfectorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdRelInsumoEfector)
        {
            return (InsRelInsumoEfector.Delete(IdRelInsumoEfector) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdRelInsumoEfector)
        {
            return (InsRelInsumoEfector.Destroy(IdRelInsumoEfector) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEfector,int? IdInsumo,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsRelInsumoEfector item = new InsRelInsumoEfector();
		    
            item.IdEfector = IdEfector;
            
            item.IdInsumo = IdInsumo;
            
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
	    public void Update(int IdRelInsumoEfector,int? IdEfector,int? IdInsumo,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsRelInsumoEfector item = new InsRelInsumoEfector();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdRelInsumoEfector = IdRelInsumoEfector;
				
			item.IdEfector = IdEfector;
				
			item.IdInsumo = IdInsumo;
				
			item.Baja = Baja;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
