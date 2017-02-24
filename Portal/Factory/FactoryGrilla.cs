using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Portal.PersistenceHelper;

namespace Portal.Domain.Factory
{
    public class FactoryGrilla
    {
        #region[Constructor]
        public FactoryGrilla()
        {
            mGrillas = new Dictionary<string, DataTable>();
        }
        #endregion
        #region[Propiedades]
        private Dictionary<string, DataTable> mGrillas;
        public string Key_GrillaGenerica { get { return "GRILLA_"; } }
        #endregion
        #region[Metodos]
        private bool Exists(string psKey)
		{
            return mGrillas.ContainsKey(psKey);
		}
		public void Clear(string psKey)
		{
            if (mGrillas.ContainsKey(psKey)) mGrillas.Remove(psKey);
		}
		private void Set(string psKey,DataTable pCombo)
		{
            if (!mGrillas.ContainsKey(psKey))
                mGrillas.Add(psKey, pCombo);
			else
                mGrillas[psKey] = pCombo;
		}
        private DataTable this[string psKey]
        {
            get
            {
                return ((DataTable)mGrillas[psKey]);
            }
        }
        private static FactoryGrilla mSingleton;
        internal static FactoryGrilla Singleton
		{
			get
			{
                if (mSingleton == null) mSingleton = new FactoryGrilla();
				return mSingleton;
			}
        }
        #region[Grilla-Generica]
        /// <summary>
        /// Metodo que factoriza la tabla obtenida y la deja disponible para todos los eventos futuros
        /// </summary>
        /// <param name="psProcedimiento">Procedimiento almacenado con el que se obtendrán los valores de la tabla</param>
        /// <returns>Retorna la tabla asociada para el procedimiento almacenado</returns>
        public DataTable ObtenerDataSource(string psProcedimiento, bool pbCache = true, bool bAdminstracion = false)
        {
            string sKey = Key_GrillaGenerica + psProcedimiento;
            if (!Exists(sKey) || !pbCache) this.Set(sKey, PortalPersistenceHelper.ObtenerDataSource(psProcedimiento, bAdminstracion));
            return this[sKey];
        }
        internal string ObtenerValorDatosGrilla(string psProcedimiento, string psColumna, string psValor, bool pbCache = true, bool bAdminstracion = false)
        {
            DataTable mTable = ObtenerDataSource(psProcedimiento, pbCache, bAdminstracion);
            try
            {
                return mTable.Select(psColumna + "='" + psValor+"'")[0][1].ToString();
            }
            catch
            {
                return "";
            }
        }
        internal DataRow[] ObtenerDatosGrillaQuery(string psProcedimiento, string psFiltro, bool pbCache = true, bool bAdminstracion = false)
        {
            DataTable mTable = ObtenerDataSource(psProcedimiento, pbCache, bAdminstracion);
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
            string sKey = Key_GrillaGenerica + psProcedimiento;
            Clear(sKey);
        }
        #endregion
        #endregion


    }
}
