using System;
using Portal.PersistenceHelper;
using System.Data;

namespace Portal.Domain.Object
{
    public class Session
    {
        #region[Constructor]
        public Session()
        {
            Clean();
        }
        public Session(long lIDSession)
        {
            Clean();
            CargarSession(PortalPersistenceHelper.ObtenerSessionPorID(lIDSession));
        }
        public Session(string sGuid)
        {
            Clean();
            this.Guid = sGuid;
        }
        public Session(string sGuid, int piIDSistema, string sIP, int plIdUsuario, double pdTimeOutSession)
        {
            Clean();
            CargarDatosSession(sGuid, piIDSistema, sIP, plIdUsuario, pdTimeOutSession);
        }
        public Session(string sGuid, int piIDSistema, string sIP, bool bCargaVacia, int plIdUsuario, double pdTimeOutSession)
        {
            Clean();
            CargarDatosSessionVacia(sGuid, piIDSistema, sIP, pdTimeOutSession);
        }
        #endregion
        #region[Propiedades]
        private Usuario mUsuario;
        public Usuario Usuario
        {
            get
            {
                if (mUsuario == null)
                {
                    mUsuario = new Usuario(IDUsuario);
                }
                return mUsuario;
            }
            set { }
        }

        private Usuario mUsuarioConectado;
        public Usuario UsuarioConectado
        {
            get
            {
                if (mUsuarioConectado == null)
                {
                    mUsuarioConectado = new Usuario(IDUsuario);
                }
                return mUsuarioConectado;
            }
            set { mUsuarioConectado = value; }
        }

        public int IDUsuario { get; set; }
        public int IDSistema { get; set; }
        public long IDSession { get; set; }
        public DateTime FechaConexion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public string Guid { get; set; }
        public string IP { get; set; }
        #endregion
        #region[Metodos]
        private void Clean()
        {
            IDSession = 0;
            IDSistema = 0;
            IDUsuario = 0;
            FechaConexion = DateTime.MinValue;
            HoraInicio = DateTime.MinValue;
            HoraTermino = DateTime.MinValue;
            Guid = "";
            IP = "";
        }
        private void CargarSession(DataRow mRow)
        {
            if (mRow != null)
            {
                if (mRow["IDSession"] != DBNull.Value) IDSession = Convert.ToInt64(mRow["IDSession"]);
                if (mRow["Fecha"] != DBNull.Value) FechaConexion = Convert.ToDateTime(mRow["Fecha"]);
                if (mRow["HoraInicio"] != DBNull.Value) HoraInicio = Convert.ToDateTime(mRow["HoraInicio"]);
                if (mRow["HoraTermino"] != DBNull.Value) HoraTermino = Convert.ToDateTime(mRow["HoraTermino"]);
                if (mRow["IDSistema"] != DBNull.Value) IDSistema = Convert.ToInt32(mRow["IDSistema"]);
                if (mRow["IP"] != DBNull.Value) IP = Convert.ToString(mRow["IP"]);
                if (mRow["Guid"] != DBNull.Value) Guid = Convert.ToString(mRow["Guidx"]);
                if (mRow["IDUsuario"] != DBNull.Value) IDUsuario = Convert.ToInt32(mRow["IDUsuario"]);
            }
        }
        public void Modificar(bool bModificaTodo = true)
        {
            InDataAccess.Parametros.ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
            mParametros.Agregar("@IDSession", IDSession);
            mParametros.Agregar("@IDSistema", IDSistema);
            mParametros.Agregar("@IDUsuario", IDUsuario);
            mParametros.Agregar("@Guid", Guid);
            mParametros.Agregar("@Fecha", FechaConexion);
            mParametros.Agregar("@HoraInicio", HoraInicio);
            mParametros.Agregar("@HoraTermino", HoraTermino);
            mParametros.Agregar("@IP", IP);
            IDSession = PortalPersistenceHelper.ModificarSession(mParametros);
        }
        private void CargarDatosSession(string sGuid, int plIDSistema, string sIP, int piIdUsuario, double pdTimeOutSession)
        {
            this.Guid = sGuid;
            this.IDSistema = plIDSistema;
            this.FechaConexion = DateTime.Now;
            this.HoraInicio = DateTime.Now;
            this.HoraTermino = DateTime.Now.AddMinutes(pdTimeOutSession);//Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["TimeOutSession"]));
            this.IP = sIP;
            this.IDUsuario = piIdUsuario;
            Modificar();
        }
        private void CargarDatosSessionVacia(string sGuid, int plIDSistema, string sIP, double pdTimeOutSession)
        {
            this.Guid = sGuid;
            this.IDSistema = plIDSistema;
            this.FechaConexion = DateTime.Now;
            this.HoraInicio = DateTime.Now;
            this.HoraTermino = DateTime.Now.AddMinutes(Convert.ToDouble(pdTimeOutSession));//System.Configuration.ConfigurationManager.AppSettings["TimeOutSession"]));
            this.IP = sIP;
        }
        private void AgregarUsuario(Usuario pmUsuario)
        {
            this.Usuario = pmUsuario;
            Modificar();
        }
        public void ActualizarTermino(double pdTimeOutSession)
        {
            this.HoraTermino = DateTime.Now.AddMinutes(pdTimeOutSession);
            Modificar();
        }
        public void CerrarSession()
        {
            this.HoraTermino = DateTime.Now;
            Modificar();
        }
        #endregion

    }
}
