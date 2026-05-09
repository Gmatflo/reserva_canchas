using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Administrador : Usuario
    {
        public int IDAdministrador { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Permisos { get; set; }
    }
}
