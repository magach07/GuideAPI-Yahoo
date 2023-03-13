using Guide.Domain.Entities;
using Guide.Infrastructure.Shared.Shared;

namespace Guide.Infrastructure.Input.Queries
{
    public class QueryInput : BaseQuery
    {
        public QueryModel InsertABEV3Query(YahooFinanceEntity dto)
        {
            this.Table = Map.GetYahooFinanceTable();
            this.Query = $@"
                INSERT INTO {this.Table}
                VALUES
                (
                    @Date,
                    @Value,
                    @Variation_Previous_Date,
                    @Variation_First_Date
                )
            ";

            this.Parameters = new
            {
                Date = dto.Date,
                Value = dto.Value,
                Variation_Previous_Date = dto.VariationPreviousDate,
                Variation_First_Date = dto.VariationFirstDate
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}