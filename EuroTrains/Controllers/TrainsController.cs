﻿using EuroTrains.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EuroTrains.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainsController : ControllerBase
    {
        private readonly ILogger<TrainsController> _logger;

        public TrainsController(ILogger<TrainsController> logger)
        {
            _logger = logger;
        }

        Random random = new Random();

        [HttpGet]
        public IEnumerable<TrainsRm> Search()
            => new TrainsRm[]
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

    }

}