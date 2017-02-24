
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

    public class ADM_Tipo_PermisoController
    {


        public void ADM_Tipo_PermisoEditar(String psIdTipoPermiso,String psDescripcion)
        {
            ADM_Tipo_Permiso mADM_Tipo_Permiso = new ADM_Tipo_Permiso(Convert.ToInt64(psIdTipoPermiso));
            
                 mADM_Tipo_Permiso.IdTipoPermiso = Convert.ToInt64(psIdTipoPermiso);
                 mADM_Tipo_Permiso.Descripcion = Convert.ToString(psDescripcion);
            mADM_Tipo_Permiso.Modificar();
            mADM_Tipo_Permiso = null;
            
        }

        public void ADM_Tipo_PermisoEliminacion(String psIdTipoPermiso)
        {
            ADM_Tipo_Permiso mADM_Tipo_Permiso  = new ADM_Tipo_Permiso(Convert.ToInt64(psIdTipoPermiso));
            
 mADM_Tipo_Permiso.IdTipoPermiso = Convert.ToInt64(psIdTipoPermiso);
            mADM_Tipo_Permiso.Eliminar();
            mADM_Tipo_Permiso = null;

        }

        public DataRow ADM_Tipo_PermisoCargar (String psIdTipoPermiso)
        {
            return ADM_Tipo_PermisoPersistence.CargarDatosADM_Tipo_Permiso(Convert.ToInt64(psIdTipoPermiso));
        }

        public DataTable ADM_Tipo_PermisosCargar ()
        {
            return ADM_Tipo_PermisoPersistence.CargarADM_Tipo_Permisos();
        }

        /// <summary>
        /// Controlador que permite obtener nombre del Tipo Permiso
        /// </summary>
        /// <param name="pIdTipoPermiso"></param>
        /// <returns></returns>
        public string ObtenerNombrePermisoTipoXId(string pIdTipoPermiso)
        {
            if (pIdTipoPermiso == "")
                pIdTipoPermiso = "0";
            ADM_Tipo_Permiso obj = new ADM_Tipo_Permiso(Convert.ToInt32(pIdTipoPermiso));
            return obj.Descripcion;
        }
    }

}

            