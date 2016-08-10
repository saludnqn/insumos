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
	/// Strongly-typed collection for the InsumosProvisionesAgente class.
	/// </summary>
    [Serializable]
	public partial class InsumosProvisionesAgenteCollection : ActiveList<InsumosProvisionesAgente, InsumosProvisionesAgenteCollection>
	{	   
		public InsumosProvisionesAgenteCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsumosProvisionesAgenteCollection</returns>
		public InsumosProvisionesAgenteCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsumosProvisionesAgente o = this[i];
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
	/// This is an ActiveRecord class which wraps the Insumos_Provisiones_Agentes table.
	/// </summary>
	[Serializable]
	public partial class InsumosProvisionesAgente : ActiveRecord<InsumosProvisionesAgente>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsumosProvisionesAgente()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsumosProvisionesAgente(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsumosProvisionesAgente(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsumosProvisionesAgente(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Insumos_Provisiones_Agentes", TableType.Table, DataService.GetInstance("depProvider"));
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
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "Tipo";
				colvarTipo.DataType = DbType.Int32;
				colvarTipo.MaxLength = 0;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = false;
				colvarTipo.IsPrimaryKey = false;
				colvarTipo.IsForeignKey = true;
				colvarTipo.IsReadOnly = false;
				
						colvarTipo.DefaultSetting = @"((2))";
				
					colvarTipo.ForeignKeyTableName = "Insumos_Provisiones_Tipos";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 500;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarDireccion = new TableSchema.TableColumn(schema);
				colvarDireccion.ColumnName = "Direccion";
				colvarDireccion.DataType = DbType.AnsiString;
				colvarDireccion.MaxLength = 500;
				colvarDireccion.AutoIncrement = false;
				colvarDireccion.IsNullable = true;
				colvarDireccion.IsPrimaryKey = false;
				colvarDireccion.IsForeignKey = false;
				colvarDireccion.IsReadOnly = false;
				colvarDireccion.DefaultSetting = @"";
				colvarDireccion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDireccion);
				
				TableSchema.TableColumn colvarCuit = new TableSchema.TableColumn(schema);
				colvarCuit.ColumnName = "Cuit";
				colvarCuit.DataType = DbType.AnsiString;
				colvarCuit.MaxLength = 500;
				colvarCuit.AutoIncrement = false;
				colvarCuit.IsNullable = true;
				colvarCuit.IsPrimaryKey = false;
				colvarCuit.IsForeignKey = false;
				colvarCuit.IsReadOnly = false;
				colvarCuit.DefaultSetting = @"";
				colvarCuit.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCuit);
				
				TableSchema.TableColumn colvarDocumento = new TableSchema.TableColumn(schema);
				colvarDocumento.ColumnName = "Documento";
				colvarDocumento.DataType = DbType.AnsiString;
				colvarDocumento.MaxLength = 500;
				colvarDocumento.AutoIncrement = false;
				colvarDocumento.IsNullable = true;
				colvarDocumento.IsPrimaryKey = false;
				colvarDocumento.IsForeignKey = false;
				colvarDocumento.IsReadOnly = false;
				colvarDocumento.DefaultSetting = @"";
				colvarDocumento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumento);
				
				TableSchema.TableColumn colvarCiudad = new TableSchema.TableColumn(schema);
				colvarCiudad.ColumnName = "Ciudad";
				colvarCiudad.DataType = DbType.AnsiString;
				colvarCiudad.MaxLength = 500;
				colvarCiudad.AutoIncrement = false;
				colvarCiudad.IsNullable = true;
				colvarCiudad.IsPrimaryKey = false;
				colvarCiudad.IsForeignKey = false;
				colvarCiudad.IsReadOnly = false;
				colvarCiudad.DefaultSetting = @"";
				colvarCiudad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCiudad);
				
				TableSchema.TableColumn colvarPais = new TableSchema.TableColumn(schema);
				colvarPais.ColumnName = "Pais";
				colvarPais.DataType = DbType.AnsiString;
				colvarPais.MaxLength = 500;
				colvarPais.AutoIncrement = false;
				colvarPais.IsNullable = true;
				colvarPais.IsPrimaryKey = false;
				colvarPais.IsForeignKey = false;
				colvarPais.IsReadOnly = false;
				
						colvarPais.DefaultSetting = @"('Argentina')";
				colvarPais.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPais);
				
				TableSchema.TableColumn colvarTelefono = new TableSchema.TableColumn(schema);
				colvarTelefono.ColumnName = "Telefono";
				colvarTelefono.DataType = DbType.AnsiString;
				colvarTelefono.MaxLength = 500;
				colvarTelefono.AutoIncrement = false;
				colvarTelefono.IsNullable = true;
				colvarTelefono.IsPrimaryKey = false;
				colvarTelefono.IsForeignKey = false;
				colvarTelefono.IsReadOnly = false;
				colvarTelefono.DefaultSetting = @"";
				colvarTelefono.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTelefono);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "Observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 500;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["depProvider"].AddSchema("Insumos_Provisiones_Agentes",schema);
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
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public int Tipo 
		{
			get { return GetColumnValue<int>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("Direccion")]
		[Bindable(true)]
		public string Direccion 
		{
			get { return GetColumnValue<string>(Columns.Direccion); }
			set { SetColumnValue(Columns.Direccion, value); }
		}
		  
		[XmlAttribute("Cuit")]
		[Bindable(true)]
		public string Cuit 
		{
			get { return GetColumnValue<string>(Columns.Cuit); }
			set { SetColumnValue(Columns.Cuit, value); }
		}
		  
		[XmlAttribute("Documento")]
		[Bindable(true)]
		public string Documento 
		{
			get { return GetColumnValue<string>(Columns.Documento); }
			set { SetColumnValue(Columns.Documento, value); }
		}
		  
		[XmlAttribute("Ciudad")]
		[Bindable(true)]
		public string Ciudad 
		{
			get { return GetColumnValue<string>(Columns.Ciudad); }
			set { SetColumnValue(Columns.Ciudad, value); }
		}
		  
		[XmlAttribute("Pais")]
		[Bindable(true)]
		public string Pais 
		{
			get { return GetColumnValue<string>(Columns.Pais); }
			set { SetColumnValue(Columns.Pais, value); }
		}
		  
		[XmlAttribute("Telefono")]
		[Bindable(true)]
		public string Telefono 
		{
			get { return GetColumnValue<string>(Columns.Telefono); }
			set { SetColumnValue(Columns.Telefono, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalDeposito.InsumosPorProveedorCollection colInsumosPorProveedorRecords;
		public DalDeposito.InsumosPorProveedorCollection InsumosPorProveedorRecords
		{
			get
			{
				if(colInsumosPorProveedorRecords == null)
				{
					colInsumosPorProveedorRecords = new DalDeposito.InsumosPorProveedorCollection().Where(InsumosPorProveedor.Columns.Proveedor, Codigo).Load();
					colInsumosPorProveedorRecords.ListChanged += new ListChangedEventHandler(colInsumosPorProveedorRecords_ListChanged);
				}
				return colInsumosPorProveedorRecords;			
			}
			set 
			{ 
					colInsumosPorProveedorRecords = value; 
					colInsumosPorProveedorRecords.ListChanged += new ListChangedEventHandler(colInsumosPorProveedorRecords_ListChanged);
			}
		}
		
		void colInsumosPorProveedorRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsumosPorProveedorRecords[e.NewIndex].Proveedor = Codigo;
		    }
		}
				
		private DalDeposito.InsumosProvisioneCollection colInsumosProvisiones;
		public DalDeposito.InsumosProvisioneCollection InsumosProvisiones
		{
			get
			{
				if(colInsumosProvisiones == null)
				{
					colInsumosProvisiones = new DalDeposito.InsumosProvisioneCollection().Where(InsumosProvisione.Columns.Agente, Codigo).Load();
					colInsumosProvisiones.ListChanged += new ListChangedEventHandler(colInsumosProvisiones_ListChanged);
				}
				return colInsumosProvisiones;			
			}
			set 
			{ 
					colInsumosProvisiones = value; 
					colInsumosProvisiones.ListChanged += new ListChangedEventHandler(colInsumosProvisiones_ListChanged);
			}
		}
		
		void colInsumosProvisiones_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsumosProvisiones[e.NewIndex].Agente = Codigo;
		    }
		}
				
		private DalDeposito.InsumosProvisioneCollection colInsumosProvisionesFromInsumosProvisionesAgente;
		public DalDeposito.InsumosProvisioneCollection InsumosProvisionesFromInsumosProvisionesAgente
		{
			get
			{
				if(colInsumosProvisionesFromInsumosProvisionesAgente == null)
				{
					colInsumosProvisionesFromInsumosProvisionesAgente = new DalDeposito.InsumosProvisioneCollection().Where(InsumosProvisione.Columns.Agente, Codigo).Load();
					colInsumosProvisionesFromInsumosProvisionesAgente.ListChanged += new ListChangedEventHandler(colInsumosProvisionesFromInsumosProvisionesAgente_ListChanged);
				}
				return colInsumosProvisionesFromInsumosProvisionesAgente;			
			}
			set 
			{ 
					colInsumosProvisionesFromInsumosProvisionesAgente = value; 
					colInsumosProvisionesFromInsumosProvisionesAgente.ListChanged += new ListChangedEventHandler(colInsumosProvisionesFromInsumosProvisionesAgente_ListChanged);
			}
		}
		
		void colInsumosProvisionesFromInsumosProvisionesAgente_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsumosProvisionesFromInsumosProvisionesAgente[e.NewIndex].Agente = Codigo;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a InsumosProvisionesTipo ActiveRecord object related to this InsumosProvisionesAgente
		/// 
		/// </summary>
		public DalDeposito.InsumosProvisionesTipo InsumosProvisionesTipo
		{
			get { return DalDeposito.InsumosProvisionesTipo.FetchByID(this.Tipo); }
			set { SetColumnValue("Tipo", value.Codigo); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public DalDeposito.InsumoCollection GetInsumoCollection() { return InsumosProvisionesAgente.GetInsumoCollection(this.Codigo); }
		public static DalDeposito.InsumoCollection GetInsumoCollection(int varCodigo)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Insumos] INNER JOIN [Insumos_Por_Proveedor] ON [Insumos].[Codigo] = [Insumos_Por_Proveedor].[Insumo] WHERE [Insumos_Por_Proveedor].[Proveedor] = @Proveedor", InsumosProvisionesAgente.Schema.Provider.Name);
			cmd.AddParameter("@Proveedor", varCodigo, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			InsumoCollection coll = new InsumoCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveInsumoMap(int varCodigo, InsumoCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Insumos_Por_Proveedor] WHERE [Insumos_Por_Proveedor].[Proveedor] = @Proveedor", InsumosProvisionesAgente.Schema.Provider.Name);
			cmdDel.AddParameter("@Proveedor", varCodigo, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Insumo item in items)
			{
				InsumosPorProveedor varInsumosPorProveedor = new InsumosPorProveedor();
				varInsumosPorProveedor.SetColumnValue("Proveedor", varCodigo);
				varInsumosPorProveedor.SetColumnValue("Insumo", item.GetPrimaryKeyValue());
				varInsumosPorProveedor.Save();
			}
		}
		public static void SaveInsumoMap(int varCodigo, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Insumos_Por_Proveedor] WHERE [Insumos_Por_Proveedor].[Proveedor] = @Proveedor", InsumosProvisionesAgente.Schema.Provider.Name);
			cmdDel.AddParameter("@Proveedor", varCodigo, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					InsumosPorProveedor varInsumosPorProveedor = new InsumosPorProveedor();
					varInsumosPorProveedor.SetColumnValue("Proveedor", varCodigo);
					varInsumosPorProveedor.SetColumnValue("Insumo", l.Value);
					varInsumosPorProveedor.Save();
				}
			}
		}
		public static void SaveInsumoMap(int varCodigo , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Insumos_Por_Proveedor] WHERE [Insumos_Por_Proveedor].[Proveedor] = @Proveedor", InsumosProvisionesAgente.Schema.Provider.Name);
			cmdDel.AddParameter("@Proveedor", varCodigo, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				InsumosPorProveedor varInsumosPorProveedor = new InsumosPorProveedor();
				varInsumosPorProveedor.SetColumnValue("Proveedor", varCodigo);
				varInsumosPorProveedor.SetColumnValue("Insumo", item);
				varInsumosPorProveedor.Save();
			}
		}
		
		public static void DeleteInsumoMap(int varCodigo) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Insumos_Por_Proveedor] WHERE [Insumos_Por_Proveedor].[Proveedor] = @Proveedor", InsumosProvisionesAgente.Schema.Provider.Name);
			cmdDel.AddParameter("@Proveedor", varCodigo, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTipo,string varNombre,string varDireccion,string varCuit,string varDocumento,string varCiudad,string varPais,string varTelefono,string varObservaciones)
		{
			InsumosProvisionesAgente item = new InsumosProvisionesAgente();
			
			item.Tipo = varTipo;
			
			item.Nombre = varNombre;
			
			item.Direccion = varDireccion;
			
			item.Cuit = varCuit;
			
			item.Documento = varDocumento;
			
			item.Ciudad = varCiudad;
			
			item.Pais = varPais;
			
			item.Telefono = varTelefono;
			
			item.Observaciones = varObservaciones;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCodigo,int varTipo,string varNombre,string varDireccion,string varCuit,string varDocumento,string varCiudad,string varPais,string varTelefono,string varObservaciones)
		{
			InsumosProvisionesAgente item = new InsumosProvisionesAgente();
			
				item.Codigo = varCodigo;
			
				item.Tipo = varTipo;
			
				item.Nombre = varNombre;
			
				item.Direccion = varDireccion;
			
				item.Cuit = varCuit;
			
				item.Documento = varDocumento;
			
				item.Ciudad = varCiudad;
			
				item.Pais = varPais;
			
				item.Telefono = varTelefono;
			
				item.Observaciones = varObservaciones;
			
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
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DireccionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CuitColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DocumentoColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CiudadColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PaisColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TelefonoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Codigo = @"Codigo";
			 public static string Tipo = @"Tipo";
			 public static string Nombre = @"Nombre";
			 public static string Direccion = @"Direccion";
			 public static string Cuit = @"Cuit";
			 public static string Documento = @"Documento";
			 public static string Ciudad = @"Ciudad";
			 public static string Pais = @"Pais";
			 public static string Telefono = @"Telefono";
			 public static string Observaciones = @"Observaciones";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colInsumosPorProveedorRecords != null)
                {
                    foreach (DalDeposito.InsumosPorProveedor item in colInsumosPorProveedorRecords)
                    {
                        if (item.Proveedor != Codigo)
                        {
                            item.Proveedor = Codigo;
                        }
                    }
               }
		
                if (colInsumosProvisiones != null)
                {
                    foreach (DalDeposito.InsumosProvisione item in colInsumosProvisiones)
                    {
                        if (item.Agente != Codigo)
                        {
                            item.Agente = Codigo;
                        }
                    }
               }
		
                if (colInsumosProvisionesFromInsumosProvisionesAgente != null)
                {
                    foreach (DalDeposito.InsumosProvisione item in colInsumosProvisionesFromInsumosProvisionesAgente)
                    {
                        if (item.Agente != Codigo)
                        {
                            item.Agente = Codigo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colInsumosPorProveedorRecords != null)
                {
                    colInsumosPorProveedorRecords.SaveAll();
               }
		
                if (colInsumosProvisiones != null)
                {
                    colInsumosProvisiones.SaveAll();
               }
		
                if (colInsumosProvisionesFromInsumosProvisionesAgente != null)
                {
                    colInsumosProvisionesFromInsumosProvisionesAgente.SaveAll();
               }
		}
        #endregion
	}
}
