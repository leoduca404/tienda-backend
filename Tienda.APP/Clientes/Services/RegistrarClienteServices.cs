using Application.Interfaces;
using Tienda.APP.Helpers;

namespace Tienda.APP.Clientes.Services
{
    public class RegistrarClienteServices
    {
        private readonly IClienteServices _services;
        private readonly LogicaPantalla _logicaPantalla;

        public RegistrarClienteServices(IClienteServices services, LogicaPantalla logicaPantalla)
        {
            _services = services;
            _logicaPantalla = logicaPantalla;
        }

        public async Task RegistrarCliente()
        {           
            _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Registrar Cliente");

            string nombre, apellido, dni, direccion, telefono;
            nombre = _logicaPantalla.obtenerValorSoloLetras("nombre", 25);
            apellido = _logicaPantalla.obtenerValorSoloLetras("apellido", 25);
            dni = _logicaPantalla.obtenerValorSoloNumeros("DNI", 10);
            direccion = _logicaPantalla.obtenerValor("direccion");
            telefono = _logicaPantalla.obtenerValorSoloNumeros("telefono", 13);

            await _services.AddCliente(nombre, apellido, dni, direccion, telefono);

            Console.Write("\n--------------------------------------------------------------------------------\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Operación Exitosa.\n"));
            Console.WriteLine(string.Format("\t- El Cliente '{0}' fue dado de alta correctamente", nombre));
            _logicaPantalla.imprimirSalida();        
        }
    }
}
