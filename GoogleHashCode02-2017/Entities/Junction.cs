using System.Collections.Generic;

namespace GoogleHashCode02_2017.Entities
{
    public class Junction
    {
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