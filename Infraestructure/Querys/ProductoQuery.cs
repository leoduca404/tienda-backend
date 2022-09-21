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
    public class ProductoQuery : IProductoQuery
    {
        private readonly TiendaContext _context;

        public ProductoQuery(TiendaContext context)
        {
            _context = context;
        }

        public Producto GetById(int productoId)
        {
            return _context.Productos.FirstOrDefault(s => s.ProductoId == productoId);

        }

        public List<Producto> GetProductos()
        {
            throw new NotImplementedException();
        }
    }
}
