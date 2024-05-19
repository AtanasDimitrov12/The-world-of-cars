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
        string AddCarNews(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro);
        string UpdateNews(CarNews news);
        string AddComment(int NewsId, int UserId, DateTime CommentDate, string Content);
        string GetNewsId(string Title);
        string GetCommentId(DateTime date);
    }
}
