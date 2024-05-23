using Database;
using Entity_Layer;
using EntityLayout;
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
        private readonly ICarNewsDataWriter _dataWriter;
        private readonly ICarNewsDataRemover _dataRemover;

        public CommentsManager(IDataAccess dataAccess, ICarNewsDataWriter dataWriter, ICarNewsDataRemover dataRemover)
        {
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public string AddComment(CarNews news, Comment comment)
        {
            try
            {
                _dataWriter.AddComment(news.Id, comment.UserId, comment.Date, comment.Message);
                int CommentId = _dataWriter.GetCommentId(comment.Date);
                comment.Id = CommentId;
                news.AddComment(comment);
                return "done";
            } 
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }

        public string RemoveComment(CarNews news, Comment comment)
        {
            try
            {
                _dataRemover.RemoveComment(comment.Id);
            news.RemoveComment(comment);
            return "done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
