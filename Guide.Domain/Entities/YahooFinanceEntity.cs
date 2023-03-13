namespace Guide.Domain.Entities
{
    public class YahooFinanceEntity
    {
        public YahooFinanceEntity(DateTime date, double value, double variationPreviousDate, double variationFirstDate)
        {
            Date = date;
            Value = value;
            VariationPreviousDate = variationPreviousDate;
            VariationFirstDate = variationFirstDate;
        }

        public YahooFinanceEntity()
        {
            
        }

        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double VariationPreviousDate { get; set; }
        public double VariationFirstDate { get; set; }
    }
}