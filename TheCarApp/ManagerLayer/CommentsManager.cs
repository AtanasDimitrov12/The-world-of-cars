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
    public class CommentsManager
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

        public void AddComment(CarNews news, Comment comment, User user)
        {
            _dataWriter.AddComment(news.Id, user.Id, comment.Date, comment.Message);
            comment.Id = _dataWriter.GetCommentId(comment.Date);
            news.AddComment(comment);
        }

        public void RemoveComment(CarNews news, Comment comment)
        {
            _dataRemover.RemoveComment(comment.Id);
            news.RemoveComment(comment);
        }

    }
}
