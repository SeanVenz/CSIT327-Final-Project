using CoffeeShopAPI.Dtos.Order;
using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.Services
{
    public interface IOrderService
    {

        /// <summary>
        /// Inserts an order of the customer
        /// </summary>
        /// <param name="orderDto">Order details</param>
        /// <returns>the id of the preference</returns>
        Task<OrderDto> CreateOrder(OrderCreationDto orderDto);

        /// <summary>
        /// Assigns barista to an order
        /// </summary>
        /// <param name="baristaId">Barista Id to assign to order</param>
        /// <param name="orderId">Order Id to be assigned</param>
        /// <returns>Id of the new order</returns>
        Task<bool> AssignBaristaToOrder(int baristaId, int orderId);

        /// <summary>
        /// Adds product to an order
        /// </summary>
        /// <param name="productId">Product Id to add to order</param>
        /// <param name="orderId">Order Id to be assigned</param>
        /// <returns>Id of the new order</returns>
        Task<bool> AddProductToOrder(int productId, int orderId);

        /// <summary>
        /// Get all orders with products
        /// </summary>
        /// <returns>All Orders with Products</returns>
        Task<IEnumerable<OrderDto>> GetAllOrders();

        /// <summary>
        /// Get all orders with comments
        /// </summary>
        /// <returns>All Orders with comments</returns>
        Task<IEnumerable<OrderGetAllDto>> GetAllOrdersWithComments();

        /// <summary>
        /// Get all orders by a customer
        /// </summary>
        /// <param name="customerId">ID of the customer</param>
        /// <returns>All Orders by a customer</returns>
        Task<IEnumerable<OrderDto>> GetOrdersByCustomer(int customerId);

        /// <summary>
        /// Get order by Id
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <returns>Id of the order</returns>
        Task<OrderDto?> GetOrder(int id);

        /// <summary>
        /// Update an order
        /// </summary>
        /// <param name="id">Id of Order to Update</param>
        /// <param name="orderToUpdate">Details of Order to Update</param>
        /// <returns>Id of the new order</returns>
        Task<OrderDto> UpdateOrder(int id, OrderCreationDto orderToUpdate);

        /// <summary>
        /// Delete an order
        /// </summary>
        /// <param name="id">Id of the order</param>
        /// <returns>Id of the deleted order</returns>
        Task<bool> DeleteOrder(int id);
    }
}
