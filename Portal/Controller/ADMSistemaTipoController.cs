
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InDataAccess;
//using Dominio.Portal.Domain.Enum;



namespace Portal.Controller
{
    using Portal.Domain.Object;
    using Portal.PersistenceHelper;
    using Portal.PersistenceHelper;
    //using Dominio.Portal.Domain.Enum;

    public class ADMSistemaTipoController
    {


        public void ADMSistemaTipoEditar(String psId,String psDescripcion)
        {
            ADMSistemaTipo mADMSistemaTipo = new ADMSistemaTipo(Convert.ToInt64(psId));
            
                 mADMSistemaTipo.IdSistemaTipo = Convert.ToInt64(psId);
                 mADMSistemaTipo.Descripcion = Convert.ToString(psDescripcion);
            mADMSistemaTipo.Modificar();
            mADMSistemaTipo = null;
            
        }

        public void ADMSistemaTipoEliminacion(String psId)
        {
            ADMSistemaTipo mADMSistemaTipo  = new ADMSistemaTipo(Convert.ToInt64(psId));
            
 mADMSistemaTipo.IdSistemaTipo = Convert.ToInt64(psId);
            mADMSistemaTipo.Eliminar();
            mADMSistemaTipo = null;

        }

        public DataRow ADMSistemaTipoCargar (String psId)
        {
            return ADMSistemaTipoPersistenceHelper.CargarDatosADMSistemaTipo(Convert.ToInt64(psId));
        }

        public DataTable ADMSistemaTiposCargar ()
        {
            return ADMSistemaTipoPersistenceHelper.CargarADMSistemaTipos();
        }
    }

}

            