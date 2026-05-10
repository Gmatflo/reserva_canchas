using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class ReporteController
    {
        public List<object> GenerarReporteIngresosPorSede(List<Pago> todosLosPagos, DateTime pFechaInicio, DateTime pFechaFin)
        {
            // Filtramos pagos completados en el rango de fechas
            var pagosValidos = todosLosPagos.Where(p =>
                p.EstadoPago == "Completado" &&
                p.FechaPago.Date >= pFechaInicio.Date &&
                p.FechaPago.Date <= pFechaFin.Date &&
                p.Reserva != null && p.Reserva.Cancha != null && p.Reserva.Cancha.Sede != null).ToList();

            // Agrupamos por nombre de sede y sumamos
            var reporte = pagosValidos
                .GroupBy(p => p.Reserva.Cancha.Sede.Nombre)
                .Select(g => new
                {
                    Sede = g.Key,
                    IngresosTotales = g.Sum(p => p.MontoPagado),
                    CantidadDePagos = g.Count()
                })
                .OrderByDescending(r => r.IngresosTotales)
                .Cast<object>()
                .ToList();

            return reporte;
        }

        // REPORTE 2: Reservas por Deporte (Para Gráfico de Barras)
        public List<object> GenerarReporteReservasPorDeporte(List<Reserva> todasLasReservas)
        {
            // Filtramos reservas que NO estén canceladas
            var reservasValidas = todasLasReservas.Where(r =>
                r.Estado != "Cancelada" &&
                r.Cancha != null).ToList();

            // Agrupamos por deporte
            var reporte = reservasValidas
                .GroupBy(r => r.Cancha.Deporte)
                .Select(g => new
                {
                    Deporte = g.Key,
                    TotalReservas = g.Count()
                })
                .OrderByDescending(r => r.TotalReservas)
                .Cast<object>()
                .ToList();

            return reporte;
        }
    }
}
