
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

    public class PerfilPermisoController
    {


        public void PerfilPermisoEditar(String psIdPerfilPermiso, String psIdPerfil, String psIdPermiso)
        {
            PerfilPermiso mPerfilPermiso = new PerfilPermiso(Convert.ToInt64(psIdPerfilPermiso));

            mPerfilPermiso.IdPerfilPermiso = Convert.ToInt64(psIdPerfilPermiso);
            mPerfilPermiso.IdPerfil = Convert.ToInt64(psIdPerfil);
            mPerfilPermiso.IdPermiso = Convert.ToInt64(psIdPermiso);
            mPerfilPermiso.Modificar();
            mPerfilPermiso = null;

        }

        public void PerfilPermisoEliminacion(String psIdPerfilPermiso)
        {
            PerfilPermiso mPerfilPermiso = new PerfilPermiso(Convert.ToInt64(psIdPerfilPermiso));

            mPerfilPermiso.IdPerfilPermiso = Convert.ToInt64(psIdPerfilPermiso);
            mPerfilPermiso.Eliminar();
            mPerfilPermiso = null;

        }

        public DataRow PerfilPermisoCargar(String psIdPerfilPermiso)
        {
            return PerfilPermisoPersistenceHelper.CargarDatosPerfilPermiso(Convert.ToInt64(psIdPerfilPermiso));
        }

        public DataTable PerfilPermisosCargar()
        {
            return PerfilPermisoPersistenceHelper.CargarPerfilPermisos();
        }
        /// <summary>
        /// Controlador que permite Verificar que exista Perfil
        /// </summary>
        /// <param name="iPermiso">IdPermiso</param>
        /// <param name="iIdPerfil">IdPerfil</param>
        /// <returns>True o False</returns>
        public bool VerificarExistenciaPerfilPermiso(int iPermiso, int iIdPerfil)
        {
            return Convert.ToBoolean(PerfilPermisoPersistenceHelper.VerificarExistenciaPerfilPermiso(iPermiso,iIdPerfil));
        }
        /// <summary>
        /// Borrar Permisos por Perfil
        /// </summary>
        /// <param name="iIdPerfil">IdPerfil</param>
        public void BorrarXPerfil(int iIdPerfil)
        {
            PerfilPermisoPersistenceHelper.BorrarXPerfil(iIdPerfil);
        }
    }

}

            