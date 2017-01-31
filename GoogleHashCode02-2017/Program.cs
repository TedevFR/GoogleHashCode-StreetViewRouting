using GoogleHashCode02_2017.Entities;
using System;

namespace GoogleHashCode02_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "paris_54000.txt";
            
            EntryFileParser parser = new EntryFileParser(filePath);
            ProblemData data = parser.Parse();

            JourneyPlanner planner = new JourneyPlanner(data);
            var journeys = planner.Plan();

            // calcul des ointspi

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