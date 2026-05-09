using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class ImplementoController
    {
        private List<Implemento> implementos = new List<Implemento>();

        public List<Implemento> ListarPorSede(int pIdSede)
        {
            return implementos.Where(i => i.Sede != null && i.Sede.IDSede == pIdSede).ToList();
        }

        public bool RegistrarImplemento(Implemento pImplemento)
        {
            if (implementos.Any(i => i.IDImplemento == pImplemento.IDImplemento)) return false;

            implementos.Add(pImplemento);
            return true;
        }

        public bool EditarImplemento(Implemento pImplemento)
        {
            var index = implementos.FindIndex(i => i.IDImplemento == pImplemento.IDImplemento);
            if (index != -1)
            {
                implementos[index] = pImplemento;
                return true;
            }
            return false;
        }

        public bool EliminarImplemento(int pIdImplemento)
        {
            var implemento = implementos.Find(i => i.IDImplemento == pIdImplemento);
            if (implemento != null)
            {
                implementos.Remove(implemento);
                return true;
            }
            return false;
        }

        public bool ValidarStockDisponible(int pIdImplemento, int pCantidadDeseada)
        {
            var implemento = implementos.FirstOrDefault(i => i.IDImplemento == pIdImplemento);
            if (implemento != null)
            {
                // Validación en memoria asumiendo el StockTotal. 
                // Para una validación avanzada, aquí cruzarías contra las reservas de esa hora.
                return implemento.StockTotal >= pCantidadDeseada;
            }
            return false;
        }
    }
}
