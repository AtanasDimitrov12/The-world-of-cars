using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer.Enums;
using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class NewsManager
    {

        private List<CarNews> news { get; set; }
        private DataAccess access;
        private DataWriter writer;
        private DataRemover remover;

        public NewsManager()
        {

            news = new List<CarNews>();
            access = new DataAccess();
            writer = new DataWriter();
            remover = new DataRemover();
        }

        public void AddNews(CarNews carnews)
        {
            news.Add(carnews);
            writer.AddCarNews(carnews.Author, carnews.Title, carnews.ReleaseDate, carnews.NewsDescription, carnews.ImageURL, carnews.ShortIntro);
        }

        public void DeleteNews(CarNews carnews)
        {
            news.Remove(carnews);
            remover.RemoveNews(carnews.Id);
        }

        public List<CarNews> GetNews()
        {
            return news;
        }

        public void AddComment(CarNews news, Comment comment)
        {
            news.AddComment(comment);
        }

        public void RemoveComment(CarNews news, Comment comment)
        {
            news.RemoveComment(comment);
        }

        public List<Comment> GetComments(CarNews news)
        {
            return news.GetComments();
        }

        public void LoadNews()
        {
            if (access.GetCarNews() != null)
            {
                
                foreach (CarNewsDTO newsDTO in access.GetCarNews())
                {
                    List<Comment> loadComments = new List<Comment>();   
                    foreach (CommentDTO comment in newsDTO.comments)
                    {
                        Comment comm = new Comment(comment.Id, comment.UserId, comment.Date, comment.Content);
                        loadComments.Add(comm);
                    }

                    CarNews loadnews = new CarNews(newsDTO.Id, newsDTO.NewsDescription, newsDTO.ReleaseDate, newsDTO.ImageURL, newsDTO.Title, newsDTO.Author, newsDTO.ShortIntro, loadComments);

                    news.Add(loadnews);
                }
            }
        }
    }
}
