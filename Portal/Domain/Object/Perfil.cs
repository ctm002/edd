using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InDataAccess.Parametros;
using Portal.Interface;
using Portal.Domain.Enum;
using Portal.PersistenceHelper;
namespace Portal.Domain.Object
{
    [Serializable]
    public class Perfil : IBase
    {
        #region[Contructor]
        public Perfil()
        {
            Clean();
            CargarTabla();
        }

        public Perfil(int psIdPerfil)
        {
            Clean();
            CargarDatos(PerfilPersistance.CargarDatos(psIdPerfil));
        }

        #endregion
        #region[public Interfaz]
        private void CargarTabla()
        {
            sNombreTabla = "Editar Perfil";
            iAncho = 500;
            iAlto = 500;
            iNumeroPaginas = 5;
            mTipoFiltro = eTipoFiltro.Simple;

            mAccionesPersonalizadas = new Dictionary<string, string>();
            //mAccionesPersonalizadas.Add("Consulta WeekMark", "http://www.weekmark.com|btnir|modal|");

            sPrimaryKey = new string[] { "IdPerfil" };

            mForeignKey = new Dictionary<string, string>();
            mForeignKey.Add("IdSistema", "ADM_Sistema_Listar");
            mForeignKey.Add("IdPaginaDefecto", "ADM_Pagina_Listar");


            mAnchoColumnas = new Dictionary<string, int>();
            mAnchoColumnas.Add("IdPerfil", 100);
            mAnchoColumnas.Add("Descripcion", 100);
            mAnchoColumnas.Add("IdSistema", 100);
            mAnchoColumnas.Add("IdPaginaDefecto", 100);
            


            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasNombre.Add("IdPerfil", "IdPerfil");
            mListadoColumnasNombre.Add("Descripcion", "Descripcion");
            mListadoColumnasNombre.Add("IdSistema", "Sistema");
            mListadoColumnasNombre.Add("IdPaginaDefecto", "Pagina Defecto");



            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoColumnasTipo.Add("IdPerfil", eTipoCampoTabla.Int32);
            mListadoColumnasTipo.Add("Descripcion", eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("IdSistema", eTipoCampoTabla.ForeignKey);
            mListadoColumnasTipo.Add("IdPaginaDefecto", eTipoCampoTabla.ForeignKey);


            mListadoForeignKeyAlias = new Dictionary<string, string>();
            mListadoForeignKeyAlias.Add("IdPaginaDefecto", "IdPagina");

            mAcciones = new eTipoAccion[3];
            mAcciones[0] = eTipoAccion.Eliminar;
            mAcciones[1] = eTipoAccion.Insertar;
            mAcciones[2] = eTipoAccion.Modificar;

            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            //mListadoEnumeradores.Add("IdArchivoTipo", new eArchivoTipo());
            sProcedimientoGrilla = "ADM_Perfil_Listar";
            mMostrarPordefecto = false;
        }
        private int iIdUsuarioModifica; int IBase.IdUsuarioModifica { get { return iIdUsuarioModifica; } set { iIdUsuarioModifica = value; } } private string sNombreModifica; string IBase.NombreModifica { get { return sNombreModifica; } set { sNombreModifica = value; } }
     
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
        Dictionary<string,string> IBase.ListadoForeignKeyAlias
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
        public Int32 IdPerfil { get; set; } //IdPerfil;
        public String Descripcion { get; set; } //Descripcion;
        public Int32 IdSistema { get; set; } //IdSistema;
        public Int32 IdPaginaDefecto { get; set; } //IdSistema;
        public List<int> Permisos { get; set; }
        public Pagina PaginaDefecto { get; set; }
        #endregion
        #region[Metodos]
        private void Clean()
        {
            IdPerfil = 0;
            Descripcion = "";
            IdSistema = 0;
            Permisos = new List<int>();
        }
        private void CargarDatos(DataRow mRow)
        {
            if (mRow != null)
            {
                IdPerfil = (mRow["IdPerfil"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdPerfil"]);
                Descripcion = (mRow["Descripcion"] == DBNull.Value) ? "" : Convert.ToString(mRow["Descripcion"]);
                IdSistema = (mRow["IdSistema"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdSistema"]);
                IdPaginaDefecto = (mRow["IdPaginaDefecto"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdPaginaDefecto"]);
                CargarPermisos();
                CargarPaginaDefecto();
            }
        }

        private void CargarPaginaDefecto()
        {
            PaginaDefecto = new Pagina(IdPaginaDefecto);
        }
        private void CargarPermisos()
        {
            foreach (DataRow mRow in PermisoPersistence.ObtenerPermisosXIDPerfil(this.IdPerfil).Rows)
            {
                if (!Permisos.Contains<int>(Convert.ToInt32(mRow["IdPermiso"])))
                    Permisos.Add(Convert.ToInt32(mRow["IdPermiso"]));
            }
        }

        public void Modificar(bool bModificaTodo = true)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfil", Convert.ToInt32(IdPerfil));
            mParametros.Agregar("@Descripcion", Convert.ToString(Descripcion));
            mParametros.Agregar("@IdSistema", Convert.ToInt32(IdSistema));
            mParametros.Agregar("@IdPagina", Convert.ToInt32(IdPaginaDefecto));
            this.IdPerfil = PerfilPersistance.ModificarPerfil(mParametros);
        }

        public void Eliminar()
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPerfil", Convert.ToInt32(IdPerfil));
            this.IdPerfil = PerfilPersistance.EliminarPerfil(mParametros);
        }


        #endregion
    }
}
