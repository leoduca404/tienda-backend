
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase
{
    public class CarritoServices : ICarritoServices
    {
        private readonly ICarritoCommand _command;
        private readonly ICarritoQuery _query;
        
        public CarritoServices(ICarritoCommand command, ICarritoQuery query)
        {
            _command = command;
            _query = query;
        }   

        public async Task Add(Carrito carrito)
        {
            //Guid id = Guid.NewGuid();

            //var order = new Orden
            //{
            //    OrdenId = Guid.NewGuid(),
            //    CarritoId = id,
            //    Fecha = DateTime.Now,
            //    Total = 0
            //};

            //var newCarrito = new Carrito
            //{
            //    CarritoId = id,   
            //    Cliente = cliente,      
            //    ClienteId= cliente.ClienteId,
            //    Estado = true, 
            //    Orden = order,
            //};                      

            await _command.Add(carrito);
        
        }

        public List<Carrito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Carrito GetById(Guid clientId)
        {
           return _query.GetById(clientId);            
        }
    }
}
