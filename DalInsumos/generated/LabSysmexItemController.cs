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
    /// Controller class for LAB_SysmexItem
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LabSysmexItemController
    {
        // Preload our schema..
        LabSysmexItem thisSchemaLoad = new LabSysmexItem();
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
        public LabSysmexItemCollection FetchAll()
        {
            LabSysmexItemCollection coll = new LabSysmexItemCollection();
            Query qry = new Query(LabSysmexItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSysmexItemCollection FetchByID(object IdSysmexItem)
        {
            LabSysmexItemCollection coll = new LabSysmexItemCollection().Where("idSysmexItem", IdSysmexItem).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LabSysmexItemCollection FetchByQuery(Query qry)
        {
            LabSysmexItemCollection coll = new LabSysmexItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdSysmexItem)
        {
            return (LabSysmexItem.Delete(IdSysmexItem) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdSysmexItem)
        {
            return (LabSysmexItem.Destroy(IdSysmexItem) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string IdSysmex,int IdItem,bool Habilitado,bool Redondeo)
	    {
		    LabSysmexItem item = new LabSysmexItem();
		    
            item.IdSysmex = IdSysmex;
            
            item.IdItem = IdItem;
            
            item.Habilitado = Habilitado;
            
            item.Redondeo = Redondeo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdSysmexItem,string IdSysmex,int IdItem,bool Habilitado,bool Redondeo)
	    {
		    LabSysmexItem item = new LabSysmexItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdSysmexItem = IdSysmexItem;
				
			item.IdSysmex = IdSysmex;
				
			item.IdItem = IdItem;
				
			item.Habilitado = Habilitado;
				
			item.Redondeo = Redondeo;
				
	        item.Save(UserName);
	    }
    }
}
