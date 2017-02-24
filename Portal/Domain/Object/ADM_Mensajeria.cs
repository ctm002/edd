/********************************************
/       Portal Develop 2014
/********************************************
/ Creado Por: Israel Rivera
/ Objetivo  : Objeto encargado de la interaccion
/            Con el ADM_Mensajeria
/********************************************
/ Fecha : 20-06-2014
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
    public class ADM_Mensajeria : IBase
    {
        #region[Propiedades]
            public long Id{ get; set; }
            public string Mensaje{ get; set; }
            public long IdUsuario{ get; set; }
            public long IdUsuarioMod{ get; set; }
            public DateTime Fecha{ get; set; }
            public DateTime FechaMod{ get; set; }
            public long Estado{ get; set; }
            public byte[] Archivo{ get; set; }
            public string NombreArchivo{ get; set; }
            public string ContentType{ get; set; }
            public int IdSistema { get; set; }
            #endregion
            #region [Constructor]
            public ADM_Mensajeria()
            {
                Clean();
                CargarTabla();
            }
            public ADM_Mensajeria(Int64 Id)
            {
                Clean();
                CargarADM_Mensajeria(ADM_MensajeriaPersistence.CargarDatosADM_Mensajeria(Id));
            }
            #endregion
            

            #region[public Interfaz]
            private void CargarTabla()
            {
            
 sNombreTabla = "Editar ADM_Mensajeria";
            			iAncho = 700;
            			iAlto = 500;
            			iNumeroPaginas = 10;
            			mTipoFiltro = eTipoFiltro.Simple;            
 sPrimaryKey = new string[] { "Id" };
						mForeignKey = new Dictionary<string, string>();
            			mAccionesPersonalizadas = new Dictionary<string, string>();
            			mAnchoColumnas = new Dictionary<string, int>();
            			mListadoColumnasNombre = new Dictionary<string, string>();
            			mListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
                        mListadoForeignKeyAlias = new Dictionary<string, string>();/*tabla destino, tabla source*/
                        mListadoPrimaryKeyExcepciones = new List<string>();
                        
                        mAnchoColumnas.Add("Id", 100);
                        mListadoColumnasNombre.Add("Id", "Id");
                        mListadoColumnasTipo.Add("Id", eTipoCampoTabla.Int64);
                        mAnchoColumnas.Add("Mensaje", 100);
                        mListadoColumnasNombre.Add("Mensaje", "Mensaje");
                        mListadoColumnasTipo.Add("Mensaje", eTipoCampoTabla.String);
                        mAnchoColumnas.Add("IdUsuario", 100);
                        mListadoColumnasNombre.Add("IdUsuario", "IdUsuario");
                        mListadoColumnasTipo.Add("IdUsuario", eTipoCampoTabla.Int64);
                        mAnchoColumnas.Add("IdUsuarioMod", 100);
                        mListadoColumnasNombre.Add("IdUsuarioMod", "IdUsuarioMod");
                        mListadoColumnasTipo.Add("IdUsuarioMod", eTipoCampoTabla.Int64);
                        mAnchoColumnas.Add("Fecha", 100);
                        mListadoColumnasNombre.Add("Fecha", "Fecha");
                        mListadoColumnasTipo.Add("Fecha", eTipoCampoTabla.DateTime);
                        mAnchoColumnas.Add("FechaMod", 100);
                        mListadoColumnasNombre.Add("FechaMod", "FechaMod");
                        mListadoColumnasTipo.Add("FechaMod", eTipoCampoTabla.DateTime);
                        mAnchoColumnas.Add("Estado", 100);
                        mListadoColumnasNombre.Add("Estado", "Estado");
                        mListadoColumnasTipo.Add("Estado", eTipoCampoTabla.Int64);
                        mAnchoColumnas.Add("Archivo", 100);
                        mListadoColumnasNombre.Add("Archivo", "Archivo");
                        mListadoColumnasTipo.Add("Archivo", eTipoCampoTabla.String);
                        mAnchoColumnas.Add("NombreArchivo", 100);
                        mListadoColumnasNombre.Add("NombreArchivo", "NombreArchivo");
                        mListadoColumnasTipo.Add("NombreArchivo", eTipoCampoTabla.String);
                        mAnchoColumnas.Add("ContentType", 100);
                        mListadoColumnasNombre.Add("ContentType", "ContentType");
                        mListadoColumnasTipo.Add("ContentType", eTipoCampoTabla.String);
            			mAcciones = new eTipoAccion[3];
            			mAcciones[0] = eTipoAccion.Eliminar;
            			mAcciones[1] = eTipoAccion.Insertar;
            			mAcciones[2] = eTipoAccion.Modificar;
            			mListadoEnumeradores = new Dictionary<string, System.Enum>();
            sProcedimientoGrilla = "ADM_Mensajeria_Listar";
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
                Id = 0;
                Mensaje = "";
                IdUsuario = 0;
                IdUsuarioMod = 0;
                Fecha = new DateTime();
                FechaMod = new DateTime();
                Estado = 0;
                Archivo = null;
                NombreArchivo = "";
                ContentType = "";
                IdSistema = 0;
            }
            private void CargarADM_Mensajeria(DataRow mRow)
            {
                if (mRow != null)
                {
                     if (mRow["Id"] != DBNull.Value) Id = Convert.ToInt64(mRow["Id"]);
                     if (mRow["Mensaje"] != DBNull.Value) Mensaje = Convert.ToString(mRow["Mensaje"]);
                     if (mRow["IdUsuario"] != DBNull.Value) IdUsuario = Convert.ToInt64(mRow["IdUsuario"]);
                     if (mRow["IdUsuarioMod"] != DBNull.Value) IdUsuarioMod = Convert.ToInt64(mRow["IdUsuarioMod"]);
                     if (mRow["Fecha"] != DBNull.Value) Fecha = Convert.ToDateTime(mRow["Fecha"]);
                     if (mRow["FechaMod"] != DBNull.Value) FechaMod = Convert.ToDateTime(mRow["FechaMod"]);
                     if (mRow["Estado"] != DBNull.Value) Estado = Convert.ToInt64(mRow["Estado"]);
                     if (mRow["Archivo"] != DBNull.Value) Archivo = (byte[])mRow["Archivo"];
                     if (mRow["NombreArchivo"] != DBNull.Value) NombreArchivo = Convert.ToString(mRow["NombreArchivo"]);
                     if (mRow["ContentType"] != DBNull.Value) ContentType = Convert.ToString(mRow["ContentType"]);
                     if (mRow["IdSistema"] != DBNull.Value) IdSistema = Convert.ToInt32(mRow["IdSistema"]);
                }
            }
            public void Modificar(bool bBool = true)
            {   //Dictionary<string,long> dModificarDatos = new   Dictionary<string,long>(); //util para obtener llaves introducidas 
                long lRespuesta = 0;
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                mParametros.Agregar("@Id",Id);
                mParametros.Agregar("@Mensaje",Mensaje);
                mParametros.Agregar("@IdUsuario",IdUsuario);
                mParametros.Agregar("@IdUsuarioMod",IdUsuarioMod);
                mParametros.Agregar("@Fecha",Fecha);
                mParametros.Agregar("@FechaMod",FechaMod);
                mParametros.Agregar("@Estado",Estado);
                mParametros.Agregar("@Archivo",Archivo);
                mParametros.Agregar("@NombreArchivo",NombreArchivo);
                mParametros.Agregar("@ContentType",ContentType);
                mParametros.Agregar("@IdSistema", IdSistema);
                lRespuesta = ADM_MensajeriaPersistence.ModificarADM_Mensajeria(mParametros);
                Id = lRespuesta;
                
                
            }
            public void Eliminar()
            {
                ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
                
                
                mParametros.Agregar("@Id", Id);
                ADM_MensajeriaPersistence.EliminarADM_Mensajeria(mParametros);
            } 
            #endregion
    }
}