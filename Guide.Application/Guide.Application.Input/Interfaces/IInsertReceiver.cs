using Guide.Application.Input.Receivers;
using Guide.Domain.Entities;

namespace Guide.Application.Input.Interfaces
{
    public interface IInsertReceiver
    {
        public State Action (List<YahooFinanceEntity> entity);
    }
}