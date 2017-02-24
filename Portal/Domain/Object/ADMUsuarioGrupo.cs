/********************************************
/       Portal Develop 2012
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            Con el ADMUsuarioGrupo
/********************************************
/ Fecha : 23-07-2012
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
    public class ADMUsuarioGrupo : IBase
    {
        #region[Propiedades]
            public long IdUsuarioGrupo{ get; set; }
            public long IdUsuario{ get; set; }
            public long IdGrupo{ get; set; }
            #endregion
            #region [Constructor]
            public ADMUsuarioGrupo()
            {
                Clean();
                CargarTabla();
            }
            public ADMUsuarioGrupo(Int64 IdUsuarioGrupo)
            {
                Clean();
                CargarADMUsuarioGrupo(ADMUsuarioGrupoPersistence.CargarDatosADMUsuarioGrupo(IdUsuarioGrupo));
            }
            #endregion
            

            #region[public Interfaz]
            private void CargarTabla()
            {
            
 sNombreTabla = "Editar ADMUsuarioGrupo";
            			iAncho = 700;
            			iAlto = 500;
            			iNumeroPaginas = 10;
            			mTipoFiltro = eTipoFiltro.Simple;            
 sPrimaryKey = new string[] { "IdUsuarioGrupo" };
						mForeignKey = new Dictionary<string, string>();
            			mAccionesPersonalizadas = new Dictionary<string, string>();
            			mAnchoColumnas = new Dictionary<string, int>();
            			mListadoColumnasNombre = new Dictionary<string, string>();
            			mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
                        mListadoForeignKeyAlias = new Dictionary<string, string>();/*tabla destino, tabla source*/
                        mListadoPrimaryKeyExcepciones = new List<string>();
                        
                        mAnchoColumnas.Add("IdUsuarioGrupo", 100);
                        mListadoColumnasNombre.Add("IdUsuarioGrupo", "IdUsuarioGrupo");
                        mListadoColumnasTipo.Add("IdUsuarioGrupo", eTipoCampoTabla.Int64);
                        mAnchoColumnas.Add("IdUsuario", 100);
                        mListadoColumnasNombre.Add("IdUsuario", "IdUsuario");
                        mListadoColumnasTipo.Add("IdUsuario", eTipoCampoTabla.Int64);
                        mAnchoColumnas.Add("IdGrupo", 100);
                        mListadoColumnasNombre.Add("IdGrupo", "IdGrupo");
                        mListadoColumnasTipo.Add("IdGrupo", eTipoCampoTabla.Int64);
            			mAcciones = new eTipoAccion[3];
            			mAcciones[0] = eTipoAccion.Eliminar;
            			mAcciones[1] = eTipoAccion.Insertar;
            			mAcciones[2] = eTipoAccion.Modificar;
            			mListadoEnumeradores = new Dictionary<string, System.Enum>();
            sProcedimientoGrilla = "ADMUsuarioGrupo_Listar";
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
        private int iIdUsuarioModifica; 
        int IBase.IdUsuarioModifica 
        { 
            get { return iIdUsuarioModifica; } 
            set { iIdUsuarioModifica = value; } 
        } 

        private string sNombreModifica; 
        string IBase.NombreModifica 
        { 
            get { return sNombreModifica; } 
            set { sNombreModifica = value; } 
        }
        #endregion

            
            
            #region [Metodos]
            private void Clean()
            {
                IdUsuarioGrupo = 0;
                IdUsuario = 0;
                IdGrupo = 0;
            }
            private void CargarADMUsuarioGrupo(DataRow mRow)
            {
                if (mRow != null)
                {
                     if (mRow["IdUsuarioGrupo"] != DBNull.Value) IdUsuarioGrupo = Convert.ToInt64(mRow["IdUsuarioGrupo"]);
                     if (mRow["IdUsuario"] != DBNull.Value) IdUsuario = Convert.ToInt64(mRow["IdUsuario"]);
                     if (mRow["IdGrupo"] != DBNull.Value) IdGrupo = Convert.ToInt64(mRow["IdGrupo"]);
                
                }
            }
            public void Modificar(bool bBool = true)
            {   //Dictionary<string,long> dModificarDatos = new   Dictionary<string,long>(); //util para obtener llaves introducidas 
                long lRespuesta = 0;
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                mParametros.Agregar("@IdUsuarioGrupo",IdUsuarioGrupo);
                mParametros.Agregar("@IdUsuario",IdUsuario);
                mParametros.Agregar("@IdGrupo",IdGrupo);
                lRespuesta = ADMUsuarioGrupoPersistence.ModificarADMUsuarioGrupo(mParametros);
        IdUsuarioGrupo = lRespuesta;
                
                
            }
            public void Eliminar()
            {
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                
                
 mParametros.Agregar("@IdUsuarioGrupo", IdUsuarioGrupo);
                ADMUsuarioGrupoPersistence.EliminarADMUsuarioGrupo(mParametros);
            } 
            #endregion
    }
}