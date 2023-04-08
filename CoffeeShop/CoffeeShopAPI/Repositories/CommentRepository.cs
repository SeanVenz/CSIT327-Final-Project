using CoffeeShopAPI.Context;
using CoffeeShopAPI.Models;
using Dapper;
using System.Data;

namespace CoffeeShopAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DapperContext _context;

        public CommentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateComment(Comment comment)
        {
            var sql = "INSERT INTO Comment (Comments,OrdersId) VALUES (@Comments, @OrdersId); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, comment);
            }
        }

        public async Task<bool> DeleteComment(int id)
        {
            var sql = "DELETE FROM Comment WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            var sql = "SELECT * FROM Comment";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Comment>(sql);
            }
        }

        public async Task<Comment> GetComment(int id)
        {
            var sql = "SELECT * FROM Comment WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleAsync<Comment>(sql, new { id });
            }
        }

        public async Task<bool> UpdateComment(Comment comment)
        {
            var sql = "UPDATE [dbo].[Comment] SET [Comments] = @Comments, [OrdersId] = @OrdersId WHERE Id = @id";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { comment.Comments, comment.OrdersId, comment.Id }) > 0;
            }
        }
    }
}
