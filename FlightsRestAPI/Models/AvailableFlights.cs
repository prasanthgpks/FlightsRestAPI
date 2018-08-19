using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsRestAPI.Models
{
    /// <summary>
    /// Defines data model of AvailableFlights
    /// </summary>
    
    public class AvailableFlights
    {
        public DateTime Date { get; set; }

        public Flight Flights { get; set; }
        
    }
}
