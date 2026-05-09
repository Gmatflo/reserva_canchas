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
        private List<Reserva> reservas = new List<Reserva>();

        public List<Reserva> ListarTodo()
        {
            return reservas;
        }

        private bool Existe(int pIdReserva)
        {
            return reservas.Exists(r => r.IDReserva == pIdReserva);
        }

        public bool ExisteCruceHorario(int pIdCancha, DateTime pFecha, TimeSpan pHoraInicio, TimeSpan pHoraFin, int pIdReservaIgnorar = -1)
        {
            foreach (var r in reservas)
            {
                if (r.Cancha != null && r.Cancha.IDCancha == pIdCancha && r.Fecha.Date == pFecha.Date && r.Estado != "Cancelada")
                {
                    if (r.IDReserva == pIdReservaIgnorar) continue;

                    if (pHoraInicio < r.HoraFin && pHoraFin > r.HoraInicio)
                    {
                        return true; // Hay cruce
                    }
                }
            }
            return false; // Está libre
        }

        public bool RegistrarReserva(Reserva pReserva)
        {
            if (Existe(pReserva.IDReserva))
            {
                return false; // ID duplicado
            }

            if (ExisteCruceHorario(pReserva.Cancha.IDCancha, pReserva.Fecha, pReserva.HoraInicio, pReserva.HoraFin))
            {
                return false; // Cruce de horarios
            }

            reservas.Add(pReserva);
            return true;
        }

        public bool EditarReserva(Reserva pReserva)
        {
            if (ExisteCruceHorario(pReserva.Cancha.IDCancha, pReserva.Fecha, pReserva.HoraInicio, pReserva.HoraFin, pReserva.IDReserva))
            {
                return false;
            }

            var index = reservas.FindIndex(r => r.IDReserva == pReserva.IDReserva);
            if (index != -1)
            {
                reservas[index] = pReserva;
                return true;
            }
            return false;
        }

        public bool CancelarReserva(int pIdReserva)
        {
            var reserva = reservas.Find(r => r.IDReserva == pIdReserva);
            if (reserva != null && reserva.Estado != "Cancelada")
            {
                reserva.Estado = "Cancelada";
                return true;
            }
            return false;
        }
    }
}
