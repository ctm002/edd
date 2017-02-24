using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Domain.Factory;
using Portal.PersistenceHelper;
using InDataAccess.Parametros;
using System.Data;
using Portal.Domain.Object;
using Portal.Factory;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace Portal.Controller
{
    public class PortalController
    {
        public PortalController()
        {
            CargarObjetos();
        }
        #region[Propiedades]
        private Dictionary<string, object> mListadoObjetosMantenedores;
        public Dictionary<string, object> ListadoObjetosMantenedores { get { if (mListadoObjetosMantenedores == null) CargarObjetos(); return mListadoObjetosMantenedores; } set { mListadoObjetosMantenedores = value; } }
        
        private void CargarObjetos()
        {
            mListadoObjetosMantenedores = new Dictionary<string, object>();
            //mListadoObjetosMantenedores.Add("archivo", new Archivo().GetType());
            //mListadoObjetosMantenedores.Add("bodega", new Bodega().GetType());
            //mListadoObjetosMantenedores.Add("estante", new Estante().GetType());
            //mListadoObjetosMantenedores.Add("sector", new Sector().GetType());
        }
        #endregion
        /// <summary>
        /// Metodo que retorna los datos de la grilla generica
        /// </summary>
        /// <param name="psProcedimiento">Parametro que se define en el objeto para poder listar los campos a desplegar en la grilla</param>
        /// <returns>Retorna la tabla o vista asociada en la grilla generica</returns>
        public System.Data.DataTable ObtenerDatosGrilla(string psProcedimiento, bool pbCache = true, bool bAdminstracion = false)
        {
            return FactoryGrilla.Singleton.ObtenerDataSource(psProcedimiento, pbCache, bAdminstracion);
        }

        /// <summary>
        /// Metodo que retorna el valor almacenado en la grilla factorizada
        /// </summary>
        /// <param name="psProcedimiento">Nombre del procedimiento a utilizar</param>
        /// <param name="psColumna">Nombre de la columna a buscar</param>
        /// <param name="psValor">Valor a consultar</param>
        /// <returns></returns>
        public string ObtenerValorDatosGrilla(string psProcedimiento, string psColumna, string psValor, bool pbCache = true, bool bAdminstracion = false)
        {
            return FactoryGrilla.Singleton.ObtenerValorDatosGrilla(psProcedimiento, psColumna, psValor, pbCache, bAdminstracion);
        }
        /// <summary>
        /// Metodo que limpia la tabla del Factory para que sea utilizada en eventos posteriores
        /// </summary>
        /// <param name="psProcedimiento">Nombre del procedimiento a buscar</param>
        public void LimpiarTablaGrilla(string psProcedimiento)
        {
            FactoryGrilla.Singleton.LimpiarDataSource(psProcedimiento);
        }

        //public void AgregarMantenedor(string psNombre, Type tType)
        //{
        //    //if (!mListadoObjetosMantenedores.ContainsKey(psNombre))
        //    //    mListadoObjetosMantenedores.Add(psNombre, tType);
        //}

        public void AgregarMantenedor(string psNombre, object oObject)
        {
            if (!mListadoObjetosMantenedores.ContainsKey(psNombre))
                mListadoObjetosMantenedores.Add(psNombre, oObject);
        }
        /// <summary>
        /// Metodo que permite obtener un conjunto de filas asociadas a una tabl, mediante los parametros del sistema
        /// </summary>
        /// <param name="psProcedimiento">Nombre de la tabla factorizada</param>
        /// <param name="sQuery">Query que representa el WHERE de la consulta</param>
        /// <returns></returns>
        public DataTable ListarMenu(int piIdSistema)
        {
            return PortalPersistenceHelper.MenuSistema(piIdSistema);
        }
        public DataTable ListarPaginas(int piIdMenu)
        {
            return PortalPersistenceHelper.MenuSistemaPaginas(piIdMenu);
        }


        public object ObtenerDatosGrillaQuery(string psProcedimiento, string psQuery, bool pbCache = true, bool bAdminstracion = false)
        {
            return FactoryGrilla.Singleton.ObtenerDatosGrillaQuery(psProcedimiento, psQuery, pbCache, bAdminstracion);
        }

        #region[Portal]
        public Sistema ObtenerSistema(string psUrl)
        {
            return FactoryObject.Singleton.ObtenerPortal(psUrl);
        }
        public DataTable CargarTodosLosSistemas()
        {
            return SistemaPersistance.CargarSistema();
        }
        //public string ObtenerPaginaInicial(int piIdSistema, Usuario pmUsuario)
        //{
        //    foreach (KeyValuePair<int, Perfil> mPerfil in pmUsuario.Perfiles)
        //    {
        //        if (mPerfil.Value.Sistemas.ContainsKey(piIdSistema))
        //            return mPerfil.Value.Sistemas[piIdSistema].PaginaDefecto.Url;
        //    }
        //    return "/Default.aspx";
        //}
        public string SerealizarObjeto<T>(T mObjeto)
        {
            String XmlizedString = null;
            try
            {
                MemoryStream mMemoryStream = new MemoryStream();
                XmlSerializer mSerealizacion = new XmlSerializer(mObjeto.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(mMemoryStream, Encoding.UTF8);
                mSerealizacion.Serialize(xmlTextWriter, mObjeto);
                mMemoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8ByteArrayToString(mMemoryStream.ToArray());
            }
            catch
            {
                XmlizedString = "";
            }
            return XmlizedString;
        }
        public string SerealizarObjeto(Type mType, object mObjeto)
        {
            
            String XmlizedString = null;
            MemoryStream mMemoryStream = new MemoryStream();
            XmlSerializer mSerealizacion = new XmlSerializer(Activator.CreateInstance(mType).GetType());
            XmlTextWriter xmlTextWriter = new XmlTextWriter(mMemoryStream, Encoding.UTF8);
            mSerealizacion.Serialize(xmlTextWriter, mObjeto);
            mMemoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = UTF8ByteArrayToString(mMemoryStream.ToArray());
            return XmlizedString;
        }
        public T DeserializeObject<T>(T mObjeto, String psXmlizedString)
        {
            XmlSerializer xs = new XmlSerializer(mObjeto.GetType());
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(psXmlizedString));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)xs.Deserialize(memoryStream);
        }
        private String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        } 
        #endregion
        /// <summary>
        /// Metodo que registra el historial de las acciones realizadas sobre el Mantenedor General
        /// </summary>
        /// <param name="piIdUsuario">Id Usuario que realiza la accion</param>
        /// <param name="psObjeto">Nombre del Objeto a Modificar</param>
        /// <param name="psAccion">Nombre de Accion a Realizar</param>
        /// <param name="psXmlInicial">Objeto Serealizado Previo Modificacion</param>
        /// <param name="psXmlFinal">Objeto Serealizado Post Modificacion</param>
        public void AgregarHistorialAcciones(int piIdUsuario, string psObjeto, string psAccion, string psXmlInicial, string psXmlFinal)
        {
            HistorialAcciones mHistorial = new HistorialAcciones();
            mHistorial.Accion = psAccion;
            mHistorial.IdUsuario = piIdUsuario;
            mHistorial.Objeto = psObjeto;
            mHistorial.SerealizablePost = psXmlFinal;
            mHistorial.SerializablePre = psXmlInicial;
            mHistorial.Modificar();

        }

        public Type EstadoArchivo { get; set; }

        public string ObtenerNomnbreDominio()
        {
            return ActiveDirectoryHelper.Instancia.Domain;
        }
    }
}
