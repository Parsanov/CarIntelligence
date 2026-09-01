namespace Core.Model
{
    public class Generations
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public short YearFrom { get; set; }

        /// <summary>null = ще випускається.</summary>
        public short? YearTo { get; set; }

        public Guid ModelId { get; set; }
        public Models Model { get; set; } = null!;

        public List<BodyIssues> BodyIssues { get; set; } = [];
        public List<Powertrains> Powertrains { get; set; } = [];
    }
}
