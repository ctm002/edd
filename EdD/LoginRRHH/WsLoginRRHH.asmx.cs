using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EdD.LoginRRHH
{
    /// <summary>
    /// Summary description for WsLoginRRHH
    /// </summary>
    [WebService(Namespace = "http://viisdesa/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WsLoginRRHH : System.Web.Services.WebService
    {
        [WebMethod]
        public Status AutenticarUsuario(string User, string Pwrd, string IP, string UserPC)
        {
            //User = "admin1"; Pwrd = "12";
            Status respuesta = new Status();
            if (User == "gerente" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 100;
                respDatos.Nombre = "Gerente";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "grrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 0;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "subgerente" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 101;
                respDatos.Nombre = "Subgerente";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "subg@weekmark.cl";
                respDatos.IdMaestroJefe = 100;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "subgerente2" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 105;
                respDatos.Nombre = "Subgerente 2";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "subg2@weekmark.cl";
                respDatos.IdMaestroJefe = 100;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin1" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 102;
                respDatos.Nombre = "Admin1";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin1rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin2" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 103;
                respDatos.Nombre = "Admin2";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin2rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin3" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 106;
                respDatos.Nombre = "Admin3";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin4" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 107;
                respDatos.Nombre = "Admin4";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin5" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 108;
                respDatos.Nombre = "Admin5";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin6" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 109;
                respDatos.Nombre = "Admin6";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin7" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 110;
                respDatos.Nombre = "Admin7";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin8" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 111;
                respDatos.Nombre = "Admin8";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin9" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 112;
                respDatos.Nombre = "Admin9";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin10" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 113;
                respDatos.Nombre = "Admin10";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin11" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 114;
                respDatos.Nombre = "Admin11";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "admin12" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 115;
                respDatos.Nombre = "Admin12";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin3rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 101;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else if (User == "super" && Pwrd == "12")
            {
                respuesta.Codigo = 1;
                respuesta.Descripcion = "Exitoso";
                DatosUsr respDatos = new DatosUsr();
                // respDatos.IdMaestroUsuario = 174;
                respDatos.IdMaestroUsuario = 104;
                respDatos.Nombre = "SUPER";
                // respDatos.Cargo = "Administrativo";
                respDatos.Cargo = "Rol de Prueba";
                respDatos.Area = "RRHH";
                respDatos.Correo = "admin2rrhh@weekmark.cl";
                respDatos.IdMaestroJefe = 100;
                respDatos.Estado = "Activo";
                respuesta.DatosUsuario = respDatos;
                return respuesta;
            }
            else
            {
                respuesta.Codigo = 4;
                respuesta.Descripcion = "Error AD Usuario/Password/No Existe";
                return respuesta;
            }
        }



        public class Status
        {
            public int Codigo { get; set; }
            public string Descripcion { get; set; }
            public DatosUsr DatosUsuario { get; set; }
        }

        public class DatosUsr
        {
            public int IdMaestroUsuario { get; set; }
            public string Nombre { get; set; }
            public string Cargo { get; set; }
            public string Area { get; set; }
            public string Correo { get; set; }
            public int IdMaestroJefe { get; set; }
            public string Estado  { get; set; }
        }

    }
}
