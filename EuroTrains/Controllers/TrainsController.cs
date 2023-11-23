using EuroTrains.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System;
using EuroTrains.Dtos;
using EuroTrains.Domain.Entities;
using System.Diagnostics;

namespace EuroTrains.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainsController : ControllerBase
    {
        private readonly ILogger<TrainsController> _logger;

        static Random random = new Random();

        static private Trains[] trains = new Trains[]
        {
                new (   Guid.NewGuid(),
                        "Hrvatske Željeznice",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(1, 3))),
                        new TimePlace("Sisak",DateTime.Now.AddHours(random.Next(4, 10))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hekurudha Shqiptare",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Tirana",DateTime.Now.AddHours(random.Next(1, 10))),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(4, 15))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(1, 15))),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(4, 18))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hrvatske Željeznice",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Osijek",DateTime.Now.AddHours(random.Next(1, 21))),
                        new TimePlace("Koprivnica",DateTime.Now.AddHours(random.Next(4, 21))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hekurudha Shqiptare",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Tirana",DateTime.Now.AddHours(random.Next(1, 23))),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(4, 25))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(1, 15))),
                        new TimePlace("Graz",DateTime.Now.AddHours(random.Next(4, 19))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(1, 55))),
                        new TimePlace("Ljubljana",DateTime.Now.AddHours(random.Next(4, 58))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Salzburg",DateTime.Now.AddHours(random.Next(1, 58))),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(4, 60))),
                        random.Next(1, 853))
        };

        

        public TrainsController(ILogger<TrainsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<TrainsRm>), 200)]
        public IEnumerable<TrainsRm> Search()
        {
            var trainsRmList = trains.Select(train => new TrainsRm(
            train.Id,
            train.Company,
            train.Price,
            new TimePlaceRm(train.Departure.Place.ToString(), train.Departure.Time),
            new TimePlaceRm(train.Arrival.Place.ToString(), train.Arrival.Time),
            train.RemainingNumberOfSeats
            ));

            return trainsRmList;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(TrainsRm), 200)]
        public ActionResult<TrainsRm> Find(Guid id)
        {
            var train = trains.SingleOrDefault(f => f.Id == id);

            if (train == null )
            {
                return NotFound();
            }

            var readModel = new TrainsRm(
                train.Id,
                train.Company,
                train.Price,
                new TimePlaceRm(train.Departure.Place.ToString(), train.Departure.Time),
                new TimePlaceRm(train.Arrival.Place.ToString(), train.Arrival.Time),
                train.RemainingNumberOfSeats
                );

            return Ok(readModel);

        }


        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(200)]
        public IActionResult Book(BookDto dto)
        {
            System.Diagnostics.Debug.WriteLine($"Booking a new train {dto.TrainId}");

            var train = trains.SingleOrDefault(f => f.Id == dto.TrainId);

            if (train == null)
                return NotFound();

            train.Bookings.Add(
                new Booking(
                    dto.TrainId,
                    dto.PassengerEmail,
                    dto.NumberOfSeats)
                );
            return CreatedAtAction(nameof(Find), new { id = dto.TrainId });
        }




    }

}
