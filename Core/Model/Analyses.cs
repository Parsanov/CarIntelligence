
namespace Core.Model
{
    public class Analyses
    {
        public Guid Id { get; set; }
        public byte Score { get; set; }
        public string Components { get; set; }
        public decimal MarketMedianUsd { get; set; }
        public string MatchScore { get; set; }
        public int FormulaVersion { get; set; }
        public TimeSpan ComputeAt { get; set; }

        public Listings Listings { get; set; }
    }
}
