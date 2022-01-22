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
        Task<Cliente> GetClienteById(int id);
        Task<int> CreateCliente(Cliente Cliente);
        Task UpdateCliente(Cliente Cliente);
        Task DeleteCliente(Cliente Cliente);

        bool ClienteExists(int id);
    }
}
