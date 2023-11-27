using System.ComponentModel;

namespace EuroTrains.Dtos
{
    public record TrainsSearchParameters(

        [DefaultValue("12/25/2022 10:30:00 AM")]
        DateTime? FromDate,

        [DefaultValue("12/26/2022 10:30:00 AM")]
        DateTime? ToDate,

        [DefaultValue("Vienna")]
        string? From,

        [DefaultValue("Zagreb")]
        string? Destination,

        [DefaultValue(1)]
        int? NumberOfPassengers

        );

}
