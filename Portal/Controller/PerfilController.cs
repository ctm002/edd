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
    public class PerfilController
    {
        public void EditarPagina(Int32 psIdPerfil,string psDescripcion,string psIdSistema , string sIdPorDefecto)
        {
            Perfil mPerfil = new Perfil(psIdPerfil);
            //        Modificar(Controller)
            mPerfil.IdPerfil = Convert.ToInt32(psIdPerfil);
            mPerfil.Descripcion = Convert.ToString(psDescripcion);
            mPerfil.IdSistema = Convert.ToInt32(psIdSistema);
            mPerfil.IdPaginaDefecto = Convert.ToInt32(sIdPorDefecto);

            mPerfil.Modificar();
            mPerfil = null;
        }

        public DataTable CargarPerfil()
        {
            return PerfilPersistance.CargarPerfil();
        }

        public void EliminarPagina(int psIdPerfil)
        {
            Perfil mPerfil = new Perfil(psIdPerfil);
            mPerfil.IdPerfil = Convert.ToInt32(psIdPerfil);
            mPerfil.Eliminar();
            mPerfil = null;
        }
        public DataTable ObtenerListadoUsuariosPerfil(int piIdPerfil)
        {
            return Factory.FactoryTablas.Singleton.ObtenerDataSourceValorTabla(piIdPerfil, "ADM_Usuario_Perfil");
        }
        public void LimpiarTabla(int piIdPerfil)
        {
            Factory.FactoryTablas.Singleton.LimpiarTabla(piIdPerfil, "ADM_Usuario_Perfil");
        }
        public DataTable CargarMenus()
        {
            return PaginaPersistence.CargarPagina();
        }

        public DataTable ObtenerListadoUsuariosAsignados(int piIdUsuario)
        {
            return Portal.PersistenceHelper.PerfilPersistance.ObtenerListadoUsuariosAsignados(piIdUsuario);
        }

        public string ObtenerNombrePerfil(int pIdPerfil)
        {
            Perfil obj = new Perfil(pIdPerfil);
            string Desc = obj.Descripcion;
            obj = null;
            return Desc;
        }
        /// <summary>
        /// Controlador que obtiene nomobre Sistema por IdPerfil
        /// </summary>
        /// <param name="pIdPerfil"></param>
        /// <returns></returns>
        public string ObtenerSistemaXIdPerfil(int pIdPerfil)
        {
            Perfil obj = new Perfil(pIdPerfil);
            Sistema objsistema = new Sistema(obj.IdSistema);
            return objsistema.Descripcion;
            
        }

        /// <summary>
        /// Controlador que obtiene nomobre Sistema por IdPerfil
        /// </summary>
        /// <param name="pIdPerfil"></param>
        /// <returns></returns>
        public int ObtenerIdSistemaXIdPerfil(int pIdPerfil)
        {
            Perfil obj = new Perfil(pIdPerfil);
            Sistema objsistema = new Sistema(obj.IdSistema);
            return objsistema.IdSistema;

        }
        /// <summary>
        /// Obtiene Perfiles X sistema
        /// </summary>
        /// <param name="iIdSistema"></param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerPerfilesXSistema(int iIdSistema)
        {
            return PerfilPersistance.ObtenerPerfilesXSistema(iIdSistema);
        }

        /// <summary>
        /// Controlador que permite eliminar Permisos, Usuarios y el perfil correspondiente
        /// </summary>
        /// <param name="iIdPerfil">IdPerfil</param>
        /// <returns>entero de Salida 1 o 0</returns>
        public int EliminarPerfil(int iIdPerfil)
        {
            return PerfilPersistance.EliminarPerfil(iIdPerfil);
        }
    }
}
