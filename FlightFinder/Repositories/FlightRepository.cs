using CsvHelper;
using FlightFinder.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightFinder.Repositories
{
    public class FlightRepository
    {
        private const string SOURCE_FILE_PATH = @"App_Data\flights.csv";

        private static FlightRepository _instance;

        private List<Flight> _flights;

        private FlightRepository()
        {
            Initialize();
        }

        public static FlightRepository Instance()
        {
            if (_instance == null)
            {
                _instance = new FlightRepository();
            }
            return _instance;
        }

        public List<Flight> GetAll(string sortField)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                return _flights;
            }

            switch (sortField.ToLower())
            {
                case "departs":
                    return _flights.OrderBy(f => f.Departs).ToList();

                case "maincabinprice":
                    return _flights.OrderBy(f => f.MainCabinPrice).ToList();

                case "firstclassprice":
                    return _flights.OrderBy(f => f.FirstClassPrice).ToList();

                default:
                    return _flights;
            }
        }

        public List<Flight> Search(string from, string to, string sortField)
        {
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                return SearchFromTo(from, to, sortField);
            }

            if (!string.IsNullOrEmpty(from))
            {
                return SearchFrom(from, sortField);
            }

            if (!string.IsNullOrEmpty(to))
            {
                return SearchTo(to, sortField);
            }

            return GetAll(sortField);
        }

        private List<Flight> SearchFrom(string from, string sortField)
        {
            return GetAll(sortField).Where(f => f.From.ToLower().Contains(from.ToLower())).ToList();
        }

        private List<Flight> SearchTo(string to, string sortField)
        {
            return GetAll(sortField).Where(f => f.To.ToLower().Contains(to.ToLower())).ToList();
        }

        private List<Flight> SearchFromTo(string from, string to, string sortField)
        {
            return GetAll(sortField).Where(f =>
                f.From.ToLower().Contains(from.ToLower()) &&
                f.To.ToLower().Contains(to.ToLower())
            ).ToList();
        }

        private void Initialize()
        {
            var path = (System.Web.HttpContext.Current == null) ?
                SOURCE_FILE_PATH : System.Web.HttpContext.Current.Server.MapPath("~\\" + SOURCE_FILE_PATH);
            using (TextReader textReader = File.OpenText(path))
            {
                var csv = new CsvReader(textReader);
                _flights = csv.GetRecords<Flight>().ToList();
            }
        }
    }
}