namespace Core.Model
{
    public class GearBox
    {
        public Guid Id { get; set; }

        /// <summary>Заводський код КПП: MQ200, DQ200, JF011E, ZF6HP.</summary>
        public required string Code { get; set; }

        /// <summary>manual / auto / dct / cvt</summary>
        public required string Kind { get; set; }

        public short? Gears { get; set; }

        public List<GearboxIssues> GearboxIssues { get; set; } = [];
        public List<Powertrains> Powertrains { get; set; } = [];
    }
}
