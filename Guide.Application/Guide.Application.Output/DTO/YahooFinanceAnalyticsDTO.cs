using System;

namespace Guide.Application.Output.DTO
{
    public class YahooFinanceAnalyticsDTO
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double VariationPreviousDate { get; set; }
        public double VariationFirstDate { get; set; }
    }
}