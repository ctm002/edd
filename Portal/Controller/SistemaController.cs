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
    public class SistemaController
    {
        public void EditarSistema(Int32 psIdSistema, string psDescripcion,string psUrl, int IdSistemaTipo)
        {
            Sistema mSistema = new Sistema(psIdSistema);
            //        Modificar(Controller)
            mSistema.IdSistema = Convert.ToInt32(psIdSistema);
            mSistema.Descripcion = Convert.ToString(psDescripcion);
            mSistema.Url = Convert.ToString(psUrl);
            mSistema.IdSistemaTipo = Convert.ToInt32(IdSistemaTipo);
            mSistema.Modificar();
            mSistema = null;
        }

        public void EliminarSistema(int psIdSistema)
        {
            Sistema mSistema = new Sistema(psIdSistema);
            mSistema.IdSistema = Convert.ToInt32(psIdSistema);
            mSistema.Eliminar();
            mSistema = null;
        }

        public DataTable CargarMenus()
        {
            return SistemaPersistance.CargarSistema();
        }

        /// <summary>
        /// Obtener Nombre Sistema Por Id
        /// </summary>
        /// <param name="iIdSistema">Id Tabla</param>
        /// <returns>String con nombre Usuario</returns>
        public string ObtenerNombreSistema(int iIdSistema)
        {
            Sistema mSistema = new Sistema(iIdSistema);
            return mSistema.Descripcion;
        }

        /// <summary>
        /// Obtiene Sistema perfil por IdUsuario
        /// </summary>
        /// <param name="iIdUsuario">IdUsuario</param>
        /// <returns>DataTable con informacion de Sistema Perfil</returns>
        public DataTable ObtenerSistemaXIdUsuario(int iIdUsuario)
        {
            return SistemaPersistance.ObtenerSistemaXIdUsuario(iIdUsuario);
        }
    }
}
