using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsRestAPI.Models;

namespace FlightsRestAPI.Services
{
    public class FlightService
    {
        private FlightsDataBase _flightsDataBase;

        public FlightService(FlightsDataBase flightsDataBase)
        {
            _flightsDataBase = flightsDataBase;
        }

        public List<Flight> GetAllFlights()
        {
            return _flightsDataBase.GetFlights();
        }

        public List<Booking> GetAllBookings()
        {
            return _flightsDataBase.GetBookings();
        }

        public List<AvailableFlights> GetAllAvailableFlights(DateTime FromDate, DateTime ToDate, int Pax)
        {

            if (FromDate < DateTime.Now.Date || FromDate == DateTime.MinValue)
            {
                throw new ArgumentException($"Invalid start date {FromDate}", nameof(FromDate));
            }
            if (ToDate < DateTime.Now.Date || FromDate == DateTime.MinValue)
            {
                throw new ArgumentException($"Invalid end date {ToDate}", nameof(ToDate));
            }
            if (Pax < 1)
            {
                throw new ArgumentException($"Passenger count has to be atleast 1 { Pax }", nameof(Pax));

            }

            var Bookings = _flightsDataBase.GetBookings();

            var Flights = _flightsDataBase.GetFlights();

            var AvailableFlights = new List<AvailableFlights>();

            var DateList = new List<DateTime>();

            for (DateTime date = FromDate.Date; date.Date <= ToDate.Date; date = date.AddDays(1))
            {
                DateList.Add(date);

                foreach (var t in Flights)
                {
                    AvailableFlights.Add(new AvailableFlights { Date = date.Date, Flights = t });
                }
                
            }

            var Modified_AvailableFlights = new List<AvailableFlights>();


            foreach(var AvFlights in AvailableFlights)
            {
                var M_Avl_Flights = new AvailableFlights();
                var M_Flight = new Flight();

                var ts = GetBooking(AvFlights.Date.Date, AvFlights.Flights.Id);
                var originalcapacity = Flights
                                        .Where(o => o.Id == AvFlights.Flights.Id)
                                            .Select(u => u.Capacity)
                                                .FirstOrDefault();

                M_Flight.Id = AvFlights.Flights.Id;
                M_Flight.FlightNumber = AvFlights.Flights.FlightNumber;
                M_Flight.ArrivalCity = AvFlights.Flights.ArrivalCity;
                M_Flight.DepartureCity = AvFlights.Flights.DepartureCity;
                M_Flight.startTime = AvFlights.Flights.startTime;
                M_Flight.EndTime = AvFlights.Flights.EndTime;
                M_Flight.Capacity = (originalcapacity - ts);

                M_Avl_Flights.Date = AvFlights.Date;
                M_Avl_Flights.Flights = M_Flight;

                Modified_AvailableFlights.Add(M_Avl_Flights);

            }

            return Modified_AvailableFlights
                    .Where(v=> (v.Flights.Capacity - Pax) >= 0).ToList();
    }            
        
        public int GetBooking(DateTime date , int flightid)
        {
            return _flightsDataBase
                        .GetBookings()
                            .Where(c => (c.FlightId == flightid && c.BookingDate.Date == date))
                                .Select(h => h.NumberOfPassengers)
                                    .FirstOrDefault();
            }
    }
}
