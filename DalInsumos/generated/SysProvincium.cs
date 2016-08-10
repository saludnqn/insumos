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
	/// Strongly-typed collection for the SysProvincium class.
	/// </summary>
    [Serializable]
	public partial class SysProvinciumCollection : ActiveList<SysProvincium, SysProvinciumCollection>
	{	   
		public SysProvinciumCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysProvinciumCollection</returns>
		public SysProvinciumCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysProvincium o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Provincia table.
	/// </summary>
	[Serializable]
	public partial class SysProvincium : ActiveRecord<SysProvincium>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysProvincium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysProvincium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysProvincium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysProvincium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Provincia", TableType.Table, DataService.GetInstance("insProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdProvincia = new TableSchema.TableColumn(schema);
				colvarIdProvincia.ColumnName = "idProvincia";
				colvarIdProvincia.DataType = DbType.Int32;
				colvarIdProvincia.MaxLength = 0;
				colvarIdProvincia.AutoIncrement = true;
				colvarIdProvincia.IsNullable = false;
				colvarIdProvincia.IsPrimaryKey = true;
				colvarIdProvincia.IsForeignKey = false;
				colvarIdProvincia.IsReadOnly = false;
				colvarIdProvincia.DefaultSetting = @"";
				colvarIdProvincia.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdProvincia);
				
				TableSchema.TableColumn colvarNombre = new TableSchema.TableColumn(schema);
				colvarNombre.ColumnName = "nombre";
				colvarNombre.DataType = DbType.String;
				colvarNombre.MaxLength = 100;
				colvarNombre.AutoIncrement = false;
				colvarNombre.IsNullable = false;
				colvarNombre.IsPrimaryKey = false;
				colvarNombre.IsForeignKey = false;
				colvarNombre.IsReadOnly = false;
				colvarNombre.DefaultSetting = @"";
				colvarNombre.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNombre);
				
				TableSchema.TableColumn colvarIdPais = new TableSchema.TableColumn(schema);
				colvarIdPais.ColumnName = "idPais";
				colvarIdPais.DataType = DbType.Int32;
				colvarIdPais.MaxLength = 0;
				colvarIdPais.AutoIncrement = false;
				colvarIdPais.IsNullable = false;
				colvarIdPais.IsPrimaryKey = false;
				colvarIdPais.IsForeignKey = true;
				colvarIdPais.IsReadOnly = false;
				colvarIdPais.DefaultSetting = @"";
				
					colvarIdPais.ForeignKeyTableName = "Sys_Pais";
				schema.Columns.Add(colvarIdPais);
				
				TableSchema.TableColumn colvarCodigoINDEC = new TableSchema.TableColumn(schema);
				colvarCodigoINDEC.ColumnName = "codigoINDEC";
				colvarCodigoINDEC.DataType = DbType.String;
				colvarCodigoINDEC.MaxLength = 100;
				colvarCodigoINDEC.AutoIncrement = false;
				colvarCodigoINDEC.IsNullable = true;
				colvarCodigoINDEC.IsPrimaryKey = false;
				colvarCodigoINDEC.IsForeignKey = false;
				colvarCodigoINDEC.IsReadOnly = false;
				colvarCodigoINDEC.DefaultSetting = @"";
				colvarCodigoINDEC.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodigoINDEC);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["insProvider"].AddSchema("Sys_Provincia",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdProvincia")]
		[Bindable(true)]
		public int IdProvincia 
		{
			get { return GetColumnValue<int>(Columns.IdProvincia); }
			set { SetColumnValue(Columns.IdProvincia, value); }
		}
		  
		[XmlAttribute("Nombre")]
		[Bindable(true)]
		public string Nombre 
		{
			get { return GetColumnValue<string>(Columns.Nombre); }
			set { SetColumnValue(Columns.Nombre, value); }
		}
		  
		[XmlAttribute("IdPais")]
		[Bindable(true)]
		public int IdPais 
		{
			get { return GetColumnValue<int>(Columns.IdPais); }
			set { SetColumnValue(Columns.IdPais, value); }
		}
		  
		[XmlAttribute("CodigoINDEC")]
		[Bindable(true)]
		public string CodigoINDEC 
		{
			get { return GetColumnValue<string>(Columns.CodigoINDEC); }
			set { SetColumnValue(Columns.CodigoINDEC, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
				
		private DalInsumos.SysParentescoCollection colSysParentescoRecords;
		public DalInsumos.SysParentescoCollection SysParentescoRecords
		{
			get
			{
				if(colSysParentescoRecords == null)
				{
					colSysParentescoRecords = new DalInsumos.SysParentescoCollection().Where(SysParentesco.Columns.IdProvincia, IdProvincia).Load();
					colSysParentescoRecords.ListChanged += new ListChangedEventHandler(colSysParentescoRecords_ListChanged);
				}
				return colSysParentescoRecords;			
			}
			set 
			{ 
					colSysParentescoRecords = value; 
					colSysParentescoRecords.ListChanged += new ListChangedEventHandler(colSysParentescoRecords_ListChanged);
			}
		}
		
		void colSysParentescoRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysParentescoRecords[e.NewIndex].IdProvincia = IdProvincia;
		    }
		}
				
		private DalInsumos.SysPacienteCollection colSysPacienteRecords;
		public DalInsumos.SysPacienteCollection SysPacienteRecords
		{
			get
			{
				if(colSysPacienteRecords == null)
				{
					colSysPacienteRecords = new DalInsumos.SysPacienteCollection().Where(SysPaciente.Columns.IdProvincia, IdProvincia).Load();
					colSysPacienteRecords.ListChanged += new ListChangedEventHandler(colSysPacienteRecords_ListChanged);
				}
				return colSysPacienteRecords;			
			}
			set 
			{ 
					colSysPacienteRecords = value; 
					colSysPacienteRecords.ListChanged += new ListChangedEventHandler(colSysPacienteRecords_ListChanged);
			}
		}
		
		void colSysPacienteRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysPacienteRecords[e.NewIndex].IdProvincia = IdProvincia;
		    }
		}
				
		private DalInsumos.SysPacienteCollection colSysPacienteRecordsFromSysProvincium;
		public DalInsumos.SysPacienteCollection SysPacienteRecordsFromSysProvincium
		{
			get
			{
				if(colSysPacienteRecordsFromSysProvincium == null)
				{
					colSysPacienteRecordsFromSysProvincium = new DalInsumos.SysPacienteCollection().Where(SysPaciente.Columns.IdProvinciaDomicilio, IdProvincia).Load();
					colSysPacienteRecordsFromSysProvincium.ListChanged += new ListChangedEventHandler(colSysPacienteRecordsFromSysProvincium_ListChanged);
				}
				return colSysPacienteRecordsFromSysProvincium;			
			}
			set 
			{ 
					colSysPacienteRecordsFromSysProvincium = value; 
					colSysPacienteRecordsFromSysProvincium.ListChanged += new ListChangedEventHandler(colSysPacienteRecordsFromSysProvincium_ListChanged);
			}
		}
		
		void colSysPacienteRecordsFromSysProvincium_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colSysPacienteRecordsFromSysProvincium[e.NewIndex].IdProvinciaDomicilio = IdProvincia;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysPai ActiveRecord object related to this SysProvincium
		/// 
		/// </summary>
		public DalInsumos.SysPai SysPai
		{
			get { return DalInsumos.SysPai.FetchByID(this.IdPais); }
			set { SetColumnValue("idPais", value.IdPais); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public DalInsumos.SysNivelInstruccionCollection GetSysNivelInstruccionCollection() { return SysProvincium.GetSysNivelInstruccionCollection(this.IdProvincia); }
		public static DalInsumos.SysNivelInstruccionCollection GetSysNivelInstruccionCollection(int varIdProvincia)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_NivelInstruccion] INNER JOIN [Sys_Parentesco] ON [Sys_NivelInstruccion].[idNivelInstruccion] = [Sys_Parentesco].[idNivelInstruccion] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmd.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysNivelInstruccionCollection coll = new SysNivelInstruccionCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysNivelInstruccionMap(int varIdProvincia, SysNivelInstruccionCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysNivelInstruccion item in items)
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idNivelInstruccion", item.GetPrimaryKeyValue());
				varSysParentesco.Save();
			}
		}
		public static void SaveSysNivelInstruccionMap(int varIdProvincia, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SysParentesco varSysParentesco = new SysParentesco();
					varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
					varSysParentesco.SetColumnValue("idNivelInstruccion", l.Value);
					varSysParentesco.Save();
				}
			}
		}
		public static void SaveSysNivelInstruccionMap(int varIdProvincia , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idNivelInstruccion", item);
				varSysParentesco.Save();
			}
		}
		
		public static void DeleteSysNivelInstruccionMap(int varIdProvincia) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public DalInsumos.SysPaiCollection GetSysPaiCollection() { return SysProvincium.GetSysPaiCollection(this.IdProvincia); }
		public static DalInsumos.SysPaiCollection GetSysPaiCollection(int varIdProvincia)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_Pais] INNER JOIN [Sys_Parentesco] ON [Sys_Pais].[idPais] = [Sys_Parentesco].[idPais] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmd.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysPaiCollection coll = new SysPaiCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysPaiMap(int varIdProvincia, SysPaiCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysPai item in items)
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idPais", item.GetPrimaryKeyValue());
				varSysParentesco.Save();
			}
		}
		public static void SaveSysPaiMap(int varIdProvincia, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SysParentesco varSysParentesco = new SysParentesco();
					varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
					varSysParentesco.SetColumnValue("idPais", l.Value);
					varSysParentesco.Save();
				}
			}
		}
		public static void SaveSysPaiMap(int varIdProvincia , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idPais", item);
				varSysParentesco.Save();
			}
		}
		
		public static void DeleteSysPaiMap(int varIdProvincia) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public DalInsumos.SysParentescoCollection GetSysParentescoCollection() { return SysProvincium.GetSysParentescoCollection(this.IdProvincia); }
		public static DalInsumos.SysParentescoCollection GetSysParentescoCollection(int varIdProvincia)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_Parentesco] INNER JOIN [Sys_Parentesco] ON [Sys_Parentesco].[idParentesco] = [Sys_Parentesco].[idParentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmd.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysParentescoCollection coll = new SysParentescoCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysParentescoMap(int varIdProvincia, SysParentescoCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysParentesco item in items)
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idParentesco", item.GetPrimaryKeyValue());
				varSysParentesco.Save();
			}
		}
		public static void SaveSysParentescoMap(int varIdProvincia, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SysParentesco varSysParentesco = new SysParentesco();
					varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
					varSysParentesco.SetColumnValue("idParentesco", l.Value);
					varSysParentesco.Save();
				}
			}
		}
		public static void SaveSysParentescoMap(int varIdProvincia , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idParentesco", item);
				varSysParentesco.Save();
			}
		}
		
		public static void DeleteSysParentescoMap(int varIdProvincia) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public DalInsumos.SysProfesionCollection GetSysProfesionCollection() { return SysProvincium.GetSysProfesionCollection(this.IdProvincia); }
		public static DalInsumos.SysProfesionCollection GetSysProfesionCollection(int varIdProvincia)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_Profesion] INNER JOIN [Sys_Parentesco] ON [Sys_Profesion].[idProfesion] = [Sys_Parentesco].[idProfesion] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmd.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysProfesionCollection coll = new SysProfesionCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysProfesionMap(int varIdProvincia, SysProfesionCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysProfesion item in items)
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idProfesion", item.GetPrimaryKeyValue());
				varSysParentesco.Save();
			}
		}
		public static void SaveSysProfesionMap(int varIdProvincia, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SysParentesco varSysParentesco = new SysParentesco();
					varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
					varSysParentesco.SetColumnValue("idProfesion", l.Value);
					varSysParentesco.Save();
				}
			}
		}
		public static void SaveSysProfesionMap(int varIdProvincia , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idProfesion", item);
				varSysParentesco.Save();
			}
		}
		
		public static void DeleteSysProfesionMap(int varIdProvincia) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public DalInsumos.SysSituacionLaboralCollection GetSysSituacionLaboralCollection() { return SysProvincium.GetSysSituacionLaboralCollection(this.IdProvincia); }
		public static DalInsumos.SysSituacionLaboralCollection GetSysSituacionLaboralCollection(int varIdProvincia)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_SituacionLaboral] INNER JOIN [Sys_Parentesco] ON [Sys_SituacionLaboral].[idSituacionLaboral] = [Sys_Parentesco].[idSituacionLaboral] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmd.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysSituacionLaboralCollection coll = new SysSituacionLaboralCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysSituacionLaboralMap(int varIdProvincia, SysSituacionLaboralCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysSituacionLaboral item in items)
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idSituacionLaboral", item.GetPrimaryKeyValue());
				varSysParentesco.Save();
			}
		}
		public static void SaveSysSituacionLaboralMap(int varIdProvincia, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SysParentesco varSysParentesco = new SysParentesco();
					varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
					varSysParentesco.SetColumnValue("idSituacionLaboral", l.Value);
					varSysParentesco.Save();
				}
			}
		}
		public static void SaveSysSituacionLaboralMap(int varIdProvincia , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idSituacionLaboral", item);
				varSysParentesco.Save();
			}
		}
		
		public static void DeleteSysSituacionLaboralMap(int varIdProvincia) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public DalInsumos.SysTipoDocumentoCollection GetSysTipoDocumentoCollection() { return SysProvincium.GetSysTipoDocumentoCollection(this.IdProvincia); }
		public static DalInsumos.SysTipoDocumentoCollection GetSysTipoDocumentoCollection(int varIdProvincia)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_TipoDocumento] INNER JOIN [Sys_Parentesco] ON [Sys_TipoDocumento].[idTipoDocumento] = [Sys_Parentesco].[idTipoDocumento] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmd.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysTipoDocumentoCollection coll = new SysTipoDocumentoCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysTipoDocumentoMap(int varIdProvincia, SysTipoDocumentoCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysTipoDocumento item in items)
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idTipoDocumento", item.GetPrimaryKeyValue());
				varSysParentesco.Save();
			}
		}
		public static void SaveSysTipoDocumentoMap(int varIdProvincia, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SysParentesco varSysParentesco = new SysParentesco();
					varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
					varSysParentesco.SetColumnValue("idTipoDocumento", l.Value);
					varSysParentesco.Save();
				}
			}
		}
		public static void SaveSysTipoDocumentoMap(int varIdProvincia , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SysParentesco varSysParentesco = new SysParentesco();
				varSysParentesco.SetColumnValue("idProvincia", varIdProvincia);
				varSysParentesco.SetColumnValue("idTipoDocumento", item);
				varSysParentesco.Save();
			}
		}
		
		public static void DeleteSysTipoDocumentoMap(int varIdProvincia) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [Sys_Parentesco] WHERE [Sys_Parentesco].[idProvincia] = @idProvincia", SysProvincium.Schema.Provider.Name);
			cmdDel.AddParameter("@idProvincia", varIdProvincia, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNombre,int varIdPais,string varCodigoINDEC)
		{
			SysProvincium item = new SysProvincium();
			
			item.Nombre = varNombre;
			
			item.IdPais = varIdPais;
			
			item.CodigoINDEC = varCodigoINDEC;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIdProvincia,string varNombre,int varIdPais,string varCodigoINDEC)
		{
			SysProvincium item = new SysProvincium();
			
				item.IdProvincia = varIdProvincia;
			
				item.Nombre = varNombre;
			
				item.IdPais = varIdPais;
			
				item.CodigoINDEC = varCodigoINDEC;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdProvinciaColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NombreColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPaisColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CodigoINDECColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdProvincia = @"idProvincia";
			 public static string Nombre = @"nombre";
			 public static string IdPais = @"idPais";
			 public static string CodigoINDEC = @"codigoINDEC";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
                if (colSysParentescoRecords != null)
                {
                    foreach (DalInsumos.SysParentesco item in colSysParentescoRecords)
                    {
                        if (item.IdProvincia != IdProvincia)
                        {
                            item.IdProvincia = IdProvincia;
                        }
                    }
               }
		
                if (colSysPacienteRecords != null)
                {
                    foreach (DalInsumos.SysPaciente item in colSysPacienteRecords)
                    {
                        if (item.IdProvincia != IdProvincia)
                        {
                            item.IdProvincia = IdProvincia;
                        }
                    }
               }
		
                if (colSysPacienteRecordsFromSysProvincium != null)
                {
                    foreach (DalInsumos.SysPaciente item in colSysPacienteRecordsFromSysProvincium)
                    {
                        if (item.IdProvinciaDomicilio != IdProvincia)
                        {
                            item.IdProvinciaDomicilio = IdProvincia;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colSysParentescoRecords != null)
                {
                    colSysParentescoRecords.SaveAll();
               }
		
                if (colSysPacienteRecords != null)
                {
                    colSysPacienteRecords.SaveAll();
               }
		
                if (colSysPacienteRecordsFromSysProvincium != null)
                {
                    colSysPacienteRecordsFromSysProvincium.SaveAll();
               }
		}
        #endregion
	}
}
