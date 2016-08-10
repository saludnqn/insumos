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
    /// Controller class for Pd_PUCO
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdPucoController
    {
        // Preload our schema..
        PdPuco thisSchemaLoad = new PdPuco();
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
        public PdPucoCollection FetchAll()
        {
            PdPucoCollection coll = new PdPucoCollection();
            Query qry = new Query(PdPuco.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPucoCollection FetchByID(object Id)
        {
            PdPucoCollection coll = new PdPucoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPucoCollection FetchByQuery(Query qry)
        {
            PdPucoCollection coll = new PdPucoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdPucoCollection FetchAllPaged(int start, int pageLength)
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
          PdPucoCollection coll = new PdPucoCollection();
          Query qry = new Query( PdPuco.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdPuco.Schema );
            return qry.GetCount( "Id" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PdPuco.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PdPuco.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TipoDoc,int? Dni,int? CodigoOS,string Transmite,string Nombre)
	    {
		    PdPuco item = new PdPuco();
		    
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
		    PdPuco item = new PdPuco();
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
