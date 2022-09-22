
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
            if (carrito == null)
                throw new ArgumentNullException("El 'Carrito' es requerido");

            await _command.Add(carrito);        
        }

        public void Update(Carrito carrito)
        {
     
        }

        public List<Carrito> GetAll()
        {
            throw new NotImplementedException();
        }  

        public Carrito GetByClientId(int clientId)
        {
            return _query.GetByClientId(clientId);
        }
    }
}
