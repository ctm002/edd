/********************************************
/       Portal Develop 2012
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 20-07-2012
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


    public class ADM_Usuario_Permiso_DelegaPersistence
    {
        #region [Constructor]
        public ADM_Usuario_Permiso_DelegaPersistence()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADM_Usuario_Permiso_Delega(Int64 IdDelegado)
        {
            ParametrosDA mParametros = new ParametrosDA();
            
            
 mParametros.Agregar("@IdDelegado", IdDelegado);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_usuario_permiso_delega_ListarXPKS", mParametros);
        }
        internal static long ModificarADM_Usuario_Permiso_Delega(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_usuario_permiso_delega_Modificar", mParametros));
        }
        internal static void EliminarADM_Usuario_Permiso_Delega(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_usuario_permiso_delega_Eliminar", mParametros);
        }
        public static System.Data.DataTable CargarADM_Usuario_Permiso_Delegas()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_usuario_permiso_delega_Listar");
        }
        #endregion

        internal static DataTable UsuariosDelegadosXIdUsuario(int iIDUsuario)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario",iIDUsuario);

            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_ListaDelegadosXUsuario", mParam);
        }
    }
}