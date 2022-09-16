using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; }
    }
}
