namespace Core.Model
{
    public class Makes
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public List<Models> Models { get; set; } = [];
    }
}
