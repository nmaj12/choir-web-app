using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            var images = _context.GalleryImages.ToList();
            return View(images);
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Upload()
        {
            return View();
        }

        // UPLOAD
        [HttpPost]
        [Authorize(Roles = "Admin,Dyrygent")]
        public async Task<IActionResult> Upload(IFormFile image, string title)
        {
            if (image == null || image.Length == 0)
                return RedirectToAction("Index");

            var folder = Path.Combine(_env.WebRootPath, "gallery");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);

            var fullPath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var img = new GalleryImage
            {
                Title = title,
                ImageUrl = "/gallery/" + fileName
            };

            _context.GalleryImages.Add(img);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // DELETE
        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Delete(int id)
        {
            var img = _context.GalleryImages.FirstOrDefault(x => x.Id == id);

            if (img != null)
            {
                var fullPath = Path.Combine(_env.WebRootPath, img.ImageUrl.TrimStart('/'));

                if (System.IO.File.Exists(fullPath))
                    System.IO.File.Delete(fullPath);

                _context.GalleryImages.Remove(img);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}