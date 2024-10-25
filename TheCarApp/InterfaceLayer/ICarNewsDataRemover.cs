
namespace InterfaceLayer
{
    public interface ICarNewsDataRemover
    {

        // Asynchronously removes a news entry by its ID
        Task RemoveNewsAsync(int newsId);

        // Asynchronously removes a comment entry by its ID
        Task RemoveCommentAsync(int commentId);

    }
}