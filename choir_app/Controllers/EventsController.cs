using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims; // NIEZBĘDNE!
using Microsoft.AspNetCore.Identity;

namespace choir_app.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Events.ToList();

            if (User.Identity.IsAuthenticated)
            {
                // Najpewniejszy sposób na pobranie ID w ASP.NET Identity
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userId))
                {
                    ViewBag.Subscriptions = _context.UserEventSubscriptions
                        .Where(s => s.UserId == userId)
                        .Select(s => s.Event)
                        .ToList();
                }
            }
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Subscribe(int eventId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            System.Diagnostics.Debug.WriteLine($"DEBUG: Próba zapisu dla EventId: {eventId}, UserId: '{userId}'");

            if (!string.IsNullOrEmpty(userId))
            {
                bool exists = _context.UserEventSubscriptions.Any(s => s.EventId == eventId && s.UserId == userId);
                if (!exists)
                {
                    _context.UserEventSubscriptions.Add(new UserEventSubscription { EventId = eventId, UserId = userId });
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Details", new { id = eventId });
        }

        // Metody Admina (Create/Delete/Edit) pozostają bez zmian
        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin,Dyrygent")]
        [HttpPost]
        public IActionResult Create(Events e)
        {
            _context.Events.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Delete(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev != null) { _context.Events.Remove(ev); _context.SaveChanges(); }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Edit(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        [HttpPost]
        public IActionResult Edit(Events ev)
        {
            _context.Events.Update(ev);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}