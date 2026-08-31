
namespace Core.Model
{
    public class Models
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Makes MakeId { get; set; }
        public List<Generations> Generations { get; set; }
    }
}
