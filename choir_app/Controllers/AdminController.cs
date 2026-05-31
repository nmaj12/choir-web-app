using choir_app.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace choir_app.Controllers
{
    [Authorize(Roles = "Admin,Dyrygent")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // DASHBOARD
        public IActionResult Index()
        {
            ViewBag.UsersCount = _userManager.Users.Count();
            ViewBag.EventsCount = _context.Events.Count();
            ViewBag.NewsCount = _context.News.Count();
            ViewBag.ImagesCount = _context.GalleryImages.Count();
            ViewBag.FilesCount = _context.FileResources.Count();
            ViewBag.ChoirCount = _context.ChoirMembers.Count();

            return View();
        }

        // USERS
        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // ASSIGN ROLE
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var currentRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            await _userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Users");
        }
    }
}