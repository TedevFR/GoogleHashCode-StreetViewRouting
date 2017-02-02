namespace GoogleHashCode_StreetViewRouting.Entities
{
    public class Street
    {
        public Junction StartJunction { get; set; }
        public Junction ArrivalJunction { get; set; }

        public int Direction { get; set; }
        public int CrossingTime { get; set; }
        public int Distance { get; set; }

        public double Ponderation
            => Distance / CrossingTime;

        public bool WasVisited { get; set; } = false;
    }
}