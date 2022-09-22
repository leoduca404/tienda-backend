using Application.Interfaces;
using Application.UseCase;
using Domain.Entities;
using Infraestructure.Data;
using Tienda.APP.Helpers;

namespace Tienda.APP.Ventas.Services
{
    public class RegistrarVentasServices
    {
        private readonly LogicaPantalla _logicaPantalla;
        private readonly IClienteServices _clienteServices;
        private readonly IProductoServices _productoServices;
        private readonly ICarritoServices _carritoServices;
        private double _total;

        private readonly TiendaContext _context;

        public RegistrarVentasServices(LogicaPantalla logicaPantalla,
            IClienteServices clienteServices, 
            IProductoServices productoServices, 
            TiendaContext context,
            ICarritoServices carritoServices)
        {
            _logicaPantalla = logicaPantalla;
            _clienteServices = clienteServices;
            _context = context;
            _productoServices = productoServices;
            _carritoServices = carritoServices;
            _total = 0;
        }

        public async Task RegistrarVentaDiaria()
        {
            _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Registrar Venta");

            //Busco el cliente y valido que exista.
            string clienteId;
            clienteId = _logicaPantalla.obtenerValorSoloNumeros("ClienteId");

            Cliente cliente;            
            cliente = _clienteServices.GetById(Int32.Parse(clienteId));

            while (cliente == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Format("Ingrese un cliente valido"));
                clienteId = _logicaPantalla.obtenerValorSoloNumeros("ClienteId");
                Console.ResetColor();
                cliente = _clienteServices.GetById(Int32.Parse(clienteId));
            }

            //Busco Carrito abierto
            Carrito carrito = _carritoServices.GetByClientId(cliente.ClienteId);
            List<CarritoProducto> productos = this.SeleccionarProductos();

            Guid id = Guid.NewGuid();
            var order = new Orden
            {
                OrdenId = Guid.NewGuid(),
                CarritoId = carrito == null ? id: carrito.CarritoId,
                Fecha = DateTime.Now,
                Total = _total
            };

            if (carrito == null)
            {
                carrito = new Carrito
                {
                    CarritoId = id,
                    Cliente = cliente,
                    Estado = false,
                    Orden = order,
                    CarritoProductos = productos
                };

                await _carritoServices.Add(carrito);
            }
            else
            {               
                carrito.Orden = order;
                carrito.CarritoProductos = productos;
                carrito.Estado = false;

                _carritoServices.Update(carrito);
            }

            //Registro ventas
            Console.Write("\n--------------------------------------------------------------------------------\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Operación Exitosa.\n"));
            Console.WriteLine(string.Format("\t- La venta se registro correctamente"));
            _logicaPantalla.imprimirSalida();
        }

        private List<CarritoProducto> SeleccionarProductos()
        {
            List<CarritoProducto> productos = new List<CarritoProducto>() { };
            bool isComprando = true;
            _total = 0;
            while (isComprando)
            {
                string productoId, cantidad;
                productoId = _logicaPantalla.obtenerValorSoloNumeros("ProductoId");

                Producto producto = _productoServices.GetById(Int32.Parse(productoId));

                while (producto == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(string.Format("Ingrese producto valido"));
                    productoId = _logicaPantalla.obtenerValorSoloNumeros("ProductoId");
                    Console.ResetColor();
                    producto = _productoServices.GetById(Int32.Parse(productoId));
                }

                cantidad = _logicaPantalla.obtenerValorSoloNumeros("Cantidad");

                CarritoProducto productoCarrito = new CarritoProducto
                {
                    Producto = producto,
                    Cantidad = Int32.Parse(cantidad)
                };

                _total += producto.Precio * float.Parse(cantidad);

                productos.Add(productoCarrito);

                Console.WriteLine(string.Format("Presione S para salir o enter para continuar"));
                string valor = Console.ReadLine();

                if (valor.ToUpper() == "S")
                    isComprando = false;
            }

            return productos;
        }
    }
}
