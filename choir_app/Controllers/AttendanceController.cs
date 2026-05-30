using choir_app.Data;
using choir_app.Models;
using Microsoft.AspNetCore.Mvc;

public class AttendanceController : Controller
{
    private readonly ApplicationDbContext _context;

    public AttendanceController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.Attendances.ToList();
        return View(list);
    }

    public IActionResult Set(int eventId, string status)
    {
        var attendance = new Attendance
        {
            EventId = eventId,
            Status = status,
            UserId = "demo-user"
        };

        _context.Attendances.Add(attendance);
        _context.SaveChanges();

        return RedirectToAction("Index", "Events");
    }
}