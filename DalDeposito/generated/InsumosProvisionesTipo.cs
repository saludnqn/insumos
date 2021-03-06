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
	/// Strongly-typed collection for the InsumosProvisionesTipo class.
	/// </summary>
    [Serializable]
	public partial class InsumosProvisionesTipoCollection : ActiveList<InsumosProvisionesTipo, InsumosProvisionesTipoCollection>
	{	   
		public InsumosProvisionesTipoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsumosProvisionesTipoCollection</returns>
		public InsumosProvisionesTipoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsumosProvisionesTipo o = this[i];
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
	/// This is an ActiveRecord class which wraps the Insumos_Provisiones_Tipos table.
	/// </summary>
	[Serializable]
	public partial class InsumosProvisionesTipo : ActiveRecord<InsumosProvisionesTipo>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsumosProvisionesTipo()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsumosProvisionesTipo(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsumosProvisionesTipo(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsumosProvisionesTipo(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Insumos_Provisiones_Tipos", TableType.Table, DataService.GetInstance("depProvider"));
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["depProvider"].AddSchema("Insumos_Provisiones_Tipos",schema);
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
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalDeposito.InsumosProvisionesAgenteCollection colInsumosProvisionesAgentes;
		public DalDeposito.InsumosProvisionesAgenteCollection InsumosProvisionesAgentes
		{
			get
			{
				if(colInsumosProvisionesAgentes == null)
				{
					colInsumosProvisionesAgentes = new DalDeposito.InsumosProvisionesAgenteCollection().Where(InsumosProvisionesAgente.Columns.Tipo, Codigo).Load();
					colInsumosProvisionesAgentes.ListChanged += new ListChangedEventHandler(colInsumosProvisionesAgentes_ListChanged);
				}
				return colInsumosProvisionesAgentes;			
			}
			set 
			{ 
					colInsumosProvisionesAgentes = value; 
					colInsumosProvisionesAgentes.ListChanged += new ListChangedEventHandler(colInsumosProvisionesAgentes_ListChanged);
			}
		}
		
		void colInsumosProvisionesAgentes_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsumosProvisionesAgentes[e.NewIndex].Tipo = Codigo;
		    }
		}
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre)
		{
			InsumosProvisionesTipo item = new InsumosProvisionesTipo();
			
			item.Nombre = varNombre;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCodigo,string varNombre)
		{
			InsumosProvisionesTipo item = new InsumosProvisionesTipo();
			
				item.Codigo = varCodigo;
			
				item.Nombre = varNombre;
			
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
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Codigo = @"Codigo";
			 public static string Nombre = @"Nombre";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colInsumosProvisionesAgentes != null)
                {
                    foreach (DalDeposito.InsumosProvisionesAgente item in colInsumosProvisionesAgentes)
                    {
                        if (item.Tipo != Codigo)
                        {
                            item.Tipo = Codigo;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colInsumosProvisionesAgentes != null)
                {
                    colInsumosProvisionesAgentes.SaveAll();
               }
		}
        #endregion
	}
}
