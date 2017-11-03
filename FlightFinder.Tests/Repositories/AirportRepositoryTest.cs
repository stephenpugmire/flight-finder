using FlightFinder.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FlightFinder.Tests.Repositories
{
    [TestClass]
    public class AirportRepositoryTest
    {
        [TestMethod]
        public void GetAll()
        {
            var repository = AirportRepository.Instance();
            
            Assert.IsTrue(repository.GetAll().Count > 0);
        }

        [TestMethod]
        public void GetAllSorted()
        {
            var repository = AirportRepository.Instance();

            var airports = repository.GetAll();

            Assert.IsTrue(airports.First().Code == "LAS");
            Assert.IsTrue(airports.Last().Code == "SEA");
        }

        [TestMethod]
        public void Search()
        {
            var repository = AirportRepository.Instance();

            var result = repository.Search("seattle");

            Assert.IsTrue(result.First().Code == "SEA");
        }
    }
}
