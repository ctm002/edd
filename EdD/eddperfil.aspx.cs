using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Net.Json;


namespace EdD
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button_Imprimir_Click(object sender, EventArgs e)
        {
            //-------------
            // DATOS PERFIL
            //-------------
            string nombre1 = "";
            string nombre2 = "";
            string ape1 = "";
            string ape2 = "";
            string nacionalidad = "";
            string cargo = "";
            string area = "";
            string gerencia = "";
            string celular = "";

            int numexp = 0;
            string[] expfecini = new string[4];
            string[] expfecter = new string[4];
            string[] expcargo = new string[4];

            int numemp = 0;
            string[] empfecini = new string[10];
            string[] empfecter = new string[10];
            string[] empcargo = new string[10];
            string[] empresa = new string[10];

            int numcap = 0;
            string[] capfecini = new string[8];
            string[] capfecter = new string[8];
            string[] captitulo = new string[8];
            string[] captitestudio = new string[8];
            string[] capinstitucion = new string[8];

            int numidiom = 0;
            string[] idiom = new string[5];
            string[] nivel = new string[5];

            int nummov = 0;
            string[] areapref = new string[1];
            string[] disp = new string[1];

            int numprem = 0;
            string[] nomprem = new string[10];
            string[] fecprem = new string[10];
            string[] orgprem = new string[10];

            int nummemb = 0;
            string[] memb = new string[5];
            string[] membfecini = new string[5];
            string[] membfecter = new string[5];

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

            string ad_IdMaestroUsuario = Request.Cookies["IdMaestroUsuario"].Value;
            sqlText = "SELECT * from tbl_perfil where cv_ad = " + ad_IdMaestroUsuario;
            comandoSql = new SqlCommand(sqlText, conexionBD);
            comandoSql.Connection.Open();
            var lecturaSql = comandoSql.ExecuteReader();
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
                    else if (name == "celular")
                        celular = (string)field.GetValue();

                    // Experiencia Laboral en la Organización
                    else if (name.StartsWith("expfecini"))
                    {
                        numexp = (int)Convert.ToInt32(name.Substring(9));
                        expfecini[numexp - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("expfecter"))
                    {
                        numexp = (int)Convert.ToInt32(name.Substring(9));
                        expfecter[numexp - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("expcargo"))
                    {
                        numexp = (int)Convert.ToInt32(name.Substring(8));
                        expcargo[numexp - 1] = (string)field.GetValue();
                    }

                    // Empleo Anterior
                    else if (name.StartsWith("empfecini"))
                    {
                        numemp = (int)Convert.ToInt32(name.Substring(9));
                        empfecini[numemp - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("empfecter"))
                    {
                        numemp = (int)Convert.ToInt32(name.Substring(9));
                        empfecter[numemp - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("empcargo"))
                    {
                        numemp = (int)Convert.ToInt32(name.Substring(8));
                        empcargo[numemp - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("empresa"))
                    {
                        numemp = (int)Convert.ToInt32(name.Substring(7));
                        empresa[numemp - 1] = (string)field.GetValue();
                    }

                    // Educación - Capacitaciones
                    else if (name.StartsWith("capfecini"))
                    {
                        numcap = (int)Convert.ToInt32(name.Substring(9));
                        capfecini[numcap - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("capfecter"))
                    {
                        numcap = (int)Convert.ToInt32(name.Substring(9));
                        capfecter[numcap - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("captitulo"))
                    {
                        numcap = (int)Convert.ToInt32(name.Substring(9));
                        captitulo[numcap - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("captitestudio"))
                    {
                        numcap = (int)Convert.ToInt32(name.Substring(13));
                        captitestudio[numcap - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("capinstitucion"))
                    {
                        numcap = (int)Convert.ToInt32(name.Substring(14));
                        capinstitucion[numcap - 1] = (string)field.GetValue();
                    }

                    // Idiomas
                    else if (name.StartsWith("idiom"))
                    {
                        numidiom = (int)Convert.ToInt32(name.Substring(5));
                        idiom[numidiom - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("nivel"))
                    {
                        numidiom = (int)Convert.ToInt32(name.Substring(5));
                        nivel[numidiom - 1] = (string)field.GetValue();
                    }

                    // Movimientos
                    else if (name.StartsWith("areapref"))
                    {
                        nummov = (int)Convert.ToInt32(name.Substring(8));
                        areapref[nummov - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("disp"))
                    {
                        nummov = (int)Convert.ToInt32(name.Substring(4));
                        disp[nummov - 1] = (string)field.GetValue();
                    }

                    // Premios
                    else if (name.StartsWith("nomprem"))
                    {
                        numprem = (int)Convert.ToInt32(name.Substring(7));
                        nomprem[numprem - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("fecprem"))
                    {
                        numprem = (int)Convert.ToInt32(name.Substring(7));
                        fecprem[numprem - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("orgprem"))
                    {
                        numprem = (int)Convert.ToInt32(name.Substring(7));
                        orgprem[numprem - 1] = (string)field.GetValue();
                    }

                    // Membresías
                    else if (name.StartsWith("memb") && name.Length == 5)
                    {
                        nummemb = (int)Convert.ToInt32(name.Substring(4));
                        memb[nummemb - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("membfecini"))
                    {
                        nummemb = (int)Convert.ToInt32(name.Substring(10));
                        membfecini[nummemb - 1] = (string)field.GetValue();
                    }
                    else if (name.StartsWith("membfecter"))
                    {
                        nummemb = (int)Convert.ToInt32(name.Substring(10));
                        membfecter[nummemb - 1] = (string)field.GetValue();
                    }

                    // SE CUENTAN LAS OCURRENCIAS
                    // ---------------------------
                    // Experiencia Laboral en la Organización
                    numexp = 0;
                    for (int i = 0; i < 4; i++)
                        if (expfecini[i] != "" || expfecter[i] != "" || expcargo[i] != "")
                            numexp++;

                    // Empleo Anterior
                    numemp = 0;
                    for (int i = 0; i < 4; i++)
                        if (empfecini[i] != "" || empfecter[i] != "" || empcargo[i] != "" || empresa[i] != "")
                            numemp++;

                    // Educación - Capacitaciones
                    numcap = 0;
                    for (int i = 0; i < 8; i++)
                        if (capfecini[i] != "" || capfecter[i] != "" || captitulo[i] != "" || captitestudio[i] != "" || capinstitucion[i] != "")
                            numcap++;

                    // Idiomas
                    numidiom = 0;
                    for (int i = 0; i < 5; i++)
                        if (idiom[i] != "" || (nivel[i] != "" && nivel[i] != "null"))
                            numidiom++;

                    // Movivmientos
                    nummov = 0;
                    for (int i = 0; i < 1; i++)
                        if (areapref[i] != "" || disp[i] != "")
                            nummov++;

                    // Premios
                    numprem = 0;
                    for (int i = 0; i < 10; i++)
                        if (nomprem[i] != "" || fecprem[i] != "" || orgprem[i] != "")
                            numprem++;

                    // Membresías
                    nummemb = 0;
                    for (int i = 0; i < 5; i++)
                        if (memb[i] != "" || membfecini[i] != "" || membfecter[i] != "")
                            nummemb++;

                }
            }
            else
            {
                cv_datos = "";
                cv_estado = "";
            }
            lecturaSql.Close();
            comandoSql.Connection.Close();


            //---------
            // Reporte
            //---------
            if (cv_datos != "")
            {
                using (MemoryStream ms = new MemoryStream())
                using (Document document = new Document(PageSize.LETTER, 50, 50, 25, 25))
                using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
                {
                    var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                    var subTitleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                    var boldTableFont = FontFactory.GetFont("Arial", 10, Font.BOLD);
                    var tableFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
                    var endingMessageFont = FontFactory.GetFont("Arial", 9, Font.ITALIC);
                    var bodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);

                    // Comienzo Documento
                    document.Open();

                    // Titulo
                    //var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/imagenes/logo.jpg"));
                    //logo.SetAbsolutePosition(445, 670);
                    //document.Add(logo);
                    document.Add(new Paragraph("PERFIL USUARIO", titleFont));
                    document.Add(new Paragraph(" ", titleFont));

                    // Datos Personales
                    document.Add(new Paragraph("DATOS PERSONALES", subTitleFont));
                    var perfilTable = new PdfPTable(2);
                    perfilTable.HorizontalAlignment = 0;
                    perfilTable.SpacingBefore = 4;
                    perfilTable.SpacingAfter = 10;
                    perfilTable.DefaultCell.Border = 0;
                    perfilTable.SetWidths(new int[] { 1, 3 });

                    perfilTable.AddCell(new Phrase("Nombre:", tableFont));
                    perfilTable.AddCell(new Phrase(nombre1 + " " + nombre2 + " " + ape1 + " " + ape2, tableFont));
                    perfilTable.AddCell(new Phrase("Nacionalidad:", tableFont));
                    perfilTable.AddCell(new Phrase(nacionalidad, tableFont));
                    perfilTable.AddCell(new Phrase("Cargo:", tableFont));
                    perfilTable.AddCell(new Phrase(cargo, tableFont));
                    perfilTable.AddCell(new Phrase("Área:", tableFont));
                    perfilTable.AddCell(new Phrase(area, tableFont));
                    perfilTable.AddCell(new Phrase("Gerencia:", tableFont));
                    perfilTable.AddCell(new Phrase(gerencia, tableFont));
                    perfilTable.AddCell(new Phrase("Celular:", tableFont));
                    perfilTable.AddCell(new Phrase(celular, tableFont));
                    document.Add(perfilTable);

                    // Experiencia Laboral en la Organización
                    if (numexp > 0)
                    {
                        document.Add(new Paragraph("EXPERIANCIA LABORAL EN LA ORGANIZACIÓN", subTitleFont));
                        perfilTable = new PdfPTable(3);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 2, 2, 2 });
                        for (int i = 0; i < numexp; i++)
                        {
                            if (i == 0)
                            {
                                perfilTable.AddCell(new Phrase("Fecha Inicio", boldTableFont));
                                perfilTable.AddCell(new Phrase("Fecha Término", boldTableFont));
                                perfilTable.AddCell(new Phrase("Cargo", boldTableFont));
                            }
                            perfilTable.AddCell(new Phrase(expfecini[i], tableFont));
                            perfilTable.AddCell(new Phrase(expfecter[i], tableFont));
                            perfilTable.AddCell(new Phrase(expcargo[i], tableFont));
                        }
                        document.Add(perfilTable);
                    }

                    // Empleo Anterior
                    if (numemp > 0)
                    {
                        document.Add(new Paragraph("EMPLEO ANTERIOR", subTitleFont));
                        perfilTable = new PdfPTable(4);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 2, 2, 2, 2 });
                        for (int i = 0; i < numemp; i++)
                        {
                            if (i == 0)
                            {
                                perfilTable.AddCell(new Phrase("Fecha Inicio", boldTableFont));
                                perfilTable.AddCell(new Phrase("Fecha Término", boldTableFont));
                                perfilTable.AddCell(new Phrase("Cargo", boldTableFont));
                                perfilTable.AddCell(new Phrase("Empresa", boldTableFont));
                            }
                            perfilTable.AddCell(new Phrase(empfecini[i], tableFont));
                            perfilTable.AddCell(new Phrase(empfecter[i], tableFont));
                            perfilTable.AddCell(new Phrase(empcargo[i], tableFont));
                            perfilTable.AddCell(new Phrase(empresa[i], tableFont));
                        }
                        document.Add(perfilTable);
                    }

                    // Educación - Capacitaciones
                    if (numcap > 0)
                    {
                        document.Add(new Paragraph("EDUCACIÓN/CAPACITACIONES", subTitleFont));
                        perfilTable = new PdfPTable(5);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 3, 3, 2, 3, 4 });
                        for (int i = 0; i < numcap; i++)
                        {
                            if (i == 0)
                            {
                                perfilTable.AddCell(new Phrase("Fecha Inicio", boldTableFont));
                                perfilTable.AddCell(new Phrase("Fecha Término", boldTableFont));
                                perfilTable.AddCell(new Phrase("Título", boldTableFont));
                                perfilTable.AddCell(new Phrase("Tipo de Estudio", boldTableFont));
                                perfilTable.AddCell(new Phrase("Universidad/Instituto", boldTableFont));
                            }
                            perfilTable.AddCell(new Phrase(capfecini[i], tableFont));
                            perfilTable.AddCell(new Phrase(capfecter[i], tableFont));
                            perfilTable.AddCell(new Phrase(captitulo[i], tableFont));
                            perfilTable.AddCell(new Phrase(captitestudio[i], tableFont));
                            perfilTable.AddCell(new Phrase(capinstitucion[i], tableFont));
                        }
                        document.Add(perfilTable);
                    }

                    // Idiomas
                    if (numidiom > 0)
                    {
                        document.Add(new Paragraph("IDIOMAS", subTitleFont));
                        perfilTable = new PdfPTable(2);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 1, 1 });
                        for (int i = 0; i < numidiom; i++)
                        {
                            if (i == 0)
                            {
                                perfilTable.AddCell(new Phrase("Idioma", boldTableFont));
                                perfilTable.AddCell(new Phrase("Nivel Idioma", boldTableFont));
                            }
                            perfilTable.AddCell(new Phrase(idiom[i], tableFont));
                            perfilTable.AddCell(new Phrase(nivel[i], tableFont));
                        }
                        document.Add(perfilTable);
                    }

                    // Movimientos
                    if (nummov > 0)
                    {
                        document.Add(new Paragraph("MOVIMIENTO INTERNO", subTitleFont));
                        perfilTable = new PdfPTable(2);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 3, 3 });
                        for (int i = 0; i < nummov; i++)
                        {
                            if (i == 0)
                            {
                                perfilTable.AddCell(new Phrase("Area Preferencia", boldTableFont));
                                perfilTable.AddCell(new Phrase("Disponibilidad", boldTableFont));
                            }
                            perfilTable.AddCell(new Phrase(areapref[i], tableFont));
                            perfilTable.AddCell(new Phrase(disp[i], tableFont));
                        }
                        document.Add(perfilTable);
                    }

                    // Premios
                    if (numprem > 0)
                    {
                        document.Add(new Paragraph("PREMIOS", subTitleFont));
                        perfilTable = new PdfPTable(3);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 3, 3, 3 });
                        for (int i = 0; i < numprem; i++)
                        {
                            if (i == 0)
                            {
                                perfilTable.AddCell(new Phrase("Nombre Premio", boldTableFont));
                                perfilTable.AddCell(new Phrase("Fecha", boldTableFont));
                                perfilTable.AddCell(new Phrase("Organización", boldTableFont));
                            }
                            perfilTable.AddCell(new Phrase(nomprem[i], tableFont));
                            perfilTable.AddCell(new Phrase(fecprem[i], tableFont));
                            perfilTable.AddCell(new Phrase(orgprem[i], tableFont));
                        }
                        document.Add(perfilTable);
                    }

                    // Membresías
                    if (nummemb > 0)
                    {
                        document.Add(new Paragraph("MEMBRESÍA", subTitleFont));
                        perfilTable = new PdfPTable(3);
                        perfilTable.HorizontalAlignment = 0;
                        perfilTable.SpacingBefore = 4;
                        perfilTable.SpacingAfter = 10;
                        perfilTable.DefaultCell.Border = 0;
                        perfilTable.SetWidths(new int[] { 3, 3, 3 });
                        for (int i = 0; i < nummemb; i++)
                        {
                            if (i == 0)
                            {
                                perfilTable.AddCell(new Phrase("Nombre Membresía", boldTableFont));
                                perfilTable.AddCell(new Phrase("Fecha Inicio", boldTableFont));
                                perfilTable.AddCell(new Phrase("Fecha Término", boldTableFont));
                            }
                            perfilTable.AddCell(new Phrase(memb[i], tableFont));
                            perfilTable.AddCell(new Phrase(membfecini[i], tableFont));
                            perfilTable.AddCell(new Phrase(membfecter[i], tableFont));
                        }
                        document.Add(perfilTable);
                    }



                    document.Close();
                    writer.Close();
                    ms.Close();
                    Response.ContentType = "pdf/application";
                    Response.AddHeader("content-disposition", "attachment;filename=Perfil-" + nombre1 + ape1 + ".pdf");
                    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                }
            }

            //--------------
            // BASE DE DATOS
            //--------------
            comandoSql.Connection.Dispose();
            conexionBD.Close();
            conexionBD.Dispose();
        }

    }
}