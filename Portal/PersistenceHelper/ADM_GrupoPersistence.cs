/********************************************
/       Portal Develop 2012
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 19-07-2012
/
*********************************************/
namespace Portal.Persistence /**/
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using InDataAccess.Parametros;


    public class ADM_GrupoPersistence
    {
        #region [Constructor]
        public ADM_GrupoPersistence()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADM_Grupo(Int64 IdGrupo)
        {
            ParametrosDA mParametros = new ParametrosDA();
            
            
 mParametros.Agregar("@IdGrupo", IdGrupo);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_grupo_ListarXPKS", mParametros);
        }
        internal static long ModificarADM_Grupo(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_grupo_Modificar", mParametros));
        }
        internal static void EliminarADM_Grupo(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_grupo_Eliminar", mParametros);
        }
        public static System.Data.DataTable CargarADM_Grupos()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_grupo_Listar");
        }
        #endregion
    }
}