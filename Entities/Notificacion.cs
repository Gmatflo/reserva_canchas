using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Entities
{
    public class Notificacion : EntidadAuditable
    {
        public int IDNotificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }

        // Relación con el Usuario (aplica polimorfismo para Cliente o Administrador)
        public Usuario UsuarioDestino { get; set; }
    }
}
