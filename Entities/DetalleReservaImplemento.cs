using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class DetalleReservaImplemento : EntidadAuditable
    {
        // Relaciones principales
        public Reserva Reserva { get; set; }
        public Implemento Implemento { get; set; }

        public double PrecioCongelado { get; set; }
        public int Cantidad { get; set; }
    }
}
