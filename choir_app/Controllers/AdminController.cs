using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace choir_app.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var vm = new AdminDashboardViewModel
            {
                TotalMembers = await _context.ChoirMembers.CountAsync(m => m.IsActive),
                UpcomingEventsCount = await _context.Events.CountAsync(e => e.Date >= DateTime.Today),
                TotalPhotos = await _context.GalleryImages.CountAsync(),
                TotalNews = await _context.News.CountAsync(),
                RecentEvents = await _context.Events
                                        .OrderByDescending(e => e.Date)
                                        .Take(5).ToListAsync(),
                RecentNews = await _context.News
                                        .OrderByDescending(n => n.CreatedAt)
                                        .Take(5).ToListAsync(),
                RecentPhotos = await _context.GalleryImages
                                        .OrderByDescending(g => g.CreatedAt)
                                        .Take(4).ToListAsync(),
            };
            return View(vm);
        }
    }
}