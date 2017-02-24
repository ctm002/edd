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
    public class Menu : IBase
    {
        #region[Contructor]
        public Menu()
        {
            Clean();
            CargarTabla();
        }

        public Menu(int psIdMenu)
        {
            Clean();
            CargarDatos(MenuPersistence.CargarDatos(psIdMenu));
        }

        #endregion
        #region[public Interfaz]
        private void CargarTabla()
        {
            sNombreTabla = "Editar Menu";
            iAncho = 500;
            iAlto = 500;
            iNumeroPaginas = 5;
            mTipoFiltro = eTipoFiltro.Simple;

            mAccionesPersonalizadas = new Dictionary<string, string>();
            //mAccionesPersonalizadas.Add("Consulta WeekMark", "http://www.weekmark.com|btnir|modal|");

            sPrimaryKey = new string[] { "IdMenu" };

            mForeignKey = new Dictionary<string, string>();
            mForeignKey.Add("IdSistema", "ADM_Sistema_Listar");


            mAnchoColumnas = new Dictionary<string, int>();
            mAnchoColumnas.Add("IdMenu", 100);
            mAnchoColumnas.Add("IdPadre", 100);
            mAnchoColumnas.Add("Nombre", 100);
            mAnchoColumnas.Add("Descripcion", 100);
            mAnchoColumnas.Add("Url", 100);
            mAnchoColumnas.Add("IdSistema", 100);
            mAnchoColumnas.Add("Posicion", 100);


            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasNombre.Add("IdMenu","IdMenu");
            mListadoColumnasNombre.Add("IdPadre","IdPadre");
            mListadoColumnasNombre.Add("Nombre","Nombre");
            mListadoColumnasNombre.Add("Descripcion","Descripcion");
            mListadoColumnasNombre.Add("Url","Url");
            mListadoColumnasNombre.Add("IdSistema","IdSistema");
            mListadoColumnasNombre.Add("Posicion", "Posicion");
            

            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoColumnasTipo.Add("IdMenu",eTipoCampoTabla.Int);
            mListadoColumnasTipo.Add("IdPadre",eTipoCampoTabla.Int);
            mListadoColumnasTipo.Add("Nombre",eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("Descripcion",eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("Url",eTipoCampoTabla.String);
            mListadoColumnasTipo.Add("IdSistema",eTipoCampoTabla.ForeignKey);
            mListadoColumnasTipo.Add("Posicion", eTipoCampoTabla.Int);



            mAcciones = new eTipoAccion[3];
            mAcciones[0] = eTipoAccion.Eliminar;
            mAcciones[1] = eTipoAccion.Insertar;
            mAcciones[2] = eTipoAccion.Modificar;

            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            //mListadoEnumeradores.Add("IdArchivoTipo", new eArchivoTipo());
            sProcedimientoGrilla = "ADM_Menu_Listar";
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
        public Int32 IdMenu {get;set;} //IdMenu;
        public Int32 IdPadre {get;set;} //IdPadre;
        public String Nombre {get;set;} //Nombre;
        public String Descripcion {get;set;} //Descripcion;
        public String Url {get;set;} //Url;
        public Int32 IdSistema {get;set;} //IdSistema;
        public Int32 Posicion { get; set; }


       // public Dictionary<string, Archivo> ListaArchivosAsignados { get; set; }
        #endregion
        #region[Metodos]
        private void Clean()
        {
            IdMenu = 0;
            IdPadre = 0;
            Nombre = "";
            Descripcion = "";
            Url = "";
            IdSistema = 0;
            Posicion = 0;

            //ListaArchivosAsignados = new Dictionary<string, Archivo>();
        }
        private void CargarDatos(DataRow mRow)
        {
            if (mRow != null)
            {
                IdMenu = (mRow["IdMenu"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdMenu"]);
                IdPadre = (mRow["IdPadre"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdPadre"]);
                Nombre = (mRow["Nombre"] == DBNull.Value) ? "" : Convert.ToString(mRow["Nombre"]);
                Descripcion = (mRow["Descripcion"] == DBNull.Value) ? "" : Convert.ToString(mRow["Descripcion"]);
                Url = (mRow["Url"] == DBNull.Value) ? "" : Convert.ToString(mRow["Url"]);
                IdSistema = (mRow["IdSistema"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["IdSistema"]);
                Posicion = (mRow["Posicion"] == DBNull.Value) ? 0 : Convert.ToInt32(mRow["Posicion"]);
            }
        }

        public void Modificar(bool bModificaTodo = true)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdMenu",Convert.ToInt32(IdMenu));
            mParametros.Agregar("@IdPadre",Convert.ToInt32(IdPadre));
            mParametros.Agregar("@Nombre",Convert.ToString(Nombre));
            mParametros.Agregar("@Descripcion",Convert.ToString(Descripcion));
            mParametros.Agregar("@Url",Convert.ToString(Url));
            mParametros.Agregar("@IdSistema",Convert.ToInt32(IdSistema));
            mParametros.Agregar("@Posicion", Convert.ToInt32(Posicion));

            this.IdMenu = MenuPersistence.ModificarMenu(mParametros);

        }

        public void Eliminar()
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar("@IdMenu",Convert.ToInt32(IdMenu));
            this.IdMenu = MenuPersistence.EliminarMenu(mParametros);
        }


        #endregion
    }
}
