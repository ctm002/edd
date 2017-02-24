namespace InDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using Parametros;
    using DataAccess;
    using System.Data.SqlClient;
    using Sybase.Data.AseClient;
    abstract public class InHelperBase
    {
        protected string mConnectionDB = "";

        protected int mTimeOut = 0;

        public string ConnectionDB
        {
            get
            {
                if (mConnectionDB == null || mConnectionDB.Length == 0)
                {
                    switch (meTipoMotor)
                    {
                        case eTipoMotor.SqlServer:
                            mConnectionDB = System.Configuration.ConfigurationManager.AppSettings["Connection.SQLServer"];
                            mTimeOut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Connection.TimeOut"]);
                            break;
                        case eTipoMotor.Sybase:
                            mConnectionDB = System.Configuration.ConfigurationManager.AppSettings["Connection.Sybase"];
                            mTimeOut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Connection.TimeOut"]);
                            break;

                    }
                }

                return mConnectionDB;
            }
        }

        protected string mConnectionDBAdministracion = "";

        public string ConnectionDBAdministracion
        {
            get
            {
                if (mConnectionDBAdministracion == null || mConnectionDBAdministracion.Length == 0)
                    mConnectionDBAdministracion = System.Configuration.ConfigurationManager.AppSettings["Connection.SQLServer.Administracion"];

                return mConnectionDBAdministracion;
            }
        }

        protected int TimeOut
        {
            get
            {
                if (mTimeOut == 0)
                    mTimeOut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Connection.TimeOut"]);
                return mTimeOut;
            }
        }

        protected eTipoMotor _meTipoMotor;

        protected eTipoMotor meTipoMotor
        {
            get
            {
                if (_meTipoMotor == eTipoMotor.No_Motor)
                    _meTipoMotor = (eTipoMotor)Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Motor"]);
                return _meTipoMotor;
            }
            set { _meTipoMotor = value; }
        }

        protected eTipoMotor _eTipoMotorAdministracion;

        protected eTipoMotor eTipoMotorAdministracion
        {
            get
            {
                if (_eTipoMotorAdministracion == eTipoMotor.No_Motor)
                    _eTipoMotorAdministracion = (eTipoMotor)Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Motor.Administracion"]);
                return _eTipoMotorAdministracion;
            }
            set { _eTipoMotorAdministracion = value; }
        }

        public InHelperBase()
        {
        }

        public InHelperBase(eTipoMotor pmeTipoMotor)
        {
            meTipoMotor = pmeTipoMotor;
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mConnectionDB = System.Configuration.ConfigurationManager.AppSettings["Connection.SQLServer"];
                    mTimeOut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Connection.TimeOut"]);
                    break;
                case eTipoMotor.Sybase:
                    mConnectionDB = System.Configuration.ConfigurationManager.AppSettings["Connection.Sybase"];
                    mTimeOut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Connection.TimeOut"]);
                    break;
            }
        }
        #region[Metodos]

        public void EjecutarProcedimientoAlmacenado(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor)
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = "";
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    EjecutarProcedimientoAlmacenadoOleDb(psProcedimiento, pParametros, pbAdministracion);
                    break;
                case eTipoMotor.Sybase:
                    EjecutarProcedimientoAlmacenadoSyBase(psProcedimiento, pParametros, pbAdministracion);
                    break;
            }
        }

        public object ObtenerEscalar(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor)
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = "";
            object mReturn = null;
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mReturn = ObtenerEscalarOleDb(psProcedimiento, pParametros, pbAdministracion);
                    break;
                case eTipoMotor.Sybase:
                    mReturn = ObtenerEscalarSyBase(psProcedimiento, pParametros, pbAdministracion);
                    break;
            }
            return mReturn;
        }

        public DataTable ObtenerDataTable(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor)
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = "";
            DataTable mReturn = new DataTable();
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mReturn = ObtenerDataTableOleDb(psProcedimiento, pParametros, pbAdministracion);
                    break;
                case eTipoMotor.Sybase:
                    mReturn = ObtenerDataTableSyBase(psProcedimiento, pParametros, pbAdministracion);
                    break;
            }
            return mReturn;
        }

        public DataTable ObtenerDataTable(string psProcedimiento, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor)
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = "";
            DataTable mReturn = new DataTable();
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mReturn = ObtenerDataTableOleDb(psProcedimiento, pbAdministracion);
                    break;
                case eTipoMotor.Sybase:
                    mReturn = ObtenerDataTableSyBase(psProcedimiento, pbAdministracion);
                    break;
            }
            return mReturn;
        }
        
        public DataRow ObtenerDataRow(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor)
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = "";
            DataRow mReturn = null;
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mReturn = ObtenerDataRowOleDb(psProcedimiento, pParametros, pbAdministracion);
                    break;
                case eTipoMotor.Sybase:
                    mReturn = ObtenerDataRowSyBase(psProcedimiento, pParametros, pbAdministracion);
                    break;
            }
            return mReturn;
        }

        #endregion
        #region[OleDb]

        private void EjecutarProcedimientoAlmacenadoOleDb(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            SqlCommand mCommand = new SqlCommand();
            mCommand.CommandType = CommandType.StoredProcedure;
            mCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.Parameters.AddWithValue(mParametro.Nombre, mParametro.Valor);
            mCommand.Connection = (!pbAdministracion) ? new SqlConnection(ConnectionDB) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.Connection.Open();
            mCommand.CommandTimeout = TimeOut;
            mCommand.ExecuteNonQuery();
            mCommand.Connection.Close();
        }

        private object ObtenerEscalarOleDb(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            object mReturn;
            SqlCommand mCommand = new SqlCommand();
            mCommand.CommandType = CommandType.StoredProcedure;
            mCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.Parameters.AddWithValue(mParametro.Nombre, mParametro.Valor);
            mCommand.Connection = (!pbAdministracion) ? new SqlConnection(ConnectionDB) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.Connection.Open();
            mCommand.CommandTimeout = TimeOut;
            mReturn = mCommand.ExecuteScalar();
            mCommand.Connection.Close();
            mCommand.Connection = null;

            return (mReturn == null) ? 0 : mReturn;
        }


        private DataTable ObtenerDataTableOleDb(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            DataTable mTable = new DataTable();
            SqlDataAdapter mCommand = new SqlDataAdapter();
            mCommand.SelectCommand = new SqlCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.AddWithValue(mParametro.Nombre, mParametro.Valor);
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new SqlConnection(ConnectionDB) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.SelectCommand.CommandTimeout = TimeOut;
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            return mTable;
        }

        private DataTable ObtenerDataTableFromSQLOleDb(string psSql, bool pbAdministracion = false)
        {
            DataTable mTable = new DataTable();
            SqlDataAdapter mCommand = new SqlDataAdapter();
            mCommand.SelectCommand = new SqlCommand();
            mCommand.SelectCommand.CommandType = CommandType.Text;
            mCommand.SelectCommand.CommandText = psSql;
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new SqlConnection(ConnectionDB) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.SelectCommand.CommandTimeout = TimeOut;
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            return mTable;
        }

        private DataTable ObtenerDataTableOleDb(string psProcedimiento, bool pbAdministracion = false)
        {
            return ObtenerDataTableOleDb(psProcedimiento, new ParametrosDA(), pbAdministracion);
        }

        private DataRow ObtenerDataRowOleDb(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            DataTable mTable = new DataTable();
            DataRow mRow = null;
            SqlDataAdapter mCommand = new SqlDataAdapter();
            mCommand.SelectCommand = new SqlCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.AddWithValue(mParametro.Nombre, mParametro.Valor);
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new SqlConnection(ConnectionDB) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.SelectCommand.CommandTimeout = TimeOut;
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            if (mTable.Rows.Count > 0)
                mRow = mTable.Rows[0];
            return mRow;
        }

        #endregion

        #region[Ase-SyBase]
        private DataRow ObtenerDataRowSyBase(string psProcedimiento, bool pbAdministracion = false)
        {
            return ObtenerDataRowSyBase(psProcedimiento, new ParametrosDA(), pbAdministracion);
        }
        private DataRow ObtenerDataRowSyBase(string psProcedimiento, ParametroDA pParametro, bool pbAdministracion = false)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar(pParametro);
            return ObtenerDataRowSyBase(psProcedimiento, mParametros, pbAdministracion);
        }
        private DataTable ObtenerDataTableSyBase(string psProcedimiento, bool pbAdministracion = false)
        {
            return ObtenerDataTableSyBase(psProcedimiento, new ParametrosDA(), pbAdministracion);
        }
        private DataTable ObtenerDataTableSyBase(string psProcedimiento, ParametroDA pParametro, bool pbAdministracion = false)
        {
            DataTable mReturn;
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar(pParametro);
            mReturn = ObtenerDataTableSyBase(psProcedimiento, mParametros, pbAdministracion);

            return mReturn;
        }
        private object ObtenerEscalarSyBase(string psProcedimiento, ParametroDA pParametro, bool pbAdministracion = false)
        {
            object mReturn;
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar(pParametro);
            mReturn = ObtenerEscalarSyBase(psProcedimiento, mParametros, pbAdministracion);

            return mReturn;
        }
        private object ObtenerEscalarSyBase(string psProcedimiento, bool pbAdministracion = false)
        {
            return ObtenerEscalarSyBase(psProcedimiento, new ParametrosDA(), pbAdministracion);
        }
        private void EjecutarProcedimientoAlmacenadoSyBase(string psProcedimiento, ParametroDA pParametro, bool pbAdministracion = false)
        {
            ParametrosDA mParametros = new ParametrosDA();
            mParametros.Agregar(pParametro);
            EjecutarProcedimientoAlmacenadoSyBase(psProcedimiento, mParametros, pbAdministracion);

        }
        private void EjecutarProcedimientoAlmacenadoSyBase(string psProcedimiento, bool pbAdministracion = false)
        {
            EjecutarProcedimientoAlmacenadoSyBase(psProcedimiento, new ParametrosDA(), pbAdministracion);
        }
        private AseParameter ObtenerParametroSyBase(ParametroDA mParametro, bool pbAdministracion = false)
        {
            AseParameter mParametroOdBC = new AseParameter(mParametro.Nombre, mParametro.DbType);
            mParametroOdBC.Value = mParametro.Valor;
            if (mParametro.DbType == AseDbType.VarChar)
                mParametroOdBC.Size = mParametro.Valor.ToString().Length;
            return mParametroOdBC;
        }
        private void EjecutarProcedimientoAlmacenadoSyBase(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            AseCommand mCommand = new AseCommand();
            mCommand.CommandType = CommandType.StoredProcedure;
            mCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.Parameters.Add(ObtenerParametroSyBase(mParametro));
            mCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.Connection.Open();
            mCommand.CommandTimeout = TimeOut;
            mCommand.ExecuteNonQuery();
            mCommand.Connection.Close();
            mCommand.Connection = null;

        }
        private void EjecutarSQLSyBase(string psSQL, bool pbAdministracion = false)
        {
            AseCommand mCommand = new AseCommand();
            mCommand.CommandType = CommandType.Text;
            mCommand.CommandText = psSQL;
            mCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.Connection.Open();
            mCommand.CommandTimeout = TimeOut;
            mCommand.ExecuteNonQuery();
            mCommand.Connection.Close();
            mCommand.Connection = null;

        }
        private object ObtenerEscalarSyBase(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            object mReturn;
            AseCommand mCommand = new AseCommand();
            mCommand.CommandType = CommandType.StoredProcedure;
            mCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.Parameters.Add(ObtenerParametroSyBase(mParametro));
            mCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.Connection.Open();
            mCommand.CommandTimeout = TimeOut;
            mReturn = mCommand.ExecuteScalar();
            mCommand.Connection.Close();
            mCommand.Connection = null;

            return (mReturn == null) ? 0 : mReturn;
        }
        private DataTable ObtenerDataTableSyBase(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            DataTable mTable = new DataTable();
            AseDataAdapter mCommand = new AseDataAdapter();
            mCommand.SelectCommand = new AseCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.Add(ObtenerParametroSyBase(mParametro));
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.SelectCommand.CommandText = psProcedimiento;
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;
            mCommand.Dispose();

            return mTable;
        }
        private DataTable ObtenerDataTableFromSQLSyBase(string psSql, bool pbAdministracion = false)
        {
            DataTable mTable = new DataTable();
            AseDataAdapter mCommand = new AseDataAdapter();
            mCommand.SelectCommand = new AseCommand();
            mCommand.SelectCommand.CommandType = CommandType.Text;
            mCommand.SelectCommand.CommandText = psSql;
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            return mTable;
        }
        private DataRow ObtenerDataRowSyBase(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false)
        {
            DataTable mTable = new DataTable();
            DataRow mRow = null;
            AseDataAdapter mCommand = new AseDataAdapter();
            mCommand.SelectCommand = new AseCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.Add(ObtenerParametroSyBase(mParametro));
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            if (mTable.Rows.Count > 0)
                mRow = mTable.Rows[0];
            return mRow;
        }

        private DataRow ObtenerDataRowSyBaseCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, string psConnectionString = "")
        {
            DataTable mTable = new DataTable();
            DataRow mRow = null;
            AseDataAdapter mCommand = new AseDataAdapter();
            mCommand.SelectCommand = new AseCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.Add(ObtenerParametroSyBase(mParametro));
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new AseConnection(psConnectionString) : new AseConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            if (mTable.Rows.Count > 0)
                mRow = mTable.Rows[0];
            return mRow;
        }

        private object ObtenerEscalarSyBaseCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, string psConnectionString = "")
        {
            AseCommand mCommand = new AseCommand();
            mCommand.CommandType = CommandType.StoredProcedure;
            mCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.Parameters.Add(ObtenerParametroSyBase(mParametro));
            mCommand.Connection = (!pbAdministracion) ? new AseConnection(psConnectionString) : new AseConnection(ConnectionDBAdministracion);
            mCommand.Connection.Open();
            mCommand.CommandTimeout = TimeOut;
            object mReturn = mCommand.ExecuteScalar();
            mCommand.Connection.Close();
            mCommand.Connection = null;
            return (mReturn == null) ? 0 : mReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="psProcedimiento"></param>
        /// <param name="pParametros"></param>
        /// <param name="pbAdministracion"></param>
        /// <param name="psConnectionString"></param>
        /// <returns></returns>
        private object ObtenerEscalarSQLCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, string psConnectionString = "")
        {
            object mReturn;
            SqlCommand mCommand = new SqlCommand();
            mCommand.CommandType = CommandType.StoredProcedure;
            mCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.Parameters.AddWithValue(mParametro.Nombre, mParametro.Valor);
            mCommand.Connection = (!pbAdministracion) ? new SqlConnection(psConnectionString) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.Connection.Open();
            mCommand.CommandTimeout = TimeOut;
            mReturn = mCommand.ExecuteScalar();
            mCommand.Connection.Close();
            mCommand.Connection = null;

            return (mReturn == null) ? 0 : mReturn;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="psProcedimiento"></param>
        /// <param name="pParametros"></param>
        /// <param name="pbAdministracion"></param>
        /// <param name="psConnectionString"></param>
        /// <returns></returns>
        private DataRow ObtenerDataRowSQLCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, string psConnectionString = "")
        {
            DataTable mTable = new DataTable();
            DataRow mRow = null;
            SqlDataAdapter mCommand = new SqlDataAdapter();
            mCommand.SelectCommand = new SqlCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.AddWithValue(mParametro.Nombre, mParametro.Valor);
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new SqlConnection(psConnectionString) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.SelectCommand.CommandTimeout = TimeOut;
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            if (mTable.Rows.Count > 0)
                mRow = mTable.Rows[0];
            return mRow;
        }

        public object ObtenerEscalarSyBaseCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor, string psConnectionString = "")
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = "";
            object mReturn = null;
            switch (meTipoMotor)
            {
                case eTipoMotor.Sybase:
                    mReturn = ObtenerEscalarSyBaseCustom(psProcedimiento, pParametros, pbAdministracion, psConnectionString);
                    break;
            }
            return mReturn;
        }

        public object ObtenerEscalarSQLCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor, string psConnectionString = "")
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = psConnectionString;
            object mReturn = null;
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mReturn = ObtenerEscalarSQLCustom(psProcedimiento, pParametros, pbAdministracion, psConnectionString);
                    break;
                case eTipoMotor.Sybase:
                    mReturn = ObtenerEscalarSQLCustomSysbase(psProcedimiento, pParametros, pbAdministracion, psConnectionString);
                    break;
            }
            return mReturn;
        }

        public DataRow ObtenerDataRowSQLCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor, string psConnectionString = "")
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = psConnectionString;
            DataRow mReturn = null;
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mReturn = ObtenerDataRowSQLCustom(psProcedimiento, pParametros, pbAdministracion, psConnectionString);
                    break;
            }
            return mReturn;
        }

        public DataTable ObtenerDataTableSQLCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion = false, eTipoMotor peTipoMotor = eTipoMotor.No_Motor, string psConnectionString = "")
        {
            eTipoMotor mTipoMotor = meTipoMotor;
            if (pbAdministracion)
                meTipoMotor = eTipoMotorAdministracion;
            else
            {
                meTipoMotor = eTipoMotor.No_Motor;
                meTipoMotor = (peTipoMotor == eTipoMotor.No_Motor) ? meTipoMotor : peTipoMotor;
            }
            if (mTipoMotor != meTipoMotor)
                mConnectionDB = "";
            DataTable mReturn = new DataTable();
            switch (meTipoMotor)
            {
                case eTipoMotor.SqlServer:
                    mReturn = ObtenerDataTableSQLCustom(psProcedimiento, pParametros, pbAdministracion, psConnectionString);
                    break;
                case eTipoMotor.Sybase:
                    mReturn = ObtenerDataTableSybaseCustom(psProcedimiento, pParametros, pbAdministracion, psConnectionString);
                    break;
            }
            return mReturn;
        }

        private DataTable ObtenerDataTableSybaseCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion, string psConnectionString)
        {

            DataTable mTable = new DataTable();
            AseDataAdapter mCommand = new AseDataAdapter();
            mCommand.SelectCommand = new AseCommand();
            mCommand.SelectCommand.CommandType = CommandType.Text;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            return mTable;

            /*
            DataTable mTable = new DataTable();
            AseDataAdapter mCommand = new AseDataAdapter();
            mCommand.SelectCommand = new AseCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.Add(ObtenerParametroSyBase(mParametro));
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.SelectCommand.CommandText = psProcedimiento;
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;
            mCommand.Dispose();
            
            return mTable;*/
        }

        private object ObtenerEscalarSQLCustomSysbase(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion, string psConnectionString)
        {
            object mReturn;
            DataTable mTable = new DataTable();
            AseDataAdapter mCommand = new AseDataAdapter();
            mCommand.SelectCommand = new AseCommand();
            mCommand.SelectCommand.CommandType = CommandType.Text;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new AseConnection(ConnectionDB) : new AseConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.Fill(mTable);
            mReturn = mCommand.SelectCommand.ExecuteScalar();
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;


            return (mReturn == null) ? 0 : mReturn;
        }


        private DataTable ObtenerDataTableSQLCustom(string psProcedimiento, ParametrosDA pParametros, bool pbAdministracion, string psConnectionString)
        {
            DataTable mTable = new DataTable();
            SqlDataAdapter mCommand = new SqlDataAdapter();
            mCommand.SelectCommand = new SqlCommand();
            mCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            mCommand.SelectCommand.CommandText = psProcedimiento;
            foreach (ParametroDA mParametro in pParametros)
                mCommand.SelectCommand.Parameters.AddWithValue(mParametro.Nombre, mParametro.Valor);
            mCommand.SelectCommand.Connection = (!pbAdministracion) ? new SqlConnection(psConnectionString) : new SqlConnection(ConnectionDBAdministracion);
            mCommand.SelectCommand.Connection.Open();
            mCommand.SelectCommand.CommandTimeout = TimeOut;
            mCommand.Fill(mTable);
            mCommand.SelectCommand.Connection.Close();
            mCommand.SelectCommand.Connection = null;
            mCommand.SelectCommand = null;

            return mTable;
        }


        #endregion
    }
}
