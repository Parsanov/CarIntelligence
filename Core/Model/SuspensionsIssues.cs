namespace Core.Model
{
    public class SuspensionsIssues
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Severity { get; set; }
        public int TypicalMileageKm { get; set; }
        public string HowToCheck { get; set; }


        public Suspensions Suspensions { get; set; }
        public Guid SuspensionsId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}