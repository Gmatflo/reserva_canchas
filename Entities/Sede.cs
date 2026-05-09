using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Sede : EntidadAuditable
    {
        public int IDSede { get; set; }
        public string Nombre { get; set; }
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }

        public Ubigeo Ubigeo { get; set; }
        public List<Cancha> Canchas { get; set; }
        public List<Implemento> Implementos { get; set; }

        public Sede()
        {
            Canchas = new List<Cancha>();
            Implementos = new List<Implemento>();
        }
    }
}
