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
    /// Controller class for INS_DepositoZona
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsDepositoZonaController
    {
        // Preload our schema..
        InsDepositoZona thisSchemaLoad = new InsDepositoZona();
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
        public InsDepositoZonaCollection FetchAll()
        {
            InsDepositoZonaCollection coll = new InsDepositoZonaCollection();
            Query qry = new Query(InsDepositoZona.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDepositoZonaCollection FetchByID(object IdDepositoZona)
        {
            InsDepositoZonaCollection coll = new InsDepositoZonaCollection().Where("idDepositoZona", IdDepositoZona).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDepositoZonaCollection FetchByQuery(Query qry)
        {
            InsDepositoZonaCollection coll = new InsDepositoZonaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDepositoZona)
        {
            return (InsDepositoZona.Delete(IdDepositoZona) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDepositoZona)
        {
            return (InsDepositoZona.Destroy(IdDepositoZona) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int IdDepositoZona,int IdEfector,int IdEfectorDepositoZona,string IpDepositoZona,string UrlDepositoZona,int? IdEfectorSistemaIntegrado,string Nombre)
	    {
		    InsDepositoZona item = new InsDepositoZona();
		    
            item.IdDepositoZona = IdDepositoZona;
            
            item.IdEfector = IdEfector;
            
            item.IdEfectorDepositoZona = IdEfectorDepositoZona;
            
            item.IpDepositoZona = IpDepositoZona;
            
            item.UrlDepositoZona = UrlDepositoZona;
            
            item.IdEfectorSistemaIntegrado = IdEfectorSistemaIntegrado;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDepositoZona,int IdEfector,int IdEfectorDepositoZona,string IpDepositoZona,string UrlDepositoZona,int? IdEfectorSistemaIntegrado,string Nombre)
	    {
		    InsDepositoZona item = new InsDepositoZona();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDepositoZona = IdDepositoZona;
				
			item.IdEfector = IdEfector;
				
			item.IdEfectorDepositoZona = IdEfectorDepositoZona;
				
			item.IpDepositoZona = IpDepositoZona;
				
			item.UrlDepositoZona = UrlDepositoZona;
				
			item.IdEfectorSistemaIntegrado = IdEfectorSistemaIntegrado;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
