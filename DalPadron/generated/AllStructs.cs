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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string PdIose = @"Pd_Iose";
        
		public static readonly string PdIoseFull = @"Pd_Iose_Full";
        
		public static readonly string PdIssn = @"Pd_Issn";
        
		public static readonly string PdIssn2 = @"Pd_Issn2";
        
		public static readonly string PdObraSoc = @"Pd_ObraSoc";
        
		public static readonly string PdObraSoc2 = @"Pd_ObraSoc2";
        
		public static readonly string PdPaciente = @"Pd_Paciente";
        
		public static readonly string PdPami = @"Pd_Pami";
        
		public static readonly string PdPami20120409 = @"Pd_Pami20120409";
        
		public static readonly string PdPamiC = @"Pd_PamiC";
        
		public static readonly string PdProfe = @"Pd_Profe";
        
		public static readonly string PdPuco = @"Pd_PUCO";
        
		public static readonly string PdPUCODiciembre = @"Pd_PUCODiciembre";
        
		public static readonly string PdTotal = @"PD_TOTAL";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table PdIose
		{
            get { return DataService.GetSchema("Pd_Iose", "padronProvider"); }
		}
        
		public static TableSchema.Table PdIoseFull
		{
            get { return DataService.GetSchema("Pd_Iose_Full", "padronProvider"); }
		}
        
		public static TableSchema.Table PdIssn
		{
            get { return DataService.GetSchema("Pd_Issn", "padronProvider"); }
		}
        
		public static TableSchema.Table PdIssn2
		{
            get { return DataService.GetSchema("Pd_Issn2", "padronProvider"); }
		}
        
		public static TableSchema.Table PdObraSoc
		{
            get { return DataService.GetSchema("Pd_ObraSoc", "padronProvider"); }
		}
        
		public static TableSchema.Table PdObraSoc2
		{
            get { return DataService.GetSchema("Pd_ObraSoc2", "padronProvider"); }
		}
        
		public static TableSchema.Table PdPaciente
		{
            get { return DataService.GetSchema("Pd_Paciente", "padronProvider"); }
		}
        
		public static TableSchema.Table PdPami
		{
            get { return DataService.GetSchema("Pd_Pami", "padronProvider"); }
		}
        
		public static TableSchema.Table PdPami20120409
		{
            get { return DataService.GetSchema("Pd_Pami20120409", "padronProvider"); }
		}
        
		public static TableSchema.Table PdPamiC
		{
            get { return DataService.GetSchema("Pd_PamiC", "padronProvider"); }
		}
        
		public static TableSchema.Table PdProfe
		{
            get { return DataService.GetSchema("Pd_Profe", "padronProvider"); }
		}
        
		public static TableSchema.Table PdPuco
		{
            get { return DataService.GetSchema("Pd_PUCO", "padronProvider"); }
		}
        
		public static TableSchema.Table PdPUCODiciembre
		{
            get { return DataService.GetSchema("Pd_PUCODiciembre", "padronProvider"); }
		}
        
		public static TableSchema.Table PdTotal
		{
            get { return DataService.GetSchema("PD_TOTAL", "padronProvider"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["padronProvider"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository 
        {
            get 
            {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static readonly string padronProvider = @"padronProvider";
    
}
#endregion