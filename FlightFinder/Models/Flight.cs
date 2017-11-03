using FlightFinder.Repositories;
using System.Collections.Generic;

namespace FlightFinder.Models
{
    public class Flight
    {
        public string From { get; set; }
        public string To { get; set; }
        public string FlightNumber { get; set; }
        public string Departs { get; set; }
        public string Arrives { get; set; }
        public decimal MainCabinPrice { get; set; }
        public decimal FirstClassPrice { get; set; }

        public static List<Flight> Search(FlightSearchRequest request)
        {
            return FlightRepository.Instance().Search(request.From, request.To, request.SortField);
        }
    }
}