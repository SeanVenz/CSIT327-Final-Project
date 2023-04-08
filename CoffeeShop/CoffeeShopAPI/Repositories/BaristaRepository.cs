using CoffeeShopAPI.Context;
using CoffeeShopAPI.Models;
using Dapper;

namespace CoffeeShopAPI.Repositories
{
    public class BaristaRepository : IBaristaRepository
    {
        private readonly DapperContext _context;
        public BaristaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateBarista(Barista barista)
        {
            var sql = "INSERT INTO Barista (Name) VALUES (@Name); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, barista);
            }
        }

        public async Task<bool> DeleteBarista(int id)
        {
            var sql = "DELETE FROM Barista WHERE Id = @id";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

        public async Task<IEnumerable<Barista>> GetAllBaristas()
        {
            var sql = "SELECT * FROM Barista";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Barista>(sql);
            }
        }

        public async Task<Barista?> GetBarista(int id)
        {
            var sql = "SELECT * FROM Barista WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Barista>(sql, new { id });
            }
        }

        public async Task<bool> UpdateBarista(Barista barista)
        {
            var sql = "UPDATE [dbo].[Barista] SET [Name] = @Name WHERE Id = @id";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { barista.Name,barista.Id}) > 0;
            }
        }
    }
}
