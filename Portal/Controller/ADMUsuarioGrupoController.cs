
using System;
using System.Data;

namespace Portal.Controller
{
    using Portal.Domain.Object;
    using Portal.Persistence;

    public class ADMUsuarioGrupoController
    {
        public void ADMUsuarioGrupoEditar(String psIdUsuarioGrupo, String psIdUsuario, String psIdGrupo)
        {
            ADMUsuarioGrupo mADMUsuarioGrupo = new ADMUsuarioGrupo(Convert.ToInt64(psIdUsuarioGrupo));
            mADMUsuarioGrupo.IdUsuarioGrupo = Convert.ToInt64(psIdUsuarioGrupo);
            mADMUsuarioGrupo.IdUsuario = Convert.ToInt64(psIdUsuario);
            mADMUsuarioGrupo.IdGrupo = Convert.ToInt64(psIdGrupo);
            mADMUsuarioGrupo.Modificar();
        }

        public void ADMUsuarioGrupoEliminacion(String psIdUsuarioGrupo)
        {
            ADMUsuarioGrupo mADMUsuarioGrupo = new ADMUsuarioGrupo(Convert.ToInt64(psIdUsuarioGrupo));
            mADMUsuarioGrupo.IdUsuarioGrupo = Convert.ToInt64(psIdUsuarioGrupo);
            mADMUsuarioGrupo.Eliminar();
        }

        public DataRow ADMUsuarioGrupoCargar(String psIdUsuarioGrupo)
        {
            return ADMUsuarioGrupoPersistence.CargarDatosADMUsuarioGrupo(Convert.ToInt64(psIdUsuarioGrupo));
        }

        public DataTable ADMUsuarioGruposCargar()
        {
            return ADMUsuarioGrupoPersistence.CargarADMUsuarioGrupos();
        }

        /// <summary>
        /// Controlador que permite obtener usuarios asociados al grupo
        /// </summary>
        /// <param name="iIdGrupo">IdGRupo</param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerUsuariosXGrupoId(int iIdGrupo)
        {
            return ADMUsuarioGrupoPersistence.ObtenerUsuariosXGrupoId(iIdGrupo);
        }
    }

}

