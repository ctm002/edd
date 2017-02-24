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
    public class Permiso : IBase
    {
        #region[Contructor]
        public Permiso()
        {
            Clean();
            CargarTabla();
        }

        public Permiso(int psIdPermiso)
        {
            Clean();
            CargarDatos(PermisoPersistence.CargarDatos(psIdPermiso));
        }

        #endregion
        #region[public Interfaz]
        private void CargarTabla()
        {
            sNombreTabla = "Editar Permiso";
            iAncho = 500;
            iAlto = 500;
            iNumeroPaginas = 25;
            mTipoFiltro = eTipoFiltro.Simple;

            mAccionesPersonalizadas = new Dictionary<string, string>();
            //mAccionesPersonalizadas.Add("Consulta WeekMark", "http://www.weekmark.com|btnir|modal|");

            sPrimaryKey = new string[] { "IdPermiso" };

            mForeignKey = new Dictionary<string, string>();
            mForeignKey.Add("IdSistema", "ADM_Sistema_Listar");
            mForeignKey.Add("IdTipoPermiso", "ADM_Tipo_Permiso_Listar");

            mAnchoColumnas = new Dictionary<string, int>();
            mAnchoColumnas.Add("IdPermiso", 100);
            mAnchoColumnas.Add("Descripcion", 100);
            mAnchoColumnas.Add("IdSistema", 100);
            mAnchoColumnas.Add("IdTipoPermiso", 100);
            mAnchoColumnas.Add("Glosa", 200);

            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasNombre.Add("IdPermiso", "IdPermiso");
            mListadoColumnasNombre.Add("Descripcion", "Descripcion");
            mListadoColumnasNombre.Add("IdSistema", "IdSistema");
            mListadoColumnasNombre.Add("IdTipoPermiso", "IdTipoPermiso");
            mListadoColumnasNombre.Add("Glosa", "Glosa");

            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoColumnasTipo.Add("IdPermiso", eTipoCampoTabla.Int64);
            mListadoColumnasTipo.Add("Descripcion", eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("IdSistema", eTipoCampoTabla.ForeignKey);
            mListadoColumnasTipo.Add("IdTipoPermiso", eTipoCampoTabla.ForeignKey);
            mListadoColumnasTipo.Add("Glosa", eTipoCampoTabla.String);

            mAcciones = new eTipoAccion[3];
            mAcciones[0] = eTipoAccion.Eliminar;
            mAcciones[1] = eTipoAccion.Insertar;
            mAcciones[2] = eTipoAccion.Modificar;

            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            //mListadoEnumeradores.Add("IdArchivoTipo", new eArchivoTipo());
            sProcedimientoGrilla = "ADM_Permiso_Listar";
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
        public Int32 IdPermiso { get; set; } //IdPermiso;
        public String Descripcion { get; set; } //Descripcion;
        public Int32 IdSistema { get; set; } //IdPermiso;
        public String Glosa { get; set; } //Glosa;
        public Int32 IdTipoPermiso { get; set; }

        // public Dictionary<string, Archivo> ListaArchivosAsignados { get; set; }
        #endregion
       
        #region[Metodos]
        private void Clean()
        {
            IdPermiso = 0;
            Descripcion = "";
            IdSistema = 0;
            Glosa = "";
            IdTipoPermiso = 0;
            //ListaArchivosAsignados = new Dictionary<string, Archivo>();
        }
        private void CargarDatos(DataRow mRow)
        {
            if (mRow != null)
            {
                IdPermiso = (mRow["IdPermiso"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdPermiso"]);
                Descripcion = (mRow["Descripcion"] == DBNull.Value) ? "" : Convert.ToString(mRow["Descripcion"]);
                IdSistema = (mRow["IdSistema"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdSistema"]);
                Glosa = (mRow["Glosa"] == DBNull.Value) ? "" : Convert.ToString(mRow["Glosa"]);
                IdTipoPermiso = (mRow["IdTipoPermiso"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdTipoPermiso"]);
            }
        }

        public void Modificar(bool bModificaTodo = true)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPermiso", Convert.ToInt32(IdPermiso));
            mParametros.Agregar("@Descripcion", Convert.ToString(Descripcion));
            mParametros.Agregar("@IdSistema", Convert.ToInt32(IdSistema));
            mParametros.Agregar("@Glosa", Convert.ToString(Glosa));
            mParametros.Agregar("@IdTipoPermiso", Convert.ToInt32(IdTipoPermiso));

            this.IdPermiso = PermisoPersistence.ModificarPermiso(mParametros);

        }

        public void Eliminar()
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdPermiso", Convert.ToInt32(IdPermiso));
            this.IdPermiso = PermisoPersistence.EliminarPermiso(mParametros);
        }


        #endregion

    }
}
