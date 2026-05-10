using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Usuario : EntidadAuditable
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; } //a
    }
}
