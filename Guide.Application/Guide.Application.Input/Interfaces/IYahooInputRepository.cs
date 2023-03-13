using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.Domain.Entities;

namespace Guide.Application.Input.Interfaces
{
    public interface IYahooInputRepository
    {
        void InsertYahooFinance(YahooFinanceEntity dto);
    }
}