namespace Portal.Domain.Object
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using PersistenceHelper;
    using InDataAccess.Parametros;
    using Interface;
    using Enum;

    [Serializable]
    public class HistorialAcciones : IBase
    {
        #region[Propiedades]

        public long IdHistorial { get; set; }

        public string Objeto { get; set; }

        public string Accion { get; set; }

        public long IdUsuario { get; set; }

        public string SerializablePre { get; set; }

        public string SerealizablePost { get; set; }

        #endregion
        #region [Constructor]
        public HistorialAcciones()
        {
            Clean();
            CargarTabla();
        }

        public HistorialAcciones(Int64 IdHistorial)
        {
            Clean();
            CargarHistorialAcciones(HistorialAccionesPersistenceHelper.CargarDatosHistorialAcciones(IdHistorial));
        }

        #endregion
        #region[public Interfaz]
        private void CargarTabla()
        {

            NombreTabla = "Editar HistorialAcciones";
            Ancho = 700;
            Alto = 500;
            NumeroPaginas = 10;
            mTipoFiltro = eTipoFiltro.Simple;
            PrimaryKey = new string[] { "IdHistorial" };
            ForeignKey = new Dictionary<string, string>();
            AccionesPersonalizadas = new Dictionary<string, string>();
            AnchoColumnas = new Dictionary<string, int>();
            ListadoColumnasNombre = new Dictionary<string, string>();
            ListadoColumnasTipo = new Dictionary<string, eTipoCampoTabla>();
            ListadoForeignKeyAlias = new Dictionary<string, string>();
            ListadoPrimaryKeyExcepciones = new List<string>();

            AnchoColumnas.Add("IdHistorial", 100);
            ListadoColumnasNombre.Add("IdHistorial", "IdHistorial");
            ListadoColumnasTipo.Add("IdHistorial", eTipoCampoTabla.Int64);
            AnchoColumnas.Add("Objeto", 100);
            ListadoColumnasNombre.Add("Objeto", "Objeto");
            ListadoColumnasTipo.Add("Objeto", eTipoCampoTabla.String);
            AnchoColumnas.Add("Accion", 100);
            ListadoColumnasNombre.Add("Accion", "Accion");
            ListadoColumnasTipo.Add("Accion", eTipoCampoTabla.String);
            AnchoColumnas.Add("IdUsuario", 100);
            ListadoColumnasNombre.Add("IdUsuario", "IdUsuario");
            ListadoColumnasTipo.Add("IdUsuario", eTipoCampoTabla.Int64);
            AnchoColumnas.Add("SerializablePre", 100);
            ListadoColumnasNombre.Add("SerializablePre", "SerializablePre");
            ListadoColumnasTipo.Add("SerializablePre", eTipoCampoTabla.String);
            AnchoColumnas.Add("SerealizablePost", 100);
            ListadoColumnasNombre.Add("SerealizablePost", "SerealizablePost");
            ListadoColumnasTipo.Add("SerealizablePost", eTipoCampoTabla.String);
            Acciones = new eTipoAccion[3];
            Acciones[0] = eTipoAccion.Eliminar;
            Acciones[1] = eTipoAccion.Insertar;
            Acciones[2] = eTipoAccion.Modificar;
            ListadoEnumeradores = new Dictionary<string, System.Enum>();
            ProcedimientoGrilla = "ADM_Historial_Acciones_Listar";
            MostrarPordefecto = false;
        }

        //private int iIdUsuarioModifica;

        public int IdUsuarioModifica
        {
            get; set;
        }


        public string NombreModifica
        {
            get; set;
        }

        public string ProcedimientoGrilla
        {
            get; set;
        }


        public string NombreTabla { get; set; }

        public int Ancho
        {
            get; set;
        }

        public int Alto
        {
            get; set;
        }

        public int NumeroPaginas
        {
            get; set;
        }

        public Dictionary<string, string> ListadoForeignKeyAlias
        {
            get; set;
        }
        public List<string> ListadoPrimaryKeyExcepciones
        {
            get; set;
        }

        public Dictionary<string, eTipoCampoTabla> ListadoColumnasTipo { get; set; }



        public Dictionary<string, string> ListadoColumnasNombre
        {
            get; set;
        }
        private eTipoFiltro mTipoFiltro;
        public eTipoFiltro TipoFiltro
        {
            get; set;
        }

        public string Titulo
        {
            get; set;
        }

        public eTipoAccion[] Acciones
        {
            get; set;
        }

        public Dictionary<string, string> AccionesPersonalizadas
        {
            get; set;
        }
        public string ProcedimientoParentId
        {
            get; set;
        }

        public string[] PrimaryKey
        {
            get; set;
        }

        public Dictionary<string, string> ForeignKey
        {
            get; set;
        }

        public Dictionary<string, int> AnchoColumnas
        {
            get; set;
        }

        public Dictionary<string, System.Enum> ListadoEnumeradores
        {
            get; set;
        }

        public bool MostrarPordefecto
        {
            get; set;
        }
        #endregion
        #region [Metodos]
        private void Clean()
        {
            IdHistorial = 0;
            Objeto = "";
            Accion = "";
            IdUsuario = 0;
            SerializablePre = "";
            SerealizablePost = "";
        }

        private void CargarHistorialAcciones(DataRow mRow)
        {
            if (mRow == null) return;
            if (mRow["IdHistorial"] != DBNull.Value) IdHistorial = Convert.ToInt64(mRow["IdHistorial"]);
            if (mRow["Objeto"] != DBNull.Value) Objeto = Convert.ToString(mRow["Objeto"]);
            if (mRow["Accion"] != DBNull.Value) Accion = Convert.ToString(mRow["Accion"]);
            if (mRow["IdUsuario"] != DBNull.Value) IdUsuario = Convert.ToInt64(mRow["IdUsuario"]);
            if (mRow["SerializablePre"] != DBNull.Value) SerializablePre = Convert.ToString(mRow["SerializablePre"]);
            if (mRow["SerealizablePost"] != DBNull.Value) SerealizablePost = Convert.ToString(mRow["SerealizablePost"]);
        }

        public void Modificar(bool bModificaTodo = true)
        {
            ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
            mParametros.Agregar("@IdHistorial", IdHistorial);
            mParametros.Agregar("@Objeto", Objeto);
            mParametros.Agregar("@Accion", Accion);
            mParametros.Agregar("@IdUsuario", IdUsuario);
            mParametros.Agregar("@SerializablePre", SerializablePre);
            mParametros.Agregar("@SerealizablePost", SerealizablePost);
            long lRespuesta = HistorialAccionesPersistenceHelper.ModificarHistorialAcciones(mParametros);
            IdHistorial = lRespuesta;
        }

        public void Eliminar()
        {
            ParametrosDA mParametros = new InDataAccess.Parametros.ParametrosDA();
            mParametros.Agregar("@IdHistorial", IdHistorial);
            HistorialAccionesPersistenceHelper.EliminarHistorialAcciones(mParametros);
        }
        #endregion
    }
}