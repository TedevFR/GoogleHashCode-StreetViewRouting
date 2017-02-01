using GoogleHashCode02_2017.Entities;
using System.Collections.Generic;

namespace GoogleHashCode02_2017
{
    public class QueueElement
    {
        public Junction Position;
        public int ElapsedSeconds;
        public List<Street> StreetSteps;
    }
}