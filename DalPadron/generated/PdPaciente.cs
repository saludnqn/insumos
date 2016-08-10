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
	/// Strongly-typed collection for the PdPaciente class.
	/// </summary>
    [Serializable]
	public partial class PdPacienteCollection : ActiveList<PdPaciente, PdPacienteCollection>
	{	   
		public PdPacienteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PdPacienteCollection</returns>
		public PdPacienteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PdPaciente o = this[i];
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
	/// This is an ActiveRecord class which wraps the Pd_Paciente table.
	/// </summary>
	[Serializable]
	public partial class PdPaciente : ActiveRecord<PdPaciente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PdPaciente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PdPaciente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PdPaciente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PdPaciente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Pd_Paciente", TableType.Table, DataService.GetInstance("padronProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPdPaciente.ColumnName = "id_PdPaciente";
				colvarIdPdPaciente.DataType = DbType.Int32;
				colvarIdPdPaciente.MaxLength = 0;
				colvarIdPdPaciente.AutoIncrement = true;
				colvarIdPdPaciente.IsNullable = false;
				colvarIdPdPaciente.IsPrimaryKey = true;
				colvarIdPdPaciente.IsForeignKey = false;
				colvarIdPdPaciente.IsReadOnly = false;
				colvarIdPdPaciente.DefaultSetting = @"";
				colvarIdPdPaciente.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPdPaciente);
				
				TableSchema.TableColumn colvarNumeroDocumento = new TableSchema.TableColumn(schema);
				colvarNumeroDocumento.ColumnName = "numeroDocumento";
				colvarNumeroDocumento.DataType = DbType.Int32;
				colvarNumeroDocumento.MaxLength = 0;
				colvarNumeroDocumento.AutoIncrement = false;
				colvarNumeroDocumento.IsNullable = true;
				colvarNumeroDocumento.IsPrimaryKey = false;
				colvarNumeroDocumento.IsForeignKey = false;
				colvarNumeroDocumento.IsReadOnly = false;
				colvarNumeroDocumento.DefaultSetting = @"";
				colvarNumeroDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDocumento);
				
				TableSchema.TableColumn colvarApellido = new TableSchema.TableColumn(schema);
				colvarApellido.ColumnName = "apellido";
				colvarApellido.DataType = DbType.String;
				colvarApellido.MaxLength = 100;
				colvarApellido.AutoIncrement = false;
				colvarApellido.IsNullable = true;
				colvarApellido.IsPrimaryKey = false;
				colvarApellido.IsForeignKey = false;
				colvarApellido.IsReadOnly = false;
				colvarApellido.DefaultSetting = @"";
				colvarApellido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApellido);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdSexo = new TableSchema.TableColumn(schema);
				colvarIdSexo.ColumnName = "idSexo";
				colvarIdSexo.DataType = DbType.Int32;
				colvarIdSexo.MaxLength = 0;
				colvarIdSexo.AutoIncrement = false;
				colvarIdSexo.IsNullable = true;
				colvarIdSexo.IsPrimaryKey = false;
				colvarIdSexo.IsForeignKey = false;
				colvarIdSexo.IsReadOnly = false;
				colvarIdSexo.DefaultSetting = @"";
				colvarIdSexo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSexo);
				
				TableSchema.TableColumn colvarFechaNacimiento = new TableSchema.TableColumn(schema);
				colvarFechaNacimiento.ColumnName = "fechaNacimiento";
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
				
				TableSchema.TableColumn colvarInformacionContacto = new TableSchema.TableColumn(schema);
				colvarInformacionContacto.ColumnName = "informacionContacto";
				colvarInformacionContacto.DataType = DbType.String;
				colvarInformacionContacto.MaxLength = 800;
				colvarInformacionContacto.AutoIncrement = false;
				colvarInformacionContacto.IsNullable = true;
				colvarInformacionContacto.IsPrimaryKey = false;
				colvarInformacionContacto.IsForeignKey = false;
				colvarInformacionContacto.IsReadOnly = false;
				colvarInformacionContacto.DefaultSetting = @"";
				colvarInformacionContacto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInformacionContacto);
				
				TableSchema.TableColumn colvarFechaActualizacion = new TableSchema.TableColumn(schema);
				colvarFechaActualizacion.ColumnName = "fechaActualizacion";
				colvarFechaActualizacion.DataType = DbType.DateTime;
				colvarFechaActualizacion.MaxLength = 0;
				colvarFechaActualizacion.AutoIncrement = false;
				colvarFechaActualizacion.IsNullable = true;
				colvarFechaActualizacion.IsPrimaryKey = false;
				colvarFechaActualizacion.IsForeignKey = false;
				colvarFechaActualizacion.IsReadOnly = false;
				colvarFechaActualizacion.DefaultSetting = @"";
				colvarFechaActualizacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaActualizacion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["padronProvider"].AddSchema("Pd_Paciente",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPdPaciente")]
		[Bindable(true)]
		public int IdPdPaciente 
		{
			get { return GetColumnValue<int>(Columns.IdPdPaciente); }
			set { SetColumnValue(Columns.IdPdPaciente, value); }
		}
		  
		[XmlAttribute("NumeroDocumento")]
		[Bindable(true)]
		public int? NumeroDocumento 
		{
			get { return GetColumnValue<int?>(Columns.NumeroDocumento); }
			set { SetColumnValue(Columns.NumeroDocumento, value); }
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
		  
		[XmlAttribute("IdSexo")]
		[Bindable(true)]
		public int? IdSexo 
		{
			get { return GetColumnValue<int?>(Columns.IdSexo); }
			set { SetColumnValue(Columns.IdSexo, value); }
		}
		  
		[XmlAttribute("FechaNacimiento")]
		[Bindable(true)]
		public DateTime? FechaNacimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaNacimiento); }
			set { SetColumnValue(Columns.FechaNacimiento, value); }
		}
		  
		[XmlAttribute("InformacionContacto")]
		[Bindable(true)]
		public string InformacionContacto 
		{
			get { return GetColumnValue<string>(Columns.InformacionContacto); }
			set { SetColumnValue(Columns.InformacionContacto, value); }
		}
		  
		[XmlAttribute("FechaActualizacion")]
		[Bindable(true)]
		public DateTime? FechaActualizacion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaActualizacion); }
			set { SetColumnValue(Columns.FechaActualizacion, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varNumeroDocumento,string varApellido,string varNombre,int? varIdSexo,DateTime? varFechaNacimiento,string varInformacionContacto,DateTime? varFechaActualizacion)
		{
			PdPaciente item = new PdPaciente();
			
			item.NumeroDocumento = varNumeroDocumento;
			
			item.Apellido = varApellido;
			
			item.Nombre = varNombre;
			
			item.IdSexo = varIdSexo;
			
			item.FechaNacimiento = varFechaNacimiento;
			
			item.InformacionContacto = varInformacionContacto;
			
			item.FechaActualizacion = varFechaActualizacion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPdPaciente,int? varNumeroDocumento,string varApellido,string varNombre,int? varIdSexo,DateTime? varFechaNacimiento,string varInformacionContacto,DateTime? varFechaActualizacion)
		{
			PdPaciente item = new PdPaciente();
			
				item.IdPdPaciente = varIdPdPaciente;
			
				item.NumeroDocumento = varNumeroDocumento;
			
				item.Apellido = varApellido;
			
				item.Nombre = varNombre;
			
				item.IdSexo = varIdSexo;
			
				item.FechaNacimiento = varFechaNacimiento;
			
				item.InformacionContacto = varInformacionContacto;
			
				item.FechaActualizacion = varFechaActualizacion;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPdPacienteColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDocumentoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ApellidoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdSexoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaNacimientoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn InformacionContactoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaActualizacionColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPdPaciente = @"id_PdPaciente";
			 public static string NumeroDocumento = @"numeroDocumento";
			 public static string Apellido = @"apellido";
			 public static string Nombre = @"nombre";
			 public static string IdSexo = @"idSexo";
			 public static string FechaNacimiento = @"fechaNacimiento";
			 public static string InformacionContacto = @"informacionContacto";
			 public static string FechaActualizacion = @"fechaActualizacion";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
