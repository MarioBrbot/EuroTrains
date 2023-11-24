using EuroTrains.Domain.Entities;

namespace EuroTrains.Data
{
    public class Entities
    {
        public IList<Passenger> Passengers = new List<Passenger>();
        public List<Trains> Trains = new List<Trains>();
    }
}
