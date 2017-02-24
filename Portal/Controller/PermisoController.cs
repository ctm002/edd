using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Domain.Factory;
using Portal.PersistenceHelper;
using InDataAccess.Parametros;
using System.Data;
using Portal.Domain.Object;
namespace Portal.Controller
{
    public class PermisoController
    {
        public void EditarPermiso(Int32 psIdPermiso, string psDescripcion,Int32 pdIdSistema, string psGlosa , string psIdTipoPermiso)
        {
            Permiso mPermiso = new Permiso(psIdPermiso);
            //        Modificar(Controller)
            mPermiso.IdPermiso = Convert.ToInt32(psIdPermiso);
            mPermiso.Descripcion = Convert.ToString(psDescripcion);
            mPermiso.IdSistema = Convert.ToInt32(pdIdSistema);
            mPermiso.Glosa = Convert.ToString(psGlosa);
            mPermiso.IdTipoPermiso = Convert.ToInt32(psIdTipoPermiso);

            mPermiso.Modificar();
            mPermiso = null;
        }

        public void EliminarPermiso(int psIdPermiso)
        {
            Permiso mPermiso = new Permiso(psIdPermiso);
            mPermiso.IdPermiso = Convert.ToInt32(psIdPermiso);
            mPermiso.Eliminar();
            mPermiso = null;
        }

        public DataTable CargarPermisos()
        {
            return PermisoPersistence.CargarPermiso();
        }

        /// <summary>
        /// Conmtrolador que permite listar informacion de Permisos Por Perfil
        /// </summary>
        /// <param name="iIdPerfil">IdPerfil</param>
        /// <returns></returns>
        public DataTable PermisosXIdPerfil(int iIdPerfil)
        {
            return PermisoPersistence.TodosPermisosXIdPerfil(iIdPerfil);
        }
        /// <summary>
        /// Controlador que permite listar Informacion de Permisos por IdSistema
        /// </summary>
        /// <param name="iIdSistema">Sistema seleccionado</param>
        /// <returns>DataTable con la informacion</returns>
        public DataTable CargarPermisosXSistema(int iIdSistema)
        {
            return PermisoPersistence.CargarPermisosXSistema(iIdSistema);
        }
        /// <summary>
        /// Metodo que permite Obtener Permiso x ID
        /// </summary>
        /// <param name="iIdPermiso">IdPermiso</param>
        /// <returns>DataTable</returns>
        public string ObtenerNombrePermiso(int iIdPermiso)
        {
            Permiso mPermiso = new Permiso(iIdPermiso);

            return mPermiso.Descripcion;

        }

        /// <summary>
        /// Controlador que permite 
        /// </summary>
        /// <param name="iidPermiso"></param>
        public void EliminarPermisoTotal(int iidPermiso)
        {
            PermisoPersistence.EliminarPermisoTotal(iidPermiso);
        }


        public int ObtenerSistemaXIdPerfil(int piIdPermiso)
        {
            Permiso obj = new Permiso(piIdPermiso);
            return obj.IdSistema; 
        }
    }
}
