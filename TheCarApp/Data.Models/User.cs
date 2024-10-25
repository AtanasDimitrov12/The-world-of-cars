using System.ComponentModel.DataAnnotations;


namespace Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [MaxLength(20)]
        public string LicenseNumber { get; set; }

        public DateTime ModifiedOn { get; set; }

        [Required]
        public string Salt { get; set; }

        // Combined from UserProfilePictures table
        public string ProfilePictureFilePath { get; set; }

        // Relationships
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }



        public User()
        { 
            Comments = new HashSet<Comment>();
            Rentals = new HashSet<Rental>();
        }
    }

}
