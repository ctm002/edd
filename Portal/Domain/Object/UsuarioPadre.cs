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

    [Serializable]
    public class UsuarioPadre : IBase
    {
        #region[Propiedades]
        public int IdUsuario { get; set; }
        public int IdUsuarioHijo { get; set; }
        #endregion
        #region [Constructor]
        public UsuarioPadre()
        {
            Clean();
            CargarTabla();
        }
        #endregion


        #region[public Interfaz]
        private void CargarTabla()
        {

            sNombreTabla = "Editar Usuario Responsable";
            iAncho = 700;
            iAlto = 500;
            iNumeroPaginas = 10;
            mTipoFiltro = eTipoFiltro.Simple;
            sPrimaryKey = new string[] { };//{ "IdUsuario", "IdUsuarioHijo" };
            mForeignKey = new Dictionary<string, string>();
            mAccionesPersonalizadas = new Dictionary<string, string>();
            mAnchoColumnas = new Dictionary<string, int>();
            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoForeignKeyAlias = new Dictionary<string, string>();/*tabla destino, tabla source*/
            mListadoPrimaryKeyExcepciones = new List<string>();

            mAnchoColumnas.Add("IdUsuario", 100);
            mAnchoColumnas.Add("IdUsuarioHijo", 100);

            mListadoColumnasNombre.Add("IdUsuario", "Usuario Responsable");
            mListadoColumnasNombre.Add("IdUsuarioHijo", "Usuario Asignado");

            mListadoColumnasTipo.Add("IdUsuarioHijo", eTipoCampoTabla.ForeignKey);
            mListadoColumnasTipo.Add("IdUsuario", eTipoCampoTabla.ForeignKey);
            
            mForeignKey.Add("IdUsuario", "ADM_Usuario_Listar");
            mForeignKey.Add("IdUsuarioHijo", "ADM_Usuario_Listar");

            mListadoForeignKeyAlias.Add("IdUsuarioHijo", "IdUsuario");

            mListadoPrimaryKeyExcepciones.Add("IdUsuario");
            mListadoPrimaryKeyExcepciones.Add("IdUsuarioHijo");

            mAcciones = new eTipoAccion[3];
            mAcciones[0] = eTipoAccion.Eliminar;
            mAcciones[1] = eTipoAccion.Insertar;
            mAcciones[2] = eTipoAccion.Modificar;
            
            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            sProcedimientoGrilla = "ADM_Usuario_Padre_Listar";
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
            IdUsuario = 0;
            IdUsuarioHijo = 0;
        }
        private void CargarUsuarioPerfil(DataRow mRow)
        {
            if (mRow != null)
            {
                if (mRow["IdUsuarioHijo"] != DBNull.Value) IdUsuarioHijo = Convert.ToInt32(mRow["IdUsuarioHijo"]);
                if (mRow["IdUsuario"] != DBNull.Value) IdUsuario = Convert.ToInt32(mRow["IdUsuario"]);

            }
        }
        public void Modificar(bool bModificaTodo = true)
        {
            ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
            mParametros.Agregar("@IdUsuario", IdUsuario);
            mParametros.Agregar("@IdUsuarioHijo", IdUsuarioHijo);
            UsuarioPerfilPersistenceHelper.ModificarUsuarioHijo(mParametros);
        }
        public void Eliminar()
        {
            ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
            mParametros.Agregar("@IdUsuario", IdUsuario);
            mParametros.Agregar("@IdUsuarioHijo", IdUsuarioHijo);
            UsuarioPerfilPersistenceHelper.EliminarUsuarioHijo(mParametros);
        }
        #endregion
    }
}