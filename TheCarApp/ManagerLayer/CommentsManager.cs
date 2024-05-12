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
        private readonly IDataWriter _dataWriter;
        private readonly IDataRemover _dataRemover;

        public CommentsManager(IDataAccess dataAccess, IDataWriter dataWriter, IDataRemover dataRemover)
        {
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
        }

        public string AddComment(CarNews news, Comment comment)
        {
            string Message = _dataWriter.AddComment(news.Id, comment.UserId, comment.Date, comment.Message);
            if (Message == "done")
            {

                string SearchID = _dataWriter.GetCommentId(comment.Date);
                int CommentId;
                if (int.TryParse(SearchID, out CommentId))
                {
                    comment.Id = CommentId;
                    news.AddComment(comment);
                    return "done";
                }
                else
                {
                    return SearchID;
                }
            }
            else
            {
                return Message; 
            }
            
        }

        

        public string RemoveComment(CarNews news, Comment comment)
        {

            string Message = _dataRemover.RemoveComment(comment.Id);
            if (Message == "done")
            {

                news.RemoveComment(comment);
                return "done";
            }
            else
            {
                return Message;
            }
        }
    }
}
