using EdD.App_Code;
using Portal;
using System;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace EdD.AD
{
    /// <summary>
    /// Summary description for WSAuth
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WSAuth : System.Web.Services.WebService
    {

        [WebMethod]
        public void AutenticarUsuario(string pUserName, string pPassword)
        {
            try
            {
                if(string.IsNullOrEmpty(pUserName)) pUserName = "carlos_tapia";
                if (string.IsNullOrEmpty(pPassword)) pUserName = "P3l3qu3n1277";
                var usuarioController = PortalFacade.Singleton.AutenticacionController;
                bool isAuth = usuarioController.AutenticarUsuario(pUserName, pPassword);
                if (!isAuth) throw new Exception("El usuario no se encuentra en el active directory");

                Usuario u = UsuarioRepository.Instance.GetUsuarioByUserName(pUserName);
                if (u == null) throw new Exception("El usuario no se encuentra en la tabla usuario");

                var result = new JavaScriptSerializer().Serialize(u);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(result);
            }
            catch (Exception ex)
            {
                var result = new JavaScriptSerializer().Serialize(ex.Message);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Flush();
                Context.Response.Write(result);
            }

        }
    }
}