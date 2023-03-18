using Bacen.Dollar.Api.Client.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bacen.Dollar.Api.Client
{
    public interface IBacenDollarClient
    {
        Task<DollarQuotation> DailyDollarQuotation(DateTime date);
        Task<IList<DollarQuotation>> PeriodicDollarQuotation(DateTime fromDate, DateTime toDate);
    }
}
