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
    /// Controller class for INS_Dispensacion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsDispensacionController
    {
        // Preload our schema..
        InsDispensacion thisSchemaLoad = new InsDispensacion();
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
        public InsDispensacionCollection FetchAll()
        {
            InsDispensacionCollection coll = new InsDispensacionCollection();
            Query qry = new Query(InsDispensacion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDispensacionCollection FetchByID(object IdDispensacion)
        {
            InsDispensacionCollection coll = new InsDispensacionCollection().Where("idDispensacion", IdDispensacion).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsDispensacionCollection FetchByQuery(Query qry)
        {
            InsDispensacionCollection coll = new InsDispensacionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdDispensacion)
        {
            return (InsDispensacion.Delete(IdDispensacion) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdDispensacion)
        {
            return (InsDispensacion.Destroy(IdDispensacion) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdEfector,int? IdPrescripcion,int? IdDeposito,int? IdPaciente,int? Edad,string Unidad,int? IdTipoPrescripcion,int? IdObraSocial,int? IdProfesional,string Diagnostico,int? IdCODCie10,DateTime? Fecha,string Observaciones,int? IdTipoTratamiento,int? Duracion,string UnidadDuracion,DateTime? ProximaFecha,int? NumeroDispensacion,bool RecetaVencida,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDispensacion item = new InsDispensacion();
		    
            item.IdEfector = IdEfector;
            
            item.IdPrescripcion = IdPrescripcion;
            
            item.IdDeposito = IdDeposito;
            
            item.IdPaciente = IdPaciente;
            
            item.Edad = Edad;
            
            item.Unidad = Unidad;
            
            item.IdTipoPrescripcion = IdTipoPrescripcion;
            
            item.IdObraSocial = IdObraSocial;
            
            item.IdProfesional = IdProfesional;
            
            item.Diagnostico = Diagnostico;
            
            item.IdCODCie10 = IdCODCie10;
            
            item.Fecha = Fecha;
            
            item.Observaciones = Observaciones;
            
            item.IdTipoTratamiento = IdTipoTratamiento;
            
            item.Duracion = Duracion;
            
            item.UnidadDuracion = UnidadDuracion;
            
            item.ProximaFecha = ProximaFecha;
            
            item.NumeroDispensacion = NumeroDispensacion;
            
            item.RecetaVencida = RecetaVencida;
            
            item.Baja = Baja;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdDispensacion,int? IdEfector,int? IdPrescripcion,int? IdDeposito,int? IdPaciente,int? Edad,string Unidad,int? IdTipoPrescripcion,int? IdObraSocial,int? IdProfesional,string Diagnostico,int? IdCODCie10,DateTime? Fecha,string Observaciones,int? IdTipoTratamiento,int? Duracion,string UnidadDuracion,DateTime? ProximaFecha,int? NumeroDispensacion,bool RecetaVencida,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsDispensacion item = new InsDispensacion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdDispensacion = IdDispensacion;
				
			item.IdEfector = IdEfector;
				
			item.IdPrescripcion = IdPrescripcion;
				
			item.IdDeposito = IdDeposito;
				
			item.IdPaciente = IdPaciente;
				
			item.Edad = Edad;
				
			item.Unidad = Unidad;
				
			item.IdTipoPrescripcion = IdTipoPrescripcion;
				
			item.IdObraSocial = IdObraSocial;
				
			item.IdProfesional = IdProfesional;
				
			item.Diagnostico = Diagnostico;
				
			item.IdCODCie10 = IdCODCie10;
				
			item.Fecha = Fecha;
				
			item.Observaciones = Observaciones;
				
			item.IdTipoTratamiento = IdTipoTratamiento;
				
			item.Duracion = Duracion;
				
			item.UnidadDuracion = UnidadDuracion;
				
			item.ProximaFecha = ProximaFecha;
				
			item.NumeroDispensacion = NumeroDispensacion;
				
			item.RecetaVencida = RecetaVencida;
				
			item.Baja = Baja;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
