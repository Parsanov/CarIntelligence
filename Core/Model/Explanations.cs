namespace Core.Model
{
    /// <summary>
    /// Кеш текстів від LLM. Ключ — модифікація + діапазон ціни + діапазон оцінки,
    /// бо для схожих авто текст практично однаковий.
    /// </summary>
    public class Explanations
    {
        public Guid Id { get; set; }

        /// <summary>below / market / above</summary>
        public required string PriceBand { get; set; }

        /// <summary>low / mid / high</summary>
        public required string ScoreBand { get; set; }

        public required string Body { get; set; }

        /// <summary>Яка модель згенерувала — щоб знати, що перегенеровувати.</summary>
        public string? ModelVersion { get; set; }

        public DateTimeOffset GeneratedAt { get; set; }

        public Guid PowertrainId { get; set; }
        public Powertrains Powertrain { get; set; } = null!;
    }
}
