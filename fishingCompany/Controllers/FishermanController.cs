using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fishingCompany.Data;
using fishingCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace fishingCompany.Controllers
{
 public class FishermanController : Controller
    {
        private readonly ILogger<BoatsController> _logger;
        private readonly ApplicationDbContext _context;

        public FishermanController(ILogger<BoatsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var fisherman = _context.fishermen.ToList();
            return View(fisherman);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fisherman fisherman)
        {
            if(!ModelState.IsValid)
            {
                return View(fisherman);
            }

            Fisherman newfisherman = new Fisherman(){
                Name = fisherman.Name,
                PhoneNumber = fisherman.PhoneNumber,
                HireDate = DateTime.Now,
            };

            _context.fishermen.Add(newfisherman);
            _context.SaveChanges();

            return RedirectToAction("Index", "Fisherman");
        }

public IActionResult Edit(int id)
{
    var catchy = _context.fishermen.Find(id);
    if (catchy == null)
    {
        return RedirectToAction("Index", "Catch");
    }

    return View(catchy);
}

        [HttpPost]
        public IActionResult Edit(int id, Fisherman fisherman)
        {
            var fishermany = _context.fishermen.Find(id);
            if(fishermany == null){
                return RedirectToAction("Index", "Fisherman");
            }

            if(!ModelState.IsValid)
            {
            ViewData["Name"] = fishermany.Name;
            ViewData["PhoneNumber"] = fishermany.PhoneNumber;
            ViewData["HireDate"] = fishermany.HireDate;
            // ViewData["Created aT"] = fishingTrips.CreatedAtAction.ToString("MM/dd/yyyy");
            // ViewData["Status"] = boat.Status;

            return View(fishermany);
            }

            fishermany.Name = fisherman.Name;
            fishermany.PhoneNumber = fisherman.PhoneNumber;
            fishermany.HireDate = fisherman.HireDate;
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Fisherman");



        }

        public IActionResult Delete(int id)
        {
            var fisherman = _context.fishermen.Find(id);
            if(fisherman == null){
                TempData["Error"] = " not found!";
                return RedirectToAction("Index", "Fisherman");
            }
            try
                {
                    _context.fishermen.Remove(fisherman);
                    _context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    TempData["Error"] = "Cannot delete the Fisherman because it is referenced in other records.";
                    return RedirectToAction("Index", "Fisherman");
                }

                return RedirectToAction("Index", "Fisherman");

        }

    }
}