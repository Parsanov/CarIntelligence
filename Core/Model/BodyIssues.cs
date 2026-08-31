using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class BodyIssues
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public short Severity { get; set; }
        public string Zone { get; set; }

        public Generations Generations { get; set; }
        public Guid GenerationsId { get; set; }
    }
}
