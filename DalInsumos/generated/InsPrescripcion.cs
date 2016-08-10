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
	/// Strongly-typed collection for the InsPrescripcion class.
	/// </summary>
    [Serializable]
	public partial class InsPrescripcionCollection : ActiveList<InsPrescripcion, InsPrescripcionCollection>
	{	   
		public InsPrescripcionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InsPrescripcionCollection</returns>
		public InsPrescripcionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InsPrescripcion o = this[i];
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
	/// This is an ActiveRecord class which wraps the INS_Prescripcion table.
	/// </summary>
	[Serializable]
	public partial class InsPrescripcion : ActiveRecord<InsPrescripcion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InsPrescripcion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InsPrescripcion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InsPrescripcion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InsPrescripcion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("INS_Prescripcion", TableType.Table, DataService.GetInstance("insProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarIdPrescripcion = new TableSchema.TableColumn(schema);
				colvarIdPrescripcion.ColumnName = "idPrescripcion";
				colvarIdPrescripcion.DataType = DbType.Int32;
				colvarIdPrescripcion.MaxLength = 0;
				colvarIdPrescripcion.AutoIncrement = true;
				colvarIdPrescripcion.IsNullable = false;
				colvarIdPrescripcion.IsPrimaryKey = true;
				colvarIdPrescripcion.IsForeignKey = false;
				colvarIdPrescripcion.IsReadOnly = false;
				colvarIdPrescripcion.DefaultSetting = @"";
				colvarIdPrescripcion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdPrescripcion);
				
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
				
				TableSchema.TableColumn colvarIdPaciente = new TableSchema.TableColumn(schema);
				colvarIdPaciente.ColumnName = "idPaciente";
				colvarIdPaciente.DataType = DbType.Int32;
				colvarIdPaciente.MaxLength = 0;
				colvarIdPaciente.AutoIncrement = false;
				colvarIdPaciente.IsNullable = true;
				colvarIdPaciente.IsPrimaryKey = false;
				colvarIdPaciente.IsForeignKey = true;
				colvarIdPaciente.IsReadOnly = false;
				colvarIdPaciente.DefaultSetting = @"";
				
					colvarIdPaciente.ForeignKeyTableName = "Sys_Paciente";
				schema.Columns.Add(colvarIdPaciente);
				
				TableSchema.TableColumn colvarEdad = new TableSchema.TableColumn(schema);
				colvarEdad.ColumnName = "edad";
				colvarEdad.DataType = DbType.Int32;
				colvarEdad.MaxLength = 0;
				colvarEdad.AutoIncrement = false;
				colvarEdad.IsNullable = true;
				colvarEdad.IsPrimaryKey = false;
				colvarEdad.IsForeignKey = false;
				colvarEdad.IsReadOnly = false;
				colvarEdad.DefaultSetting = @"";
				colvarEdad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEdad);
				
				TableSchema.TableColumn colvarUnidad = new TableSchema.TableColumn(schema);
				colvarUnidad.ColumnName = "unidad";
				colvarUnidad.DataType = DbType.AnsiString;
				colvarUnidad.MaxLength = 20;
				colvarUnidad.AutoIncrement = false;
				colvarUnidad.IsNullable = true;
				colvarUnidad.IsPrimaryKey = false;
				colvarUnidad.IsForeignKey = false;
				colvarUnidad.IsReadOnly = false;
				colvarUnidad.DefaultSetting = @"";
				colvarUnidad.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidad);
				
				TableSchema.TableColumn colvarIdTipoPrescripcion = new TableSchema.TableColumn(schema);
				colvarIdTipoPrescripcion.ColumnName = "idTipoPrescripcion";
				colvarIdTipoPrescripcion.DataType = DbType.Int32;
				colvarIdTipoPrescripcion.MaxLength = 0;
				colvarIdTipoPrescripcion.AutoIncrement = false;
				colvarIdTipoPrescripcion.IsNullable = true;
				colvarIdTipoPrescripcion.IsPrimaryKey = false;
				colvarIdTipoPrescripcion.IsForeignKey = true;
				colvarIdTipoPrescripcion.IsReadOnly = false;
				colvarIdTipoPrescripcion.DefaultSetting = @"";
				
					colvarIdTipoPrescripcion.ForeignKeyTableName = "INS_TipoPrescripcion";
				schema.Columns.Add(colvarIdTipoPrescripcion);
				
				TableSchema.TableColumn colvarIdObraSocial = new TableSchema.TableColumn(schema);
				colvarIdObraSocial.ColumnName = "idObraSocial";
				colvarIdObraSocial.DataType = DbType.Int32;
				colvarIdObraSocial.MaxLength = 0;
				colvarIdObraSocial.AutoIncrement = false;
				colvarIdObraSocial.IsNullable = true;
				colvarIdObraSocial.IsPrimaryKey = false;
				colvarIdObraSocial.IsForeignKey = true;
				colvarIdObraSocial.IsReadOnly = false;
				colvarIdObraSocial.DefaultSetting = @"";
				
					colvarIdObraSocial.ForeignKeyTableName = "Sys_ObraSocial";
				schema.Columns.Add(colvarIdObraSocial);
				
				TableSchema.TableColumn colvarIdProfesional = new TableSchema.TableColumn(schema);
				colvarIdProfesional.ColumnName = "idProfesional";
				colvarIdProfesional.DataType = DbType.Int32;
				colvarIdProfesional.MaxLength = 0;
				colvarIdProfesional.AutoIncrement = false;
				colvarIdProfesional.IsNullable = true;
				colvarIdProfesional.IsPrimaryKey = false;
				colvarIdProfesional.IsForeignKey = true;
				colvarIdProfesional.IsReadOnly = false;
				colvarIdProfesional.DefaultSetting = @"";
				
					colvarIdProfesional.ForeignKeyTableName = "Sys_Profesional";
				schema.Columns.Add(colvarIdProfesional);
				
				TableSchema.TableColumn colvarDiagnostico = new TableSchema.TableColumn(schema);
				colvarDiagnostico.ColumnName = "diagnostico";
				colvarDiagnostico.DataType = DbType.AnsiString;
				colvarDiagnostico.MaxLength = 200;
				colvarDiagnostico.AutoIncrement = false;
				colvarDiagnostico.IsNullable = true;
				colvarDiagnostico.IsPrimaryKey = false;
				colvarDiagnostico.IsForeignKey = false;
				colvarDiagnostico.IsReadOnly = false;
				colvarDiagnostico.DefaultSetting = @"";
				colvarDiagnostico.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagnostico);
				
				TableSchema.TableColumn colvarIdCODCie10 = new TableSchema.TableColumn(schema);
				colvarIdCODCie10.ColumnName = "idCODCie10";
				colvarIdCODCie10.DataType = DbType.Int32;
				colvarIdCODCie10.MaxLength = 0;
				colvarIdCODCie10.AutoIncrement = false;
				colvarIdCODCie10.IsNullable = true;
				colvarIdCODCie10.IsPrimaryKey = false;
				colvarIdCODCie10.IsForeignKey = true;
				colvarIdCODCie10.IsReadOnly = false;
				
						colvarIdCODCie10.DefaultSetting = @"((0))";
				
					colvarIdCODCie10.ForeignKeyTableName = "Sys_CIE10";
				schema.Columns.Add(colvarIdCODCie10);
				
				TableSchema.TableColumn colvarFecha = new TableSchema.TableColumn(schema);
				colvarFecha.ColumnName = "fecha";
				colvarFecha.DataType = DbType.DateTime;
				colvarFecha.MaxLength = 0;
				colvarFecha.AutoIncrement = false;
				colvarFecha.IsNullable = true;
				colvarFecha.IsPrimaryKey = false;
				colvarFecha.IsForeignKey = false;
				colvarFecha.IsReadOnly = false;
				colvarFecha.DefaultSetting = @"";
				colvarFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFecha);
				
				TableSchema.TableColumn colvarObservaciones = new TableSchema.TableColumn(schema);
				colvarObservaciones.ColumnName = "observaciones";
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
				
				TableSchema.TableColumn colvarIdTipoTratamiento = new TableSchema.TableColumn(schema);
				colvarIdTipoTratamiento.ColumnName = "idTipoTratamiento";
				colvarIdTipoTratamiento.DataType = DbType.Int32;
				colvarIdTipoTratamiento.MaxLength = 0;
				colvarIdTipoTratamiento.AutoIncrement = false;
				colvarIdTipoTratamiento.IsNullable = true;
				colvarIdTipoTratamiento.IsPrimaryKey = false;
				colvarIdTipoTratamiento.IsForeignKey = true;
				colvarIdTipoTratamiento.IsReadOnly = false;
				colvarIdTipoTratamiento.DefaultSetting = @"";
				
					colvarIdTipoTratamiento.ForeignKeyTableName = "INS_TipoTratamiento";
				schema.Columns.Add(colvarIdTipoTratamiento);
				
				TableSchema.TableColumn colvarDuracion = new TableSchema.TableColumn(schema);
				colvarDuracion.ColumnName = "duracion";
				colvarDuracion.DataType = DbType.Int32;
				colvarDuracion.MaxLength = 0;
				colvarDuracion.AutoIncrement = false;
				colvarDuracion.IsNullable = true;
				colvarDuracion.IsPrimaryKey = false;
				colvarDuracion.IsForeignKey = false;
				colvarDuracion.IsReadOnly = false;
				colvarDuracion.DefaultSetting = @"";
				colvarDuracion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDuracion);
				
				TableSchema.TableColumn colvarUnidadDuracion = new TableSchema.TableColumn(schema);
				colvarUnidadDuracion.ColumnName = "unidadDuracion";
				colvarUnidadDuracion.DataType = DbType.AnsiString;
				colvarUnidadDuracion.MaxLength = 10;
				colvarUnidadDuracion.AutoIncrement = false;
				colvarUnidadDuracion.IsNullable = true;
				colvarUnidadDuracion.IsPrimaryKey = false;
				colvarUnidadDuracion.IsForeignKey = false;
				colvarUnidadDuracion.IsReadOnly = false;
				colvarUnidadDuracion.DefaultSetting = @"";
				colvarUnidadDuracion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnidadDuracion);
				
				TableSchema.TableColumn colvarProximaFecha = new TableSchema.TableColumn(schema);
				colvarProximaFecha.ColumnName = "proximaFecha";
				colvarProximaFecha.DataType = DbType.DateTime;
				colvarProximaFecha.MaxLength = 0;
				colvarProximaFecha.AutoIncrement = false;
				colvarProximaFecha.IsNullable = true;
				colvarProximaFecha.IsPrimaryKey = false;
				colvarProximaFecha.IsForeignKey = false;
				colvarProximaFecha.IsReadOnly = false;
				colvarProximaFecha.DefaultSetting = @"";
				colvarProximaFecha.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProximaFecha);
				
				TableSchema.TableColumn colvarNumeroDispensacion = new TableSchema.TableColumn(schema);
				colvarNumeroDispensacion.ColumnName = "numeroDispensacion";
				colvarNumeroDispensacion.DataType = DbType.Int32;
				colvarNumeroDispensacion.MaxLength = 0;
				colvarNumeroDispensacion.AutoIncrement = false;
				colvarNumeroDispensacion.IsNullable = true;
				colvarNumeroDispensacion.IsPrimaryKey = false;
				colvarNumeroDispensacion.IsForeignKey = false;
				colvarNumeroDispensacion.IsReadOnly = false;
				colvarNumeroDispensacion.DefaultSetting = @"";
				colvarNumeroDispensacion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNumeroDispensacion);
				
				TableSchema.TableColumn colvarRecetaVencida = new TableSchema.TableColumn(schema);
				colvarRecetaVencida.ColumnName = "recetaVencida";
				colvarRecetaVencida.DataType = DbType.Boolean;
				colvarRecetaVencida.MaxLength = 0;
				colvarRecetaVencida.AutoIncrement = false;
				colvarRecetaVencida.IsNullable = false;
				colvarRecetaVencida.IsPrimaryKey = false;
				colvarRecetaVencida.IsForeignKey = false;
				colvarRecetaVencida.IsReadOnly = false;
				
						colvarRecetaVencida.DefaultSetting = @"((0))";
				colvarRecetaVencida.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRecetaVencida);
				
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
				DataService.Providers["insProvider"].AddSchema("INS_Prescripcion",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("IdPrescripcion")]
		[Bindable(true)]
		public int IdPrescripcion 
		{
			get { return GetColumnValue<int>(Columns.IdPrescripcion); }
			set { SetColumnValue(Columns.IdPrescripcion, value); }
		}
		  
		[XmlAttribute("IdEfector")]
		[Bindable(true)]
		public int? IdEfector 
		{
			get { return GetColumnValue<int?>(Columns.IdEfector); }
			set { SetColumnValue(Columns.IdEfector, value); }
		}
		  
		[XmlAttribute("IdDeposito")]
		[Bindable(true)]
		public int? IdDeposito 
		{
			get { return GetColumnValue<int?>(Columns.IdDeposito); }
			set { SetColumnValue(Columns.IdDeposito, value); }
		}
		  
		[XmlAttribute("IdPaciente")]
		[Bindable(true)]
		public int? IdPaciente 
		{
			get { return GetColumnValue<int?>(Columns.IdPaciente); }
			set { SetColumnValue(Columns.IdPaciente, value); }
		}
		  
		[XmlAttribute("Edad")]
		[Bindable(true)]
		public int? Edad 
		{
			get { return GetColumnValue<int?>(Columns.Edad); }
			set { SetColumnValue(Columns.Edad, value); }
		}
		  
		[XmlAttribute("Unidad")]
		[Bindable(true)]
		public string Unidad 
		{
			get { return GetColumnValue<string>(Columns.Unidad); }
			set { SetColumnValue(Columns.Unidad, value); }
		}
		  
		[XmlAttribute("IdTipoPrescripcion")]
		[Bindable(true)]
		public int? IdTipoPrescripcion 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoPrescripcion); }
			set { SetColumnValue(Columns.IdTipoPrescripcion, value); }
		}
		  
		[XmlAttribute("IdObraSocial")]
		[Bindable(true)]
		public int? IdObraSocial 
		{
			get { return GetColumnValue<int?>(Columns.IdObraSocial); }
			set { SetColumnValue(Columns.IdObraSocial, value); }
		}
		  
		[XmlAttribute("IdProfesional")]
		[Bindable(true)]
		public int? IdProfesional 
		{
			get { return GetColumnValue<int?>(Columns.IdProfesional); }
			set { SetColumnValue(Columns.IdProfesional, value); }
		}
		  
		[XmlAttribute("Diagnostico")]
		[Bindable(true)]
		public string Diagnostico 
		{
			get { return GetColumnValue<string>(Columns.Diagnostico); }
			set { SetColumnValue(Columns.Diagnostico, value); }
		}
		  
		[XmlAttribute("IdCODCie10")]
		[Bindable(true)]
		public int? IdCODCie10 
		{
			get { return GetColumnValue<int?>(Columns.IdCODCie10); }
			set { SetColumnValue(Columns.IdCODCie10, value); }
		}
		  
		[XmlAttribute("Fecha")]
		[Bindable(true)]
		public DateTime? Fecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.Fecha); }
			set { SetColumnValue(Columns.Fecha, value); }
		}
		  
		[XmlAttribute("Observaciones")]
		[Bindable(true)]
		public string Observaciones 
		{
			get { return GetColumnValue<string>(Columns.Observaciones); }
			set { SetColumnValue(Columns.Observaciones, value); }
		}
		  
		[XmlAttribute("IdTipoTratamiento")]
		[Bindable(true)]
		public int? IdTipoTratamiento 
		{
			get { return GetColumnValue<int?>(Columns.IdTipoTratamiento); }
			set { SetColumnValue(Columns.IdTipoTratamiento, value); }
		}
		  
		[XmlAttribute("Duracion")]
		[Bindable(true)]
		public int? Duracion 
		{
			get { return GetColumnValue<int?>(Columns.Duracion); }
			set { SetColumnValue(Columns.Duracion, value); }
		}
		  
		[XmlAttribute("UnidadDuracion")]
		[Bindable(true)]
		public string UnidadDuracion 
		{
			get { return GetColumnValue<string>(Columns.UnidadDuracion); }
			set { SetColumnValue(Columns.UnidadDuracion, value); }
		}
		  
		[XmlAttribute("ProximaFecha")]
		[Bindable(true)]
		public DateTime? ProximaFecha 
		{
			get { return GetColumnValue<DateTime?>(Columns.ProximaFecha); }
			set { SetColumnValue(Columns.ProximaFecha, value); }
		}
		  
		[XmlAttribute("NumeroDispensacion")]
		[Bindable(true)]
		public int? NumeroDispensacion 
		{
			get { return GetColumnValue<int?>(Columns.NumeroDispensacion); }
			set { SetColumnValue(Columns.NumeroDispensacion, value); }
		}
		  
		[XmlAttribute("RecetaVencida")]
		[Bindable(true)]
		public bool RecetaVencida 
		{
			get { return GetColumnValue<bool>(Columns.RecetaVencida); }
			set { SetColumnValue(Columns.RecetaVencida, value); }
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
        
				
		private DalInsumos.InsPrescripcionDetalleCollection colInsPrescripcionDetalleRecords;
		public DalInsumos.InsPrescripcionDetalleCollection InsPrescripcionDetalleRecords
		{
			get
			{
				if(colInsPrescripcionDetalleRecords == null)
				{
					colInsPrescripcionDetalleRecords = new DalInsumos.InsPrescripcionDetalleCollection().Where(InsPrescripcionDetalle.Columns.IdPrescripcion, IdPrescripcion).Load();
					colInsPrescripcionDetalleRecords.ListChanged += new ListChangedEventHandler(colInsPrescripcionDetalleRecords_ListChanged);
				}
				return colInsPrescripcionDetalleRecords;			
			}
			set 
			{ 
					colInsPrescripcionDetalleRecords = value; 
					colInsPrescripcionDetalleRecords.ListChanged += new ListChangedEventHandler(colInsPrescripcionDetalleRecords_ListChanged);
			}
		}
		
		void colInsPrescripcionDetalleRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsPrescripcionDetalleRecords[e.NewIndex].IdPrescripcion = IdPrescripcion;
		    }
		}
				
		private DalInsumos.InsDispensacionCollection colInsDispensacionRecords;
		public DalInsumos.InsDispensacionCollection InsDispensacionRecords
		{
			get
			{
				if(colInsDispensacionRecords == null)
				{
					colInsDispensacionRecords = new DalInsumos.InsDispensacionCollection().Where(InsDispensacion.Columns.IdPrescripcion, IdPrescripcion).Load();
					colInsDispensacionRecords.ListChanged += new ListChangedEventHandler(colInsDispensacionRecords_ListChanged);
				}
				return colInsDispensacionRecords;			
			}
			set 
			{ 
					colInsDispensacionRecords = value; 
					colInsDispensacionRecords.ListChanged += new ListChangedEventHandler(colInsDispensacionRecords_ListChanged);
			}
		}
		
		void colInsDispensacionRecords_ListChanged(object sender, ListChangedEventArgs e)
		{
		    if (e.ListChangedType == ListChangedType.ItemAdded)
		    {
		        // Set foreign key value
		        colInsDispensacionRecords[e.NewIndex].IdPrescripcion = IdPrescripcion;
		    }
		}
		
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysProfesional ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.SysProfesional SysProfesional
		{
			get { return DalInsumos.SysProfesional.FetchByID(this.IdProfesional); }
			set { SetColumnValue("idProfesional", value.IdProfesional); }
		}
		
		
		/// <summary>
		/// Returns a SysCIE10 ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.SysCIE10 SysCIE10
		{
			get { return DalInsumos.SysCIE10.FetchByID(this.IdCODCie10); }
			set { SetColumnValue("idCODCie10", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a SysPaciente ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.SysPaciente SysPaciente
		{
			get { return DalInsumos.SysPaciente.FetchByID(this.IdPaciente); }
			set { SetColumnValue("idPaciente", value.IdPaciente); }
		}
		
		
		/// <summary>
		/// Returns a SysObraSocial ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.SysObraSocial SysObraSocial
		{
			get { return DalInsumos.SysObraSocial.FetchByID(this.IdObraSocial); }
			set { SetColumnValue("idObraSocial", value.IdObraSocial); }
		}
		
		
		/// <summary>
		/// Returns a InsTipoTratamiento ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.InsTipoTratamiento InsTipoTratamiento
		{
			get { return DalInsumos.InsTipoTratamiento.FetchByID(this.IdTipoTratamiento); }
			set { SetColumnValue("idTipoTratamiento", value.IdTipoTratamiento); }
		}
		
		
		/// <summary>
		/// Returns a InsTipoPrescripcion ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.InsTipoPrescripcion InsTipoPrescripcion
		{
			get { return DalInsumos.InsTipoPrescripcion.FetchByID(this.IdTipoPrescripcion); }
			set { SetColumnValue("idTipoPrescripcion", value.IdTipoPrescripcion); }
		}
		
		
		/// <summary>
		/// Returns a InsDeposito ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.InsDeposito InsDeposito
		{
			get { return DalInsumos.InsDeposito.FetchByID(this.IdDeposito); }
			set { SetColumnValue("idDeposito", value.IdDeposito); }
		}
		
		
		/// <summary>
		/// Returns a SysEfector ActiveRecord object related to this InsPrescripcion
		/// 
		/// </summary>
		public DalInsumos.SysEfector SysEfector
		{
			get { return DalInsumos.SysEfector.FetchByID(this.IdEfector); }
			set { SetColumnValue("idEfector", value.IdEfector); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdEfector,int? varIdDeposito,int? varIdPaciente,int? varEdad,string varUnidad,int? varIdTipoPrescripcion,int? varIdObraSocial,int? varIdProfesional,string varDiagnostico,int? varIdCODCie10,DateTime? varFecha,string varObservaciones,int? varIdTipoTratamiento,int? varDuracion,string varUnidadDuracion,DateTime? varProximaFecha,int? varNumeroDispensacion,bool varRecetaVencida,bool varBaja,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			InsPrescripcion item = new InsPrescripcion();
			
			item.IdEfector = varIdEfector;
			
			item.IdDeposito = varIdDeposito;
			
			item.IdPaciente = varIdPaciente;
			
			item.Edad = varEdad;
			
			item.Unidad = varUnidad;
			
			item.IdTipoPrescripcion = varIdTipoPrescripcion;
			
			item.IdObraSocial = varIdObraSocial;
			
			item.IdProfesional = varIdProfesional;
			
			item.Diagnostico = varDiagnostico;
			
			item.IdCODCie10 = varIdCODCie10;
			
			item.Fecha = varFecha;
			
			item.Observaciones = varObservaciones;
			
			item.IdTipoTratamiento = varIdTipoTratamiento;
			
			item.Duracion = varDuracion;
			
			item.UnidadDuracion = varUnidadDuracion;
			
			item.ProximaFecha = varProximaFecha;
			
			item.NumeroDispensacion = varNumeroDispensacion;
			
			item.RecetaVencida = varRecetaVencida;
			
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
		public static void Update(int varIdPrescripcion,int? varIdEfector,int? varIdDeposito,int? varIdPaciente,int? varEdad,string varUnidad,int? varIdTipoPrescripcion,int? varIdObraSocial,int? varIdProfesional,string varDiagnostico,int? varIdCODCie10,DateTime? varFecha,string varObservaciones,int? varIdTipoTratamiento,int? varDuracion,string varUnidadDuracion,DateTime? varProximaFecha,int? varNumeroDispensacion,bool varRecetaVencida,bool varBaja,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiedOn)
		{
			InsPrescripcion item = new InsPrescripcion();
			
				item.IdPrescripcion = varIdPrescripcion;
			
				item.IdEfector = varIdEfector;
			
				item.IdDeposito = varIdDeposito;
			
				item.IdPaciente = varIdPaciente;
			
				item.Edad = varEdad;
			
				item.Unidad = varUnidad;
			
				item.IdTipoPrescripcion = varIdTipoPrescripcion;
			
				item.IdObraSocial = varIdObraSocial;
			
				item.IdProfesional = varIdProfesional;
			
				item.Diagnostico = varDiagnostico;
			
				item.IdCODCie10 = varIdCODCie10;
			
				item.Fecha = varFecha;
			
				item.Observaciones = varObservaciones;
			
				item.IdTipoTratamiento = varIdTipoTratamiento;
			
				item.Duracion = varDuracion;
			
				item.UnidadDuracion = varUnidadDuracion;
			
				item.ProximaFecha = varProximaFecha;
			
				item.NumeroDispensacion = varNumeroDispensacion;
			
				item.RecetaVencida = varRecetaVencida;
			
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
        
        
        public static TableSchema.TableColumn IdPrescripcionColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdEfectorColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdDepositoColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IdPacienteColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EdadColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoPrescripcionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IdObraSocialColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IdProfesionalColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn DiagnosticoColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IdCODCie10Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FechaColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ObservacionesColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn IdTipoTratamientoColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DuracionColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn UnidadDuracionColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ProximaFechaColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn NumeroDispensacionColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn RecetaVencidaColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn BajaColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string IdPrescripcion = @"idPrescripcion";
			 public static string IdEfector = @"idEfector";
			 public static string IdDeposito = @"idDeposito";
			 public static string IdPaciente = @"idPaciente";
			 public static string Edad = @"edad";
			 public static string Unidad = @"unidad";
			 public static string IdTipoPrescripcion = @"idTipoPrescripcion";
			 public static string IdObraSocial = @"idObraSocial";
			 public static string IdProfesional = @"idProfesional";
			 public static string Diagnostico = @"diagnostico";
			 public static string IdCODCie10 = @"idCODCie10";
			 public static string Fecha = @"fecha";
			 public static string Observaciones = @"observaciones";
			 public static string IdTipoTratamiento = @"idTipoTratamiento";
			 public static string Duracion = @"duracion";
			 public static string UnidadDuracion = @"unidadDuracion";
			 public static string ProximaFecha = @"proximaFecha";
			 public static string NumeroDispensacion = @"numeroDispensacion";
			 public static string RecetaVencida = @"recetaVencida";
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
                if (colInsPrescripcionDetalleRecords != null)
                {
                    foreach (DalInsumos.InsPrescripcionDetalle item in colInsPrescripcionDetalleRecords)
                    {
                        if (item.IdPrescripcion == null ||item.IdPrescripcion != IdPrescripcion)
                        {
                            item.IdPrescripcion = IdPrescripcion;
                        }
                    }
               }
		
                if (colInsDispensacionRecords != null)
                {
                    foreach (DalInsumos.InsDispensacion item in colInsDispensacionRecords)
                    {
                        if (item.IdPrescripcion == null ||item.IdPrescripcion != IdPrescripcion)
                        {
                            item.IdPrescripcion = IdPrescripcion;
                        }
                    }
               }
		}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
                if (colInsPrescripcionDetalleRecords != null)
                {
                    colInsPrescripcionDetalleRecords.SaveAll();
               }
		
                if (colInsDispensacionRecords != null)
                {
                    colInsDispensacionRecords.SaveAll();
               }
		}
        #endregion
	}
}