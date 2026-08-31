
namespace Core.Model
{
    public class Analyses
    {
        public Guid Id { get; set; }
        public byte Score { get; set; }
        public string Components { get; set; }
        public decimal MarketMedianUsd { get; set; }
        public string MatchSource { get; set; }
        public int FormulaVersion { get; set; }
        public DateTimeOffset ComputeAt { get; set; }

        public Listings Listings { get; set; }
        public Guid ListingsId { get; set; }
    }
}
