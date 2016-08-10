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
    /// Controller class for INS_Proveedor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsProveedorController
    {
        // Preload our schema..
        InsProveedor thisSchemaLoad = new InsProveedor();
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
        public InsProveedorCollection FetchAll()
        {
            InsProveedorCollection coll = new InsProveedorCollection();
            Query qry = new Query(InsProveedor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsProveedorCollection FetchByID(object IdProveedor)
        {
            InsProveedorCollection coll = new InsProveedorCollection().Where("idProveedor", IdProveedor).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsProveedorCollection FetchByQuery(Query qry)
        {
            InsProveedorCollection coll = new InsProveedorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdProveedor)
        {
            return (InsProveedor.Delete(IdProveedor) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdProveedor)
        {
            return (InsProveedor.Destroy(IdProveedor) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Codigo,string Nombre,string Descripcion,string Cuit,string Domicilio,string Telefono,string Email,string Observaciones,int IdEfector,int IdTipoProveedor,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsProveedor item = new InsProveedor();
		    
            item.Codigo = Codigo;
            
            item.Nombre = Nombre;
            
            item.Descripcion = Descripcion;
            
            item.Cuit = Cuit;
            
            item.Domicilio = Domicilio;
            
            item.Telefono = Telefono;
            
            item.Email = Email;
            
            item.Observaciones = Observaciones;
            
            item.IdEfector = IdEfector;
            
            item.IdTipoProveedor = IdTipoProveedor;
            
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
	    public void Update(int IdProveedor,string Codigo,string Nombre,string Descripcion,string Cuit,string Domicilio,string Telefono,string Email,string Observaciones,int IdEfector,int IdTipoProveedor,bool Baja,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiedOn)
	    {
		    InsProveedor item = new InsProveedor();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdProveedor = IdProveedor;
				
			item.Codigo = Codigo;
				
			item.Nombre = Nombre;
				
			item.Descripcion = Descripcion;
				
			item.Cuit = Cuit;
				
			item.Domicilio = Domicilio;
				
			item.Telefono = Telefono;
				
			item.Email = Email;
				
			item.Observaciones = Observaciones;
				
			item.IdEfector = IdEfector;
				
			item.IdTipoProveedor = IdTipoProveedor;
				
			item.Baja = Baja;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiedOn = ModifiedOn;
				
	        item.Save(UserName);
	    }
    }
}
