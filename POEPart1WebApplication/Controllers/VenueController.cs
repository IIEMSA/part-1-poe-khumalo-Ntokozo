using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POEPart1WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class VenueController : Controller
{
    private readonly EventEaseDbContext _context;

    public VenueController(EventEaseDbContext context)
    {
        _context = context;
    }
     public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Venue venue)
    {
        if (ModelState.IsValid)
        {
            _context.Add(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(venue);
    }
    public async Task<IActionResult> Index()
    {
        var venues = _context.Venues.ToListAsync();
        return View(venues);
    }
}
