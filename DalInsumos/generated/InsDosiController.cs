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
    /// Controller class for INS_Dosis
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsDosiController
    {
        // Preload our schema..
        InsDosi thisSchemaLoad = new InsDosi();
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
        public InsDosiCollection FetchAll()
        {
            InsDosiCollection coll = new InsDosiCollection();
            Query qry = new Query(InsDosi.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDosiCollection FetchByID(object IdDosis)
        {
            InsDosiCollection coll = new InsDosiCollection().Where("idDosis", IdDosis).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDosiCollection FetchByQuery(Query qry)
        {
            InsDosiCollection coll = new InsDosiCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDosis)
        {
            return (InsDosi.Delete(IdDosis) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDosis)
        {
            return (InsDosi.Destroy(IdDosis) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdInsumo,int IdEfector,decimal Cantidad,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDosi item = new InsDosi();
		    
            item.IdInsumo = IdInsumo;
            
            item.IdEfector = IdEfector;
            
            item.Cantidad = Cantidad;
            
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
	    public void Update(int IdDosis,int IdInsumo,int IdEfector,decimal Cantidad,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDosi item = new InsDosi();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDosis = IdDosis;
				
			item.IdInsumo = IdInsumo;
				
			item.IdEfector = IdEfector;
				
			item.Cantidad = Cantidad;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
