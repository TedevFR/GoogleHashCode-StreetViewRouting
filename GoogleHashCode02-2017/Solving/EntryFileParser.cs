using GoogleHashCode_StreetViewRouting.Entities;
using System.Linq;
using Tools.Parsing;

namespace GoogleHashCode_StreetViewRouting.Solving
{
    public class EntryFileParser
    {
        private readonly string FilePath;

        private ProblemData Data;

        public EntryFileParser(string filePath)
        {
            FilePath = filePath;
        }

        public ProblemData Parse()
        {
            Data = new ProblemData();

            using (Parser parser = new Parser(FilePath))
            {
                ParseLine1(parser);
                string lastLine = ParseGpsLines(parser);
                ParseStreets(parser, lastLine);
            }

            return Data;
        }

        private void ParseLine1(Parser parser)
        {
            string line = parser.GetStringLine();
            var tabLine1 = line.Split(' ');
            Data.NbJunctions = int.Parse(tabLine1[0]);
            Data.NbStreets = int.Parse(tabLine1[1]);
            Data.NbSecondsMax = int.Parse(tabLine1[2]);
            Data.NbCars = int.Parse(tabLine1[3]);
            Data.StartJunctionId = int.Parse(tabLine1[4]);
        }
    
        private string ParseGpsLines(Parser parser)
        {
            string line = parser.GetStringLine();
            int currentId = 0;
            while (line.Contains('.'))
            {
                var junction = new Junction();
                junction.Id = currentId++;
                Data.Junctions.Add(junction);

                line = parser.GetStringLine();
            }

            return line;
        }

        private void ParseStreets(Parser parser, string firstLine)
        {
            string line = firstLine;
            do
            {
                var tabStreetLine = line.Split(' ');

                Junction startJunction = Data.Junctions.ElementAt(int.Parse(tabStreetLine[0]));
                Junction arrivalJunction = Data.Junctions.ElementAt(int.Parse(tabStreetLine[1]));

                Street street = new Street();
                street.StartJunction = startJunction;
                street.ArrivalJunction = arrivalJunction;
                street.Direction = int.Parse(tabStreetLine[2]);
                street.CrossingTime = int.Parse(tabStreetLine[3]);
                street.Distance = int.Parse(tabStreetLine[4]);
                Data.Streets.Add(street);

                startJunction.BeginningStreets.Add(street);
                arrivalJunction.EndingStreets.Add(street);

                line = parser.GetStringLine();
            } while (!string.IsNullOrWhiteSpace(line));
        }
    }
}