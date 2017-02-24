using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;

namespace Portal.PersistenceHelper
{
    public class SistemaPersistance
    {
        internal static System.Data.DataRow CargarDatos(int pIdSistema)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdSistema", pIdSistema);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Sistema_ObtenerXid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataRow CargarDatos(string psUrl)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@Url", psUrl);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Sistema_ObtenerXUrl", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataTable CargarSistema()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Sistema_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static int ModificarSistema(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Sistema_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static int EliminarSistema(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Sistema_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }

        internal static System.Data.DataTable CargarPorIdPerfil(int piIdPerfil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@piIdPerfil", piIdPerfil);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Sistema_ObtenerXIdPerfil", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static System.Data.DataTable ObtenerSistemaXIdUsuario(int iIdUsuario)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario",iIdUsuario);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_SistemaXUsuarioPerfil",mParam);
        }
    }
}
