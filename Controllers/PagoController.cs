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

        public List<Pago> ListarTodo()
        {
            return pagos;
        }

        public List<Pago> ListarPorReserva(int pIdReserva)
        {
            return pagos.Where(p => p.Reserva != null && p.Reserva.IDReserva == pIdReserva).ToList();
        }

        private bool Existe(int pIdPago)
        {
            return pagos.Exists(p => p.IDPago == pIdPago);
        }

        public bool RegistrarPago(Pago pPago, int pIdReserva)
        {
            if (Existe(pPago.IDPago) || pPago.MontoPagado <= 0)
            {
                return false;
            }
            else
            {
                pagos.Add(pPago);
                return true;
            }
        }

        public bool EditarPago(Pago pPago)
        {
            var index = pagos.FindIndex(p => p.IDPago == pPago.IDPago);
            if (index != -1)
            {
                pagos[index] = pPago;
                return true;
            }
            return false;
        }

        public bool EliminarPago(int pIdPago)
        {
            var pago = pagos.Find(p => p.IDPago == pIdPago);
            if (pago != null)
            {
                pagos.Remove(pago);
                return true;
            }
            return false;
        }
    }
}
