using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class AdministradorController
    {
        private List<Administrador> administradores = new List<Administrador>();

        public List<Administrador> ListarTodo()
        {
            return administradores;
        }

        public Administrador BuscarAdministrador(string pDNI)
        {
            return administradores.FirstOrDefault(a => a.DNI == pDNI);
        }

        public bool RegistrarAdministrador(Administrador pAdmin)
        {
            if (administradores.Any(a => a.DNI == pAdmin.DNI)) return false;

            administradores.Add(pAdmin);
            return true;
        }

        public bool EditarAdministrador(Administrador pAdmin)
        {
            var index = administradores.FindIndex(a => a.IDAdministrador == pAdmin.IDAdministrador);
            if (index != -1)
            {
                administradores[index] = pAdmin;
                return true;
            }
            return false;
        }

        public bool EliminarAdministrador(int pIdAdmin)
        {
            var admin = administradores.Find(a => a.IDAdministrador == pIdAdmin);
            if (admin != null)
            {
                administradores.Remove(admin);
                return true;
            }
            return false;
        }
    }
}
