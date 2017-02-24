using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;
using System.Data;

namespace Portal.PersistenceHelper
{
    internal class PortalPersistenceHelper
    {
        internal static System.Data.DataTable ObtenerDataSource(string psProcedimiento, bool bAdministracion = false)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable(psProcedimiento, bAdministracion, (bAdministracion) ? DataAccess.eTipoMotor.SqlServer : DataAccess.eTipoMotor.No_Motor);
        }
        internal static System.Data.DataTable MenuSistema(int pIdSistema)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdSistema", pIdSistema);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Menu_Sistema", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static System.Data.DataTable MenuSistemaPaginas(int psIdMenu)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdMenu", psIdMenu);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Menu_Sistema_Pagina", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        #region[Session]
        internal static DataRow ObtenerSessionPorID(long lIDSession)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IDSession", lIDSession);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_session_obtenerxid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static DataRow ObtenerSessionPorGuid(string sGuid)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@Guid", sGuid);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_session_obtenerxguid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static DataRow ObtenerSessionPorGuid(string sGuid, int piIdSistema)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@Guid", sGuid);
            mParametros.Agregar("@IdSistema", piIdSistema);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_session_obtenerxguidsistema", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static long ModificarSession(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_session_modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        #endregion
    }
}
