using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;

namespace Portal.PersistenceHelper
{
    public class PaginaPersistence
    {
        internal static System.Data.DataRow CargarDatos(int pIdMenu)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPagina", pIdMenu);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Pagina_ObtenerXid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataTable CargarPagina()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Pagina_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static int ModificarPagina(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Pagina_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static int EliminarPagina(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Pagina_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }

        internal static System.Data.DataTable CargarPaginaXIdUsuarioPerfil(int piIdUsuario, int piIdPerfil, int piIdMenu)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", piIdUsuario);
            mParametros.Agregar("@IdPerfil", piIdPerfil);
            mParametros.Agregar("@IdMenu", piIdMenu);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Pagina_ListarXIdUsuarioIdSistema", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static System.Data.DataTable CargarPaginaXIdUsuarioPerfilTodo(int piIdUsuario, int piIdPerfil, int piIdMenu)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", piIdUsuario);
            mParametros.Agregar("@IdPerfil", piIdPerfil);
            mParametros.Agregar("@IdMenu", piIdMenu);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Pagina_ListarXIdUsuarioIdSistemaAll", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static System.Data.DataTable CargarPaginasXSistema(int iIdSistema)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdSistema",iIdSistema);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_ListarPaginasXSistema",mParametros);
        }

        internal static System.Data.DataTable CargarPaginaXPerfilSistema(int piIdPerfil, int piIdMenu)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfil", piIdPerfil);
            mParametros.Agregar("@IdMenu", piIdMenu);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("Adm_PaginaXPerfilSistema", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
    }
}
