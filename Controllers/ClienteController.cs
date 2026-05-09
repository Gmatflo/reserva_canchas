using MultiSport_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSport_Manager.Controllers
{
    public class ClienteController
    {
        private List<Cliente> clientes = new List<Cliente>();

        public List<Cliente> ListarTodo()
        {
            return clientes;
        }

        public Cliente BuscarCliente(string pDNI)
        {
            return clientes.Find(c => c.DNI.Equals(pDNI));
        }

        private bool Existe(int pIdCliente)
        {
            return clientes.Exists(c => c.IDCliente == pIdCliente);
        }

        private bool ExisteDNI(string pDNI)
        {
            return clientes.Exists(c => c.DNI.Equals(pDNI));
        }

        public bool RegistrarCliente(Cliente pCliente)
        {
            if (Existe(pCliente.IDCliente) || ExisteDNI(pCliente.DNI))
            {
                return false;
            }
            else
            {
                clientes.Add(pCliente);
                return true;
            }
        }

        public bool EditarCliente(Cliente pCliente)
        {
            var index = clientes.FindIndex(c => c.IDCliente == pCliente.IDCliente);
            if (index != -1)
            {
                clientes[index] = pCliente;
                return true;
            }
            return false;
        }

        public bool EliminarCliente(int pIdCliente)
        {
            var cliente = clientes.Find(c => c.IDCliente == pIdCliente);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                return true;
            }
            return false;
        }

        public Cliente BuscarClientePorID(int pIdCliente)
        {
            return clientes.Find(c => c.IDCliente == pIdCliente);
        }
    }
}
