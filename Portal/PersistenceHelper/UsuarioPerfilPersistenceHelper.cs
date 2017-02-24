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


    public class UsuarioPerfilPersistenceHelper
    {
        #region [Constructor]
        public UsuarioPerfilPersistenceHelper()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosUsuarioPerfil(Int64 IdUsuarioPerfil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuarioPerfil", IdUsuarioPerfil);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_usuario_perfil_ObtenerXid", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static long ModificarUsuarioPerfil(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_usuario_perfil_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static void EliminarUsuarioPerfil(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_usuario_perfil_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        public static System.Data.DataTable CargarUsuarioPerfils()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_usuario_perfil_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        #endregion


        internal static void ModificarUsuarioHijo(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_Usuario_Padre_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static void EliminarUsuarioHijo(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_Usuario_Padre_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }

        internal static DataTable UsuarioPerfilXUsuario(int iIDUsuario)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario",iIDUsuario);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_UsuarioPerfilXUsuario", mParam);


        }

        internal static DataTable ListarUsuariosXPerfil(int iIdPerfil)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdPerfil", iIdPerfil); ;

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_UsuarioXPerfil",mParam);

        }

        internal static DataRow VerificarPerfilAsociadoUsuario(int iIDUsuario, int iIdPerfil)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario",iIDUsuario);
            mParam.Agregar("@IdPerfil", iIdPerfil);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_VerificaPerfilUsuario",mParam);

        }
    }
}