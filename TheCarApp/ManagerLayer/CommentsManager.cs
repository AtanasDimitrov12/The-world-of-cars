using AutoMapper;
using InterfaceLayer;
using Data.Models;
using DTO;

namespace ManagerLayer
{
    public class CommentsManager : ICommentsManager
    {
        private readonly ICarNewsDataWriter _dataWriter;
        private readonly ICarNewsDataRemover _dataRemover;
        private readonly IMapper _mapper;

        public CommentsManager(ICarNewsDataWriter dataWriter, ICarNewsDataRemover dataRemover, IMapper mapper)
        {
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            _mapper = mapper;
        }

        // Adds a comment to a news article and maps it to CommentDTO
        public async Task<(bool Success, string ErrorMessage)> AddCommentAsync(CarNewsDTO newsDTO, CommentDTO commentDTO)
        {
            try
            {
                // Map DTO to entity
                var comment = _mapper.Map<Comment>(commentDTO);

                // Add the comment using the data writer
                await _dataWriter.AddCommentAsync(newsDTO.Id, comment.UserId, comment.CommentDate, comment.Content);

                // Retrieve the comment ID and update the comment entity
                int commentId = await _dataWriter.GetCommentIdAsync(comment.CommentDate);
                comment.CommentId = commentId;

                // Map the updated comment back to DTO and add it to the DTO list
                commentDTO.Id = commentId;
                newsDTO.Comments.Add(commentDTO);
                newsDTO.NrOfComments++;

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Ensure that the error message is returned correctly
            }
        }



        // Removes a comment from a news article and updates the DTO
        public async Task<(bool Success, string ErrorMessage)> RemoveCommentAsync(CarNewsDTO newsDTO, CommentDTO commentDTO)
        {
            try
            {
                // Map DTO to entity
                var comment = _mapper.Map<Comment>(commentDTO);

                // Remove the comment using the data remover
                await _dataRemover.RemoveCommentAsync(comment.CommentId);

                // Remove the comment from the DTO list and update the comment count
                newsDTO.Comments.Remove(commentDTO);
                newsDTO.NrOfComments--;

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
