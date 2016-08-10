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
    /// Controller class for Pd_PamiC
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdPamiCController
    {
        // Preload our schema..
        PdPamiC thisSchemaLoad = new PdPamiC();
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
        public PdPamiCCollection FetchAll()
        {
            PdPamiCCollection coll = new PdPamiCCollection();
            Query qry = new Query(PdPamiC.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPamiCCollection FetchByID(object Id)
        {
            PdPamiCCollection coll = new PdPamiCCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPamiCCollection FetchByQuery(Query qry)
        {
            PdPamiCCollection coll = new PdPamiCCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdPamiCCollection FetchAllPaged(int start, int pageLength)
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
          PdPamiCCollection coll = new PdPamiCCollection();
          Query qry = new Query( PdPamiC.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdPamiC.Schema );
            return qry.GetCount( "Id" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PdPamiC.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PdPamiC.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int Documento,string TipoDocumento,DateTime? FechaIngreso,long? NroAfiliado)
	    {
		    PdPamiC item = new PdPamiC();
		    
            item.Nombre = Nombre;
            
            item.Documento = Documento;
            
            item.TipoDocumento = TipoDocumento;
            
            item.FechaIngreso = FechaIngreso;
            
            item.NroAfiliado = NroAfiliado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre,int Documento,string TipoDocumento,DateTime? FechaIngreso,long? NroAfiliado)
	    {
		    PdPamiC item = new PdPamiC();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
			item.Documento = Documento;
				
			item.TipoDocumento = TipoDocumento;
				
			item.FechaIngreso = FechaIngreso;
				
			item.NroAfiliado = NroAfiliado;
				
	        item.Save(UserName);
	    }
    }
}
