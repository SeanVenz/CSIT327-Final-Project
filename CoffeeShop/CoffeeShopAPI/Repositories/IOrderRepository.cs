using CoffeeShopAPI.Context;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Dtos.Order;
using CoffeeShopAPI.Dtos.Barista;
using CoffeeShopAPI.Dtos.Product;

namespace CoffeeShopAPI.Repositories
{
    /// <summary>
    /// Interface for Order repository
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Creates an Order.
        /// </summary>
        /// <param name="order">Order Details (CustomerId, Date)</param>
        /// <returns>Id of the new order</returns>
        Task<int> CreateOrder(Order order);

        /// <summary>
        /// Assigns a Barista to an Order.
        /// </summary>
        /// <param name="baristaId">Barista Id</param>
        /// <param name="orderId">Order Id</param>
        /// <returns>Id of the connection between Barista and Order</returns>
        Task<bool> AssignBaristaToOrder(int baristaId, int orderId);

        /// <summary>
        /// Adds a Product to an Order.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="orderId">Order Id</param>
        /// <returns>Id of the connection between Product and Order</returns>
        Task<bool> AddProductToOrder(int productId, int orderId);

        /// <summary>
        /// Gets an Order by its Id.
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <returns>Id of the order</returns>
        Task<Order?> GetOrder(int id);

        /// <summary>
        /// Gets all Orders.
        /// </summary>
        /// <returns>All Orders</returns>
        Task<IEnumerable<Order>> GetAllOrders();

        /// <summary>
        /// Gets all Orders by Customer ID = <param name="customerId">Customer id</param>
        /// </summary>
        /// <returns>All Orders by a Customer</returns>
        Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId);

        /// <summary>
        /// Gets all Orders with Comment/s.
        /// </summary>
        /// <returns>All Orders with comments</returns>
        Task<IEnumerable<Order>> GetAllOrdersWithComments();

        /// <summary>
        /// Updates an Order.
        /// </summary>
        /// <param name="order">New Order Details</param>
        /// <returns>True if update is successful, otherwise false</returns>
        Task<bool> UpdateOrder(Order order);

        /// <summary>
        /// Deletes an Order.
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <returns>True if deletion is successful, otherwise false</returns>
        Task<bool> DeleteOrder(int id);
    }
}
