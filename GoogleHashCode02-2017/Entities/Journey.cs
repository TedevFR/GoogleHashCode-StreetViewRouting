using System.Collections.Generic;
using System.Diagnostics;

namespace GoogleHashCode02_2017.Entities
{
    [DebuggerDisplay("{Debug}")]
    public class Journey
    {
        public string Debug
            => $"{TotalSeconds}s, {Steps.Count} steps";

        public int CarId { get; set; }
        public List<Junction> Steps { get; set; }
        public int TotalSeconds { get; set; }
        
        public Journey()
        {
            Steps = new List<Junction>();
        }
    }
}