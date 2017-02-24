/********************************************
/       Portal Develop 2011
/********************************************
/ Creado Por: Luis Moreno
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 03-05-2011
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


    public class PerfilPermisoPersistenceHelper
    {
        #region [Constructor]
        public PerfilPermisoPersistenceHelper()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosPerfilPermiso(Int64 IdPerfilPermiso)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfilPermiso", IdPerfilPermiso);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Perfil_Permiso_ObtenerXid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static long ModificarPerfilPermiso(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_perfil_permiso_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static void EliminarPerfilPermiso(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_perfil_permiso_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        public static System.Data.DataTable CargarPerfilPermisos()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_perfil_permiso_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        #endregion

        internal static object VerificarExistenciaPerfilPermiso(int iPermiso, int iIdPerfil)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdPermiso",iPermiso);
            mParam.Agregar("@IdPerfil", iIdPerfil);

            return InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_VerificaPerfilPermiso",mParam);
        }

        internal static void BorrarXPerfil(int iIdPerfil)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdPerfil", iIdPerfil);

            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_EliminarPerfilPermisoXIdPerfil", mParam);
        }
    }
}