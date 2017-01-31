namespace GoogleHashCode02_2017.Entities
{
    public class Street
    {
        public Junction StartJunction { get; set; }
        public Junction ArrivalJunction { get; set; }

        public int Direction { get; set; }
        public int Time { get; set; }
        public int Distance { get; set; }

        public double Ponderation
            => Distance / Time;

        public bool WasVisited { get; set; } = false;
    }
}