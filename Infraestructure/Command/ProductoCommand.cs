using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Data;


namespace Infraestructure.Command
{
    public class ProductoCommand: IProductoCommand
    {
        private readonly TiendaContext _context;

        public ProductoCommand(TiendaContext context)
        {
            _context = context;
        }

        public async Task AddProducto(Producto producto)
        {
           _context.Add(producto);
           await _context.SaveChangesAsync();
        }          

        public async Task RemoveProducto(int productoId)
        {
            _context.Remove(productoId);
            await _context.SaveChangesAsync();
        }
    }
}
