using System.Text.Json;

namespace Core.Model
{
    public class Analyses
    {
        public Guid Id { get; set; }
        public short Score { get; set; }

        /// <summary>Розклад формули по компонентах: ціна, пробіг, болячки.</summary>
        public required JsonDocument Components { get; set; }

        /// <summary>Медіана на момент розрахунку — ринок рухається, тому фіксуємо.</summary>
        public decimal MarketMedianUsd { get; set; }

        /// <summary>Як визначили модифікацію: vin / params / none.</summary>
        public required string MatchSource { get; set; }

        public int FormulaVersion { get; set; }
        public DateTimeOffset ComputedAt { get; set; }

        public Guid ListingId { get; set; }
        public Listings Listing { get; set; } = null!;
    }
}
