﻿using EuroTrains.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System;
using EuroTrains.Dtos;
using EuroTrains.Domain.Entities;
using System.Diagnostics;
using EuroTrains.Domain.Errors;
using EuroTrains.Data;

namespace EuroTrains.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainsController : ControllerBase
    {
        private readonly ILogger<TrainsController> _logger;





        private readonly Entities _entities;


        public TrainsController(ILogger<TrainsController> logger,
            Entities entities)
        {
            _logger = logger;
            _entities = entities;
        }


        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<TrainsRm>), 200)]
        public IEnumerable<TrainsRm> Search()
        {
            var trainsRmList = _entities.Trains.Select(train => new TrainsRm(
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
            var train = _entities.Trains.SingleOrDefault(f => f.Id == id);

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

            var train = _entities.Trains.SingleOrDefault(f => f.Id == dto.TrainId);

            if (train == null)
                return NotFound();

            var error = train.MakeBooking(dto.PassengerEmail, dto.NumberOfSeats);

            if (error is OverbookError)
                return Conflict(new { message = "Not enough seats." });

            return CreatedAtAction(nameof(Find), new { id = dto.TrainId });
        }




    }

}
