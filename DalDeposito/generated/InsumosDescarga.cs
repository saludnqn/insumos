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
	/// Strongly-typed collection for the InsumosDescarga class.
	/// </summary>
    [Serializable]
	public partial class InsumosDescargaCollection : ActiveList<InsumosDescarga, InsumosDescargaCollection>
	{	   
		public InsumosDescargaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsumosDescargaCollection</returns>
		public InsumosDescargaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsumosDescarga o = this[i];
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
	/// This is an ActiveRecord class which wraps the Insumos_Descargas table.
	/// </summary>
	[Serializable]
	public partial class InsumosDescarga : ActiveRecord<InsumosDescarga>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsumosDescarga()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsumosDescarga(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsumosDescarga(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsumosDescarga(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Insumos_Descargas", TableType.Table, DataService.GetInstance("depProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCodigo = new TableSchema.TableColumn(schema);
				colvarCodigo.ColumnName = "Codigo";
				colvarCodigo.DataType = DbType.Int32;
				colvarCodigo.MaxLength = 0;
				colvarCodigo.AutoIncrement = false;
				colvarCodigo.IsNullable = false;
				colvarCodigo.IsPrimaryKey = true;
				colvarCodigo.IsForeignKey = false;
				colvarCodigo.IsReadOnly = false;
				colvarCodigo.DefaultSetting = @"";
				colvarCodigo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigo);
				
				TableSchema.TableColumn colvarSistema = new TableSchema.TableColumn(schema);
				colvarSistema.ColumnName = "Sistema";
				colvarSistema.DataType = DbType.Byte;
				colvarSistema.MaxLength = 0;
				colvarSistema.AutoIncrement = false;
				colvarSistema.IsNullable = false;
				colvarSistema.IsPrimaryKey = false;
				colvarSistema.IsForeignKey = false;
				colvarSistema.IsReadOnly = false;
				colvarSistema.DefaultSetting = @"";
				colvarSistema.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSistema);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "Fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = false;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarHc = new TableSchema.TableColumn(schema);
				colvarHc.ColumnName = "HC";
				colvarHc.DataType = DbType.AnsiString;
				colvarHc.MaxLength = 50;
				colvarHc.AutoIncrement = false;
				colvarHc.IsNullable = false;
				colvarHc.IsPrimaryKey = false;
				colvarHc.IsForeignKey = false;
				colvarHc.IsReadOnly = false;
				colvarHc.DefaultSetting = @"";
				colvarHc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHc);
				
				TableSchema.TableColumn colvarHospitalOrigen = new TableSchema.TableColumn(schema);
				colvarHospitalOrigen.ColumnName = "HospitalOrigen";
				colvarHospitalOrigen.DataType = DbType.AnsiString;
				colvarHospitalOrigen.MaxLength = 50;
				colvarHospitalOrigen.AutoIncrement = false;
				colvarHospitalOrigen.IsNullable = true;
				colvarHospitalOrigen.IsPrimaryKey = false;
				colvarHospitalOrigen.IsForeignKey = false;
				colvarHospitalOrigen.IsReadOnly = false;
				colvarHospitalOrigen.DefaultSetting = @"";
				colvarHospitalOrigen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHospitalOrigen);
				
				TableSchema.TableColumn colvarServicioOrigen = new TableSchema.TableColumn(schema);
				colvarServicioOrigen.ColumnName = "ServicioOrigen";
				colvarServicioOrigen.DataType = DbType.AnsiString;
				colvarServicioOrigen.MaxLength = 10;
				colvarServicioOrigen.AutoIncrement = false;
				colvarServicioOrigen.IsNullable = true;
				colvarServicioOrigen.IsPrimaryKey = false;
				colvarServicioOrigen.IsForeignKey = false;
				colvarServicioOrigen.IsReadOnly = false;
				colvarServicioOrigen.DefaultSetting = @"";
				colvarServicioOrigen.ForeignKeyTableName = "";
				schema.Columns.Add(colvarServicioOrigen);
				
				TableSchema.TableColumn colvarMedico = new TableSchema.TableColumn(schema);
				colvarMedico.ColumnName = "Medico";
				colvarMedico.DataType = DbType.AnsiString;
				colvarMedico.MaxLength = 100;
				colvarMedico.AutoIncrement = false;
				colvarMedico.IsNullable = false;
				colvarMedico.IsPrimaryKey = false;
				colvarMedico.IsForeignKey = false;
				colvarMedico.IsReadOnly = false;
				colvarMedico.DefaultSetting = @"";
				colvarMedico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMedico);
				
				TableSchema.TableColumn colvarDiagnosticoCausa = new TableSchema.TableColumn(schema);
				colvarDiagnosticoCausa.ColumnName = "Diagnostico_Causa";
				colvarDiagnosticoCausa.DataType = DbType.AnsiString;
				colvarDiagnosticoCausa.MaxLength = 200;
				colvarDiagnosticoCausa.AutoIncrement = false;
				colvarDiagnosticoCausa.IsNullable = true;
				colvarDiagnosticoCausa.IsPrimaryKey = false;
				colvarDiagnosticoCausa.IsForeignKey = false;
				colvarDiagnosticoCausa.IsReadOnly = false;
				colvarDiagnosticoCausa.DefaultSetting = @"";
				colvarDiagnosticoCausa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoCausa);
				
				TableSchema.TableColumn colvarDiagnosticoSubcausa = new TableSchema.TableColumn(schema);
				colvarDiagnosticoSubcausa.ColumnName = "Diagnostico_Subcausa";
				colvarDiagnosticoSubcausa.DataType = DbType.AnsiString;
				colvarDiagnosticoSubcausa.MaxLength = 200;
				colvarDiagnosticoSubcausa.AutoIncrement = false;
				colvarDiagnosticoSubcausa.IsNullable = true;
				colvarDiagnosticoSubcausa.IsPrimaryKey = false;
				colvarDiagnosticoSubcausa.IsForeignKey = false;
				colvarDiagnosticoSubcausa.IsReadOnly = false;
				colvarDiagnosticoSubcausa.DefaultSetting = @"";
				colvarDiagnosticoSubcausa.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnosticoSubcausa);
				
				TableSchema.TableColumn colvarInternacion = new TableSchema.TableColumn(schema);
				colvarInternacion.ColumnName = "Internacion";
				colvarInternacion.DataType = DbType.Boolean;
				colvarInternacion.MaxLength = 0;
				colvarInternacion.AutoIncrement = false;
				colvarInternacion.IsNullable = false;
				colvarInternacion.IsPrimaryKey = false;
				colvarInternacion.IsForeignKey = false;
				colvarInternacion.IsReadOnly = false;
				
						colvarInternacion.DefaultSetting = @"(0)";
				colvarInternacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInternacion);
				
				TableSchema.TableColumn colvarHabitacion = new TableSchema.TableColumn(schema);
				colvarHabitacion.ColumnName = "Habitacion";
				colvarHabitacion.DataType = DbType.AnsiString;
				colvarHabitacion.MaxLength = 10;
				colvarHabitacion.AutoIncrement = false;
				colvarHabitacion.IsNullable = true;
				colvarHabitacion.IsPrimaryKey = false;
				colvarHabitacion.IsForeignKey = false;
				colvarHabitacion.IsReadOnly = false;
				colvarHabitacion.DefaultSetting = @"";
				colvarHabitacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHabitacion);
				
				TableSchema.TableColumn colvarCama = new TableSchema.TableColumn(schema);
				colvarCama.ColumnName = "Cama";
				colvarCama.DataType = DbType.AnsiString;
				colvarCama.MaxLength = 10;
				colvarCama.AutoIncrement = false;
				colvarCama.IsNullable = true;
				colvarCama.IsPrimaryKey = false;
				colvarCama.IsForeignKey = false;
				colvarCama.IsReadOnly = false;
				colvarCama.DefaultSetting = @"";
				colvarCama.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCama);
				
				TableSchema.TableColumn colvarAutorizado = new TableSchema.TableColumn(schema);
				colvarAutorizado.ColumnName = "Autorizado";
				colvarAutorizado.DataType = DbType.Boolean;
				colvarAutorizado.MaxLength = 0;
				colvarAutorizado.AutoIncrement = false;
				colvarAutorizado.IsNullable = false;
				colvarAutorizado.IsPrimaryKey = false;
				colvarAutorizado.IsForeignKey = false;
				colvarAutorizado.IsReadOnly = false;
				
						colvarAutorizado.DefaultSetting = @"(0)";
				colvarAutorizado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAutorizado);
				
				TableSchema.TableColumn colvarAutoridad = new TableSchema.TableColumn(schema);
				colvarAutoridad.ColumnName = "Autoridad";
				colvarAutoridad.DataType = DbType.Int32;
				colvarAutoridad.MaxLength = 0;
				colvarAutoridad.AutoIncrement = false;
				colvarAutoridad.IsNullable = true;
				colvarAutoridad.IsPrimaryKey = false;
				colvarAutoridad.IsForeignKey = false;
				colvarAutoridad.IsReadOnly = false;
				colvarAutoridad.DefaultSetting = @"";
				colvarAutoridad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAutoridad);
				
				TableSchema.TableColumn colvarLoggedUser = new TableSchema.TableColumn(schema);
				colvarLoggedUser.ColumnName = "_loggedUser";
				colvarLoggedUser.DataType = DbType.AnsiString;
				colvarLoggedUser.MaxLength = 100;
				colvarLoggedUser.AutoIncrement = false;
				colvarLoggedUser.IsNullable = true;
				colvarLoggedUser.IsPrimaryKey = false;
				colvarLoggedUser.IsForeignKey = false;
				colvarLoggedUser.IsReadOnly = false;
				colvarLoggedUser.DefaultSetting = @"";
				colvarLoggedUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoggedUser);
				
				TableSchema.TableColumn colvarDespachado = new TableSchema.TableColumn(schema);
				colvarDespachado.ColumnName = "Despachado";
				colvarDespachado.DataType = DbType.Boolean;
				colvarDespachado.MaxLength = 0;
				colvarDespachado.AutoIncrement = false;
				colvarDespachado.IsNullable = false;
				colvarDespachado.IsPrimaryKey = false;
				colvarDespachado.IsForeignKey = false;
				colvarDespachado.IsReadOnly = false;
				
						colvarDespachado.DefaultSetting = @"(0)";
				colvarDespachado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDespachado);
				
				TableSchema.TableColumn colvarFechaDespacho = new TableSchema.TableColumn(schema);
				colvarFechaDespacho.ColumnName = "Fecha_Despacho";
				colvarFechaDespacho.DataType = DbType.DateTime;
				colvarFechaDespacho.MaxLength = 0;
				colvarFechaDespacho.AutoIncrement = false;
				colvarFechaDespacho.IsNullable = true;
				colvarFechaDespacho.IsPrimaryKey = false;
				colvarFechaDespacho.IsForeignKey = false;
				colvarFechaDespacho.IsReadOnly = false;
				colvarFechaDespacho.DefaultSetting = @"";
				colvarFechaDespacho.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaDespacho);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["depProvider"].AddSchema("Insumos_Descargas",schema);
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
		  
		[XmlAttribute("Sistema")]
		[Bindable(true)]
		public byte Sistema 
		{
			get { return GetColumnValue<byte>(Columns.Sistema); }
			set { SetColumnValue(Columns.Sistema, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime Fecha 
		{
			get { return GetColumnValue<DateTime>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Hc")]
		[Bindable(true)]
		public string Hc 
		{
			get { return GetColumnValue<string>(Columns.Hc); }
			set { SetColumnValue(Columns.Hc, value); }
		}
		  
		[XmlAttribute("HospitalOrigen")]
		[Bindable(true)]
		public string HospitalOrigen 
		{
			get { return GetColumnValue<string>(Columns.HospitalOrigen); }
			set { SetColumnValue(Columns.HospitalOrigen, value); }
		}
		  
		[XmlAttribute("ServicioOrigen")]
		[Bindable(true)]
		public string ServicioOrigen 
		{
			get { return GetColumnValue<string>(Columns.ServicioOrigen); }
			set { SetColumnValue(Columns.ServicioOrigen, value); }
		}
		  
		[XmlAttribute("Medico")]
		[Bindable(true)]
		public string Medico 
		{
			get { return GetColumnValue<string>(Columns.Medico); }
			set { SetColumnValue(Columns.Medico, value); }
		}
		  
		[XmlAttribute("DiagnosticoCausa")]
		[Bindable(true)]
		public string DiagnosticoCausa 
		{
			get { return GetColumnValue<string>(Columns.DiagnosticoCausa); }
			set { SetColumnValue(Columns.DiagnosticoCausa, value); }
		}
		  
		[XmlAttribute("DiagnosticoSubcausa")]
		[Bindable(true)]
		public string DiagnosticoSubcausa 
		{
			get { return GetColumnValue<string>(Columns.DiagnosticoSubcausa); }
			set { SetColumnValue(Columns.DiagnosticoSubcausa, value); }
		}
		  
		[XmlAttribute("Internacion")]
		[Bindable(true)]
		public bool Internacion 
		{
			get { return GetColumnValue<bool>(Columns.Internacion); }
			set { SetColumnValue(Columns.Internacion, value); }
		}
		  
		[XmlAttribute("Habitacion")]
		[Bindable(true)]
		public string Habitacion 
		{
			get { return GetColumnValue<string>(Columns.Habitacion); }
			set { SetColumnValue(Columns.Habitacion, value); }
		}
		  
		[XmlAttribute("Cama")]
		[Bindable(true)]
		public string Cama 
		{
			get { return GetColumnValue<string>(Columns.Cama); }
			set { SetColumnValue(Columns.Cama, value); }
		}
		  
		[XmlAttribute("Autorizado")]
		[Bindable(true)]
		public bool Autorizado 
		{
			get { return GetColumnValue<bool>(Columns.Autorizado); }
			set { SetColumnValue(Columns.Autorizado, value); }
		}
		  
		[XmlAttribute("Autoridad")]
		[Bindable(true)]
		public int? Autoridad 
		{
			get { return GetColumnValue<int?>(Columns.Autoridad); }
			set { SetColumnValue(Columns.Autoridad, value); }
		}
		  
		[XmlAttribute("LoggedUser")]
		[Bindable(true)]
		public string LoggedUser 
		{
			get { return GetColumnValue<string>(Columns.LoggedUser); }
			set { SetColumnValue(Columns.LoggedUser, value); }
		}
		  
		[XmlAttribute("Despachado")]
		[Bindable(true)]
		public bool Despachado 
		{
			get { return GetColumnValue<bool>(Columns.Despachado); }
			set { SetColumnValue(Columns.Despachado, value); }
		}
		  
		[XmlAttribute("FechaDespacho")]
		[Bindable(true)]
		public DateTime? FechaDespacho 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaDespacho); }
			set { SetColumnValue(Columns.FechaDespacho, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalDeposito.InsumosDescargasLineaCollection colInsumosDescargasLineas;
		public DalDeposito.InsumosDescargasLineaCollection InsumosDescargasLineas
		{
			get
			{
				if(colInsumosDescargasLineas == null)
				{
					colInsumosDescargasLineas = new DalDeposito.InsumosDescargasLineaCollection().Where(InsumosDescargasLinea.Columns.Descarga, Codigo).Load();
					colInsumosDescargasLineas.ListChanged += new ListChangedEventHandler(colInsumosDescargasLineas_ListChanged);
				}
				return colInsumosDescargasLineas;			
			}
			set 
			{ 
					colInsumosDescargasLineas = value; 
					colInsumosDescargasLineas.ListChanged += new ListChangedEventHandler(colInsumosDescargasLineas_ListChanged);
			}
		}
		
		void colInsumosDescargasLineas_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsumosDescargasLineas[e.NewIndex].Descarga = Codigo;
		    }
		}
				
		private DalDeposito.InsumosValeCollection colInsumosVales;
		public DalDeposito.InsumosValeCollection InsumosVales
		{
			get
			{
				if(colInsumosVales == null)
				{
					colInsumosVales = new DalDeposito.InsumosValeCollection().Where(InsumosVale.Columns.Descarga, Codigo).Load();
					colInsumosVales.ListChanged += new ListChangedEventHandler(colInsumosVales_ListChanged);
				}
				return colInsumosVales;			
			}
			set 
			{ 
					colInsumosVales = value; 
					colInsumosVales.ListChanged += new ListChangedEventHandler(colInsumosVales_ListChanged);
			}
		}
		
		void colInsumosVales_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsumosVales[e.NewIndex].Descarga = Codigo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varCodigo,byte varSistema,DateTime varFecha,string varHc,string varHospitalOrigen,string varServicioOrigen,string varMedico,string varDiagnosticoCausa,string varDiagnosticoSubcausa,bool varInternacion,string varHabitacion,string varCama,bool varAutorizado,int? varAutoridad,string varLoggedUser,bool varDespachado,DateTime? varFechaDespacho)
		{
			InsumosDescarga item = new InsumosDescarga();
			
			item.Codigo = varCodigo;
			
			item.Sistema = varSistema;
			
			item.Fecha = varFecha;
			
			item.Hc = varHc;
			
			item.HospitalOrigen = varHospitalOrigen;
			
			item.ServicioOrigen = varServicioOrigen;
			
			item.Medico = varMedico;
			
			item.DiagnosticoCausa = varDiagnosticoCausa;
			
			item.DiagnosticoSubcausa = varDiagnosticoSubcausa;
			
			item.Internacion = varInternacion;
			
			item.Habitacion = varHabitacion;
			
			item.Cama = varCama;
			
			item.Autorizado = varAutorizado;
			
			item.Autoridad = varAutoridad;
			
			item.LoggedUser = varLoggedUser;
			
			item.Despachado = varDespachado;
			
			item.FechaDespacho = varFechaDespacho;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCodigo,byte varSistema,DateTime varFecha,string varHc,string varHospitalOrigen,string varServicioOrigen,string varMedico,string varDiagnosticoCausa,string varDiagnosticoSubcausa,bool varInternacion,string varHabitacion,string varCama,bool varAutorizado,int? varAutoridad,string varLoggedUser,bool varDespachado,DateTime? varFechaDespacho)
		{
			InsumosDescarga item = new InsumosDescarga();
			
				item.Codigo = varCodigo;
			
				item.Sistema = varSistema;
			
				item.Fecha = varFecha;
			
				item.Hc = varHc;
			
				item.HospitalOrigen = varHospitalOrigen;
			
				item.ServicioOrigen = varServicioOrigen;
			
				item.Medico = varMedico;
			
				item.DiagnosticoCausa = varDiagnosticoCausa;
			
				item.DiagnosticoSubcausa = varDiagnosticoSubcausa;
			
				item.Internacion = varInternacion;
			
				item.Habitacion = varHabitacion;
			
				item.Cama = varCama;
			
				item.Autorizado = varAutorizado;
			
				item.Autoridad = varAutoridad;
			
				item.LoggedUser = varLoggedUser;
			
				item.Despachado = varDespachado;
			
				item.FechaDespacho = varFechaDespacho;
			
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
        
        
        
        public static TableSchema.TableColumn SistemaColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn HcColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn HospitalOrigenColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ServicioOrigenColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn MedicoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoCausaColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoSubcausaColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn InternacionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn HabitacionColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CamaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AutorizadoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn AutoridadColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn LoggedUserColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn DespachadoColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaDespachoColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Codigo = @"Codigo";
			 public static string Sistema = @"Sistema";
			 public static string Fecha = @"Fecha";
			 public static string Hc = @"HC";
			 public static string HospitalOrigen = @"HospitalOrigen";
			 public static string ServicioOrigen = @"ServicioOrigen";
			 public static string Medico = @"Medico";
			 public static string DiagnosticoCausa = @"Diagnostico_Causa";
			 public static string DiagnosticoSubcausa = @"Diagnostico_Subcausa";
			 public static string Internacion = @"Internacion";
			 public static string Habitacion = @"Habitacion";
			 public static string Cama = @"Cama";
			 public static string Autorizado = @"Autorizado";
			 public static string Autoridad = @"Autoridad";
			 public static string LoggedUser = @"_loggedUser";
			 public static string Despachado = @"Despachado";
			 public static string FechaDespacho = @"Fecha_Despacho";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colInsumosDescargasLineas != null)
                {
                    foreach (DalDeposito.InsumosDescargasLinea item in colInsumosDescargasLineas)
                    {
                        if (item.Descarga != Codigo)
                        {
                            item.Descarga = Codigo;
                        }
                    }
               }
		
                if (colInsumosVales != null)
                {
                    foreach (DalDeposito.InsumosVale item in colInsumosVales)
                    {
                        if (item.Descarga != Codigo)
                        {
                            item.Descarga = Codigo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colInsumosDescargasLineas != null)
                {
                    colInsumosDescargasLineas.SaveAll();
               }
		
                if (colInsumosVales != null)
                {
                    colInsumosVales.SaveAll();
               }
		}
        #endregion
	}
}
