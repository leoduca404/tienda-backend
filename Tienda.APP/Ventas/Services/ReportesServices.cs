using Application.Interfaces.Ventas;
using Domain.Entities;
using Tienda.APP.Helpers;

namespace Tienda.APP.Ventas.Services
{
    public class ReportesServices
    {        
        private readonly LogicaPantalla _logicaPantalla;
        private readonly IReporteServices _reportesServices; 

        public ReportesServices(LogicaPantalla logicaPantalla, IReporteServices reportesServices)
        {
            _reportesServices = reportesServices;
            _logicaPantalla = logicaPantalla;
        }

        public async Task ReporteVentasDiarias()
        {
            _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Reportes Ventas Diarias");

            List<Orden> ordenes = await _reportesServices.GetReporteDiario();
            _logicaPantalla.imprimirColumnaHead("Cliente", "Producto", "Marca", "Precio", "Fecha");
            int cont = 0;

            foreach (Orden orden in ordenes)
            {                
                foreach (CarritoProducto carritoProducto in orden.Carrito.CarritoProductos)
                {
                    _logicaPantalla.imprimirColumna(
                        orden.Carrito.Cliente.ClienteId.ToString(),
                        carritoProducto.Producto.Nombre,
                        carritoProducto.Producto.Marca,
                        carritoProducto.Producto.Precio.ToString(),
                        orden.Fecha.ToString());
                    cont++;
                }
            }

            if (cont == 0)
                Console.WriteLine("No hay elementos...");

            _logicaPantalla.imprimirSalida();
        }

        public async Task BusquedaVentasDiarias()
        {
            _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Busqueda por producto - Ventas Diarias");

            string producto = _logicaPantalla.obtenerValor("nombre del producto");
            Console.WriteLine();

            List <Orden> ordenes = await _reportesServices.GetReporteDiario(producto);
          
            _logicaPantalla.imprimirColumnaHead("Cliente", "Producto", "Marca", "Precio", "Fecha");
            int cont = 0;

            foreach (Orden orden in ordenes)
            {
                foreach (CarritoProducto carritoProducto in orden.Carrito.CarritoProductos)
                {
                    _logicaPantalla.imprimirColumna(orden.Carrito.Cliente.DNI,
                        carritoProducto.Producto.Nombre,
                        carritoProducto.Producto.Marca,
                        carritoProducto.Producto.Precio.ToString(),
                        orden.Fecha.ToString());
                    cont++;
                }
            }
           
            if(cont == 0)
                Console.WriteLine("No hay elementos...");
           

            _logicaPantalla.imprimirSalida();
        }

    }    
}
