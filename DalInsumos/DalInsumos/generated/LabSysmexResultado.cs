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
	/// Strongly-typed collection for the LabSysmexResultado class.
	/// </summary>
    [Serializable]
	public partial class LabSysmexResultadoCollection : ActiveList<LabSysmexResultado, LabSysmexResultadoCollection>
	{	   
		public LabSysmexResultadoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LabSysmexResultadoCollection</returns>
		public LabSysmexResultadoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LabSysmexResultado o = this[i];
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
	/// This is an ActiveRecord class which wraps the LAB_SysmexResultado table.
	/// </summary>
	[Serializable]
	public partial class LabSysmexResultado : ActiveRecord<LabSysmexResultado>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LabSysmexResultado()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LabSysmexResultado(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LabSysmexResultado(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LabSysmexResultado(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("LAB_SysmexResultado", TableType.Table, DataService.GetInstance("insProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdSysmexResultado = new TableSchema.TableColumn(schema);
				colvarIdSysmexResultado.ColumnName = "idSysmexResultado";
				colvarIdSysmexResultado.DataType = DbType.Int32;
				colvarIdSysmexResultado.MaxLength = 0;
				colvarIdSysmexResultado.AutoIncrement = true;
				colvarIdSysmexResultado.IsNullable = false;
				colvarIdSysmexResultado.IsPrimaryKey = true;
				colvarIdSysmexResultado.IsForeignKey = false;
				colvarIdSysmexResultado.IsReadOnly = false;
				colvarIdSysmexResultado.DefaultSetting = @"";
				colvarIdSysmexResultado.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdSysmexResultado);
				
				TableSchema.TableColumn colvarProtocolo = new TableSchema.TableColumn(schema);
				colvarProtocolo.ColumnName = "protocolo";
				colvarProtocolo.DataType = DbType.AnsiString;
				colvarProtocolo.MaxLength = 50;
				colvarProtocolo.AutoIncrement = false;
				colvarProtocolo.IsNullable = false;
				colvarProtocolo.IsPrimaryKey = false;
				colvarProtocolo.IsForeignKey = false;
				colvarProtocolo.IsReadOnly = false;
				colvarProtocolo.DefaultSetting = @"";
				colvarProtocolo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProtocolo);
				
				TableSchema.TableColumn colvarIdItemSysmex = new TableSchema.TableColumn(schema);
				colvarIdItemSysmex.ColumnName = "idItemSysmex";
				colvarIdItemSysmex.DataType = DbType.AnsiString;
				colvarIdItemSysmex.MaxLength = 50;
				colvarIdItemSysmex.AutoIncrement = false;
				colvarIdItemSysmex.IsNullable = false;
				colvarIdItemSysmex.IsPrimaryKey = false;
				colvarIdItemSysmex.IsForeignKey = false;
				colvarIdItemSysmex.IsReadOnly = false;
				colvarIdItemSysmex.DefaultSetting = @"";
				colvarIdItemSysmex.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdItemSysmex);
				
				TableSchema.TableColumn colvarUnidadMedida = new TableSchema.TableColumn(schema);
				colvarUnidadMedida.ColumnName = "unidadMedida";
				colvarUnidadMedida.DataType = DbType.AnsiString;
				colvarUnidadMedida.MaxLength = 50;
				colvarUnidadMedida.AutoIncrement = false;
				colvarUnidadMedida.IsNullable = false;
				colvarUnidadMedida.IsPrimaryKey = false;
				colvarUnidadMedida.IsForeignKey = false;
				colvarUnidadMedida.IsReadOnly = false;
				colvarUnidadMedida.DefaultSetting = @"";
				colvarUnidadMedida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadMedida);
				
				TableSchema.TableColumn colvarValorObtenido = new TableSchema.TableColumn(schema);
				colvarValorObtenido.ColumnName = "valorObtenido";
				colvarValorObtenido.DataType = DbType.AnsiString;
				colvarValorObtenido.MaxLength = 50;
				colvarValorObtenido.AutoIncrement = false;
				colvarValorObtenido.IsNullable = false;
				colvarValorObtenido.IsPrimaryKey = false;
				colvarValorObtenido.IsForeignKey = false;
				colvarValorObtenido.IsReadOnly = false;
				colvarValorObtenido.DefaultSetting = @"";
				colvarValorObtenido.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValorObtenido);
				
				TableSchema.TableColumn colvarFechaRegistro = new TableSchema.TableColumn(schema);
				colvarFechaRegistro.ColumnName = "fechaRegistro";
				colvarFechaRegistro.DataType = DbType.DateTime;
				colvarFechaRegistro.MaxLength = 0;
				colvarFechaRegistro.AutoIncrement = false;
				colvarFechaRegistro.IsNullable = false;
				colvarFechaRegistro.IsPrimaryKey = false;
				colvarFechaRegistro.IsForeignKey = false;
				colvarFechaRegistro.IsReadOnly = false;
				
						colvarFechaRegistro.DefaultSetting = @"(((1)/(1))/(1900))";
				colvarFechaRegistro.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaRegistro);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["insProvider"].AddSchema("LAB_SysmexResultado",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdSysmexResultado")]
		[Bindable(true)]
		public int IdSysmexResultado 
		{
			get { return GetColumnValue<int>(Columns.IdSysmexResultado); }
			set { SetColumnValue(Columns.IdSysmexResultado, value); }
		}
		  
		[XmlAttribute("Protocolo")]
		[Bindable(true)]
		public string Protocolo 
		{
			get { return GetColumnValue<string>(Columns.Protocolo); }
			set { SetColumnValue(Columns.Protocolo, value); }
		}
		  
		[XmlAttribute("IdItemSysmex")]
		[Bindable(true)]
		public string IdItemSysmex 
		{
			get { return GetColumnValue<string>(Columns.IdItemSysmex); }
			set { SetColumnValue(Columns.IdItemSysmex, value); }
		}
		  
		[XmlAttribute("UnidadMedida")]
		[Bindable(true)]
		public string UnidadMedida 
		{
			get { return GetColumnValue<string>(Columns.UnidadMedida); }
			set { SetColumnValue(Columns.UnidadMedida, value); }
		}
		  
		[XmlAttribute("ValorObtenido")]
		[Bindable(true)]
		public string ValorObtenido 
		{
			get { return GetColumnValue<string>(Columns.ValorObtenido); }
			set { SetColumnValue(Columns.ValorObtenido, value); }
		}
		  
		[XmlAttribute("FechaRegistro")]
		[Bindable(true)]
		public DateTime FechaRegistro 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaRegistro); }
			set { SetColumnValue(Columns.FechaRegistro, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varProtocolo,string varIdItemSysmex,string varUnidadMedida,string varValorObtenido,DateTime varFechaRegistro)
		{
			LabSysmexResultado item = new LabSysmexResultado();
			
			item.Protocolo = varProtocolo;
			
			item.IdItemSysmex = varIdItemSysmex;
			
			item.UnidadMedida = varUnidadMedida;
			
			item.ValorObtenido = varValorObtenido;
			
			item.FechaRegistro = varFechaRegistro;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdSysmexResultado,string varProtocolo,string varIdItemSysmex,string varUnidadMedida,string varValorObtenido,DateTime varFechaRegistro)
		{
			LabSysmexResultado item = new LabSysmexResultado();
			
				item.IdSysmexResultado = varIdSysmexResultado;
			
				item.Protocolo = varProtocolo;
			
				item.IdItemSysmex = varIdItemSysmex;
			
				item.UnidadMedida = varUnidadMedida;
			
				item.ValorObtenido = varValorObtenido;
			
				item.FechaRegistro = varFechaRegistro;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdSysmexResultadoColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProtocoloColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdItemSysmexColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadMedidaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ValorObtenidoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaRegistroColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdSysmexResultado = @"idSysmexResultado";
			 public static string Protocolo = @"protocolo";
			 public static string IdItemSysmex = @"idItemSysmex";
			 public static string UnidadMedida = @"unidadMedida";
			 public static string ValorObtenido = @"valorObtenido";
			 public static string FechaRegistro = @"fechaRegistro";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}