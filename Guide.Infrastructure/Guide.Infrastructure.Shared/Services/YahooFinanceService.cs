using Guide.Application.Output.DTO;
using Guide.Application.Output.Interfaces;
using Newtonsoft.Json;

namespace Guide.Infrastructure.Shared.Services
{
    public class YahooFinanceService : IYahooFinanceService
    {
        public async Task<string> GetAllYahoFinance()
        {
            string yahooFinance = "https://query2.finance.yahoo.com/v8/finance/chart/ABEV3.SA?symbol=ABEV3.SA&period1=1676289600&period2=9999999999&interval=1d";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(yahooFinance);

            var data = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<YahooFinanceDTO>(data);

            return data;
        }
    }
}
