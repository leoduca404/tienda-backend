using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities{
    public class Orden
    {
     
        public Guid OrdenId { get; set; }
        public Guid CarritoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
       
        public virtual Carrito Carrito { get; set; }
    }
}
