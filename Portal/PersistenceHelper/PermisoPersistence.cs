using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;
using System.Data;

namespace Portal.PersistenceHelper
{
    public class PermisoPersistence
    {
        internal static System.Data.DataRow CargarDatos(int pIdPermiso)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPermiso", pIdPermiso);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Permiso_ObtenerXid", mParametros, true,DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataTable CargarPermiso()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Permiso_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static int ModificarPermiso(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Permiso_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static int EliminarPermiso(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Permiso_Eliminar", mParametros, true,DataAccess.eTipoMotor.SqlServer));
        }
        internal static DataTable ObtenerPermisosXIDPerfil(int plIdPerfil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfil", plIdPerfil);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Permiso_ObtenerXidPerfil", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static DataTable TodosPermisosXIdPerfil(int iIdPerfil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfil", iIdPerfil);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_PermisosTotalXIdPerfil", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static DataTable CargarPermisosXSistema(int iIdSistema)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdSistema",iIdSistema);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_PermisosXSistema",mParam);
        }

        internal static void EliminarPermisoTotal(int iidPermiso)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPermiso", iidPermiso);

            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_EliminarPermisoTotal",mParametros);
        }
    }
}
