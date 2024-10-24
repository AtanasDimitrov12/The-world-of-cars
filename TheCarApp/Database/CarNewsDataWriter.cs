using System;
using System.Threading.Tasks;
using Data;
using Data.Models;
using InterfaceLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class CarNewsDataWriter : ICarNewsDataWriter
    {
        private readonly CarAppContext _context;

        public CarNewsDataWriter(CarAppContext context)
        {
            _context = context;
        }

        public async Task AddCarNewsAsync(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro)
        {
            try
            {
                var news = new News
                {
                    Author = Author,
                    Title = Title,
                    DatePosted = DatePosted,
                    NewsDescription = NewsDescription,
                    ImageURL = ImageURL,
                    ShortIntro = Intro
                };

                await _context.News.AddAsync(news);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding news: {ex.Message}");
            }
        }

        public async Task UpdateNewsAsync(News news)
        {
            try
            {
                _context.News.Update(news);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating news: {ex.Message}");
            }
        }

        public async Task AddCommentAsync(int NewsId, int UserId, DateTime CommentDate, string Content)
        {
            try
            {
                var comment = new Comment
                {
                    NewsId = NewsId,
                    UserId = UserId,
                    CommentDate = CommentDate,
                    Content = Content
                };

                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a comment: {ex.Message}");
            }
        }

        public async Task<int> GetNewsIdAsync(string Title)
        {
            try
            {
                var news = await _context.News
                    .FirstOrDefaultAsync(n => n.Title == Title);

                return news != null ? news.NewsId : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting the News ID: {ex.Message}");
                return -1;
            }
        }

        public async Task<int> GetCommentIdAsync(DateTime date)
        {
            try
            {
                var comment = await _context.Comments
                    .FirstOrDefaultAsync(c => c.CommentDate == date);

                return comment != null ? Convert.ToInt32(comment.NewsId) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting the Comment ID: {ex.Message}");
                return -1;
            }
        }
    }
}
