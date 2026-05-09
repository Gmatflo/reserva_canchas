using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Pago : EntidadAuditable
    {
        public int IDPago { get; set; }
        public double MontoPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public string EstadoPago { get; set; }

        // Relación con Reserva
        public Reserva Reserva { get; set; }
    }
}
