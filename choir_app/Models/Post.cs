using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace choir_app.Models
{
    public class Post
    {
        //komentarz
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [Display(Name = "Tytuł wpisu")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Treść wpisu jest wymagana")]
        [Display(Name = "Treść")]
        public string Content { get; set; }

        [Display(Name = "Data publikacji")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}