using GoogleHashCode02_2017.Entities;
using GoogleHashCode02_2017.Extensions;
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
                journey.CarId = i;
                int elapsedSeconds = 0;

                Junction startJunction = Data.Junctions.Single(j => j.Id == Data.StartJunctionId);
                startJunction.WasVisited = true;
                journey.Steps.Add(startJunction);
                journey.TotalSeconds = 0;

                Junction currentJunction = startJunction;
                while (elapsedSeconds < Data.NbSecondsMax)
                {
                    Street nextStreet = GetNextStreet(currentJunction, elapsedSeconds);

                    // On a trouvé aucune rue
                    if (nextStreet == null)
                        break;

                    // On n'a pas le temps d'aller à la prochaine rue
                    // TODO : la rue la plus optimale est trop loin mais une autre est peut etre accessible ?
                    if ((elapsedSeconds + nextStreet.CrossingTime) > Data.NbSecondsMax)
                        break;

                    journey.Steps.Add(nextStreet.ArrivalJunction);
                    journey.TotalSeconds += nextStreet.CrossingTime;
                    nextStreet.WasVisited = true;
                    nextStreet.ArrivalJunction.WasVisited = true;
                    currentJunction = nextStreet.ArrivalJunction;
                    elapsedSeconds += nextStreet.CrossingTime;
                }

                Journeys.Add(journey);
            }
            
            return Journeys;
        }

        private Street GetNextStreet(Junction currentJunction, int elapsedSeconds)
        {
            Queue<QueueElement> fifo = new Queue<QueueElement>();
            fifo.Enqueue(new QueueElement {
                ElapsedSeconds = elapsedSeconds,
                Position = currentJunction,
                StreetSteps = new List<Street>()
            });

            HashSet<int> alreadySeenJunctionId = new HashSet<int>();
            alreadySeenJunctionId.Add(currentJunction.Id);

            while(fifo.Count() > 0)
            {
                var qElement = fifo.Dequeue();

                var notVisitedStreets = GetNotVisitedStreets(qElement.Position);

                if (notVisitedStreets.Count() > 0)
                {
                    var street = GetBestPonderationStreet(notVisitedStreets);
                    qElement.StreetSteps.Add(street);
                    return qElement.StreetSteps.First();
                }
                else
                {
                    foreach(var street in qElement.Position.BeginningStreets)
                    {
                        if (!alreadySeenJunctionId.Contains(street.ArrivalJunction.Id))
                        {
                            fifo.Enqueue(new QueueElement
                            {
                                ElapsedSeconds = elapsedSeconds + street.CrossingTime,
                                Position = street.ArrivalJunction,
                                StreetSteps = qElement.StreetSteps.CloneAndAdd(street)
                            });
                            alreadySeenJunctionId.Add(street.ArrivalJunction.Id);
                        }
                    }
                }
            }

            return null; // on n'a rien trouvé !
        }

        private Street GetBestPonderationStreet(List<Street> notVisitedStreets)
        {
            return notVisitedStreets.MaxBy(_ => _.Ponderation);
        }

        private List<Street> GetNotVisitedStreets(Junction junction)
        {
            return junction.BeginningStreets.Where(_ => !_.WasVisited).ToList();
        }
    }
}