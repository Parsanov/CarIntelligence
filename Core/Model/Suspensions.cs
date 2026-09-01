namespace Core.Model
{
    public class Suspensions
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }

        /// <summary>spring / air / adaptive</summary>
        public required string Kind { get; set; }

        public List<SuspensionsIssues> SuspensionsIssues { get; set; } = [];
        public List<Powertrains> Powertrains { get; set; } = [];
    }
}
