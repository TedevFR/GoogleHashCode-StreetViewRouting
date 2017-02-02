using GoogleHashCode_StreetViewRouting.Solving;
using System;

namespace GoogleHashCode_StreetViewRouting
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new StreetViewRoutingSolver();
            solver.Solve();

            Console.ReadKey();
        }
    }
}