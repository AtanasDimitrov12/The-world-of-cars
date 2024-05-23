using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarNewsDataWriter
    {
        void AddCarNews(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro);
        void UpdateNews(CarNews news);
        void AddComment(int NewsId, int UserId, DateTime CommentDate, string Content);
        int GetNewsId(string Title);
        int GetCommentId(DateTime date);
    }
}
