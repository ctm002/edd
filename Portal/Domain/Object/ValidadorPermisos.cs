using System;
using System.Collections;

namespace Portal.Domain.Object
{
    public class ValidadorPermisos
    {
        private SortedList mPermisos;

        public ValidadorPermisos()
        {
            mPermisos = new SortedList();
        }

        public bool Validar(Usuario pUsuario, int piIdSistema)
        {
            if (mPermisos.Count == 0)
                return true;
            else
                for (int i = 0; i < mPermisos.Count; i++)
                {
                    if (PortalFacade.Singleton.UsuarioController.ValidarPermiso(pUsuario, Convert.ToInt32(mPermisos.GetKey(i))))
                        return true;
                }
            return false;
        }
    }
}
