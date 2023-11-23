using EuroTrains.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System;
using EuroTrains.Dtos;

namespace EuroTrains.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainsController : ControllerBase
    {
        private readonly ILogger<TrainsController> _logger;

        static Random random = new Random();

        static private TrainsRm[] trains = new TrainsRm[]
        {
                new (   Guid.NewGuid(),
                        "Hrvatske Željeznice",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Zagreb",DateTime.Now.AddHours(random.Next(1, 3))),
                        new TimePlaceRm("Sisak",DateTime.Now.AddHours(random.Next(4, 10))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hekurudha Shqiptare",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Tirana",DateTime.Now.AddHours(random.Next(1, 10))),
                        new TimePlaceRm("Zagreb",DateTime.Now.AddHours(random.Next(4, 15))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Vienna",DateTime.Now.AddHours(random.Next(1, 15))),
                        new TimePlaceRm("Zagreb",DateTime.Now.AddHours(random.Next(4, 18))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hrvatske Željeznice",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Osijek",DateTime.Now.AddHours(random.Next(1, 21))),
                        new TimePlaceRm("Koprivnica",DateTime.Now.AddHours(random.Next(4, 21))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hekurudha Shqiptare",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Tirana",DateTime.Now.AddHours(random.Next(1, 23))),
                        new TimePlaceRm("Vienna",DateTime.Now.AddHours(random.Next(4, 25))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Vienna",DateTime.Now.AddHours(random.Next(1, 15))),
                        new TimePlaceRm("Graz",DateTime.Now.AddHours(random.Next(4, 19))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Vienna",DateTime.Now.AddHours(random.Next(1, 55))),
                        new TimePlaceRm("Ljubljana",DateTime.Now.AddHours(random.Next(4, 58))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlaceRm("Salzburg",DateTime.Now.AddHours(random.Next(1, 58))),
                        new TimePlaceRm("Zagreb",DateTime.Now.AddHours(random.Next(4, 60))),
                        random.Next(1, 853))
        };


        static private IList<BookDto> Bookings = new List<BookDto>();

        public TrainsController(ILogger<TrainsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<TrainsRm>), 200)]
        public IEnumerable<TrainsRm> Search()
            => trains;

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

            return Ok(train);

        }


        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(200)]
        public IActionResult Book(BookDto dto)
        {
            System.Diagnostics.Debug.WriteLine($"Booking a new train {dto.TrainId}");

            var trainFound = trains.Any(f => f.Id == dto.TrainId);

            if (trainFound == false)
                return NotFound();

            Bookings.Add(dto);
            return CreatedAtAction(nameof(Find), new { id = dto.TrainId });
        }




    }

}
