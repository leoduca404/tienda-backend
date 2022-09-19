using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Data;


namespace Infraestructure.Command
{
    public class CarritoCommand : ICarritoCommand
    {
        private readonly TiendaContext _context;

        public CarritoCommand(TiendaContext context)
        {
            _context = context;
        }

        public async Task Add(Carrito carrito)
        {
           _context.Add(carrito);
           await _context.SaveChangesAsync();
        }  
    }
}
