using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class ClienteQuery : IOrdenQuery
    {
        private readonly TiendaContext _context;

        public ClienteQuery(TiendaContext context)
        {
            _context = context;
        }

        public Cliente GetById(int clienteId)
        {
            return _context.Clientes.Include(c=> c.Carritos).FirstOrDefault(s => s.ClienteId == clienteId);
        }

        public List<Cliente> GetClientes()
        {
            throw new NotImplementedException();
        }
    }
}
