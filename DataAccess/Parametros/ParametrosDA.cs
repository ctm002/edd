using System;
using System.Collections;

namespace InDataAccess.Parametros
{
    public class ParametrosDA
    {
        private ArrayList mParametros;
        public ParametrosDA()
        {
            mParametros = new ArrayList();
        }
        public void Agregar(ParametroDA pParametro)
        {
            mParametros.Add(pParametro);
        }
        public void Agregar(string psNombre, long plValor)
        {
            mParametros.Add(new ParametroLong(psNombre, plValor));
        }
        public void Agregar(string psNombre, byte[] pBinario)
        {
            mParametros.Add(new ParametroBinario(psNombre, pBinario));
        }
        public void Agregar(string psNombre, double plValor)
        {
            mParametros.Add(new ParametroDouble(psNombre, plValor));
        }
        public void Agregar(string psNombre, decimal plValor)
        {
            mParametros.Add(new ParametroDecimal(psNombre, plValor));
        }
        public void Agregar(string psNombre, string psValor)
        {
            mParametros.Add(new ParametroString(psNombre, psValor));
        }
        public void Agregar(string psNombre, bool pbValor)
        {
            mParametros.Add(new ParametroBool(psNombre, pbValor));
        }
        public void Agregar(string psNombre, DateTime pdValor)
        {
            mParametros.Add(new ParametroDateTime(psNombre, (pdValor.Year == 0001) ? new DateTime(1900, 1, 1) : pdValor));
        }
        public ParametroDA this[int lIndex]
        {
            get
            {
                return (ParametroDA)mParametros[lIndex];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return mParametros.GetEnumerator();
        }

        public void Agregar(string psNombre, DBNull plValor)
        {
            mParametros.Add(new ParametroNull(psNombre, plValor));
        }
    }
}
