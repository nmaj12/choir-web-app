using System.ComponentModel.DataAnnotations;

namespace choir_app.Models
{
    public class FileResource
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty; 

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}