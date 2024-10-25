using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public DateTime CommentDate { get; set; }

        [Required]
        public string Content { get; set; }

        // Foreign Key to User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign Key to News
        [ForeignKey("News")]
        public int? NewsId { get; set; }
        public virtual News News { get; set; }
    }

}
