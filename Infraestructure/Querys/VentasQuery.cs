﻿using Application.Interfaces.Ventas;
using Domain.Entities;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class VentasQuery : IVentasQuery
    {
        private readonly TiendaContext _context;

        public VentasQuery(TiendaContext context)
        {
            _context = context;
        }

        public async Task<List<Orden>> GetReporteDiario()
        {
            DateTime now = DateTime.Now;
            DateTime fechaInicioDia = new DateTime(now.Year, now.Month, now.Day, 00, 00, 00);
            DateTime fechaFinDia = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            List<Orden> ordenes = await _context.Ordenes
                  .Include(o => o.Carrito)
                      .ThenInclude(c => c.CarritoProductos)
                      .ThenInclude(cp => cp.Producto)
                  .Include(o => o.Carrito)
                    .ThenInclude(c => c.Cliente)
                  .Where(o => (o.Fecha <= fechaFinDia && o.Fecha >= fechaInicioDia))
                  .AsNoTracking()
                  .ToListAsync();

            return ordenes;
        }

        public async Task<List<Orden>> GetReporteDiario(string producto)
        {
            DateTime now = DateTime.Now;
            DateTime fechaInicioDia = new DateTime(now.Year, now.Month, now.Day, 00, 00, 00);
            DateTime fechaFinDia = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            List<Orden> ordenes = await _context.Ordenes
                  .Include(o => o.Carrito)
                      .ThenInclude(c => c.CarritoProductos.Where(o => o.Producto.Nombre.Contains(producto)))
                      .ThenInclude(cp => cp.Producto)                
                  .Include(o => o.Carrito)
                      .ThenInclude(c => c.Cliente)
                  .Where(o => (o.Fecha <= fechaFinDia && o.Fecha >= fechaInicioDia))
                  .AsNoTracking()
                  .ToListAsync();


            return ordenes;
        }
    }
}
