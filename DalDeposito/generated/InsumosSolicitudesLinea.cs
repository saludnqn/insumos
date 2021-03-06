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
	/// Strongly-typed collection for the InsumosSolicitudesLinea class.
	/// </summary>
    [Serializable]
	public partial class InsumosSolicitudesLineaCollection : ActiveList<InsumosSolicitudesLinea, InsumosSolicitudesLineaCollection>
	{	   
		public InsumosSolicitudesLineaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsumosSolicitudesLineaCollection</returns>
		public InsumosSolicitudesLineaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsumosSolicitudesLinea o = this[i];
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
	/// This is an ActiveRecord class which wraps the Insumos_Solicitudes_Lineas table.
	/// </summary>
	[Serializable]
	public partial class InsumosSolicitudesLinea : ActiveRecord<InsumosSolicitudesLinea>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsumosSolicitudesLinea()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsumosSolicitudesLinea(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsumosSolicitudesLinea(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsumosSolicitudesLinea(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Insumos_Solicitudes_Lineas", TableType.Table, DataService.GetInstance("depProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSolicitud = new TableSchema.TableColumn(schema);
				colvarSolicitud.ColumnName = "Solicitud";
				colvarSolicitud.DataType = DbType.Int32;
				colvarSolicitud.MaxLength = 0;
				colvarSolicitud.AutoIncrement = false;
				colvarSolicitud.IsNullable = false;
				colvarSolicitud.IsPrimaryKey = false;
				colvarSolicitud.IsForeignKey = true;
				colvarSolicitud.IsReadOnly = false;
				colvarSolicitud.DefaultSetting = @"";
				
					colvarSolicitud.ForeignKeyTableName = "Insumos_Solicitudes";
				schema.Columns.Add(colvarSolicitud);
				
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
				
				TableSchema.TableColumn colvarInsumo = new TableSchema.TableColumn(schema);
				colvarInsumo.ColumnName = "Insumo";
				colvarInsumo.DataType = DbType.Int32;
				colvarInsumo.MaxLength = 0;
				colvarInsumo.AutoIncrement = false;
				colvarInsumo.IsNullable = false;
				colvarInsumo.IsPrimaryKey = false;
				colvarInsumo.IsForeignKey = true;
				colvarInsumo.IsReadOnly = false;
				colvarInsumo.DefaultSetting = @"";
				
					colvarInsumo.ForeignKeyTableName = "Insumos";
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
				
				TableSchema.TableColumn colvarCosto = new TableSchema.TableColumn(schema);
				colvarCosto.ColumnName = "Costo";
				colvarCosto.DataType = DbType.Currency;
				colvarCosto.MaxLength = 0;
				colvarCosto.AutoIncrement = false;
				colvarCosto.IsNullable = true;
				colvarCosto.IsPrimaryKey = false;
				colvarCosto.IsForeignKey = false;
				colvarCosto.IsReadOnly = false;
				colvarCosto.DefaultSetting = @"";
				colvarCosto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCosto);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["depProvider"].AddSchema("Insumos_Solicitudes_Lineas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Solicitud")]
		[Bindable(true)]
		public int Solicitud 
		{
			get { return GetColumnValue<int>(Columns.Solicitud); }
			set { SetColumnValue(Columns.Solicitud, value); }
		}
		  
		[XmlAttribute("Codigo")]
		[Bindable(true)]
		public int Codigo 
		{
			get { return GetColumnValue<int>(Columns.Codigo); }
			set { SetColumnValue(Columns.Codigo, value); }
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
		  
		[XmlAttribute("Costo")]
		[Bindable(true)]
		public decimal? Costo 
		{
			get { return GetColumnValue<decimal?>(Columns.Costo); }
			set { SetColumnValue(Columns.Costo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Insumo ActiveRecord object related to this InsumosSolicitudesLinea
		/// 
		/// </summary>
		public DalDeposito.Insumo InsumoRecord
		{
			get { return DalDeposito.Insumo.FetchByID(this.Insumo); }
			set { SetColumnValue("Insumo", value.Codigo); }
		}
		
		
		/// <summary>
		/// Returns a InsumosSolicitude ActiveRecord object related to this InsumosSolicitudesLinea
		/// 
		/// </summary>
		public DalDeposito.InsumosSolicitude InsumosSolicitude
		{
			get { return DalDeposito.InsumosSolicitude.FetchByID(this.Solicitud); }
			set { SetColumnValue("Solicitud", value.Codigo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSolicitud,int varInsumo,int varCantidad,decimal? varCosto)
		{
			InsumosSolicitudesLinea item = new InsumosSolicitudesLinea();
			
			item.Solicitud = varSolicitud;
			
			item.Insumo = varInsumo;
			
			item.Cantidad = varCantidad;
			
			item.Costo = varCosto;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSolicitud,int varCodigo,int varInsumo,int varCantidad,decimal? varCosto)
		{
			InsumosSolicitudesLinea item = new InsumosSolicitudesLinea();
			
				item.Solicitud = varSolicitud;
			
				item.Codigo = varCodigo;
			
				item.Insumo = varInsumo;
			
				item.Cantidad = varCantidad;
			
				item.Costo = varCosto;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SolicitudColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoColumn
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
        
        
        
        public static TableSchema.TableColumn CostoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Solicitud = @"Solicitud";
			 public static string Codigo = @"Codigo";
			 public static string Insumo = @"Insumo";
			 public static string Cantidad = @"Cantidad";
			 public static string Costo = @"Costo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
