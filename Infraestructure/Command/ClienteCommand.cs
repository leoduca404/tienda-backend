using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Data;


namespace Infraestructure.Command
{
    public class ClienteCommand: IOrdenCommand
    {
        private readonly TiendaContext _context;

        public ClienteCommand(TiendaContext context)
        {
            _context = context;
        }

        public async Task AddCliente(Cliente cliente)
        {
           _context.Add(cliente);
           await _context.SaveChangesAsync();
        }          

        public async Task RemoveCliente(int clienteId)
        {
            _context.Remove(clienteId);
            await _context.SaveChangesAsync();
        }
    }
}
