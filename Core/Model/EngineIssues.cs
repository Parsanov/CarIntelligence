namespace Core.Model
{
    public class EngineIssues
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public short Severity { get; set; }
        public int TypicalMileageKm { get; set; }
        public short AppliesYearFrom { get; set; }
        public short AppliesYearTo { get; set; }
        public string HowToCheck { get; set; }

        public Engine Engines { get; set; }
        public Guid EnginesId { get; set; }
    }
}