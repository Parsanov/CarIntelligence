
namespace Core.Model
{
    public class Engine
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal DisplacementL { get; set; }
        public string FuelType { get; set; }
        public short PowerHp { get; set; }

        public List<EngineIssues> EngineIssues { get; set; }
    }
}
