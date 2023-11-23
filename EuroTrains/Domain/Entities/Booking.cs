

namespace EuroTrains.Domain.Entities
{
    public record Booking(
       Guid TrainId,
       string PassengerEmail,
       byte NumberOfSeats);
}
