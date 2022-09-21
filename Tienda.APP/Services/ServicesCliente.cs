using Application.Interfaces;
using Tienda.APP.Helpers;

namespace Tienda.APP.Services
{
    public class ServicesCliente
    {
        private readonly IOrdenServices _services;
        private readonly LogicaPantalla _logicaPantalla;

        public ServicesCliente(IOrdenServices services, LogicaPantalla logicaPantalla)
        {
            _services = services;
            _logicaPantalla = logicaPantalla;
        }

        public async Task RegistrarCliente()
        {
            try
            {                
                _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Registrar Cliente");

                string nombre, apellido, dni, direccion, telefono;          
                nombre = _logicaPantalla.obtenerValorSoloLetras("nombre");
                apellido = _logicaPantalla.obtenerValorSoloLetras("apellido");
                dni = _logicaPantalla.obtenerValorSoloNumeros("DNI");
                direccion = _logicaPantalla.obtenerValor("direccion");
                telefono = _logicaPantalla.obtenerValorSoloNumeros("telefono");

                await _services.AddCliente(nombre, apellido, dni, direccion, telefono);

                Console.Write("\n--------------------------------------------------------------------------------\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format("Operación Exitosa.\n"));
                Console.WriteLine(string.Format("\t- El Cliente '{0}' fue dado de alta correctamente", nombre));
                _logicaPantalla.imprimirSalida();
            }
            catch (Exception)
            {
                //TODO: CONTROLAR ERROR
                throw;
            }
        }
    }
}
