using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Configuration;
using Portal.Domain.Object;

namespace Portal.PersistenceHelper
{
    public class ActiveDirectoryHelper
    {
        private static ActiveDirectoryHelper mInstancia;
        public static ActiveDirectoryHelper Instancia
        {
            get
            {
                if (mInstancia == null)
                {
                    mInstancia = new ActiveDirectoryHelper();
                } return mInstancia;
            }
        }
        private DirectoryEntry _directoryEntry = null;
        private DirectoryEntry SearchRoot
        {
            get
            {
                if (_directoryEntry == null)
                {
                    _directoryEntry = new DirectoryEntry(LDAPPath, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);
                } return _directoryEntry;
            }
        }
        private String LDAPPath
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAPPath"];
            }
        }

        private String LDAPUser
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAPUser"];
            }
        }
        private String LDAPPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAPPassword"];
            }
        }
        public String Domain
        {
            get
            {
                return LDAPDomain;
            }
        }
        private String LDAPDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAPDomain"];
            }
        }
        internal ADUserDetail GetUserByFullName(String userName)
        {
            try
            {
                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Filter = "(&(objectClass=user)(cn=" + userName + "))";
                SearchResult results = directorySearch.FindOne(); if (results != null)
                {
                    DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword); 
                    return ADUserDetail.GetUser(user);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }
        }
        /// <summary>
        /// Metodo que valida que el usuario exista en AD
        /// </summary>
        /// <param name="psUserName"></param>
        /// <returns></returns>
        public bool ValidUserByLoginName(String psUserName)
        {
            try
            {
                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Filter = "(&(objectClass=user)(" + ADProperties.LOGINNAME + "=" + psUserName + "))";
                SearchResult results = directorySearch.FindOne(); 
                if (results != null)
                {
                    DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);
                    return (!Convert.ToBoolean(user.InvokeGet(ADProperties.ACCOUNTLOCKED))) ? true : false;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }
        }
        public bool ValidUserByLoginName(string username, string pwd)
        {
            string domainAndUsername = LDAPDomain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(LDAPPath, domainAndUsername, pwd);
            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(" + ADProperties.LOGINNAME + "=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    search.Dispose();
                    return false;
                }
                result = null;
                search.Dispose();
                search = null;
            }
            catch
            {
                return false;
                //throw new Exception("Error authenticating user. " + ex.Message);
            }
            finally
            {
                entry.Close();
                entry.Dispose();
            }
            return true;
        }
        public ADUserDetail GetUserByLoginName(String userName)
        {
            try
            {
                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Filter = "(&(objectClass=user)(" + ADProperties.LOGINNAME + "=" + userName + "))";
                SearchResult results = directorySearch.FindOne(); if (results != null)
                {
                    DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);
                    return ADUserDetail.GetUser(user);
                } 
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }
        }
        public static string ConvertGuidToOctectString(string objectGuid)
        {
            System.Guid guid = new Guid(objectGuid);
            byte[] byteGuid = guid.ToByteArray();
            string queryGuid = "";
            foreach (byte b in byteGuid)
            {
                queryGuid += @"\" + b.ToString("x2");
            }
            return queryGuid;
        }
        public ADUserDetail GetUserByGuid(String psGuid)
        {
            try
            {
                string filter = "";
                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Asynchronous = true;
                directorySearch.CacheResults = true;
                filter = string.Format("(" + ADProperties.OBJECTGUID + "={0})", ConvertGuidToOctectString(psGuid));//filter = "(&(objectClass=user)(objectCategory=person)(givenName="+fName+ "*))";
                directorySearch.Filter = filter;
                SearchResult results = directorySearch.FindOne(); 
                if (results != null)
                {
                    DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword); 
                    return ADUserDetail.GetUser(user);
                } 
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }
        }
        /// <summary>
        /// This function will take a DL or Group name and return list of users
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public List<ADUserDetail> GetUserFromGroup(String groupName)
        {
            List<ADUserDetail> userlist = new List<ADUserDetail>(); 
            try
            {
                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Filter = "(&(objectClass=group)(" + ADProperties.LOGINNAME + "=" + groupName + "))";
                SearchResult results = directorySearch.FindOne(); if (results != null)
                {

                    DirectoryEntry deGroup = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);
                    System.DirectoryServices.PropertyCollection pColl = deGroup.Properties; int count = pColl["member"].Count; for (int i = 0; i < count; i++)
                    {
                        string respath = results.Path; string[] pathnavigate = respath.Split("CN".ToCharArray());
                        respath = pathnavigate[0]; string objpath = pColl["member"][i].ToString(); string path = respath + objpath;


                        DirectoryEntry user = new DirectoryEntry(path, LDAPUser, LDAPPassword);
                        ADUserDetail userobj = ADUserDetail.GetUser(user);
                        userlist.Add(userobj);
                        user.Close();
                    }
                } 
                return userlist;
            }
            catch
            {
                return userlist;
            }
            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }

        }
        #region Get user with First Name
        public List<ADUserDetail> GetUsersByFirstName(string fName)
        {//UserProfile user;
            List<ADUserDetail> userlist = new List<ADUserDetail>();
            try
            {
                string filter = "";

                _directoryEntry = null;
                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);
                directorySearch.Asynchronous = true;
                directorySearch.CacheResults = true;
                filter = string.Format("(givenName={0}*", fName);//filter = "(&(objectClass=user)(objectCategory=person)(givenName="+fName+ "*))";
                directorySearch.Filter = filter;

                SearchResultCollection userCollection = directorySearch.FindAll(); 
                foreach (SearchResult users in userCollection)
                {
                    DirectoryEntry userEntry = new DirectoryEntry(users.Path, LDAPUser, LDAPPassword);
                    ADUserDetail userInfo = ADUserDetail.GetUser(userEntry);

                    userlist.Add(userInfo);

                }

                directorySearch.Filter = "(&(objectClass=group)(" + ADProperties.LOGINNAME + "=" + fName + "*))";
                SearchResultCollection results = directorySearch.FindAll(); if (results != null)
                {
                    foreach (SearchResult r in results)
                    {
                        DirectoryEntry deGroup = new DirectoryEntry(r.Path, LDAPUser, LDAPPassword);

                        ADUserDetail agroup = ADUserDetail.GetUser(deGroup);
                        userlist.Add(agroup);
                    }

                } 
                return userlist;
            }
            catch
            {
                return userlist;
            }

            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }
        }
        #endregion
        #region AddUserToGroup
        public bool AddUserToGroup(string userlogin, string groupName)
        {
            try
            {
                _directoryEntry = null;
                ADManager admanager = new ADManager(LDAPDomain, LDAPUser, LDAPPassword);
                admanager.AddUserToGroup(userlogin, groupName); return true;
            }
            catch
            {
                return false;
            }

            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }
        }
        #endregion
        #region RemoveUserToGroup
        public bool RemoveUserToGroup(string userlogin, string groupName)
        {
            try
            {
                _directoryEntry = null;
                ADManager admanager = new ADManager("xxx", LDAPUser, LDAPPassword);
                admanager.RemoveUserFromGroup(userlogin, groupName); return true;
            }
            catch
            {
                return false;
            }

            finally
            {
                _directoryEntry.Close();
                _directoryEntry.Dispose();
            }
        }
        #endregion
        #region[Filtros]
        public string getLDAPFilterString(eLDAPFilterType peType, string psFilter)
        {
            psFilter = psFilter.Replace("&", "");
            psFilter = psFilter.Replace("|", "");
            psFilter = psFilter.Replace("*", "");
            string FilterByName = "(" + ADProperties.LOGINNAME + "=*{0}*)";
            string f = string.Empty;
            switch (peType)
            {
                case eLDAPFilterType.OnlyUsers:
                    f = "(&(objectCategory=person)(objectClass=user){0})";
                    break;
                case eLDAPFilterType.OnlyGroups:
                    f = "(&(objectCategory=Group){0})";
                    break;
                case eLDAPFilterType.UsersAndGroups:
                    f = "(|(&(objectCategory=person)(objectClass=user){0})(&(objectCategory=Group){0}))";
                    break;
            }
            if (psFilter == string.Empty)
            {
                return string.Format(f, string.Empty);
            }
            else
            {
                return string.Format(f, string.Format(FilterByName, psFilter));
            }
        }
        /// <summary>
        /// Metodo que obtiene el listado de elementos del AD, donde el primer elemento es el objectGUID y el segundo " + ADProperties.LOGINNAME + "
        /// </summary>
        /// <param name="peType">Tipo de Busqueda, Grupo, Personas o todos</param>
        /// <param name="psCriteria">Texto de filtro de busqueda</param>
        /// <returns>Diccionario con todos elementos encontrados en la busqueda</returns>
        public Dictionary<string,string> getItemsInLDAP(eLDAPFilterType peType, string psCriteria)
        {
            Dictionary<string, string> lItems = new Dictionary<string, string>();
            DirectorySearcher dSearcher;
            _directoryEntry = null;
                string filter = getLDAPFilterString(peType, psCriteria);
                dSearcher = new DirectorySearcher(_directoryEntry, filter);
            
            try
            {
                foreach (SearchResult result in dSearcher.FindAll())
                {
                    DirectoryEntry entry = result.GetDirectoryEntry();
                    
                    //Guid mGuid = new Guid(entry.NativeGuid);
                    Guid mGuid = entry.Guid;

                    if (result.Properties[ADProperties.DISPLAYNAME].Count > 0)
                        lItems.Add(mGuid.ToString(), (string)result.Properties[ADProperties.DISPLAYNAME][0]);
                    entry = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lItems;
        }
        #endregion

        #region[pormail]
        internal IEnumerable<KeyValuePair<string, string>> getItemsInLDAPMail(eLDAPFilterType peType, string psCriteria)
        {
            Dictionary<string, string> lItems = new Dictionary<string, string>();
            DirectorySearcher dSearcher;
            _directoryEntry = null;
            string filter = getLDAPFilterString(peType, psCriteria);
            dSearcher = new DirectorySearcher(_directoryEntry, filter);

            try
            {
                foreach (SearchResult result in dSearcher.FindAll())
                {
                    DirectoryEntry entry = result.GetDirectoryEntry();

                    //Guid mGuid = new Guid(entry.NativeGuid);
                    Guid mGuid = entry.Guid;

                    if (result.Properties[ADProperties.EMAILADDRESS].Count > 0)
                        lItems.Add(mGuid.ToString(), (string)result.Properties[ADProperties.EMAILADDRESS][0]);
                    entry = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lItems;
        }
        #endregion
    }
}
