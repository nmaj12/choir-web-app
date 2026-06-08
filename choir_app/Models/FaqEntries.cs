using System.ComponentModel.DataAnnotations; 

namespace choir_app.Models
{
    public class FaqEntries
    {
        [Key] 
        public int Id { get; set; }

        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}