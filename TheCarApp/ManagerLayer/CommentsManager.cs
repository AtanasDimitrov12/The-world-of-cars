using Database;
using Entity_Layer;
using EntityLayout;
using InterfaceLayer;
using System;

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

        public bool AddComment(CarNews news, Comment comment, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataWriter.AddComment(news.Id, comment.UserId, comment.Date, comment.Message);
                int commentId = _dataWriter.GetCommentId(comment.Date);
                comment.Id = commentId;
                news.Comments.Add(comment);
                news.NrOfComments++;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool RemoveComment(CarNews news, Comment comment, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                _dataRemover.RemoveComment(comment.Id);
                news.Comments.Remove(comment);
                news.NrOfComments--;
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
