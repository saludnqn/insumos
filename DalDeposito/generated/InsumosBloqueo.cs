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
	/// Strongly-typed collection for the InsumosBloqueo class.
	/// </summary>
    [Serializable]
	public partial class InsumosBloqueoCollection : ActiveList<InsumosBloqueo, InsumosBloqueoCollection>
	{	   
		public InsumosBloqueoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsumosBloqueoCollection</returns>
		public InsumosBloqueoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsumosBloqueo o = this[i];
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
	/// This is an ActiveRecord class which wraps the Insumos_Bloqueos table.
	/// </summary>
	[Serializable]
	public partial class InsumosBloqueo : ActiveRecord<InsumosBloqueo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsumosBloqueo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsumosBloqueo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsumosBloqueo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsumosBloqueo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Insumos_Bloqueos", TableType.Table, DataService.GetInstance("depProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTicket = new TableSchema.TableColumn(schema);
				colvarTicket.ColumnName = "Ticket";
				colvarTicket.DataType = DbType.Int32;
				colvarTicket.MaxLength = 0;
				colvarTicket.AutoIncrement = true;
				colvarTicket.IsNullable = false;
				colvarTicket.IsPrimaryKey = false;
				colvarTicket.IsForeignKey = false;
				colvarTicket.IsReadOnly = false;
				colvarTicket.DefaultSetting = @"";
				colvarTicket.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTicket);
				
				TableSchema.TableColumn colvarTipo = new TableSchema.TableColumn(schema);
				colvarTipo.ColumnName = "Tipo";
				colvarTipo.DataType = DbType.Int32;
				colvarTipo.MaxLength = 0;
				colvarTipo.AutoIncrement = false;
				colvarTipo.IsNullable = false;
				colvarTipo.IsPrimaryKey = true;
				colvarTipo.IsForeignKey = false;
				colvarTipo.IsReadOnly = false;
				colvarTipo.DefaultSetting = @"";
				colvarTipo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipo);
				
				TableSchema.TableColumn colvarIdentificador = new TableSchema.TableColumn(schema);
				colvarIdentificador.ColumnName = "Identificador";
				colvarIdentificador.DataType = DbType.Int32;
				colvarIdentificador.MaxLength = 0;
				colvarIdentificador.AutoIncrement = false;
				colvarIdentificador.IsNullable = false;
				colvarIdentificador.IsPrimaryKey = true;
				colvarIdentificador.IsForeignKey = false;
				colvarIdentificador.IsReadOnly = false;
				colvarIdentificador.DefaultSetting = @"";
				colvarIdentificador.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdentificador);
				
				TableSchema.TableColumn colvarUsuario = new TableSchema.TableColumn(schema);
				colvarUsuario.ColumnName = "Usuario";
				colvarUsuario.DataType = DbType.Int32;
				colvarUsuario.MaxLength = 0;
				colvarUsuario.AutoIncrement = false;
				colvarUsuario.IsNullable = false;
				colvarUsuario.IsPrimaryKey = false;
				colvarUsuario.IsForeignKey = false;
				colvarUsuario.IsReadOnly = false;
				colvarUsuario.DefaultSetting = @"";
				colvarUsuario.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsuario);
				
				TableSchema.TableColumn colvarFechaHora = new TableSchema.TableColumn(schema);
				colvarFechaHora.ColumnName = "FechaHora";
				colvarFechaHora.DataType = DbType.DateTime;
				colvarFechaHora.MaxLength = 0;
				colvarFechaHora.AutoIncrement = false;
				colvarFechaHora.IsNullable = false;
				colvarFechaHora.IsPrimaryKey = false;
				colvarFechaHora.IsForeignKey = false;
				colvarFechaHora.IsReadOnly = false;
				colvarFechaHora.DefaultSetting = @"";
				colvarFechaHora.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFechaHora);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["depProvider"].AddSchema("Insumos_Bloqueos",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Ticket")]
		[Bindable(true)]
		public int Ticket 
		{
			get { return GetColumnValue<int>(Columns.Ticket); }
			set { SetColumnValue(Columns.Ticket, value); }
		}
		  
		[XmlAttribute("Tipo")]
		[Bindable(true)]
		public int Tipo 
		{
			get { return GetColumnValue<int>(Columns.Tipo); }
			set { SetColumnValue(Columns.Tipo, value); }
		}
		  
		[XmlAttribute("Identificador")]
		[Bindable(true)]
		public int Identificador 
		{
			get { return GetColumnValue<int>(Columns.Identificador); }
			set { SetColumnValue(Columns.Identificador, value); }
		}
		  
		[XmlAttribute("Usuario")]
		[Bindable(true)]
		public int Usuario 
		{
			get { return GetColumnValue<int>(Columns.Usuario); }
			set { SetColumnValue(Columns.Usuario, value); }
		}
		  
		[XmlAttribute("FechaHora")]
		[Bindable(true)]
		public DateTime FechaHora 
		{
			get { return GetColumnValue<DateTime>(Columns.FechaHora); }
			set { SetColumnValue(Columns.FechaHora, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTipo,int varIdentificador,int varUsuario,DateTime varFechaHora)
		{
			InsumosBloqueo item = new InsumosBloqueo();
			
			item.Tipo = varTipo;
			
			item.Identificador = varIdentificador;
			
			item.Usuario = varUsuario;
			
			item.FechaHora = varFechaHora;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTicket,int varTipo,int varIdentificador,int varUsuario,DateTime varFechaHora)
		{
			InsumosBloqueo item = new InsumosBloqueo();
			
				item.Ticket = varTicket;
			
				item.Tipo = varTipo;
			
				item.Identificador = varIdentificador;
			
				item.Usuario = varUsuario;
			
				item.FechaHora = varFechaHora;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TicketColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TipoColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdentificadorColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UsuarioColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaHoraColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Ticket = @"Ticket";
			 public static string Tipo = @"Tipo";
			 public static string Identificador = @"Identificador";
			 public static string Usuario = @"Usuario";
			 public static string FechaHora = @"FechaHora";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
