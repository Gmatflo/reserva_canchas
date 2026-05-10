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

        public List<Pago> ListarTodo() { return pagos; }

        public List<Pago> ListarPorReserva(int pIdReserva)
        {
            return pagos.Where(p => p.Reserva != null && p.Reserva.IDReserva == pIdReserva).ToList();
        }

        private bool Existe(int pIdPago)
        {
            return pagos.Exists(p => p.IDPago == pIdPago);
        }

        // Método estrella 1: Suma solo los pagos que NO están reembolsados
        public double SumaPagosActivos(int pIdReserva, int pIdPagoIgnorar = -1)
        {
            return pagos.Where(p => p.Reserva != null &&
                                    p.Reserva.IDReserva == pIdReserva &&
                                    p.EstadoPago != "Reembolsado" &&
                                    p.IDPago != pIdPagoIgnorar)
                        .Sum(p => p.MontoPagado);
        }

        // Método estrella 2: Cambia el estado de todos los pagos activos de una reserva
        public void SincronizarEstados(int pIdReserva, string nuevoEstado)
        {
            foreach (var pago in pagos.Where(p => p.Reserva.IDReserva == pIdReserva && p.EstadoPago != "Reembolsado"))
            {
                pago.EstadoPago = nuevoEstado;
            }
        }

        public bool RegistrarPago(Pago pPago)
        {
            if (Existe(pPago.IDPago) || pPago.MontoPagado <= 0) return false;
            pagos.Add(pPago);
            return true;
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

        // En vez de eliminar de la lista, lo "Reembolsamos" (Borrado Lógico)
        public bool ReembolsarPago(int pIdPago)
        {
            var pago = pagos.Find(p => p.IDPago == pIdPago);
            if (pago != null && pago.EstadoPago != "Reembolsado")
            {
                pago.EstadoPago = "Reembolsado";
                return true;
            }
            return false;
        }
    }
}
