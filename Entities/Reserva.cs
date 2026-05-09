using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Reserva : EntidadAuditable
    {
        public int IDReserva { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public double MontoTotal { get; set; }
        public string Estado { get; set; }

        public Cliente Cliente { get; set; }
        public Cancha Cancha { get; set; }
        public List<Pago> Pagos { get; set; }
        public List<DetalleReservaImplemento> DetallesImplementos { get; set; }

        public Reserva()
        {
            Pagos = new List<Pago>();
            DetallesImplementos = new List<DetalleReservaImplemento>();
        }

        public double CalcularSaldoPendiente()
        {
            double pagado = 0;
            foreach (var pago in Pagos)
            {
                pagado += pago.MontoPagado;
            }
            return MontoTotal - pagado;
        }
    }
}
