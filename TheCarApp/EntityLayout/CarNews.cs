﻿using System;
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
        public List<Comment> comments { get; set; }

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
            comments = Comments;
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public void RemoveComment(Comment comment) 
        {
            comments.Remove(comment);
        }

        public List<Comment> GetComments() 
        {
            return comments; 
        } 

    }
}
