
using System.Text.Json;

namespace Core.Model
{
    public class Listings
    {
        public Guid Id { get; set; }
        public long AutoriaId { get; set; }
        public Guid? PowertrainId { get; set; }
        public Powertrains Powertrains { get; set; }
        public string? Vin { get; set; }
        public required string Url { get; set; }
        public decimal PriceUSD { get; set; }
        public int MileageKm { get; set; }
        public short Year { get; set; }
        public required JsonDocument RawPayload { get; set; }
        public DateTimeOffset FetchedAt { get; set; }

    }
}
