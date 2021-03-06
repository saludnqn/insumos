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
    /// Controller class for Insumos_Vales
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InsumosValeController
    {
        // Preload our schema..
        InsumosVale thisSchemaLoad = new InsumosVale();
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
        public InsumosValeCollection FetchAll()
        {
            InsumosValeCollection coll = new InsumosValeCollection();
            Query qry = new Query(InsumosVale.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosValeCollection FetchByID(object Codigo)
        {
            InsumosValeCollection coll = new InsumosValeCollection().Where("Codigo", Codigo).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InsumosValeCollection FetchByQuery(Query qry)
        {
            InsumosValeCollection coll = new InsumosValeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Codigo)
        {
            return (InsumosVale.Delete(Codigo) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Codigo)
        {
            return (InsumosVale.Destroy(Codigo) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Codigo,byte Sistema,int Descarga,DateTime Vencimiento,bool Entregado,bool Denegado)
	    {
		    InsumosVale item = new InsumosVale();
		    
            item.Codigo = Codigo;
            
            item.Sistema = Sistema;
            
            item.Descarga = Descarga;
            
            item.Vencimiento = Vencimiento;
            
            item.Entregado = Entregado;
            
            item.Denegado = Denegado;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Codigo,byte Sistema,int Descarga,DateTime Vencimiento,bool Entregado,bool Denegado)
	    {
		    InsumosVale item = new InsumosVale();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Codigo = Codigo;
				
			item.Sistema = Sistema;
				
			item.Descarga = Descarga;
				
			item.Vencimiento = Vencimiento;
				
			item.Entregado = Entregado;
				
			item.Denegado = Denegado;
				
	        item.Save(UserName);
	    }
    }
}
