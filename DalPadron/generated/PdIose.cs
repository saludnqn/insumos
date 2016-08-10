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
namespace DalPadron
{
	/// <summary>
	/// Strongly-typed collection for the PdIose class.
	/// </summary>
    [Serializable]
	public partial class PdIoseCollection : ActiveList<PdIose, PdIoseCollection>
	{	   
		public PdIoseCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PdIoseCollection</returns>
		public PdIoseCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PdIose o = this[i];
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
	/// This is an ActiveRecord class which wraps the Pd_Iose table.
	/// </summary>
	[Serializable]
	public partial class PdIose : ActiveRecord<PdIose>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PdIose()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PdIose(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PdIose(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PdIose(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Pd_Iose", TableType.Table, DataService.GetInstance("padronProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarDocumento = new TableSchema.TableColumn(schema);
				colvarDocumento.ColumnName = "Documento";
				colvarDocumento.DataType = DbType.Int32;
				colvarDocumento.MaxLength = 0;
				colvarDocumento.AutoIncrement = false;
				colvarDocumento.IsNullable = false;
				colvarDocumento.IsPrimaryKey = false;
				colvarDocumento.IsForeignKey = false;
				colvarDocumento.IsReadOnly = false;
				colvarDocumento.DefaultSetting = @"";
				colvarDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumento);
				
				TableSchema.TableColumn colvarTipoDocumento = new TableSchema.TableColumn(schema);
				colvarTipoDocumento.ColumnName = "TipoDocumento";
				colvarTipoDocumento.DataType = DbType.AnsiString;
				colvarTipoDocumento.MaxLength = 50;
				colvarTipoDocumento.AutoIncrement = false;
				colvarTipoDocumento.IsNullable = true;
				colvarTipoDocumento.IsPrimaryKey = false;
				colvarTipoDocumento.IsForeignKey = false;
				colvarTipoDocumento.IsReadOnly = false;
				colvarTipoDocumento.DefaultSetting = @"";
				colvarTipoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocumento);
				
				TableSchema.TableColumn colvarFechaIngreso = new TableSchema.TableColumn(schema);
				colvarFechaIngreso.ColumnName = "FechaIngreso";
				colvarFechaIngreso.DataType = DbType.DateTime;
				colvarFechaIngreso.MaxLength = 0;
				colvarFechaIngreso.AutoIncrement = false;
				colvarFechaIngreso.IsNullable = true;
				colvarFechaIngreso.IsPrimaryKey = false;
				colvarFechaIngreso.IsForeignKey = false;
				colvarFechaIngreso.IsReadOnly = false;
				colvarFechaIngreso.DefaultSetting = @"";
				colvarFechaIngreso.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaIngreso);
				
				TableSchema.TableColumn colvarNroAfiliado = new TableSchema.TableColumn(schema);
				colvarNroAfiliado.ColumnName = "NroAfiliado";
				colvarNroAfiliado.DataType = DbType.Int32;
				colvarNroAfiliado.MaxLength = 0;
				colvarNroAfiliado.AutoIncrement = false;
				colvarNroAfiliado.IsNullable = true;
				colvarNroAfiliado.IsPrimaryKey = false;
				colvarNroAfiliado.IsForeignKey = false;
				colvarNroAfiliado.IsReadOnly = false;
				colvarNroAfiliado.DefaultSetting = @"";
				colvarNroAfiliado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroAfiliado);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["padronProvider"].AddSchema("Pd_Iose",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Documento")]
		[Bindable(true)]
		public int Documento 
		{
			get { return GetColumnValue<int>(Columns.Documento); }
			set { SetColumnValue(Columns.Documento, value); }
		}
		  
		[XmlAttribute("TipoDocumento")]
		[Bindable(true)]
		public string TipoDocumento 
		{
			get { return GetColumnValue<string>(Columns.TipoDocumento); }
			set { SetColumnValue(Columns.TipoDocumento, value); }
		}
		  
		[XmlAttribute("FechaIngreso")]
		[Bindable(true)]
		public DateTime? FechaIngreso 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaIngreso); }
			set { SetColumnValue(Columns.FechaIngreso, value); }
		}
		  
		[XmlAttribute("NroAfiliado")]
		[Bindable(true)]
		public int? NroAfiliado 
		{
			get { return GetColumnValue<int?>(Columns.NroAfiliado); }
			set { SetColumnValue(Columns.NroAfiliado, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varDocumento,string varTipoDocumento,DateTime? varFechaIngreso,int? varNroAfiliado)
		{
			PdIose item = new PdIose();
			
			item.Nombre = varNombre;
			
			item.Documento = varDocumento;
			
			item.TipoDocumento = varTipoDocumento;
			
			item.FechaIngreso = varFechaIngreso;
			
			item.NroAfiliado = varNroAfiliado;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varNombre,int varDocumento,string varTipoDocumento,DateTime? varFechaIngreso,int? varNroAfiliado)
		{
			PdIose item = new PdIose();
			
				item.Id = varId;
			
				item.Nombre = varNombre;
			
				item.Documento = varDocumento;
			
				item.TipoDocumento = varTipoDocumento;
			
				item.FechaIngreso = varFechaIngreso;
			
				item.NroAfiliado = varNroAfiliado;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DocumentoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocumentoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaIngresoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NroAfiliadoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Nombre = @"Nombre";
			 public static string Documento = @"Documento";
			 public static string TipoDocumento = @"TipoDocumento";
			 public static string FechaIngreso = @"FechaIngreso";
			 public static string NroAfiliado = @"NroAfiliado";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
