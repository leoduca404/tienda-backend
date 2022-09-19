using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.APP.Controllers
{
    public class ClienteController
    {
        private readonly IClienteServices _services;

        public ClienteController(IClienteServices services)
        {
            _services = services;
        }

        public async Task AddCliente(string nombre, string apellido, string dni, string direccion, string telefono)
        {
            await _services.AddCliente(nombre, apellido, dni, direccion, telefono); 
        }

        public Cliente GetById(int clientId)
        {
            return _services.GetById(clientId);
        }
    }
}
