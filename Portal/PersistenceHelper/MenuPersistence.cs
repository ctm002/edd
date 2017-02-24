using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;
using InDataAccess;
using Portal.Domain.Enum;

namespace Portal.PersistenceHelper
{
    public class MenuPersistence
    {
        #region[Menu]
        internal static System.Data.DataRow CargarDatos(int pIdMenu)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdMenu", pIdMenu);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Menu_ObtenerXid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataTable CargarMenu()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Menu_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static int ModificarMenu(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Menu_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static int EliminarMenu(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Menu_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static System.Data.DataTable CargarMenuXIdUsuarioSistema(int piIdUsuario, int piIdSistema, int piIdPerfil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", piIdUsuario);
            mParametros.Agregar("@IdPerfil", piIdPerfil);
            mParametros.Agregar("@IdSistema", piIdSistema);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Menu_ListarXIdUsuarioIdSistema", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataTable CargarMenuXIdUsuarioSistema(int piIdUsuario, int piIdSistema, int piIdPerfil, ePermisos mePermisoGod)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", piIdUsuario);
            mParametros.Agregar("@IdPerfil", piIdPerfil);
            mParametros.Agregar("@IdSistema", piIdSistema);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Menu_ListarXIdUsuarioIdSistemaGod", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        #endregion


        internal static System.Data.DataTable ObtenerMenuXSistema(int iIdSistema)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdSistema", iIdSistema);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_MenusXIdSistema",mParam);
        }



        internal static System.Data.DataTable CargarMenuXSistemaPerfil(int piSistema, int piPerfil)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdSistema", piSistema);
            mParam.Agregar("@IdPerfil", piPerfil);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_MenuXSistemaPerfil", mParam, true, DataAccess.eTipoMotor.SqlServer);
        }
    }
}
