using System.Collections.Generic;

namespace FlightFinder.Models
{
    public class FlightSearchRequest
    {
        public FlightSearchRequest()
        {
            Results = new List<Flight>();
        }

        public string From { get; set; }

        public string To { get; set; }

        public string SortField { get; set; }

        public List<Flight> Results { get; set; }
    }
}