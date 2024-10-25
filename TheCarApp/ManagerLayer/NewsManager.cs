using AutoMapper;
using Data.Models;
using DTO;
using DTO.Interfaces;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class NewsManager : INewsManager
    {
        public List<CarNewsDTO> News { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly ICarNewsDataWriter _dataWriter;
        private readonly ICarNewsDataRemover _dataRemover;
        private readonly IMapper _mapper;

        public NewsManager(IDataAccess dataAccess, ICarNewsDataWriter dataWriter, ICarNewsDataRemover dataRemover, IMapper mapper)
        {
            News = new List<CarNewsDTO>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            _mapper = mapper;
        }

        // Adds a new news article and maps from CarNewsDTO
        public async Task<(bool Success, string ErrorMessage)> AddNewsAsync(CarNewsDTO carNewsDTO)
        {
            try
            {
                // Map DTO to entity
                var carNews = _mapper.Map<News>(carNewsDTO);

                await _dataWriter.AddCarNewsAsync(carNews.Author, carNews.Title, carNews.DatePosted, carNews.NewsDescription, carNews.ImageURL, carNews.ShortIntro);

                // Get the NewsId from the database
                int newsId = await _dataWriter.GetNewsIdAsync(carNews.Title);
                carNews.NewsId = newsId;

                // Map back to DTO and add to the list
                var updatedNewsDTO = _mapper.Map<CarNewsDTO>(carNews);
                News.Add(updatedNewsDTO);

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Deletes a news article and removes its related comments
        public async Task<(bool Success, string ErrorMessage)> DeleteNewsAsync(CarNewsDTO carNewsDTO)
        {
            try
            {
                // Map DTO to entity
                var carNews = _mapper.Map<News>(carNewsDTO);

                // Remove related comments
                foreach (var comment in carNews.Comments)
                {
                    await _dataRemover.RemoveCommentAsync(Convert.ToInt32(comment.NewsId));
                }

                // Remove the news article
                await _dataRemover.RemoveNewsAsync(carNews.NewsId);
                News.Remove(carNewsDTO);

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Updates a news article
        public async Task<(bool Success, string ErrorMessage)> UpdateNewsAsync(CarNewsDTO carNewsDTO)
        {
            try
            {
                // Map DTO to entity
                var carNews = _mapper.Map<News>(carNewsDTO);

                // Update the news
                await _dataWriter.UpdateNewsAsync(carNews);

                // Update the DTO list
                var index = News.FindIndex(n => n.Id == carNews.NewsId);
                if (index != -1)
                {
                    News[index] = carNewsDTO;
                }

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Gets the list of news sorted in ascending order by date
        public List<CarNewsDTO> GetNewsASC()
        {
            News.Sort(new CarNewsDateAscendingComparer());
            return News;
        }

        // Gets the list of news sorted in descending order by date
        public List<CarNewsDTO> GetNewsDESC()
        {
            News.Sort(new CarNewsDateDescendingComparer());
            return News;
        }

        // Gets a news article by its ID
        public CarNewsDTO GetNewsById(int id)
        {
            return News.FirstOrDefault(n => n.Id == id);
        }

        // Loads news from the database and maps them to DTOs
        public async Task<(bool Success, string ErrorMessage)> LoadNewsAsync()
        {
            try
            {
                var carNewsList = await _dataAccess.GetCarNewsAsync();
                if (carNewsList != null)
                {
                    News.Clear();
                    foreach (var newsDTO in carNewsList)
                    {
                        // Map each news entity to DTO
                        var mappedNews = _mapper.Map<CarNewsDTO>(newsDTO);
                        News.Add(mappedNews);
                    }
                }
                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }
    }
}
