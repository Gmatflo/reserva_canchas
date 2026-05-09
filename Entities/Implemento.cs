using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Implemento : EntidadAuditable
    {
        public int IDImplemento { get; set; }
        public string Nombre { get; set; }
        public int StockTotal { get; set; }
        public double PrecioAlquiler { get; set; }
        public string Estado { get; set; }

        // Relación con Sede
        public Sede Sede { get; set; }
    }
}
