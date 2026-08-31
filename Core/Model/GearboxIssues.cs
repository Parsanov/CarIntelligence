using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class GearboxIssues
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public short Severity { get; set; }
        public int TypicalMileageKm { get; set; }
        public short AppliesYearFrom { get; set; }
        public short AppliesYearTo { get; set; }


        public GearBox GearBox { get; set; }
        public Guid GearBoxId { get; set; }
    }
}
