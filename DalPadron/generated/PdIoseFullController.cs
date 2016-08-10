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
    /// Controller class for Pd_Iose_Full
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdIoseFullController
    {
        // Preload our schema..
        PdIoseFull thisSchemaLoad = new PdIoseFull();
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
        public PdIoseFullCollection FetchAll()
        {
            PdIoseFullCollection coll = new PdIoseFullCollection();
            Query qry = new Query(PdIoseFull.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdIoseFullCollection FetchByID(object Id)
        {
            PdIoseFullCollection coll = new PdIoseFullCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdIoseFullCollection FetchByQuery(Query qry)
        {
            PdIoseFullCollection coll = new PdIoseFullCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdIoseFullCollection FetchAllPaged(int start, int pageLength)
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
          PdIoseFullCollection coll = new PdIoseFullCollection();
          Query qry = new Query( PdIoseFull.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdIoseFull.Schema );
            return qry.GetCount( "Id" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PdIoseFull.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PdIoseFull.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Documento,string TipoDocumento,string Apellido,string Nombre,DateTime? FechaNacimiento,string Sexo,string Afiliado,string Nucleo,string Localidad,string Provincia,string NombreCompleto,string NroAfiliado)
	    {
		    PdIoseFull item = new PdIoseFull();
		    
            item.Documento = Documento;
            
            item.TipoDocumento = TipoDocumento;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.Sexo = Sexo;
            
            item.Afiliado = Afiliado;
            
            item.Nucleo = Nucleo;
            
            item.Localidad = Localidad;
            
            item.Provincia = Provincia;
            
            item.NombreCompleto = NombreCompleto;
            
            item.NroAfiliado = NroAfiliado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int Documento,string TipoDocumento,string Apellido,string Nombre,DateTime? FechaNacimiento,string Sexo,string Afiliado,string Nucleo,string Localidad,string Provincia,string NombreCompleto,string NroAfiliado)
	    {
		    PdIoseFull item = new PdIoseFull();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Documento = Documento;
				
			item.TipoDocumento = TipoDocumento;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.Sexo = Sexo;
				
			item.Afiliado = Afiliado;
				
			item.Nucleo = Nucleo;
				
			item.Localidad = Localidad;
				
			item.Provincia = Provincia;
				
			item.NombreCompleto = NombreCompleto;
				
			item.NroAfiliado = NroAfiliado;
				
	        item.Save(UserName);
	    }
    }
}
