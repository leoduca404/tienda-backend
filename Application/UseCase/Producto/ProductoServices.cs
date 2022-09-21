
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase
{
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoCommand _command;
        private readonly IProductoQuery _query;
        
        public ProductoServices(IProductoCommand command, IProductoQuery query)
        {
            _command = command;
            _query = query;
        }   

        public async Task<Producto> AddProducto(string nombre, string descripcion, string marca, string codigo, double precio, string image)
        {
            var newProducto = new Producto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Marca = marca,
                Codigo = codigo,
                Precio = precio,
                Image = image
            };
            await _command.AddProducto(newProducto);
            return newProducto;
        }

        public async Task RemoveProducto(int productoId)
        {
            await _command.RemoveProducto(productoId);
        }

        public Task<List<Producto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Producto GetById(int id)
        {
            return _query.GetById(id);
        }
    }
}
