using CoffeeShopAPI.Context;
using CoffeeShopAPI.Models;
using Dapper;
using System.Data;
using System.Xml.Linq;

namespace CoffeeShopAPI.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DapperContext _context;

        public PaymentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePayment(Payment payment)
        {
            var sql = "INSERT INTO Payment (Amount,PaymentDate,OrdersId) VALUES (@Amount, @PaymentDate, @OrdersId); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, payment);
            }
        }

        public async Task<bool> DeletePayment(int id)
        {
            var sql = "DELETE FROM Payment WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            var sql = "SELECT * FROM Payment";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Payment>(sql);
            }
        }

        public async Task<Payment> GetPayment(int id)
        {
            var sql = "SELECT * FROM Payment WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleAsync<Payment>(sql, new { id });
            }
        }

        public async Task<bool> UpdatePayment(Payment payment)
        {
            var sql = "UPDATE [dbo].[Payment] SET [Amount] = @Amount, [PaymentDate] = @PaymentDate, [OrdersId] = @OrdersId WHERE Id = @id";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { payment.Amount, payment.PaymentDate, payment.OrdersId, payment.Id }) > 0;
            }           
        }
    }

}
