using CoffeeShopAPI.Dtos.Payment;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Services
{
    public interface IPaymentService
    {
        /// <summary>
        /// Create a payment
        /// </summary>
        /// <param name="PaymentDto">payment Model</param>
        /// <returns>Id of the new paymen</returns>
        Task<PaymentDto> CreatePayment(PaymentCreationDto PaymentDto);

        /// <summary>
        /// Get all payments
        /// </summary>
        /// <returns>All Payments</returns>
        Task<IEnumerable<PaymentDto>> GetAllPayments();      

        /// <summary>
        /// Get paymnetby Id
        /// </summary>
        /// <param name="id">Id of the payment</param>
        /// <returns>Id of the paymnet</returns>
        Task<PaymentDto?> GetPayment(int id);

        /// <summary>
        /// Updates a payment 
        /// </summary>
        /// <param name="paymentId">Id of the payment</param>
        /// <param name="paymentToUpdate">Payment Model</param>
        /// <returns>true if updated, false if not</returns>
        Task UpdatePayment(int paymentId, PaymentCreationDto paymentToUpdate);

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <param name="id">Id of the payment</param>
        /// <returns>true if updated, false if not</returns>
        Task<bool> DeletePayment(int id);
    }
}
