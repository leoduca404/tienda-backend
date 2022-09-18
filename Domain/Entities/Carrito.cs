using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrito
    {
        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public bool Estado { get; set; }
        public virtual Orden Orden { get; set; }
        public ICollection<CarritoProducto> CarritoProductos { get; set; }
    }
}
