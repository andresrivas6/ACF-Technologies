using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACF.Models;
using ACF.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACF.Infrastructure.Services
{
    public class SCliente : ICliente
    {
        private readonly AcfDbContext _context;

        public SCliente(AcfDbContext context) {
            _context = context;
        }

        public List<Cliente> GetClientes()
        {
            try
            {
                List<Cliente> Clientes = null;

                using (var context = new AcfDbContext())
                {
                    Clientes = context.Cliente.ToList();
                }

                return Clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            try
            {

                var Cliente = new Cliente();
                using (var context = new AcfDbContext())
                {
                    

                    Cliente = await context.Cliente.Where(o => o.Id == id)
                                                .FirstOrDefaultAsync();
                    
                }
                return Cliente;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<int> CreateCliente(Cliente Cliente)
        {
            int response = 0;
            try
            {
                if (Cliente == null)
                {
                    throw new ArgumentNullException(nameof(Cliente));
                }
                using (var context = new AcfDbContext())
                {

                    await context.Cliente.AddAsync(Cliente);
                }
                response = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task DeleteCliente(Cliente Cliente)
        {
            try
            {
                if (Cliente == null)
                {
                    throw new ArgumentNullException(nameof(Cliente));
                }
                using (var context = new AcfDbContext())
                {
                    context.Cliente.Remove(Cliente);
                    await context.SaveChangesAsync();
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }



        public async Task UpdateCliente(Cliente Cliente)
        {
            try
            {
                if (Cliente == null)
                {
                    throw new ArgumentNullException(nameof(Cliente));
                }
                using (var context = new AcfDbContext())
                {
                    context.Entry(Cliente).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ClienteExists(int id)
        {

            try
            {
                using (var context = new AcfDbContext())
                {
                    return context.Cliente.Any(e => e.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}
