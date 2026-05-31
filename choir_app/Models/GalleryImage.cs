using System.ComponentModel.DataAnnotations;

namespace choir_app.Models
{
    public class GalleryImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UploadedById { get; set; }
    }
}