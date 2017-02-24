using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;
using InDataAccess;
using System.Data;
namespace Portal.PersistenceHelper
{
    public class PerfilPersistance
    {
        internal static System.Data.DataRow CargarDatos(int pIdPerfil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfil", pIdPerfil);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Perfil_ObtenerXid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataTable CargarPerfil()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Perfil_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static int ModificarPerfil(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Perfil_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static int EliminarPerfil(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Perfil_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }

        internal static DataTable CargarPorIdPerfil(int piIdPerfil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfil", piIdPerfil);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Usuario_Perfil_ListadoXIdPerfil", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static DataTable CargarPorIdUsuario(int piIdUsuario)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", piIdUsuario);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Perfil_ObtenerXIdUsuario", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static DataTable ObtenerListadoUsuariosAsignados(int piIdUsuario)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", piIdUsuario);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Usuario_Padre_ListarXIdUsuario", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static DataTable ObtenerPerfilesXSistema(int iIdSistema)
        {
            ParametrosDA mPara = new ParametrosDA();
            mPara.Agregar("@IdSistema",@iIdSistema);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_PerfilesXSistema",mPara , true);
        }

        internal static int EliminarPerfil(int iIdPerfil)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdPerfil",iIdPerfil);

            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_EliminarPerfilTodo",mParam));
        }
    }
}
