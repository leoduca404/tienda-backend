using Application.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.APP.Helpers;

namespace Tienda.APP.Ventas.Services
{
    public class Reportes
    {
        //private readonly IOrdenServices _servicesOrden;
        private readonly LogicaPantalla _logicaPantalla;
        private readonly TiendaContext _context;

        public Reportes(LogicaPantalla logicaPantalla, TiendaContext context)
        {
            _context = context;
            _logicaPantalla = logicaPantalla;
        }

        public async Task ReporteVentasDiarias()
        {
            _logicaPantalla.imprimirEncabezado(ConsoleColor.Blue, "Reportes Ventas Diarias");

            DateTime now = DateTime.Now;//Parse("2022-09-19 17:52:26.5526611");
            DateTime fechaInicioDia = new DateTime(now.Year, now.Month, now.Day, 00, 00, 00);;
            DateTime fechaFinDia = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59); ;
      

            var ordenes =  await _context.Ordenes
                .Include(o => o.Carrito)
                .ThenInclude(c => c.CarritoProductos)
                .ThenInclude(cp => cp.Producto)
                .Include(o => o.Carrito)
                .ThenInclude(c => c.Cliente)
                .Where(o => (o.Fecha <= fechaFinDia && o.Fecha >= fechaInicioDia))
                .ToListAsync(); 

            Console.ReadLine();
        }    

    }    
}
