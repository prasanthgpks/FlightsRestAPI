using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsRestAPI.Models
{
    /// <summary>
    /// Defines data model of Flight
    /// </summary>

    public class Flight
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public int Capacity { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public TimeSpan startTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
