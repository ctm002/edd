/********************************************
/       Portal Develop 2011
/********************************************
/ Creado Por: 
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 05-05-2011
/
*********************************************/
namespace Portal.PersistenceHelper /**/
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using InDataAccess.Parametros;


    public class HistorialAccionesPersistenceHelper
    {
        #region [Constructor]
        public HistorialAccionesPersistenceHelper()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosHistorialAcciones(Int64 IdHistorial)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdHistorial", IdHistorial);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_historial_acciones_ListarXPKS", mParametros, true,DataAccess.eTipoMotor.SqlServer);
        }
        internal static long ModificarHistorialAcciones(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_historial_acciones_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static void EliminarHistorialAcciones(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_historial_acciones_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        public static System.Data.DataTable CargarHistorialAccioness()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_historial_acciones_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        #endregion
    }
}