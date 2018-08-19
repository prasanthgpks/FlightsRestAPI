using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightsRestAPI.Services;
using FlightsRestAPI.Models;
using FlightsRestAPI.ViewModels;

namespace FlightsRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        

        public FlightsController(FlightService flightService)
        {
            _flightService = flightService;
        }

        public FlightService _flightService { get; set; }

        [HttpGet("")]
        public JsonResult GetAllFlights()
        {
            var Result = _flightService.GetAllFlights();

            return new JsonResult(Result);
        }

        [HttpGet("Bookings")]
        public JsonResult GetAllBookings()
        {
            var Result = _flightService.GetAllBookings();

            return new JsonResult(Result);
        }

        [HttpPost("GetAvailableFlights")]
        public IActionResult GetAvailableFlights([FromBody]FlightRequest flightRequest)
        {
            try
            {
                if (flightRequest == null)
                {
                    throw new ArgumentException("Invalid Request");
                }

                if (flightRequest.startDate < DateTime.Now.Date || flightRequest.startDate == DateTime.MinValue)
                {
                    throw new ArgumentException($"Invalid start date {flightRequest.startDate}", nameof(flightRequest.startDate));
                }
                if (flightRequest.endDate < DateTime.Now.Date || flightRequest.endDate == DateTime.MinValue)
                {
                    throw new ArgumentException($"Invalid end date {flightRequest.endDate}", nameof(flightRequest.endDate));
                }
                if (flightRequest.numberOfPax < 1)
                {
                    throw new ArgumentException($"Passenger count has to be atleast 1 { flightRequest.numberOfPax }", nameof(flightRequest.numberOfPax));
                }

                var Result = _flightService.GetAllAvailableFlights(flightRequest.startDate, flightRequest.endDate, flightRequest.numberOfPax);

                return Ok(new JsonResult(Result));
            }
            catch(Exception ex)
            {
                return BadRequest(new JsonResult(ex.Message));
            }
            
        }

    }
}