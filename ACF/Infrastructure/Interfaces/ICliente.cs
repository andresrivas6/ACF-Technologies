using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACF.Models;
namespace ACF.Infrastructure.Interfaces
{
    public interface ICliente
    {
        List<Cliente> GetClientes();
        Cliente GetClienteById(int id);
        void CreateCliente(Cliente Cliente);
        void UpdateCliente(Cliente Cliente);
        void DeleteCliente(Cliente Cliente);

        bool ClienteExists(int id);
    }
}
