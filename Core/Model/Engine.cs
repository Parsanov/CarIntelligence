namespace Core.Model
{
    public class Engine
    {
        public Guid Id { get; set; }

        /// <summary>Заводський код мотора: DV6, BXE, N47D20, 4B12.</summary>
        public required string Code { get; set; }

        public decimal DisplacementL { get; set; }

        /// <summary>petrol / diesel / lpg / hybrid / electric</summary>
        public required string FuelType { get; set; }

        public short? PowerHp { get; set; }

        public List<EngineIssues> EngineIssues { get; set; } = [];
        public List<Powertrains> Powertrains { get; set; } = [];
    }
}
