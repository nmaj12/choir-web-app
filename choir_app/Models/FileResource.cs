using System.ComponentModel.DataAnnotations;

namespace choir_app.Models
{
    public class FileResource
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string FileType { get; set; } // pdf/mp3/nuty

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}