namespace Core.Model
{
    /// <summary>
    /// Конкретна заводська модифікація: покоління + двигун + КПП + підвіска.
    /// Точка, де оголошення з API зустрічається з довідником.
    /// </summary>
    public class Powertrains
    {
        public Guid Id { get; set; }

        public Guid GenerationId { get; set; }
        public Generations Generation { get; set; } = null!;

        public Guid EngineId { get; set; }
        public Engine Engine { get; set; } = null!;

        public Guid GearBoxId { get; set; }
        public GearBox GearBox { get; set; } = null!;

        /// <summary>null = варіантів підвіски немає, стоїть базова.</summary>
        public Guid? SuspensionId { get; set; }
        public Suspensions? Suspension { get; set; }

        /// <summary>fwd / rwd / awd</summary>
        public string? Drive { get; set; }

        public List<Explanations> Explanations { get; set; } = [];
        public List<Listings> Listings { get; set; } = [];
    }
}
