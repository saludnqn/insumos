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
	/// Strongly-typed collection for the InsumosProvisionesLinea class.
	/// </summary>
    [Serializable]
	public partial class InsumosProvisionesLineaCollection : ActiveList<InsumosProvisionesLinea, InsumosProvisionesLineaCollection>
	{	   
		public InsumosProvisionesLineaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsumosProvisionesLineaCollection</returns>
		public InsumosProvisionesLineaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsumosProvisionesLinea o = this[i];
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
	/// This is an ActiveRecord class which wraps the Insumos_Provisiones_Lineas table.
	/// </summary>
	[Serializable]
	public partial class InsumosProvisionesLinea : ActiveRecord<InsumosProvisionesLinea>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsumosProvisionesLinea()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsumosProvisionesLinea(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsumosProvisionesLinea(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsumosProvisionesLinea(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Insumos_Provisiones_Lineas", TableType.Table, DataService.GetInstance("depProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProvision = new TableSchema.TableColumn(schema);
				colvarProvision.ColumnName = "Provision";
				colvarProvision.DataType = DbType.Int32;
				colvarProvision.MaxLength = 0;
				colvarProvision.AutoIncrement = false;
				colvarProvision.IsNullable = false;
				colvarProvision.IsPrimaryKey = false;
				colvarProvision.IsForeignKey = true;
				colvarProvision.IsReadOnly = false;
				colvarProvision.DefaultSetting = @"";
				
					colvarProvision.ForeignKeyTableName = "Insumos_Provisiones";
				schema.Columns.Add(colvarProvision);
				
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
				
				TableSchema.TableColumn colvarMultiplicador = new TableSchema.TableColumn(schema);
				colvarMultiplicador.ColumnName = "Multiplicador";
				colvarMultiplicador.DataType = DbType.Int32;
				colvarMultiplicador.MaxLength = 0;
				colvarMultiplicador.AutoIncrement = false;
				colvarMultiplicador.IsNullable = false;
				colvarMultiplicador.IsPrimaryKey = false;
				colvarMultiplicador.IsForeignKey = false;
				colvarMultiplicador.IsReadOnly = false;
				
						colvarMultiplicador.DefaultSetting = @"((1))";
				colvarMultiplicador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMultiplicador);
				
				TableSchema.TableColumn colvarLote = new TableSchema.TableColumn(schema);
				colvarLote.ColumnName = "Lote";
				colvarLote.DataType = DbType.AnsiString;
				colvarLote.MaxLength = 50;
				colvarLote.AutoIncrement = false;
				colvarLote.IsNullable = true;
				colvarLote.IsPrimaryKey = false;
				colvarLote.IsForeignKey = false;
				colvarLote.IsReadOnly = false;
				colvarLote.DefaultSetting = @"";
				colvarLote.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLote);
				
				TableSchema.TableColumn colvarVencimiento = new TableSchema.TableColumn(schema);
				colvarVencimiento.ColumnName = "Vencimiento";
				colvarVencimiento.DataType = DbType.DateTime;
				colvarVencimiento.MaxLength = 0;
				colvarVencimiento.AutoIncrement = false;
				colvarVencimiento.IsNullable = true;
				colvarVencimiento.IsPrimaryKey = false;
				colvarVencimiento.IsForeignKey = false;
				colvarVencimiento.IsReadOnly = false;
				colvarVencimiento.DefaultSetting = @"";
				colvarVencimiento.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVencimiento);
				
				TableSchema.TableColumn colvarVencimientoOriginal = new TableSchema.TableColumn(schema);
				colvarVencimientoOriginal.ColumnName = "Vencimiento_Original";
				colvarVencimientoOriginal.DataType = DbType.DateTime;
				colvarVencimientoOriginal.MaxLength = 0;
				colvarVencimientoOriginal.AutoIncrement = false;
				colvarVencimientoOriginal.IsNullable = true;
				colvarVencimientoOriginal.IsPrimaryKey = false;
				colvarVencimientoOriginal.IsForeignKey = false;
				colvarVencimientoOriginal.IsReadOnly = false;
				colvarVencimientoOriginal.DefaultSetting = @"";
				colvarVencimientoOriginal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVencimientoOriginal);
				
				TableSchema.TableColumn colvarCostoUnitario = new TableSchema.TableColumn(schema);
				colvarCostoUnitario.ColumnName = "Costo_unitario";
				colvarCostoUnitario.DataType = DbType.Single;
				colvarCostoUnitario.MaxLength = 0;
				colvarCostoUnitario.AutoIncrement = false;
				colvarCostoUnitario.IsNullable = true;
				colvarCostoUnitario.IsPrimaryKey = false;
				colvarCostoUnitario.IsForeignKey = false;
				colvarCostoUnitario.IsReadOnly = false;
				
						colvarCostoUnitario.DefaultSetting = @"((0))";
				colvarCostoUnitario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostoUnitario);
				
				TableSchema.TableColumn colvarUbicacion = new TableSchema.TableColumn(schema);
				colvarUbicacion.ColumnName = "Ubicacion";
				colvarUbicacion.DataType = DbType.AnsiString;
				colvarUbicacion.MaxLength = 50;
				colvarUbicacion.AutoIncrement = false;
				colvarUbicacion.IsNullable = true;
				colvarUbicacion.IsPrimaryKey = false;
				colvarUbicacion.IsForeignKey = false;
				colvarUbicacion.IsReadOnly = false;
				colvarUbicacion.DefaultSetting = @"";
				colvarUbicacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUbicacion);
				
				TableSchema.TableColumn colvarCantidadDisponible = new TableSchema.TableColumn(schema);
				colvarCantidadDisponible.ColumnName = "Cantidad_Disponible";
				colvarCantidadDisponible.DataType = DbType.Int32;
				colvarCantidadDisponible.MaxLength = 0;
				colvarCantidadDisponible.AutoIncrement = false;
				colvarCantidadDisponible.IsNullable = false;
				colvarCantidadDisponible.IsPrimaryKey = false;
				colvarCantidadDisponible.IsForeignKey = false;
				colvarCantidadDisponible.IsReadOnly = false;
				colvarCantidadDisponible.DefaultSetting = @"";
				colvarCantidadDisponible.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCantidadDisponible);
				
				TableSchema.TableColumn colvarRenglon = new TableSchema.TableColumn(schema);
				colvarRenglon.ColumnName = "Renglon";
				colvarRenglon.DataType = DbType.Int32;
				colvarRenglon.MaxLength = 0;
				colvarRenglon.AutoIncrement = false;
				colvarRenglon.IsNullable = true;
				colvarRenglon.IsPrimaryKey = false;
				colvarRenglon.IsForeignKey = false;
				colvarRenglon.IsReadOnly = false;
				colvarRenglon.DefaultSetting = @"";
				colvarRenglon.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRenglon);
				
				TableSchema.TableColumn colvarDescripcionExtendida = new TableSchema.TableColumn(schema);
				colvarDescripcionExtendida.ColumnName = "DescripcionExtendida";
				colvarDescripcionExtendida.DataType = DbType.AnsiString;
				colvarDescripcionExtendida.MaxLength = 2000;
				colvarDescripcionExtendida.AutoIncrement = false;
				colvarDescripcionExtendida.IsNullable = true;
				colvarDescripcionExtendida.IsPrimaryKey = false;
				colvarDescripcionExtendida.IsForeignKey = false;
				colvarDescripcionExtendida.IsReadOnly = false;
				colvarDescripcionExtendida.DefaultSetting = @"";
				colvarDescripcionExtendida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescripcionExtendida);
				
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
				
				TableSchema.TableColumn colvarLineaOriginal = new TableSchema.TableColumn(schema);
				colvarLineaOriginal.ColumnName = "Linea_Original";
				colvarLineaOriginal.DataType = DbType.Int32;
				colvarLineaOriginal.MaxLength = 0;
				colvarLineaOriginal.AutoIncrement = false;
				colvarLineaOriginal.IsNullable = true;
				colvarLineaOriginal.IsPrimaryKey = false;
				colvarLineaOriginal.IsForeignKey = true;
				colvarLineaOriginal.IsReadOnly = false;
				colvarLineaOriginal.DefaultSetting = @"";
				
					colvarLineaOriginal.ForeignKeyTableName = "Insumos_Provisiones_Lineas";
				schema.Columns.Add(colvarLineaOriginal);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["depProvider"].AddSchema("Insumos_Provisiones_Lineas",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Provision")]
		[Bindable(true)]
		public int Provision 
		{
			get { return GetColumnValue<int>(Columns.Provision); }
			set { SetColumnValue(Columns.Provision, value); }
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
		  
		[XmlAttribute("Multiplicador")]
		[Bindable(true)]
		public int Multiplicador 
		{
			get { return GetColumnValue<int>(Columns.Multiplicador); }
			set { SetColumnValue(Columns.Multiplicador, value); }
		}
		  
		[XmlAttribute("Lote")]
		[Bindable(true)]
		public string Lote 
		{
			get { return GetColumnValue<string>(Columns.Lote); }
			set { SetColumnValue(Columns.Lote, value); }
		}
		  
		[XmlAttribute("Vencimiento")]
		[Bindable(true)]
		public DateTime? Vencimiento 
		{
			get { return GetColumnValue<DateTime?>(Columns.Vencimiento); }
			set { SetColumnValue(Columns.Vencimiento, value); }
		}
		  
		[XmlAttribute("VencimientoOriginal")]
		[Bindable(true)]
		public DateTime? VencimientoOriginal 
		{
			get { return GetColumnValue<DateTime?>(Columns.VencimientoOriginal); }
			set { SetColumnValue(Columns.VencimientoOriginal, value); }
		}
		  
		[XmlAttribute("CostoUnitario")]
		[Bindable(true)]
		public float? CostoUnitario 
		{
			get { return GetColumnValue<float?>(Columns.CostoUnitario); }
			set { SetColumnValue(Columns.CostoUnitario, value); }
		}
		  
		[XmlAttribute("Ubicacion")]
		[Bindable(true)]
		public string Ubicacion 
		{
			get { return GetColumnValue<string>(Columns.Ubicacion); }
			set { SetColumnValue(Columns.Ubicacion, value); }
		}
		  
		[XmlAttribute("CantidadDisponible")]
		[Bindable(true)]
		public int CantidadDisponible 
		{
			get { return GetColumnValue<int>(Columns.CantidadDisponible); }
			set { SetColumnValue(Columns.CantidadDisponible, value); }
		}
		  
		[XmlAttribute("Renglon")]
		[Bindable(true)]
		public int? Renglon 
		{
			get { return GetColumnValue<int?>(Columns.Renglon); }
			set { SetColumnValue(Columns.Renglon, value); }
		}
		  
		[XmlAttribute("DescripcionExtendida")]
		[Bindable(true)]
		public string DescripcionExtendida 
		{
			get { return GetColumnValue<string>(Columns.DescripcionExtendida); }
			set { SetColumnValue(Columns.DescripcionExtendida, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("LineaOriginal")]
		[Bindable(true)]
		public int? LineaOriginal 
		{
			get { return GetColumnValue<int?>(Columns.LineaOriginal); }
			set { SetColumnValue(Columns.LineaOriginal, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalDeposito.InsumosProvisionesLineaCollection colChildInsumosProvisionesLineas;
		public DalDeposito.InsumosProvisionesLineaCollection ChildInsumosProvisionesLineas
		{
			get
			{
				if(colChildInsumosProvisionesLineas == null)
				{
					colChildInsumosProvisionesLineas = new DalDeposito.InsumosProvisionesLineaCollection().Where(InsumosProvisionesLinea.Columns.LineaOriginal, Codigo).Load();
					colChildInsumosProvisionesLineas.ListChanged += new ListChangedEventHandler(colChildInsumosProvisionesLineas_ListChanged);
				}
				return colChildInsumosProvisionesLineas;			
			}
			set 
			{ 
					colChildInsumosProvisionesLineas = value; 
					colChildInsumosProvisionesLineas.ListChanged += new ListChangedEventHandler(colChildInsumosProvisionesLineas_ListChanged);
			}
		}
		
		void colChildInsumosProvisionesLineas_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colChildInsumosProvisionesLineas[e.NewIndex].LineaOriginal = Codigo;
		    }
		}
				
		private DalDeposito.InsumosRemitosPedidosLineaCollection colInsumosRemitosPedidosLineas;
		public DalDeposito.InsumosRemitosPedidosLineaCollection InsumosRemitosPedidosLineas
		{
			get
			{
				if(colInsumosRemitosPedidosLineas == null)
				{
					colInsumosRemitosPedidosLineas = new DalDeposito.InsumosRemitosPedidosLineaCollection().Where(InsumosRemitosPedidosLinea.Columns.LineaProvision, Codigo).Load();
					colInsumosRemitosPedidosLineas.ListChanged += new ListChangedEventHandler(colInsumosRemitosPedidosLineas_ListChanged);
				}
				return colInsumosRemitosPedidosLineas;			
			}
			set 
			{ 
					colInsumosRemitosPedidosLineas = value; 
					colInsumosRemitosPedidosLineas.ListChanged += new ListChangedEventHandler(colInsumosRemitosPedidosLineas_ListChanged);
			}
		}
		
		void colInsumosRemitosPedidosLineas_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsumosRemitosPedidosLineas[e.NewIndex].LineaProvision = Codigo;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Insumo ActiveRecord object related to this InsumosProvisionesLinea
		/// 
		/// </summary>
		public DalDeposito.Insumo InsumoRecord
		{
			get { return DalDeposito.Insumo.FetchByID(this.Insumo); }
			set { SetColumnValue("Insumo", value.Codigo); }
		}
		
		
		/// <summary>
		/// Returns a InsumosProvisione ActiveRecord object related to this InsumosProvisionesLinea
		/// 
		/// </summary>
		public DalDeposito.InsumosProvisione InsumosProvisione
		{
			get { return DalDeposito.InsumosProvisione.FetchByID(this.Provision); }
			set { SetColumnValue("Provision", value.Codigo); }
		}
		
		
		/// <summary>
		/// Returns a InsumosProvisionesLinea ActiveRecord object related to this InsumosProvisionesLinea
		/// 
		/// </summary>
		public DalDeposito.InsumosProvisionesLinea ParentInsumosProvisionesLinea
		{
			get { return DalDeposito.InsumosProvisionesLinea.FetchByID(this.LineaOriginal); }
			set { SetColumnValue("Linea_Original", value.Codigo); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProvision,int varInsumo,int varCantidad,int varMultiplicador,string varLote,DateTime? varVencimiento,DateTime? varVencimientoOriginal,float? varCostoUnitario,string varUbicacion,int varCantidadDisponible,int? varRenglon,string varDescripcionExtendida,string varObservaciones,int? varLineaOriginal)
		{
			InsumosProvisionesLinea item = new InsumosProvisionesLinea();
			
			item.Provision = varProvision;
			
			item.Insumo = varInsumo;
			
			item.Cantidad = varCantidad;
			
			item.Multiplicador = varMultiplicador;
			
			item.Lote = varLote;
			
			item.Vencimiento = varVencimiento;
			
			item.VencimientoOriginal = varVencimientoOriginal;
			
			item.CostoUnitario = varCostoUnitario;
			
			item.Ubicacion = varUbicacion;
			
			item.CantidadDisponible = varCantidadDisponible;
			
			item.Renglon = varRenglon;
			
			item.DescripcionExtendida = varDescripcionExtendida;
			
			item.Observaciones = varObservaciones;
			
			item.LineaOriginal = varLineaOriginal;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProvision,int varCodigo,int varInsumo,int varCantidad,int varMultiplicador,string varLote,DateTime? varVencimiento,DateTime? varVencimientoOriginal,float? varCostoUnitario,string varUbicacion,int varCantidadDisponible,int? varRenglon,string varDescripcionExtendida,string varObservaciones,int? varLineaOriginal)
		{
			InsumosProvisionesLinea item = new InsumosProvisionesLinea();
			
				item.Provision = varProvision;
			
				item.Codigo = varCodigo;
			
				item.Insumo = varInsumo;
			
				item.Cantidad = varCantidad;
			
				item.Multiplicador = varMultiplicador;
			
				item.Lote = varLote;
			
				item.Vencimiento = varVencimiento;
			
				item.VencimientoOriginal = varVencimientoOriginal;
			
				item.CostoUnitario = varCostoUnitario;
			
				item.Ubicacion = varUbicacion;
			
				item.CantidadDisponible = varCantidadDisponible;
			
				item.Renglon = varRenglon;
			
				item.DescripcionExtendida = varDescripcionExtendida;
			
				item.Observaciones = varObservaciones;
			
				item.LineaOriginal = varLineaOriginal;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProvisionColumn
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
        
        
        
        public static TableSchema.TableColumn MultiplicadorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn LoteColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn VencimientoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn VencimientoOriginalColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CostoUnitarioColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn UbicacionColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CantidadDisponibleColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn RenglonColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn DescripcionExtendidaColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn LineaOriginalColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Provision = @"Provision";
			 public static string Codigo = @"Codigo";
			 public static string Insumo = @"Insumo";
			 public static string Cantidad = @"Cantidad";
			 public static string Multiplicador = @"Multiplicador";
			 public static string Lote = @"Lote";
			 public static string Vencimiento = @"Vencimiento";
			 public static string VencimientoOriginal = @"Vencimiento_Original";
			 public static string CostoUnitario = @"Costo_unitario";
			 public static string Ubicacion = @"Ubicacion";
			 public static string CantidadDisponible = @"Cantidad_Disponible";
			 public static string Renglon = @"Renglon";
			 public static string DescripcionExtendida = @"DescripcionExtendida";
			 public static string Observaciones = @"Observaciones";
			 public static string LineaOriginal = @"Linea_Original";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colChildInsumosProvisionesLineas != null)
                {
                    foreach (DalDeposito.InsumosProvisionesLinea item in colChildInsumosProvisionesLineas)
                    {
                        if (item.LineaOriginal == null ||item.LineaOriginal != Codigo)
                        {
                            item.LineaOriginal = Codigo;
                        }
                    }
               }
		
                if (colInsumosRemitosPedidosLineas != null)
                {
                    foreach (DalDeposito.InsumosRemitosPedidosLinea item in colInsumosRemitosPedidosLineas)
                    {
                        if (item.LineaProvision != Codigo)
                        {
                            item.LineaProvision = Codigo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colChildInsumosProvisionesLineas != null)
                {
                    colChildInsumosProvisionesLineas.SaveAll();
               }
		
                if (colInsumosRemitosPedidosLineas != null)
                {
                    colInsumosRemitosPedidosLineas.SaveAll();
               }
		}
        #endregion
	}
}
