using CoffeeShopAPI.Dtos.Comment;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Services
{
    public interface ICommentService
    {
        /// <summary>
        /// Create a comment
        /// </summary>
        /// <param name="CommentDto">Comment Model</param>
        /// <returns>Id of the new comment</returns>
        Task<CommentDto> CreateComment(CommentCreationDto CommentDto);

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns>All Comments</returns>
        Task<IEnumerable<CommentDto>> GetAllComments();
          
        /// <summary>
        /// Get comment by Id
        /// </summary>
        /// <param name="id">Id of the comment</param>
        /// <returns>Id of the comment</returns>
        Task<CommentDto?> GetComment(int id);

        /// <summary>
        /// Updates a comment 
        /// </summary>
        /// <param name="commentId">Id of the comment</param>
        /// <param name="commentToUpdate">Comment Model</param>
        /// <returns>true if updated, false if not</returns>
        Task UpdateComment(int commentId, CommentCreationDto commentToUpdate);

        /// <summary>
        /// Get comment by Id
        /// </summary>
        /// <param name="id">Id of the comment</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> DeleteComment(int id);
    }
}
