using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Json;

namespace EdD
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //----------------------------
        // CONEXIÓN A LA BASE DE DATOS
        //----------------------------
        string stringConexionBD;
        SqlConnection conexionBD, conexionBD2;
        SqlCommand comandoSql1, comandoSql2;
        string sqlText1, sqlText2;

        //----------------------
        // PERIODO DE EVALUACION
        //----------------------
        int evalId;
        DateTime fechaDia = DateTime.Now;
        DateTime fechaInicio, fechaTermino, fechaPrimeraEvaluacion, fechaSegundaEvaluacion;
        string periodoActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            //----------------------------
            // CONEXIÓN A LA BASE DE DATOS
            //----------------------------
            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return;
                }
            }
            if (connString == null) { Console.WriteLine("No connection string"); return; }

            stringConexionBD = connString.ConnectionString;
            conexionBD = new SqlConnection(stringConexionBD);

            //------------------------------
            // Informacion Proveniente de AD
            //------------------------------
            string ad_IdMaestroUsuario = Request.Cookies["IdMaestroUsuario"].Value;
            string ad_IdMaestroJefe = Request.Cookies["IdMaestroJefe"].Value;
            string ad_Nombre = Request.Cookies["Nombre"].Value;
            string ad_Cargo = Request.Cookies["Cargo"].Value;
            string ad_Estado = Request.Cookies["Estado"].Value;

            if (ad_IdMaestroUsuario == "100" || ad_IdMaestroUsuario =="101" || ad_IdMaestroUsuario == "105" ) Button11.Visible = true;

            //-----------------------------------------
            // OBTIENE FECHAS PARA LA EVALUACIÓN ACTIVA
            //-----------------------------------------
            sqlText1 = "select eval_id, eval_fecha_inicio, eval_fecha_termino, eval_estado_evaluacion, ";
            sqlText1 = sqlText1 + "eval_termino_primera_evaluacion, eval_termino_segunda_evaluacion ";
            sqlText1 = sqlText1 + "from tbl_eval ";
            sqlText1 = sqlText1 + "where eval_estado_evaluacion = 1";
            comandoSql1 = new SqlCommand(sqlText1, conexionBD);
            comandoSql1.Connection.Open();
            var lecturaSql1 = comandoSql1.ExecuteReader();
            var lecturaSql2 = lecturaSql1;
            if (lecturaSql1.Read())
            {
                evalId = (int)lecturaSql1["eval_id"];
                Response.Cookies["evalId"].Value = lecturaSql1["eval_id"].ToString();
                fechaInicio = (DateTime)lecturaSql1["eval_fecha_inicio"];
                fechaTermino = (DateTime)lecturaSql1["eval_fecha_termino"];
                fechaPrimeraEvaluacion = (DateTime)lecturaSql1["eval_termino_primera_evaluacion"];
                fechaSegundaEvaluacion = (DateTime)lecturaSql1["eval_termino_segunda_evaluacion"];

                if (fechaDia < fechaPrimeraEvaluacion.AddDays(-30))
                    periodoActual = "antesEvaluacionInicial";
                else if (fechaDia >= fechaPrimeraEvaluacion.AddDays(-30) && fechaDia <= fechaPrimeraEvaluacion)
                    periodoActual = "EvaluacionInicial";
                else if (fechaDia > fechaPrimeraEvaluacion && fechaDia < fechaSegundaEvaluacion.AddDays(-30))
                    periodoActual = "entreEvaluaciones";
                else if (fechaDia >= fechaSegundaEvaluacion.AddDays(-30) && fechaDia <= fechaSegundaEvaluacion)
                    periodoActual = "EvaluacionFinal";
                else
                    periodoActual = "despuesEvaluacionFinal";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alert('No hay ningún período de evaluación activo.');", true);
                return;
            }
            lecturaSql1.Close();
            comandoSql1.Connection.Close();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("informes.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("edd.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("eddperfil.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("eddcompetencias.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("eddobj.aspx");
        }

        protected void Organigrama(object sender, EventArgs e)
        {
            Response.Redirect("eddorganigrama.aspx");
        }

        protected void Imprimir_Evaluacion(object sender, EventArgs e)
        {
            //--------------
            // BASE DE DATOS
            //--------------
            string stringConexionBD;
            SqlConnection conexionBD;

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/EdD");
            System.Configuration.ConnectionStringSettings connString;
            connString = null;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["eddapp.My.MySettings.edd"];
                if (connString == null)
                {
                    Console.WriteLine("No connection string"); return;
                }
            }
            if (connString.ConnectionString == null) { Console.WriteLine("No connection string"); return; }
            stringConexionBD = connString.ConnectionString;
            conexionBD = new SqlConnection(stringConexionBD);

            //---------
            // Lecturas
            //---------
            SqlCommand comandoSql;
            string sqlText;
            string cv_datos;
            string cv_estado;

            // Leer Datos Perfil
            string ad_IdMaestroUsuario = Request.Cookies["IdMaestroUsuario"].Value;
            sqlText = "SELECT * from tbl_perfil where cv_ad = " + ad_IdMaestroUsuario;
            comandoSql = new SqlCommand(sqlText, conexionBD);
            comandoSql.Connection.Open();
            var lecturaSql = comandoSql.ExecuteReader();

            string nombre1 = "";
            string nombre2 = "";
            string ape1 = "";
            string ape2 = "";
            string nacionalidad = "";
            string cargo = "";
            string area = "";
            string gerencia = "";

            if (lecturaSql.Read())
            {
                cv_datos = (string)lecturaSql["cv_datos"];
                cv_estado = (string)lecturaSql["cv_estado"];

                JsonTextParser parser = new JsonTextParser();
                JsonObject obj = parser.Parse(cv_datos);
                JsonUtility.GenerateIndentedJsonText = false;
                foreach (JsonObject field in obj as JsonObjectCollection)
                {
                    string name = field.Name;
                    // Datos Personales
                    if (name == "nombre1")
                        nombre1 = (string)field.GetValue();
                    else if (name == "nombre2")
                        nombre2 = (string)field.GetValue();
                    else if (name == "ape1")
                        ape1 = (string)field.GetValue();
                    else if (name == "ape2")
                        ape2 = (string)field.GetValue();
                    else if (name == "nacionalidad")
                        nacionalidad = (string)field.GetValue();
                    else if (name == "cargo")
                        cargo = (string)field.GetValue();
                    else if (name == "area")
                        area = (string)field.GetValue();
                    else if (name == "gerencia")
                        gerencia = (string)field.GetValue();
                }
            }
            else
            {
                cv_datos = "";
                cv_estado = "";
            }
            lecturaSql.Close();
            comandoSql.Connection.Close();

            //-----------------------------------------
            // OBTIENE FECHAS PARA LA EVALUACIÓN ACTIVA
            //-----------------------------------------
            sqlText1 = "select eval_id, eval_fecha_inicio, eval_fecha_termino, eval_estado_evaluacion, ";
            sqlText1 = sqlText1 + "eval_termino_primera_evaluacion, eval_termino_segunda_evaluacion ";
            sqlText1 = sqlText1 + "from tbl_eval ";
            sqlText1 = sqlText1 + "where eval_estado_evaluacion = 1";
            comandoSql = new SqlCommand(sqlText1, conexionBD);
            comandoSql.Connection.Open();
            lecturaSql = comandoSql.ExecuteReader();

            if (lecturaSql.Read())
            {
                evalId = (int)lecturaSql["eval_id"];
                fechaInicio = (DateTime)lecturaSql["eval_fecha_inicio"];
                fechaTermino = (DateTime)lecturaSql["eval_fecha_termino"];
                fechaPrimeraEvaluacion = (DateTime)lecturaSql["eval_termino_primera_evaluacion"];
                fechaSegundaEvaluacion = (DateTime)lecturaSql["eval_termino_segunda_evaluacion"];
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alert('No hay ningún período de evaluación activo.');", true);
                return;
            }
            lecturaSql.Close();
            comandoSql.Connection.Close();

            // Leer Datos Objetivos
            sqlText = "SELECT a.obj_tabla1, a.obj_tabla2, a.obj_tabla3, a.obj_tabla4, a.obj_tabla5 from tbl_obj a where a.obj_ad =" + ad_IdMaestroUsuario;
            comandoSql = new SqlCommand(sqlText, conexionBD);
            comandoSql.Connection.Open();
            lecturaSql = comandoSql.ExecuteReader();
            string[,] objetivos = new string[8, 6];
            int io = 1;
            while (lecturaSql.Read())
            {
                objetivos[io, 1] = (string)lecturaSql["obj_tabla1"];
                objetivos[io, 2] = (string)lecturaSql["obj_tabla2"];
                objetivos[io, 3] = (string)lecturaSql["obj_tabla3"];
                objetivos[io, 4] = (string)lecturaSql["obj_tabla4"];
                objetivos[io, 5] = (string)lecturaSql["obj_tabla5"];
                io = io + 1;
            }
            lecturaSql.Close();
            comandoSql.Connection.Close();



            // Leer Datos Competencias
            sqlText = "select cargo_cap_descripcion,";
            sqlText = sqlText + "       cap_eval_inicial_consensuada,";
            sqlText = sqlText + "       cap_eval_inicial_comentario,";
            sqlText = sqlText + "       cap_eval_inicial_plan_accion,";
            sqlText = sqlText + "       cap_eval_inicial_jefe,";
            sqlText = sqlText + "       cap_eval_final_consensuada,";
            sqlText = sqlText + "       cap_eval_final_comentario,";
            sqlText = sqlText + "       cap_eval_final_plan_accion,";
            sqlText = sqlText + "       cap_eval_final_jefe";
            sqlText = sqlText + " from  tbl_competencias, tbl_usuario, tbl_cargo_competencia";
            sqlText = sqlText + " where tbl_competencias.eval_id = " + evalId;
            sqlText = sqlText + "   and tbl_competencias.usuario_id = " + ad_IdMaestroUsuario;
            sqlText = sqlText + "   and tbl_usuario.usuario_ad = " + ad_IdMaestroUsuario;
            sqlText = sqlText + "   and tbl_usuario.rol_id = tbl_cargo_competencia.rol_id";
            sqlText = sqlText + "   and tbl_cargo_competencia.cargo_cap_ncap = tbl_competencias.cap_cargo_id";

            comandoSql = new SqlCommand(sqlText, conexionBD);
            comandoSql.Connection.Open();
            lecturaSql = comandoSql.ExecuteReader();
            int i = 0;
            string[,] comp = new String[10, 12];
            int compval;

            while (lecturaSql.Read())
            {
                // Competencia
                if (lecturaSql["cargo_cap_descripcion"] == DBNull.Value)
                    comp[i, 0] = "";
                else
                    comp[i, 0] = (string)lecturaSql["cargo_cap_descripcion"];

                // Evaluación Inicial
                if (lecturaSql["cap_eval_inicial_consensuada"] == DBNull.Value)
                    comp[i, 1] = "";
                else
                    comp[i, 1] = (string)lecturaSql["cap_eval_inicial_consensuada"];

                // Evaluación Inicial Comentario
                if (lecturaSql["cap_eval_inicial_comentario"] == DBNull.Value)
                    comp[i, 2] = "";
                else
                    comp[i, 2] = (string)lecturaSql["cap_eval_inicial_comentario"];

                // Evaluación Inicial Plan de Acción
                if (lecturaSql["cap_eval_inicial_plan_accion"] == DBNull.Value)
                    comp[i, 3] = "";
                else
                    comp[i, 3] = (string)lecturaSql["cap_eval_inicial_plan_accion"];

                // Evaluación Inicial Jefatura
                if (lecturaSql["cap_eval_inicial_jefe"] == DBNull.Value)
                    comp[i,4] = "";
                else
                    comp[i,4] = (string)lecturaSql["cap_eval_inicial_jefe"];

                // Evaluación Final

                if (lecturaSql["cap_eval_final_consensuada"] == DBNull.Value)
                    comp[i, 8] = "";
                else
                    comp[i, 8] = (string)lecturaSql["cap_eval_final_consensuada"];

                // Evaluación Inicial Comentario
                if (lecturaSql["cap_eval_final_comentario"] == DBNull.Value)
                    comp[i, 9] = "";
                else
                    comp[i, 9] = (string)lecturaSql["cap_eval_final_comentario"];

                // Evaluación Inicial Plan de Acción
                if (lecturaSql["cap_eval_final_plan_accion"] == DBNull.Value)
                    comp[i, 10] = "";
                else
                    comp[i, 10] = (string)lecturaSql["cap_eval_final_plan_accion"];

                // Evaluación Inicial Jefatura
                if (lecturaSql["cap_eval_final_jefe"] == DBNull.Value)
                    comp[i, 11] = "";
                else
                    comp[i, 11] = (string)lecturaSql["cap_eval_final_jefe"];
                i = i + 1;
            }

            //Reporte

            if (cv_datos != "")
            {
                using (MemoryStream ms = new MemoryStream())
                using (Document document = new Document(PageSize.LETTER, 30f, 60f, 10f, 10f))
                using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
                {
                    var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                    var subTitleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                    var boldTableFont = FontFactory.GetFont("Arial", 8, Font.BOLD);
                    var tableFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
                    var tableFont2 = FontFactory.GetFont("Arial", 8, Font.NORMAL);
                    var endingMessageFont = FontFactory.GetFont("Arial", 9, Font.ITALIC);
                    var bodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);

                    // Comienzo Documento
                    int jo;
                    int j;
                    document.Open();

                    // Titulo
                    document.Add(new Paragraph("EVALUACION DE DESEMPEÑO PROFESIONAL", titleFont));
                    document.Add(new Paragraph(" ", titleFont));
                    // Datos Personales
                    document.Add(new Paragraph("DATOS PERSONALES", subTitleFont));
                    var perfilTable = new PdfPTable(2);
                    perfilTable.HorizontalAlignment = 0;
                    perfilTable.SpacingBefore = 4;
                    perfilTable.SpacingAfter = 10;
                    perfilTable.DefaultCell.Border = 0;
                    perfilTable.SetWidths(new int[] { 1, 3 });
                    perfilTable.AddCell(new Phrase("Nombre:", tableFont2));
                    perfilTable.AddCell(new Phrase(nombre1 + " " + nombre2 + " " + ape1 + " " + ape2, tableFont2));
                    perfilTable.AddCell(new Phrase("Nacionalidad:", tableFont2));
                    perfilTable.AddCell(new Phrase(nacionalidad, tableFont2));
                    perfilTable.AddCell(new Phrase("Cargo:", tableFont2));
                    perfilTable.AddCell(new Phrase(cargo, tableFont2));
                    perfilTable.AddCell(new Phrase("Área:", tableFont2));
                    perfilTable.AddCell(new Phrase(area, tableFont2));
                    perfilTable.AddCell(new Phrase("Gerencia:", tableFont2));
                    perfilTable.AddCell(new Phrase(gerencia, tableFont2));
                    document.Add(perfilTable);


                    // OBJETIVOS
                    string categoria = "";
                    string objetivo = "";
                    string logros = "";
                    string medicion = "";
                    string paso31 = "";
                    string paso32 = "";
                    string categoria3 = "";
                    string categoria4 = "";
                    string paso41 = "";
                    string paso42 = "";
                    string categoria5 = "";
                    string pasos51 = "";
                    string notafinaljefatura5 = "";

                    document.Add(new Paragraph("OBJETIVOS", subTitleFont));
                    perfilTable = new PdfPTable(2);
                    perfilTable.HorizontalAlignment = 0;
                    perfilTable.SpacingBefore = 4;
                    perfilTable.SpacingAfter = 10;
                    perfilTable.DefaultCell.Border = 0;
                    perfilTable.SetWidths(new int[] { 75, 75 });
                    if (DateTime.Today < fechaPrimeraEvaluacion)
                    {
                        JsonTextParser parser = new JsonTextParser();
                        for (jo = 1; jo < io; jo++)
                        {
                            //tabla1                          
                            JsonObject obj = parser.Parse(objetivos[jo, 1]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria")
                                    categoria = (string)field.GetValue();
                                if (name == "objetivo")
                                    objetivo = (string)field.GetValue();
                                if (name == "logros")
                                    logros = (string)field.GetValue();
                            }
                            perfilTable.AddCell(new Phrase("Obj.", tableFont2));
                            perfilTable.AddCell(new Phrase(jo.ToString() + ". ", tableFont2));
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria, tableFont2));
                            perfilTable.AddCell(new Phrase("Objetivo", tableFont2));
                            perfilTable.AddCell(new Phrase(objetivo, tableFont2));
                            perfilTable.AddCell(new Phrase("Logros", tableFont2));
                            perfilTable.AddCell(new Phrase(logros, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));

                            //tabla2
                            JsonObject obj1 = parser.Parse(objetivos[jo, 2]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj1 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria3")
                                    categoria3 = (string)field.GetValue();
                                if (name == "medicion")
                                    medicion = (string)field.GetValue();
                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria3, tableFont2));
                            perfilTable.AddCell(new Phrase("Medición", tableFont2));
                            perfilTable.AddCell(new Phrase(medicion, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            //tabla3
                            JsonObject obj3 = parser.Parse(objetivos[jo, 3]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj3 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria3")
                                    categoria3 = (string)field.GetValue();
                                if (name == "paso31")
                                    paso31 = (string)field.GetValue();
                                if (name == "paso32")
                                    paso32 = (string)field.GetValue();

                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria3, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Empleado", tableFont2));
                            perfilTable.AddCell(new Phrase(paso31, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Jefatura", tableFont2));
                            perfilTable.AddCell(new Phrase(paso32, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                        }
                    }
                    else if (DateTime.Today > fechaPrimeraEvaluacion && DateTime.Today < fechaSegundaEvaluacion)
                    {
                        JsonTextParser parser = new JsonTextParser();
                        for (jo = 1; jo < io; jo++)
                        {
                            //tabla1                          
                            JsonObject obj = parser.Parse(objetivos[jo, 1]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria")
                                    categoria = (string)field.GetValue();
                                if (name == "objetivo")
                                    objetivo = (string)field.GetValue();
                                if (name == "logros")
                                    logros = (string)field.GetValue();
                            }
                            perfilTable.AddCell(new Phrase("Obj.", tableFont2));
                            perfilTable.AddCell(new Phrase(jo.ToString() + ". ", tableFont2));
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria, tableFont2));
                            perfilTable.AddCell(new Phrase("Objetivo", tableFont2));
                            perfilTable.AddCell(new Phrase(objetivo, tableFont2));
                            perfilTable.AddCell(new Phrase("Logros", tableFont2));
                            perfilTable.AddCell(new Phrase(logros, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));

                            //tabla2
                            JsonObject obj1 = parser.Parse(objetivos[jo, 2]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj1 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria3")
                                    categoria3 = (string)field.GetValue();
                                if (name == "medicion")
                                    medicion = (string)field.GetValue();
                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria3, tableFont2));
                            perfilTable.AddCell(new Phrase("Medición", tableFont2));
                            perfilTable.AddCell(new Phrase(medicion, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            //tabla3
                            JsonObject obj3 = parser.Parse(objetivos[jo, 3]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj3 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria3")
                                    categoria3 = (string)field.GetValue();
                                if (name == "paso31")
                                    paso31 = (string)field.GetValue();
                                if (name == "paso32")
                                    paso32 = (string)field.GetValue();

                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria3, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Empleado", tableFont2));
                            perfilTable.AddCell(new Phrase(paso31, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Jefatura", tableFont2));
                            perfilTable.AddCell(new Phrase(paso32, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            //tabla 4
                            JsonObject obj4 = parser.Parse(objetivos[jo, 4]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj4 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria4")
                                    categoria4 = (string)field.GetValue();
                                if (name == "paso41")
                                    paso41 = (string)field.GetValue();
                                if (name == "paso42")
                                    paso42 = (string)field.GetValue();

                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria4, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Empleado", tableFont2));
                            perfilTable.AddCell(new Phrase(paso41, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Jefatura", tableFont2));
                            perfilTable.AddCell(new Phrase(paso42, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));

                        }
                    }
                    else
                    {
                        JsonTextParser parser = new JsonTextParser();
                        for (jo = 1; jo < io; jo++)
                        {
                            //tabla1                          
                            JsonObject obj = parser.Parse(objetivos[jo, 1]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria")
                                    categoria = (string)field.GetValue();
                                if (name == "objetivo")
                                    objetivo = (string)field.GetValue();
                                if (name == "logros")
                                    logros = (string)field.GetValue();
                            }
                            perfilTable.AddCell(new Phrase("Obj.", tableFont2));
                            perfilTable.AddCell(new Phrase(jo.ToString() + ". ", tableFont2));
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria, tableFont2));
                            perfilTable.AddCell(new Phrase("Objetivo", tableFont2));
                            perfilTable.AddCell(new Phrase(objetivo, tableFont2));
                            perfilTable.AddCell(new Phrase("Logros", tableFont2));
                            perfilTable.AddCell(new Phrase(logros, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));

                            //tabla2
                            JsonObject obj1 = parser.Parse(objetivos[jo, 2]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj1 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria3")
                                    categoria3 = (string)field.GetValue();
                                if (name == "medicion")
                                    medicion = (string)field.GetValue();
                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria3, tableFont2));
                            perfilTable.AddCell(new Phrase("Medición", tableFont2));
                            perfilTable.AddCell(new Phrase(medicion, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            //tabla3
                            JsonObject obj3 = parser.Parse(objetivos[jo, 3]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj3 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria3")
                                    categoria3 = (string)field.GetValue();
                                if (name == "paso31")
                                    paso31 = (string)field.GetValue();
                                if (name == "paso32")
                                    paso32 = (string)field.GetValue();

                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria3, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Empleado", tableFont2));
                            perfilTable.AddCell(new Phrase(paso31, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Jefatura", tableFont2));
                            perfilTable.AddCell(new Phrase(paso32, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            //tabla 4
                            JsonObject obj4 = parser.Parse(objetivos[jo, 4]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj4 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria4")
                                    categoria4 = (string)field.GetValue();
                                if (name == "paso41")
                                    paso41 = (string)field.GetValue();
                                if (name == "paso42")
                                    paso42 = (string)field.GetValue();

                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria4, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Empleado", tableFont2));
                            perfilTable.AddCell(new Phrase(paso41, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Jefatura", tableFont2));
                            perfilTable.AddCell(new Phrase(paso42, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            //tabla 5
                            JsonObject obj5 = parser.Parse(objetivos[jo, 5]);
                            JsonUtility.GenerateIndentedJsonText = false;
                            foreach (JsonObject field in obj5 as JsonObjectCollection)
                            {
                                string name = field.Name;
                                if (name == "categoria5")
                                    categoria5 = (string)field.GetValue();
                                if (name == "pasos51")
                                    pasos51 = (string)field.GetValue();
                                if (name == "notafinaljefatura5")
                                    notafinaljefatura5 = (string)field.GetValue();

                            }
                            perfilTable.AddCell(new Phrase("Categoria", tableFont2));
                            perfilTable.AddCell(new Phrase(categoria5, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Empleado", tableFont2));
                            perfilTable.AddCell(new Phrase(pasos51, tableFont2));
                            perfilTable.AddCell(new Phrase("Comentarios Jefatura", tableFont2));
                            perfilTable.AddCell(new Phrase(notafinaljefatura5, tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                            perfilTable.AddCell(new Phrase("", tableFont2));
                        }
                    }
                    document.Add(perfilTable);


                    // COMPETENCIAS
                    document.Add(new Paragraph("COMPETENCIAS", subTitleFont));
                    document.Add(new Paragraph("", subTitleFont));

                    if (DateTime.Today < fechaPrimeraEvaluacion)
                    {
                        document.Add(new Paragraph("Evaluación Inicial", subTitleFont));
                        document.Add(new Paragraph("", subTitleFont));
                        perfilTable = new PdfPTable(7);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 60, 60, 60, 60, 60, 60, 60 });

                        perfilTable.AddCell(new Phrase("Competencia", boldTableFont));
                        perfilTable.AddCell(new Phrase("Evaluación", boldTableFont));
                        perfilTable.AddCell(new Phrase("Comentario", boldTableFont));
                        perfilTable.AddCell(new Phrase("Plan Acción", boldTableFont));
                        perfilTable.AddCell(new Phrase("Eval.Jefatura", boldTableFont));
                        perfilTable.AddCell(new Phrase("Coment.Jefatura", boldTableFont));
                        perfilTable.AddCell(new Phrase("Eval.Calibrada", boldTableFont));

                        for (j = 0; j < i; j++)
                        {
                            perfilTable.AddCell(new Phrase(comp[j, 0], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 1], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 2], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 3], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 4], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 5], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 6], tableFont2));
                        }
                    }
                    else
                    {
                        document.Add(new Paragraph("Evaluación Final", subTitleFont));
                        document.Add(new Paragraph("", subTitleFont));
                        perfilTable = new PdfPTable(4);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 30, 35, 35, 35 });

                        perfilTable.AddCell(new Phrase("Competencia", boldTableFont));
                        perfilTable.AddCell(new Phrase("Evaluación", boldTableFont));
                        perfilTable.AddCell(new Phrase("Eval.Jefatura", boldTableFont));
                        perfilTable.AddCell(new Phrase("Eval.Calibrada", boldTableFont));

                        for (j = 1; j < i; j++)
                        {
                            perfilTable.AddCell(new Phrase(comp[j, 0], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 7], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 8], tableFont2));
                            perfilTable.AddCell(new Phrase(comp[j, 9], tableFont2));
                        }
                    }

                    document.Add(perfilTable);
                    document.Close();
                    writer.Close();
                    ms.Close();
                    Response.ContentType = "pdf/application";
                    Response.AddHeader("content-disposition", "attachment;filename=Evaluacion-" + nombre1 + ape1 + ".pdf");
                    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                }
            }
            //--------------
            // CIERRE BASE DE DATOS
            //--------------

            conexionBD.Close();
            conexionBD.Dispose();
        }
    }
}