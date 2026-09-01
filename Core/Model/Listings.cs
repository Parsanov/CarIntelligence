using System.Text.Json;

namespace Core.Model
{
    /// <summary>Кеш розібраних оголошень. Статистику дає AUTO.RIA, тут її не тримаємо.</summary>
    public class Listings
    {
        public Guid Id { get; set; }

        /// <summary>ID оголошення в AUTO.RIA — природний ключ для upsert.</summary>
        public long AutoriaId { get; set; }

        /// <summary>null = модифікацію не зматчили, показуємо тільки ціну.</summary>
        public Guid? PowertrainId { get; set; }
        public Powertrains? Powertrain { get; set; }

        /// <summary>Продавці публікують VIN не завжди.</summary>
        public string? Vin { get; set; }

        public required string Url { get; set; }
        public decimal PriceUSD { get; set; }
        public int? MileageKm { get; set; }
        public short Year { get; set; }

        /// <summary>Сирий JSON з API — страховка від помилок парсингу.</summary>
        public required JsonDocument RawPayload { get; set; }

        public DateTimeOffset FetchedAt { get; set; }

        public Analyses? Analysis { get; set; }
    }
}
