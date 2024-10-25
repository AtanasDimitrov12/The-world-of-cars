using DTO;

namespace InterfaceLayer
{
    public interface ICommentsManager
    {
        Task<(bool Success, string ErrorMessage)> AddCommentAsync(CarNewsDTO newsDTO, CommentDTO commentDTO);

        Task<(bool Success, string ErrorMessage)> RemoveCommentAsync(CarNewsDTO newsDTO, CommentDTO commentDTO);
    }
}
