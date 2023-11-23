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
    }
    
}
