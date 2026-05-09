using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public abstract class EntidadAuditable
    {
        public int CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }

        public EntidadAuditable()
        {
            // Inicializa las fechas por defecto al momento de instanciar
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
        }
    }
}
