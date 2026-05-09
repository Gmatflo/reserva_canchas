
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Cliente : Usuario
    {
        public int IDCliente { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public List<Reserva> Reservas { get; set; }

        public Cliente()
        {
            Reservas = new List<Reserva>();
        }
    }
}
