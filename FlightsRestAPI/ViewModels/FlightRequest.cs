using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlightsRestAPI.ViewModels
{
    public class FlightRequest
    {
        
            
            public DateTime startDate { get; set; }

            
            public DateTime endDate { get; set; }

            
            public int numberOfPax { get; set; }
    }
    
}
