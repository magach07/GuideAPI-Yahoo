using System.Data;
using Dapper;
using Guide.Application.Output.DTO;
using Guide.Application.Output.Interfaces;
using Guide.Infrastructure.Output.Queries;
using Guide.Infrastructure.Shared.Factory;
using Newtonsoft.Json;

namespace Guide.Infrastructure.Output.Repositories
{
    public class YahooFinanceRepository : IYahooFinanceRepository
    {
        private readonly IYahooFinanceService _service;
        private readonly IDbConnection _connection; 

        public YahooFinanceRepository(IYahooFinanceService service, SqlFactory factory)
        {
            _service = service;
            _connection = factory.GetSqlConnection();
        }

        public async Task<List<YahooFinanceAnalyticsDTO>> GetAll()
        {
            var jsonCompleto = _service.GetAllYahoFinance();
            
            var json = JsonConvert.DeserializeObject<YahooFinanceDTO>(await jsonCompleto);

            List<YahooFinanceAnalyticsDTO> analyticsDTO = new List<YahooFinanceAnalyticsDTO>();
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            var timestamp = json.Chart.Result[0].Timestamp[0];

            for (int i = 0; i < json.Chart.Result[0].Timestamp.Count; i++)
            {
                var valueFirstDate = json.Chart.Result[0].Indicators.Quote[0].Open[0];
                var valueToday = json.Chart.Result[0].Indicators.Quote[0].Open[i];

                YahooFinanceAnalyticsDTO dto = new YahooFinanceAnalyticsDTO();
            
                var date = dateTime.AddSeconds(json.Chart.Result[0].Timestamp[i]).ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                dto.Date = Convert.ToDateTime(date);
                dto.Value = Math.Round(valueToday, 2);
                if (i > 0)
                {
                    var valuePreviousDate = json.Chart.Result[0].Indicators.Quote[0].Open[i - 1];
                    dto.VariationPreviousDate = Math.Round(((valueToday / valuePreviousDate) - 1) * 100, 2);
                    dto.VariationFirstDate = Math.Round(((valueToday / valueFirstDate) - 1) * 100, 2);
                }
                else
                {
                    dto.VariationPreviousDate = 0;
                    dto.VariationFirstDate = 0;
                }
                
                analyticsDTO.Add(dto);
            }

            return analyticsDTO;
        }

        public IEnumerable<YahooFinanceReturnDTO> GetHistoric30Days ()
        {
            var query = new QueryOutput().GetHistoric30Days();

            try
            {
                return _connection.Query<YahooFinanceReturnDTO>(query.Query) as List<YahooFinanceReturnDTO>;
            }
            catch
            {
                throw new Exception("Falha ao recuperar historico.");
            }
        }
    }
}