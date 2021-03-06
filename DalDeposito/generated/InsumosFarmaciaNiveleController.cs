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
    /// Controller class for Insumos_Farmacia_Niveles
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsumosFarmaciaNiveleController
    {
        // Preload our schema..
        InsumosFarmaciaNivele thisSchemaLoad = new InsumosFarmaciaNivele();
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
        public InsumosFarmaciaNiveleCollection FetchAll()
        {
            InsumosFarmaciaNiveleCollection coll = new InsumosFarmaciaNiveleCollection();
            Query qry = new Query(InsumosFarmaciaNivele.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosFarmaciaNiveleCollection FetchByID(object Nivel)
        {
            InsumosFarmaciaNiveleCollection coll = new InsumosFarmaciaNiveleCollection().Where("Nivel", Nivel).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosFarmaciaNiveleCollection FetchByQuery(Query qry)
        {
            InsumosFarmaciaNiveleCollection coll = new InsumosFarmaciaNiveleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Nivel)
        {
            return (InsumosFarmaciaNivele.Delete(Nivel) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Nivel)
        {
            return (InsumosFarmaciaNivele.Destroy(Nivel) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nivel)
	    {
		    InsumosFarmaciaNivele item = new InsumosFarmaciaNivele();
		    
            item.Nivel = Nivel;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string Nivel)
	    {
		    InsumosFarmaciaNivele item = new InsumosFarmaciaNivele();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Nivel = Nivel;
				
	        item.Save(UserName);
	    }
    }
}
