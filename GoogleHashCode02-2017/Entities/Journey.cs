using System.Collections.Generic;

namespace GoogleHashCode02_2017.Entities
{
    public class Journey
    {
        public int CarId { get; set; }
        public List<Junction> Steps { get; set; }
        
        public Journey()
        {
            Steps = new List<Junction>();
        }
    }
}