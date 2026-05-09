using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class SedeController
    {
        private List<Sede> sedes = new List<Sede>();

        public List<Sede> ListarTodo()
        {
            return sedes;
        }

        public Sede BuscarSede(int pIdSede)
        {
            return sedes.Find(s => s.IDSede == pIdSede);
        }

        private bool Existe(int pIdSede)
        {
            return sedes.Exists(s => s.IDSede == pIdSede);
        }

        public bool RegistrarSede(Sede pSede)
        {
            if (Existe(pSede.IDSede))
            {
                return false;
            }
            else
            {
                sedes.Add(pSede);
                return true;
            }
        }

        public bool EditarSede(Sede pSede)
        {
            var index = sedes.FindIndex(s => s.IDSede == pSede.IDSede);
            if (index != -1)
            {
                sedes[index] = pSede;
                return true;
            }
            return false;
        }

        public bool EliminarSede(int pIdSede)
        {
            var sede = sedes.Find(s => s.IDSede == pIdSede);
            if (sede != null)
            {
                sedes.Remove(sede);
                return true;
            }
            return false;
        }
    }
}
