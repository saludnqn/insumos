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
    /// Controller class for LAB_PhoresysItem
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabPhoresysItemController
    {
        // Preload our schema..
        LabPhoresysItem thisSchemaLoad = new LabPhoresysItem();
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
        public LabPhoresysItemCollection FetchAll()
        {
            LabPhoresysItemCollection coll = new LabPhoresysItemCollection();
            Query qry = new Query(LabPhoresysItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabPhoresysItemCollection FetchByID(object IdPhoresysItem)
        {
            LabPhoresysItemCollection coll = new LabPhoresysItemCollection().Where("idPhoresysItem", IdPhoresysItem).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabPhoresysItemCollection FetchByQuery(Query qry)
        {
            LabPhoresysItemCollection coll = new LabPhoresysItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPhoresysItem)
        {
            return (LabPhoresysItem.Delete(IdPhoresysItem) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPhoresysItem)
        {
            return (LabPhoresysItem.Destroy(IdPhoresysItem) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string IdPhoresys,int IdItem,bool Habilitado)
	    {
		    LabPhoresysItem item = new LabPhoresysItem();
		    
            item.IdPhoresys = IdPhoresys;
            
            item.IdItem = IdItem;
            
            item.Habilitado = Habilitado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPhoresysItem,string IdPhoresys,int IdItem,bool Habilitado)
	    {
		    LabPhoresysItem item = new LabPhoresysItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPhoresysItem = IdPhoresysItem;
				
			item.IdPhoresys = IdPhoresys;
				
			item.IdItem = IdItem;
				
			item.Habilitado = Habilitado;
				
	        item.Save(UserName);
	    }
    }
}