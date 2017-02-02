using System.Collections.Generic;

namespace GoogleHashCode_StreetViewRouting.Entities
{
    public class JourneyStep
    {
        public Junction Position;
        public int ElapsedSeconds;
        public List<Street> StreetSteps;
    }
}