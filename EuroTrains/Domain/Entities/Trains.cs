using EuroTrains.Domain.Errors;

namespace EuroTrains.Domain.Entities
{
    public class Trains {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public string Price { get; set; }
        public TimePlace Departure { get; set; }
        public TimePlace Arrival { get; set; }
        public int RemainingNumberOfSeats { get; set; }

        public IList<Booking> Bookings = new List<Booking>();

        public Trains() { }


        public Trains(
         Guid id,
         string company,
         string price,
         TimePlace departure,
         TimePlace arrival,
         int remainingNumberOfSeats
        )
        {
            Id = id;
            Company = company;
            Price = price;
            Departure = departure;
            Arrival = arrival;
            RemainingNumberOfSeats = remainingNumberOfSeats;
        }

   


        public object? MakeBooking(string passengerEmail, byte numberOfSeats)
        {
            var train = this;

            if (train.RemainingNumberOfSeats < numberOfSeats)
            {
                return new OverbookError();
            }

            train.Bookings.Add(
                new Booking(
                    passengerEmail,
                    numberOfSeats)
                );

            train.RemainingNumberOfSeats -= numberOfSeats;
            return null;
        }
    }
}
