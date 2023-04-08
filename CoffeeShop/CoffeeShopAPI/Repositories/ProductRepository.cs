using CoffeeShopAPI.Context;
using CoffeeShopAPI.Models;
using Dapper;

namespace CoffeeShopAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProduct(Product product)
        {
            var sql = "INSERT INTO Product (Category, Name, Description, Price) VALUES (@Category, @Name, @Description, @Price); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, product);
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var sql = "DELETE FROM Product WHERE Id = @id";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var sql = "SELECT * FROM Product";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Product>(sql);
            }
        }

        public async Task<Product?> GetProduct(int id)
        {
            var sql = "SELECT * FROM Product WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Product>(sql, new { id });
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var sql = "UPDATE [dbo].[Product] SET [Category] = @Category, [Name] = @Name, [Description] = @Description, [Price] = @Price "
                + "WHERE Id = @id";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { product.Category, product.Name,product.Description,product.Price, product.Id}) > 0;
            }
        }
    }

}
