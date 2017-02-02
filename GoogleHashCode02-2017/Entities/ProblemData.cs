using System.Collections.Generic;

namespace GoogleHashCode_StreetViewRouting.Entities
{
    public class ProblemData
    {
        public int NbJunctions;
        public int NbStreets;
        public int NbSecondsMax;
        public int NbCars;
        public int StartJunctionId;
        public List<Junction> Junctions = new List<Junction>();
        public List<Street> Streets = new List<Street>();
    }
}