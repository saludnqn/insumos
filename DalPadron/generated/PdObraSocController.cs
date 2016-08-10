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
    /// Controller class for Pd_ObraSoc
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdObraSocController
    {
        // Preload our schema..
        PdObraSoc thisSchemaLoad = new PdObraSoc();
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
        public PdObraSocCollection FetchAll()
        {
            PdObraSocCollection coll = new PdObraSocCollection();
            Query qry = new Query(PdObraSoc.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdObraSocCollection FetchByID(object Id)
        {
            PdObraSocCollection coll = new PdObraSocCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdObraSocCollection FetchByQuery(Query qry)
        {
            PdObraSocCollection coll = new PdObraSocCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdObraSocCollection FetchAllPaged(int start, int pageLength)
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
          PdObraSocCollection coll = new PdObraSocCollection();
          Query qry = new Query( PdObraSoc.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdObraSoc.Schema );
            return qry.GetCount( "Id" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PdObraSoc.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PdObraSoc.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int Documento,string TipoDocumento,DateTime? FechaIngreso,int? NroAfiliado,int? IdObraSocial)
	    {
		    PdObraSoc item = new PdObraSoc();
		    
            item.Nombre = Nombre;
            
            item.Documento = Documento;
            
            item.TipoDocumento = TipoDocumento;
            
            item.FechaIngreso = FechaIngreso;
            
            item.NroAfiliado = NroAfiliado;
            
            item.IdObraSocial = IdObraSocial;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre,int Documento,string TipoDocumento,DateTime? FechaIngreso,int? NroAfiliado,int? IdObraSocial)
	    {
		    PdObraSoc item = new PdObraSoc();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
			item.Documento = Documento;
				
			item.TipoDocumento = TipoDocumento;
				
			item.FechaIngreso = FechaIngreso;
				
			item.NroAfiliado = NroAfiliado;
				
			item.IdObraSocial = IdObraSocial;
				
	        item.Save(UserName);
	    }
    }
}
