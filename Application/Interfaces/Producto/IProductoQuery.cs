using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductoQuery
    {
        List<Producto> GetProductos();
        Producto GetById(int productoId);
    }
}
