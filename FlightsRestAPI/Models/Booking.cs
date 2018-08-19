using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsRestAPI.Models
{
    /// <summary>
    /// Defines data model of Booking
    /// </summary>

    public class Booking
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public DateTime BookingDate { get; set; }

        public int NumberOfPassengers { get; set; }
    }
}
