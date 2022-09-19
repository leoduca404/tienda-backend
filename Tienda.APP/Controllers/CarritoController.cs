using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.APP.Controllers
{
    public class CarritoController
    {
        private readonly ICarritoServices _services;
        public CarritoController(ICarritoServices services)
        {
            _services = services;
        }

        public async Task<Carrito> Add(Cliente cliente)
        {                       
          return await _services.Add(cliente);
        }
    }
}
