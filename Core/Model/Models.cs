namespace Core.Model
{
    public class Models
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public Guid MakeId { get; set; }
        public Makes Make { get; set; } = null!;

        public List<Generations> Generations { get; set; } = [];
    }
}
