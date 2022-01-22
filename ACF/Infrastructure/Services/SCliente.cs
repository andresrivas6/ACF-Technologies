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

                //using (var context = new EorContext())
                //{
                Clientes = _context.Cliente.ToList();
                //}

                return Clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _context.Dispose();
            }
        }

        public Cliente GetClienteById(int id)
        {
            try
            {
                var Cliente = new Cliente();

                Cliente = _context.Cliente.Where(o => o.Id == id)
                                                .FirstOrDefault();
                

                return Cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _context.Dispose();
            }

        }

        public void CreateCliente(Cliente Cliente)
        {
            try
            {
                if (Cliente == null)
                {
                    throw new ArgumentNullException(nameof(Cliente));
                }

                _context.Cliente.AddAsync(Cliente);
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _context.Dispose();
            }
        }

        public void DeleteCliente(Cliente Cliente)
        {
            try
            {
                if (Cliente == null)
                {
                    throw new ArgumentNullException(nameof(Cliente));
                }

                _context.Cliente.Remove(Cliente);
                _context.SaveChangesAsync();
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _context.Dispose();
            }
        }



        public void UpdateCliente(Cliente Cliente)
        {
            try
            {
                if (Cliente == null)
                {
                    throw new ArgumentNullException(nameof(Cliente));
                }

                _context.Entry(Cliente).State = EntityState.Modified;
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _context.Dispose();
            }
        }

        public bool ClienteExists(int id)
        {

            try
            {
                return _context.Cliente.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _context.Dispose();
            }
            
        }
    }
}
