/********************************************
/       Portal Develop 2012
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            Con el ADM_Tipo_Permiso
/********************************************
/ Fecha : 19-07-2012
/
*********************************************/

namespace Portal.Domain.Object
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using Portal.Persistence;
    //using Portal.Domain.Enum;
    using InDataAccess.Parametros;
    using Portal.Interface;
    using Portal.Domain.Enum;

    [Serializable]
    public class ADM_Tipo_Permiso : IBase
    {
        #region[Propiedades]
            public long IdTipoPermiso{ get; set; }
            public string Descripcion{ get; set; }
            #endregion
            #region [Constructor]
            public ADM_Tipo_Permiso()
            {
                Clean();
                CargarTabla();
            }
            public ADM_Tipo_Permiso(Int64 IdTipoPermiso)
            {
                Clean();
                CargarADM_Tipo_Permiso(ADM_Tipo_PermisoPersistence.CargarDatosADM_Tipo_Permiso(IdTipoPermiso));
            }
            #endregion
            

            #region[public Interfaz]
            private void CargarTabla()
            {
            
            sNombreTabla = "Editar ADM_Tipo_Permiso";
            iAncho = 500;
            iAlto = 500;
            iNumeroPaginas = 10;
            mTipoFiltro = eTipoFiltro.Simple;            
            sPrimaryKey = new string[] { "IdTipoPermiso" };
			mForeignKey = new Dictionary<string, string>();
            mAccionesPersonalizadas = new Dictionary<string, string>();
            mAnchoColumnas = new Dictionary<string, int>();
            mListadoColumnasNombre = new Dictionary<string, string>();
            mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            mListadoForeignKeyAlias = new Dictionary<string, string>();/*tabla destino, tabla source*/
            mListadoPrimaryKeyExcepciones = new List<string>();
                        
            mAnchoColumnas.Add("IdTipoPermiso", 50);
            mListadoColumnasNombre.Add("IdTipoPermiso", "IdTipoPermiso");
            mListadoColumnasTipo.Add("IdTipoPermiso", eTipoCampoTabla.Int64);
            mAnchoColumnas.Add("Descripcion", 150);
            mListadoColumnasNombre.Add("Descripcion", "Descripcion");
            mListadoColumnasTipo.Add("Descripcion", eTipoCampoTabla.String);
            mAcciones = new eTipoAccion[3];
            mAcciones[0] = eTipoAccion.Eliminar;
            mAcciones[1] = eTipoAccion.Insertar;
            mAcciones[2] = eTipoAccion.Modificar;
            mListadoEnumeradores = new Dictionary<string, System.Enum>();
            sProcedimientoGrilla = "ADM_Tipo_Permiso_Listar";
            mMostrarPordefecto = false;
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
        private int iIdUsuarioModifica; int IBase.IdUsuarioModifica { get { return iIdUsuarioModifica; } set { iIdUsuarioModifica = value; } } private string sNombreModifica; string IBase.NombreModifica { get { return sNombreModifica; } set { sNombreModifica = value; } }
        #endregion

            
            
            #region [Metodos]
            private void Clean()
            {
                IdTipoPermiso = 0;
                Descripcion = "";
            }
            private void CargarADM_Tipo_Permiso(DataRow mRow)
            {
                if (mRow != null)
                {
                     if (mRow["IdTipoPermiso"] != DBNull.Value) IdTipoPermiso = Convert.ToInt64(mRow["IdTipoPermiso"]);
                     if (mRow["Descripcion"] != DBNull.Value) Descripcion = Convert.ToString(mRow["Descripcion"]);
                
                }
            }
            public void Modificar(bool bBool = true)
            {   //Dictionary<string,long> dModificarDatos = new   Dictionary<string,long>(); //util para obtener llaves introducidas 
                long lRespuesta = 0;
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                mParametros.Agregar("@IdTipoPermiso",IdTipoPermiso);
                mParametros.Agregar("@Descripcion",Descripcion);
                lRespuesta = ADM_Tipo_PermisoPersistence.ModificarADM_Tipo_Permiso(mParametros);
        IdTipoPermiso = lRespuesta;
                
                
            }
            public void Eliminar()
            {
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                
                
 mParametros.Agregar("@IdTipoPermiso", IdTipoPermiso);
                ADM_Tipo_PermisoPersistence.EliminarADM_Tipo_Permiso(mParametros);
            } 
            #endregion
    }
}