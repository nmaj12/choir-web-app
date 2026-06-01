using System.ComponentModel.DataAnnotations;
using System;

namespace choir_app.Models
{
    public class Events
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty; // zmienilam name na title
        public string Description {  get; set; } = string.Empty; // dodalam description
        [Required]
        public DateTime Date { get; set; }

        public string Location { get; set; } = string.Empty;
    }
}
