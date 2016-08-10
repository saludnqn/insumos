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
namespace DalDeposito
{
    /// <summary>
    /// Controller class for Insumos_Vales_Lineas
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsumosValesLineaController
    {
        // Preload our schema..
        InsumosValesLinea thisSchemaLoad = new InsumosValesLinea();
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
        public InsumosValesLineaCollection FetchAll()
        {
            InsumosValesLineaCollection coll = new InsumosValesLineaCollection();
            Query qry = new Query(InsumosValesLinea.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosValesLineaCollection FetchByID(object Codigo)
        {
            InsumosValesLineaCollection coll = new InsumosValesLineaCollection().Where("Codigo", Codigo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosValesLineaCollection FetchByQuery(Query qry)
        {
            InsumosValesLineaCollection coll = new InsumosValesLineaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Codigo)
        {
            return (InsumosValesLinea.Delete(Codigo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Codigo)
        {
            return (InsumosValesLinea.Destroy(Codigo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Vale,int Insumo,int Cantidad)
	    {
		    InsumosValesLinea item = new InsumosValesLinea();
		    
            item.Vale = Vale;
            
            item.Insumo = Insumo;
            
            item.Cantidad = Cantidad;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Codigo,int Vale,int Insumo,int Cantidad)
	    {
		    InsumosValesLinea item = new InsumosValesLinea();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Codigo = Codigo;
				
			item.Vale = Vale;
				
			item.Insumo = Insumo;
				
			item.Cantidad = Cantidad;
				
	        item.Save(UserName);
	    }
    }
}
