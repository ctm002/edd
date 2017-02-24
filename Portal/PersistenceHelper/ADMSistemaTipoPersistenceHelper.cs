/********************************************
/       Dominio.Portal Develop 2011
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 21-06-2011
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


    public class ADMSistemaTipoPersistenceHelper
    {
        #region [Constructor]
        public ADMSistemaTipoPersistenceHelper()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADMSistemaTipo(Int64 Id)
        {
            ParametrosDA mParametros = new ParametrosDA();
            
            
             mParametros.Agregar("@Id", Id);
             return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Sistema_Tip_ListarXPKS", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static long ModificarADMSistemaTipo(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Sistema_Tipo_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static void EliminarADMSistemaTipo(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_Sistema_Tipo_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        public static System.Data.DataTable CargarADMSistemaTipos()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Sistema_Tipo_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        #endregion
    }
}