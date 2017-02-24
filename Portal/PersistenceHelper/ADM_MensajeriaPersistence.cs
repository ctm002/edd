/********************************************
/       Portal Develop 2014
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            con la base de datos
/********************************************
/ Fecha : Fecha : 20-06-2014
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


    public class ADM_MensajeriaPersistence
    {
        #region [Constructor]
        public ADM_MensajeriaPersistence()
        {
        }
        #endregion
        #region [Metodos]
        public static DataRow CargarDatosADM_Mensajeria(Int64 Id)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@Id", Id);
            return InDataAccess.InDbHelper.Instancia.ObtenerDataRow("adm_mensajeria_ListarXPKS", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        internal static long ModificarADM_Mensajeria(ParametrosDA mParametros)
        {
            return Convert.ToInt64(InDataAccess.InDbHelper.Instancia.ObtenerEscalar("adm_mensajeria_Modificar", mParametros, true, DataAccess.eTipoMotor.SqlServer));
        }
        internal static void EliminarADM_Mensajeria(ParametrosDA mParametros)
        {
            InDataAccess.InDbHelper.Instancia.EjecutarProcedimientoAlmacenado("adm_mensajeria_Eliminar", mParametros, true, DataAccess.eTipoMotor.SqlServer);
        }
        public static System.Data.DataTable CargarADM_Mensajerias()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("adm_mensajeria_Listar", true, DataAccess.eTipoMotor.SqlServer);
        }
        #endregion

        internal static DataTable GetMensajeriaToMantenedor()
        {
            return InDataAccess.InDbHelper.Instancia.ObtenerDataTable("ADM_GetMensajeriaMantenedor", true, DataAccess.eTipoMotor.SqlServer);
        }
    }
}