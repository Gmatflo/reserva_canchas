using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class ReservaController
    {
        // Esta lista simula la base de datos temporalmente
        private List<Reserva> reservas = new List<Reserva>();

        public List<Reserva> ListarTodo()
        {
            return reservas;
        }

        public bool ExisteCruceHorario(int pIdCancha, DateTime pFecha, TimeSpan pHoraInicio, TimeSpan pHoraFin)
        {
            foreach (var r in reservas)
            {
                if (r.Cancha.IDCancha == pIdCancha && r.Fecha.Date == pFecha.Date && r.Estado != "Cancelada")
                {
                    // Lógica para verificar si se solapan las horas
                    if ((pHoraInicio >= r.HoraInicio && pHoraInicio < r.HoraFin) ||
                        (pHoraFin > r.HoraInicio && pHoraFin <= r.HoraFin))
                    {
                        return true; // Hay cruce
                    }
                }
            }
            return false; // Está libre
        }

        public bool RegistrarReserva(Reserva pReserva)
        {
            if (ExisteCruceHorario(pReserva.Cancha.IDCancha, pReserva.Fecha, pReserva.HoraInicio, pReserva.HoraFin))
            {
                return false; // No permite guardar si hay cruce
            }

            reservas.Add(pReserva);
            return true;
        }

        public bool CancelarReserva(int pIdReserva)
        {
            var reserva = reservas.Find(r => r.IDReserva == pIdReserva);
            if (reserva != null)
            {
                reserva.Estado = "Cancelada";
                // Aquí podrías agregar la lógica que invoca al ReporteController para la penalidad
                return true;
            }
            return false;
        }
    }
}
