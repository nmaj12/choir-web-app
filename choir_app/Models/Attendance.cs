namespace choir_app.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string UserId { get; set; }

        public string Status { get; set; }
        // "present", "absent", "maybe"
    }
}
