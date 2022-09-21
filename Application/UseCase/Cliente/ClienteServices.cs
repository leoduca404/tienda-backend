
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase
{
    public class ClienteServices : IOrdenServices
    {
        private readonly IOrdenCommand _command;
        private readonly IOrdenQuery _query;
        
        public ClienteServices(IOrdenCommand command, IOrdenQuery query)
        {
            _command = command;
            _query = query;
        }   

        public async Task<Cliente> AddCliente(string nombre, string apellido, string dni, string direccion, string telefono)
        {
            var newCliente = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                DNI = dni,
                Direccion = direccion,
                Telefono = telefono,
            };
            await _command.AddCliente(newCliente);
            return newCliente;
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int clientId)
        {
           return _query.GetById(clientId);            
        }
    }
}
