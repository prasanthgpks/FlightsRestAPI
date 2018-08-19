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
                new Flight{ Id = 1, FlightNumber = "SG 202", DepartureCity = "Melbourne", ArrivalCity = "Singapore", Capacity = 30, startTime=TimeSpan.Parse("10:00:00"),  EndTime=TimeSpan.Parse("18:00:00")},
                new Flight{ Id = 2, FlightNumber = "MH 101", DepartureCity = "Melbourne", ArrivalCity = "Malaysia", Capacity = 50, startTime=TimeSpan.Parse("11:00:00"),  EndTime=TimeSpan.Parse("14:00:00")},
                new Flight{ Id = 3, FlightNumber = "HK 303", DepartureCity = "Melbourne", ArrivalCity = "Hong Kong", Capacity = 75, startTime=TimeSpan.Parse("12:00:00"),  EndTime=TimeSpan.Parse("16:00:00")},
                new Flight{ Id = 4, FlightNumber = "AB 786", DepartureCity = "Melbourne", ArrivalCity = "Abu Dhabi", Capacity = 40, startTime=TimeSpan.Parse("09:00:00"),  EndTime=TimeSpan.Parse("11:00:00")},
                new Flight{ Id = 5, FlightNumber = "TH 856", DepartureCity = "Melbourne", ArrivalCity = "Bangkok", Capacity = 50, startTime=TimeSpan.Parse("08:00:00"),  EndTime=TimeSpan.Parse("12:00:00")}

            };
        }

        public List<Booking> GetBookings()
        {
            return new List<Booking>
            {

                new Booking { Id= 1, BookingDate = DateTime.Now, FlightId = 1 , NumberOfPassengers = 20 },
                new Booking { Id= 2, BookingDate = DateTime.Now, FlightId = 2 , NumberOfPassengers = 30 },
                new Booking { Id= 3, BookingDate = DateTime.Now.Date.AddDays(1), FlightId = 3 , NumberOfPassengers = 10 },
                new Booking { Id= 4, BookingDate = DateTime.Now.Date.AddDays(1), FlightId = 4 , NumberOfPassengers = 5 },
                new Booking { Id= 5, BookingDate = DateTime.Now.Date.AddDays(1), FlightId = 5 , NumberOfPassengers = 5 }

            };
        }
    }
}
