using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using EdD.Modelo;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Json;

namespace EdD.Servicios
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class edddatosperf : System.Web.Services.WebService
    {

        [WebMethod]
        public List<perfil> leer_perfil(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_PERFIL] " + usuario;
            List<perfil> perfilcv = new List<perfil>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return perfilcv;
                }
            }
            if( connString == null) { Console.WriteLine("No connection string"); return perfilcv; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            if (sqlReader.Read())
            {
                perfilcv.Add(new perfil
                {
                    cv_id = sqlReader["cv_id"].ToString().Trim(),
                    cv_ad= sqlReader["cv_ad"].ToString().Trim(),
                    cv_datos = sqlReader["cv_datos"].ToString(),
                    cv_estado = sqlReader["cv_estado"].ToString(),
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            return perfilcv;
        } // fin leer_perfil

        [WebMethod]
        public int guardar_perfil( Int32 cvad, string datosperfil )
        {
            var SqlText = "execute [dbo].[GUARDA_PERFIL] " + cvad + ", '" + datosperfil+"'";          

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
        } // fin guardar_perfil

        [WebMethod]
        public List<eval> lee_eval()
        {
            var SqlText = "execute [dbo].[LEE_EVAL] ";
            List<eval> evaledd = new List<eval>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return evaledd;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return evaledd; }
          
            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            if (sqlReader.Read())
            {
                
                evaledd.Add(new eval
                {
                  eval_fecha_inicio = sqlReader["eval_fecha_inicio"].ToString(),
                  eval_fecha_primera_evaluacion = sqlReader["eval_termino_primera_evaluacion"].ToString(),
                  eval_fecha_intermedio = sqlReader["eval_termino_segunda_evaluacion"].ToString(),
                  eval_fecha_termino = sqlReader["eval_fecha_termino"].ToString(),
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return evaledd;
        } // fin leer_eval

        [WebMethod]
        public List<obj> lee_obj(Int32 usuario, Int32 evalid, Int32 numobj )
        {
            var SqlText = "execute [dbo].[LEE_OBJ] " + usuario + ", " + evalid + ", " + numobj;
            List<obj> objusuario = new List<obj>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return objusuario;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return objusuario; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            if (sqlReader.Read())
            {
                objusuario.Add(new obj
                {              
                    obj_tabla1 = sqlReader["obj_tabla1"].ToString(),
                    obj_tabla2 = sqlReader["obj_tabla2"].ToString(),
                    obj_tabla3 = sqlReader["obj_tabla3"].ToString(),
                    obj_tabla4 = sqlReader["obj_tabla4"].ToString(),
                    obj_tabla5 = sqlReader["obj_tabla5"].ToString(),
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            return objusuario;
        } // fin leer_obj
        [WebMethod]
        public int guarda_obj(Int32 cvad, Int32 evalid, Int32 numobj, string tabla1, string tabla2, string tabla3, string tabla4, string tabla5  )
        {
            var SqlText = "execute [dbo].[GUARDA_OBJ] " + cvad + "," + evalid + "," + numobj + ", '" + tabla1 + "', '" + tabla2 + "', '" + tabla3 + "', '" + tabla4 + "', '" + tabla5 + "'";

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
        } // fin guardar_obj
        [WebMethod]
        public string lee_mensaje(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_MSJ] " + usuario;

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return "";
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return ""; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            string msj;
            msj = "";
            if (sqlReader.Read())
            {
                msj = sqlReader["eval_mensaje_bienvenida"].ToString();
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            return msj;
        } // fin leer_mensaje

        [WebMethod]
        public string lee_bienvenida()
        {
            var SqlText = "execute [dbo].[LEE_BIENVENIDA] ";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return "";
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return ""; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            string msj;
            msj = "";
            if (sqlReader.Read())
            {
                msj = sqlReader["eval_mensaje_bienvenida"].ToString();
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            return msj;
        } // fin leer_bienvenida

        [WebMethod]
        public string lee_estado_obj(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_ESTADO_OBJ] " + usuario;
            var estado_obj = "0";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return estado_obj;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return estado_obj; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            if (sqlReader.Read())
            {
                estado_obj = sqlReader["estado_obj"].ToString();
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return estado_obj;
        } // fin lee_estado_obj

        [WebMethod]
        public string lee_estado_comp(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_ESTADO_COMP] " + usuario;
            var estado_comp = "0";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return estado_comp;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return estado_comp; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            if (sqlReader.Read())
            {
                estado_comp = sqlReader["evalusr_estado_evaluacion"].ToString();
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return estado_comp;
        } // fin lee_estado_comp

        [WebMethod]
        public string leer_jefatura(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_JEFATURA] " + usuario;
            var jefatura = "";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return jefatura;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return jefatura; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            if (sqlReader.Read())
            {
                jefatura = sqlReader["usuario_nombre"].ToString();
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return jefatura;
        } // fin lee_jefatura

        [WebMethod]
        public List<revisa> lee_revisa_obj(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_REVISA_OBJ] " + usuario;
            List<revisa> estado = new List<revisa>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return estado;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return estado; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                estado.Add(new revisa
                {
                    rev_ad = sqlReader["id_ad"].ToString(),
                    rev_nombre = sqlReader["usuario_nombre"].ToString(),
                    rev_estado = sqlReader["estado_obj"].ToString(),
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            return estado;
        } // fin leer_revisa_obj

        [WebMethod]
        public List<revisa> lee_revisa_comp(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_REVISA_COMP] " + usuario;
            List<revisa> estado = new List<revisa>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return estado;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return estado; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                estado.Add(new revisa
                {
                    rev_ad = sqlReader["usuario_ad"].ToString(),
                    rev_nombre = sqlReader["usuario_nombre"].ToString(),
                    rev_estado = sqlReader["evalusr_estado_evaluacion"].ToString(),
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            return estado;
        } // fin leer_revisa_comp

        [WebMethod]
        public string actualiza_estado_obj(Int32 usuario, Int32 estado)
        {
            var SqlText = "execute [dbo].[ACTUALIZA_ESTADO_OBJ] " + usuario + "," + estado;

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return "Error";
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return "Error"; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            string actividad="";
            string est="";

            if(estado == 0) { actividad = "Completando Objetivos Inicial"; est = "PENDIENTE"; }
            else
            if(estado == 1) { actividad = "Objetivos Inicial enviado a Jefatura"; est = "REVISION"; }
            else
            if(estado == 2) { actividad = "Objetivos Inicial Aprobado por Jefatura"; est = "APROBADO"; }
            else
            if(estado == 3) { actividad = "Objetivos Inicial Rechazado por Jefatura"; est = "RECHAZADO"; }
            else
            if(estado == 4) { actividad = "Objetivos Intermedio enviado a Jefatura"; est = "REVISION"; }
            else
            if(estado == 5) { actividad = "Objetivos Intermedio Aprobado por Jefatura"; est = "APROBADO"; }
            else
            if(estado == 6) { actividad = "Objetivos Intermedio Rechazado por Jefatura"; est = "RECHAZADO"; }
            else
            if(estado == 7) { actividad = "Objetivos Final enviado a Jefatura"; est = "REVISION"; }
            else
            if(estado == 8) { actividad = "Objetivos Final Aprobado por Jefatura"; est = "APROBADO"; }
            else
            if(estado == 9) { actividad = "Objetivos Final Rechazado por Jefatura"; est = "RECHAZADO"; }
            else
            {
                actividad = "Objetivos Final Aprobado por Jefatura"; est = "APROBADO";
            }

            SqlText = "execute [dbo].[GUARDA_LOG] " + usuario + ",'" + actividad + "','" + est + "'";
            SqlConnection cn1 = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd1 = new SqlCommand(SqlText, cn1);
            cmd1.Connection.Open();
            sqlReader = cmd1.ExecuteReader();
            cn1.Dispose();
            cn1.Close();
            sqlReader.Close();

            return "Ok";
        } // fin actualiza_estado_obj

        [WebMethod]
        public List<competencias> lee_cargo_comp(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_CARGO_COMP] " + usuario;
            List<competencias> comp = new List<competencias>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return comp;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return comp; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                comp.Add(new competencias
                {
                    cargo_id = sqlReader["cargo_cap_ncap"].ToString(),
                    cargo_desc = sqlReader["cargo_cap_descripcion"].ToString()
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            return comp;
        } // fin lee_cargo_comp

        [WebMethod]
        public string actualiza_estado_comp(Int32 usuario, Int32 estado)
        {
            var SqlText = "execute [dbo].[ACTUALIZA_ESTADO_COMP] " + usuario + "," + estado;

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return "Error";
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return "Error"; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            cn.Dispose();
            cn.Close();
            sqlReader.Close();

            string actividad = "";
            string est = "";

            if (estado == 0) { actividad = "Completando Competencias Inicial"; est = "PENDIENTE"; }
            else
            if (estado == 1) { actividad = "Competencias Inicial enviado a Jefatura"; est = "REVISION"; }
            else
            if (estado == 2) { actividad = "Competencias Inicial Aprobado por Jefatura"; est = "APROBADO"; }
            else
            if (estado == 3) { actividad = "Competencias Inicial Rechazado por Jefatura"; est = "RECHAZADO"; }
            else
            if (estado == 4) { actividad = "Competencias Final enviado a Jefatura"; est = "REVISION"; }
            else
            if (estado == 5) { actividad = "Competencias Final Aprobado por Jefatura"; est = "APROBADO"; }
            else
            if (estado == 6) { actividad = "Competencias Final Rechazado por Jefatura"; est = "RECHAZADO"; }
            else
            {
                actividad = "Competencias Final Aprobado por Jefatura"; est = "APROBADO";
            }

            SqlText = "execute [dbo].[GUARDA_LOG] " + usuario + ",'" + actividad + "','" + est + "'";
            SqlConnection cn1 = new SqlConnection(connString.ConnectionString);
            var cmd1 = new SqlCommand(SqlText, cn1);
            cmd1.Connection.Open();
            sqlReader = cmd1.ExecuteReader();
            cn1.Dispose();
            cn1.Close();
            sqlReader.Close();

            return "Ok";
        } // fin actualiza_estado_comp

        [WebMethod]
        public List<regcomp> lee_competencias(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_COMPETENCIAS] " + usuario;
            List<regcomp> comp = new List<regcomp>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return comp;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return comp; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                comp.Add(new regcomp
                {
                    comp_id = sqlReader["cap_cargo_id"].ToString(),
                    comp_desc = sqlReader["cargo_cap_descripcion"].ToString(),
                    comp_inicial_consensuada = sqlReader["cap_eval_inicial_consensuada"].ToString(),
                    comp_inicial_comentario = sqlReader["cap_eval_inicial_comentario"].ToString(),
                    comp_inicial_plan_accion = sqlReader["cap_eval_inicial_plan_accion"].ToString(),
                    comp_inicial_jefe = sqlReader["cap_eval_inicial_jefe"].ToString(),
                    comp_final_consensuada = sqlReader["cap_eval_final_consensuada"].ToString(),
                    comp_final_comentario = sqlReader["cap_eval_final_comentario"].ToString(),
                    comp_final_plan_accion = sqlReader["cap_eval_final_plan_accion"].ToString(),
                    comp_final_jefe = sqlReader["cap_eval_final_jefe"].ToString()
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return comp;
        } // fin lee_competencias

        [WebMethod]
        public string actualiza_comp(Int32 id, Int32 usuario, Int32 evalid, Int32 cargo, string eval_inicial_consensuada, string eval_inicial_plan_accion,
            string eval_inicial_comentario, string eval_inicial_jefe, string eval_final_consensuada,
            string eval_final_plan_accion, string eval_final_comentario, string eval_final_jefe)
        {
            var SqlText = "execute [dbo].[ACTUALIZA_COMPETENCIAS] " + id + "," + usuario + "," + evalid + "," + cargo + ","
                + eval_inicial_consensuada + ",'" + eval_inicial_plan_accion + "','" + eval_inicial_comentario + "','" + eval_inicial_jefe + "',"
                + eval_final_consensuada + ",'" + eval_final_plan_accion + "','" + eval_final_comentario + "','" + eval_final_jefe+"'";

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return "Error";
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return "Error"; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return "Ok";
        } // fin graba_competencias

        [WebMethod]
        public string hay_obj(Int32 usuario)
        {
            var SqlText = "execute [dbo].[HAY_OBJ] " + usuario;
            var contador="0";
            
            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return contador;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return contador; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            if (sqlReader.Read())
            {
                contador = sqlReader[0].ToString();
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return contador;
        } // fin hay_obj
        [WebMethod]
        public string hay_comp(Int32 usuario)
        {
            var SqlText = "execute [dbo].[HAY_COMP] " + usuario;
            var contador = "0";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return contador;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return contador; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            if (sqlReader.Read())
            {
                contador = sqlReader[0].ToString();
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return contador;
        } // fin hay_comp

        [WebMethod]
        public string act_eval(string fecuno, string fecdos)
        {
            var SqlText = "execute [dbo].[ACTUALIZA_EVAL] '" + fecuno + "','" + fecdos+"'";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return "Error";
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return "Error"; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return "OK";
        } // fin act_eval

        [WebMethod]
        public string guarda_log(int trabajador, string actividad, string estado)
        {
            var SqlText = "execute [dbo].[GUARDA_LOG] " + trabajador + ",'" + actividad + "','" + estado + "'";

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return "Error";
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return "Error"; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);

            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return "OK";
        } // fin guarda_log

        [WebMethod]
        public List<reglog> lee_log(Int32 usuario)
        {
            var SqlText = "execute [dbo].[LEE_LOG] " + usuario;
            List<reglog> comp = new List<reglog>();

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return comp;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return comp; }

            SqlConnection cn = new SqlConnection(connString.ConnectionString);
            SqlCommand cmd = new SqlCommand(SqlText, cn);
            cmd.Connection.Open();
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                comp.Add(new reglog
                {
                    log_fecha = sqlReader["log_fecha"].ToString(),
                    log_actividad = sqlReader["log_actividad"].ToString(),
                    log_estado = sqlReader["log_estado"].ToString(),
                    usuario_nombre = sqlReader["usuario_nombre"].ToString()
                });
            }
            cn.Dispose();
            cn.Close();
            sqlReader.Close();
            return comp;
        } // fin lee_logjefe

        [WebMethod]
        public List<Google_org_data> getOrgData()
        {
            List<Google_org_data> g = new List<Google_org_data>();

            g.Add(new Google_org_data
            {
                Employee = "Gerente General",
                Manager = "Nombre",
                mgrID = "",
                empID = "100",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Subgerente",
                Manager = "Nombre",
                mgrID = "100",
                empID = "101",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin1",
                Manager = "Nombre",
                mgrID = "101",
                empID = "102",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin2",
                Manager = "Nombre",
                mgrID = "101",
                empID = "103",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin3",
                Manager = "Nombre",
                mgrID = "101",
                empID = "106",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin4",
                Manager = "Nombre",
                mgrID = "101",
                empID = "107",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin5",
                Manager = "Nombre",
                mgrID = "101",
                empID = "108",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin6",
                Manager = "Nombre",
                mgrID = "101",
                empID = "109",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin7",
                Manager = "Nombre",
                mgrID = "101",
                empID = "110",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin8",
                Manager = "Nombre",
                mgrID = "101",
                empID = "111",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin9",
                Manager = "Nombre",
                mgrID = "101",
                empID = "112",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin10",
                Manager = "Nombre",
                mgrID = "101",
                empID = "113",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin11",
                Manager = "Nombre",
                mgrID = "101",
                empID = "114",
                designation = ""
            });
            g.Add(new Google_org_data
            {
                Employee = "Admin12",
                Manager = "Nombre",
                mgrID = "101",
                empID = "115",
                designation = ""
            });

            g.Add(new Google_org_data
            {
                Employee = "Subgerente 2",
                Manager = "Nombre",
                mgrID = "100",
                empID = "105",
                designation = ""
            });

            return g;
        } //fin GetOrgData

    }
}
