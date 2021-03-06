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
	/// Strongly-typed collection for the InsumosValesLinea class.
	/// </summary>
    [Serializable]
	public partial class InsumosValesLineaCollection : ActiveList<InsumosValesLinea, InsumosValesLineaCollection>
	{	   
		public InsumosValesLineaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsumosValesLineaCollection</returns>
		public InsumosValesLineaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsumosValesLinea o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the Insumos_Vales_Lineas table.
	/// </summary>
	[Serializable]
	public partial class InsumosValesLinea : ActiveRecord<InsumosValesLinea>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsumosValesLinea()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsumosValesLinea(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsumosValesLinea(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsumosValesLinea(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Insumos_Vales_Lineas", TableType.Table, DataService.GetInstance("depProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "Codigo";
				colvarCodigo.DataType = DbType.Int32;
				colvarCodigo.MaxLength = 0;
				colvarCodigo.AutoIncrement = true;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = true;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarVale = new TableSchema.TableColumn(schema);
				colvarVale.ColumnName = "Vale";
				colvarVale.DataType = DbType.Int32;
				colvarVale.MaxLength = 0;
				colvarVale.AutoIncrement = false;
				colvarVale.IsNullable = false;
				colvarVale.IsPrimaryKey = false;
				colvarVale.IsForeignKey = true;
				colvarVale.IsReadOnly = false;
				colvarVale.DefaultSetting = @"";
				
					colvarVale.ForeignKeyTableName = "Insumos_Vales";
				schema.Columns.Add(colvarVale);
				
				TableSchema.TableColumn colvarInsumo = new TableSchema.TableColumn(schema);
				colvarInsumo.ColumnName = "Insumo";
				colvarInsumo.DataType = DbType.Int32;
				colvarInsumo.MaxLength = 0;
				colvarInsumo.AutoIncrement = false;
				colvarInsumo.IsNullable = false;
				colvarInsumo.IsPrimaryKey = false;
				colvarInsumo.IsForeignKey = false;
				colvarInsumo.IsReadOnly = false;
				colvarInsumo.DefaultSetting = @"";
				colvarInsumo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInsumo);
				
				TableSchema.TableColumn colvarCantidad = new TableSchema.TableColumn(schema);
				colvarCantidad.ColumnName = "Cantidad";
				colvarCantidad.DataType = DbType.Int32;
				colvarCantidad.MaxLength = 0;
				colvarCantidad.AutoIncrement = false;
				colvarCantidad.IsNullable = false;
				colvarCantidad.IsPrimaryKey = false;
				colvarCantidad.IsForeignKey = false;
				colvarCantidad.IsReadOnly = false;
				colvarCantidad.DefaultSetting = @"";
				colvarCantidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidad);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["depProvider"].AddSchema("Insumos_Vales_Lineas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public int Codigo 
		{
			get { return GetColumnValue<int>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
		}
		  
		[XmlAttribute("Vale")]
		[Bindable(true)]
		public int Vale 
		{
			get { return GetColumnValue<int>(Columns.Vale); }
			set { SetColumnValue(Columns.Vale, value); }
		}
		  
		[XmlAttribute("Insumo")]
		[Bindable(true)]
		public int Insumo 
		{
			get { return GetColumnValue<int>(Columns.Insumo); }
			set { SetColumnValue(Columns.Insumo, value); }
		}
		  
		[XmlAttribute("Cantidad")]
		[Bindable(true)]
		public int Cantidad 
		{
			get { return GetColumnValue<int>(Columns.Cantidad); }
			set { SetColumnValue(Columns.Cantidad, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a InsumosVale ActiveRecord object related to this InsumosValesLinea
		/// 
		/// </summary>
		public DalDeposito.InsumosVale InsumosVale
		{
			get { return DalDeposito.InsumosVale.FetchByID(this.Vale); }
			set { SetColumnValue("Vale", value.Codigo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varVale,int varInsumo,int varCantidad)
		{
			InsumosValesLinea item = new InsumosValesLinea();
			
			item.Vale = varVale;
			
			item.Insumo = varInsumo;
			
			item.Cantidad = varCantidad;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCodigo,int varVale,int varInsumo,int varCantidad)
		{
			InsumosValesLinea item = new InsumosValesLinea();
			
				item.Codigo = varCodigo;
			
				item.Vale = varVale;
			
				item.Insumo = varInsumo;
			
				item.Cantidad = varCantidad;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CodigoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ValeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn InsumoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Codigo = @"Codigo";
			 public static string Vale = @"Vale";
			 public static string Insumo = @"Insumo";
			 public static string Cantidad = @"Cantidad";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
