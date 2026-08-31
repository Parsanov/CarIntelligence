using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Generations
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }

        public Models Models { get; set; }
        public Guid ModelsId { get; set; }

        public List<BodyIssues> BodyIssues { get; set; }
    }
}
