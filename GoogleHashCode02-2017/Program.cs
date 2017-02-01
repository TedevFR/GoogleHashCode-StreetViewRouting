using GoogleHashCode02_2017.Entities;
using System;
using System.Linq;

namespace GoogleHashCode02_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "../../EntryFiles/paris_54000.txt";
            
            EntryFileParser parser = new EntryFileParser(filePath);
            ProblemData data = parser.Parse();

            JourneyPlanner planner = new JourneyPlanner(data);
            var journeys = planner.Plan();

            // calcul des ointspi
            int totalPoints = data.Streets.Where(_ => _.WasVisited).Sum(_ => _.Distance);
            Console.WriteLine(totalPoints + " points !");

            foreach(var journey in journeys)
            {
                Console.WriteLine($"Voiture {journey.CarId} : {journey.Steps.Count()} étapes en {journey.TotalSeconds} secondes");
            }

            /*using (FileCreator fc = new FileCreator("submission.txt"))
            {
                fc.WriteLine("coucou");
                int i = 666;
                fc.WriteLine(i.ToString());
                fc.WriteLine("A la prochaine");
            }*/


            Console.ReadKey();
        }
    }
}