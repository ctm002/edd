using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdD.Modelo
{
    public class perfil
    {
            public string cv_id { get; set; }
            public string cv_ad { get; set; }
            public string cv_datos { get; set; }
            public string cv_estado { get; set; }  
    }
    public class eval
    {
        public string eval_fecha_inicio { get; set; }
        public string eval_fecha_primera_evaluacion { get; set; }
        public string eval_fecha_intermedio { get; set; }
        public string eval_fecha_termino { get; set; }
    }
    public class obj
    {
        public string obj_tabla1 { get; set; }
        public string obj_tabla2 { get; set; }
        public string obj_tabla3 { get; set; }
        public string obj_tabla4 { get; set; }
        public string obj_tabla5 { get; set; }
    }

    public class revisa
    {
        public string rev_ad { get; set; }
        public string rev_nombre { get; set; }
        public string rev_estado { get; set; }
    }
    public class competencias
    {
        public string cargo_id { get; set; }
        public string cargo_desc { get; set; }
    }

    public class regcomp
    {
        public string comp_id { get; set; }
        public string comp_desc { get; set; }
        public string comp_inicial_consensuada { get; set; }
        public string comp_inicial_comentario { get; set; }
        public string comp_inicial_plan_accion { get; set; }
        public string comp_inicial_jefe { get; set; }
        public string comp_final_consensuada { get; set; }
        public string comp_final_comentario { get; set; }
        public string comp_final_plan_accion { get; set; }
        public string comp_final_jefe { get; set; }
    }

    public sealed class Google_org_data
    {
        public string Employee { get; set; }
        public string Manager { get; set; }
        public string mgrID { get; set; }
        public string designation { get; set; }
        public string empID { get; set; }
    }

    public class reglog
    {
        public string log_fecha { get; set; }
        public string log_actividad { get; set; }
        public string log_estado { get; set; }
        public string usuario_nombre { get; set; }
    }
}