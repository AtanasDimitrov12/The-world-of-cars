using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Administrator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
