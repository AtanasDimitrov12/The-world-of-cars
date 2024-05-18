using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class CarNews
    {

        public int Id { get; set; }
        public string NewsDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        public int NrOfMessages{ get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ShortIntro { get; set; }
        public List<Comment> Comments { get; set; }

        public CarNews(int Id, string newsDescription, DateTime releaseDate, string imageURL, string title, string author, string shortIntro, List<Comment> Comments)
        {
            this.Id = Id;
            NewsDescription = newsDescription;
            ReleaseDate = releaseDate;
            ImageURL = imageURL;
            NrOfMessages = 0;
            Title = title;
            Author = author;
            ShortIntro = shortIntro;
            this.Comments = Comments;
        }

        public CarNews(string newsDescription, DateTime releaseDate, string imageURL, string title, string author, string shortIntro)
        {
            NewsDescription = newsDescription;
            ReleaseDate = releaseDate;
            ImageURL = imageURL;
            NrOfMessages = 0;
            Title = title;
            Author = author;
            ShortIntro = shortIntro;
            Comments = new List<Comment>();
        }

        public CarNews() { }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
            NrOfMessages++; 
        }

        public void RemoveComment(Comment comment) 
        {
            Comments.Remove(comment);
            NrOfMessages--;
        }

        public List<Comment> GetComments() 
        {
            return Comments; 
        } 

    }
}
