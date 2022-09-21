using Application.Interfaces;
using Application.Interfaces.Ventas;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Ventas
{
    public class ReporteServices:IReporteServices
    {
        private readonly IVentasQuery _query;
        public ReporteServices(IVentasQuery query)
        {   
            _query = query;
        }
        public Task<List<Orden>> GetReporteDiario()
        {
           return _query.GetReporteDiario();
        }

        public Task<List<Orden>> GetReporteDiario(string producto)
        {
            return _query.GetReporteDiario(producto);
        }
    }
}
