namespace EuroTrains.ReadModels
{
    public record TrainsRm(
        Guid Id,
        string Company,
        string Price,
        TimePlaceRm Departure,
        TimePlaceRm Arrival,
        int RemainingNumberOfSeats
        );
    
}
