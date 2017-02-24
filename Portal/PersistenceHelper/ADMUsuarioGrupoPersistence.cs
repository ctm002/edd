/********************************************
/       Portal Develop 2012
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 23-07-2012
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


    public class ADMUsuarioGrupoPersistence
    {
        #region [Constructor]
        public ADMUsuarioGrupoPersistence()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADMUsuarioGrupo(Int64 IdUsuarioGrupo)
        {
            ParametrosDA mParametros = new ParametrosDA();
            
            
 mParametros.Agregar("@IdUsuarioGrupo", IdUsuarioGrupo);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_usuario_grupo_ListarXPKS", mParametros);
        }
        internal static long ModificarADMUsuarioGrupo(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_usuario_grupo_Modificar", mParametros));
        }
        internal static void EliminarADMUsuarioGrupo(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_usuario_grupo_Eliminar", mParametros);
        }
        public static System.Data.DataTable CargarADMUsuarioGrupos()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_usuario_grupo_Listar");
        }
        #endregion

        internal static DataTable ObtenerUsuariosXGrupoId(int iIdGrupo)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdGrupo",iIdGrupo);


            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_UsuariosGrupoXID", mParam);

        }
    }
}