using FlightFinder.Repositories;
using System.Collections.Generic;

namespace FlightFinder.Models
{
    public class Airport
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public static List<Airport> GetAll()
        {
            return AirportRepository.Instance().GetAll();
        }

        public static List<Airport> Search(string prefix)
        {
            return AirportRepository.Instance().Search(prefix);
        }
    }
}