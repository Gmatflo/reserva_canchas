using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    internal class DetalleReservaImplementoController
    {
        private static List<DetalleReservaImplemento> detalles = new List<DetalleReservaImplemento>();

        public List<DetalleReservaImplemento> ListarPorReserva(int pIdReserva)
        {
            return detalles.Where(d => d.Reserva.IDReserva == pIdReserva).ToList();
        }

        public bool AgregarDetalle(DetalleReservaImplemento pDetalle)
        {
            // 1. Validar que no se agregue el mismo implemento dos veces a la misma reserva
            if (detalles.Exists(d => d.Reserva.IDReserva == pDetalle.Reserva.IDReserva &&
                                   d.Implemento.IDImplemento == pDetalle.Implemento.IDImplemento))
            {
                return false;
            }

            // 2. Restar el stock del implemento real
            pDetalle.Implemento.StockTotal -= pDetalle.Cantidad;

            detalles.Add(pDetalle);
            return true;
        }

        public void QuitarDetalle(int pIdReserva, int pIdImplemento)
        {
            var detalle = detalles.Find(d => d.Reserva.IDReserva == pIdReserva &&
                                           d.Implemento.IDImplemento == pIdImplemento);
            if (detalle != null)
            {
                // Devolvemos el stock al implemento
                detalle.Implemento.StockTotal += detalle.Cantidad;
                detalles.Remove(detalle);
            }
        }
    }
}
