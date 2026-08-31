
namespace Core.Model
{
    public class Listings
    {
        public Guid Id { get; set; }
        public long AutoriaId { get; set; }
        public int PowertrainId { get; set; }
        public string Vin { get; set; }
        public string Url { get; set; }
        public decimal PriceUSD { get; set; }
        public int MileageKm { get; set; }
        public short Year { get; set; }
        public string RawPayload { get; set; }
        public TimeSpan FetchedAt { get; set; }

    }
}
