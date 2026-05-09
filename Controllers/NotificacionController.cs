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

        public List<Notificacion> ListarTodo()
        {
            return notificaciones;
        }

        public List<Notificacion> ListarPorUsuario(int pIdUsuario)
        {
            return notificaciones.Where(n => n.UsuarioDestino != null && n.UsuarioDestino.IDUsuario == pIdUsuario).ToList();
        }

        private bool Existe(int pIdNotificacion)
        {
            return notificaciones.Exists(n => n.IDNotificacion == pIdNotificacion);
        }

        public bool RegistrarNotificacion(Notificacion pNotificacion)
        {
            if (Existe(pNotificacion.IDNotificacion))
            {
                return false;
            }
            else
            {
                notificaciones.Add(pNotificacion);
                return true;
            }
        }

        public bool EditarNotificacion(Notificacion pNotificacion)
        {
            var index = notificaciones.FindIndex(n => n.IDNotificacion == pNotificacion.IDNotificacion);
            if (index != -1)
            {
                notificaciones[index] = pNotificacion;
                return true;
            }
            return false;
        }

        public bool EliminarNotificacion(int pIdNotificacion)
        {
            var notif = notificaciones.Find(n => n.IDNotificacion == pIdNotificacion);
            if (notif != null)
            {
                notificaciones.Remove(notif);
                return true;
            }
            return false;
        }
    }
}
