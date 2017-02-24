using EdD.WrLoginRRHH;
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace EdD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Unnamed1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            int res;
            string strHostName = string.Empty;
            string strIPlocal  = string.Empty;
            strHostName = System.Net.Dns.GetHostName();
            System.Net.IPAddress[] hostIPs = System.Net.Dns.GetHostAddresses(strHostName);
            for (int i = 0; i < hostIPs.Length; i++)
                if (hostIPs[i].AddressFamily.ToString() == "InterNetwork")
                {
                    strIPlocal = hostIPs[i].ToString();
                    break;
                }

            WrLoginRRHH.WsLoginRRHH respuestaWS = new WrLoginRRHH.WsLoginRRHH();
            Status respWS = respuestaWS.AutenticarUsuario(Login1.UserName.ToString(), Login1.Password.ToString(), strIPlocal, strHostName);
            if (respWS.Codigo == 1)
            {
                DatosUsr respWS2 = new DatosUsr();
                respWS2 = respWS.DatosUsuario;

                Response.Cookies["IdMaestroUsuario"].Value = respWS2.IdMaestroUsuario.ToString();
                Response.Cookies["Nombre"].Value = respWS2.Nombre;
                Response.Cookies["Cargo"].Value = respWS2.Cargo;
                Response.Cookies["Area"].Value = respWS2.Area;
                Response.Cookies["Correo"].Value = respWS2.Correo;
                Response.Cookies["IdMaestroJefe"].Value = respWS2.IdMaestroJefe.ToString();
                Response.Cookies["Estado"].Value = respWS2.Estado;

                Response.Cookies["IdMaestroUsuario"].Expires = System.DateTime.Now.AddDays(1);
                Response.Cookies["Nombre"].Expires = System.DateTime.Now.AddDays(1);
                Response.Cookies["Cargo"].Expires = System.DateTime.Now.AddDays(1);
                Response.Cookies["Area"].Expires = System.DateTime.Now.AddDays(1);
                Response.Cookies["Correo"].Expires = System.DateTime.Now.AddDays(1);
                Response.Cookies["IdMaestroJefe"].Expires = System.DateTime.Now.AddDays(1);
                Response.Cookies["Estado"].Expires = System.DateTime.Now.AddDays(1);

                e.Authenticated = true;
                if (respWS2.IdMaestroUsuario == 104) Response.Redirect("eddpaneladmin.aspx");
                else
                {
                    res=actualiza_usuario(respWS2.IdMaestroUsuario, respWS2.Nombre, respWS2.IdMaestroJefe, respWS2.Cargo, respWS2.Area);
                    Response.Redirect("eddpanel.aspx");
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }
        protected int actualiza_usuario(int idusuario, string nombre , int idjefe, string cargo, string area)
        {
            var SqlText = "execute [dbo].[GUARDA_USUARIO] " + idusuario+","+ idjefe+",'"+nombre+"','"+cargo+"','"+area+"'";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return 0;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return 0; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return 1;
        }
    }
}