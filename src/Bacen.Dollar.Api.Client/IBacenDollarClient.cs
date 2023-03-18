using Bacen.Dollar.Api.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bacen.Dollar.Api.Client
{
    public interface IBacenDollarClient
    {
        Task<DollarQuotation> DailyDollarQuotationAsync(DateTime date);
        Task<IList<DollarQuotation>> PeriodicDollarQuotationAsync(DateTime fromDate, DateTime toDate);
    }
}
