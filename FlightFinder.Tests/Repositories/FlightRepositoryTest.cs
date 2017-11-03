using FlightFinder.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FlightFinder.Tests.Repositories
{
    [TestClass]
    public class FlightRepositoryTest
    {
        [TestMethod]
        public void GetAll()
        {
            var repository = FlightRepository.Instance();
            
            Assert.IsTrue(repository.GetAll(null).Count > 0);
        }

        [TestMethod]
        public void SearchAllNoSort()
        {
            var repository = FlightRepository.Instance();

            Assert.IsTrue(repository.Search(null, null, null).Count > 0);
        }

        [TestMethod]
        public void SearchAllSortByDeparts()
        {
            var repository = FlightRepository.Instance();

            var flights = repository.Search(null, null, "Departs");

            Assert.IsTrue(flights.First().Departs.CompareTo(flights.Last().Departs) == -1);
        }

        [TestMethod]
        public void SearchAllSortByMainCabinPrice()
        {
            var repository = FlightRepository.Instance();

            var flights = repository.Search(null, null, "MainCabinPrice");

            Assert.IsTrue(flights.First().MainCabinPrice < flights.Last().MainCabinPrice);
        }

        [TestMethod]
        public void SearchAllSortByFirstClassPrice()
        {
            var repository = FlightRepository.Instance();

            var flights = repository.Search(null, null, "FirstClassPrice");

            Assert.IsTrue(flights.First().FirstClassPrice < flights.Last().FirstClassPrice);
        }

        [TestMethod]
        public void SearchFromSea()
        {
            var repository = FlightRepository.Instance();

            var flights = repository.Search("sea", null, null);

            foreach(var flight in flights)
            {
                Assert.IsTrue(flight.From.ToLower() == "sea");
            }
        }

        [TestMethod]
        public void SearchToLax()
        {
            var repository = FlightRepository.Instance();

            var flights = repository.Search(null, "lax", null);

            foreach (var flight in flights)
            {
                Assert.IsTrue(flight.To.ToLower() == "lax");
            }
        }

        [TestMethod]
        public void SearchFromSeaToLax()
        {
            var repository = FlightRepository.Instance();

            var flights = repository.Search("sea", "lax", null);

            foreach (var flight in flights)
            {
                Assert.IsTrue(flight.From.ToLower() == "sea");
                Assert.IsTrue(flight.To.ToLower() == "lax");
            }
        }
    }
}
