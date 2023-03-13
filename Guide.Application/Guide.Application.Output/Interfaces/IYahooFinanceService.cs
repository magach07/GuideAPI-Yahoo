using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guide.Application.Output.Interfaces
{
    public interface IYahooFinanceService
    {
        Task<string> GetAllYahoFinance();
    }
}