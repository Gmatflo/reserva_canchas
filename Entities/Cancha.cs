using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Cancha : EntidadAuditable
    {
        public int IDCancha { get; set; }
        public double PrecioHora { get; set; }
        public string Deporte { get; set; }
        public string Estado { get; set; }

        public Sede Sede { get; set; }

        public override string ToString()
        {
            return IDCancha.ToString();
        }
    }
}
