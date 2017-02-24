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


    public class ADM_Tipo_PermisoPersistence
    {
        #region [Constructor]
        public ADM_Tipo_PermisoPersistence()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADM_Tipo_Permiso(Int64 IdTipoPermiso)
        {
            ParametrosDA mParametros = new ParametrosDA();
            
            
            mParametros.Agregar("@IdTipoPermiso", IdTipoPermiso);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("ADM_Tipo_Permiso_ListarXPKS", mParametros);
        }
        internal static long ModificarADM_Tipo_Permiso(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("ADM_Tipo_Permiso_Modificar", mParametros));
        }
        internal static void EliminarADM_Tipo_Permiso(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("ADM_Tipo_Permiso_Eliminar", mParametros);
        }
        public static System.Data.DataTable CargarADM_Tipo_Permisos()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_Tipo_Permiso_Listar");
        }
        #endregion
    }
}