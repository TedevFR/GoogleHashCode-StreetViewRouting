using System.Collections.Generic;
using System.Diagnostics;

namespace GoogleHashCode_StreetViewRouting.Entities
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Junction
    {
        public string DebuggerDisplay
            => $"Id {Id}";

        public int Id { get; set; }

        public List<Street> BeginningStreets { get; set; }
        public List<Street> EndingStreets { get; set; }

        public bool WasVisited { get; set; }


        public Junction()
        {
            BeginningStreets = new List<Street>();
            EndingStreets = new List<Street>();
        }
    }
}