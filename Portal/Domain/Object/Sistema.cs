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
    public class Sistema : IBase
    {
        #region[Contructor]
        public Sistema()
        {
            Clean();
            CargarTabla();
        }

        public Sistema(int psIdSistema)
        {
            Clean();
            CargarDatos(SistemaPersistance.CargarDatos(psIdSistema));
        }

        public Sistema(string psUrl)
        {
            Clean();
            CargarDatos(SistemaPersistance.CargarDatos(psUrl));
        }
        #endregion
        #region[public Interfaz]
        private void CargarTabla()
        {
            sNombreTabla = "Editar Sistema";
            iAncho = 800;
            iAlto = 600;
            iNumeroPaginas = 20;
            mTipoFiltro = eTipoFiltro.Simple;

            mAccionesPersonalizadas = new Dictionary<string, string>();
            mAccionesPersonalizadas.Add("Url_Sistema", "/Mantenedor/AliasSistema.aspx|btnir|modal|");

            sPrimaryKey = new string[] { "IdSistema" };

            mForeignKey = new Dictionary<string, string>();
            mForeignKey.Add("IdPagina", "ADM_Pagina_Listar");
            mForeignKey.Add("IdSistemaTipo", "ADM_Sistema_Tipo_Listar");


            mAnchoColumnas = new Dictionary<string, int>();
            mAnchoColumnas.Add("IdSistema", 50);
            mAnchoColumnas.Add("Descripcion", 250);
            mAnchoColumnas.Add("Url", 150);
            mAnchoColumnas.Add("IdPagina", 100);
            mAnchoColumnas.Add("IdSistemaTipo", 50);


            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasNombre.Add("IdSistema", "IdSistema");
            mListadoColumnasNombre.Add("Descripcion", "Descripcion");
            mListadoColumnasNombre.Add("Url", "Url");
            mListadoColumnasNombre.Add("IdPagina", "PaginaDefecto");
            mListadoColumnasNombre.Add("IdSistemaTipo", "TipoSistema");


            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoColumnasTipo.Add("IdSistema", eTipoCampoTabla.Int64);
            mListadoColumnasTipo.Add("Descripcion", eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("Url", eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("IdPagina", eTipoCampoTabla.ForeignKey);
            mListadoColumnasTipo.Add("IdSistemaTipo", eTipoCampoTabla.ForeignKey);

            mAcciones = new eTipoAccion[3];
            mAcciones[0] = eTipoAccion.Eliminar;
            mAcciones[1] = eTipoAccion.Insertar;
            mAcciones[2] = eTipoAccion.Modificar;

            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            //mListadoEnumeradores.Add("IdArchivoTipo", new eArchivoTipo());
            sProcedimientoGrilla = "ADM_Sistema_Listar";
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
        public Int32 IdSistema { get; set; }

        public String Descripcion { get; set; }

        public string Url { get; set; }

        public Int32 IdPagina { get; set; }

        public Pagina PaginaDefecto { get; set; }

        public Int32 IdSistemaTipo { get; set; }
        #endregion
        #region[Metodos]

        private void Clean()
        {
            Descripcion = "";
            IdSistema = 0;
            Url = "";
            IdPagina = 0;
            IdSistemaTipo = 0;
        }

        private void CargarDatos(DataRow mRow)
        {
            if (mRow != null)
            {
                IdSistema = (mRow["IdSistema"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdSistema"]);
                Descripcion = (mRow["Descripcion"] == DBNull.Value) ? "" : Convert.ToString(mRow["Descripcion"]);
                Url = (mRow["Url"] == DBNull.Value) ? "" : Convert.ToString(mRow["Url"]);
                IdPagina = (mRow["IdPagina"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdPagina"]);
                PaginaDefecto = new Pagina(IdPagina);
                IdSistemaTipo = (mRow["IdSistemaTipo"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdSistemaTipo"]);
            }
        }

        public void Modificar(bool bModificaTodo = true)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdSistema", Convert.ToInt32(IdSistema));
            mParametros.Agregar("@Descripcion", Convert.ToString(Descripcion));
            mParametros.Agregar("@Url", Convert.ToString(Url));
            mParametros.Agregar("@IdPagina", IdPagina);
            mParametros.Agregar("@IdSistemaTipo", IdSistemaTipo);

            this.IdSistema = SistemaPersistance.ModificarSistema(mParametros);

        }

        public void Eliminar()
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdSistema", Convert.ToInt32(IdSistema));
            this.IdSistema = SistemaPersistance.EliminarSistema(mParametros);
        }
        
        #endregion
    }
}
