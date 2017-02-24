using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Configuration;
using Portal.PersistenceHelper;
using System.Data;
using Portal.Domain.Object;

namespace Portal.Controller
{
    public class AutenticacionController
    {
        #region[Constructor]
        public AutenticacionController()
        {
        }
        #endregion
        #region[Propiedades]
        #endregion
        #region[Metodos]
        /// <summary>
        /// Metodo que valida que el usuario exista en el AD y no este bloqueado
        /// </summary>
        /// <param name="psUserName">Nombre de usuario</param>
        /// <returns>Bool que indica resultado</returns>
        public bool ValidarUsuario(string psUserName)
        {
            if (ActiveDirectoryHelper.Instancia.ValidUserByLoginName(ValidarNombreUsuario(psUserName)))
            {
                Portal.Domain.Object.ADUserDetail mDatosUser = ActiveDirectoryHelper.Instancia.GetUserByLoginName(ValidarNombreUsuario(psUserName));
                if (Portal.PortalFacade.Singleton.UsuarioController.ExisteUsuarioSistema(mDatosUser.Guid))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public Session ObtenerSessionPorGuid(string psGuid)
        {
            return Portal.PortalFacade.Singleton.UsuarioController.ObtenerUsuarioPorGuid(psGuid);
        }
        /// <summary>
        /// Metodo que permite separar los nombres de los usuarios que esten activos en el dominio
        /// </summary>
        /// <param name="psNombre">Valor obtenido de la session del usuario: Domain\\User</param>
        /// <returns>User</returns>
        private string ValidarNombreUsuario(string psNombre)
        {
            string[] sNombre = psNombre.Split('\\');
            if (sNombre.Length > 1)
                return sNombre[1];
            else
                return psNombre;
        }
        public bool AutenticarUsuario(string psUserName, string psPassword)
        {
            return ActiveDirectoryHelper.Instancia.ValidUserByLoginName(psUserName, psPassword);
        }

        public ADUserDetail CargarDatosADUsuarioPorGuid(string psGuid)
        {
            return ActiveDirectoryHelper.Instancia.GetUserByGuid(psGuid);
        }

        public ADUserDetail CargarDatosADUsuarioPorLoginName(string psLoginName)
        {
            return ActiveDirectoryHelper.Instancia.GetUserByLoginName(ValidarNombreUsuario(psLoginName));
        }

        /// <summary>
        /// Metodo que obtiene los datos de los usuarios que no están cargados en sistema desde el AD
        /// </summary>
        /// <param name="peType">Tipo de Usuario Grupo / Usuario</param>
        /// <param name="psCriteria">Nombre de Usuario / Grupo</param>
        /// <returns>Retorna el listado de usuarios disponibles para ser cargados</returns>
        public DataTable CargarUsuario(eLDAPFilterType peType, string psCriteria)
        {
            DataTable mTableAD = new DataTable();
            mTableAD.Columns.Add("Guid", typeof(string));
            mTableAD.Columns.Add("Loguin", typeof(string));
            foreach (KeyValuePair<string, string> dListadoColumna in ActiveDirectoryHelper.Instancia.getItemsInLDAP(peType, psCriteria))
            {
                if (!Portal.PortalFacade.Singleton.UsuarioController.ExisteUsuarioSistema(dListadoColumna.Key))
                {
                    DataRow mRow = mTableAD.NewRow();
                    mRow["Guid"] = dListadoColumna.Key;
                    mRow["Loguin"] = dListadoColumna.Value;
                    mTableAD.Rows.Add(mRow);
                    mRow = null;
                }
            }
            return mTableAD;
        }

        public DataTable CargarUsuariosEmailAD(eLDAPFilterType peType, string psCriteria)
        {
            DataTable mTableAD = new DataTable();
            mTableAD.Columns.Add("Guid", typeof(string));
            mTableAD.Columns.Add("Loguin", typeof(string));
            foreach (KeyValuePair<string, string> dListadoColumna in ActiveDirectoryHelper.Instancia.getItemsInLDAPMail(peType, psCriteria))
            {
                if (Portal.PortalFacade.Singleton.UsuarioController.ExisteUsuarioSistema(dListadoColumna.Key))
                {
                    DataRow mRow = mTableAD.NewRow();
                    mRow["Guid"] = dListadoColumna.Key;
                    mRow["Loguin"] = dListadoColumna.Value;
                    mTableAD.Rows.Add(mRow);
                    mRow = null;
                }
            }
            return mTableAD;
        }


        #endregion

        public string ObtenerPerfil(Dictionary<int, Perfil> pPerfiles, int piIdSistema)
        {
            foreach (KeyValuePair<int,Perfil> mListado in pPerfiles)
            {
                if(mListado.Value.IdSistema == piIdSistema)
                return mListado.Value.Descripcion;
            }
            return "";
        }

        public string ObtenerUrlPerfil(Dictionary<int, Perfil> pPerfiles, int piIdSistema)
        {
            foreach (KeyValuePair<int, Perfil> mListado in pPerfiles)
            {
                if (mListado.Value.IdSistema == piIdSistema)
                    return mListado.Value.PaginaDefecto.Url;
            }
            return "default.aspx";
        }
    }
}
