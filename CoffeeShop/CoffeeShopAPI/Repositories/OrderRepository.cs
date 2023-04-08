using CoffeeShopAPI.Context;
using CoffeeShopAPI.Dtos.Product;
using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Models;
using Dapper;
using System.Data;

namespace CoffeeShopAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Stores db server connection string initialized in the constructor to map objects
        /// </summary>
        private readonly DapperContext _context;

        /// <summary>
        /// Constructor where _context is initialized with my db server connection string
        /// </summary>
        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(Order order)
        {
            var sql = "INSERT INTO Orders (Date, CustomerId) " +
                "VALUES (@Date, @CustomerId); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { order.Date, CustomerId = order.CustomerId });
            }
        }

        public async Task<bool> AssignBaristaToOrder(int baristaId, int orderId)
        {
            var sql = "INSERT INTO Orders_Barista (BaristaId, OrdersId) VALUES (@BaristaId, @OrdersId)" +
             "SELECT SCOPE_IDENTITY();";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { BaristaId = baristaId, OrdersId = orderId }) > 0;
            }
        }

        public async Task<bool> AddProductToOrder(int productId, int orderId)
        {
            var sql = "INSERT INTO Orders_Product (ProductId, OrdersId) VALUES (@ProductId, @OrdersId)" +
             "SELECT SCOPE_IDENTITY();";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { ProductId = productId, OrdersId = orderId }) > 0;
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var sql = "spOrder_GetAllOrders";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<Order, ProductDto, Order>(
                    sql,
                    MapProductOrder,
                    commandType: CommandType.StoredProcedure);

                return result.GroupBy(s => s.Id).Select(OrderGroup =>
                {
                    var firstOrder = OrderGroup.First();
                    firstOrder.Products = OrderGroup.SelectMany(order => order.Products).ToList();
                    return firstOrder;
                });
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithComments()
        {
            var storedProc = "spOrder_GetAllOrdersWithComments";

            using (var con = _context.CreateConnection())
            {
                var order = await con.QueryAsync<Order, Comment, Order>(storedProc, (order, comment) =>
                {
                    order.Comments.Add(comment);
                    return order;
                }, commandType: CommandType.StoredProcedure);

                return order.GroupBy(c => c.Id).Select(g =>
                {
                    var first = g.First();
                    first.Comments = g.SelectMany(order => order.Comments).ToList();
                    return first;
                });
            }
        }

        public async Task<Order?> GetOrder(int id)
        {
            var sql = "SELECT * FROM Orders WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleAsync<Order>(sql, new { id });
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
                {
                    var sql = "SELECT * FROM Order WHERE CustomerId = @id";

                    using (var con = _context.CreateConnection())
                    {
                        return await con.QueryAsync<Order>(sql, new { customerId });
                    }
                }

        public async Task<bool> UpdateOrder(Order order)
        {
            var sql = "UPDATE Orders SET Date = @Date, CustomerId = @CustomerId";

            using (var connection = _context.CreateConnection())
            {
                int rowsAffected = await connection.ExecuteAsync(sql, new { order.Date, order.CustomerId});
                return rowsAffected > 0 ? true : false;
            }
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var sql = "DELETE FROM Orders WHERE Id = @id";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

        private static Order MapProductOrder(Order order, ProductDto product)
        {
            order.Products.Add(product);
            return order;
        }
    }

}
