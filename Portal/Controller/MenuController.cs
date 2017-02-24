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
    public class MenuController
    {

        public void EditarMenu(int psIdMenu, int psIdPadre, string psNombre, string psDescripcion, string psUrl, int psIdSistema, int pPosiscion)
        {
            Menu mADM_Menu = new Menu(psIdMenu);
            mADM_Menu.IdMenu = Convert.ToInt32(psIdMenu);
            mADM_Menu.IdPadre = Convert.ToInt32(psIdPadre);
            mADM_Menu.Nombre = Convert.ToString(psNombre);
            mADM_Menu.Descripcion = Convert.ToString(psDescripcion);
            mADM_Menu.Url = Convert.ToString(psUrl);
            mADM_Menu.IdSistema = Convert.ToInt32(psIdSistema);
            mADM_Menu.Posicion = Convert.ToInt32(pPosiscion);

            mADM_Menu.Modificar();
            mADM_Menu = null;
        }

        public void EliminarMenu(int pIdMenu)
        {
            Menu mADM_Menu = new Menu(pIdMenu);
            mADM_Menu.IdMenu = Convert.ToInt32(pIdMenu);
            mADM_Menu.Eliminar();
            mADM_Menu = null;
        }

        public DataTable CargarMenus()
        {
            return MenuPersistence.CargarMenu();
        }
        /// <summary>
        /// Controlador que permite
        /// </summary>
        /// <param name="iIdSistema"></param>
        /// <returns></returns>
        public DataTable ObtenerMenuXSistema(int iIdSistema)
        {
            return MenuPersistence.ObtenerMenuXSistema(iIdSistema);
        }



        public string ObtenerNombreMenuXId(string pIdMenu)
        {
            Menu obj = new Menu(Convert.ToInt32(pIdMenu));
            return obj.Nombre;
        }
    }
}
