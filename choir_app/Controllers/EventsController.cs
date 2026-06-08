using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

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
            return View(events);
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Create()
        {
            return View();
        }

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

            if (ev != null)
            {
                _context.Events.Remove(ev);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Edit(int id)
        {
            var ev = _context.Events.Find(id);

            if (ev == null)
                return NotFound();

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
