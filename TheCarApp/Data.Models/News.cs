using System.ComponentModel.DataAnnotations;


namespace Data.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        public DateTime DatePosted { get; set; }

        public string NewsDescription { get; set; }

        [MaxLength(255)]
        public string ImageURL { get; set; }

        [MaxLength(255)]
        public string ShortIntro { get; set; }

        // Relationships
        public virtual ICollection<Comment> Comments { get; set; }

        public News()
        { 
            Comments = new HashSet<Comment>();
        }
    }
 
}
