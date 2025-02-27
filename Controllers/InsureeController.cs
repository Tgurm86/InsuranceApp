using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 
using InsuranceApp.Models; 
using InsuranceApp.Data; 
 
namespace InsuranceApp.Controllers 
{ 
    public class InsureeController : Controller 
    { 
        private readonly InsuranceDbContext _context; 
 
        public InsureeController(InsuranceDbContext context) 
        { 
            _context = context; 
        } 
 
        // GET: Insuree/Create 
        public IActionResult Create() 
        { 
            return View(); 
        } 
 
        // POST: Insuree/Create 
        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create(Insuree insuree) 
        { 
            if (ModelState.IsValid) 
            { 
                // Calculate the quote based on the guidelines 
                decimal quote = 50m; // Base quote of $50/month 
 
                // Age-based adjustments 
                if (insuree.Age <= 18) 
                { 
                    quote += 100m; // Add $100 for 18 or under 
                } 
                else if (insuree.Age >= 19 && insuree.Age <= 25) 
                { 
                    quote += 50m; // Add $50 for 19-25 
                } 
                else if (insuree.Age >= 26) 
                { 
                    quote += 25m; // Add $25 for 26 or older 
                } 
 
                // Car year adjustments 
                if (insuree.CarYear < 2000) 
                { 
                    quote += 25m; // Add $25 for cars before 2000 
                } 
                else if (insuree.CarYear > 2015) 
                { 
                    quote += 25m; // Add $25 for cars after 2015 
                } 
 
                // Car make and model adjustments 
                if (insuree.CarMake?.ToLower() == "porsche") 
                { 
                    quote += 25m; // Add $25 for any Porsche 
                    if (insuree.CarModel?.ToLower() == "911 carrera") 
                    { 
                        quote += 25m; // Add an additional $25 for Porsche 911 Carrera 
                    } 
                } 
 
                // Speeding tickets adjustment 
                quote += insuree.SpeedingTickets * 10m; // Add $10 per speeding ticket 
 
                // DUI adjustment 
                if (insuree.HasDUI) 
                { 
                    quote *= 1.25m; // Add 25 to the total for DUI 
                } 
 
                // Full coverage adjustment 
                if (insuree.IsFullCoverage) 
                { 
                    quote *= 1.5m; // Add 50 to the total for full coverage 
                } 
 
                // Assign the calculated quote to the Insuree model 
                insuree.Quote = quote; 
 
                _context.Insurees.Add(insuree); 
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index)); 
            } 
            return View(insuree); 
        } 
 
        // GET: Insuree/Admin 
        public async Task<IActionResult> Admin() 
        { 
            var insurees = await _context.Insurees.ToListAsync(); 
            return View(insurees); 
        } 
 
        // GET: Insuree/Index (optional) 
        public async Task<IActionResult> Index() 
        { 
            var insurees = await _context.Insurees.ToListAsync(); 
            return View(insurees); 
        } 
    } 
} 
