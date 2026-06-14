using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace choir_app.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public GalleryController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var photos = await _context.GalleryImages
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();
            return View(photos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var photo = await _context.GalleryImages.FindAsync(id);
            if (photo == null) return NotFound();
            return View(photo);
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(GalleryImage model, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsDir = Path.Combine(_env.WebRootPath, "uploads", "gallery");
                Directory.CreateDirectory(uploadsDir);

                var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsDir, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);

                model.ImageUrl = $"/uploads/gallery/{fileName}";
            }

            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UploadedById = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                _context.GalleryImages.Add(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Zdjęcie zostało dodane.";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var photo = await _context.GalleryImages.FindAsync(id);
            if (photo != null)
            {
                if (!string.IsNullOrEmpty(photo.ImageUrl))
                {
                    var filePath = Path.Combine(_env.WebRootPath, photo.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }
                _context.GalleryImages.Remove(photo);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Zdjęcie zostało usunięte.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}