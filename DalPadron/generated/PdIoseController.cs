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
    /// Controller class for Pd_Iose
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdIoseController
    {
        // Preload our schema..
        PdIose thisSchemaLoad = new PdIose();
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
        public PdIoseCollection FetchAll()
        {
            PdIoseCollection coll = new PdIoseCollection();
            Query qry = new Query(PdIose.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdIoseCollection FetchByID(object Id)
        {
            PdIoseCollection coll = new PdIoseCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdIoseCollection FetchByQuery(Query qry)
        {
            PdIoseCollection coll = new PdIoseCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdIoseCollection FetchAllPaged(int start, int pageLength)
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
          PdIoseCollection coll = new PdIoseCollection();
          Query qry = new Query( PdIose.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdIose.Schema );
            return qry.GetCount( "Id" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PdIose.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PdIose.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,int Documento,string TipoDocumento,DateTime? FechaIngreso,int? NroAfiliado)
	    {
		    PdIose item = new PdIose();
		    
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
		    PdIose item = new PdIose();
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
