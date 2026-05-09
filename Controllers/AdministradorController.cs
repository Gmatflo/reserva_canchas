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
            return administradores.Find(a => a.DNI.Equals(pDNI));
        }
        private bool Existe(int pIdAdmin)
        {
            return administradores.Exists(a => a.IDAdministrador == pIdAdmin);
        }

        private bool ExisteDNI(string pDNI)
        {
            return administradores.Exists(a => a.DNI.Equals(pDNI));
        }

        public bool RegistrarAdministrador(Administrador pAdmin)
        {
            if (Existe(pAdmin.IDAdministrador) || ExisteDNI(pAdmin.DNI))
            {
                return false;
            }
            else
            {
                administradores.Add(pAdmin);
                return true;
            }
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
