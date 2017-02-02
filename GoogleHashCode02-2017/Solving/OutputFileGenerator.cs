using GoogleHashCode_StreetViewRouting.Entities;
using System.Collections.Generic;
using System.Linq;
using Tools.Parsing;

namespace GoogleHashCode_StreetViewRouting.Solving
{
    public class OutputFileGenerator
    {
        private string FilePath;

        public OutputFileGenerator(string filePath)
        {
            FilePath = filePath;
        }

        public void Generate(List<Journey> journeys)
        {
            using (FileCreator fileCreator = new FileCreator(FilePath))
            {
                WriteNbCars(journeys, fileCreator);
                WriteJourneys(journeys, fileCreator);
            }
        }

        #region Private methods
        private static void WriteNbCars(List<Journey> journeys, FileCreator fileCreator)
        {
            fileCreator.WriteLine(journeys.Count());
        }

        private void WriteJourneys(List<Journey> journeys, FileCreator fileCreator)
        {
            foreach (Journey journey in journeys)
            {
                WriteJourney(journey, fileCreator);
            }
        }

        private void WriteJourney(Journey journey, FileCreator fileCreator)
        {
            WriteNumberOfJunctions(journey, fileCreator);
            WriteSteps(journey, fileCreator);
        }

        private void WriteNumberOfJunctions(Journey journey, FileCreator fileCreator)
        {
            fileCreator.WriteLine(journey.Steps.Count());
        }

        private void WriteSteps(Journey journey, FileCreator fileCreator)
        {
            foreach (var junction in journey.Steps)
            {
                fileCreator.WriteLine(junction.Id);
            }
        }
        #endregion
    }
}