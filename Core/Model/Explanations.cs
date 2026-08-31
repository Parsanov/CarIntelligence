

namespace Core.Model
{
    public class Explanations
    {
        public Guid Id { get; set; }
        public string PriceBand { get; set; }
        public string ScoreBand { get; set; }
        public string Body { get; set; }
        public string ModelVersion { get; set; }
        public TimeSpan GeneratedAt { get; set; }


    }
}
