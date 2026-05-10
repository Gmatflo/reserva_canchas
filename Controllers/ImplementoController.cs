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
        private static List<Implemento> implementos = new List<Implemento>();

        public List<Implemento> ListarTodo()
        {
            return implementos;
        }

        public List<Implemento> ListarPorSede(int pIdSede)
        {
            return implementos.Where(i => i.Sede != null && i.Sede.IDSede == pIdSede).ToList();
        }

        private bool Existe(int pIdImplemento)
        {
            return implementos.Exists(i => i.IDImplemento == pIdImplemento);
        }

        public bool RegistrarImplemento(Implemento pImplemento)
        {
            if (Existe(pImplemento.IDImplemento))
            {
                return false;
            }
            else
            {
                implementos.Add(pImplemento);
                return true;
            }
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
            var implemento = implementos.Find(i => i.IDImplemento == pIdImplemento);
            if (implemento != null)
            {
                return implemento.StockTotal >= pCantidadDeseada;
            }
            return false;
        }
    }
}
