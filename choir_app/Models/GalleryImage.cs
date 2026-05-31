using System.ComponentModel.DataAnnotations;

namespace choir_app.Models
{
    public class GalleryImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UploadedById { get; set; } = string.Empty;
    }
}