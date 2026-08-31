
namespace Core.Model
{
    public class Powertrains
    {
        public Guid Id { get; set; }
        public Generations GenerationsId { get; set; }
        public Engine EngineId { get; set; }
        public Suspensions SuspensionsId { get; set; }
        public GearBox GearBoxId { get; set; }
        public string Drive { get; set; }

        public List<Explanations> Explanations { get; set; }
        public List<Listings> Listings { get; set; }
    }
}
