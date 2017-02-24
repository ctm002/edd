
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

    public class ADM_MensajeriaController
    {


        public long ADM_MensajeriaEditar(String psId,String psMensaje,String psIdUsuario,String psIdUsuarioMod,String psFecha,String psFechaMod,String psEstado,byte[] psArchivo,String psNombreArchivo,String psContentType , String psIdSistema)
        {
            ADM_Mensajeria mADM_Mensajeria = new ADM_Mensajeria(Convert.ToInt64(psId));
            
                 mADM_Mensajeria.Id = Convert.ToInt64(psId);
                 mADM_Mensajeria.Mensaje = Convert.ToString(psMensaje);
                 mADM_Mensajeria.IdUsuario = Convert.ToInt64(psIdUsuario);
                 mADM_Mensajeria.IdUsuarioMod = Convert.ToInt64(psIdUsuarioMod);
                 mADM_Mensajeria.Fecha = Convert.ToDateTime(psFecha);
                 mADM_Mensajeria.FechaMod = Convert.ToDateTime(psFechaMod);
                 mADM_Mensajeria.Estado = Convert.ToInt64(psEstado);
                 mADM_Mensajeria.Archivo = psArchivo;
                 mADM_Mensajeria.NombreArchivo = Convert.ToString(psNombreArchivo);
                 mADM_Mensajeria.ContentType = Convert.ToString(psContentType);
                 mADM_Mensajeria.IdSistema = Convert.ToInt32(psIdSistema);
            mADM_Mensajeria.Modificar();
            long lSalida = mADM_Mensajeria.Id;
            mADM_Mensajeria = null;
            return lSalida;
            
        }

        public void ADM_MensajeriaEliminacion(String psId)
        {
            ADM_Mensajeria mADM_Mensajeria  = new ADM_Mensajeria(Convert.ToInt64(psId));
            
 mADM_Mensajeria.Id = Convert.ToInt64(psId);
            mADM_Mensajeria.Eliminar();
            mADM_Mensajeria = null;

        }

        public DataRow ADM_MensajeriaCargar (String psId)
        {
            return ADM_MensajeriaPersistence.CargarDatosADM_Mensajeria(Convert.ToInt64(psId));
        }

        public DataTable ADM_MensajeriasCargar ()
        {
            return ADM_MensajeriaPersistence.CargarADM_Mensajerias();
        }

        /// <summary>
        /// Controlador que permite obtener 
        /// </summary>
        /// <returns></returns>
        public DataTable GetMensajeriaToMantenedor()
        {
            return ADM_MensajeriaPersistence.GetMensajeriaToMantenedor();
        }

        /// <summary>
        /// Controlador que permite obtener el objeto en cuestion
        /// </summary>
        /// <param name="Id">Id para el Constructor</param>
        /// <returns>OBJ</returns>
        public ADM_Mensajeria ObtenerObjeto(int Id)
        {
            return new ADM_Mensajeria(Id);
        }
    }

}

            