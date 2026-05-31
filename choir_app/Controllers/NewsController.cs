using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace choir_app.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var news = _context.News.ToList();

            return View(news);
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        [HttpPost]
        public IActionResult Create(News n)
        {
            n.CreatedAt = DateTime.Now;

            _context.News.Add(n);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Delete(int id)
        {
            var n = _context.News.Find(id);

            if (n != null)
            {
                _context.News.Remove(n);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        public IActionResult Edit(int id)
        {
            var n = _context.News.Find(id);

            if (n == null)
                return NotFound();

            return View(n);
        }

        [Authorize(Roles = "Admin,Dyrygent")]
        [HttpPost]
        public IActionResult Edit(News n)
        {
            var existing = _context.News.Find(n.Id);

            if (existing == null)
                return NotFound();

            existing.Title = n.Title;
            existing.Content = n.Content;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
