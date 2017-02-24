using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EdD.App_Code
{
    public class Usuario
    {

        public Usuario(SqlDataReader reader)
        {
            IdEmpleado = Convert.ToInt16(reader["pk_id_per_maestro"]);
            CargoID = Convert.ToInt16(reader["pk_id_adm_cargo"]);
            AreaID = Convert.ToInt16(reader["id_area"]);
            JefeID = Convert.ToInt16(reader["id_jefe"]);
            Empleado = reader["empleado"].ToString();
            Cargo = reader["cargo"].ToString();
            Area = reader["area"].ToString();
            Jefe = reader["jefe"].ToString();
        }

        public int IdEmpleado { get; set; }

        public string Empleado { get; set; }

        public int CargoID { get; set; }

        public string Cargo { get; set; }

        public int AreaID { get; set; }

        public string Area { get; set; }

        public int JefeID { get; set; }

        public string Jefe { get; set; }

    }
}