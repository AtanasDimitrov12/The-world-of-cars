﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DateTime CreatedOn { get; set; }

        [Required]
        public string Salt { get; set; }

        // Combined from UserProfilePictures table
        public string ProfilePictureFilePath { get; set; }
        public DateTime? ProfilePictureUploadedOn { get; set; }

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
