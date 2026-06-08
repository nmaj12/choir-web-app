using choir_app.Models;

namespace choir_app.Models
{
    public class AdminDashboardViewModel
    {
        // Statystyki
        public int TotalMembers { get; set; }
        public int UpcomingEventsCount { get; set; }
        public int TotalPhotos { get; set; }
        public int TotalNews { get; set; }

        // Listy do tabel
        public List<Events> RecentEvents { get; set; } = new();
        public List<News> RecentNews { get; set; } = new();
        public List<GalleryImage> RecentPhotos { get; set; } = new();

        // Aktywność
        public List<ActivityLogItem> RecentActivity { get; set; } = new();
    }

    public class ActivityLogItem
    {
        public string Icon { get; set; } = "clock";
        public string Message { get; set; } = string.Empty;
        public string TimeAgo { get; set; } = string.Empty;
    }
}