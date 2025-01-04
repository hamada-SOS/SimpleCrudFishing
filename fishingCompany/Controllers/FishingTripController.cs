using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fishingCompany.Data;
using fishingCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace fishingCompany.Controllers
{
 public class FishingTripController : Controller
    {
        private readonly ILogger<BoatsController> _logger;
        private readonly ApplicationDbContext _context;

        public FishingTripController(ILogger<BoatsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var fishingTrips = _context.fishingTrips.ToList();
            return View(fishingTrips);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FishingTrip fishingTrip)
        {
            if(!ModelState.IsValid)
            {
                return View(fishingTrip);
            }

            FishingTrip newfishingTrip = new FishingTrip(){
                TripID = fishingTrip.TripID,
                BoatID = fishingTrip.BoatID,
                Destination = fishingTrip.Destination,
                TripDate = DateTime.Now,
                Status = fishingTrip.Status
            };

            _context.fishingTrips.Add(newfishingTrip);
            _context.SaveChanges();

            return RedirectToAction("Index", "FishingTrip");
        }


public IActionResult Edit(int id)
{
    var catchy = _context.fishingTrips.Find(id);
    if (catchy == null)
    {
        return RedirectToAction("Index", "Catch");
    }

    return View(catchy);
}

        [HttpPost]
        public IActionResult Edit(int id, FishingTrip fishingTrip)
        {
            var fishingTrips = _context.fishingTrips.Find(id);
            if(fishingTrip == null){
                return RedirectToAction("Index", "FishingTrip");
            }

            if(!ModelState.IsValid)
            {
            ViewData["TripID"] = fishingTrips.TripID;
            ViewData["BoatID"] = fishingTrips.BoatID;
            ViewData["TripDate"] = fishingTrips.TripDate;
            ViewData["Destination"] = fishingTrips.Destination;
            ViewData["Status"] = fishingTrips.TripDate;
            // ViewData["Created aT"] = fishingTrips.CreatedAtAction.ToString("MM/dd/yyyy");
            // ViewData["Status"] = boat.Status;

            return View(fishingTrip);
            }

            fishingTrips.TripID = fishingTrip.TripID;
            fishingTrips.BoatID = fishingTrip.BoatID;
            fishingTrips.TripDate = fishingTrip.TripDate;
            fishingTrips.Destination = fishingTrip.Destination;
            fishingTrips.Status = fishingTrip.Status;
            _context.SaveChanges(true);

            return RedirectToAction("Index", "FishingTrip");



        }

        public IActionResult Delete(int id)
        {
            var fishingTrips = _context.fishingTrips.Find(id);
            if(fishingTrips == null){
                TempData["Error"] = "Catch not found!";
                return RedirectToAction("Index", "FishingTrip");
            }
            try
                {
                    _context.fishingTrips.Remove(fishingTrips);
                    _context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    TempData["Error"] = "Cannot d   elete the chatc because it is referenced in other records.";
                    return RedirectToAction("Index", "FishingTrip");
                }

                return RedirectToAction("Index", "FishingTrip");

        }

    }
}