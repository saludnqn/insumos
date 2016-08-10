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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string ConTiempoInsumido = @"CON_TiempoInsumido";
        
		public static readonly string InsAlarma = @"INS_Alarma";
        
		public static readonly string InsDatoFarmaceutico = @"INS_DatoFarmaceutico";
        
		public static readonly string InsDeposito = @"INS_Deposito";
        
		public static readonly string InsDepositoZona = @"INS_DepositoZona";
        
		public static readonly string InsDispensacion = @"INS_Dispensacion";
        
		public static readonly string InsDispensacionDetalle = @"INS_DispensacionDetalle";
        
		public static readonly string InsDispensacionEntrega = @"INS_DispensacionEntrega";
        
		public static readonly string InsDosi = @"INS_Dosis";
        
		public static readonly string InsEstadoPedido = @"INS_EstadoPedido";
        
		public static readonly string InsInsumo = @"INS_Insumo";
        
		public static readonly string InsInsumosEquivalente = @"INS_InsumosEquivalentes";
        
		public static readonly string InsInternacionPedido = @"INS_InternacionPedido";
        
		public static readonly string InsMensaje = @"INS_Mensajes";
        
		public static readonly string InsMensajesRole = @"INS_Mensajes_Roles";
        
		public static readonly string InsMensajesTipo = @"INS_Mensajes_tipos";
        
		public static readonly string InsMotivosRechazo = @"INS_MotivosRechazo";
        
		public static readonly string InsMovimiento = @"INS_Movimiento";
        
		public static readonly string InsMovimientoDetalle = @"INS_MovimientoDetalle";
        
		public static readonly string InsOrdenCompra = @"INS_OrdenCompra";
        
		public static readonly string InsPedido = @"INS_Pedido";
        
		public static readonly string InsPedidoDetalle = @"INS_PedidoDetalle";
        
		public static readonly string InsPrescripcion = @"INS_Prescripcion";
        
		public static readonly string InsPrescripcionDetalle = @"INS_PrescripcionDetalle";
        
		public static readonly string InsPrescripcionEntrega = @"INS_PrescripcionEntrega";
        
		public static readonly string InsPrograma = @"INS_Programa";
        
		public static readonly string InsProveedor = @"INS_Proveedor";
        
		public static readonly string InsRecetum = @"INS_Receta";
        
		public static readonly string InsRelInsumoEfector = @"INS_RelInsumoEfector";
        
		public static readonly string InsRelInsumoPrograma = @"INS_RelInsumoPrograma";
        
		public static readonly string InsRubro = @"INS_Rubro";
        
		public static readonly string InsTipoComprobante = @"INS_TipoComprobante";
        
		public static readonly string InsTipoDeposito = @"INS_TipoDeposito";
        
		public static readonly string InsTipoMovimiento = @"INS_TipoMovimiento";
        
		public static readonly string InsTipoPedido = @"INS_TipoPedido";
        
		public static readonly string InsTipoPrescripcion = @"INS_TipoPrescripcion";
        
		public static readonly string InsTipoProveedor = @"INS_TipoProveedor";
        
		public static readonly string InsTipoTratamiento = @"INS_TipoTratamiento";
        
		public static readonly string InsUnidad = @"INS_Unidad";
        
		public static readonly string IntNivelDeInstruccion = @"INT_NivelDeInstruccion";
        
		public static readonly string LabPhoresysItem = @"LAB_PhoresysItem";
        
		public static readonly string LabSysmexItem = @"LAB_SysmexItem";
        
		public static readonly string LabSysmexItemKX21N = @"LAB_SysmexItemKX21N";
        
		public static readonly string LabSysmexItemXT1800 = @"LAB_SysmexItemXT1800";
        
		public static readonly string LabSysmexResultado = @"LAB_SysmexResultado";
        
		public static readonly string SysAntecedente = @"Sys_Antecedente";
        
		public static readonly string SysAntecedenteEnfermedad = @"Sys_AntecedenteEnfermedad";
        
		public static readonly string SysBarrio = @"Sys_Barrio";
        
		public static readonly string SysCalendarioEpidemiologico = @"Sys_CalendarioEpidemiologico";
        
		public static readonly string SysCepSap = @"Sys_CepSap";
        
		public static readonly string SysCIE10 = @"Sys_CIE10";
        
		public static readonly string SysCIE10DelSip = @"Sys_CIE10_del_sips";
        
		public static readonly string SysCIE10Capitulo = @"Sys_CIE10Capitulo";
        
		public static readonly string SysDepartamento = @"Sys_Departamento";
        
		public static readonly string SysDireccione = @"Sys_Direcciones";
        
		public static readonly string SysEfector = @"Sys_Efector";
        
		public static readonly string SysEspecialidad = @"Sys_Especialidad";
        
		public static readonly string SysEstablecimiento = @"sys_Establecimiento";
        
		public static readonly string SysEstado = @"Sys_Estado";
        
		public static readonly string SysEstadoCivil = @"Sys_EstadoCivil";
        
		public static readonly string SysHistoriaClinica = @"Sys_HistoriaClinica";
        
		public static readonly string SysIdioma = @"Sys_Idioma";
        
		public static readonly string SysLocalidad = @"Sys_Localidad";
        
		public static readonly string SysMedicamento = @"Sys_Medicamento";
        
		public static readonly string SysMedicamentoRubro = @"Sys_MedicamentoRubro";
        
		public static readonly string SysMenu = @"Sys_Menu";
        
		public static readonly string SysModulo = @"Sys_Modulo";
        
		public static readonly string SysMotivoNI = @"Sys_MotivoNI";
        
		public static readonly string SysMovimientoHistoriaClinica = @"Sys_MovimientoHistoriaClinica";
        
		public static readonly string SysMunicipio = @"Sys_Municipio";
        
		public static readonly string SysNivelInstruccion = @"Sys_NivelInstruccion";
        
		public static readonly string SysObraSocial = @"Sys_ObraSocial";
        
		public static readonly string SysOcupacion = @"Sys_Ocupacion";
        
		public static readonly string SysOrganismo = @"Sys_Organismo";
        
		public static readonly string SysPaciente = @"Sys_Paciente";
        
		public static readonly string SysPacienteCeliaco = @"Sys_PacienteCeliaco";
        
		public static readonly string SysPai = @"Sys_Pais";
        
		public static readonly string SysParentesco = @"Sys_Parentesco";
        
		public static readonly string SysPerfil = @"Sys_Perfil";
        
		public static readonly string SysPermiso = @"Sys_Permiso";
        
		public static readonly string SysPoblacion = @"Sys_Poblacion";
        
		public static readonly string SysProfesion = @"Sys_Profesion";
        
		public static readonly string SysProfesional = @"Sys_Profesional";
        
		public static readonly string SysProvincium = @"Sys_Provincia";
        
		public static readonly string SysRelAntecedentePaciente = @"Sys_RelAntecedentePaciente";
        
		public static readonly string SysRelEspecialidadEfector = @"Sys_RelEspecialidadEfector";
        
		public static readonly string SysRelEstadoMotivoNI = @"Sys_RelEstadoMotivoNI";
        
		public static readonly string SysRelFormularioCobertura = @"Sys_RelFormularioCobertura";
        
		public static readonly string SysRelHistoriaClinicaEfector = @"Sys_RelHistoriaClinicaEfector";
        
		public static readonly string SysRelPacienteObraSocial = @"Sys_RelPacienteObraSocial";
        
		public static readonly string SysRelProfesionalEfector = @"Sys_RelProfesionalEfector";
        
		public static readonly string SysRelServicioEfector = @"Sys_RelServicioEfector";
        
		public static readonly string SysServicio = @"Sys_Servicio";
        
		public static readonly string SysSexo = @"Sys_Sexo";
        
		public static readonly string SysSituacionLaboral = @"Sys_SituacionLaboral";
        
		public static readonly string SysTipoAntecedente = @"Sys_TipoAntecedente";
        
		public static readonly string SysTipoCoberturaBorrar = @"Sys_TipoCobertura_BORRAR";
        
		public static readonly string SysTipoDocumento = @"Sys_TipoDocumento";
        
		public static readonly string SysTipoEfector = @"Sys_TipoEfector";
        
		public static readonly string SysTipoObraSocial = @"Sys_TipoObraSocial";
        
		public static readonly string SysTipoProfesional = @"Sys_TipoProfesional";
        
		public static readonly string SysUsuario = @"Sys_Usuario";
        
		public static readonly string SysZona = @"Sys_Zona";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table ConTiempoInsumido
		{
            get { return DataService.GetSchema("CON_TiempoInsumido", "insProvider"); }
		}
        
		public static TableSchema.Table InsAlarma
		{
            get { return DataService.GetSchema("INS_Alarma", "insProvider"); }
		}
        
		public static TableSchema.Table InsDatoFarmaceutico
		{
            get { return DataService.GetSchema("INS_DatoFarmaceutico", "insProvider"); }
		}
        
		public static TableSchema.Table InsDeposito
		{
            get { return DataService.GetSchema("INS_Deposito", "insProvider"); }
		}
        
		public static TableSchema.Table InsDepositoZona
		{
            get { return DataService.GetSchema("INS_DepositoZona", "insProvider"); }
		}
        
		public static TableSchema.Table InsDispensacion
		{
            get { return DataService.GetSchema("INS_Dispensacion", "insProvider"); }
		}
        
		public static TableSchema.Table InsDispensacionDetalle
		{
            get { return DataService.GetSchema("INS_DispensacionDetalle", "insProvider"); }
		}
        
		public static TableSchema.Table InsDispensacionEntrega
		{
            get { return DataService.GetSchema("INS_DispensacionEntrega", "insProvider"); }
		}
        
		public static TableSchema.Table InsDosi
		{
            get { return DataService.GetSchema("INS_Dosis", "insProvider"); }
		}
        
		public static TableSchema.Table InsEstadoPedido
		{
            get { return DataService.GetSchema("INS_EstadoPedido", "insProvider"); }
		}
        
		public static TableSchema.Table InsInsumo
		{
            get { return DataService.GetSchema("INS_Insumo", "insProvider"); }
		}
        
		public static TableSchema.Table InsInsumosEquivalente
		{
            get { return DataService.GetSchema("INS_InsumosEquivalentes", "insProvider"); }
		}
        
		public static TableSchema.Table InsInternacionPedido
		{
            get { return DataService.GetSchema("INS_InternacionPedido", "insProvider"); }
		}
        
		public static TableSchema.Table InsMensaje
		{
            get { return DataService.GetSchema("INS_Mensajes", "insProvider"); }
		}
        
		public static TableSchema.Table InsMensajesRole
		{
            get { return DataService.GetSchema("INS_Mensajes_Roles", "insProvider"); }
		}
        
		public static TableSchema.Table InsMensajesTipo
		{
            get { return DataService.GetSchema("INS_Mensajes_tipos", "insProvider"); }
		}
        
		public static TableSchema.Table InsMotivosRechazo
		{
            get { return DataService.GetSchema("INS_MotivosRechazo", "insProvider"); }
		}
        
		public static TableSchema.Table InsMovimiento
		{
            get { return DataService.GetSchema("INS_Movimiento", "insProvider"); }
		}
        
		public static TableSchema.Table InsMovimientoDetalle
		{
            get { return DataService.GetSchema("INS_MovimientoDetalle", "insProvider"); }
		}
        
		public static TableSchema.Table InsOrdenCompra
		{
            get { return DataService.GetSchema("INS_OrdenCompra", "insProvider"); }
		}
        
		public static TableSchema.Table InsPedido
		{
            get { return DataService.GetSchema("INS_Pedido", "insProvider"); }
		}
        
		public static TableSchema.Table InsPedidoDetalle
		{
            get { return DataService.GetSchema("INS_PedidoDetalle", "insProvider"); }
		}
        
		public static TableSchema.Table InsPrescripcion
		{
            get { return DataService.GetSchema("INS_Prescripcion", "insProvider"); }
		}
        
		public static TableSchema.Table InsPrescripcionDetalle
		{
            get { return DataService.GetSchema("INS_PrescripcionDetalle", "insProvider"); }
		}
        
		public static TableSchema.Table InsPrescripcionEntrega
		{
            get { return DataService.GetSchema("INS_PrescripcionEntrega", "insProvider"); }
		}
        
		public static TableSchema.Table InsPrograma
		{
            get { return DataService.GetSchema("INS_Programa", "insProvider"); }
		}
        
		public static TableSchema.Table InsProveedor
		{
            get { return DataService.GetSchema("INS_Proveedor", "insProvider"); }
		}
        
		public static TableSchema.Table InsRecetum
		{
            get { return DataService.GetSchema("INS_Receta", "insProvider"); }
		}
        
		public static TableSchema.Table InsRelInsumoEfector
		{
            get { return DataService.GetSchema("INS_RelInsumoEfector", "insProvider"); }
		}
        
		public static TableSchema.Table InsRelInsumoPrograma
		{
            get { return DataService.GetSchema("INS_RelInsumoPrograma", "insProvider"); }
		}
        
		public static TableSchema.Table InsRubro
		{
            get { return DataService.GetSchema("INS_Rubro", "insProvider"); }
		}
        
		public static TableSchema.Table InsTipoComprobante
		{
            get { return DataService.GetSchema("INS_TipoComprobante", "insProvider"); }
		}
        
		public static TableSchema.Table InsTipoDeposito
		{
            get { return DataService.GetSchema("INS_TipoDeposito", "insProvider"); }
		}
        
		public static TableSchema.Table InsTipoMovimiento
		{
            get { return DataService.GetSchema("INS_TipoMovimiento", "insProvider"); }
		}
        
		public static TableSchema.Table InsTipoPedido
		{
            get { return DataService.GetSchema("INS_TipoPedido", "insProvider"); }
		}
        
		public static TableSchema.Table InsTipoPrescripcion
		{
            get { return DataService.GetSchema("INS_TipoPrescripcion", "insProvider"); }
		}
        
		public static TableSchema.Table InsTipoProveedor
		{
            get { return DataService.GetSchema("INS_TipoProveedor", "insProvider"); }
		}
        
		public static TableSchema.Table InsTipoTratamiento
		{
            get { return DataService.GetSchema("INS_TipoTratamiento", "insProvider"); }
		}
        
		public static TableSchema.Table InsUnidad
		{
            get { return DataService.GetSchema("INS_Unidad", "insProvider"); }
		}
        
		public static TableSchema.Table IntNivelDeInstruccion
		{
            get { return DataService.GetSchema("INT_NivelDeInstruccion", "insProvider"); }
		}
        
		public static TableSchema.Table LabPhoresysItem
		{
            get { return DataService.GetSchema("LAB_PhoresysItem", "insProvider"); }
		}
        
		public static TableSchema.Table LabSysmexItem
		{
            get { return DataService.GetSchema("LAB_SysmexItem", "insProvider"); }
		}
        
		public static TableSchema.Table LabSysmexItemKX21N
		{
            get { return DataService.GetSchema("LAB_SysmexItemKX21N", "insProvider"); }
		}
        
		public static TableSchema.Table LabSysmexItemXT1800
		{
            get { return DataService.GetSchema("LAB_SysmexItemXT1800", "insProvider"); }
		}
        
		public static TableSchema.Table LabSysmexResultado
		{
            get { return DataService.GetSchema("LAB_SysmexResultado", "insProvider"); }
		}
        
		public static TableSchema.Table SysAntecedente
		{
            get { return DataService.GetSchema("Sys_Antecedente", "insProvider"); }
		}
        
		public static TableSchema.Table SysAntecedenteEnfermedad
		{
            get { return DataService.GetSchema("Sys_AntecedenteEnfermedad", "insProvider"); }
		}
        
		public static TableSchema.Table SysBarrio
		{
            get { return DataService.GetSchema("Sys_Barrio", "insProvider"); }
		}
        
		public static TableSchema.Table SysCalendarioEpidemiologico
		{
            get { return DataService.GetSchema("Sys_CalendarioEpidemiologico", "insProvider"); }
		}
        
		public static TableSchema.Table SysCepSap
		{
            get { return DataService.GetSchema("Sys_CepSap", "insProvider"); }
		}
        
		public static TableSchema.Table SysCIE10
		{
            get { return DataService.GetSchema("Sys_CIE10", "insProvider"); }
		}
        
		public static TableSchema.Table SysCIE10DelSip
		{
            get { return DataService.GetSchema("Sys_CIE10_del_sips", "insProvider"); }
		}
        
		public static TableSchema.Table SysCIE10Capitulo
		{
            get { return DataService.GetSchema("Sys_CIE10Capitulo", "insProvider"); }
		}
        
		public static TableSchema.Table SysDepartamento
		{
            get { return DataService.GetSchema("Sys_Departamento", "insProvider"); }
		}
        
		public static TableSchema.Table SysDireccione
		{
            get { return DataService.GetSchema("Sys_Direcciones", "insProvider"); }
		}
        
		public static TableSchema.Table SysEfector
		{
            get { return DataService.GetSchema("Sys_Efector", "insProvider"); }
		}
        
		public static TableSchema.Table SysEspecialidad
		{
            get { return DataService.GetSchema("Sys_Especialidad", "insProvider"); }
		}
        
		public static TableSchema.Table SysEstablecimiento
		{
            get { return DataService.GetSchema("sys_Establecimiento", "insProvider"); }
		}
        
		public static TableSchema.Table SysEstado
		{
            get { return DataService.GetSchema("Sys_Estado", "insProvider"); }
		}
        
		public static TableSchema.Table SysEstadoCivil
		{
            get { return DataService.GetSchema("Sys_EstadoCivil", "insProvider"); }
		}
        
		public static TableSchema.Table SysHistoriaClinica
		{
            get { return DataService.GetSchema("Sys_HistoriaClinica", "insProvider"); }
		}
        
		public static TableSchema.Table SysIdioma
		{
            get { return DataService.GetSchema("Sys_Idioma", "insProvider"); }
		}
        
		public static TableSchema.Table SysLocalidad
		{
            get { return DataService.GetSchema("Sys_Localidad", "insProvider"); }
		}
        
		public static TableSchema.Table SysMedicamento
		{
            get { return DataService.GetSchema("Sys_Medicamento", "insProvider"); }
		}
        
		public static TableSchema.Table SysMedicamentoRubro
		{
            get { return DataService.GetSchema("Sys_MedicamentoRubro", "insProvider"); }
		}
        
		public static TableSchema.Table SysMenu
		{
            get { return DataService.GetSchema("Sys_Menu", "insProvider"); }
		}
        
		public static TableSchema.Table SysModulo
		{
            get { return DataService.GetSchema("Sys_Modulo", "insProvider"); }
		}
        
		public static TableSchema.Table SysMotivoNI
		{
            get { return DataService.GetSchema("Sys_MotivoNI", "insProvider"); }
		}
        
		public static TableSchema.Table SysMovimientoHistoriaClinica
		{
            get { return DataService.GetSchema("Sys_MovimientoHistoriaClinica", "insProvider"); }
		}
        
		public static TableSchema.Table SysMunicipio
		{
            get { return DataService.GetSchema("Sys_Municipio", "insProvider"); }
		}
        
		public static TableSchema.Table SysNivelInstruccion
		{
            get { return DataService.GetSchema("Sys_NivelInstruccion", "insProvider"); }
		}
        
		public static TableSchema.Table SysObraSocial
		{
            get { return DataService.GetSchema("Sys_ObraSocial", "insProvider"); }
		}
        
		public static TableSchema.Table SysOcupacion
		{
            get { return DataService.GetSchema("Sys_Ocupacion", "insProvider"); }
		}
        
		public static TableSchema.Table SysOrganismo
		{
            get { return DataService.GetSchema("Sys_Organismo", "insProvider"); }
		}
        
		public static TableSchema.Table SysPaciente
		{
            get { return DataService.GetSchema("Sys_Paciente", "insProvider"); }
		}
        
		public static TableSchema.Table SysPacienteCeliaco
		{
            get { return DataService.GetSchema("Sys_PacienteCeliaco", "insProvider"); }
		}
        
		public static TableSchema.Table SysPai
		{
            get { return DataService.GetSchema("Sys_Pais", "insProvider"); }
		}
        
		public static TableSchema.Table SysParentesco
		{
            get { return DataService.GetSchema("Sys_Parentesco", "insProvider"); }
		}
        
		public static TableSchema.Table SysPerfil
		{
            get { return DataService.GetSchema("Sys_Perfil", "insProvider"); }
		}
        
		public static TableSchema.Table SysPermiso
		{
            get { return DataService.GetSchema("Sys_Permiso", "insProvider"); }
		}
        
		public static TableSchema.Table SysPoblacion
		{
            get { return DataService.GetSchema("Sys_Poblacion", "insProvider"); }
		}
        
		public static TableSchema.Table SysProfesion
		{
            get { return DataService.GetSchema("Sys_Profesion", "insProvider"); }
		}
        
		public static TableSchema.Table SysProfesional
		{
            get { return DataService.GetSchema("Sys_Profesional", "insProvider"); }
		}
        
		public static TableSchema.Table SysProvincium
		{
            get { return DataService.GetSchema("Sys_Provincia", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelAntecedentePaciente
		{
            get { return DataService.GetSchema("Sys_RelAntecedentePaciente", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelEspecialidadEfector
		{
            get { return DataService.GetSchema("Sys_RelEspecialidadEfector", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelEstadoMotivoNI
		{
            get { return DataService.GetSchema("Sys_RelEstadoMotivoNI", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelFormularioCobertura
		{
            get { return DataService.GetSchema("Sys_RelFormularioCobertura", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelHistoriaClinicaEfector
		{
            get { return DataService.GetSchema("Sys_RelHistoriaClinicaEfector", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelPacienteObraSocial
		{
            get { return DataService.GetSchema("Sys_RelPacienteObraSocial", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelProfesionalEfector
		{
            get { return DataService.GetSchema("Sys_RelProfesionalEfector", "insProvider"); }
		}
        
		public static TableSchema.Table SysRelServicioEfector
		{
            get { return DataService.GetSchema("Sys_RelServicioEfector", "insProvider"); }
		}
        
		public static TableSchema.Table SysServicio
		{
            get { return DataService.GetSchema("Sys_Servicio", "insProvider"); }
		}
        
		public static TableSchema.Table SysSexo
		{
            get { return DataService.GetSchema("Sys_Sexo", "insProvider"); }
		}
        
		public static TableSchema.Table SysSituacionLaboral
		{
            get { return DataService.GetSchema("Sys_SituacionLaboral", "insProvider"); }
		}
        
		public static TableSchema.Table SysTipoAntecedente
		{
            get { return DataService.GetSchema("Sys_TipoAntecedente", "insProvider"); }
		}
        
		public static TableSchema.Table SysTipoCoberturaBorrar
		{
            get { return DataService.GetSchema("Sys_TipoCobertura_BORRAR", "insProvider"); }
		}
        
		public static TableSchema.Table SysTipoDocumento
		{
            get { return DataService.GetSchema("Sys_TipoDocumento", "insProvider"); }
		}
        
		public static TableSchema.Table SysTipoEfector
		{
            get { return DataService.GetSchema("Sys_TipoEfector", "insProvider"); }
		}
        
		public static TableSchema.Table SysTipoObraSocial
		{
            get { return DataService.GetSchema("Sys_TipoObraSocial", "insProvider"); }
		}
        
		public static TableSchema.Table SysTipoProfesional
		{
            get { return DataService.GetSchema("Sys_TipoProfesional", "insProvider"); }
		}
        
		public static TableSchema.Table SysUsuario
		{
            get { return DataService.GetSchema("Sys_Usuario", "insProvider"); }
		}
        
		public static TableSchema.Table SysZona
		{
            get { return DataService.GetSchema("Sys_Zona", "insProvider"); }
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
        public static DataProvider _provider = DataService.Providers["insProvider"];
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
	
	public static readonly string insProvider = @"insProvider";
    
}
#endregion