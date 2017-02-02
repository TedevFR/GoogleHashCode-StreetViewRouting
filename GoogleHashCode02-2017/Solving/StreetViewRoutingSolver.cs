using GoogleHashCode_StreetViewRouting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode_StreetViewRouting.Solving
{
    public class StreetViewRoutingSolver
    {
        const string EntryFilePath = "../../EntryFiles/paris_54000.txt";
        const string outputFilePath = "../../output.txt";

        public void Solve()
        {
            ProblemData data = GetProblemData();
            List<Journey> journeys = CalculateJourneys(data);

            DisplayResults(data, journeys);

            GenerateOutputFile(journeys);
        }

        private void GenerateOutputFile(List<Journey> journeys)
        {
            var outputFileGenerator = new OutputFileGenerator(outputFilePath);
            outputFileGenerator.Generate(journeys);
        }

        private List<Journey> CalculateJourneys(ProblemData data)
        {
            JourneyPlanner planner = new JourneyPlanner(data);
            var journeys = planner.Plan();
            return journeys;
        }

        private ProblemData GetProblemData()
        {
            EntryFileParser parser = new EntryFileParser(EntryFilePath);
            ProblemData data = parser.Parse();
            return data;
        }

        private void DisplayResults(ProblemData data, List<Journey> journeys)
        {
            int totalPoints = data.Streets.Where(_ => _.WasVisited).Sum(_ => _.Distance);
            Console.WriteLine(totalPoints + " points !");

            foreach (var journey in journeys)
            {
                Console.WriteLine($"Voiture {journey.CarId} : {journey.Steps.Count()} étapes en {journey.TotalSeconds} secondes");
            }
        }
    }
}