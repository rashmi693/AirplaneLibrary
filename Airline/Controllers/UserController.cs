using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirplaneLib;
using Airline.Models;
namespace Airline.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            FlightDal fd = new FlightDal();
            ViewBag.arrival = fd.GetArrivalCitiesS();
            ViewBag.depart = fd.GetDepartCities();
            return View();
        }
        [HttpPost]
        public ActionResult Index(FlightTime fp)
        {
            FlightDal fd = new FlightDal();
            FlightDetails f = new FlightDetails();
            f.Arrival_Airport = fp.ArrivalAirport;
            f.Depart_Airport = fp.DepartureAirport;
            f.Depart_Time = fp.FlightDate;
            List<FlightDetails> mylist = new List<FlightDetails>();
            List<FlightModel> flist = new List<FlightModel>();
           
            mylist = fd.FindFlights(f);
            
            foreach (var item in mylist)
            {
                FlightModel fm = new FlightModel();
                fm.Amount = item.Amount;
                fm.Arrival_Airport = item.Arrival_Airport;
                fm.Depart_Airport = item.Depart_Airport;
                fm.Arrival_Time = item.Arrival_Time;
                fm.Depart_Time = item.Depart_Time;
                fm.Flightno = item.Flightno;
                fm.Seating_Capacity = item.Seating_Capacity;
                fm.Availaible_Seat = fd.FindSeat(item.Flightno);
                flist.Add(fm);

            }

            TempData["FP"] = flist;
            return RedirectToAction("ShowFlights");
        }
        public ActionResult BookFlights(String id)
        {


            return View();
        }
        public ActionResult ShowFlights()
        {

            List<FlightModel> flist = TempData["FP"] as List<FlightModel>; 
            if (flist.Count== 0)
            {
                ViewBag.error = "Sorry No Flights Availaible!! Change your Choice..";
                
            }
            
            return View(flist);
        }
       

    }
}