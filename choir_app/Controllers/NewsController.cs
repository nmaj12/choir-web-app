using choir_app.Data;
using choir_app.Models;
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

        public IActionResult Details(int id)
        {
            var article = _context.News.FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }
    }
}
