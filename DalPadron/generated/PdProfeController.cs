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
    /// Controller class for Pd_Profe
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdProfeController
    {
        // Preload our schema..
        PdProfe thisSchemaLoad = new PdProfe();
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
        public PdProfeCollection FetchAll()
        {
            PdProfeCollection coll = new PdProfeCollection();
            Query qry = new Query(PdProfe.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdProfeCollection FetchByID(object Id)
        {
            PdProfeCollection coll = new PdProfeCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdProfeCollection FetchByQuery(Query qry)
        {
            PdProfeCollection coll = new PdProfeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdProfeCollection FetchAllPaged(int start, int pageLength)
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
          PdProfeCollection coll = new PdProfeCollection();
          Query qry = new Query( PdProfe.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdProfe.Schema );
            return qry.GetCount( "Id" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PdProfe.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PdProfe.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int Documento,string TipoDocumento,DateTime? FechaIngreso,int? NroAfiliado)
	    {
		    PdProfe item = new PdProfe();
		    
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
	    public void Update(int Id,string Nombre,int Documento,string TipoDocumento,DateTime? FechaIngreso,int? NroAfiliado)
	    {
		    PdProfe item = new PdProfe();
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
