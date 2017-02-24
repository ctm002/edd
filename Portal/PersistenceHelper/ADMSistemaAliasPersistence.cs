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


    public class ADMSistemaAliasPersistence
    {
        #region [Constructor]
        public ADMSistemaAliasPersistence()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADMSistemaAlias(Int64 IdAlias)
        {
            ParametrosDA mParametros = new ParametrosDA();
            
            
 mParametros.Agregar("@IdAlias", IdAlias);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_sistema_alias_ListarXPKS", mParametros);
        }
        internal static long ModificarADMSistemaAlias(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_sistema_alias_Modificar", mParametros));
        }
        internal static void EliminarADMSistemaAlias(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_sistema_alias_Eliminar", mParametros);
        }
        public static System.Data.DataTable CargarADMSistemaAliass()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_sistema_alias_Listar");
        }
        #endregion

        internal static DataTable CargarAliasXSistema(int iIdSistema)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdSistema",iIdSistema);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_AliasXSistema",mParam);
        }
    }
}