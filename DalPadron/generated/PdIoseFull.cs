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
	/// Strongly-typed collection for the PdIoseFull class.
	/// </summary>
    [Serializable]
	public partial class PdIoseFullCollection : ActiveList<PdIoseFull, PdIoseFullCollection>
	{	   
		public PdIoseFullCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PdIoseFullCollection</returns>
		public PdIoseFullCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PdIoseFull o = this[i];
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
	/// This is an ActiveRecord class which wraps the Pd_Iose_Full table.
	/// </summary>
	[Serializable]
	public partial class PdIoseFull : ActiveRecord<PdIoseFull>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PdIoseFull()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PdIoseFull(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PdIoseFull(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PdIoseFull(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Pd_Iose_Full", TableType.Table, DataService.GetInstance("padronProvider"));
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
				colvarTipoDocumento.IsNullable = false;
				colvarTipoDocumento.IsPrimaryKey = false;
				colvarTipoDocumento.IsForeignKey = false;
				colvarTipoDocumento.IsReadOnly = false;
				colvarTipoDocumento.DefaultSetting = @"";
				colvarTipoDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDocumento);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "Apellido";
				colvarApellido.DataType = DbType.AnsiString;
				colvarApellido.MaxLength = 50;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = false;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 50;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "FechaNacimiento";
				colvarFechaNacimiento.DataType = DbType.DateTime;
				colvarFechaNacimiento.MaxLength = 0;
				colvarFechaNacimiento.AutoIncrement = false;
				colvarFechaNacimiento.IsNullable = true;
				colvarFechaNacimiento.IsPrimaryKey = false;
				colvarFechaNacimiento.IsForeignKey = false;
				colvarFechaNacimiento.IsReadOnly = false;
				colvarFechaNacimiento.DefaultSetting = @"";
				colvarFechaNacimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaNacimiento);
				
				TableSchema.TableColumn colvarSexo = new TableSchema.TableColumn(schema);
				colvarSexo.ColumnName = "Sexo";
				colvarSexo.DataType = DbType.AnsiString;
				colvarSexo.MaxLength = 50;
				colvarSexo.AutoIncrement = false;
				colvarSexo.IsNullable = true;
				colvarSexo.IsPrimaryKey = false;
				colvarSexo.IsForeignKey = false;
				colvarSexo.IsReadOnly = false;
				colvarSexo.DefaultSetting = @"";
				colvarSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSexo);
				
				TableSchema.TableColumn colvarAfiliado = new TableSchema.TableColumn(schema);
				colvarAfiliado.ColumnName = "Afiliado";
				colvarAfiliado.DataType = DbType.AnsiString;
				colvarAfiliado.MaxLength = 50;
				colvarAfiliado.AutoIncrement = false;
				colvarAfiliado.IsNullable = true;
				colvarAfiliado.IsPrimaryKey = false;
				colvarAfiliado.IsForeignKey = false;
				colvarAfiliado.IsReadOnly = false;
				colvarAfiliado.DefaultSetting = @"";
				colvarAfiliado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAfiliado);
				
				TableSchema.TableColumn colvarNucleo = new TableSchema.TableColumn(schema);
				colvarNucleo.ColumnName = "Nucleo";
				colvarNucleo.DataType = DbType.AnsiString;
				colvarNucleo.MaxLength = 50;
				colvarNucleo.AutoIncrement = false;
				colvarNucleo.IsNullable = true;
				colvarNucleo.IsPrimaryKey = false;
				colvarNucleo.IsForeignKey = false;
				colvarNucleo.IsReadOnly = false;
				colvarNucleo.DefaultSetting = @"";
				colvarNucleo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNucleo);
				
				TableSchema.TableColumn colvarLocalidad = new TableSchema.TableColumn(schema);
				colvarLocalidad.ColumnName = "Localidad";
				colvarLocalidad.DataType = DbType.AnsiString;
				colvarLocalidad.MaxLength = 50;
				colvarLocalidad.AutoIncrement = false;
				colvarLocalidad.IsNullable = true;
				colvarLocalidad.IsPrimaryKey = false;
				colvarLocalidad.IsForeignKey = false;
				colvarLocalidad.IsReadOnly = false;
				colvarLocalidad.DefaultSetting = @"";
				colvarLocalidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocalidad);
				
				TableSchema.TableColumn colvarProvincia = new TableSchema.TableColumn(schema);
				colvarProvincia.ColumnName = "Provincia";
				colvarProvincia.DataType = DbType.AnsiString;
				colvarProvincia.MaxLength = 50;
				colvarProvincia.AutoIncrement = false;
				colvarProvincia.IsNullable = true;
				colvarProvincia.IsPrimaryKey = false;
				colvarProvincia.IsForeignKey = false;
				colvarProvincia.IsReadOnly = false;
				colvarProvincia.DefaultSetting = @"";
				colvarProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProvincia);
				
				TableSchema.TableColumn colvarNombreCompleto = new TableSchema.TableColumn(schema);
				colvarNombreCompleto.ColumnName = "NombreCompleto";
				colvarNombreCompleto.DataType = DbType.AnsiString;
				colvarNombreCompleto.MaxLength = 102;
				colvarNombreCompleto.AutoIncrement = false;
				colvarNombreCompleto.IsNullable = true;
				colvarNombreCompleto.IsPrimaryKey = false;
				colvarNombreCompleto.IsForeignKey = false;
				colvarNombreCompleto.IsReadOnly = true;
				colvarNombreCompleto.DefaultSetting = @"";
				colvarNombreCompleto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombreCompleto);
				
				TableSchema.TableColumn colvarNroAfiliado = new TableSchema.TableColumn(schema);
				colvarNroAfiliado.ColumnName = "NroAfiliado";
				colvarNroAfiliado.DataType = DbType.AnsiString;
				colvarNroAfiliado.MaxLength = 101;
				colvarNroAfiliado.AutoIncrement = false;
				colvarNroAfiliado.IsNullable = true;
				colvarNroAfiliado.IsPrimaryKey = false;
				colvarNroAfiliado.IsForeignKey = false;
				colvarNroAfiliado.IsReadOnly = true;
				colvarNroAfiliado.DefaultSetting = @"";
				colvarNroAfiliado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNroAfiliado);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["padronProvider"].AddSchema("Pd_Iose_Full",schema);
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
		  
		[XmlAttribute("Apellido")]
		[Bindable(true)]
		public string Apellido 
		{
			get { return GetColumnValue<string>(Columns.Apellido); }
			set { SetColumnValue(Columns.Apellido, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("Sexo")]
		[Bindable(true)]
		public string Sexo 
		{
			get { return GetColumnValue<string>(Columns.Sexo); }
			set { SetColumnValue(Columns.Sexo, value); }
		}
		  
		[XmlAttribute("Afiliado")]
		[Bindable(true)]
		public string Afiliado 
		{
			get { return GetColumnValue<string>(Columns.Afiliado); }
			set { SetColumnValue(Columns.Afiliado, value); }
		}
		  
		[XmlAttribute("Nucleo")]
		[Bindable(true)]
		public string Nucleo 
		{
			get { return GetColumnValue<string>(Columns.Nucleo); }
			set { SetColumnValue(Columns.Nucleo, value); }
		}
		  
		[XmlAttribute("Localidad")]
		[Bindable(true)]
		public string Localidad 
		{
			get { return GetColumnValue<string>(Columns.Localidad); }
			set { SetColumnValue(Columns.Localidad, value); }
		}
		  
		[XmlAttribute("Provincia")]
		[Bindable(true)]
		public string Provincia 
		{
			get { return GetColumnValue<string>(Columns.Provincia); }
			set { SetColumnValue(Columns.Provincia, value); }
		}
		  
		[XmlAttribute("NombreCompleto")]
		[Bindable(true)]
		public string NombreCompleto 
		{
			get { return GetColumnValue<string>(Columns.NombreCompleto); }
			set { SetColumnValue(Columns.NombreCompleto, value); }
		}
		  
		[XmlAttribute("NroAfiliado")]
		[Bindable(true)]
		public string NroAfiliado 
		{
			get { return GetColumnValue<string>(Columns.NroAfiliado); }
			set { SetColumnValue(Columns.NroAfiliado, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varDocumento,string varTipoDocumento,string varApellido,string varNombre,DateTime? varFechaNacimiento,string varSexo,string varAfiliado,string varNucleo,string varLocalidad,string varProvincia,string varNombreCompleto,string varNroAfiliado)
		{
			PdIoseFull item = new PdIoseFull();
			
			item.Documento = varDocumento;
			
			item.TipoDocumento = varTipoDocumento;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.Sexo = varSexo;
			
			item.Afiliado = varAfiliado;
			
			item.Nucleo = varNucleo;
			
			item.Localidad = varLocalidad;
			
			item.Provincia = varProvincia;
			
			item.NombreCompleto = varNombreCompleto;
			
			item.NroAfiliado = varNroAfiliado;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varDocumento,string varTipoDocumento,string varApellido,string varNombre,DateTime? varFechaNacimiento,string varSexo,string varAfiliado,string varNucleo,string varLocalidad,string varProvincia,string varNombreCompleto,string varNroAfiliado)
		{
			PdIoseFull item = new PdIoseFull();
			
				item.Id = varId;
			
				item.Documento = varDocumento;
			
				item.TipoDocumento = varTipoDocumento;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.Sexo = varSexo;
			
				item.Afiliado = varAfiliado;
			
				item.Nucleo = varNucleo;
			
				item.Localidad = varLocalidad;
			
				item.Provincia = varProvincia;
			
				item.NombreCompleto = varNombreCompleto;
			
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
        
        
        
        public static TableSchema.TableColumn DocumentoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoDocumentoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SexoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn AfiliadoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn NucleoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn LocalidadColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ProvinciaColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreCompletoColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn NroAfiliadoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Documento = @"Documento";
			 public static string TipoDocumento = @"TipoDocumento";
			 public static string Apellido = @"Apellido";
			 public static string Nombre = @"Nombre";
			 public static string FechaNacimiento = @"FechaNacimiento";
			 public static string Sexo = @"Sexo";
			 public static string Afiliado = @"Afiliado";
			 public static string Nucleo = @"Nucleo";
			 public static string Localidad = @"Localidad";
			 public static string Provincia = @"Provincia";
			 public static string NombreCompleto = @"NombreCompleto";
			 public static string NroAfiliado = @"NroAfiliado";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
