using choir_app.Models;
using choir_app.Models.Enums;
using choir_app.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace choir_app.Controllers
{
    [Authorize(Roles = "Admin,Dyrygent")]
    public class ChoirMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChoirMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var members = await _context.ChoirMembers
                .Include(x => x.User)
                .ToListAsync();

            return View(members);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string userId, VoiceType voice)
        {
            var member = new ChoirMember
            {
                UserId = userId,
                Voice = voice
            };

            _context.ChoirMembers.Add(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var member = await _context.ChoirMembers
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (member == null) return NotFound();

            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VoiceType voice)
        {
            var member = await _context.ChoirMembers.FindAsync(id);

            if (member == null) return NotFound();

            member.Voice = voice;

            _context.Update(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.ChoirMembers
                .FirstOrDefaultAsync(x => x.Id == id);

            if (member == null) return NotFound();

            _context.ChoirMembers.Remove(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}