using Guide.Application.Output.DTO;

namespace Guide.Application.Output.Interfaces
{
    public interface IYahooFinanceRepository
    {
        Task<List<YahooFinanceAnalyticsDTO>> GetAll();
        IEnumerable<YahooFinanceReturnDTO> GetHistoric30Days();
    }
}