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
    /// Controller class for Pd_Paciente
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PdPacienteController
    {
        // Preload our schema..
        PdPaciente thisSchemaLoad = new PdPaciente();
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
        public PdPacienteCollection FetchAll()
        {
            PdPacienteCollection coll = new PdPacienteCollection();
            Query qry = new Query(PdPaciente.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPacienteCollection FetchByID(object IdPdPaciente)
        {
            PdPacienteCollection coll = new PdPacienteCollection().Where("id_PdPaciente", IdPdPaciente).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PdPacienteCollection FetchByQuery(Query qry)
        {
            PdPacienteCollection coll = new PdPacienteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        
    [DataObjectMethod(DataObjectMethodType.Select, false )]
        public PdPacienteCollection FetchAllPaged(int start, int pageLength)
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
          PdPacienteCollection coll = new PdPacienteCollection();
          Query qry = new Query( PdPaciente.Schema );
          qry.PageSize = pageLength;
          qry.PageIndex = startIndex;
          coll.LoadAndCloseReader( qry.ExecuteReader() );
          return coll;
    }
        public int FetchAllCount()
        {
            Query qry = new Query( PdPaciente.Schema );
            return qry.GetCount( "IdPdPaciente" );
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPdPaciente)
        {
            return (PdPaciente.Delete(IdPdPaciente) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPdPaciente)
        {
            return (PdPaciente.Destroy(IdPdPaciente) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? NumeroDocumento,string Apellido,string Nombre,int? IdSexo,DateTime? FechaNacimiento,string InformacionContacto,DateTime? FechaActualizacion)
	    {
		    PdPaciente item = new PdPaciente();
		    
            item.NumeroDocumento = NumeroDocumento;
            
            item.Apellido = Apellido;
            
            item.Nombre = Nombre;
            
            item.IdSexo = IdSexo;
            
            item.FechaNacimiento = FechaNacimiento;
            
            item.InformacionContacto = InformacionContacto;
            
            item.FechaActualizacion = FechaActualizacion;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPdPaciente,int? NumeroDocumento,string Apellido,string Nombre,int? IdSexo,DateTime? FechaNacimiento,string InformacionContacto,DateTime? FechaActualizacion)
	    {
		    PdPaciente item = new PdPaciente();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPdPaciente = IdPdPaciente;
				
			item.NumeroDocumento = NumeroDocumento;
				
			item.Apellido = Apellido;
				
			item.Nombre = Nombre;
				
			item.IdSexo = IdSexo;
				
			item.FechaNacimiento = FechaNacimiento;
				
			item.InformacionContacto = InformacionContacto;
				
			item.FechaActualizacion = FechaActualizacion;
				
	        item.Save(UserName);
	    }
    }
}
