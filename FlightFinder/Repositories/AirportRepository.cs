using CsvHelper;
using FlightFinder.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightFinder.Repositories
{
    public class AirportRepository
    {
        private const string SOURCE_FILE_PATH = @"App_Data\airports.csv";

        private static AirportRepository _instance;

        private List<Airport> _airports;

        private AirportRepository()
        {
            Initialize();
        }

        public static AirportRepository Instance()
        {
            if (_instance == null)
            {
                _instance = new AirportRepository();
            }
            return _instance;
        }

        public List<Airport> GetAll()
        {
            // TODO: refactor for custom sort order
            return _airports.OrderBy(a => a.Code).ToList();
        }

        public List<Airport> Search(string prefix)
        {
            return GetAll().Where(a =>
                a.Code.ToLower().Contains(prefix.ToLower()) ||
                a.Name.ToLower().Contains(prefix.ToLower())
            ).ToList();
        }

        private void Initialize()
        {
            var path = (System.Web.HttpContext.Current == null) ?
                SOURCE_FILE_PATH : System.Web.HttpContext.Current.Server.MapPath("~\\" + SOURCE_FILE_PATH);
            using (TextReader textReader = File.OpenText(path))
            {
                var csv = new CsvReader(textReader);
                _airports = csv.GetRecords<Airport>().ToList();
            }
        }
    }
}