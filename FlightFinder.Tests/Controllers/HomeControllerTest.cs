using FlightFinder.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace FlightFinder.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            
            ViewResult result = controller.Index(new Models.FlightSearchRequest()) as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
