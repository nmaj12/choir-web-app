using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace choir_app.Controllers
{
    public class FilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FilesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // LISTA
        public IActionResult Index()
        {
            var files = _context.FileResources.ToList();
            return View(files);
        }

        // UPLOAD VIEW
        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Upload()
        {
            return View();
        }

        // UPLOAD LOGIC
        [HttpPost]
        [Authorize(Roles = "Admin,Dyrygent")]
        public async Task<IActionResult> Upload(IFormFile file, string fileType)
        {
            if (file == null || file.Length == 0)
                return RedirectToAction("Index");

            // folder zależny od typu
            var folder = Path.Combine(_env.WebRootPath, "files", fileType);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var path = Path.Combine(folder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var dbFile = new FileResource
            {
                FileName = file.FileName,
                FilePath = "/files/" + fileType + "/" + fileName,
                FileType = fileType
            };

            _context.FileResources.Add(dbFile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // DOWNLOAD
        [Authorize]
        public IActionResult Download(int id)
        {
            var file = _context.FileResources.FirstOrDefault(x => x.Id == id);
            if (file == null) return NotFound();

            var fullPath = Path.Combine(_env.WebRootPath, file.FilePath.TrimStart('/'));

            var bytes = System.IO.File.ReadAllBytes(fullPath);

            return File(bytes, "application/octet-stream", file.FileName);
        }
    }
}