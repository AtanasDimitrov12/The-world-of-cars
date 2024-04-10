using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer.Enums;
using EntityLayout;
using InterfaceLayer;
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
        private readonly IDataAccess _dataAccess;
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public NewsManager(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            news = new List<CarNews>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public void AddNews(CarNews carnews)
        {
            _dataWriter.AddCarNews(carnews.Author, carnews.Title, carnews.ReleaseDate, carnews.NewsDescription, carnews.ImageURL, carnews.ShortIntro);
            carnews.Id = _dataWriter.GetNewsId(carnews.Title);
            news.Add(carnews);
        }

        public void DeleteNews(CarNews carnews)
        {
            news.Remove(carnews);
            _dataRemover.RemoveNews(carnews.Id);
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
            if (_dataAccess.GetCarNews() != null)
            {
                
                foreach (CarNewsDTO newsDTO in _dataAccess.GetCarNews())
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
