
namespace Core.Model
{
    public class Powertrains
    {
        public Guid Id { get; set; }
        public Generations Generations { get; set; }
        public Guid GenerationsId { get; set; }
        public Engine Engine { get; set; }
        public Guid EngineId { get; set; }
        public Suspensions Suspensions { get; set; }
        public Guid SuspensionsId { get; set; }
        public GearBox GearBox { get; set; }
        public Guid GearBoxId { get; set; }
        public string Drive { get; set; }

        public List<Explanations> Explanations { get; set; }
        public List<Listings> Listings { get; set; }
    }
}
