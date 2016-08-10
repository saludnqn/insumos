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
namespace DalPadron{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the FiltrarPacientes Procedure
        /// </summary>
        public static StoredProcedure FiltrarPacientes()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("FiltrarPacientes", DataService.GetInstance("padronProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GeneraPacientesXml Procedure
        /// </summary>
        public static StoredProcedure GeneraPacientesXml()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GeneraPacientesXml", DataService.GetInstance("padronProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientes Procedure
        /// </summary>
        public static StoredProcedure GetPacientes(int? documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientes", DataService.GetInstance("padronProvider"), "dbo");
        	
            sp.Command.AddParameter("@documento", documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPacientesPD Procedure
        /// </summary>
        public static StoredProcedure GetPacientesPD()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPacientesPD", DataService.GetInstance("padronProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ImportaXML Procedure
        /// </summary>
        public static StoredProcedure ImportaXML()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ImportaXML", DataService.GetInstance("padronProvider"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ListarObraSocial Procedure
        /// </summary>
        public static StoredProcedure ListarObraSocial(int? Documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ListarObraSocial", DataService.GetInstance("padronProvider"), "dbo");
        	
            sp.Command.AddParameter("@Documento", Documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ListarObraSocialXML Procedure
        /// </summary>
        public static StoredProcedure ListarObraSocialXML(int? Documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ListarObraSocialXML", DataService.GetInstance("padronProvider"), "dbo");
        	
            sp.Command.AddParameter("@Documento", Documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ListarPersonas Procedure
        /// </summary>
        public static StoredProcedure ListarPersonas(int? Documento)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ListarPersonas", DataService.GetInstance("padronProvider"), "dbo");
        	
            sp.Command.AddParameter("@Documento", Documento, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the ListarPersonasNombre Procedure
        /// </summary>
        public static StoredProcedure ListarPersonasNombre(string Nombre)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ListarPersonasNombre", DataService.GetInstance("padronProvider"), "dbo");
        	
            sp.Command.AddParameter("@Nombre", Nombre, DbType.String, null, null);
        	
            return sp;
        }
        
    }
    
}
