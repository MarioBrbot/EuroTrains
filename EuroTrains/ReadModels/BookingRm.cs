namespace EuroTrains.ReadModels
{
    public record BookingRm(
         Guid TrainId,
         string Company,
         string Price,
         TimePlaceRm Arrival,
         TimePlaceRm Departure,
         int NumberOfBookedSeats,
         string PassengerEmail);
}
