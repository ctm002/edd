using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EdD
{
    public partial class eddpaneladmin : System.Web.UI.Page
    {
        //----------------------------
        // CONEXIÓN A LA BASE DE DATOS
        //----------------------------
        string stringConexionBD;
        SqlConnection conexionBD, conexionBD2;
        SqlCommand comandoSql1, comandoSql2;
        string sqlText1, sqlText2;



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("eddpaneladminfechas.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
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
            sqlText1 = "EXEC LIMPIA_TABLAS";
            comandoSql1 = new SqlCommand(sqlText1, conexionBD);
            comandoSql1.Connection.Open();
            var lecturaSql1 = comandoSql1.ExecuteReader();
            lecturaSql1.Close();
            comandoSql1.Connection.Close();
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("edd.aspx");
        }

    }
}