using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace choir_app.Controllers
{
    [Authorize(Roles = "Chorzysta,Admin,Dyrygent")]
    public class ChoirDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChoirDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);

            var model = new ChoirDashboard
            {
                News = _context.News
                    .OrderByDescending(x => x.CreatedAt)
                    .Take(5)
                    .ToList(),

                Events = _context.Events
                    .OrderBy(x => x.Date)
                    .Take(5)
                    .ToList(),

                Files = _context.FileResources
                    .OrderByDescending(x => x.UploadedAt)
                    .Take(5)
                    .ToList(),

                MyAttendance = _context.Attendances
                    .Include(x => x.Event)
                    .Where(x => x.UserId == userId)
                    .ToList(),

                MyMember = _context.ChoirMembers
                    .Include(x => x.User)
                    .FirstOrDefault(x => x.UserId == userId)
            };

            return View(model);
        }
    }
}