/********************************************
/       Portal Develop 2011
/********************************************
/ Creado Por: Luis Moreno
/ Objetivo  : Objeto encargado de la interaccion
/            Con el UsuarioPerfil
/********************************************
/ Fecha : 03-05-2011
/
*********************************************/

namespace Portal.Domain.Object
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using Portal.PersistenceHelper;
    //using Portal.Domain.Enum;
    using InDataAccess.Parametros;
    using Portal.Interface;
    using Portal.Domain.Enum;
    using System.Configuration;

    [Serializable]
    public class UsuarioPerfil : IBase
    {
        #region[Propiedades]
        public long IdUsuarioPerfil { get; set; }
        public long IdPerfil { get; set; }
        public long IdUsuario { get; set; }
        #endregion

        #region [Constructor]
        public UsuarioPerfil()
        {
            Clean();
            CargarTabla();
        }
        public UsuarioPerfil(Int64 IdUsuarioPerfil)
        {
            Clean();
            CargarUsuarioPerfil(UsuarioPerfilPersistenceHelper.CargarDatosUsuarioPerfil(IdUsuarioPerfil));
        }
        #endregion

        #region[public Interfaz]
        private void CargarTabla()
        {

            sNombreTabla = "Editar UsuarioPerfil";
            iAncho = 700;
            iAlto = 500;
            iNumeroPaginas = 10;
            mTipoFiltro = eTipoFiltro.Simple;
            sPrimaryKey = new string[] { "IdUsuarioPerfil" };
            mForeignKey = new Dictionary<string, string>();
            mAccionesPersonalizadas = new Dictionary<string, string>();
            mAnchoColumnas = new Dictionary<string, int>();
            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoForeignKeyAlias = new Dictionary<string, string>();/*tabla destino, tabla source*/
            mListadoPrimaryKeyExcepciones = new List<string>();

            mAnchoColumnas.Add("IdUsuarioPerfil", 100);
            mListadoColumnasNombre.Add("IdUsuarioPerfil", "IdUsuarioPerfil");
            mListadoColumnasTipo.Add("IdUsuarioPerfil", eTipoCampoTabla.Int64);
            mAnchoColumnas.Add("IdPerfil", 100);
            mListadoColumnasNombre.Add("IdPerfil", "IdPerfil");
            mListadoColumnasTipo.Add("IdPerfil", eTipoCampoTabla.ForeignKey);
            mForeignKey.Add("IdPerfil", "ADM_Perfil_Listar");
            mListadoForeignKeyAlias.Add("IdPerfil", "IdPerfil");
            mAnchoColumnas.Add("IdUsuario", 100);
            mListadoColumnasNombre.Add("IdUsuario", "IdUsuario");
            mListadoColumnasTipo.Add("IdUsuario", eTipoCampoTabla.ForeignKey);
            mForeignKey.Add("IdUsuario", "ADM_Usuario_Listar");
            mListadoForeignKeyAlias.Add("IdUsuario", "IdUsuario");
            mAcciones = new eTipoAccion[3];
            mAcciones[0] = eTipoAccion.Eliminar;
            mAcciones[1] = eTipoAccion.Insertar;
            mAcciones[2] = eTipoAccion.Modificar;
            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            sProcedimientoGrilla = "ADM_Usuario_Perfil_Listar";
            mMostrarPordefecto = false;
        }
        private int _IIdUsuarioModifica;

        public int IdUsuarioModifica {
            get { return _IIdUsuarioModifica; }
            set { _IIdUsuarioModifica = value; }
        }

        private string sNombreModifica;

        string IBase.NombreModifica {
            get { return sNombreModifica; }
            set { sNombreModifica = value; }
        }

        private string sProcedimientoGrilla;
        public string ProcedimientoGrilla
        {
            get { return sProcedimientoGrilla; }
            set { sProcedimientoGrilla = value; }
        }
        private string sNombreTabla;
        string IBase.NombreTabla
        {
            get { return sNombreTabla; }
            set { sNombreTabla = value; }
        }
        private int iAncho;
        int IBase.Ancho
        {
            get { return iAncho; }
            set { iAncho = value; }
        }
        private int iAlto;
        int IBase.Alto
        {
            get { return iAlto; }
            set { iAlto = value; }
        }
        private int iNumeroPaginas;
        int IBase.NumeroPaginas
        {
            get { return iNumeroPaginas; }
            set { iNumeroPaginas = value; }
        }
        private Dictionary<string, string> mListadoForeignKeyAlias;
        Dictionary<string, string> IBase.ListadoForeignKeyAlias
        {
            get { return mListadoForeignKeyAlias; }
            set { mListadoForeignKeyAlias = value; }
        }
        private List<string> mListadoPrimaryKeyExcepciones;
        List<string> IBase.ListadoPrimaryKeyExcepciones
        {
            get { return mListadoPrimaryKeyExcepciones; }
            set { mListadoPrimaryKeyExcepciones = value; }
        }
        private Dictionary<string, eTipoCampoTabla> mListadoColumnasTipo;
        Dictionary<string, eTipoCampoTabla> IBase.ListadoColumnasTipo
        {
            get { return mListadoColumnasTipo; }
            set { mListadoColumnasTipo = value; }
        }
        private Dictionary<string, string> mListadoColumnasNombre;
        Dictionary<string, string> IBase.ListadoColumnasNombre
        {
            get { return mListadoColumnasNombre; }
            set { mListadoColumnasNombre = value; }
        }
        private eTipoFiltro mTipoFiltro;
        eTipoFiltro IBase.TipoFiltro
        {
            get { return mTipoFiltro; }
            set { mTipoFiltro = value; }
        }
        private string sTitulo;
        string IBase.Titulo
        {
            get { return sTitulo; }
            set { sTitulo = value; }
        }
        eTipoAccion[] mAcciones;
        eTipoAccion[] IBase.Acciones
        {
            get { return mAcciones; }
            set { mAcciones = value; }
        }
        private Dictionary<string, string> mAccionesPersonalizadas;
        Dictionary<string, string> IBase.AccionesPersonalizadas
        {
            get { return mAccionesPersonalizadas; }
            set { mAccionesPersonalizadas = value; }
        }
        private string sProcedimientoParentId;
        string IBase.ProcedimientoParentId
        {
            get { return sProcedimientoParentId; }
            set { sProcedimientoParentId = value; }
        }
        private string[] sPrimaryKey;
        string[] IBase.PrimaryKey
        {
            get { return sPrimaryKey; }
            set { sPrimaryKey = value; }
        }
        private Dictionary<string, string> mForeignKey;
        Dictionary<string, string> IBase.ForeignKey
        {
            get { return mForeignKey; }
            set { mForeignKey = value; }
        }
        private Dictionary<string, int> mAnchoColumnas;
        Dictionary<string, int> IBase.AnchoColumnas
        {
            get { return mAnchoColumnas; }
            set { mAnchoColumnas = value; }
        }
        private Dictionary<string, System.Enum> mListadoEnumeradores;
        Dictionary<string, System.Enum> IBase.ListadoEnumeradores
        {
            get { return mListadoEnumeradores; }
            set { mListadoEnumeradores = value; }
        }
        private bool mMostrarPordefecto;
        bool IBase.MostrarPordefecto
        {
            get { return mMostrarPordefecto; }
            set { mMostrarPordefecto = value; }
        }
        #endregion

        #region [Metodos]
        private void Clean()
        {
            IdUsuarioPerfil = 0;
            IdPerfil = 0;
            IdUsuario = 0;
        }
        private void CargarUsuarioPerfil(DataRow mRow)
        {
            if (mRow != null)
            {
                if (mRow["IdUsuarioPerfil"] != DBNull.Value) IdUsuarioPerfil = Convert.ToInt64(mRow["IdUsuarioPerfil"]);
                if (mRow["IdPerfil"] != DBNull.Value) IdPerfil = Convert.ToInt64(mRow["IdPerfil"]);
                if (mRow["IdUsuario"] != DBNull.Value) IdUsuario = Convert.ToInt64(mRow["IdUsuario"]);

            }
        }
        public void Modificar(bool bModificaTodo = true)
        {   //Dictionary<string,long> dModificarDatos = new   Dictionary<string,long>(); //util para obtener llaves introducidas 
            long lRespuesta = 0;
            ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
            mParametros.Agregar("@IdUsuarioPerfil", IdUsuarioPerfil);
            mParametros.Agregar("@IdPerfil", IdPerfil);
            mParametros.Agregar("@IdUsuario", IdUsuario);
            lRespuesta = UsuarioPerfilPersistenceHelper.ModificarUsuarioPerfil(mParametros);
            IdUsuarioPerfil = lRespuesta;
            PortalFacade.Singleton.PerfilController.LimpiarTabla(Convert.ToInt32(IdPerfil));
            PortalFacade.Singleton.UsuarioController.EliminarSessionUsuario(Convert.ToInt32(IdUsuario));
            Usuario mUsuario = new Usuario(Convert.ToInt32(IdUsuario));
            PortalFacade.Singleton.UsuarioController.DesconectarUsuario(ConfigurationManager.AppSettings["LDAPDomain"] + "\\" + mUsuario.LoginName.ToLower());
        }
        public void Eliminar()
        {
            ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
            mParametros.Agregar("@IdUsuarioPerfil", IdUsuarioPerfil);
            UsuarioPerfilPersistenceHelper.EliminarUsuarioPerfil(mParametros);
            PortalFacade.Singleton.PerfilController.LimpiarTabla(Convert.ToInt32(IdPerfil));
            PortalFacade.Singleton.UsuarioController.EliminarSessionUsuario(Convert.ToInt32(IdUsuario));
        }
        #endregion
    }
}