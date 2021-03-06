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
	/// Strongly-typed collection for the InsInsumosEquivalente class.
	/// </summary>
    [Serializable]
	public partial class InsInsumosEquivalenteCollection : ActiveList<InsInsumosEquivalente, InsInsumosEquivalenteCollection>
	{	   
		public InsInsumosEquivalenteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsInsumosEquivalenteCollection</returns>
		public InsInsumosEquivalenteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsInsumosEquivalente o = this[i];
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
	/// This is an ActiveRecord class which wraps the INS_InsumosEquivalentes table.
	/// </summary>
	[Serializable]
	public partial class InsInsumosEquivalente : ActiveRecord<InsInsumosEquivalente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsInsumosEquivalente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsInsumosEquivalente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsInsumosEquivalente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsInsumosEquivalente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("INS_InsumosEquivalentes", TableType.Table, DataService.GetInstance("insProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdAsociacion = new TableSchema.TableColumn(schema);
				colvarIdAsociacion.ColumnName = "idAsociacion";
				colvarIdAsociacion.DataType = DbType.Int32;
				colvarIdAsociacion.MaxLength = 0;
				colvarIdAsociacion.AutoIncrement = true;
				colvarIdAsociacion.IsNullable = false;
				colvarIdAsociacion.IsPrimaryKey = true;
				colvarIdAsociacion.IsForeignKey = false;
				colvarIdAsociacion.IsReadOnly = false;
				colvarIdAsociacion.DefaultSetting = @"";
				colvarIdAsociacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdAsociacion);
				
				TableSchema.TableColumn colvarIdInsumoOrigen = new TableSchema.TableColumn(schema);
				colvarIdInsumoOrigen.ColumnName = "idInsumoOrigen";
				colvarIdInsumoOrigen.DataType = DbType.Int32;
				colvarIdInsumoOrigen.MaxLength = 0;
				colvarIdInsumoOrigen.AutoIncrement = false;
				colvarIdInsumoOrigen.IsNullable = false;
				colvarIdInsumoOrigen.IsPrimaryKey = false;
				colvarIdInsumoOrigen.IsForeignKey = true;
				colvarIdInsumoOrigen.IsReadOnly = false;
				
						colvarIdInsumoOrigen.DefaultSetting = @"((0))";
				
					colvarIdInsumoOrigen.ForeignKeyTableName = "INS_Insumo";
				schema.Columns.Add(colvarIdInsumoOrigen);
				
				TableSchema.TableColumn colvarIdInsumoEquivalente = new TableSchema.TableColumn(schema);
				colvarIdInsumoEquivalente.ColumnName = "idInsumoEquivalente";
				colvarIdInsumoEquivalente.DataType = DbType.Int32;
				colvarIdInsumoEquivalente.MaxLength = 0;
				colvarIdInsumoEquivalente.AutoIncrement = false;
				colvarIdInsumoEquivalente.IsNullable = false;
				colvarIdInsumoEquivalente.IsPrimaryKey = false;
				colvarIdInsumoEquivalente.IsForeignKey = true;
				colvarIdInsumoEquivalente.IsReadOnly = false;
				
						colvarIdInsumoEquivalente.DefaultSetting = @"((0))";
				
					colvarIdInsumoEquivalente.ForeignKeyTableName = "INS_Insumo";
				schema.Columns.Add(colvarIdInsumoEquivalente);
				
				TableSchema.TableColumn colvarFechaAsociacion = new TableSchema.TableColumn(schema);
				colvarFechaAsociacion.ColumnName = "fechaAsociacion";
				colvarFechaAsociacion.DataType = DbType.DateTime;
				colvarFechaAsociacion.MaxLength = 0;
				colvarFechaAsociacion.AutoIncrement = false;
				colvarFechaAsociacion.IsNullable = false;
				colvarFechaAsociacion.IsPrimaryKey = false;
				colvarFechaAsociacion.IsForeignKey = false;
				colvarFechaAsociacion.IsReadOnly = false;
				
						colvarFechaAsociacion.DefaultSetting = @"(getdate())";
				colvarFechaAsociacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaAsociacion);
				
				TableSchema.TableColumn colvarActivo = new TableSchema.TableColumn(schema);
				colvarActivo.ColumnName = "activo";
				colvarActivo.DataType = DbType.Boolean;
				colvarActivo.MaxLength = 0;
				colvarActivo.AutoIncrement = false;
				colvarActivo.IsNullable = false;
				colvarActivo.IsPrimaryKey = false;
				colvarActivo.IsForeignKey = false;
				colvarActivo.IsReadOnly = false;
				
						colvarActivo.DefaultSetting = @"((1))";
				colvarActivo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActivo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["insProvider"].AddSchema("INS_InsumosEquivalentes",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdAsociacion")]
		[Bindable(true)]
		public int IdAsociacion 
		{
			get { return GetColumnValue<int>(Columns.IdAsociacion); }
			set { SetColumnValue(Columns.IdAsociacion, value); }
		}
		  
		[XmlAttribute("IdInsumoOrigen")]
		[Bindable(true)]
		public int IdInsumoOrigen 
		{
			get { return GetColumnValue<int>(Columns.IdInsumoOrigen); }
			set { SetColumnValue(Columns.IdInsumoOrigen, value); }
		}
		  
		[XmlAttribute("IdInsumoEquivalente")]
		[Bindable(true)]
		public int IdInsumoEquivalente 
		{
			get { return GetColumnValue<int>(Columns.IdInsumoEquivalente); }
			set { SetColumnValue(Columns.IdInsumoEquivalente, value); }
		}
		  
		[XmlAttribute("FechaAsociacion")]
		[Bindable(true)]
		public DateTime FechaAsociacion 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaAsociacion); }
			set { SetColumnValue(Columns.FechaAsociacion, value); }
		}
		  
		[XmlAttribute("Activo")]
		[Bindable(true)]
		public bool Activo 
		{
			get { return GetColumnValue<bool>(Columns.Activo); }
			set { SetColumnValue(Columns.Activo, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a InsInsumo ActiveRecord object related to this InsInsumosEquivalente
		/// 
		/// </summary>
		public DalInsumos.InsInsumo InsInsumo
		{
			get { return DalInsumos.InsInsumo.FetchByID(this.IdInsumoEquivalente); }
			set { SetColumnValue("idInsumoEquivalente", value.Codigo); }
		}
		
		
		/// <summary>
		/// Returns a InsInsumo ActiveRecord object related to this InsInsumosEquivalente
		/// 
		/// </summary>
		public DalInsumos.InsInsumo InsInsumoToIdInsumoOrigen
		{
			get { return DalInsumos.InsInsumo.FetchByID(this.IdInsumoOrigen); }
			set { SetColumnValue("idInsumoOrigen", value.Codigo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varIdInsumoOrigen,int varIdInsumoEquivalente,DateTime varFechaAsociacion,bool varActivo)
		{
			InsInsumosEquivalente item = new InsInsumosEquivalente();
			
			item.IdInsumoOrigen = varIdInsumoOrigen;
			
			item.IdInsumoEquivalente = varIdInsumoEquivalente;
			
			item.FechaAsociacion = varFechaAsociacion;
			
			item.Activo = varActivo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdAsociacion,int varIdInsumoOrigen,int varIdInsumoEquivalente,DateTime varFechaAsociacion,bool varActivo)
		{
			InsInsumosEquivalente item = new InsInsumosEquivalente();
			
				item.IdAsociacion = varIdAsociacion;
			
				item.IdInsumoOrigen = varIdInsumoOrigen;
			
				item.IdInsumoEquivalente = varIdInsumoEquivalente;
			
				item.FechaAsociacion = varFechaAsociacion;
			
				item.Activo = varActivo;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdAsociacionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInsumoOrigenColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInsumoEquivalenteColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaAsociacionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ActivoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdAsociacion = @"idAsociacion";
			 public static string IdInsumoOrigen = @"idInsumoOrigen";
			 public static string IdInsumoEquivalente = @"idInsumoEquivalente";
			 public static string FechaAsociacion = @"fechaAsociacion";
			 public static string Activo = @"activo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
