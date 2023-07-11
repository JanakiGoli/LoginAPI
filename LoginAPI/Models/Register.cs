using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string username { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string  password { get; set; }

        [Required]
        [EmailAddress]
        public string  Email { get; set; }
    }
}
