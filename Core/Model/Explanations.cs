

namespace Core.Model
{
    public class Explanations
    {
        public Guid Id { get; set; }
        public string PriceBand { get; set; }
        public string ScoreBand { get; set; }
        public string Body { get; set; }
        public string ModelVersion { get; set; }
        public DateTimeOffset GeneratedAt { get; set; }

        public Guid PowertrainsId { get; set; }
        public Powertrains Powertrains { get; set; }
    }
}
