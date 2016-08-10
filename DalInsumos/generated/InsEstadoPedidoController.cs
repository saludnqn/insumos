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
    /// Controller class for INS_EstadoPedido
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsEstadoPedidoController
    {
        // Preload our schema..
        InsEstadoPedido thisSchemaLoad = new InsEstadoPedido();
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
        public InsEstadoPedidoCollection FetchAll()
        {
            InsEstadoPedidoCollection coll = new InsEstadoPedidoCollection();
            Query qry = new Query(InsEstadoPedido.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsEstadoPedidoCollection FetchByID(object IdEstadoPedido)
        {
            InsEstadoPedidoCollection coll = new InsEstadoPedidoCollection().Where("idEstadoPedido", IdEstadoPedido).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsEstadoPedidoCollection FetchByQuery(Query qry)
        {
            InsEstadoPedidoCollection coll = new InsEstadoPedidoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdEstadoPedido)
        {
            return (InsEstadoPedido.Delete(IdEstadoPedido) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdEstadoPedido)
        {
            return (InsEstadoPedido.Destroy(IdEstadoPedido) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,bool Interno,bool Activo)
	    {
		    InsEstadoPedido item = new InsEstadoPedido();
		    
            item.Nombre = Nombre;
            
            item.Interno = Interno;
            
            item.Activo = Activo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IdEstadoPedido,string Nombre,bool Interno,bool Activo)
	    {
		    InsEstadoPedido item = new InsEstadoPedido();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdEstadoPedido = IdEstadoPedido;
				
			item.Nombre = Nombre;
				
			item.Interno = Interno;
				
			item.Activo = Activo;
				
	        item.Save(UserName);
	    }
    }
}
