using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using InDataAccess.Parametros;
using Portal.Interface;
using Portal.Domain.Enum;
using Portal.PersistenceHelper;
namespace Portal.Domain.Object
{
    [Serializable]
    public class Usuario : IBase
    {
        #region[Contructor]
        public Usuario()
        {
            Clean();
            CargarTabla();
        }

        public Usuario(int psIdUsuario)
        {
            Clean();
            CargarDatos(UsuarioPersistance.CargarDatos(psIdUsuario));
        }
        public Usuario(DataRow pmRow)
        {
            Clean();
            CargarDatos(pmRow);
        }
        public Usuario(string psGuid)
        {
            Clean();
            CargarDatos(UsuarioPersistance.CargarDatos(psGuid));
        }
        #endregion
        #region[public Interfaz]
        private void CargarTabla()
        {
            sNombreTabla = "Editar Usuario";
            iAncho = 800;
            iAlto = 600;
            iNumeroPaginas = 20;
            mTipoFiltro = eTipoFiltro.Simple;

            mAccionesPersonalizadas = new Dictionary<string, string>();
            //mAccionesPersonalizadas.Add("Consulta WeekMark", "http://www.weekmark.com|btnir|modal|");

            sPrimaryKey = new string[] { "IdUsuario" };

            mForeignKey = new Dictionary<string, string>();
            // mForeignKey.Add("IdUsuario", "ADM_Usuario");


            mAnchoColumnas = new Dictionary<string, int>();
            mAnchoColumnas.Add("IdUsuario", 50);
            mAnchoColumnas.Add("GUID", 150);
            mAnchoColumnas.Add("Nombres", 150);
            mAnchoColumnas.Add("Apellidos", 150);
            mAnchoColumnas.Add("LoginName", 300);


            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasNombre.Add("IdUsuario", "IdUsuario");
            mListadoColumnasNombre.Add("GUID", "GUID");
            mListadoColumnasNombre.Add("Nombres", "Nombre");
            mListadoColumnasNombre.Add("Apellidos", "Apellidos");
            mListadoColumnasNombre.Add("LoginName", "LoginName");

            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoColumnasTipo.Add("IdUsuario", eTipoCampoTabla.Int64);
            mListadoColumnasTipo.Add("GUID", eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("Nombres", eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("Apellidos", eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("LoginName", eTipoCampoTabla.String);

            mAcciones = new eTipoAccion[] { eTipoAccion.Modificar };
            //mAcciones[0] = eTipoAccion.Eliminar;
            //mAcciones[1] = eTipoAccion.Insertar;
            //mAcciones[2] = eTipoAccion.Modificar;

            mListadoForeignKeyAlias = new Dictionary<string, string>();
            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            mListadoPrimaryKeyExcepciones = new List<string>();
            //mListadoEnumeradores.Add("IdArchivoTipo", new eArchivoTipo());
            sProcedimientoGrilla = "ADM_Usuario_Listar";
            mMostrarPordefecto = false;
        }
        private int iIdUsuarioModifica; int IBase.IdUsuarioModifica { get { return iIdUsuarioModifica; } set { iIdUsuarioModifica = value; } }
        private string sNombreModifica; string IBase.NombreModifica { get { return sNombreModifica; } set { sNombreModifica = value; } }

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
        #endregion
        #region[Propiedades]
        public Int32 IdUsuario { get; set; } //IdUsuario;
        public String GUID { get; set; } //GUID;
        public String Nombres { get; set; } //Nombre;
        public String Apellidos { get; set; } //Apellidos;
        public String LoginName { get; set; } //Apellidos;
        public Dictionary<int, Perfil> Perfiles { get; set; }
        public ADUserDetail ADUserDetail { get; set; }
        public Dictionary<int, DataTable> MenuUsuario { get; set; }
        public Dictionary<int, DataTable> PaginaUsuario { get; set; }
        public String Skin { get; set; }
        public int Activo { get; set; }
        // public Dictionary<string, Archivo> ListaArchivosAsignados { get; set; }
        #endregion
        #region[Metodos]
        private void Clean()
        {
            IdUsuario = 0;
            GUID = "";
            Nombres = "";
            Apellidos = "";
            LoginName = "";
            Perfiles = new Dictionary<int, Perfil>();
            MenuUsuario = new Dictionary<int, DataTable>();
            PaginaUsuario = new Dictionary<int, DataTable>();
            ADUserDetail = new ADUserDetail();
            Skin = "";
            Activo = 0;
        }
        private void CargarDatos(DataRow mRow)
        {
            if (mRow != null)
            {
                IdUsuario = (mRow["IdUsuario"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdUsuario"]);
                GUID = (mRow["GUID"] == DBNull.Value) ? "" : Convert.ToString(mRow["GUID"]);
                Nombres = (mRow["Nombres"] == DBNull.Value) ? "" : Convert.ToString(mRow["Nombres"]);
                Apellidos = (mRow["Apellidos"] == DBNull.Value) ? "" : Convert.ToString(mRow["Apellidos"]);
                LoginName = (mRow["LoginName"] == DBNull.Value) ? "" : Convert.ToString(mRow["LoginName"]);
                Skin = (mRow["Skin"] == DBNull.Value) ? "" : Convert.ToString(mRow["Skin"]);
                Activo = (mRow["Activo"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["Activo"]);
                CargarPerfiles();
                CargarMenus();
            }
        }

        private void CargarMenus()
        {
            foreach (Perfil mPerfil in Perfiles.Values)
            {
                if (!this.MenuUsuario.ContainsKey(mPerfil.IdSistema))
                {
                    DataTable mTable;
                    if (mPerfil.Permisos.Contains<int>(Convert.ToInt32(ePermisos.God)))
                        mTable = MenuPersistence.CargarMenuXIdUsuarioSistema(this.IdUsuario, mPerfil.IdSistema, mPerfil.IdPerfil, ePermisos.God);
                    else if (mPerfil.Descripcion.Trim() == "Emisor")
                        mTable = MenuPersistence.CargarMenuXSistemaPerfil(mPerfil.IdSistema, mPerfil.IdPerfil);
                    else
                        mTable = MenuPersistence.CargarMenuXIdUsuarioSistema(this.IdUsuario, mPerfil.IdSistema, mPerfil.IdPerfil);

                    this.MenuUsuario.Add(mPerfil.IdSistema, mTable);
                    foreach (DataRow mRow in mTable.Rows)
                        CargarPaginas(mPerfil.IdPerfil, Convert.ToInt32(mRow["IdMenu"]));
                }
            }

        }
        private void CargarPaginas(int piIdPerfil, int piIdMenu)
        {
            if (!PaginaUsuario.ContainsKey(piIdMenu))
                if (Perfiles[piIdPerfil].Permisos.Contains<int>(Convert.ToInt32(ePermisos.God)))
                    PaginaUsuario.Add(piIdMenu, PaginaPersistence.CargarPaginaXIdUsuarioPerfilTodo(this.IdUsuario, piIdPerfil, piIdMenu));
                else if (Perfiles[piIdPerfil].Descripcion == "Emisor")
                    PaginaUsuario.Add(piIdMenu, PaginaPersistence.CargarPaginaXPerfilSistema(piIdPerfil, piIdMenu));
                else
                    PaginaUsuario.Add(piIdMenu, PaginaPersistence.CargarPaginaXIdUsuarioPerfil(this.IdUsuario, piIdPerfil, piIdMenu));
        }

        private void CargarPerfiles()
        {
            foreach (DataRow mRow in PerfilPersistance.CargarPorIdUsuario(this.IdUsuario).Rows)
            {
                if (!Perfiles.ContainsKey(Convert.ToInt32(mRow["IdPerfil"])))
                    Perfiles.Add(Convert.ToInt32(mRow["IdPerfil"]), new Perfil(Convert.ToInt32(mRow["IdPerfil"])));
            }
        }

        public void Modificar(bool bModificaTodo = true)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", Convert.ToInt32(IdUsuario));
            mParametros.Agregar("@GUID", Convert.ToString(GUID));
            mParametros.Agregar("@Nombres", Convert.ToString(Nombres));
            mParametros.Agregar("@Apellidos", Convert.ToString(Apellidos));
            mParametros.Agregar("@LoginName", Convert.ToString(LoginName));
            mParametros.Agregar("@Activo", Convert.ToInt32(Activo));
            mParametros.Agregar("@Skin", Convert.ToString(Skin));
            this.IdUsuario = UsuarioPersistance.ModificarUsuario(mParametros);
        }

        public void Eliminar()
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdUsuario", Convert.ToInt32(IdUsuario));
            this.IdUsuario = UsuarioPersistance.EliminarUsuario(mParametros);
        }

        public string ObtenerPaginaPerfil(int iIdSistema)
        {
            foreach (KeyValuePair<int, Perfil> mListado in Perfiles)
            {
                if (mListado.Value.IdSistema == iIdSistema)
                    return mListado.Value.PaginaDefecto.Url;
            }
            return "/default.aspx";
        }
        #endregion

    }
}
