using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class NotificacionController
    {
        private List<Notificacion> notificaciones = new List<Notificacion>();

        public List<Notificacion> ListarPorUsuario(int pIdUsuario)
        {
            return notificaciones.Where(n => n.UsuarioDestino != null && n.UsuarioDestino.IDUsuario == pIdUsuario).ToList();
        }

        public bool GenerarNotificacion(Usuario pUsuario, string pMensaje)
        {
            if (pUsuario == null || string.IsNullOrWhiteSpace(pMensaje)) return false;

            Notificacion nueva = new Notificacion
            {
                // Autogenerador básico de ID
                IDNotificacion = notificaciones.Count > 0 ? notificaciones.Max(n => n.IDNotificacion) + 1 : 1,
                UsuarioDestino = pUsuario,
                Mensaje = pMensaje,
                FechaEnvio = DateTime.Now
            };

            notificaciones.Add(nueva);
            return true;
        }

        public bool MarcarComoLeida(int pIdNotificacion)
        {
            var notif = notificaciones.FirstOrDefault(n => n.IDNotificacion == pIdNotificacion);
            if (notif != null)
            {
                // Si agregaron un atributo bool IsLeida en la entidad, lo actualizan aquí
                return true;
            }
            return false;
        }
    }
}
