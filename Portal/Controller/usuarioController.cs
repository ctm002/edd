using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Domain.Factory;
using Portal.PersistenceHelper;
using InDataAccess.Parametros;
using System.Data;
using Portal.Domain.Object;
using Portal.Factory;
using Portal.Domain.Enum;

namespace Portal.Controller
{
    public class UsuarioController
    {
        Dictionary<string, Session> mListadoSession;
        public UsuarioController()
        {
            mListadoSession = new Dictionary<string, Session>();
        }

        private Dictionary<string, ADUserDetail> mListadoUsuariosConectados;

        public Dictionary<string, ADUserDetail> ListadoUsuariosConectados
        {
            get
            {
                if (mListadoUsuariosConectados == null) mListadoUsuariosConectados = new Dictionary<string, ADUserDetail>();
                return mListadoUsuariosConectados;
            }
        }

        public void EditarUsuario(int psIdUsuario, string psGUID, string psNombre, string psApellidos, string psActivo, string psSkin)
        {
            Usuario mUsuario = new Usuario(psIdUsuario);
            //        Modificar(Controller)
            mUsuario.IdUsuario = Convert.ToInt32(psIdUsuario);
            mUsuario.GUID = Convert.ToString(psGUID);
            mUsuario.Nombres = Convert.ToString(psNombre);
            mUsuario.Apellidos = Convert.ToString(psApellidos);
            mUsuario.Activo = Convert.ToInt32(psActivo);
            mUsuario.Skin = Convert.ToString(psSkin);

            mUsuario.Modificar();
            mUsuario = null;
        }

        public void EliminarUsuario(int psIdUsuario)
        {
            Usuario mUsuario = new Usuario(psIdUsuario);
            mUsuario.IdUsuario = Convert.ToInt32(psIdUsuario);
            mUsuario.Eliminar();
            mUsuario = null;
        }

        public DataTable CargarMenus()
        {
            return UsuarioPersistance.CargarUsuario();
        }
        
        /// <summary>
        /// Metodo que carga el listado de usuarios del sistema Activos
        /// </summary>
        /// <returns>Tabla de usuario</returns>
        public DataTable CargarUsuarios()
        {
            return FactoryTablas.Singleton.ObtenerUsuarios();
        }

        public DataTable CargaUsuariosNoFacade()
        {
            return UsuarioPersistance.CargaUsuariosNoFacade();
        }

        /// <summary>
        /// Metodo que valida si el usuario del AD esta migrado a las tablas del sistema
        /// </summary>
        /// <param name="psGuid"></param>
        /// <returns></returns>
        public bool ExisteUsuarioSistema(string psGuid)
        {
            CargarUsuarios();
            return FactoryTablas.Singleton.ObtenerDatosGrillaQueryBool("Usuario", " Guid = '" + psGuid + "'");
        }

        public string ObtenerNombreUsuario(int piIdUsuario)
        {
            Usuario mUsuario = new Usuario(FactoryTablas.Singleton.ObtenerDatosGrillaQueryRow("Usuario", " IdUsuario = '" + piIdUsuario.ToString() + "'"));
            string sReturn = mUsuario.Nombres + " " + mUsuario.Apellidos;
            mUsuario = null;
            return sReturn;
        }

        public void AgregarUsuarioPorGuid(string psValue)
        {
            ADUserDetail mUser = ActiveDirectoryHelper.Instancia.GetUserByGuid(psValue);
            Usuario mUsuario = new Usuario(psValue);
            Usuario mUsuarioConectado = new Usuario(psValue);
            mUsuario.Apellidos = mUser.LastName;
            mUsuario.Nombres = mUser.FirstName;
            mUsuario.GUID = psValue;
            mUsuario.LoginName = mUser.LoginName;
            mUsuario.Modificar();
            mUser = null;
            FactoryTablas.Singleton.LimpiarUsuarios();
        }

        public ADUserDetail CargarUsuarioGuidAD(string psValue)
        {
            return ActiveDirectoryHelper.Instancia.GetUserByGuid(psValue);
        }

        public void EliminarUsuarioPorGuid(string psGuid)
        {
            Usuario mUsuario = new Usuario(psGuid);
            mUsuario.Eliminar();
            FactoryTablas.Singleton.LimpiarUsuarios();
        }

        public void EliminarUsuarioPorId(int piIDUsuario)
        {
            Usuario mUsuario = new Usuario(piIDUsuario);
            mUsuario.Eliminar();
            FactoryTablas.Singleton.LimpiarUsuarios();
        }

        public void IniciarSesion(string psGuid, int lIDSistema, string sIP, double pdTimeOutSession, ADUserDetail pmADUserDetail)
        {
            AgregarUsuario(psGuid, ObtenerUsuarioPorGuid(psGuid));
            Session mSession = GetSession(psGuid);
            mSession.IP = sIP;
            mSession.Usuario.ADUserDetail = pmADUserDetail;
            mSession.HoraInicio = DateTime.Now;
            mSession.FechaConexion = DateTime.Now;
            mSession.HoraTermino = DateTime.Now.AddMinutes(pdTimeOutSession);
            mSession.IDSistema = lIDSistema;
            mSession.Modificar();
            AgregarUsuario(psGuid, mSession);
        }

        public void AgregarUsuario(string psGuid, Session pmSession)
        {
            if (!ExisteSession(psGuid))
                mListadoSession.Add(psGuid, pmSession);
            else
                mListadoSession[psGuid] = pmSession;
        }

        public void EliminarSessionUsuario(int piIdUsuario)
        {
            foreach (KeyValuePair<string, Session> mListado in mListadoSession)
            {
                if (mListado.Value.Usuario.IdUsuario == piIdUsuario)
                {
                    EliminarSession(mListado.Key);
                    break;
                }
            }
        }

        private void EliminarSession(string psGuid)
        {
            mListadoSession.Remove(psGuid);
        }

        private bool ExisteSession(string psGuid)
        {
            return mListadoSession.ContainsKey(psGuid);
        }

        public bool ValidarPermiso(Usuario pmUsuario, long plIDPermiso, int piIdSistema)
        {
            foreach (Perfil mPerfil in pmUsuario.Perfiles.Values)
            {
                if (mPerfil.IdSistema == piIdSistema)
                {
                    if (mPerfil.Permisos.Contains<int>(Convert.ToInt32(ePermisos.God)))
                        return true;
                    if (mPerfil.Permisos.Contains<int>(Convert.ToInt32(plIDPermiso)))
                        return true;
                }
            }
            return false;
        }

        public bool ValidarPermiso(Usuario pmUsuario, long plIDPermiso)
        {
            foreach (Perfil mPerfil in pmUsuario.Perfiles.Values)
            {
                if (mPerfil.Permisos.Contains<int>(Convert.ToInt32(ePermisos.God)))
                    return true;
                if (mPerfil.Permisos.Contains<int>(Convert.ToInt32(plIDPermiso)))
                    return true;
            }
            return false;
        }

        internal Session GetSession(string psGuid)
        {
            return mListadoSession[psGuid];
        }

        internal Session ObtenerUsuarioPorGuid(string psGuid)
        {
            FactoryTablas.Singleton.ObtenerUsuarios();
            Usuario mUsuario = new Usuario(FactoryTablas.Singleton.ObtenerDatosGrillaQuery("Usuario", " Guid = '" + psGuid + "'", true, true, true)[0]);
            Session mSession = new Session(psGuid);
            mSession.IDUsuario = mUsuario.IdUsuario;
            mSession.Usuario = mUsuario;
            mUsuario = null;
            return mSession;
        }

        public void CerrarSession(string psGuid, double pdTimeOutSession)
        {
            Session mSession = GetSession(psGuid);
            mSession.HoraTermino = DateTime.Now;
            mSession.Modificar();
            EliminarSession(psGuid);
        }

        public void ActualizarSession(string psGuid, double pdTimeOutSession)
        {
            Session mSession = GetSession(psGuid);
            mSession.HoraTermino = DateTime.Now.AddMinutes(pdTimeOutSession);
            mSession.Modificar();
            AgregarUsuario(psGuid, mSession);
        }

        public Session ObtenerSesion(string psGuid, int piIDSistema, string sIP, double pdTimeOutSession, ADUserDetail pmDUserDetail)
        {
            if (!ExisteSession(psGuid))
                IniciarSesion(psGuid, piIDSistema, sIP, pdTimeOutSession, pmDUserDetail);
            return GetSession(psGuid);
        }

        public DataTable ListarPaginasxIdUsuarioIdMenu(string psGuid, int piIdMenu)
        {
            return ObtenerPaginas(GetSession(psGuid).Usuario, piIdMenu);
        }

        public DataTable ObtenerPaginas(Usuario pmUsuario, int piIdMenu)
        {
            if (pmUsuario.PaginaUsuario.ContainsKey(piIdMenu))
                return pmUsuario.PaginaUsuario[piIdMenu];
            else
                return new DataTable();
        }

        public void DesconectarUsuario(string psUserName)
        {
            if (ListadoUsuariosConectados.ContainsKey(psUserName))
            {
                if (mListadoSession.ContainsKey(ListadoUsuariosConectados[psUserName].Guid))
                    mListadoSession.Remove(ListadoUsuariosConectados[psUserName].Guid);
                if (mListadoSession.ContainsKey(psUserName))
                    mListadoSession.Remove(psUserName);
                ListadoUsuariosConectados.Remove(psUserName);
            }
        }
        
        /// <summary>
        /// Metodo que obtiene el objeto usuario desde el Factory
        /// </summary>
        /// <param name="piIdUsuario">Id del usuario a buscar</param>
        /// <returns></returns>
        public Usuario ObtenerUsuario(int piIdUsuario)
        {
            return new Usuario(FactoryTablas.Singleton.ObtenerDatosGrillaQueryRow("Usuario", " IdUsuario = '" + piIdUsuario.ToString() + "'"));
        }

        /// <summary>
        /// Controlador que permite Listar Informacion del usuario
        /// </summary>
        /// <param name="sNombre">Nombre </param>
        /// <param name="sApellido">Apellido</param>
        /// <returns></returns>
        public DataTable CargarUsuariosXNombre(string sNombre, string sApellido)
        {
            return UsuarioPersistance.CargarUsuariosXNombre(sNombre, sApellido);
        }

        /// <summary>
        /// Controlador que permite Actualizar el Tema telerik asociado al usuario conectado
        /// </summary>
        /// <param name="piIdUsuario">IdUsuario Conectado</param>
        /// <param name="psSkin">Skin Telerik</param>
        public void ActualizarTemaUsuario(int piIdUsuario, string psSkin)
        {
            Usuario obj = new Usuario(piIdUsuario);
            obj.Skin = psSkin;
            obj.Modificar();
        }

        public Usuario ObtenerObjeto_Usuario(int piIdUsuario)
        {
            Usuario obj = new Usuario(piIdUsuario);
            return obj;
        }

        /// <summary>
        /// Controlador que permite listar los usuarios asignados a la secretaria conectada
        /// </summary>
        /// <param name="piIdUsuario">IdUsuario</param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerAbogadosAsociadosXIdUsuario(int piIdUsuario)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario", piIdUsuario);

            return UsuarioPersistance.ObtenerAbogadosAsociadosXIdUsuario(mParam);
        }

        public int ObtenerPerfilXUsuarioSistema(int IdUsuario, int pIdSistema)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario", IdUsuario);
            mParam.Agregar("@IdSistema", pIdSistema);

            return Convert.ToInt32(UsuarioPersistance.ObtenerPerfilXUsuarioSistema(mParam));
        }
        /// <summary>
        /// Controlador que permite grabar perfil a usuario o actualizarlo
        /// </summary>
        /// <param name="IdUsuario">IdUsuario</param>
        /// <param name="iPerfil">IdPerfil</param>

        public int AsignarPerfilXUsuarioSistema(int IdUsuario, int iPerfil, int iSistema)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario", IdUsuario);
            mParam.Agregar("@IdPerfil", iPerfil);
            mParam.Agregar("@IdSistema", iSistema);

            return Convert.ToInt32(UsuarioPersistance.AsignarPerfilXUsuarioSistema(mParam));

        }

        /// <summary>
        /// Controlador que permite buscar el idusuario por email ingresado, esto se ocupa en TS
        /// </summary>
        /// <param name="sMailAbogado">Email</param>
        /// <returns>entero con idusuario</returns>
        public int ObtenerIdUsuarioXEmail(string sMailAbogado)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@Email", sMailAbogado);

            return UsuarioPersistance.ObtenerIdUsuarioXEmail(mParam);
        }

        /// <summary>
        /// Controlador que permite listar los usuarios asignados a la secretaria conectada
        /// </summary>
        /// <param name="piIdUsuario">IdUsuario</param>
        /// <returns>DataTable</returns>
        public DataTable ObtenerUsuariosPerfilConsulta(int piIdUsuario)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario", piIdUsuario);

            return UsuarioPersistance.ObtenerUsuariosPerfilConsulta(mParam);
        }

        public void LimpiarUsuarios(long lSessionIdUsuario, long lIdUsuario)
        {
            try
            {
                FactoryTablas.Singleton.LimpiarUsuarios();
                if (lSessionIdUsuario != lIdUsuario)
                {
                    Usuario oUsuario = new Usuario(Convert.ToInt32(lIdUsuario));
                    DesconectarUsuario(oUsuario.LoginName);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Controlador que busca usuarios por nombre
        /// </summary>
        /// <param name="sTexto">Texto</param>
        /// <returns>DataTable</returns>
        public DataTable CargaUsuariosNoFacadeParaBusqueda(string sTexto)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@Texto", sTexto);

            return UsuarioPersistance.CargaUsuariosNoFacadeParaBusqueda(mParam);
        }

        public DataTable ObtenerMensajeriaXIdUsuario(int IdUsuario, int pIdsistema)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario", IdUsuario);
            mParam.Agregar("@IdSistema", pIdsistema);

            return UsuarioPersistance.ObtenerMensajeriaXIdUsuario(mParam);
        }

        /// <summary>
        /// Controlador que permite 
        /// </summary>
        /// <param name="iIdUsuario"></param>
        /// <param name="pIdSistema"></param>
        public void GrabaTablaNotificacionUsuario(int iIdUsuario, int pIdSistema, int pIdMensaje)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdUsuario", iIdUsuario);
            mParam.Agregar("@IdMensaje", pIdMensaje);

            UsuarioPersistance.GrabaTablaNotificacionUsuario(mParam);
        }

        public bool VerificaArchivomensaje(int pId)
        {
            ADM_Mensajeria obj = new ADM_Mensajeria(pId);
            byte[] salida = obj.Archivo;
            obj = null;
            return (salida == null) ? false : true;

        }

        /// <summary>
        /// Controlador que permite obtener el listado de usuarios del sistema
        /// </summary>
        /// <param name="pIdsistema">IdSistema</param>
        /// <returns>dataTable con listado de Usuarios</returns>
        public DataTable ObtenerUsuariosXSistema(int pIdsistema)
        {
            ParametrosDA mParam = new ParametrosDA();
            mParam.Agregar("@IdSistema", pIdsistema);

            return UsuarioPersistance.ObtenerUsuariosXSistema(mParam);
        }

        /// <summary>
        /// Procedimiento que permite obtener el listado de usuarios que existan en sistema
        /// </summary>
        /// <param name="piIdSistema">Id Sistema int</param>
        /// <returns>listado con usuarios</returns>
        public DataTable CargaUsuariosNoFacadeXSistema(int piIdSistema)
        {
            var mParam = new ParametrosDA();
            mParam.Agregar("@IdSistema", piIdSistema);

            return UsuarioPersistance.CargaUsuariosNoFacadeXIdSistema(mParam);
        }
    }
}
