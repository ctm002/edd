namespace Portal.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Portal.Domain.Object;
    public class FactoryObject
    {
        #region[Constructor]
        public FactoryObject()
        {
            FactoryObjetos = new Dictionary<string, object>();
        }
        private static FactoryObject mSingleton;
        internal static FactoryObject Singleton
        {
            get
            {
                if (mSingleton == null) mSingleton = new FactoryObject();
                return mSingleton;
            }
        }
        public object this[string sKey]
        {
            get
            {
                return FactoryObjetos[sKey];
            }
        }
        #endregion
        #region[Propiedades]
        public Dictionary<string, object> FactoryObjetos { get; set; }
        public string Key_Sistema { get { return "SISTEMA_"; } }
        public string Key_SistemalUrl { get { return "SISTEMA_URL_"; } }
        #endregion
        #region[Metodos]
        #region[Portal]
        public Sistema AgregarPortal(int lIDPortal)
        {
            string sKey = Key_Sistema + lIDPortal.ToString();
            if (Existe(sKey))
            {
                Eliminar(sKey);
                Agregar(sKey, new Sistema(lIDPortal));
            }
            else
                Agregar(sKey, new Sistema(lIDPortal));
            return (Sistema)this[sKey];
        }
        public Sistema ObtenerPortal(int lIDPortal)
        {
            string sKey = Key_Sistema + lIDPortal.ToString();
            if (Existe(sKey))
                return (Sistema)this[sKey];
            else
                Agregar(sKey, new Sistema(lIDPortal));
            return (Sistema)this[sKey];
        }
        public Sistema ObtenerPortal(string psUrl)
        {
            string sKey = Key_SistemalUrl + psUrl;
            if (Existe(sKey))
                return (Sistema)this[sKey];
            else
                Agregar(sKey, new Sistema(psUrl));
            return (Sistema)this[sKey];
        }
        #endregion
        #region[Usuario]
        #endregion
        private void Agregar(string sKey, object mObjet)
        {
            if (FactoryObjetos.ContainsKey(sKey))
                FactoryObjetos[sKey] = mObjet;
            else
                FactoryObjetos.Add(sKey, mObjet);
        }
        private void Eliminar(string sKey)
        {
            FactoryObjetos.Remove(sKey);
        }
        private bool Existe(string sKey)
        {
            return FactoryObjetos.ContainsKey(sKey);
        }
        private bool Existe<T>(T tObj, string sKey)
        {
            return false;
        }
        #endregion
    }
}
