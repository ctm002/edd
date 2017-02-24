using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace InDataAccess
{
    public class InDbHelper : InHelperBase
    {
        public InDbHelper()
            : base()
        {
        }
        public InDbHelper(eTipoMotor pmeTipoMotor) : base(pmeTipoMotor) { }

        //public InDbHelper(eTipoMotor pmeTipoMotor)
        //    : base(pmeTipoMotor)
        //{
        //}
        private static InDbHelper mInstancia;
        public static InDbHelper Instancia
        {
            get
            {
                if (mInstancia == null)
                    mInstancia = new InDbHelper((eTipoMotor)Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Motor"]));
                return mInstancia;
            }
        }

    }
}
