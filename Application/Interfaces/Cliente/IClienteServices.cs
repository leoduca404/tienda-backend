using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteServices
    {
        Task<Cliente> AddCliente(string nombre, string apellido, string dni, string direccion, string telefono);
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
    }
}
