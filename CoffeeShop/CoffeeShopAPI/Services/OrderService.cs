using AutoMapper;
using CoffeeShopAPI.Dtos.Customer;
using CoffeeShopAPI.Dtos.CustomerPreference;
using CoffeeShopAPI.Dtos.Order;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Repositories;

namespace CoffeeShopAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _orderRepository = repository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrder(OrderCreationDto orderDto)
        {
            var orderModel = _mapper.Map<Order>(orderDto);
            orderModel.Id = await _orderRepository.CreateOrder(orderModel);
            return _mapper.Map<OrderDto>(orderModel);
        }

        public async Task<bool> AssignBaristaToOrder(int baristaId, int orderId)
        {
            return await _orderRepository.AssignBaristaToOrder(baristaId, orderId);
        }

        public async Task<bool> AddProductToOrder(int productId, int orderId)
        {
            return await _orderRepository.AddProductToOrder(productId, orderId);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orderModels = await _orderRepository.GetAllOrders();
            return _mapper.Map<IEnumerable<OrderDto>>(orderModels);
        }

        public async Task<IEnumerable<OrderGetAllDto>> GetAllOrdersWithComments()
        {
            var orderModels = await _orderRepository.GetAllOrdersWithComments();

            return _mapper.Map<IEnumerable<OrderGetAllDto>>(orderModels);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomer(int customerId)
        {
            var orderModel = await _orderRepository.GetOrdersByCustomer(customerId);
            if (orderModel == null) return null;
            return _mapper.Map<IEnumerable<OrderDto>>(orderModel);
        }

        public async Task<OrderDto?> GetOrder(int id)
        {
            var orderModel = await _orderRepository.GetOrder(id);
            if (orderModel == null) return null;

            return _mapper.Map<OrderDto>(orderModel);
        }

        public async Task<OrderDto> UpdateOrder(int id, OrderCreationDto orderToUpdate)
        {
            var orderModel = _mapper.Map<Order>(orderToUpdate);
            orderModel.Id = id;
            await _orderRepository.UpdateOrder(orderModel);
            var orderDto = _mapper.Map<OrderDto>(orderModel);

            return orderDto;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderRepository.DeleteOrder(id);
        }
    }
}
