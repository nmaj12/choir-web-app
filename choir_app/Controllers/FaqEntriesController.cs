using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using choir_app.Data;
using choir_app.Models;

namespace choir_app.Controllers
{
    public class FaqEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FaqEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FaqEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaqEntries.ToListAsync());
        }

        // GET: FaqEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqEntry = await _context.FaqEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faqEntry == null)
            {
                return NotFound();
            }

            return View(faqEntry);
        }

        // GET: FaqEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FaqEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] FaqEntry faqEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faqEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faqEntry);
        }

        // GET: FaqEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqEntry = await _context.FaqEntries.FindAsync(id);
            if (faqEntry == null)
            {
                return NotFound();
            }
            return View(faqEntry);
        }

        // POST: FaqEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] FaqEntry faqEntry)
        {
            if (id != faqEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faqEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqEntryExists(faqEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(faqEntry);
        }

        // GET: FaqEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqEntry = await _context.FaqEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faqEntry == null)
            {
                return NotFound();
            }

            return View(faqEntry);
        }

        // POST: FaqEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faqEntry = await _context.FaqEntries.FindAsync(id);
            if (faqEntry != null)
            {
                _context.FaqEntries.Remove(faqEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqEntryExists(int id)
        {
            return _context.FaqEntries.Any(e => e.Id == id);
        }
    }
}
