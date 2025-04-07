using POEPart1WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POEPart1WebApplication.Models;

namespace eventease.Controllers
{
    public class EVENTSController : Controller

    {
        private readonly EventEaseDbContext _context;

        public EVENTSController(EventEaseDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var events = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var events = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (events == null)
            {

                return NotFound();
            }
            return View(events);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var events = await _context.Events.FindAsync(id);
            _context.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(events);

        }

        private bool VenueExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Events events)
        {
            if (id != events.EventId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(events.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }
    }
}
