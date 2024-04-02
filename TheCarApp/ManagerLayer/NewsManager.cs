using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class NewsManager
    {
       
        private List<CarNews> news { get; set;}

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
    }
}
