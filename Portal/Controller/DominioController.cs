using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InDataAccess.Parametros;

namespace Portal.Controller
{
    public class DominioController
    {
        public DominioController()
        {
            CargarGrillasDinamicas();
        }

        /// <summary>
        /// Metodo en el que se deben asignar todos los objetos a utilizar en la Grilla dinamicas
        /// </summary>
        private void CargarGrillasDinamicas()
        {
            Portal.PortalFacade.Singleton.PortalController.AgregarMantenedor("usuario", new Portal.Domain.Object.Usuario());
            Portal.PortalFacade.Singleton.PortalController.AgregarMantenedor("sistema", new Portal.Domain.Object.Sistema());
            Portal.PortalFacade.Singleton.PortalController.AgregarMantenedor("permiso", new Portal.Domain.Object.Permiso());
            Portal.PortalFacade.Singleton.PortalController.AgregarMantenedor("adm_tipo_permiso", new Portal.Domain.Object.ADM_Tipo_Permiso());
        }

        public bool ValidarCargaGrillasDinamicas()
        {
            return Portal.PortalFacade.Singleton.PortalController.ListadoObjetosMantenedores.Count > 0 ? true : false;
        }

    }

}
