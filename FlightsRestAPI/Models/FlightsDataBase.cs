using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsRestAPI.Models
{
    public class FlightsDataBase
    {        
        public List<Flight> GetFlights()
        {
            return new List<Flight>
            {
                new Flight{ Id = 1, FlightNumber = "SG 202", DepartureCity = "Melbourne", ArrivalCity = "Singapore", Capacity = 8, startTime=TimeSpan.Parse("10:00:00"),  EndTime=TimeSpan.Parse("18:00:00")},
                new Flight{ Id = 2, FlightNumber = "MH 101", DepartureCity = "Melbourne", ArrivalCity = "Malaysia", Capacity = 7, startTime=TimeSpan.Parse("11:00:00"),  EndTime=TimeSpan.Parse("19:00:00")},
                new Flight{ Id = 3, FlightNumber = "MH 101", DepartureCity = "Melbourne", ArrivalCity = "Malaysia", Capacity = 9, startTime=TimeSpan.Parse("11:00:00"),  EndTime=TimeSpan.Parse("19:00:00")},


            };
        }

        public List<Booking> GetBookings()
        {
            return new List<Booking>
            {

                new Booking { BookingDate = DateTime.Now, FlightId = 1 , NumberOfPassengers = 2 },
                new Booking { BookingDate = DateTime.Now, FlightId = 2 , NumberOfPassengers = 3 },
                new Booking { BookingDate = DateTime.Now.Date.AddDays(1), FlightId = 3 , NumberOfPassengers = 2 }

            };
        }
    }
}
