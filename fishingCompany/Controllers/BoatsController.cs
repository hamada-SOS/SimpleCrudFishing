using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using fishingCompany.Data;
using fishingCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace fishingCompany.Controllers
{
    public class BoatsController : Controller
    {
        private readonly ILogger<BoatsController> _logger;
        private readonly ApplicationDbContext _context;

        public BoatsController(ILogger<BoatsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var boats = _context.boats.ToList();
            return View(boats);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Boat boat)
        {
            if(!ModelState.IsValid)
            {
                return View(boat);
            }

            Boat newboat = new Boat(){
                Name = boat.Name,
                Capacity = boat.Capacity,
                Status = boat.Status
                // Create_at = DateTime.Now
            };

            _context.boats.Add(newboat);
            _context.SaveChanges();

            return RedirectToAction("Index", "Boats");
        }


        public IActionResult Edit(int id)
{
    var boat = _context.boats.Find(id); // Fetch the boat by ID
    if (boat == null)
    {
        return RedirectToAction("Index", "Boats");
    }

    return View(boat); // Pass the boat object to the view
}

[HttpPost]
public IActionResult Edit(int id, Boat boat)
{
    var boaty = _context.boats.Find(id); // Find the boat in the database
    if (boaty == null)
    {
        return RedirectToAction("Index", "Boats");
    }

    if (!ModelState.IsValid)
    {
        return View(boat); // Return the form with validation errors
    }

    // Update the boat properties
    boaty.Name = boat.Name;
    boaty.Capacity = boat.Capacity;
    boaty.Status = boat.Status;

    _context.SaveChanges(); // Save changes to the database

    return RedirectToAction("Index", "Boats"); // Redirect to the index page
}

        public IActionResult Delete(int id)
        {
            var boat = _context.boats.Find(id);
            if(boat == null){
                TempData["Error"] = "Boat not found!";
                return RedirectToAction("Index", "Boats");
            }
            try
                {
                    _context.boats.Remove(boat);
                    _context.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    TempData["Error"] = "Cannot delete the boat because it is referenced in other records.";
                    return RedirectToAction("Index", "Boats");
                }

                return RedirectToAction("Index", "Boats");

        }

    }
}