using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;
using System.Data;

namespace Portal.PersistenceHelper
{
    public class UsuarioPersistance
    {
        internal static System.Data.DataRow CargarDatos(int pIdUsuario)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", pIdUsuario);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Usuario_ObtenerXid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataRow CargarDatos(string psGuid)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@Guid", psGuid);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Usuario_ObtenerXGuid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static System.Data.DataTable CargarUsuario()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Usuario_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static int ModificarUsuario(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Usuario_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static int EliminarUsuario(ParametrosDA mParametros)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Usuario_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }

        internal static System.Data.DataTable CargarUsuariosXNombre(string sNombre, string sApellido)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@Nombre",sNombre);
            mParam.Agregar("@Apellido", sApellido);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("Adm_ListarUsuariosXNombreApellido",mParam,true);

        }

        internal static System.Data.DataTable ObtenerAbogadosAsociadosXIdUsuario(ParametrosDA mParam)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("TS_AbogadosAsignadosXIdUsuario",mParam);
        }

        internal static int ObtenerPerfilXUsuarioSistema(ParametrosDA mParam)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("TS_UsuarioObtenerPerfil", mParam));
        }

        internal static object AsignarPerfilXUsuarioSistema(ParametrosDA mParam)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerEscalar("TS_ModificarPerfilUsuario",mParam,true);
        }

        internal static int ObtenerIdUsuarioXEmail(ParametrosDA mParam)
        {
            return Convert.ToInt32(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("TS_ObtenerIdUsuarioXEmail", mParam, true, DataAccess.eTipoMotor.SqlServer));
        }

        internal static System.Data.DataTable CargaUsuariosNoFacade()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Usuario_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static System.Data.DataTable ObtenerUsuariosPerfilConsulta(ParametrosDA mParam)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ObtenerUsuariosPerfilConsulta", mParam);
        }

        internal static System.Data.DataTable CargaUsuariosNoFacadeParaBusqueda(ParametrosDA mParam)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Usuario_ListarXNombre" , mParam, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static System.Data.DataTable ObtenerMensajeriaXIdUsuario(ParametrosDA mParam)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_MensajeriaXUsuario", mParam, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static void GrabaTablaNotificacionUsuario(ParametrosDA mParam)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_GrabaMensajeUsuarioXId_Sistema", mParam, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static System.Data.DataTable ObtenerUsuariosXSistema(ParametrosDA mParam)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_ListarUsuariosXSistemas", mParam, true);
        }

        internal static DataTable CargaUsuariosNoFacadeXIdSistema(ParametrosDA mParam)
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_ListarUsuariosXSistemas", mParam, true, DataAccess.eTipoMotor.SqlServer);
        }
    }
}
