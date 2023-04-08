using CoffeeShopAPI.Context;
using CoffeeShopAPI.Models;
using System.Data;
using Dapper;

namespace CoffeeShopAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersWithPreference()
        {
            var storedProc = "spCustomer_GetAllCustomersWithPreference";

            using (var con = _context.CreateConnection())
            {
                var customer = await con.QueryAsync<Customer, CustomerPreference, Customer>(storedProc, (customer, customerPreference) =>
                {
                    customer.CustomerPrefence.Add(customerPreference);
                    return customer;
                }, commandType: CommandType.StoredProcedure);

                return customer.GroupBy(c => c.Id).Select(g =>
                {
                    var first = g.First();
                    first.CustomerPrefence = g.SelectMany(customer => customer.CustomerPrefence).ToList();
                    return first;
                });
            }
        }

        public async Task<int> CreateCustomer(Customer customer)
        {
            var storedProc = "[spCustomer_CreateCustomer]";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>
                    (
                    storedProc,
                    new
                    {
                        Name = customer.Name,
                        Address = customer.Address,
                        PhoneNumber = customer.PhoneNumber
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var sql = "SELECT * FROM Customer WHERE Id = @id";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Customer>(sql, new { id });
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var storedProc = "[spCustomer_DeleteCustomer]";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(storedProc, new { id }, commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var sql = "SELECT * FROM Customer";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Customer>(sql);
            }
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var storedProc = "[spCustomer_UpdateCustomer]";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(storedProc, new { customer.Id, customer.Name, customer.Address, customer.PhoneNumber }, commandType: CommandType.StoredProcedure ) > 0;
            }
        }
    }
}
