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
	/// Strongly-typed collection for the InsPedido class.
	/// </summary>
    [Serializable]
	public partial class InsPedidoCollection : ActiveList<InsPedido, InsPedidoCollection>
	{	   
		public InsPedidoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsPedidoCollection</returns>
		public InsPedidoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsPedido o = this[i];
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
	/// This is an ActiveRecord class which wraps the INS_Pedido table.
	/// </summary>
	[Serializable]
	public partial class InsPedido : ActiveRecord<InsPedido>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsPedido()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsPedido(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsPedido(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsPedido(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("INS_Pedido", TableType.Table, DataService.GetInstance("insProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPedido = new TableSchema.TableColumn(schema);
				colvarIdPedido.ColumnName = "idPedido";
				colvarIdPedido.DataType = DbType.Int32;
				colvarIdPedido.MaxLength = 0;
				colvarIdPedido.AutoIncrement = true;
				colvarIdPedido.IsNullable = false;
				colvarIdPedido.IsPrimaryKey = true;
				colvarIdPedido.IsForeignKey = false;
				colvarIdPedido.IsReadOnly = false;
				colvarIdPedido.DefaultSetting = @"";
				colvarIdPedido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPedido);
				
				TableSchema.TableColumn colvarIdEfector = new TableSchema.TableColumn(schema);
				colvarIdEfector.ColumnName = "idEfector";
				colvarIdEfector.DataType = DbType.Int32;
				colvarIdEfector.MaxLength = 0;
				colvarIdEfector.AutoIncrement = false;
				colvarIdEfector.IsNullable = true;
				colvarIdEfector.IsPrimaryKey = false;
				colvarIdEfector.IsForeignKey = true;
				colvarIdEfector.IsReadOnly = false;
				colvarIdEfector.DefaultSetting = @"";
				
					colvarIdEfector.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfector);
				
				TableSchema.TableColumn colvarIdEfectorProveedor = new TableSchema.TableColumn(schema);
				colvarIdEfectorProveedor.ColumnName = "idEfectorProveedor";
				colvarIdEfectorProveedor.DataType = DbType.Int32;
				colvarIdEfectorProveedor.MaxLength = 0;
				colvarIdEfectorProveedor.AutoIncrement = false;
				colvarIdEfectorProveedor.IsNullable = true;
				colvarIdEfectorProveedor.IsPrimaryKey = false;
				colvarIdEfectorProveedor.IsForeignKey = true;
				colvarIdEfectorProveedor.IsReadOnly = false;
				colvarIdEfectorProveedor.DefaultSetting = @"";
				
					colvarIdEfectorProveedor.ForeignKeyTableName = "Sys_Efector";
				schema.Columns.Add(colvarIdEfectorProveedor);
				
				TableSchema.TableColumn colvarIdDeposito = new TableSchema.TableColumn(schema);
				colvarIdDeposito.ColumnName = "idDeposito";
				colvarIdDeposito.DataType = DbType.Int32;
				colvarIdDeposito.MaxLength = 0;
				colvarIdDeposito.AutoIncrement = false;
				colvarIdDeposito.IsNullable = true;
				colvarIdDeposito.IsPrimaryKey = false;
				colvarIdDeposito.IsForeignKey = true;
				colvarIdDeposito.IsReadOnly = false;
				colvarIdDeposito.DefaultSetting = @"";
				
					colvarIdDeposito.ForeignKeyTableName = "INS_Deposito";
				schema.Columns.Add(colvarIdDeposito);
				
				TableSchema.TableColumn colvarIdDepositoProveedor = new TableSchema.TableColumn(schema);
				colvarIdDepositoProveedor.ColumnName = "idDepositoProveedor";
				colvarIdDepositoProveedor.DataType = DbType.Int32;
				colvarIdDepositoProveedor.MaxLength = 0;
				colvarIdDepositoProveedor.AutoIncrement = false;
				colvarIdDepositoProveedor.IsNullable = true;
				colvarIdDepositoProveedor.IsPrimaryKey = false;
				colvarIdDepositoProveedor.IsForeignKey = true;
				colvarIdDepositoProveedor.IsReadOnly = false;
				colvarIdDepositoProveedor.DefaultSetting = @"";
				
					colvarIdDepositoProveedor.ForeignKeyTableName = "INS_Deposito";
				schema.Columns.Add(colvarIdDepositoProveedor);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				
						colvarFecha.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarFechaRecepcion = new TableSchema.TableColumn(schema);
				colvarFechaRecepcion.ColumnName = "fechaRecepcion";
				colvarFechaRecepcion.DataType = DbType.DateTime;
				colvarFechaRecepcion.MaxLength = 0;
				colvarFechaRecepcion.AutoIncrement = false;
				colvarFechaRecepcion.IsNullable = true;
				colvarFechaRecepcion.IsPrimaryKey = false;
				colvarFechaRecepcion.IsForeignKey = false;
				colvarFechaRecepcion.IsReadOnly = false;
				
						colvarFechaRecepcion.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaRecepcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRecepcion);
				
				TableSchema.TableColumn colvarIdTipoPedido = new TableSchema.TableColumn(schema);
				colvarIdTipoPedido.ColumnName = "idTipoPedido";
				colvarIdTipoPedido.DataType = DbType.Int32;
				colvarIdTipoPedido.MaxLength = 0;
				colvarIdTipoPedido.AutoIncrement = false;
				colvarIdTipoPedido.IsNullable = true;
				colvarIdTipoPedido.IsPrimaryKey = false;
				colvarIdTipoPedido.IsForeignKey = true;
				colvarIdTipoPedido.IsReadOnly = false;
				colvarIdTipoPedido.DefaultSetting = @"";
				
					colvarIdTipoPedido.ForeignKeyTableName = "INS_TipoPedido";
				schema.Columns.Add(colvarIdTipoPedido);
				
				TableSchema.TableColumn colvarIdEstadoPedido = new TableSchema.TableColumn(schema);
				colvarIdEstadoPedido.ColumnName = "idEstadoPedido";
				colvarIdEstadoPedido.DataType = DbType.Int32;
				colvarIdEstadoPedido.MaxLength = 0;
				colvarIdEstadoPedido.AutoIncrement = false;
				colvarIdEstadoPedido.IsNullable = true;
				colvarIdEstadoPedido.IsPrimaryKey = false;
				colvarIdEstadoPedido.IsForeignKey = true;
				colvarIdEstadoPedido.IsReadOnly = false;
				colvarIdEstadoPedido.DefaultSetting = @"";
				
					colvarIdEstadoPedido.ForeignKeyTableName = "INS_EstadoPedido";
				schema.Columns.Add(colvarIdEstadoPedido);
				
				TableSchema.TableColumn colvarIdRubro = new TableSchema.TableColumn(schema);
				colvarIdRubro.ColumnName = "idRubro";
				colvarIdRubro.DataType = DbType.Int32;
				colvarIdRubro.MaxLength = 0;
				colvarIdRubro.AutoIncrement = false;
				colvarIdRubro.IsNullable = true;
				colvarIdRubro.IsPrimaryKey = false;
				colvarIdRubro.IsForeignKey = true;
				colvarIdRubro.IsReadOnly = false;
				
						colvarIdRubro.DefaultSetting = @"((0))";
				
					colvarIdRubro.ForeignKeyTableName = "INS_Rubro";
				schema.Columns.Add(colvarIdRubro);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
				colvarObservaciones.DataType = DbType.AnsiString;
				colvarObservaciones.MaxLength = 1000;
				colvarObservaciones.AutoIncrement = false;
				colvarObservaciones.IsNullable = true;
				colvarObservaciones.IsPrimaryKey = false;
				colvarObservaciones.IsForeignKey = false;
				colvarObservaciones.IsReadOnly = false;
				colvarObservaciones.DefaultSetting = @"";
				colvarObservaciones.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObservaciones);
				
				TableSchema.TableColumn colvarResponsable = new TableSchema.TableColumn(schema);
				colvarResponsable.ColumnName = "responsable";
				colvarResponsable.DataType = DbType.AnsiString;
				colvarResponsable.MaxLength = 200;
				colvarResponsable.AutoIncrement = false;
				colvarResponsable.IsNullable = true;
				colvarResponsable.IsPrimaryKey = false;
				colvarResponsable.IsForeignKey = false;
				colvarResponsable.IsReadOnly = false;
				colvarResponsable.DefaultSetting = @"";
				colvarResponsable.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResponsable);
				
				TableSchema.TableColumn colvarAutorizado = new TableSchema.TableColumn(schema);
				colvarAutorizado.ColumnName = "autorizado";
				colvarAutorizado.DataType = DbType.Boolean;
				colvarAutorizado.MaxLength = 0;
				colvarAutorizado.AutoIncrement = false;
				colvarAutorizado.IsNullable = true;
				colvarAutorizado.IsPrimaryKey = false;
				colvarAutorizado.IsForeignKey = false;
				colvarAutorizado.IsReadOnly = false;
				colvarAutorizado.DefaultSetting = @"";
				colvarAutorizado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAutorizado);
				
				TableSchema.TableColumn colvarIdProveedor = new TableSchema.TableColumn(schema);
				colvarIdProveedor.ColumnName = "idProveedor";
				colvarIdProveedor.DataType = DbType.Int32;
				colvarIdProveedor.MaxLength = 0;
				colvarIdProveedor.AutoIncrement = false;
				colvarIdProveedor.IsNullable = true;
				colvarIdProveedor.IsPrimaryKey = false;
				colvarIdProveedor.IsForeignKey = true;
				colvarIdProveedor.IsReadOnly = false;
				
						colvarIdProveedor.DefaultSetting = @"((0))";
				
					colvarIdProveedor.ForeignKeyTableName = "INS_Proveedor";
				schema.Columns.Add(colvarIdProveedor);
				
				TableSchema.TableColumn colvarIdTipoComprobante = new TableSchema.TableColumn(schema);
				colvarIdTipoComprobante.ColumnName = "idTipoComprobante";
				colvarIdTipoComprobante.DataType = DbType.Int32;
				colvarIdTipoComprobante.MaxLength = 0;
				colvarIdTipoComprobante.AutoIncrement = false;
				colvarIdTipoComprobante.IsNullable = true;
				colvarIdTipoComprobante.IsPrimaryKey = false;
				colvarIdTipoComprobante.IsForeignKey = true;
				colvarIdTipoComprobante.IsReadOnly = false;
				colvarIdTipoComprobante.DefaultSetting = @"";
				
					colvarIdTipoComprobante.ForeignKeyTableName = "INS_TipoComprobante";
				schema.Columns.Add(colvarIdTipoComprobante);
				
				TableSchema.TableColumn colvarNumeroComprobante = new TableSchema.TableColumn(schema);
				colvarNumeroComprobante.ColumnName = "numeroComprobante";
				colvarNumeroComprobante.DataType = DbType.AnsiString;
				colvarNumeroComprobante.MaxLength = 20;
				colvarNumeroComprobante.AutoIncrement = false;
				colvarNumeroComprobante.IsNullable = true;
				colvarNumeroComprobante.IsPrimaryKey = false;
				colvarNumeroComprobante.IsForeignKey = false;
				colvarNumeroComprobante.IsReadOnly = false;
				colvarNumeroComprobante.DefaultSetting = @"";
				colvarNumeroComprobante.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroComprobante);
				
				TableSchema.TableColumn colvarOrdenCompra = new TableSchema.TableColumn(schema);
				colvarOrdenCompra.ColumnName = "ordenCompra";
				colvarOrdenCompra.DataType = DbType.AnsiString;
				colvarOrdenCompra.MaxLength = 20;
				colvarOrdenCompra.AutoIncrement = false;
				colvarOrdenCompra.IsNullable = true;
				colvarOrdenCompra.IsPrimaryKey = false;
				colvarOrdenCompra.IsForeignKey = false;
				colvarOrdenCompra.IsReadOnly = false;
				colvarOrdenCompra.DefaultSetting = @"";
				colvarOrdenCompra.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdenCompra);
				
				TableSchema.TableColumn colvarEstado = new TableSchema.TableColumn(schema);
				colvarEstado.ColumnName = "estado";
				colvarEstado.DataType = DbType.Boolean;
				colvarEstado.MaxLength = 0;
				colvarEstado.AutoIncrement = false;
				colvarEstado.IsNullable = true;
				colvarEstado.IsPrimaryKey = false;
				colvarEstado.IsForeignKey = false;
				colvarEstado.IsReadOnly = false;
				
						colvarEstado.DefaultSetting = @"((0))";
				colvarEstado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEstado);
				
				TableSchema.TableColumn colvarBaja = new TableSchema.TableColumn(schema);
				colvarBaja.ColumnName = "baja";
				colvarBaja.DataType = DbType.Boolean;
				colvarBaja.MaxLength = 0;
				colvarBaja.AutoIncrement = false;
				colvarBaja.IsNullable = false;
				colvarBaja.IsPrimaryKey = false;
				colvarBaja.IsForeignKey = false;
				colvarBaja.IsReadOnly = false;
				
						colvarBaja.DefaultSetting = @"((0))";
				colvarBaja.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBaja);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.AnsiString;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"('')";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.AnsiString;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				
						colvarModifiedBy.DefaultSetting = @"('')";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				
						colvarModifiedOn.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["insProvider"].AddSchema("INS_Pedido",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPedido")]
		[Bindable(true)]
		public int IdPedido 
		{
			get { return GetColumnValue<int>(Columns.IdPedido); }
			set { SetColumnValue(Columns.IdPedido, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdEfectorProveedor")]
		[Bindable(true)]
		public int? IdEfectorProveedor 
		{
			get { return GetColumnValue<int?>(Columns.IdEfectorProveedor); }
			set { SetColumnValue(Columns.IdEfectorProveedor, value); }
		}
		  
		[XmlAttribute("IdDeposito")]
		[Bindable(true)]
		public int? IdDeposito 
		{
			get { return GetColumnValue<int?>(Columns.IdDeposito); }
			set { SetColumnValue(Columns.IdDeposito, value); }
		}
		  
		[XmlAttribute("IdDepositoProveedor")]
		[Bindable(true)]
		public int? IdDepositoProveedor 
		{
			get { return GetColumnValue<int?>(Columns.IdDepositoProveedor); }
			set { SetColumnValue(Columns.IdDepositoProveedor, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("FechaRecepcion")]
		[Bindable(true)]
		public DateTime? FechaRecepcion 
		{
			get { return GetColumnValue<DateTime?>(Columns.FechaRecepcion); }
			set { SetColumnValue(Columns.FechaRecepcion, value); }
		}
		  
		[XmlAttribute("IdTipoPedido")]
		[Bindable(true)]
		public int? IdTipoPedido 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoPedido); }
			set { SetColumnValue(Columns.IdTipoPedido, value); }
		}
		  
		[XmlAttribute("IdEstadoPedido")]
		[Bindable(true)]
		public int? IdEstadoPedido 
		{
			get { return GetColumnValue<int?>(Columns.IdEstadoPedido); }
			set { SetColumnValue(Columns.IdEstadoPedido, value); }
		}
		  
		[XmlAttribute("IdRubro")]
		[Bindable(true)]
		public int? IdRubro 
		{
			get { return GetColumnValue<int?>(Columns.IdRubro); }
			set { SetColumnValue(Columns.IdRubro, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("Responsable")]
		[Bindable(true)]
		public string Responsable 
		{
			get { return GetColumnValue<string>(Columns.Responsable); }
			set { SetColumnValue(Columns.Responsable, value); }
		}
		  
		[XmlAttribute("Autorizado")]
		[Bindable(true)]
		public bool? Autorizado 
		{
			get { return GetColumnValue<bool?>(Columns.Autorizado); }
			set { SetColumnValue(Columns.Autorizado, value); }
		}
		  
		[XmlAttribute("IdProveedor")]
		[Bindable(true)]
		public int? IdProveedor 
		{
			get { return GetColumnValue<int?>(Columns.IdProveedor); }
			set { SetColumnValue(Columns.IdProveedor, value); }
		}
		  
		[XmlAttribute("IdTipoComprobante")]
		[Bindable(true)]
		public int? IdTipoComprobante 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoComprobante); }
			set { SetColumnValue(Columns.IdTipoComprobante, value); }
		}
		  
		[XmlAttribute("NumeroComprobante")]
		[Bindable(true)]
		public string NumeroComprobante 
		{
			get { return GetColumnValue<string>(Columns.NumeroComprobante); }
			set { SetColumnValue(Columns.NumeroComprobante, value); }
		}
		  
		[XmlAttribute("OrdenCompra")]
		[Bindable(true)]
		public string OrdenCompra 
		{
			get { return GetColumnValue<string>(Columns.OrdenCompra); }
			set { SetColumnValue(Columns.OrdenCompra, value); }
		}
		  
		[XmlAttribute("Estado")]
		[Bindable(true)]
		public bool? Estado 
		{
			get { return GetColumnValue<bool?>(Columns.Estado); }
			set { SetColumnValue(Columns.Estado, value); }
		}
		  
		[XmlAttribute("Baja")]
		[Bindable(true)]
		public bool Baja 
		{
			get { return GetColumnValue<bool>(Columns.Baja); }
			set { SetColumnValue(Columns.Baja, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiedOn")]
		[Bindable(true)]
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }
			set { SetColumnValue(Columns.ModifiedOn, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalInsumos.InsPedidoDetalleCollection colInsPedidoDetalleRecords;
		public DalInsumos.InsPedidoDetalleCollection InsPedidoDetalleRecords
		{
			get
			{
				if(colInsPedidoDetalleRecords == null)
				{
					colInsPedidoDetalleRecords = new DalInsumos.InsPedidoDetalleCollection().Where(InsPedidoDetalle.Columns.IdPedido, IdPedido).Load();
					colInsPedidoDetalleRecords.ListChanged += new ListChangedEventHandler(colInsPedidoDetalleRecords_ListChanged);
				}
				return colInsPedidoDetalleRecords;			
			}
			set 
			{ 
					colInsPedidoDetalleRecords = value; 
					colInsPedidoDetalleRecords.ListChanged += new ListChangedEventHandler(colInsPedidoDetalleRecords_ListChanged);
			}
		}
		
		void colInsPedidoDetalleRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsPedidoDetalleRecords[e.NewIndex].IdPedido = IdPedido;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a InsRubro ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.InsRubro InsRubro
		{
			get { return DalInsumos.InsRubro.FetchByID(this.IdRubro); }
			set { SetColumnValue("idRubro", value.Codigo); }
		}
		
		
		/// <summary>
		/// Returns a InsTipoComprobante ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.InsTipoComprobante InsTipoComprobante
		{
			get { return DalInsumos.InsTipoComprobante.FetchByID(this.IdTipoComprobante); }
			set { SetColumnValue("idTipoComprobante", value.IdTipoComprobante); }
		}
		
		
		/// <summary>
		/// Returns a InsTipoPedido ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.InsTipoPedido InsTipoPedido
		{
			get { return DalInsumos.InsTipoPedido.FetchByID(this.IdTipoPedido); }
			set { SetColumnValue("idTipoPedido", value.IdTipoPedido); }
		}
		
		
		/// <summary>
		/// Returns a InsProveedor ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.InsProveedor InsProveedor
		{
			get { return DalInsumos.InsProveedor.FetchByID(this.IdProveedor); }
			set { SetColumnValue("idProveedor", value.IdProveedor); }
		}
		
		
		/// <summary>
		/// Returns a InsEstadoPedido ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.InsEstadoPedido InsEstadoPedido
		{
			get { return DalInsumos.InsEstadoPedido.FetchByID(this.IdEstadoPedido); }
			set { SetColumnValue("idEstadoPedido", value.IdEstadoPedido); }
		}
		
		
		/// <summary>
		/// Returns a InsDeposito ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.InsDeposito InsDeposito
		{
			get { return DalInsumos.InsDeposito.FetchByID(this.IdDeposito); }
			set { SetColumnValue("idDeposito", value.IdDeposito); }
		}
		
		
		/// <summary>
		/// Returns a InsDeposito ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.InsDeposito InsDepositoToIdDepositoProveedor
		{
			get { return DalInsumos.InsDeposito.FetchByID(this.IdDepositoProveedor); }
			set { SetColumnValue("idDepositoProveedor", value.IdDeposito); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.SysEfector SysEfector
		{
			get { return DalInsumos.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this InsPedido
		/// 
		/// </summary>
		public DalInsumos.SysEfector SysEfectorToIdEfectorProveedor
		{
			get { return DalInsumos.SysEfector.FetchByID(this.IdEfectorProveedor); }
			set { SetColumnValue("idEfectorProveedor", value.IdEfector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEfector,int? varIdEfectorProveedor,int? varIdDeposito,int? varIdDepositoProveedor,DateTime? varFecha,DateTime? varFechaRecepcion,int? varIdTipoPedido,int? varIdEstadoPedido,int? varIdRubro,string varObservaciones,string varResponsable,bool? varAutorizado,int? varIdProveedor,int? varIdTipoComprobante,string varNumeroComprobante,string varOrdenCompra,bool? varEstado,bool varBaja,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			InsPedido item = new InsPedido();
			
			item.IdEfector = varIdEfector;
			
			item.IdEfectorProveedor = varIdEfectorProveedor;
			
			item.IdDeposito = varIdDeposito;
			
			item.IdDepositoProveedor = varIdDepositoProveedor;
			
			item.Fecha = varFecha;
			
			item.FechaRecepcion = varFechaRecepcion;
			
			item.IdTipoPedido = varIdTipoPedido;
			
			item.IdEstadoPedido = varIdEstadoPedido;
			
			item.IdRubro = varIdRubro;
			
			item.Observaciones = varObservaciones;
			
			item.Responsable = varResponsable;
			
			item.Autorizado = varAutorizado;
			
			item.IdProveedor = varIdProveedor;
			
			item.IdTipoComprobante = varIdTipoComprobante;
			
			item.NumeroComprobante = varNumeroComprobante;
			
			item.OrdenCompra = varOrdenCompra;
			
			item.Estado = varEstado;
			
			item.Baja = varBaja;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdPedido,int? varIdEfector,int? varIdEfectorProveedor,int? varIdDeposito,int? varIdDepositoProveedor,DateTime? varFecha,DateTime? varFechaRecepcion,int? varIdTipoPedido,int? varIdEstadoPedido,int? varIdRubro,string varObservaciones,string varResponsable,bool? varAutorizado,int? varIdProveedor,int? varIdTipoComprobante,string varNumeroComprobante,string varOrdenCompra,bool? varEstado,bool varBaja,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			InsPedido item = new InsPedido();
			
				item.IdPedido = varIdPedido;
			
				item.IdEfector = varIdEfector;
			
				item.IdEfectorProveedor = varIdEfectorProveedor;
			
				item.IdDeposito = varIdDeposito;
			
				item.IdDepositoProveedor = varIdDepositoProveedor;
			
				item.Fecha = varFecha;
			
				item.FechaRecepcion = varFechaRecepcion;
			
				item.IdTipoPedido = varIdTipoPedido;
			
				item.IdEstadoPedido = varIdEstadoPedido;
			
				item.IdRubro = varIdRubro;
			
				item.Observaciones = varObservaciones;
			
				item.Responsable = varResponsable;
			
				item.Autorizado = varAutorizado;
			
				item.IdProveedor = varIdProveedor;
			
				item.IdTipoComprobante = varIdTipoComprobante;
			
				item.NumeroComprobante = varNumeroComprobante;
			
				item.OrdenCompra = varOrdenCompra;
			
				item.Estado = varEstado;
			
				item.Baja = varBaja;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdPedidoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorProveedorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDepositoColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDepositoProveedorColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRecepcionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoPedidoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEstadoPedidoColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IdRubroColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ResponsableColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn AutorizadoColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProveedorColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoComprobanteColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroComprobanteColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdenCompraColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn EstadoColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPedido = @"idPedido";
			 public static string IdEfector = @"idEfector";
			 public static string IdEfectorProveedor = @"idEfectorProveedor";
			 public static string IdDeposito = @"idDeposito";
			 public static string IdDepositoProveedor = @"idDepositoProveedor";
			 public static string Fecha = @"fecha";
			 public static string FechaRecepcion = @"fechaRecepcion";
			 public static string IdTipoPedido = @"idTipoPedido";
			 public static string IdEstadoPedido = @"idEstadoPedido";
			 public static string IdRubro = @"idRubro";
			 public static string Observaciones = @"observaciones";
			 public static string Responsable = @"responsable";
			 public static string Autorizado = @"autorizado";
			 public static string IdProveedor = @"idProveedor";
			 public static string IdTipoComprobante = @"idTipoComprobante";
			 public static string NumeroComprobante = @"numeroComprobante";
			 public static string OrdenCompra = @"ordenCompra";
			 public static string Estado = @"estado";
			 public static string Baja = @"baja";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colInsPedidoDetalleRecords != null)
                {
                    foreach (DalInsumos.InsPedidoDetalle item in colInsPedidoDetalleRecords)
                    {
                        if (item.IdPedido != IdPedido)
                        {
                            item.IdPedido = IdPedido;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colInsPedidoDetalleRecords != null)
                {
                    colInsPedidoDetalleRecords.SaveAll();
               }
		}
        #endregion
	}
}