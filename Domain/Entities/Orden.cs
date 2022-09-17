using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities{
    public class Orden
    {
        public int OrdenId { get; set; }
        public int CarritoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
    }
}
