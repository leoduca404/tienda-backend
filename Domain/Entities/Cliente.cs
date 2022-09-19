﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    { 
        public int ClienteId { get; set; }   
        public string DNI { get; set; }      
        public string Nombre { get; set; } 
        public string Apellido { get; set; }
        public string Direccion { get; set; }    
        public string Telefono { get; set; }
        
        public ICollection<Carrito> Carritos { get; set; }
    }
}
