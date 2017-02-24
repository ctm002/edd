/********************************************
/       Portal Develop 2012
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 19-07-2012
/
*********************************************/
namespace Portal.Persistence /**/
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using InDataAccess.Parametros;


    public class ADM_Grupo_PerfilPersistence
    {
        #region [Constructor]
        public ADM_Grupo_PerfilPersistence()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADM_Grupo_Perfil(Int64 IdGrupoPefil)
        {
            ParametrosDA mParametros = new ParametrosDA();
            
            
 mParametros.Agregar("@IdGrupoPefil", IdGrupoPefil);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_grupo_perfil_ListarXPKS", mParametros);
        }
        internal static long ModificarADM_Grupo_Perfil(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_grupo_perfil_Modificar", mParametros));
        }
        internal static void EliminarADM_Grupo_Perfil(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_grupo_perfil_Eliminar", mParametros);
        }
        public static System.Data.DataTable CargarADM_Grupo_Perfils()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_grupo_perfil_Listar");
        }
        #endregion

        internal static void EliminarGrupoPerfil(int iIdGrupo)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdGrupo",iIdGrupo);

            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_EliminarGrupoPerfilXId",mParam);
        }

        internal static DataTable ListarGrupoPerfilXIdGrupo(int iIdGrupo)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdGrupo",iIdGrupo);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_ListarGrupoPerfilXIdGrupo",mParam);
        }

        internal static void AsignarPerfilesGrupoUsuario(int piIdUsuario, int piIdGrupo)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario",piIdUsuario);
            mParam.Agregar("@IdGrupo", piIdGrupo);

            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_GrupoPerfiles_AsociarPerfil_Usuario", mParam);
        }

        internal static void EliminarUsuariosPerfilXGrupo(int iIdUsuarioGrupo)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuarioGrupo",iIdUsuarioGrupo);

            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_EliminarPerfilesUsuarioXGrupo",mParam);
        }

        internal static DataRow VerificarExistenciaPerfilGrupo(int iIdGrupo, string sIdPerfil)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdGrupo",iIdGrupo);
            mParam.Agregar("@IdPerfil",sIdPerfil);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_VerificarPerfilEnGrupo", mParam);
        }
    }
}