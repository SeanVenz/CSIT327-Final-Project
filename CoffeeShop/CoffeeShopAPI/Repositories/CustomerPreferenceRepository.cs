using CoffeeShopAPI.Context;
using CoffeeShopAPI.Models;
using System.Data;
using Dapper;

namespace CoffeeShopAPI.Repositories
{
    public class CustomerPreferenceRepository : ICustomerPreferenceRepository
    {

        private readonly DapperContext _context;

        public CustomerPreferenceRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerPreference>> GetAllCustomerPreferences()
        {
            var sql = "SELECT * FROM CustomerPreference";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<CustomerPreference>(sql);
            }
        }

        public async Task<int> CreateCustomerPreference(CustomerPreference customerPreference)
        {
            var sql = "INSERT INTO CustomerPreference (Preference, CustomerId) VALUES (@Preference, @CustomerId); " +
                "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { customerPreference.Preference, CustomerId = customerPreference.CustomerId });
            }
        }

        public async Task<bool> DeleteCustomerPreference(int id)
        {
            var sql = "DELETE FROM CustomerPreference WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

        public async Task<CustomerPreference> GetCustomerPreference(int id)
        {
            var sql = "SELECT * FROM CustomerPreference WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<CustomerPreference>(sql, new { id });
            }
        }

        public async Task<bool> UpdatePreference(CustomerPreference customerPreference)
        {
            var storedProc = "[spCustomerPreference_UpdateCustomerPreference]";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(storedProc, new { customerPreference.Id, customerPreference.Preference }, commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
