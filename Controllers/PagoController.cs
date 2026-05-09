using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class PagoController
    {
        private List<Pago> pagos = new List<Pago>();

        public List<Pago> ListarPorReserva(int pIdReserva)
        {
            return pagos.Where(p => p.Reserva != null && p.Reserva.IDReserva == pIdReserva).ToList();
        }

        public bool RegistrarPago(Pago pPago, int pIdReserva)
        {
            // Aquí se vincula el pago a la reserva antes de guardarlo
            if (pPago.MontoPagado <= 0) return false;

            pagos.Add(pPago);
            return true;
        }
    }
}
