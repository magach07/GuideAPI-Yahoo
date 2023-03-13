namespace Guide.Application.Output.DTO
{
    public class YahooFinanceReturnDTO
    {
        public int Dia { get; set; }
        public string? Date { get; set; }
        public string? Value { get; set; }
        public string? VariationPreviousDate { get; set; }
        public string? VariationFirstDate { get; set; }
    }
}