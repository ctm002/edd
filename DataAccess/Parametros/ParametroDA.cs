using System;
using System.Data.Odbc;
using System.Data;
using Sybase.Data.AseClient;
namespace  InDataAccess.Parametros
{
// Modificado Por LMOreno 03/05/2007
    abstract public class ParametroDA
    {
        private string mNombre;
        private object mValor;
        private OdbcType mTipo;
        private AseDbType mDbType;
        public ParametroDA(string psNombre, long plValor)
        {
            mNombre = psNombre;
            mValor = plValor;
            mTipo = OdbcType.Int;
            mDbType = AseDbType.Integer;
        }
        public ParametroDA(string psNombre, double plValor)
        {
            mNombre = psNombre;
            mValor = plValor;
            mTipo = OdbcType.Double;
            mDbType = AseDbType.Double;
        }
        public ParametroDA(string psNombre, decimal plValor)
        {
            mNombre = psNombre;
            mValor = plValor;
            mTipo = OdbcType.Decimal;
            mDbType = AseDbType.Decimal;
        }
        public ParametroDA(string psNombre, string psValor)
        {
            mNombre = psNombre;
            mValor = psValor;
            mTipo = OdbcType.Text;
            mDbType = AseDbType.VarChar;
        }
        public ParametroDA(string psNombre, DateTime pdValor)
        {
            mNombre = psNombre;
            mValor = pdValor;
            mTipo = OdbcType.DateTime;
        }
        public ParametroDA(string psNombre, bool pbValor)
        {
            mNombre = psNombre;
            mValor = pbValor;
            mTipo = OdbcType.Bit;
            mDbType = AseDbType.Bit;
        }
        public ParametroDA(string psNombre, byte[] pValor)
        {
            mNombre = psNombre;
            mValor = pValor;
            mTipo = OdbcType.Binary;
            mDbType = AseDbType.Binary;
        }

        public ParametroDA(string psNombre, DBNull pValor)
        {
            mNombre = psNombre;
            mValor = pValor;
            mTipo = OdbcType.Int;
            mDbType = AseDbType.Integer;
        }

        public ParametroDA()
        {
            // TODO: Complete member initialization
        }
        public string Nombre { get { return mNombre; } }
        public object Valor { get { return mValor; } }
        public OdbcType Tipo { get { return mTipo; } }
        public AseDbType DbType { get { return mDbType; } }
    }
}
