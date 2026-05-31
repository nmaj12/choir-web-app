using Microsoft.Build.Framework;

namespace choir_app.Models
{
    public class Events
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }

        public string Location { get; set; } = string.Empty;
    }
}
