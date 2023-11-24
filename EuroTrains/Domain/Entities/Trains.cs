using EuroTrains.Domain.Errors;

namespace EuroTrains.Domain.Entities
{
    public record Trains(
        Guid Id,
        string Company,
        string Price,
        TimePlace Departure,
        TimePlace Arrival,
        int RemainingNumberOfSeats
        )
    { 
        public IList<Booking> Bookings = new List<Booking>();
        public int RemainingNumberOfSeats { get; set; } = RemainingNumberOfSeats;

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
