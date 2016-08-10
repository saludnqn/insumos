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
	/// Strongly-typed collection for the PdPUCODiciembre class.
	/// </summary>
    [Serializable]
	public partial class PdPUCODiciembreCollection : ActiveList<PdPUCODiciembre, PdPUCODiciembreCollection>
	{	   
		public PdPUCODiciembreCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PdPUCODiciembreCollection</returns>
		public PdPUCODiciembreCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PdPUCODiciembre o = this[i];
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
	/// This is an ActiveRecord class which wraps the Pd_PUCODiciembre table.
	/// </summary>
	[Serializable]
	public partial class PdPUCODiciembre : ActiveRecord<PdPUCODiciembre>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PdPUCODiciembre()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PdPUCODiciembre(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PdPUCODiciembre(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PdPUCODiciembre(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Pd_PUCODiciembre", TableType.Table, DataService.GetInstance("padronProvider"));
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
				
				TableSchema.TableColumn colvarTipoDoc = new TableSchema.TableColumn(schema);
				colvarTipoDoc.ColumnName = "TipoDoc";
				colvarTipoDoc.DataType = DbType.AnsiString;
				colvarTipoDoc.MaxLength = 3;
				colvarTipoDoc.AutoIncrement = false;
				colvarTipoDoc.IsNullable = true;
				colvarTipoDoc.IsPrimaryKey = false;
				colvarTipoDoc.IsForeignKey = false;
				colvarTipoDoc.IsReadOnly = false;
				colvarTipoDoc.DefaultSetting = @"";
				colvarTipoDoc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTipoDoc);
				
				TableSchema.TableColumn colvarDni = new TableSchema.TableColumn(schema);
				colvarDni.ColumnName = "DNI";
				colvarDni.DataType = DbType.Int32;
				colvarDni.MaxLength = 0;
				colvarDni.AutoIncrement = false;
				colvarDni.IsNullable = true;
				colvarDni.IsPrimaryKey = false;
				colvarDni.IsForeignKey = false;
				colvarDni.IsReadOnly = false;
				colvarDni.DefaultSetting = @"";
				colvarDni.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDni);
				
				TableSchema.TableColumn colvarCodigoOS = new TableSchema.TableColumn(schema);
				colvarCodigoOS.ColumnName = "CodigoOS";
				colvarCodigoOS.DataType = DbType.Int32;
				colvarCodigoOS.MaxLength = 0;
				colvarCodigoOS.AutoIncrement = false;
				colvarCodigoOS.IsNullable = true;
				colvarCodigoOS.IsPrimaryKey = false;
				colvarCodigoOS.IsForeignKey = false;
				colvarCodigoOS.IsReadOnly = false;
				colvarCodigoOS.DefaultSetting = @"";
				colvarCodigoOS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoOS);
				
				TableSchema.TableColumn colvarTransmite = new TableSchema.TableColumn(schema);
				colvarTransmite.ColumnName = "Transmite";
				colvarTransmite.DataType = DbType.AnsiString;
				colvarTransmite.MaxLength = 1;
				colvarTransmite.AutoIncrement = false;
				colvarTransmite.IsNullable = true;
				colvarTransmite.IsPrimaryKey = false;
				colvarTransmite.IsForeignKey = false;
				colvarTransmite.IsReadOnly = false;
				colvarTransmite.DefaultSetting = @"";
				colvarTransmite.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransmite);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "Nombre";
				colvarNombre.DataType = DbType.AnsiString;
				colvarNombre.MaxLength = 40;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = true;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["padronProvider"].AddSchema("Pd_PUCODiciembre",schema);
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
		  
		[XmlAttribute("TipoDoc")]
		[Bindable(true)]
		public string TipoDoc 
		{
			get { return GetColumnValue<string>(Columns.TipoDoc); }
			set { SetColumnValue(Columns.TipoDoc, value); }
		}
		  
		[XmlAttribute("Dni")]
		[Bindable(true)]
		public int? Dni 
		{
			get { return GetColumnValue<int?>(Columns.Dni); }
			set { SetColumnValue(Columns.Dni, value); }
		}
		  
		[XmlAttribute("CodigoOS")]
		[Bindable(true)]
		public int? CodigoOS 
		{
			get { return GetColumnValue<int?>(Columns.CodigoOS); }
			set { SetColumnValue(Columns.CodigoOS, value); }
		}
		  
		[XmlAttribute("Transmite")]
		[Bindable(true)]
		public string Transmite 
		{
			get { return GetColumnValue<string>(Columns.Transmite); }
			set { SetColumnValue(Columns.Transmite, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTipoDoc,int? varDni,int? varCodigoOS,string varTransmite,string varNombre)
		{
			PdPUCODiciembre item = new PdPUCODiciembre();
			
			item.TipoDoc = varTipoDoc;
			
			item.Dni = varDni;
			
			item.CodigoOS = varCodigoOS;
			
			item.Transmite = varTransmite;
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varTipoDoc,int? varDni,int? varCodigoOS,string varTransmite,string varNombre)
		{
			PdPUCODiciembre item = new PdPUCODiciembre();
			
				item.Id = varId;
			
				item.TipoDoc = varTipoDoc;
			
				item.Dni = varDni;
			
				item.CodigoOS = varCodigoOS;
			
				item.Transmite = varTransmite;
			
				item.Nombre = varNombre;
			
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
        
        
        
        public static TableSchema.TableColumn TipoDocColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DniColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoOSColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TransmiteColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string TipoDoc = @"TipoDoc";
			 public static string Dni = @"DNI";
			 public static string CodigoOS = @"CodigoOS";
			 public static string Transmite = @"Transmite";
			 public static string Nombre = @"Nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
