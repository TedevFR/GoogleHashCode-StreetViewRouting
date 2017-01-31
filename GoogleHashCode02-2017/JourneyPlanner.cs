using GoogleHashCode02_2017.Entities;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode02_2017
{
    public class JourneyPlanner
    {
        private ProblemData Data;
        private List<Journey> Journeys;

        public JourneyPlanner(ProblemData data)
        {
            Data = data;
        }

        public List<Journey> Plan()
        {
            Journeys = new List<Journey>();

            
            // Pour chaque voiture
            for (int i = 1; i <= Data.NbCars; i++)
            {
                Journey journey = new Journey();
                journey.CarId = 0;
                int elapsedSeconds = 0;

                Junction startJunction = Data.Junctions.Single(j => j.Id == Data.StartJunctionId);
                startJunction.WasVisited = true;
                journey.Steps.Add(startJunction);

                Junction currentJunction = startJunction;
                while (elapsedSeconds < Data.NbSecondsMax)
                {
                    Street nextStreet = GetNextStreet(currentJunction, elapsedSeconds);

                    journey.Steps.Add(nextStreet.ArrivalJunction);
                    nextStreet.WasVisited = true;
                    nextStreet.ArrivalJunction.WasVisited = true;
                    currentJunction = nextStreet.ArrivalJunction;
                    elapsedSeconds += nextStreet.Time;
                }
            }
            
            return Journeys;
        }

        private Street GetNextStreet(Junction currentJunction, int elapsedSeconds)
        {
            var notVisitedStreets = currentJunction.BeginningStreets.Where(_ => !_.WasVisited);

            Street nextStreet;
            if (notVisitedStreets.Count() > 0)
            {
                // il existe un chemin non visité
                nextStreet = notVisitedStreets.MaxBy(_ => _.Ponderation);
            }
            else
            {
                // tous les chemins ont déjà été visités
                nextStreet = GetNextStreet(currentJunction, elapsedSeconds, Data.NbSecondsMax);
            }

            return nextStreet;
        }

        private static Street GetNextStreet(Junction position, int secondeEcoule, int nbSecondsMax)
        {
            var streetNonVisite = position.BeginningStreets.Where(s => !s.WasVisited
                && (secondeEcoule + s.Time) <= nbSecondsMax);
            ; ; ; ; ; ;
            if (streetNonVisite.Count() > 0)
                return streetNonVisite.MaxBy(_ => _.Ponderation);


            foreach (var s in position.BeginningStreets)
            {
                return GetNextStreet(s.ArrivalJunction, secondeEcoule + s.Time, nbSecondsMax);
            }

            return null;
        }

    }
}