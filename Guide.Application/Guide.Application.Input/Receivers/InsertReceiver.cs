using Guide.Application.Input.Interfaces;
using Guide.Domain.Entities;

namespace Guide.Application.Input.Receivers
{
    public class InsertReceiver : IInsertReceiver   
    {
        private readonly IYahooInputRepository _inputRepository;

        public InsertReceiver(IYahooInputRepository inputRepository)
        {
            _inputRepository = inputRepository;
        }

        public State Action (List<YahooFinanceEntity> entity)
        {
            try
            {
                foreach (var iten in entity)
                {
                    var action = new YahooFinanceEntity(iten.Date, iten.Value, iten.VariationPreviousDate, iten.VariationFirstDate);
                    _inputRepository.InsertYahooFinance(iten);
                }
                
                return new State(200, "Informacoes adicionadas com sucesso", entity);
            }
            catch (Exception e)
            {
                return new State(500, e.Message, null);
            }
        }
    }
}
