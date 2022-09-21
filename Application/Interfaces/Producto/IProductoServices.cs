using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductoServices
    {
        Task<Producto> AddProducto(string nombre, string descripcion, string marca, string codigo, double precio,string image);
        Task RemoveProducto(int productoId);
        Task<List<Producto>> GetAll();
        Producto GetById(int id);
    }
}
