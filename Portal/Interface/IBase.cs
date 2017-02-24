using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Domain.Enum;

namespace Portal.Interface
{
    public interface IBase
    {
        string NombreTabla { set; get; }

        int Ancho { set; get; }

        int Alto { set; get; }

        int NumeroPaginas { set; get; }

        int IdUsuarioModifica { set; get; }

        string NombreModifica { set; get; }
        
        /// <summary>
        /// Constante que define el nombre de cada columna y su tipo
        /// </summary>
        Dictionary<string, eTipoCampoTabla> ListadoColumnasTipo { set; get; }

        /// <summary>
        /// Constante que define el nombre de columna db y nombre de columna grilla
        /// </summary>
        Dictionary<string, string> ListadoColumnasNombre { set; get; }

        eTipoFiltro TipoFiltro { set; get; }

        string Titulo { set; get; }

        eTipoAccion[] Acciones { set; get; }
        
        /// <summary>
        /// Acciones que serpan realizadas por medio de un proceso seleccion de archivo mediante las siguientes funciones
        /// url | clase css btn | tipo de apertura (modal || _blank || sin
        /// </summary>
        Dictionary<string, string> AccionesPersonalizadas { set; get; }

        string ProcedimientoParentId { set; get; }

        string[] PrimaryKey { set; get; }
        
        /// <summary>
        /// Constante que contiene el Valor de las llaves foreaneas junto con sus tablas
        /// </summary>
        Dictionary<string, string> ForeignKey { set; get; }
        
        /// <summary>
        /// Constante que tiene el listado de Excepciones para el mantenedor de la grilla dinamica
        /// </summary>
        List<string> ListadoPrimaryKeyExcepciones { set; get; }
        
        /// <summary>
        /// Constante que permite obtener el Alias de las ForeignKey
        /// </summary>
        Dictionary<string, string> ListadoForeignKeyAlias { set; get; }

        Dictionary<string, int> AnchoColumnas { set; get; }
        
        /// <summary>
        /// Interfaz que permite listar el numero de Enumeradores aplicados al mantenedor
        /// </summary>
        Dictionary<string, Enum> ListadoEnumeradores { set; get; }

        bool MostrarPordefecto { set; get; }
        
        /// <summary>
        /// Procedimiento utilizado en la obtencio de la informacion para la grilla
        /// </summary>
        string ProcedimientoGrilla { set; get; }
        
        /// <summary>
        /// Metodo que permite modificar los valores del objeto
        /// </summary>
        void Modificar(bool bModificaTodo = true);
        
        /// <summary>
        /// Metodo que permite eliminar los valores del objeto
        /// </summary>
        void Eliminar();
    }
}
