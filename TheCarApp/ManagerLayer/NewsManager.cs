using Database;
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

        public NewsManager()
        {

            news = new List<CarNews>();
        }

        public void AddNews(CarNews News)
        {
            news.Add(News);
        }

        public void DeleteNews(CarNews News)
        {
            news.Remove(News);
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

                    CarNews loadnews = new CarNews(newsDTO.NewsDescription, newsDTO.ReleaseDate, newsDTO.ImageURL, newsDTO.Title, newsDTO.Author, newsDTO.ShortIntro, loadComments);

                    news.Add(loadnews);
                }
            }
        }
    }
}
