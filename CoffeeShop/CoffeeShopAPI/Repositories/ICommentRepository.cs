using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Repositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns>All Comments</returns>
        Task<IEnumerable<Comment>> GetAllComments();

        /// <summary>
        /// Create a comment
        /// </summary>
        /// <param name="comment">Comment Model</param>
        /// <returns>Id of the new comment</returns>
        Task<int> CreateComment(Comment comment);

        /// <summary>
        /// Get comment by Id
        /// </summary>
        /// <param name="id">Id of the comment</param>
        /// <returns>Id of the comment</returns>
        Task<Comment> GetComment(int id);

        /// <summary>
        /// Updates a comment 
        /// </summary>
        /// <param name="comment">Comment Model</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> UpdateComment(Comment comment);

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <param name="id">Id of the comment</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> DeleteComment(int id);
    }
}
