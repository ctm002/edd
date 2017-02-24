
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InDataAccess;
//using Portal.Domain.Enum;



namespace Portal.Controller
{
    using Portal.Domain.Object;
    using Portal.Persistence;
    //using Portal.Domain.Enum;

    public class ADM_Grupo_PerfilController
    {


        public void ADM_Grupo_PerfilEditar(String psIdGrupoPefil,String psIdGrupo,String psIdPerfil)
        {
            ADM_Grupo_Perfil mADM_Grupo_Perfil = new ADM_Grupo_Perfil(Convert.ToInt64(psIdGrupoPefil));
            
                 mADM_Grupo_Perfil.IdGrupoPefil = Convert.ToInt64(psIdGrupoPefil);
                 mADM_Grupo_Perfil.IdGrupo = Convert.ToInt64(psIdGrupo);
                 mADM_Grupo_Perfil.IdPerfil = Convert.ToInt64(psIdPerfil);
            mADM_Grupo_Perfil.Modificar();
            mADM_Grupo_Perfil = null;
            
        }

        public void ADM_Grupo_PerfilEliminacion(String psIdGrupoPefil)
        {
            ADM_Grupo_Perfil mADM_Grupo_Perfil  = new ADM_Grupo_Perfil(Convert.ToInt64(psIdGrupoPefil));
            
 mADM_Grupo_Perfil.IdGrupoPefil = Convert.ToInt64(psIdGrupoPefil);
            mADM_Grupo_Perfil.Eliminar();
            mADM_Grupo_Perfil = null;

        }

        public DataRow ADM_Grupo_PerfilCargar (String psIdGrupoPefil)
        {
            return ADM_Grupo_PerfilPersistence.CargarDatosADM_Grupo_Perfil(Convert.ToInt64(psIdGrupoPefil));
        }

        public DataTable ADM_Grupo_PerfilsCargar ()
        {
            return ADM_Grupo_PerfilPersistence.CargarADM_Grupo_Perfils();
        }

        /// <summary>
        /// controlador que permite eliminar perfil asociados al grupo
        /// </summary>
        /// <param name="iIdGrupo">Entrada Grupo a eliminar</param>
        public void EliminarGrupoPerfil(int iIdGrupo)
        {
            ADM_Grupo_PerfilPersistence.EliminarGrupoPerfil(iIdGrupo);
        }

        public DataTable ListarGrupoPerfilXIdGrupo(int iIdGrupo)
        {
            return ADM_Grupo_PerfilPersistence.ListarGrupoPerfilXIdGrupo(iIdGrupo);
        }

        /// <summary>
        /// Controlador que permite Asignar perfiles a Usuarios dependiendo el grupo seleccionado
        /// </summary>
        /// <param name="piIdUsuario">IdUsuario</param>
        /// <param name="piIdGrupo">IdGrupo</param>
        public void AsignarPerfilesGrupoUsuario(int piIdUsuario, int piIdGrupo)
        {
            ADM_Grupo_PerfilPersistence.AsignarPerfilesGrupoUsuario(piIdUsuario, piIdGrupo);
        }

        /// <summary>
        /// Controlador que permite eliminar perfiles asociados al usuarios pertenecientes al grupo elimnado
        /// </summary>
        /// <param name="iIdUsuarioGrupo">IdUsuarioGrupo</param>
        public void EliminarUsuariosPerfilXGrupo(int iIdUsuarioGrupo)
        {
            ADM_Grupo_PerfilPersistence.EliminarUsuariosPerfilXGrupo(iIdUsuarioGrupo);
        }

        /// <summary>
        /// Controlador que permite verificar si existe perfil o perfil del sistema en los grupos
        /// </summary>
        /// <param name="iIdGrupo">IdGrupo</param>
        /// <param name="sIdPerfil">IdPerfil</param>
        /// <returns>DataRow</returns>
        public DataRow VerificarExistenciaPerfilGrupo(int iIdGrupo, string sIdPerfil)
        {
            return ADM_Grupo_PerfilPersistence.VerificarExistenciaPerfilGrupo(iIdGrupo,sIdPerfil);
        }
    }

}

            