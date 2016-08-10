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
    /// Controller class for INS_Mensajes_tipos
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsMensajesTipoController
    {
        // Preload our schema..
        InsMensajesTipo thisSchemaLoad = new InsMensajesTipo();
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
        public InsMensajesTipoCollection FetchAll()
        {
            InsMensajesTipoCollection coll = new InsMensajesTipoCollection();
            Query qry = new Query(InsMensajesTipo.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsMensajesTipoCollection FetchByID(object Id)
        {
            InsMensajesTipoCollection coll = new InsMensajesTipoCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsMensajesTipoCollection FetchByQuery(Query qry)
        {
            InsMensajesTipoCollection coll = new InsMensajesTipoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (InsMensajesTipo.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (InsMensajesTipo.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Nombre,string Link)
	    {
		    InsMensajesTipo item = new InsMensajesTipo();
		    
            item.Nombre = Nombre;
            
            item.Link = Link;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Nombre,string Link)
	    {
		    InsMensajesTipo item = new InsMensajesTipo();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Nombre = Nombre;
				
			item.Link = Link;
				
	        item.Save(UserName);
	    }
    }
}