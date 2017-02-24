
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

    public class ADMSistemaAliasController
    {


        public void ADMSistemaAliasEditar(String psIdAlias,String psUrl,String psIdSistema)
        {
            ADMSistemaAlias mADMSistemaAlias = new ADMSistemaAlias(Convert.ToInt64(psIdAlias));
            
                 mADMSistemaAlias.IdAlias = Convert.ToInt64(psIdAlias);
                 mADMSistemaAlias.Url = Convert.ToString(psUrl);
                 mADMSistemaAlias.IdSistema = Convert.ToInt64(psIdSistema);
            mADMSistemaAlias.Modificar();
            mADMSistemaAlias = null;
            
        }

        public void ADMSistemaAliasEliminacion(String psIdAlias)
        {
            ADMSistemaAlias mADMSistemaAlias  = new ADMSistemaAlias(Convert.ToInt64(psIdAlias));
            
 mADMSistemaAlias.IdAlias = Convert.ToInt64(psIdAlias);
            mADMSistemaAlias.Eliminar();
            mADMSistemaAlias = null;

        }

        public DataRow ADMSistemaAliasCargar (String psIdAlias)
        {
            return ADMSistemaAliasPersistence.CargarDatosADMSistemaAlias(Convert.ToInt64(psIdAlias));
        }

        public DataTable ADMSistemaAliassCargar ()
        {
            return ADMSistemaAliasPersistence.CargarADMSistemaAliass();
        }

        /// <summary>
        /// controlador que permite listar Alias del sistema x iDSistema
        /// </summary>
        /// <param name="iIdSistema">sistema</param>
        /// <returns>DataTable</returns>
        public DataTable CargarAliasXSistema(int iIdSistema)
        {
            return ADMSistemaAliasPersistence.CargarAliasXSistema(iIdSistema);
        }
    }

}

            