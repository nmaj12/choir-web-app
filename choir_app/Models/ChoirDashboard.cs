using choir_app.Models;

namespace choir_app.Models
{
    public class ChoirDashboard
    {
        public List<News> News { get; set; }
        public List<Events> Events { get; set; }
        public List<FileResource> Files { get; set; }
        public List<Attendance> MyAttendance { get; set; }
        public ChoirMember? MyMember { get; set; }
    }
}