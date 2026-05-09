using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class CanchaController
    {
        private List<Cancha> canchas = new List<Cancha>();

        public List<Cancha> ListarTodo()
        {
            return canchas;
        }

        public List<Cancha> ListarPorSede(int pIdSede)
        {
            return canchas.Where(c => c.Sede != null && c.Sede.IDSede == pIdSede).ToList();
        }

        private bool Existe(int pIdCancha)
        {
            return canchas.Exists(c => c.IDCancha == pIdCancha);
        }

        public bool RegistrarCancha(Cancha pCancha)
        {
            if (Existe(pCancha.IDCancha))
            {
                return false;
            }
            else
            {
                canchas.Add(pCancha);
                return true;
            }
        }

        public bool EditarCancha(Cancha pCancha)
        {
            var index = canchas.FindIndex(c => c.IDCancha == pCancha.IDCancha);
            if (index != -1)
            {
                canchas[index] = pCancha;
                return true;
            }
            return false;
        }

        public bool EliminarCancha(int pIdCancha)
        {
            var cancha = canchas.Find(c => c.IDCancha == pIdCancha);
            if (cancha != null)
            {
                canchas.Remove(cancha);
                return true;
            }
            return false;
        }

        public Cancha BuscarCancha(int pIdCancha)
        {
            return canchas.Find(c => c.IDCancha == pIdCancha);
        }
    }
}
