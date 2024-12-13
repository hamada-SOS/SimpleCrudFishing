using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fishingCompany.Data;
using fishingCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace fishingCompany.Controllers
{
 public class CatchController : Controller
    {
        private readonly ILogger<BoatsController> _logger;
        private readonly ApplicationDbContext _context;

        public CatchController(ILogger<BoatsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var catches = _context.catches.ToList();
            return View(catches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Catch catche)
        {
            if(!ModelState.IsValid)
            {
                return View(catche);
            }

            Catch newCatch = new Catch(){
                TripID = catche.TripID,
                FishType = catche.FishType,
                Weight = catche.Weight,
                // Create_at = DateTime.Now
            };

            _context.catches.Add(newCatch);
            _context.SaveChanges();

            return RedirectToAction("Index", "Catch");
        }


        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Catch catche)
        {
            var catchy = _context.catches.Find(id);
            if(catchy == null){
                return RedirectToAction("Index", "Catch");
            }

            if(!ModelState.IsValid)
            {
            ViewData["TripID"] = catchy.TripID;
            ViewData["FishType"] = catchy.FishType;
            ViewData["Weight"] = catchy.Weight;
            // ViewData["Status"] = boat.Status;

            return View(catchy);
            }

            catchy.TripID = catche.TripID;
            catchy.FishType = catche.FishType;
            catchy.Weight = catche.Weight;
            
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Boats");


            // ViewData["Created aT"] = boat.<CreatedAtAction.ToString("MM/dd/yyyy");

        }

        public IActionResult Delete(int id)
        {
            var catche = _context.catches.Find(id);
            if(catche == null){
                TempData["Error"] = "Catch not found!";
                return RedirectToAction("Index", "Catch");
            }
            try
                {
                    _context.catches.Remove(catche);
                    _context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    TempData["Error"] = "Cannot d   elete the chatc because it is referenced in other records.";
                    return RedirectToAction("Index", "Catch");
                }

                return RedirectToAction("Index", "Catch");

        }

    }
}