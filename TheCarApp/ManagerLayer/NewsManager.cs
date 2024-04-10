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
    public class NewsManager : INewsManager
    {
        private List<CarNews> news;
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

        public void LoadNews()
        {
            var carNewsList = _dataAccess.GetCarNews();
            if (carNewsList != null)
            {
                foreach (CarNewsDTO newsDTO in carNewsList)
                {
                    var loadComments = newsDTO.comments.Select(comment => new Comment(comment.Id, comment.UserId, comment.Date, comment.Content)).ToList();
                    var loadnews = new CarNews(newsDTO.Id, newsDTO.NewsDescription, newsDTO.ReleaseDate, newsDTO.ImageURL, newsDTO.Title, newsDTO.Author, newsDTO.ShortIntro, loadComments);
                    news.Add(loadnews);
                }
            }
        }
    }
}
