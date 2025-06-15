using System;
using System.ComponentModel.DataAnnotations;

namespace Patrik_Pospisil_Portfolio_Web.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime DateSent { get; set; } = DateTime.Now;
    }
}
