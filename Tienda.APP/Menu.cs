using Tienda.APP.Controllers;
using Tienda.APP.Helpers;
using Tienda.APP.Services;
using Tienda.APP.Ventas.Services;

namespace Tienda.APP
{
    public class Menu
    {
        private readonly ServicesCliente _clienteServices;
        private readonly ServicesCarrito _carritoServices;
        private readonly ServicesProducto _productoServices;
        private readonly LogicaPantalla _logicaPantalla;
        private readonly Reportes _reportes;


        public Menu(ServicesCliente clienteServices, ServicesCarrito carritoServices, ServicesProducto productoServices, LogicaPantalla logicaPantalla,Reportes reportes)
        {
            _clienteServices = clienteServices;
            _carritoServices = carritoServices;
            _productoServices = productoServices;
            _logicaPantalla = logicaPantalla;
            _reportes = reportes;
        }
        
        public async Task InicializarMenuPrincipal()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ResetColor();
                _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Tienda Leo");
                _logicaPantalla.imprimirMenu(new List<string>() { "Operatoria Cliente", "Operatoria Administrador", "Salir" });
                _logicaPantalla.imprimirPie();

                ConsoleKeyInfo key = Console.ReadKey();
                char caracter = key.KeyChar;

                switch (caracter)
                {
                    case '1':
                        {
                            await InicializarMenuCliente();
                            break;
                        }
                    case '2':
                        {
                            await InicializarMenuAdministrador();
                            break;
                        }
                    case '3':
                        {
                            _logicaPantalla.imprimirDespedida("Cerrando...");
                            exit = true;
                            break;
                        }
                }
            }
        }
        public async Task InicializarMenuCliente()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ResetColor();
                _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Operatoria Cliente");
                _logicaPantalla.imprimirMenu(new List<string>() { "Registrar Cliente", "Volver" });
                _logicaPantalla.imprimirPie();

                ConsoleKeyInfo key = Console.ReadKey();
                char caracter = key.KeyChar;

                switch (caracter)
                {
                    case '1':
                        {
                             await _clienteServices.RegistrarCliente();
                            break;
                        }         
                    case '2':
                        {
                            _logicaPantalla.imprimirDespedida("Volviendo...");
                            exit = true;
                            break;
                        }
                }
            }
        }
        public async Task InicializarMenuAdministrador()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ResetColor();
                _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Operatoria Administrador");
                _logicaPantalla.imprimirMenu(new List<string>() { "Registrar ventas del día", "Reportes de ventas del día", "Busquedas por producto", "Salir" });
                _logicaPantalla.imprimirPie();

                ConsoleKeyInfo key = Console.ReadKey();
                char caracter = key.KeyChar;

                switch (caracter)
                {
                    case '1':
                        {
                            //RegistrarVentasDiarias();
                            break;
                        }
                    case '2':
                        {
                            await _reportes.ReporteVentasDiarias();
                            break;
                        }
                    case '3':
                        {
                            //BusquedasPorProducto();
                            break;
                        }
                    case '4':
                        {
                            _logicaPantalla.imprimirDespedida("Volviendo...");
                            exit = true;
                            break;
                        }
                }
            }
        }


        //public async Task RegistrarVentas()
        //{
        //    _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Registrar Ventas");

        //    //Busco el cliente y valido que exista.
        //    string clienteId;
        //    clienteId = _logicaPantalla.obtenerValorSoloNumeros("ClienteId");

        //    //TODO: NO DEBERIA SER UN CLIENTE SINO UNA INTERFACE DE ICLIENTE
        //    Cliente cliente;            
        //    cliente = _clienteController.GetById(Int32.Parse(clienteId));

        //    while (cliente == null)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.WriteLine(string.Format("Ingrese cliente valido"));
        //        clienteId = _logicaPantalla.obtenerValorSoloNumeros("ClienteId");
        //        Console.ResetColor();
        //        cliente = _clienteController.GetById(Int32.Parse(clienteId));
        //    }

        //    List<CarritoProducto> productos = new List<CarritoProducto>() { };
        //    bool isComprando = true;
        //    double total = 0;
        //    while (isComprando) {
        //        Console.WriteLine(string.Format("Ingrese el producto: "));
        //        string productoId, cantidad;
        //        productoId = obtenerValorSoloNumeros("ProductoId");

        //        Producto producto = _productoController.GetById(Int32.Parse(productoId));

        //        while (producto == null)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Yellow;
        //            Console.WriteLine(string.Format("Ingrese producto valido"));
        //            productoId = obtenerValorSoloNumeros("ProductoId");
        //            Console.ResetColor();
        //            producto = _productoController.GetById(Int32.Parse(productoId));
        //        }
                
        //        cantidad = obtenerValorSoloNumeros("Cantidad");

        //        CarritoProducto productoCarrito = new CarritoProducto
        //        {
        //            Producto = producto,                    
        //            Cantidad = Int32.Parse(cantidad)                    
        //        };

        //        total += producto.Precio * float.Parse(cantidad);

        //        productos.Add(productoCarrito);

        //        Console.WriteLine(string.Format("Presione S para salir o enter para continuar"));
        //        string valor = Console.ReadLine();

        //        if(valor.ToUpper() == "S")
        //            isComprando = false;
        //    }
     
        //    Guid id = Guid.NewGuid();
        //    var order = new Orden
        //    {
        //        OrdenId = Guid.NewGuid(),
        //        CarritoId = id,
        //        Fecha = DateTime.Now,
        //        Total = total
        //    };
        //    var newCarrito = new Carrito
        //    {
        //        CarritoId = id,
        //        Cliente = cliente,
        //        ClienteId = cliente.ClienteId,
        //        Estado = false,
        //        Orden = order,
        //        CarritoProductos = productos
        //    };

        //    //Creo el carrito para el cliente.
        //    //Carrito carrito;
        //    await _carritoController.Add(newCarrito);

        //    //Registro ventas

        //    Console.Write("\n--------------------------------------------------------------------------------\n\n");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine(string.Format("Operación Exitosa.\n"));
        //    Console.WriteLine(string.Format("\t- La venta se registro correctamente"));
        //    _logicaPantalla.imprimirSalida();
        //}


    }
}
