﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EuroTrains.Dtos;
using EuroTrains.ReadModels;
using EuroTrains.Domain.Entities;
using EuroTrains.Data;

namespace EuroTrains.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly Entities _entities;

        public PassengerController(Entities entities)
        {
            _entities = entities;
        }


        [HttpPost]
            [ProducesResponseType(201)]
            [ProducesResponseType(400)]
            [ProducesResponseType(500)]
            public IActionResult Register(NewPassengerDto dto)
            {
            if (_entities.Passengers.Contains(new Passenger(
                        dto.Email,
                        dto.FirstName,
                        dto.LastName,
                        dto.Gender
                        )))
            {
            }
            else
            {
                _entities.Passengers.Add(new Passenger(
                        dto.Email,
                        dto.FirstName,
                        dto.LastName,
                        dto.Gender
                        ));
                _entities.SaveChanges();
            }

            return CreatedAtAction(nameof(Find), new { email = dto.Email });
            }

            [HttpGet("{email}")]
            public ActionResult<PassengerRm> Find(string email)
            {
                var passenger = _entities.Passengers.FirstOrDefault(p => p.Email == email);

                if (passenger == null)
                    return NotFound();

                var rm = new PassengerRm(
                    passenger.Email,
                    passenger.FirstName,
                    passenger.LastName,
                    passenger.Gender
                    );

                return Ok(rm);
            }

    }
}
