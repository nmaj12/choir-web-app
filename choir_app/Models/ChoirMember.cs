using choir_app.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace choir_app.Models
{
    public class ChoirMember
    {
        [Key]
        public int Id { get; set; }

        // połączenie z IdentityUser
        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        [Required]
        public VoiceType Voice { get; set; }

        public DateTime JoinDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public string Notes { get; set; }
    }
}
