using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Portal.PersistenceHelper;
using InDataAccess.Parametros;
namespace Portal.Factory
{
    public class FactoryTablas
    {
        #region[Constructor]
        public FactoryTablas()
        {
            mTablas = new Dictionary<string, DataTable>();
        }
        private static FactoryTablas mSingleton;
        internal static FactoryTablas Singleton
        {
            get
            {
                if (mSingleton == null) mSingleton = new FactoryTablas();
                return mSingleton;
            }
        }
        #endregion
        #region[Propiedades]
        private Dictionary<string, DataTable> mTablas;
        public string Key_Tabla { get { return "TABLA_"; } }
        #endregion
        #region[Metodos Genericos]
        private bool Exists(string psKey)
        {
            return mTablas.ContainsKey(psKey);
        }
        public void Clear(string psKey)
        {
            if (mTablas.ContainsKey(psKey)) mTablas.Remove(psKey);
        }
        private void Set(string psKey, DataTable pCombo)
        {
            if (!mTablas.ContainsKey(psKey))
                mTablas.Add(psKey, pCombo);
            else
                mTablas[psKey] = pCombo;
        }
        private DataTable this[string psKey]
        {
            get
            {
                return ((DataTable)mTablas[psKey]);
            }
        }
        #endregion
        #region[Metodos Especificos]
        public DataTable ObtenerDataSource(string psProcedimiento, bool pbCache = true, bool bAdminstracion = false)
        {
            string sKey = psProcedimiento;
            if (Exists(sKey))
                return this[sKey];
            else
                return null;
        }
        internal string ObtenerValorDatosGrilla(string psProcedimiento, string psColumna, string psValor, bool pbCache = true, bool bAdminstracion = false)
        {
            DataTable mTable = ObtenerDataSource(psProcedimiento, pbCache, bAdminstracion);
            try
            {
                return mTable.Select(psColumna + "=" + psValor)[0][1].ToString();
            }
            catch
            {
                return "";
            }
        }
        internal bool ObtenerDatosGrillaQueryBool(string psProcedimiento, string psFiltro)
        {

            string sKey = Key_Tabla + psProcedimiento;
            DataTable mTable = ObtenerDataSource(sKey);
            try
            {
                if (mTable.Select(psFiltro).Length > 0) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        internal DataRow ObtenerDatosGrillaQueryRow(string psProcedimiento, string psFiltro)
        {

            string sKey = Key_Tabla + psProcedimiento;
            DataTable mTable = ObtenerDataSource(sKey);
            try
            {
                return mTable.Select(psFiltro)[0];
                
            }
            catch
            {
                return null;
            }
        }
        internal DataRow[] ObtenerDatosGrillaQuery(string psProcedimiento, string psFiltro, bool pbCache = true, bool bAdminstracion = false, bool pbCargaKeyCompleta = false)
        {
            DataTable mTable = ObtenerDataSource((pbCargaKeyCompleta) ? Key_Tabla + psProcedimiento : psProcedimiento, pbCache, bAdminstracion);
            try
            {
                return mTable.Select(psFiltro);
            }
            catch
            {
                return null;
            }
        }
        internal void LimpiarDataSource(string psProcedimiento)
        {
            string sKey = Key_Tabla + psProcedimiento;
            Clear(sKey);
        }
        #endregion
        #region[Usuarios]
        internal DataTable ObtenerUsuarios()
        {
            string sKey = Key_Tabla + "Usuario";
            if (!Exists(sKey)) this.Set(sKey, UsuarioPersistance.CargarUsuario());
            return this[sKey];
        }
        internal void LimpiarUsuarios()
        {
            string sKey = Key_Tabla + "Usuario";
            Clear(sKey);
        }
        #endregion

        internal DataTable ObtenerDataSourceValorTabla(int piIdPerfil, string psTabla)
        {
            string sKey = Key_Tabla + psTabla + "_" + piIdPerfil.ToString();
            if (!Exists(sKey)) 
            {
                switch (psTabla)
                {
                    case "ADM_Usuario_Perfil":
                        this.Set(sKey, Portal.PersistenceHelper.PerfilPersistance.CargarPorIdPerfil(piIdPerfil));
                        break;
                }
                
            }
            return this[sKey];
        }

        internal void LimpiarTabla(int piIdPerfil, string psTabla)
        {
            string sKey = Key_Tabla + psTabla + "_" + piIdPerfil.ToString();
            Clear(sKey);
        }
    }
}
