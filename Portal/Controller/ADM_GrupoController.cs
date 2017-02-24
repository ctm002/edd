
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

    public class ADM_GrupoController
    {


        public void ADM_GrupoEditar(String psIdGrupo,String psDescripcion,String psFecha)
        {
            ADM_Grupo mADM_Grupo = new ADM_Grupo(Convert.ToInt64(psIdGrupo));
            
                 mADM_Grupo.IdGrupo = Convert.ToInt64(psIdGrupo);
                 mADM_Grupo.Descripcion = Convert.ToString(psDescripcion);
                 mADM_Grupo.Fecha = Convert.ToDateTime(psFecha);
            mADM_Grupo.Modificar();
            mADM_Grupo = null;
            
        }

        public void ADM_GrupoEliminacion(String psIdGrupo)
        {
            ADM_Grupo mADM_Grupo  = new ADM_Grupo(Convert.ToInt64(psIdGrupo));
            
 mADM_Grupo.IdGrupo = Convert.ToInt64(psIdGrupo);
            mADM_Grupo.Eliminar();
            mADM_Grupo = null;

        }

        public DataRow ADM_GrupoCargar (String psIdGrupo)
        {
            return ADM_GrupoPersistence.CargarDatosADM_Grupo(Convert.ToInt64(psIdGrupo));
        }

        public DataTable ADM_GruposCargar ()
        {
            return ADM_GrupoPersistence.CargarADM_Grupos();
        }

        /// <summary>
        /// Controlador que permite Obtener el nombre del grupo a Modificar
        /// </summary>
        /// <param name="iIdGrupo">IdGrupo</param>
        public string ObtenerNombreGrupo(int iIdGrupo)
        {
            ADM_Grupo obj = new ADM_Grupo(iIdGrupo);
            return obj.Descripcion;
        }
    }

}

            