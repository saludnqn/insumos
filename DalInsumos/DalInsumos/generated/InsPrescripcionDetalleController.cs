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
    /// Controller class for INS_PrescripcionDetalle
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsPrescripcionDetalleController
    {
        // Preload our schema..
        InsPrescripcionDetalle thisSchemaLoad = new InsPrescripcionDetalle();
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
        public InsPrescripcionDetalleCollection FetchAll()
        {
            InsPrescripcionDetalleCollection coll = new InsPrescripcionDetalleCollection();
            Query qry = new Query(InsPrescripcionDetalle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsPrescripcionDetalleCollection FetchByID(object IdPrescripcionDetalle)
        {
            InsPrescripcionDetalleCollection coll = new InsPrescripcionDetalleCollection().Where("idPrescripcionDetalle", IdPrescripcionDetalle).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsPrescripcionDetalleCollection FetchByQuery(Query qry)
        {
            InsPrescripcionDetalleCollection coll = new InsPrescripcionDetalleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdPrescripcionDetalle)
        {
            return (InsPrescripcionDetalle.Delete(IdPrescripcionDetalle) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdPrescripcionDetalle)
        {
            return (InsPrescripcionDetalle.Destroy(IdPrescripcionDetalle) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? IdPrescripcion,int? IdInsumo,DateTime? Fecha,int? Renglon,string UnidadDosis,int? DiasTratamiento,int? CantidadSolicitada,int? CantidadEmitida,string Frecuencia,string Observacion,bool Baja,int IdInternacionPedido,int? IdMotivoRechazo,string ObservacionRechazo,int IdDosis,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int? CantidadDisponible,int Deuda,int CantidadSolicitadaTotal,decimal Dosis)
	    {
		    InsPrescripcionDetalle item = new InsPrescripcionDetalle();
		    
            item.IdPrescripcion = IdPrescripcion;
            
            item.IdInsumo = IdInsumo;
            
            item.Fecha = Fecha;
            
            item.Renglon = Renglon;
            
            item.UnidadDosis = UnidadDosis;
            
            item.DiasTratamiento = DiasTratamiento;
            
            item.CantidadSolicitada = CantidadSolicitada;
            
            item.CantidadEmitida = CantidadEmitida;
            
            item.Frecuencia = Frecuencia;
            
            item.Observacion = Observacion;
            
            item.Baja = Baja;
            
            item.IdInternacionPedido = IdInternacionPedido;
            
            item.IdMotivoRechazo = IdMotivoRechazo;
            
            item.ObservacionRechazo = ObservacionRechazo;
            
            item.IdDosis = IdDosis;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiedOn = ModifiedOn;
            
            item.CantidadDisponible = CantidadDisponible;
            
            item.Deuda = Deuda;
            
            item.CantidadSolicitadaTotal = CantidadSolicitadaTotal;
            
            item.Dosis = Dosis;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdPrescripcionDetalle,int? IdPrescripcion,int? IdInsumo,DateTime? Fecha,int? Renglon,string UnidadDosis,int? DiasTratamiento,int? CantidadSolicitada,int? CantidadEmitida,string Frecuencia,string Observacion,bool Baja,int IdInternacionPedido,int? IdMotivoRechazo,string ObservacionRechazo,int IdDosis,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn,int? CantidadDisponible,int Deuda,int CantidadSolicitadaTotal,decimal Dosis)
	    {
		    InsPrescripcionDetalle item = new InsPrescripcionDetalle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdPrescripcionDetalle = IdPrescripcionDetalle;
				
			item.IdPrescripcion = IdPrescripcion;
				
			item.IdInsumo = IdInsumo;
				
			item.Fecha = Fecha;
				
			item.Renglon = Renglon;
				
			item.UnidadDosis = UnidadDosis;
				
			item.DiasTratamiento = DiasTratamiento;
				
			item.CantidadSolicitada = CantidadSolicitada;
				
			item.CantidadEmitida = CantidadEmitida;
				
			item.Frecuencia = Frecuencia;
				
			item.Observacion = Observacion;
				
			item.Baja = Baja;
				
			item.IdInternacionPedido = IdInternacionPedido;
				
			item.IdMotivoRechazo = IdMotivoRechazo;
				
			item.ObservacionRechazo = ObservacionRechazo;
				
			item.IdDosis = IdDosis;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
			item.CantidadDisponible = CantidadDisponible;
				
			item.Deuda = Deuda;
				
			item.CantidadSolicitadaTotal = CantidadSolicitadaTotal;
				
			item.Dosis = Dosis;
				
	        item.Save(UserName);
	    }
    }
}