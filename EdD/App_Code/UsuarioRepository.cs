using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EdD.App_Code
{
    public class UsuarioRepository
    {

        static UsuarioRepository _UsuarioADMRepository;

        public static UsuarioRepository Instance
        {
            get
            {
                if (_UsuarioADMRepository == null)
                {
                    _UsuarioADMRepository = new UsuarioRepository();
                }

                return _UsuarioADMRepository;
            }
        }

        public Usuario GetUsuarioByUserName(string pUserName)
        {
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Connection.SQLServer.Administracion"]))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "RRHH_ADM_Usuario_ObtenerXUserName";
                    cmd.Parameters.AddWithValue("@NameUser", pUserName);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Usuario usuario = new Usuario(reader);
                        return usuario;
                    }
                }
            }
            return null;
        }

    }
}