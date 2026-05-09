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

        public List<Cancha> ListarPorSede(int pIdSede)
        {
            // Filtra las canchas que pertenecen a una sede específica
            return canchas.Where(c => c.Sede != null && c.Sede.IDSede == pIdSede).ToList();
        }

        public bool RegistrarCancha(Cancha pCancha)
        {
            // Valida que no exista una cancha con el mismo ID
            if (canchas.Any(c => c.IDCancha == pCancha.IDCancha)) return false;

            canchas.Add(pCancha);
            return true;
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
    }
}
