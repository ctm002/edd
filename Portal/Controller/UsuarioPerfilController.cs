
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
    using Portal.PersistenceHelper;
    //using Portal.Domain.Enum;

    public class UsuarioPerfilController
    {


        public void UsuarioPerfilEditar(String psIdUsuarioPerfil, String psIdPerfil, String psIdUsuario)
        {
            UsuarioPerfil mUsuarioPerfil = new UsuarioPerfil(Convert.ToInt64(psIdUsuarioPerfil));

            mUsuarioPerfil.IdUsuarioPerfil = Convert.ToInt64(psIdUsuarioPerfil);
            mUsuarioPerfil.IdPerfil = Convert.ToInt64(psIdPerfil);
            mUsuarioPerfil.IdUsuario = Convert.ToInt64(psIdUsuario);
            mUsuarioPerfil.Modificar();
            Usuario mUsuario = new Usuario(Convert.ToInt32(psIdUsuario));
            PortalFacade.Singleton.UsuarioController.DesconectarUsuario(mUsuario.LoginName);
            mUsuarioPerfil = null;
            mUsuario = null;
        }

        public void UsuarioPerfilEliminacion(String psIdUsuarioPerfil)
        {
            UsuarioPerfil mUsuarioPerfil = new UsuarioPerfil(Convert.ToInt64(psIdUsuarioPerfil));

            mUsuarioPerfil.IdUsuarioPerfil = Convert.ToInt64(psIdUsuarioPerfil);
            mUsuarioPerfil.Eliminar();
            Usuario mUsuario = new Usuario(Convert.ToInt32(mUsuarioPerfil.IdUsuario));
            PortalFacade.Singleton.UsuarioController.DesconectarUsuario(mUsuario.LoginName);

            mUsuarioPerfil = null;
            mUsuario = null;

        }

        public DataRow UsuarioPerfilCargar(String psIdUsuarioPerfil)
        {
            return UsuarioPerfilPersistenceHelper.CargarDatosUsuarioPerfil(Convert.ToInt64(psIdUsuarioPerfil));
        }

        public DataTable UsuarioPerfilsCargar()
        {
            return UsuarioPerfilPersistenceHelper.CargarUsuarioPerfils();
        }

        /// <summary>
        /// Controlador que permite listar informacion del usuario perfil XUSusario
        /// </summary>
        /// <param name="iIDUsuario">IdUsuario</param>
        /// <returns>dataTable</returns>
        public DataTable UsuarioPerfilXUsuario(int iIDUsuario)
        {
            return UsuarioPerfilPersistenceHelper.UsuarioPerfilXUsuario(iIDUsuario);
        }
        /// <summary>
        /// Controlador que permite listar usuarios por perfil
        /// </summary>
        /// <param name="iIdPerfil">IdPerfil</param>
        /// <returns>DataTable</returns>
        public DataTable ListarUsuariosXPerfil(int iIdPerfil)
        {
            return UsuarioPerfilPersistenceHelper.ListarUsuariosXPerfil(iIdPerfil);
        }

        public DataRow VerificarPerfilAsociadoUsuario(int iIDUsuario, int iIdPerfil)
        {
            return UsuarioPerfilPersistenceHelper.VerificarPerfilAsociadoUsuario(iIDUsuario,iIdPerfil);
        }
    }

}

            