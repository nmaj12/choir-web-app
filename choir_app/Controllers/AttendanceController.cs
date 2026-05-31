using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace choir_app.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Name);

            var list = _context.Attendances
                .Include(a => a.Event)
                .Where(a => a.UserId == userEmail)
                .ToList();

            return View(list);
        }

        public IActionResult Set(int eventId, string status)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Name);

            var attendance = new Attendance
            {
                EventId = eventId,
                Status = status,
                UserId = userEmail
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return RedirectToAction("Index", "Events");
        }
    }
}