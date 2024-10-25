using Data;
using InterfaceLayer;

namespace DatabaseAccess
{
    public class CarNewsDataRemover : ICarNewsDataRemover
    {
        private readonly CarAppContext _context;

        public CarNewsDataRemover(CarAppContext context)
        {
            _context = context;
        }

        // Removes a News entry
        public async Task RemoveNewsAsync(int newsId)
        {
            try
            {
                var news = await _context.News.FindAsync(newsId);
                if (news != null)
                {
                    _context.News.Remove(news);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"News with ID {newsId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Removes a Comment entry
        public async Task RemoveCommentAsync(int commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                if (comment != null)
                {
                    _context.Comments.Remove(comment);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Comment with ID {commentId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
