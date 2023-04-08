using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Repositories
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// Get all payments
        /// </summary>
        /// <returns>All Payments</returns>
        Task<IEnumerable<Payment>> GetAllPayments();

        /// <summary>
        /// Create a payment
        /// </summary>
        /// <param name="payment">payment Model</param>
        /// <returns>Id of the new paymen</returns>
        Task<int> CreatePayment(Payment payment);

        /// <summary>
        /// Get paymnetby Id
        /// </summary>
        /// <param name="id">Id of the payment</param>
        /// <returns>Id of the paymnet</returns>
        Task<Payment> GetPayment(int id);

        /// <summary>
        /// Updates a payment of the order
        /// </summary>
        /// <param name="payment">Payment Model</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> UpdatePayment(Payment payment);

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <param name="id">Id of the payment</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> DeletePayment(int id);
    }
}
