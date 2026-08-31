using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Makes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Models> Models { get; set; }
    }
}
