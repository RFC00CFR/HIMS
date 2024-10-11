using Hims.Data.ClienteRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hims.Arquitecture.Models;

namespace TM.Data.ClienteRepository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        bool AddCliente(Cliente cliente);
        bool DeleteCliente(int id);
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
        Cliente UpdateCliente(Cliente cliente);
        IEnumerable<Cliente> FindClientes(Expression<Func<Cliente, bool>> predicate);
        
    }
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(HimsContext context) : base(context)
        {
        }

        public bool AddCliente(Cliente cliente)
        {
            return Add(cliente);
        }

        public bool DeleteCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return false;
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return GetAll();
        }

        public Cliente GetClienteById(int id)
        {
            return GetById(id);
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            return Update(cliente);
        }

        public IEnumerable<Cliente> FindClientes(Expression<Func<Cliente, bool>> predicate)
        {
            return Find(predicate);
        }
    }
}