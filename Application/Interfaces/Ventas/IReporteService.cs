using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Ventas
{
    public interface IReporteServices
    {
        Task<List<Orden>> GetReporteDiario();
        Task<List<Orden>> GetReporteDiario(string producto);

    }
}
