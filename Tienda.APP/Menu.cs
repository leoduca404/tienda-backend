using Tienda.APP.Clientes.Services;
using Tienda.APP.Helpers;
using Tienda.APP.Ventas.Services;

namespace Tienda.APP
{
    public class Menu
    {
        private readonly RegistrarClienteServices _clienteServices;
        private readonly LogicaPantalla _logicaPantalla;
        private readonly ReportesServices _reportes;
        private readonly RegistrarVentasServices _ventas;
        public Menu(RegistrarClienteServices clienteServices, LogicaPantalla logicaPantalla,ReportesServices reportes, RegistrarVentasServices ventas)
        {
            _clienteServices = clienteServices;        
            _logicaPantalla = logicaPantalla;
            _reportes = reportes;
            _ventas = ventas;
        }
        
        public async Task InicializarMenuPrincipal()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ResetColor();
                _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Tienda Leoanrdo Duca");
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
        private async Task InicializarMenuCliente()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ResetColor();
                _logicaPantalla.imprimirEncabezado(ConsoleColor.Green, "Operatoria Cliente");
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
        private async Task InicializarMenuAdministrador()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ResetColor();
                _logicaPantalla.imprimirEncabezado(ConsoleColor.Yellow, "Operatoria Administrador");
                _logicaPantalla.imprimirMenu(new List<string>() { "Registrar ventas del día", "Reportes de ventas del día", "Busquedas por producto", "Volver" });
                _logicaPantalla.imprimirPie();

                ConsoleKeyInfo key = Console.ReadKey();
                char caracter = key.KeyChar;

                switch (caracter)
                {
                    case '1':
                        {
                            await _ventas.RegistrarVentaDiaria();
                            break;
                        }
                    case '2':
                        {
                            await _reportes.ReporteVentasDiarias();
                            break;
                        }
                    case '3':
                        {
                            await _reportes.BusquedaVentasDiarias();
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
    }
}
