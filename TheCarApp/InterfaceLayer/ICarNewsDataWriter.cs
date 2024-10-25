using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace InterfaceLayer
{
    public interface ICarNewsDataWriter
    {
        Task AddCarNewsAsync(string author, string title, DateTime datePosted, string newsDescription, string imageURL, string intro);
        Task UpdateNewsAsync(News news);
        Task AddCommentAsync(int newsId, int userId, DateTime commentDate, string content);
        Task<int> GetNewsIdAsync(string title);
        Task<int> GetCommentIdAsync(DateTime date);
    }
}
