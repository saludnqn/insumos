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
	/// Strongly-typed collection for the InsRelInsumoPrograma class.
	/// </summary>
    [Serializable]
	public partial class InsRelInsumoProgramaCollection : ActiveList<InsRelInsumoPrograma, InsRelInsumoProgramaCollection>
	{	   
		public InsRelInsumoProgramaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsRelInsumoProgramaCollection</returns>
		public InsRelInsumoProgramaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsRelInsumoPrograma o = this[i];
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
	/// This is an ActiveRecord class which wraps the INS_RelInsumoPrograma table.
	/// </summary>
	[Serializable]
	public partial class InsRelInsumoPrograma : ActiveRecord<InsRelInsumoPrograma>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsRelInsumoPrograma()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsRelInsumoPrograma(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsRelInsumoPrograma(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsRelInsumoPrograma(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("INS_RelInsumoPrograma", TableType.Table, DataService.GetInstance("insProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdRelInsumoPrograma = new TableSchema.TableColumn(schema);
				colvarIdRelInsumoPrograma.ColumnName = "idRelInsumoPrograma";
				colvarIdRelInsumoPrograma.DataType = DbType.Int32;
				colvarIdRelInsumoPrograma.MaxLength = 0;
				colvarIdRelInsumoPrograma.AutoIncrement = true;
				colvarIdRelInsumoPrograma.IsNullable = false;
				colvarIdRelInsumoPrograma.IsPrimaryKey = true;
				colvarIdRelInsumoPrograma.IsForeignKey = false;
				colvarIdRelInsumoPrograma.IsReadOnly = false;
				colvarIdRelInsumoPrograma.DefaultSetting = @"";
				colvarIdRelInsumoPrograma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdRelInsumoPrograma);
				
				TableSchema.TableColumn colvarIdInsumo = new TableSchema.TableColumn(schema);
				colvarIdInsumo.ColumnName = "idInsumo";
				colvarIdInsumo.DataType = DbType.Int32;
				colvarIdInsumo.MaxLength = 0;
				colvarIdInsumo.AutoIncrement = false;
				colvarIdInsumo.IsNullable = true;
				colvarIdInsumo.IsPrimaryKey = false;
				colvarIdInsumo.IsForeignKey = false;
				colvarIdInsumo.IsReadOnly = false;
				colvarIdInsumo.DefaultSetting = @"";
				colvarIdInsumo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdInsumo);
				
				TableSchema.TableColumn colvarIdPrograma = new TableSchema.TableColumn(schema);
				colvarIdPrograma.ColumnName = "idPrograma";
				colvarIdPrograma.DataType = DbType.Int32;
				colvarIdPrograma.MaxLength = 0;
				colvarIdPrograma.AutoIncrement = false;
				colvarIdPrograma.IsNullable = true;
				colvarIdPrograma.IsPrimaryKey = false;
				colvarIdPrograma.IsForeignKey = false;
				colvarIdPrograma.IsReadOnly = false;
				colvarIdPrograma.DefaultSetting = @"";
				colvarIdPrograma.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrograma);
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = true;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				colvarBaja.DefaultSetting = @"";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["insProvider"].AddSchema("INS_RelInsumoPrograma",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdRelInsumoPrograma")]
		[Bindable(true)]
		public int IdRelInsumoPrograma 
		{
			get { return GetColumnValue<int>(Columns.IdRelInsumoPrograma); }
			set { SetColumnValue(Columns.IdRelInsumoPrograma, value); }
		}
		  
		[XmlAttribute("IdInsumo")]
		[Bindable(true)]
		public int? IdInsumo 
		{
			get { return GetColumnValue<int?>(Columns.IdInsumo); }
			set { SetColumnValue(Columns.IdInsumo, value); }
		}
		  
		[XmlAttribute("IdPrograma")]
		[Bindable(true)]
		public int? IdPrograma 
		{
			get { return GetColumnValue<int?>(Columns.IdPrograma); }
			set { SetColumnValue(Columns.IdPrograma, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool? Baja 
		{
			get { return GetColumnValue<bool?>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdInsumo,int? varIdPrograma,bool? varBaja,DateTime? varFecha)
		{
			InsRelInsumoPrograma item = new InsRelInsumoPrograma();
			
			item.IdInsumo = varIdInsumo;
			
			item.IdPrograma = varIdPrograma;
			
			item.Baja = varBaja;
			
			item.Fecha = varFecha;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdRelInsumoPrograma,int? varIdInsumo,int? varIdPrograma,bool? varBaja,DateTime? varFecha)
		{
			InsRelInsumoPrograma item = new InsRelInsumoPrograma();
			
				item.IdRelInsumoPrograma = varIdRelInsumoPrograma;
			
				item.IdInsumo = varIdInsumo;
			
				item.IdPrograma = varIdPrograma;
			
				item.Baja = varBaja;
			
				item.Fecha = varFecha;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdRelInsumoProgramaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdInsumoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProgramaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdRelInsumoPrograma = @"idRelInsumoPrograma";
			 public static string IdInsumo = @"idInsumo";
			 public static string IdPrograma = @"idPrograma";
			 public static string Baja = @"baja";
			 public static string Fecha = @"fecha";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}