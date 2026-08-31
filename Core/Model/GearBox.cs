namespace Core.Model
{
    public class GearBox
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Kind { get; set; }
        public short Gears { get; set; }

        public List<GearboxIssues> GearboxIssues { get; set; }
    }
}