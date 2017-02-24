using System;

namespace InDataAccess.Parametros
{
    public class ParametroNull : ParametroDA
    {
        public ParametroNull(string psNombre, DBNull plValor) :
            base(psNombre, plValor)
        {
        }
    }
}