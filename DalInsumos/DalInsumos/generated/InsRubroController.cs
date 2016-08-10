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
    /// Controller class for INS_Rubro
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsRubroController
    {
        // Preload our schema..
        InsRubro thisSchemaLoad = new InsRubro();
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
        public InsRubroCollection FetchAll()
        {
            InsRubroCollection coll = new InsRubroCollection();
            Query qry = new Query(InsRubro.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsRubroCollection FetchByID(object Codigo)
        {
            InsRubroCollection coll = new InsRubroCollection().Where("Codigo", Codigo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsRubroCollection FetchByQuery(Query qry)
        {
            InsRubroCollection coll = new InsRubroCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Codigo)
        {
            return (InsRubro.Delete(Codigo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Codigo)
        {
            return (InsRubro.Destroy(Codigo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(byte Sistema,int? Padre,string Nombre,byte Especial,int? RubroPrimerNivel)
	    {
		    InsRubro item = new InsRubro();
		    
            item.Sistema = Sistema;
            
            item.Padre = Padre;
            
            item.Nombre = Nombre;
            
            item.Especial = Especial;
            
            item.RubroPrimerNivel = RubroPrimerNivel;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Codigo,byte Sistema,int? Padre,string Nombre,byte Especial,int? RubroPrimerNivel)
	    {
		    InsRubro item = new InsRubro();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Codigo = Codigo;
				
			item.Sistema = Sistema;
				
			item.Padre = Padre;
				
			item.Nombre = Nombre;
				
			item.Especial = Especial;
				
			item.RubroPrimerNivel = RubroPrimerNivel;
				
	        item.Save(UserName);
	    }
    }
}