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
using Entity_Layer.Interfaces;
using System.Xml.Linq;

namespace Entity_Layer
{
    public class NewsManager : INewsManager
    {
        public List<CarNews> news { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly ICarNewsDataWriter _dataWriter;
        private readonly ICarNewsDataRemover _dataRemover;

        public NewsManager(IDataAccess dataAccess, ICarNewsDataWriter dataWriter, ICarNewsDataRemover dataRemover)
        {
            news = new List<CarNews>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public string AddNews(CarNews carnews)
        {
            try
            {
                _dataWriter.AddCarNews(carnews.Author, carnews.Title, carnews.ReleaseDate, carnews.NewsDescription, carnews.ImageURL, carnews.ShortIntro);
                int NewsId = _dataWriter.GetNewsId(carnews.Title);
                carnews.Id = NewsId;
                news.Add(carnews);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public string DeleteNews(CarNews carnews)
        {
            try
            {
                foreach (var comm in carnews.Comments)
                {
                    _dataRemover.RemoveComment(comm.Id);
                }
                _dataRemover.RemoveNews(carnews.Id);
                news.Remove(carnews);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateNews(CarNews news)
        {
            try
            {
                _dataWriter.UpdateNews(news);
                return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public CarNews GetNewsById(int id)
        {
            foreach (var News in news)
            {
                if (News.Id == id)
                {
                    return News;
                }
            }
            return null;
        }

        public string LoadNews()
        {
            try
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
                return "done";
            }
            catch (ApplicationException ex)
            {
                return ex.Message;
            }

        }
    }
}
