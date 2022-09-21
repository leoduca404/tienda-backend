using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.APP.Services
{
    public class ServicesProducto
    {
        private readonly IProductoServices _services;

        public ServicesProducto(IProductoServices services)
        {
            _services = services;
        }

        public async Task AddProducto(string nombre, string descripcion, string marca, string codigo, double precio, string image)
        {
            await _services.AddProducto(nombre, descripcion, marca, codigo, precio, image); 
        }

        public async Task RemoveProducto(int productoId)
        {
            await _services.RemoveProducto(productoId);
        }

        public Producto GetById(int productoId)
        {
            return _services.GetById(productoId);
        }

    }
}
