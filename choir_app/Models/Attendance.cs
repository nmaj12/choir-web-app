using choir_app.Data;
using Microsoft.AspNetCore.SignalR;

namespace choir_app.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public Events? Event { get; set; }

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public string Status { get; set; } = string.Empty;
        // "present", "absent", "maybe"
    }
}
