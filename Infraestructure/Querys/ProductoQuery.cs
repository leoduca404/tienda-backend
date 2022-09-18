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
    public class ProductoQuery : IProductoQuery
    {
        private readonly TiendaContext _context;

        public ProductoQuery(TiendaContext context)
        {
            _context = context;
        }

        public Producto GetProductoById(int productoId)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetProductos()
        {
            throw new NotImplementedException();
        }
    }
}
