using Database;
using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class CommentsManager : ICommentsManager
    {
        private readonly IDataAccess _dataAccess;
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public CommentsManager(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public void AddComment(CarNews news, Comment comment)
        {
            _dataWriter.AddComment(news.Id, comment.UserId, comment.Date, comment.Message);
            comment.Id = _dataWriter.GetCommentId(comment.Date); // This assumes GetCommentId method exists and works as intended.
            news.AddComment(comment);
        }

        

        public void RemoveComment(CarNews news, Comment comment)
        {
            _dataRemover.RemoveComment(comment.Id);
            news.RemoveComment(comment);
        }
    }
}
