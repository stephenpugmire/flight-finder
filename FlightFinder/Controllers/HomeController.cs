using FlightFinder.Models;
using System;
using System.Web.Mvc;

namespace FlightFinder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool search = Convert.ToBoolean(TempData["Search"]);
            if (!search)
            {
                return View(new FlightSearchRequest());
            }

            var request = new FlightSearchRequest
            {
                From = Convert.ToString(TempData["From"]),
                To = Convert.ToString(TempData["To"])
            };
            TempData["From"] = request.From;
            TempData["To"] = request.To;
            TempData["Search"] = true;
            request.Results = Flight.Search(request);
            return View(request);
        }

        [HttpPost]
        public ActionResult Index(FlightSearchRequest request)
        {
            TempData["From"] = request.From;
            TempData["To"] = request.To;
            TempData["Search"] = true;
            request.Results = Flight.Search(request);
            return View(request);
        }

        public ActionResult ClearResults()
        {
            return View(new FlightSearchRequest());
        }

        [HttpPost]
        public JsonResult AirportAutoComplete(string prefix)
        {
            var airports = Airport.Search(prefix);

            return Json(airports);
        }
    }
}