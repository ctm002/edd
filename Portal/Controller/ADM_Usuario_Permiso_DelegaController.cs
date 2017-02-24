
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

    public class ADM_Usuario_Permiso_DelegaController
    {


        public void ADM_Usuario_Permiso_DelegaEditar(String psIdDelegado,String psIdUsuario,String psIdUsuarioDelegado,String psIdPermiso)
        {
            ADM_Usuario_Permiso_Delega mADM_Usuario_Permiso_Delega = new ADM_Usuario_Permiso_Delega(Convert.ToInt64(psIdDelegado));
            
                 mADM_Usuario_Permiso_Delega.IdDelegado = Convert.ToInt64(psIdDelegado);
                 mADM_Usuario_Permiso_Delega.IdUsuario = Convert.ToInt64(psIdUsuario);
                 mADM_Usuario_Permiso_Delega.IdUsuarioDelegado = Convert.ToInt64(psIdUsuarioDelegado);
                 mADM_Usuario_Permiso_Delega.IdPermiso = Convert.ToInt64(psIdPermiso);
            mADM_Usuario_Permiso_Delega.Modificar();
            mADM_Usuario_Permiso_Delega = null;
            
        }

        public void ADM_Usuario_Permiso_DelegaEliminacion(String psIdDelegado)
        {
            ADM_Usuario_Permiso_Delega mADM_Usuario_Permiso_Delega  = new ADM_Usuario_Permiso_Delega(Convert.ToInt64(psIdDelegado));
            
 mADM_Usuario_Permiso_Delega.IdDelegado = Convert.ToInt64(psIdDelegado);
            mADM_Usuario_Permiso_Delega.Eliminar();
            mADM_Usuario_Permiso_Delega = null;

        }

        public DataRow ADM_Usuario_Permiso_DelegaCargar (String psIdDelegado)
        {
            return ADM_Usuario_Permiso_DelegaPersistence.CargarDatosADM_Usuario_Permiso_Delega(Convert.ToInt64(psIdDelegado));
        }

        public DataTable ADM_Usuario_Permiso_DelegasCargar ()
        {
            return ADM_Usuario_Permiso_DelegaPersistence.CargarADM_Usuario_Permiso_Delegas();
        }

        public DataTable UsuariosDelegadosXIdUsuario(int iIDUsuario)
        {
            return ADM_Usuario_Permiso_DelegaPersistence.UsuariosDelegadosXIdUsuario(iIDUsuario);
        }
    }

}

            