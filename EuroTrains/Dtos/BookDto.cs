namespace EuroTrains.Dtos
{
    public record BookDto(Guid TrainId,
       string PassengerEmail,
       byte NumberOfSeats);
}
