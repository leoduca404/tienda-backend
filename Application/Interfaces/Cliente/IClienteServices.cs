using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrdenServices
    {
        Task<Cliente> AddCliente(string nombre, string apellido, string dni, string direccion, string telefono);
        List<Cliente> GetAll();
        Cliente GetById(int id);
    }
}
