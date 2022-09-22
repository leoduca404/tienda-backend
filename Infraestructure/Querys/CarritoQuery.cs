using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class CarritoQuery:ICarritoQuery
    {
        private readonly TiendaContext _context;

        public CarritoQuery(TiendaContext context)
        {
            _context = context;
        }

        public Carrito GetById(Guid carritoId)
        {
            return _context.Carritos.FirstOrDefault(s => s.CarritoId == carritoId);
        }

        public List<Carrito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Carrito GetByClientId(int clientId)
        {
            return _context.Carritos.FirstOrDefault(s => (s.ClienteId == clientId && s.Estado == true));
        }
    }
}
