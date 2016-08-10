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
namespace DalPadron
{
    /// <summary>
    /// Controller class for Pd_PUCOAgosto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdPUCOAgostoController
    {
        // Preload our schema..
        PdPUCOAgosto thisSchemaLoad = new PdPUCOAgosto();
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
        public PdPUCOAgostoCollection FetchAll()
        {
            PdPUCOAgostoCollection coll = new PdPUCOAgostoCollection();
            Query qry = new Query(PdPUCOAgosto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPUCOAgostoCollection FetchByID(object Id)
        {
            PdPUCOAgostoCollection coll = new PdPUCOAgostoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPUCOAgostoCollection FetchByQuery(Query qry)
        {
            PdPUCOAgostoCollection coll = new PdPUCOAgostoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdPUCOAgostoCollection FetchAllPaged(int start, int pageLength)
        {
           int startIndex;
           if(start ==0)
           {
               startIndex = 1;
           }
           else
           {
              startIndex = start / pageLength;
          }
          PdPUCOAgostoCollection coll = new PdPUCOAgostoCollection();
          Query qry = new Query( PdPUCOAgosto.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdPUCOAgosto.Schema );
            return qry.GetCount( "Id" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PdPUCOAgosto.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PdPUCOAgosto.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TipoDoc,int? Dni,int? CodigoOS,string Transmite,string Nombre)
	    {
		    PdPUCOAgosto item = new PdPUCOAgosto();
		    
            item.TipoDoc = TipoDoc;
            
            item.Dni = Dni;
            
            item.CodigoOS = CodigoOS;
            
            item.Transmite = Transmite;
            
            item.Nombre = Nombre;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string TipoDoc,int? Dni,int? CodigoOS,string Transmite,string Nombre)
	    {
		    PdPUCOAgosto item = new PdPUCOAgosto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.TipoDoc = TipoDoc;
				
			item.Dni = Dni;
				
			item.CodigoOS = CodigoOS;
				
			item.Transmite = Transmite;
				
			item.Nombre = Nombre;
				
	        item.Save(UserName);
	    }
    }
}
