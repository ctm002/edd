using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Domain.Enum;

namespace Portal.Interface
{
    public interface IsarControl
    {
        bool SoloLectura { set; }
        eTipoCampo TipoCampo { get; set; }
        object Valor { get; set; }
        bool Obligatorio { set; }
        void DataBind();
        object DataSource { set; }
        long Width { set; }
        long Height { set; }
        bool AutoPostBack { set; }
        string NombreControl { set; }
        string ValidationGroup { set; }
        void Foco();
        void Fondo(string sColor);
        void MensajeError(string sMensaje);
    }
}
