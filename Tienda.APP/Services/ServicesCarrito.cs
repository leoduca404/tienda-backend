using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.APP.Controllers
{
    public class ServicesCarrito
    {
        private readonly ICarritoServices _services;
        public ServicesCarrito(ICarritoServices services)
        {
            _services = services;
        }

        public async Task Add(Carrito carrito)
        {                       
          await _services.Add(carrito);
        }
    }
}
