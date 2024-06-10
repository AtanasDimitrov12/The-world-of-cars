using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer.Enums;
using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using Entity_Layer.Interfaces;

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

        public bool AddNews(CarNews carnews, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.AddCarNews(carnews.Author, carnews.Title, carnews.ReleaseDate, carnews.NewsDescription, carnews.ImageURL, carnews.ShortIntro);
                int NewsId = _dataWriter.GetNewsId(carnews.Title);
                carnews.Id = NewsId;
                news.Add(carnews);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool DeleteNews(CarNews carnews, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                foreach (var comm in carnews.Comments)
                {
                    _dataRemover.RemoveComment(comm.Id);
                }
                _dataRemover.RemoveNews(carnews.Id);
                news.Remove(carnews);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool UpdateNews(CarNews news, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.UpdateNews(news);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public CarNews GetNewsById(int id)
        {
            return news.FirstOrDefault(n => n.Id == id);
        }

        public bool LoadNews(out string errorMessage)
        {
            errorMessage = string.Empty;
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
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
