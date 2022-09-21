using Application.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.APP.Helpers;
using Domain.Entities;
using Application.Interfaces.Ventas;

namespace Tienda.APP.Ventas.Services
{
    public class Reportes
    {
        //private readonly IOrdenServices _servicesOrden;
        private readonly LogicaPantalla _logicaPantalla;
        private readonly IReporteServices _reportesServices; 

        public Reportes(LogicaPantalla logicaPantalla, IReporteServices reportesServices)
        {
            _reportesServices = reportesServices;
            _logicaPantalla = logicaPantalla;
        }

        public async Task ReporteVentasDiarias()
        {
            _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Reportes Ventas Diarias");

            List<Orden> ordenes = await _reportesServices.GetReporteDiario();
            _logicaPantalla.imprimirColumnaHead("Cliente", "Producto", "Marca", "Precio", "Fecha");

            foreach (Orden orden in ordenes)
            {                
                foreach (CarritoProducto carritoProducto in orden.Carrito.CarritoProductos)
                {
                    _logicaPantalla.imprimirColumna(orden.Carrito.Cliente.DNI,
                        carritoProducto.Producto.Nombre,
                        carritoProducto.Producto.Marca,
                        carritoProducto.Producto.Precio.ToString(),
                        orden.Fecha.ToString());        
                }
            }
            
            _logicaPantalla.imprimirSalida();
        }

        public async Task BusquedaVentasDiarias()
        {
            _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Busqueda por producto - Ventas Diarias");

            string producto = _logicaPantalla.obtenerValorSoloLetras("nombre del producto");
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
