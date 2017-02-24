/********************************************
/       Portal Develop 2012
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            Con el ADM_Grupo_Perfil
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
    public class ADM_Grupo_Perfil : IBase
    {
        #region[Propiedades]
            public long IdGrupoPefil{ get; set; }
            public long IdGrupo{ get; set; }
            public long IdPerfil{ get; set; }
            #endregion
            #region [Constructor]
            public ADM_Grupo_Perfil()
            {
                Clean();
                CargarTabla();
            }
            public ADM_Grupo_Perfil(Int64 IdGrupoPefil)
            {
                Clean();
                CargarADM_Grupo_Perfil(ADM_Grupo_PerfilPersistence.CargarDatosADM_Grupo_Perfil(IdGrupoPefil));
            }
            #endregion
            

            #region[public Interfaz]
            private void CargarTabla()
            {
            
 sNombreTabla = "Editar ADM_Grupo_Perfil";
            			iAncho = 700;
            			iAlto = 500;
            			iNumeroPaginas = 10;
            			mTipoFiltro = eTipoFiltro.Simple;            
 sPrimaryKey = new string[] { "IdGrupoPefil" };
						mForeignKey = new Dictionary<string, string>();
            			mAccionesPersonalizadas = new Dictionary<string, string>();
            			mAnchoColumnas = new Dictionary<string, int>();
            			mListadoColumnasNombre = new Dictionary<string, string>();
            			mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
                        mListadoForeignKeyAlias = new Dictionary<string, string>();/*tabla destino, tabla source*/
                        mListadoPrimaryKeyExcepciones = new List<string>();
                        
                        mAnchoColumnas.Add("IdGrupoPefil", 100);
                        mListadoColumnasNombre.Add("IdGrupoPefil", "IdGrupoPefil");
                        mListadoColumnasTipo.Add("IdGrupoPefil", eTipoCampoTabla.Int64);
                        mAnchoColumnas.Add("IdGrupo", 100);
                        mListadoColumnasNombre.Add("IdGrupo", "IdGrupo");
                        mListadoColumnasTipo.Add("IdGrupo", eTipoCampoTabla.ForeignKey);
                        mForeignKey.Add("IdGrupo", "ADM_Grupo");
                        mListadoForeignKeyAlias.Add("IdGrupo", "IdGrupo");
                        mAnchoColumnas.Add("IdPerfil", 100);
                        mListadoColumnasNombre.Add("IdPerfil", "IdPerfil");
                        mListadoColumnasTipo.Add("IdPerfil", eTipoCampoTabla.ForeignKey);
                        mForeignKey.Add("IdPerfil", "ADM_Perfil");
                        mListadoForeignKeyAlias.Add("IdPerfil", "IdPerfil");
            			mAcciones = new eTipoAccion[3];
            			mAcciones[0] = eTipoAccion.Eliminar;
            			mAcciones[1] = eTipoAccion.Insertar;
            			mAcciones[2] = eTipoAccion.Modificar;
            			mListadoEnumeradores = new Dictionary<string, System.Enum>();
            sProcedimientoGrilla = "ADM_Grupo_Perfil_Listar";
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
                IdGrupoPefil = 0;
                IdGrupo = 0;
                IdPerfil = 0;
            }
            private void CargarADM_Grupo_Perfil(DataRow mRow)
            {
                if (mRow != null)
                {
                     if (mRow["IdGrupoPerfil"] != DBNull.Value) IdGrupoPefil = Convert.ToInt64(mRow["IdGrupoPerfil"]);
                     if (mRow["IdGrupo"] != DBNull.Value) IdGrupo = Convert.ToInt64(mRow["IdGrupo"]);
                     if (mRow["IdPerfil"] != DBNull.Value) IdPerfil = Convert.ToInt64(mRow["IdPerfil"]);
                
                }
            }
            public void Modificar(bool bBool = true)
            {   //Dictionary<string,long> dModificarDatos = new   Dictionary<string,long>(); //util para obtener llaves introducidas 
                long lRespuesta = 0;
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                mParametros.Agregar("@IdGrupoPefil",IdGrupoPefil);
                mParametros.Agregar("@IdGrupo",IdGrupo);
                mParametros.Agregar("@IdPerfil",IdPerfil);
                lRespuesta = ADM_Grupo_PerfilPersistence.ModificarADM_Grupo_Perfil(mParametros);
        IdGrupoPefil = lRespuesta;
                
                
            }
            public void Eliminar()
            {
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                
                
 mParametros.Agregar("@IdGrupoPefil", IdGrupoPefil);
                ADM_Grupo_PerfilPersistence.EliminarADM_Grupo_Perfil(mParametros);
            } 
            #endregion
    }
}