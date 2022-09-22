using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarritoServices
    {
        Task Add(Carrito carrito);
        Carrito GetByClientId(int clientId);
    }
}
