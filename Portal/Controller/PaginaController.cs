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
    public class PaginaController
    {

        public void EditarPagina(int psIdPagina,string psIdMenu,string psNombre,string psDescripcion,string psUrl,string psIdPermiso , string psOrden)
        {
            Pagina mPagina = new Pagina(psIdPagina);
            mPagina.IdMenu = Convert.ToInt32(psIdMenu);
            mPagina.Nombre = Convert.ToString(psNombre);
            mPagina.Descripcion = Convert.ToString(psDescripcion);
            mPagina.Url = Convert.ToString(psUrl);
            mPagina.IdPermiso = Convert.ToInt32(psIdPermiso);
            mPagina.Orden = Convert.ToInt32(psOrden);

            mPagina.Modificar();
            mPagina = null;
        }

        public void EliminarPagina(int psIdPagina)
        {
            Pagina mPagina = new Pagina(psIdPagina);
            mPagina.IdPagina = Convert.ToInt32(psIdPagina);
            mPagina.Eliminar();
            mPagina = null;
        }

        public DataTable CargarMenus()
        {
            return PaginaPersistence.CargarPagina();
        }

        /// <summary>
        /// Metodo que permite listar informacion de Paginas por Sistema Seleccionado
        /// </summary>
        /// <param name="iIdSistema">IdSistema</param>
        /// <returns></returns>
        public DataTable CargarPaginasXSistema(int iIdSistema)
        {
            return PaginaPersistence.CargarPaginasXSistema(iIdSistema);
        }

        public string ObtenerNombreMenuXId(string pIdMenu)
        {
            Menu obj = new Menu(Convert.ToInt32(pIdMenu));

            return obj.Nombre;
        }

        /// <summary>
        /// Controlador que permite liostas el menu por idmenu
        /// </summary>
        /// <param name="iIdPagina">IdPagina</param>
        /// <returns>string con el nombre</returns>
        public int ObtenerMenuXIdPagina(int iIdPagina)
        {
            Pagina obj = new Pagina(iIdPagina);
            return obj.IdMenu;
        }
    }
}
